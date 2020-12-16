using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ToolTestWishyWishy
{
    public partial class Form1 : Form
    {
        private const string STR_URL_PUBLICWEB = "https://wishywishy.netlify.app/";
        private const string STR_URL_LOCALHOST = "http://localhost:3000/";

        private const int INT_MAX_AMOUNT_OF_THREADS = 6;

        private static string PATH_CREATEWISH = Directory.GetCurrentDirectory() + "\\Excel\\CreateWish.xlsx";
        private static string PATH_THANK = Directory.GetCurrentDirectory() + "\\Excel\\Thank.xlsx";
        private static string PATH_DROPHEART = Directory.GetCurrentDirectory() + "\\Excel\\DropHeart.xlsx";

        private static ChromeDriver[] arrChrome = new ChromeDriver[INT_MAX_AMOUNT_OF_THREADS];
        private static Thread[] arrThread = new Thread[INT_MAX_AMOUNT_OF_THREADS];
        private static decimal amountOfThreads = 0;

        private enum ENUM_TASK
        {
            TEST_CREATEWISH,
            TEST_THANK,
            TEST_DROPHEART,
            TEST_UNLIKE
        }

        private static int waitTime = 2000;
        private static List<Wish> wishList = new List<Wish>();
        private static List<Thank> thankList = new List<Thank>();
        private static List<int> dropHeartList = new List<int>();

        #region "WISH"
        public struct Wish
        {
            public string AuthorName;
            public int Sex;
            public string Facebook;
            public string Context;
            public string Tag;

            public Wish(int sex, string authorName, string facebook, string context , string tag)
            {
                Sex = sex;
                AuthorName = authorName;
                Facebook = facebook;
                Context = context;
                Tag = tag;
            }
        }
        #endregion

        #region "THANK"
        public struct Thank
        {
            public int NumStar;
            public string Context;

            public Thank(int numStar , string context)
            {
                NumStar = numStar;
                Context = context;
            }
        }
        #endregion


        public Form1()
        {
            InitializeComponent();
            VisibleButton(true);
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            VisibleButton(false);
            dgv_Noti.Rows.Clear();
            waitTime = (int)numud_WaitTime.Value * 1000;
            amountOfThreads = (int)numud_TaskNum.Value;

            for (int i = 0; i < amountOfThreads; i++)
            {
                //Task.Run(() =>
                //{
                //    StartChromeInstance(i);
                //});
                int idx = i;
                Thread thr = new Thread(() =>
                {
                    StartChromeInstance(idx);
                });
                thr.IsBackground = true;
                thr.Start();
                arrThread[i] = thr;
            }

        }

        private void StartChromeInstance(int index)
        {
            try
            {
                ChromeDriver chrome = new ChromeDriver();
                arrChrome[index] = chrome;

                if (rdb_PublicWeb.Checked)
                    chrome.Url = STR_URL_PUBLICWEB;
                else
                    chrome.Url = STR_URL_LOCALHOST;
                chrome.Navigate();
                //chrome.Manage().Window.Size = new System.Drawing.Size(320, 640);
                chrome.Manage().Window.Position = new System.Drawing.Point(index * 420, 80);

                if (rdb_Option_CreateWish.Checked)
                {
                    TestCreateWishInstance(chrome);
                }
                else if (rdb_Option_Thank.Checked)
                {
                    TestThankInstance(chrome);
                }
                //else if (rdb_Option_DropHeart.Checked)
                //{
                //    TestDropHeartInstance(chrome);
                //}
                //else if (rdb_Option_Unlike.Checked)
                //{
                //    TestThankInstance(chrome);
                //}


                Thread.Sleep(waitTime);
                chrome.Close();
                chrome.Dispose();

                VisibleButton(true);
                Thread thr = arrThread[index];
                thr.Abort();
                thr = null;
            }
            catch (Exception ex)
            {
                //CommonFunc.ShowMessError(ex.ToString());
            }
        }


        private void TestCreateWishInstance(ChromeDriver chrome)
        {
            GetWishList();
            int idx = 0;

            foreach (Wish wish in wishList)
            {
                TestCreateWish(chrome, wish , idx);
                idx++;
            }    
        }

        private void TestCreateWish(ChromeDriver chrome , Wish wish , int idx)
        {
            string[] row = new string[] { (idx + 1).ToString(), "Chức năng tạo mới điều ước" , "Chưa có" , "Bắt đầu" };
            AddRowToDgv(row);

            IWebElement eleTemp = null;

            EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Chưa có", "Đang chạy");

            Thread.Sleep(3000);
            var eleGotoCreateWish = chrome.FindElement(By.XPath("//span[. = 'Tạo điều ước']"));
            eleGotoCreateWish.Click();


            SetDataForInputElement(chrome, "Tên tác giả", "input", wish.AuthorName);

            Thread.Sleep(waitTime);

            eleTemp = chrome.FindElement(By.ClassName("MuiFormGroup-row"));
            var eleInputRadioAuthorSex = eleTemp.FindElement(By.XPath("//input[@value='" + wish.Sex + "']"));
            eleInputRadioAuthorSex.Click();
            Thread.Sleep(waitTime);


            SetDataForInputElement(chrome, "Facebook", "input", wish.Facebook);

            SetDataForInputElement(chrome, "Nội dung", "textarea", wish.Context);

            SetDataForInputElement(chrome, "Tag", "input", wish.Tag);

            Thread.Sleep(waitTime);
            eleTemp = chrome.FindElement(By.XPath("//span[. = 'Tạo mới']"));
            var eleButtonCreate = eleTemp.FindElement(By.XPath("./.."));
            eleButtonCreate.Click();

            Thread.Sleep(waitTime);
            if(wish.AuthorName == "")
            {
                EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Không nhập tên", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Những điều ước']"));
                eleGotoWishes.Click();
            }
            else if (wish.Context == "")
            {
                EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Không nhập nội dung", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Những điều ước']"));
                eleGotoWishes.Click();
            }
            else if (wish.Tag == "")
            {
                EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Không nhập tag", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Những điều ước']"));
                eleGotoWishes.Click();
            } 
            else if (wish.Tag.Contains(" "))
            {
                EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Nhập tag có dấu cách", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Tạo điều ước']"));
                eleGotoWishes.Click();
            }
            else EditRowToDgv(ref row, "Chức năng tạo mới điều ước", "Không có", "Chạy thành công");
        }

        private void TestThankInstance(ChromeDriver chrome )
        {
            GetThankList();
            int idx = 0;

            foreach (Thank thank in thankList)
            {
                TestThank(chrome, thank, idx);
                idx++;
            }
        }

        private void TestThank(ChromeDriver chrome ,  Thank thank , int idx)
        {
            string[] row = new string[] { (idx + 1).ToString(), "Chức năng gửi phản hồi", "Chưa có", "Bắt đầu" };
            AddRowToDgv(row);
            IWebElement eleTemp = null;
            Thread.Sleep(waitTime);
            EditRowToDgv(ref row, "Chức năng gửi phản hồi", "Chưa có", "Đang chạy");
            var eleGotoThank = chrome.FindElement(By.XPath("//span[. = 'Lời cảm ơn']"));
            eleGotoThank.Click();

            if (thank.Context == "")
            {
                Thread.Sleep(waitTime);
                EditRowToDgv(ref row, "Chức năng gửi phản hồi", "Không nhập nội dung phản hồi", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Những điều ước']"));
                eleGotoWishes.Click();
            }
            else if (thank.NumStar <= 0)
            {
                Thread.Sleep(waitTime);
                EditRowToDgv(ref row, "Chức năng gửi phản hồi", "Chưa đánh giá sao", "Chạy thất bại");
                var eleGotoWishes = chrome.FindElement(By.XPath("//span[. = 'Những điều ước']"));
                eleGotoWishes.Click();
            }
            else
            {
                Thread.Sleep(waitTime);
                SetDataForInputElement(chrome, "Nội dung phản hồi", "textarea", thank.Context);

                Thread.Sleep(waitTime);
                Thread.Sleep(waitTime);
                eleTemp = chrome.FindElement(By.XPath("//span[. = 'Đánh giá']"));
                eleTemp = eleTemp.FindElement(By.XPath("./.."));
                //eleTemp = eleTemp.FindElement(By.TagName("div"));
                var eleTempList = eleTemp.FindElements(By.TagName("button"));
                eleTempList[thank.NumStar - 1].Click();
                eleTemp = chrome.FindElement(By.XPath("//span[. = 'Gửi phản hồi']"));
                eleTemp.Click();

                EditRowToDgv(ref row, "Chức năng gửi phản hồi", "Không có lỗi", "Thành công");
            }

        }

        private void TestDropHeartInstance(ChromeDriver chrome)
        {
            GetDropHeartList();
            int idx = 0;

            foreach (int id in dropHeartList)
            {
                TestDropHeart(chrome, id, idx);
                idx++;
            }
        }

        private void TestDropHeart(ChromeDriver chrome , int id , int idx)
        {
            string[] row = new string[] { (idx + 1).ToString(), "Chức năng thả tim", "Chưa có", "Bắt đầu" };
            AddRowToDgv(row);
            IWebElement eleTemp = null;
            Thread.Sleep(waitTime);
            EditRowToDgv(ref row, "Chức năng thả tim", "Chưa có", "Đang chạy");

            Thread.Sleep(waitTime);
            eleTemp = chrome.FindElement(By.Id("wish_" + id));
            if (eleTemp == null)
            {
                CommonFunc.ShowMessError("123");
            }

        }


        private void SetDataForInputElement(ChromeDriver chrome , string spanName , string kindOfInput , string data)
        {
            IWebElement eleTemp = null;

            //var wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(5000));
            //eleTemp =  wait.Until(drv =>  drv.FindElement(By.XPath("//span[. = '" + spanName + "']")));
            eleTemp = chrome.FindElement(By.XPath("//span[. = '" + spanName + "']"));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            var eleInput = eleTemp.FindElement(By.TagName(kindOfInput));
            eleInput.SendKeys(data); // name
        }

        private void GetWishList()
        {
            wishList.Clear();

            string strTemp = "";
            int intTemp = 0;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(PATH_CREATEWISH);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 2; i <= rowCount; i++)
                {
                    Wish wish = new Wish();

                    if (xlRange.Cells[i, 2].Value2 == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = xlRange.Cells[i, 2].Value2.ToString();
                    }
                    wish.AuthorName = strTemp;

                    strTemp = xlRange.Cells[i, 3].Value2.ToString();
                    int.TryParse(strTemp, out intTemp);
                    wish.Sex = intTemp;

                    if (xlRange.Cells[i, 4].Value2 == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = xlRange.Cells[i, 4].Value2.ToString();
                    }
                    wish.Facebook = strTemp;


                    if (xlRange.Cells[i, 5].Value2 == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = xlRange.Cells[i, 5].Value2.ToString();
                    }
                    wish.Context = strTemp;

                    if (xlRange.Cells[i, 6].Value2 == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = xlRange.Cells[i, 6].Value2.ToString();
                    }
                    wish.Tag = strTemp;


                    //Wish wish = new Wish();
                    //if (xlRange.Cells[i, 1].Value2 == null)
                    //    continue;
                    //strTemp = xlRange.Cells[i, 1].Value2.ToString();
                    //if (string.IsNullOrEmpty(strTemp) || int.TryParse(strTemp, out intTemp) == false)
                    //    continue;
                    //acc.Index = intTemp;

                    //strTemp = xlRange.Cells[i, 2].Value2.ToString();
                    //if (string.IsNullOrEmpty(strTemp))
                    //    continue;
                    //acc.UserName = strTemp.Trim();

                    //strTemp = xlRange.Cells[i, 3].Value2.ToString();
                    //if (string.IsNullOrEmpty(strTemp))
                    //    continue;
                    //acc.PassGmail = strTemp.Trim();

                    //strTemp = xlRange.Cells[i, 4].Value2.ToString();
                    //if (string.IsNullOrEmpty(strTemp))
                    //    continue;
                    //acc.PassInsta = strTemp.Trim();

                    wishList.Add(wish);
                }

                //AmountOfAcc = listAcc.Count;
                //Label_AmountOfAcc.Text = AmountOfAcc.ToString();

                //if (AmountOfAcc > 1)
                //    Button_Start.Visible = true;
                //if (AmountOfAcc > INT_MAX_AMOUNT_OF_THREADS)
                //    NumericUpDown_Threads.Maximum = AmountOfAcc - INT_MAX_AMOUNT_OF_THREADS;
                //else
                //    NumericUpDown_Threads.Maximum = 0;

                //EnabledControl(true);

                Marshal.ReleaseComObject(xlApp);
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                //xlApp.Quit();

            }
            catch (Exception ex)
            {
                CommonFunc.ShowMessError(ex.ToString());
            }
            finally
            {

            }
        }
        
        private void GetThankList()
        {
            thankList.Clear();

            string strTemp = "";
            int intTemp = 0;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(PATH_THANK);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 2; i <= rowCount; i++)
                {
                    Thank thank = new Thank();

                    strTemp = xlRange.Cells[i, 2].Value2.ToString();
                    int.TryParse(strTemp, out intTemp);
                    thank.NumStar = intTemp;

                    if (xlRange.Cells[i, 3].Value2 == null)
                    {
                        strTemp = "";
                    }
                    else
                    {
                        strTemp = xlRange.Cells[i, 3].Value2.ToString();
                    }
                    thank.Context = strTemp;

                    thankList.Add(thank);
                }


                Marshal.ReleaseComObject(xlApp);
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                //xlApp.Quit();

            }
            catch (Exception ex)
            {
                CommonFunc.ShowMessError(ex.ToString());
            }
            finally
            {

            }
        }

        private void GetDropHeartList()
        {
            dropHeartList.Clear();

            string strTemp = "";
            int intTemp = 0;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(PATH_DROPHEART);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 2; i <= rowCount; i++)
                {

                    strTemp = xlRange.Cells[i, 2].Value2.ToString();
                    int.TryParse(strTemp, out intTemp);

                    dropHeartList.Add(intTemp);
                }


                Marshal.ReleaseComObject(xlApp);
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                //xlApp.Quit();

            }
            catch (Exception ex)
            {
                CommonFunc.ShowMessError(ex.ToString());
            }
            finally
            {

            }
        }

        private void VisibleButton(bool isBtnStartVisible)
        {
            if(btn_Start.InvokeRequired)
            {
                btn_Start.Invoke(
                    (MethodInvoker)
                              delegate {
                                  btn_Start.Visible = isBtnStartVisible;
                                  btn_Stop.Visible = !isBtnStartVisible;

                                  groupBox1.Enabled = isBtnStartVisible;
                                  groupBox2.Enabled = isBtnStartVisible;
                                  groupBox3.Enabled = isBtnStartVisible;
                                  groupBox4.Enabled = isBtnStartVisible;
                                  groupBox5.Enabled = isBtnStartVisible;
                              });
            }
            else
            {
                btn_Start.Visible = isBtnStartVisible;
                btn_Stop.Visible = !isBtnStartVisible;

                groupBox1.Enabled = isBtnStartVisible;
                groupBox2.Enabled = isBtnStartVisible;
                groupBox3.Enabled = isBtnStartVisible;
                groupBox4.Enabled = isBtnStartVisible;
                groupBox5.Enabled = isBtnStartVisible;
            }

        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < amountOfThreads; i++)
                {
                    ChromeDriver chrome = arrChrome[i];
                    chrome.Close();
                    chrome.Dispose();
                    Thread thr = arrThread[i];
                    thr.Abort();
                    thr = null;
                }
            }
            catch (WebDriverException ex)
            {
                CommonFunc.ShowMessError(ex.ToString());
            }
            catch (ThreadAbortException ex)
            {
                CommonFunc.ShowMessError(ex.ToString());
            }

            VisibleButton(true);
        }

        private void AddRowToDgv(string[] row)
        {
            dgv_Noti.Invoke(new MethodInvoker(() =>
            {
                dgv_Noti.Rows.Add(row);
            }));
        }

        private void EditRowToDgv(ref string[] row, string  task, string detailError , string state)
        {
            if (!string.IsNullOrEmpty(task)) row[1] = task;
            if (!string.IsNullOrEmpty(detailError)) row[2] = detailError;
            if (!string.IsNullOrEmpty(state)) row[3] = state;

            string[] rowEdited = row;

            dgv_Noti.Invoke(new MethodInvoker(() =>
            {
                int index = Convert.ToInt32(rowEdited[0]) - 1;
                dgv_Noti.Rows[index].Cells[1].Value = rowEdited[1];
                dgv_Noti.Rows[index].Cells[2].Value = rowEdited[2];
                dgv_Noti.Rows[index].Cells[3].Value = rowEdited[3];
            }));
        }
    }

}
