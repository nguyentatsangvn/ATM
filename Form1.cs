using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using System.Diagnostics;



namespace ATM_REG_CLONE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ProfileFolderPath = "Profile";
            string ten = "facebook1";
            if (Directory.Exists(ProfileFolderPath + "\\" + ten))
            {
                Directory.Delete(ProfileFolderPath + "\\" + ten, true);
                //Thread.Sleep(5000);
            }

            ChromeDriver driver;

            ChromeOptions options = new ChromeOptions();



            if (!Directory.Exists(ProfileFolderPath))
            {
                Directory.CreateDirectory(ProfileFolderPath);
            }


            if (Directory.Exists(ProfileFolderPath))
            {


                options.AddArguments("user-data-dir=" + ProfileFolderPath + "\\" + ten);

            }


            driver = new ChromeDriver(options);


            driver.Url = "https://m.facebook.com/";
            driver.Navigate();
            Thread.Sleep(2000);

            var regnew = driver.FindElementById("signup-button");
            regnew.Click();
            

            Thread.Sleep(2000);
            //nhap ho
            var ho = driver.FindElementById("firstname_input");
            string fileho = @"C:\\ATM_DATA\\ho.txt";
            string[] horandom = File.ReadAllLines(fileho);
            Random homoi = new Random();
            int h = homoi.Next(0, horandom.Length);
            string homoiout = horandom[h].ToString() ;
            ho.SendKeys(homoiout);
            Thread.Sleep(1000);

            //nhap ten
            var name = driver.FindElementById("lastname_input");
            string fileten = @"C:\\ATM_DATA\\ten.txt";
            string[] tenrandom = File.ReadAllLines(fileten);
            Random tenmoi = new Random();
            int t = tenmoi.Next(0, tenrandom.Length);
            string tenmoiout = tenrandom[t].ToString();
            name.SendKeys(tenmoiout);
            Thread.Sleep(1500);

            var tiep = driver.FindElementByXPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/div[2]/button[1]");
            tiep.Click();
            Thread.Sleep(1500);

            //nhap ngay sinh
            var ngay = driver.FindElementById("day");
            int ngay1;
            Random tudo = new Random();
            ngay1 = tudo.Next(1, 28);
            ngay.SendKeys(ngay1.ToString());
            Thread.Sleep(1500);

            //nhap thang sinh
            var thang = driver.FindElementById("month");
            int thang1;
            Random tudo1 = new Random();
            thang1 = tudo1.Next(1, 11);
            thang.SendKeys("Tháng " + thang1.ToString());
            Thread.Sleep(1000);
            //nhap nam sinh
            var nam = driver.FindElementById("year");
            int nam1;
            Random tudo2 = new Random();
            nam1 = tudo2.Next(1990, 2000);
            nam.SendKeys(nam1.ToString());
            Thread.Sleep(1500);

            var tiep1 = driver.FindElementByXPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/div[2]/button[1]");
            tiep1.Click();
            Thread.Sleep(1500);

            // tạo ngẫu nhiên  đầu số điện thoại
            string filedauso = @"C:\\ATM_DATA\\dauso.txt";
            string[] dausorandom = File.ReadAllLines(filedauso);
            Random dausomoi = new Random();
            int ds = dausomoi.Next(0, dausorandom.Length);
            string dausomoiout = dausorandom[ds].ToString();

            //nhap sdt
            var sdt = driver.FindElementByName("reg_email__");
            int sdtsau;
            Random ramdom = new Random();
            sdtsau = ramdom.Next(0000000, 9999999);
            string sdtmoi = sdtsau.ToString();
            int chieudai = sdtmoi.Length;
            if(chieudai == 7)
            {
                sdt.SendKeys(dausomoiout + sdtmoi);
                Thread.Sleep(1500);
            }
            else
            {
                return;
            }
            

            var tiep2 = driver.FindElementByXPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/div[2]/button[1]");
            tiep2.Click();

            //chon gioi tinh
            var gioitinnao = driver.FindElementByXPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[5]/div[3]/div/div/div[3]/div/label[1]/div/div[2]/input");
            gioitinnao.Click();
            Thread.Sleep(1500);


            var tiep3 = driver.FindElementByXPath("/html/body/div[1]/div/div[2]/div[2]/div/form/div[8]/div[2]/button[1]");
            tiep3.Click();
            Thread.Sleep(1500);

            // tạo mật khẩu ngẫu nhiên
            var chars = "ZXCVBNMASDFGHJKLQWERTYUIOPzxcvbnmasdfghjklqwertyuiop1234567890!~@#$%^&*()_+";
            var stringChars = new char[15];
            var random = new Random();
            for(int i=0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var matkhauout = new String(stringChars);

            //nhap mat khau
            var matkhau = driver.FindElementById("password_step_input");
            matkhau.SendKeys(matkhauout);
            Thread.Sleep(1500);

            //nhan nut dang ky
            var dangkynao = driver.FindElementByName("submit");
            Thread.Sleep(1000);
            dangkynao.Click();

            Thread.Sleep(1000);

            Thread.Sleep(5000);

            Thread.Sleep(5000);



            Thread.Sleep(5000);

            String filepath = @"C:\\ATM_DATA\\datareg.txt";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Append);//Tạo file mới tên là datareg.txt           
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream
            sWriter.WriteLine(dausomoiout + sdtmoi + "     " + matkhauout + "     " + homoiout+" "+ tenmoiout);
            sWriter.Flush();
            fs.Close();

            driver.Close();
            driver.Quit();

            // xoa profile facebook1
            Thread.Sleep(3000);
            if (Directory.Exists(ProfileFolderPath + "\\" + ten))
            {
                Directory.Delete(ProfileFolderPath + "\\" + ten, true);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
