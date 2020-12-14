using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolTestWishyWishy
{
    public partial class Form1 : Form
    {
        private const string STR_URL_PUBLICWEB = "https://wishywishy.netlify.app/";
        private const string STR_URL_CREATEWISH = "https://wishywishy.netlify.app/create";
        private enum ENUM_TASK
        {
            TEST_CREATEWISH,
            TEST_THANK,
            TEST_DROPHEART,
            TEST_UNLIKE
        }

        private static int waitTime = 2000;


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            ENUM_TASK[] taskList = GetTaskList();
            if(taskList == null || taskList.Length <= 0)
            {
                CommonFunc.ShowMessError("Bạn chưa chọn công việc cụ thể");
            }
            else
            {
                waitTime = (int)numud_WaitTime.Value * 1000;
                int taskNum = (int)numud_TaskNum.Value;
                for (int i = 0; i < taskNum; i++)
                {
                    Task.Run(() =>
                    {
                        StartChromeInstance(taskList);
                    });
                }
            }
            
        }

        private void StartChromeInstance(ENUM_TASK[] taskList)
        {
            ChromeDriver chrome = new ChromeDriver();
            chrome.Url = STR_URL_PUBLICWEB;
            chrome.Navigate();
            chrome.Manage().Window.Maximize();

            if (taskList.Contains(ENUM_TASK.TEST_CREATEWISH))
            {
                TestCreateWishInstance(chrome);
            } 
            if (taskList.Contains(ENUM_TASK.TEST_THANK))
            {
                TestThankInstance(chrome);
            }


            Thread.Sleep(waitTime);
            chrome.Close();
        }

        private void TestCreateWishInstance(ChromeDriver chrome)
        {
            IWebElement eleTemp = null;
            var eleGotoCreateWish = chrome.FindElement(By.XPath("//span[. = 'Tạo điều ước']"));
            eleGotoCreateWish.Click();

            SetDataForInputElement(chrome, "Tên tác giả", "input", "test 123");

            Thread.Sleep(waitTime);
            int enum_Sex = 2; //0:nữ 1:nam 2:khác
            eleTemp = chrome.FindElement(By.ClassName("MuiFormGroup-row"));
            var eleInputRadioAuthorSex = eleTemp.FindElement(By.XPath("//input[@value='"+enum_Sex+"']"));
            eleInputRadioAuthorSex.Click();
            Thread.Sleep(waitTime);


            SetDataForInputElement(chrome, "Facebook", "input", "test 123");

            SetDataForInputElement(chrome, "Nội dung", "textarea", "test 123");

            SetDataForInputElement(chrome, "Tag", "input", "test123");

            Thread.Sleep(waitTime);
            eleTemp = chrome.FindElement(By.XPath("//span[. = 'Tạo mới']"));
            var eleButtonCreate = eleTemp.FindElement(By.XPath("./.."));
            eleButtonCreate.Click();

            Thread.Sleep(waitTime);
        }

        private void TestThankInstance(ChromeDriver chrome)
        {
            IWebElement eleTemp = null;
            Thread.Sleep(waitTime);
            var eleGotoThank = chrome.FindElement(By.XPath("//span[. = 'Lời cảm ơn']"));
            eleGotoThank.Click();

            SetDataForInputElement(chrome, "Nội dung phản hồi", "textarea", "huy dz vcllllllllllllllllllllllllllll");
            Thread.Sleep(waitTime);

            eleTemp = chrome.FindElement(By.XPath("//span[. = 'Đánh giá']"));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            eleTemp = eleTemp.FindElement(By.TagName("div"));
            var eleTempList = chrome.FindElement(By.XPath(".//*"));
            eleTempList[2].Click();
            Thread.Sleep(waitTime);
        }

            private void SetDataForInputElement(ChromeDriver chrome , string spanName , string kindOfInput , string data)
        {
            IWebElement eleTemp = null;
            Thread.Sleep(waitTime);
            eleTemp = chrome.FindElement(By.XPath("//span[. = '"+ spanName +"']"));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            eleTemp = eleTemp.FindElement(By.XPath("./.."));
            var eleInput = eleTemp.FindElement(By.TagName(kindOfInput));
            eleInput.SendKeys(data); // name
        }

        private ENUM_TASK[] GetTaskList()
        {
            List<ENUM_TASK> temp = new List<ENUM_TASK>();
            if (ckb_Option_CreateWish.Checked)
                temp.Add(ENUM_TASK.TEST_CREATEWISH);
            if (ckb_Option_DropHeart.Checked)
                temp.Add(ENUM_TASK.TEST_DROPHEART);
            if (ckb_Option_Thank.Checked)
                temp.Add(ENUM_TASK.TEST_THANK);
            if (ckb_Option_Unlike.Checked)
                temp.Add(ENUM_TASK.TEST_UNLIKE);

            return temp.ToArray();
        }
    }

}
