using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace BaiduLogin
{
    public partial class BaiduAutoLogin : Form
    {
        public static CookieContainer container = null; //存储验证码cookie

        public BaiduAutoLogin()
        {
            InitializeComponent();
        }

        private void BaiduLogin_Load(object sender, EventArgs e)
        {
            ForComputer();
            //ForPhone();
           

        }

        private void ForPhone()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("https://m.baidu.com/usrprofile?action=home&model=user&ori=index");

                request.Method = "GET";
                //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.ContentType = "text/html;charset=utf-8";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Mobile Safari/537.36";
                request.AllowAutoRedirect = true;
                request.Referer = "https://m.baidu.com";
                request.CookieContainer = new CookieContainer();
                //phone
                var strCookie = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; plus_cv=1::m:caddfa4f; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527651718; PSINO=5; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=96MzRNQ0o5bm1CR35JUjZOdXdxT1JMfjB0WUpYVU0tT0h2YlNrVzZUalc2VFZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANZcDlvWXA5bRG; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_123980_110085_123289; SE_LAUNCH=5%3A25461144_0%3A25461144; usr_prf=3549; reload=lsDiff:_5_de8ce127d8872de4_null; plus_lsv=de8ce127d8872de4; bd_traffictrace=301141_301641_301641_301641; BDSVRTM=484; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527669780; __bsi=9295763977982674593_00_28_R_N_19_0303_c02f_Y";
                strCookie = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; plus_cv=1::m:caddfa4f; BD_CK_SAM=1; PSINO=5; H_PS_645EC=2b78AwMLTx%2FGLXPrFqBh1GZA1Mml8OLxN4kMkMY7ikROoj9YK9YuqoygYXU; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=96MzRNQ0o5bm1CR35JUjZOdXdxT1JMfjB0WUpYVU0tT0h2YlNrVzZUalc2VFZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANZcDlvWXA5bRG; BD_HOME=1; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_123980_110085_123289; plus_lsv=de8ce127d8872de4; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527648863; SE_LAUNCH=5%3A25461144_0%3A25461144; bd_traffictrace=301624_301624; BDSVRTM=423; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527668684";

                //方法二：
                request.CookieContainer.SetCookies(new Uri("https://m.baidu.com/"), strCookie.Replace(";", ","));
                request.KeepAlive = true;//建立持久性连接
 

                //整数据
                //string postData = string.Format("userName={0}&passwd={1}&validateCode={2}&rememberMe=true", uName, passwd, vaildate);
                //ASCIIEncoding encoding = new ASCIIEncoding();
                //byte[] bytepostData = encoding.GetBytes(postData);
                //request.ContentLength = bytepostData.Length;

                ////发送数据  using结束代码段释放
                //using (Stream requestStm = request.GetRequestStream())
                //{
                //    requestStm.Write(bytepostData, 0, bytepostData.Length);
                //}

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
                    //lblComputer.Text = "Success";
                }
                if (text.Contains("https://ss1.bdstatic.com/7Ls0a8Sm1A5BphGlnYG/sys/portrait/item/cfde6168686662777e01"))
                {
                    lblPhone.Text = "Success_phone";
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                lblComputer.Text = msg;
            }
        }


        private void ForComputer()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("http://localhost/20190325/page/test.html");

                request.Method = "GET";
                //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.ContentType = "text/html;charset=utf-8";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
                request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 73.0.3683.86 Safari / 537.36";
                request.AllowAutoRedirect = true;
                // request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里
                request.CookieContainer = new CookieContainer();
                //computer
                string strCookie = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_110085_123289; plus_cv=1::m:caddfa4f; BD_CK_SAM=1; PSINO=5; H_PS_645EC=2b78AwMLTx%2FGLXPrFqBh1GZA1Mml8OLxN4kMkMY7ikROoj9YK9YuqoygYXU; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=96MzRNQ0o5bm1CR35JUjZOdXdxT1JMfjB0WUpYVU0tT0h2YlNrVzZUalc2VFZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANZcDlvWXA5bRG; BD_HOME=1";
                strCookie = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_123980_110085_123289;            plus_cv=1::m:caddfa4f; BD_CK_SAM=1; PSINO=5; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=XRSbzRiaVg4RUhxajNjZW5KcFp-RkNqenhqRGk1cElLdXhHMDNmVjUzRU5CRFpiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA13DlsNdw5bL; BD_HOME=1; BDRCVFR[feWj1Vr5u3D]=I67x6TjHwwYf0; H_PS_645EC=2e63WS0lqVHTJbQdCQHN7W%2FzYBq0znQZ9uKSsOBJDEZ5syS2u9m%2FV%2FkCk9qbo5rzj9HE";
                //phone
               // strCookie = "BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; plus_cv=1::m:caddfa4f; BD_CK_SAM=1; PSINO=5; H_PS_645EC=2b78AwMLTx%2FGLXPrFqBh1GZA1Mml8OLxN4kMkMY7ikROoj9YK9YuqoygYXU; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=96MzRNQ0o5bm1CR35JUjZOdXdxT1JMfjB0WUpYVU0tT0h2YlNrVzZUalc2VFZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANZcDlvWXA5bRG; BD_HOME=1; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_123980_110085_123289; plus_lsv=de8ce127d8872de4; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527648863; SE_LAUNCH=5%3A25461144_0%3A25461144; bd_traffictrace=301624_301624; BDSVRTM=423; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527668684";

                /******方法一：
                //string[] arrCookieCollection = strCookie.Split(new char[] { ';' });
 
                //foreach (var item in arrCookieCollection)
                //{
                //    var arrCookie = item.Split(new char[] { '=' });
                //    request.CookieContainer.Add(new Cookie(arrCookie[0].Trim(), arrCookie[1].Trim(), "/", "www.baidu.com"));
                //}
                ************/

                //方法二：
                request.CookieContainer.SetCookies(new Uri("https://www.baidu.com"), strCookie.Replace(";", ","));


                request.KeepAlive = true;//建立持久性连接
                //request.Connection = "keep-alive";
                //整数据
                //string postData = string.Format("userName={0}&passwd={1}&validateCode={2}&rememberMe=true", uName, passwd, vaildate);
                //ASCIIEncoding encoding = new ASCIIEncoding();
                //byte[] bytepostData = encoding.GetBytes(postData);
                //request.ContentLength = bytepostData.Length;

                ////发送数据  using结束代码段释放
                //using (Stream requestStm = request.GetRequestStream())
                //{
                //    requestStm.Write(bytepostData, 0, bytepostData.Length);
                //}

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
                    lblComputer.Text = "Success_Computer";
                }
                
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                lblComputer.Text = msg;
            }    
        }

    }
}

//BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; plus_cv=1::m:caddfa4f; BD_CK_SAM=1; PSINO=5; H_PS_645EC=2b78AwMLTx%2FGLXPrFqBh1GZA1Mml8OLxN4kMkMY7ikROoj9YK9YuqoygYXU; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=96MzRNQ0o5bm1CR35JUjZOdXdxT1JMfjB0WUpYVU0tT0h2YlNrVzZUalc2VFZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANZcDlvWXA5bRG; BD_HOME=1; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_123980_110085_123289; plus_lsv=de8ce127d8872de4; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527648863; SE_LAUNCH=5%3A25461144_0%3A25461144; bd_traffictrace=301624_301624; BDSVRTM=423; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527668684