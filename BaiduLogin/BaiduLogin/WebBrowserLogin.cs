using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;

namespace BaiduLogin
{
    public partial class WebBrowserLogin : Form
    {
        public string m_strUrlMain = "https://www.baidu.com/";
        public string m_strUrlLogin = "https://passport.baidu.com/passApi/html/_blank.html";
        //https://passport.baidu.com/v2/api/?login

        public WebBrowserLogin()
        {
            InitializeComponent();
        }


        private void WebBrowserLogin_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            webBrowser1.Navigate(m_strUrlMain);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            AutoAlertOK();
            //下面是你的执行操作代码
            WebBrowser wb = (WebBrowser)sender;
            if (e.Url.OriginalString == m_strUrlMain)
            {              
                var collect = wb.Document.Body.GetElementsByTagName("a");
                var IsCookieUseable = true;
                foreach (HtmlElement item in collect)
                {
                    if (item.Name == "tj_login" && item.GetAttribute("href").Contains("https://passport.baidu.com") && item.NextSibling !=null)
                    {
                        IsCookieUseable = false;
                        item.InvokeMember("click");
                        break;
                    }
                }

                if (IsCookieUseable)
                {
                    if (webBrowser1.Document.Cookie !=Properties.Settings.Default.Cookie )
                    {
                        string cookieStr = webBrowser1.Document.Cookie;
                        Properties.Settings.Default.Cookie = cookieStr;
                        Properties.Settings.Default.Save();//使用Save方法保存更改

                    }
                    var strCookie = Properties.Settings.Default.Cookie;
                    //todo：httpwebrequest
                    ForComputer(m_strUrlMain, strCookie);

                }
                return;
            }

            if (m_strUrlLogin == e.Url.OriginalString)
            {
                //<p class="tang-pass-footerBarULogin pass-link" title="用户名登录" data-type="normal" id="TANGRAM__PSP_10__footerULoginBtn">用户名登录</p>
                var item = wb.Document.GetElementById("TANGRAM__PSP_10__footerULoginBtn");
                if (item != null)
                {
                    item.InvokeMember("click");
                }
                var strUserName = Properties.Settings.Default.UserName;
                var strPassWord = Properties.Settings.Default.PassWord;
                
                wb.Document.GetElementById("TANGRAM__PSP_10__userName").SetAttribute("value", strUserName);
                wb.Document.GetElementById("TANGRAM__PSP_10__password").SetAttribute("value", strPassWord);
                return;
            }


            if (e.Url.OriginalString.Contains(  "https://www.baidu.com/cache/user/html/v3Jump.html?err_no=0"))
            {
                Console.WriteLine("succsee");
                CookieContainer myCookieContainer = new CookieContainer();
                string cookieStr = webBrowser1.Document.Cookie;
                Properties.Settings.Default.Cookie = cookieStr;
                Properties.Settings.Default.Save();//使用Save方法保存更改

                #region "设置cookie 方法二 （复杂）" 
                //string[] cookstr = cookieStr.Split(';');
                //foreach (string str in cookstr)
                //{
                //    string[] cookieNameValue = str.Split('=');
                //    Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                //    ck.Domain = "www.abc.com";//必须写对  
                //    myCookieContainer.Add(ck);
                //}  
                #endregion

                myCookieContainer.SetCookies(new Uri("https://www.baidu.com"), cookieStr.Replace(";", ","));
                // todo：httpwebrequest 操作
                ForComputer(m_strUrlMain, cookieStr);
            }

        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WebBrowser wb = (WebBrowser)sender;
            string url = wb.Document.ActiveElement.GetAttribute("href");
            webBrowser1.Navigate(url);  
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            AutoAlertOK();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }


        private void AutoAlertOK()
        {
            //自动点击弹出确认或弹出提示
            IHTMLDocument2 vDocument = (IHTMLDocument2)webBrowser1.Document.DomDocument;
            vDocument.parentWindow.execScript("function confirm(str){return true;} ", "javascript"); //弹出确认
            vDocument.parentWindow.execScript("function alert(str){return true;} ", "javaScript");//弹出提示
        }


        private void ForComputer(string url, string strCookie)
        {
            string cookie2 = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; plus_cv=1::m:caddfa4f; locale=zh; H_PS_PSSID=1461_26458_21117_22073; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=GNSMjI5NEItRFFBTXNWeU1JVHFLaWJGaW85eHB6VzkxLWU5NE1iLUxFekdJenhiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMaWFFvGlhRba; BD_HOME=1";
           // cookie2 = GetCookieString("http://www.baidu.com");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = "GET";
                request.ContentType = "text/html;charset=utf-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
                request.AllowAutoRedirect = true;
                // request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里
                request.CookieContainer = new CookieContainer();
                //computer
                //方法二：
                request.CookieContainer.SetCookies(new Uri(url), cookie2.Replace(";", ","));
                request.KeepAlive = true;//建立持久性连接

                //响应
                response = (HttpWebResponse)request.GetResponse();
                string text = string.Empty;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    text = redStm.ReadToEnd();
                }

                if (text.Contains("ahhfbw"))
                {
                    //lblComputer.Text = "Success_Computer";
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //lblComputer.Text = msg;
            }
        }

        ////取当前webBrowser登录后的Cookie值   
        //[DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, object lpReserved);
        ////取出Cookie，当登录后才能取    
        //private static string GetCookieString(string url)
        //{
        //    // Determine the size of the cookie      
        //    int datasize = 256;
        //    StringBuilder cookieData = new StringBuilder(datasize);
        //    if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
        //    {
        //        if (datasize < 0)
        //            return null;
        //        // Allocate stringbuilder large enough to hold the cookie    
        //        cookieData = new StringBuilder(datasize);
        //        if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
        //            return null;
        //    }
        //    return cookieData.ToString();
        //}

    }

}


//https://blog.csdn.net/yinbucheng/article/details/64443576
//http://www.cnblogs.com/Fooo/archive/2010/09/10/1823016.html
//https://www.cnblogs.com/yhleng/p/6728864.html