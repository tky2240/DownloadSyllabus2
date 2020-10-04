using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using static DownloadSyllabus2.Globals;

namespace DownloadSyllabus2 {
    public class ConnectSyllabus {
        private string ID;
        private string PW;
        ChromeDriver driver;
        SshClient sshClient;
        ForwardedPortDynamic portDynamic;

        public bool Start_Download(DataTable csvTable) {

            Progress progress = new Progress();
            progress.Set_Max = csvTable.Rows.Count + 6;
            progress.Show();

            progress.Set_Text = "アカウント情報を取得しています...";
            progress.Add_ProgressBar();
            if (!Input_Account()) {
                progress.Quit();
                return false;
            }

            progress.Set_Text = "SSH接続を試行しています...";
            progress.Add_ProgressBar();
            if (!Connect_SSH()) {
                portDynamic.Stop();
                portDynamic.Dispose();
                sshClient.Disconnect();
                sshClient.Dispose();
                progress.Quit();
                return false;
            }

            progress.Set_Text = "Chromeの準備をしています...";
            progress.Add_ProgressBar();
            ChromeOptions options = Set_Options();
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            progress.Set_Text = "UEC統合認証中...";
            progress.Add_ProgressBar();
            if (!UEC_Authorization()) {
                Terminate_Chrome();
                progress.Quit();
                return false;
            }

            progress.Set_Text = "シラバス検索ページへ遷移中...";
            progress.Add_ProgressBar();
            if (!Goto_SearchPage()) {
                Terminate_Chrome();
                progress.Quit();
                return false;
            }
            foreach(DataRow row in csvTable.Rows) {
                progress.Set_Text = $"{string.Join(",", row.ItemArray)}を取得中...";
                progress.Add_ProgressBar();
                if (!Search_Syllabus(row)) {
                    MessageBox.Show($"次の行のシラバス取得に失敗しました。項目を見直してください。\n{string.Join(",", row.ItemArray)}");
                    if (!Goto_SearchPage()) {
                        Terminate_Chrome();
                        progress.Quit();
                        return false;
                    }
                    continue;
                }
                if (!Download_and_Reference_Syllabus(row)) {
                    MessageBox.Show($"次の行のシラバス取得に失敗しました。項目を見直してください。\n{string.Join(",", row.ItemArray)}");
                    if (!Goto_SearchPage()) {
                        Terminate_Chrome();
                        progress.Quit();
                        return false;
                    }
                }
                if (!Goto_SearchPage()) {
                    Terminate_Chrome();
                    progress.Quit();
                    return false;
                }
            }
            progress.Set_Text = "Chromeの終了処理中...";
            progress.Add_ProgressBar();
            Terminate_Chrome();
            progress.Quit();
            return true;
        }

        private bool Input_Account() {
            Input_ID _ID = new Input_ID();
            if (_ID.ShowDialog() == DialogResult.OK) {
                ID = _ID.GetID;
            } else {
                MessageBox.Show("中止しました。");
                return false;
            }
            Input_PW _PW = new Input_PW();
            _PW.DialogResult = DialogResult.None;
            while (_PW.DialogResult == DialogResult.None) {
                if (_PW.ShowDialog() == DialogResult.OK) {
                    PW = _PW.GetPW;
                } else if (_PW.DialogResult == DialogResult.Cancel){
                    MessageBox.Show("中止しました。");
                    return false;
                }
            }
            return true;
        }

        private bool Connect_SSH() {
            try {
                sshClient = new SshClient("sol.edu.cc.uec.ac.jp", ID, PW);
                portDynamic = new ForwardedPortDynamic("127.0.0.1", 8080);
                sshClient.Connect();
                sshClient.AddForwardedPort(portDynamic);
                portDynamic.Start();
            } catch (SshConnectionException e){
                MessageBox.Show($"SSHコネクションが切断されました。\n{e.Message}");
                return false;
            } catch (SshAuthenticationException e) {
                MessageBox.Show($"SSH認証に失敗しました。\n{e.Message}");
                return false;
            } catch (SocketException e) {
                MessageBox.Show($"ソケットエラーです。\n多重起動していないか確認してください。\n{e.Message}");
                return false;
            } catch (Exception e){
                MessageBox.Show($"不明なSSH接続時のエラーです。\n{e.Message}");
                return false;
            }
            return true;
        }

        private ChromeOptions Set_Options() {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", folderPath);
            options.AddUserProfilePreference("browser.download.dir", folderPath);
            options.AddUserProfilePreference("browser.download.manager.showWhenStarting", false);
            options.AddUserProfilePreference("browser.download.manager.alertOnEXEOpen", false);
            options.AddUserProfilePreference("browser.download.manager.closeWhenDone", false);
            options.AddUserProfilePreference("browser.download.folderList", 2);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("plugins.plugins_disabled", "Chrome PDF Viewer");
            options.AddUserProfilePreference("download.directory_upgrade", true);
            //options.AddArguments("--proxy-server=socks5://127.0.0.1:8080");
            options.AddArguments("--proxy-server=socks5://127.0.0.1:8080", "--headless");
            return options;
        }

        private bool UEC_Authorization() {
            try {
                driver.Url = "https://campusweb.office.uec.ac.jp/campusweb/";
                driver.FindElementById("username").SendKeys(ID);
                driver.FindElementById("password").SendKeys(PW);
                driver.FindElementByName("_eventId_proceed").Click();
            } catch (NoSuchElementException e) {
                MessageBox.Show($"UEC統合認証でエラーが発生しました。\n{e.Message}");
                return false;
            } catch (Exception e) {
                MessageBox.Show($"不明なエラーです。\n{e.Message}");
                return false;
            }
            return true;
        }

        private bool Goto_SearchPage() {
            try {
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame("menu");
                driver.FindElementByCssSelector("body > table > tbody > tr:nth-child(12) > td > table > tbody > tr:nth-child(2) > td > a").Click();
            } catch (NoSuchElementException e) {
                MessageBox.Show($"シラバス検索ページ遷移に失敗しました。\n{e.Message}");
                return false;
            } catch (NoSuchFrameException e) {
                MessageBox.Show($"メニューバーまたはメインフレームへの移動に失敗しました。\n{e.Message}");
                return false;
            } catch (Exception e) {
                MessageBox.Show($"不明なエラーです。\n{e.Message}");
                return false;
            }
            return true;
        }

        private bool Search_Syllabus(DataRow row) {
            try {
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame("body");

                SelectElement shozoku = new SelectElement(driver.FindElementById("jikanwariShozokuCode"));
                shozoku.SelectByValue("");

                SelectElement kubun = new SelectElement(driver.FindElementById("gakkiKubunCode"));
                kubun.SelectByValue(row["Semester"].ToString());

                SelectElement nenji = new SelectElement(driver.FindElementById("nenji"));
                nenji.SelectByValue(row["Year"].ToString());

                SelectElement yobi = new SelectElement(driver.FindElementById("yobi"));
                yobi.SelectByValue(row["Week"].ToString());

                SelectElement jigen = new SelectElement(driver.FindElementById("jigen"));
                jigen.SelectByValue(row["Time"].ToString());

                driver.FindElementById("kaikoKamokunm").SendKeys(row["ClassName"].ToString());
                driver.FindElementById("kyokannm").SendKeys(row["Teacher"].ToString());
                driver.FindElementByCssSelector("#jikanwariSearchForm > table > tbody > tr:nth-child(13) > td > p > input[type=button]:nth-child(1)").Click();
            } catch (NoSuchElementException e) {
                MessageBox.Show($"シラバス検索に失敗しました。\n{e.Message}");
                return false;
            } catch (NoSuchFrameException e) {
                MessageBox.Show($"メニューバーまたはメインフレームへの移動に失敗しました。\n{e.Message}");
                return false;
            } catch (Exception e) {
                MessageBox.Show($"不明なエラーです。\n{e.Message}");
                return false;
            }
            return true;
        }

        private bool Download_and_Reference_Syllabus(DataRow row) {
            try {
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame("body");
                
                string WeekTime = "";
                string ClassName = "";
                string Teacher = "";
                int rowCount = driver.FindElement(By.XPath($"/html/body/table[2]/tbody")).FindElements(By.TagName("tr")).Count;
                for (int i = 1; i <= rowCount; i++) {
                    if(i > 1) {
                        Goto_SearchPage();
                    Search_Syllabus(row);
                    }
                    
                    WeekTime = driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[4]")).Text;
                    ClassName = driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[6]")).Text;
                    Teacher = driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[7]")).Text;
                    driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[8]/input")).Click();

                    driver.SwitchTo().ParentFrame();
                    driver.SwitchTo().Frame("body");

                    driver.FindElementByCssSelector("body > p:nth-child(13) > input[type=submit]").Click();

                    System.Threading.Thread.Sleep(500);
                    string downloadFile = "";
                    string[] files = Directory.GetFiles(folderPath, "*.pdf", System.IO.SearchOption.TopDirectoryOnly);
                    DateTime updateTime = new DateTime(2000, 1, 1, 0, 0, 0);
                    foreach (string fileName in files) {
                        if (updateTime < File.GetLastWriteTime(fileName)) {
                            updateTime = File.GetLastWriteTime(fileName);
                            downloadFile = fileName;
                        }
                    }
                    if (FileSystem.FileExists($"{folderPath}\\{WeekTime}_{ClassName}_{Teacher}.pdf")) {
                        FileSystem.DeleteFile($"{folderPath}\\{WeekTime}_{ClassName}_{Teacher}.pdf");
                    }
                    if(downloadFile == "") {
                        downloadFile = $"{folderPath}\\syllabusPdfList.pdf";
                    }
                    FileSystem.RenameFile(downloadFile, $"{WeekTime}_{ClassName}_{Teacher}.pdf");
                    
                }
            } catch (NoSuchElementException e) {
                MessageBox.Show($"シラバス参照に失敗しました。\n{e.Message}");
                return false;
            } catch (NoSuchFrameException e) {
                MessageBox.Show($"メニューバーまたはメインフレームへの移動に失敗しました。\n{e.Message}");
                return false;
            } catch (IOException e) {
                MessageBox.Show($"ファイル操作に失敗しました。\npdfファイルが開かれていないか確認してください。\n{e.Message}");
                return false;
            } catch (Exception e) {
                MessageBox.Show($"不明なエラーです。\n{e.Message}");
                return false;
            }
            return true;
        }

        private void Terminate_Chrome(){
            driver.Quit();
            portDynamic.Stop();
            portDynamic.Dispose();
            sshClient.Disconnect();
            sshClient.Dispose();
        }
    }
}
