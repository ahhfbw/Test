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
using System.Drawing;

namespace BaiduLogin
{
    public partial class BaiduManualLogin : Form
    {
        public BaiduManualLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnReValidate_Click(object sender, EventArgs e)
        {

        }

        private void picValidate_Click(object sender, EventArgs e)
        {
            btnReValidate_Click(sender, e);
        }

        private void BaiduManualLogin_Load(object sender, EventArgs e)
        {
           // btnReValidate_Click(sender, e);
            txtUserName.Text = "13485708506";
            txtPassWord.Text = "ebt12345678";

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("https://passport.baidu.com/v2/api/?login");

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
                request.AllowAutoRedirect = true;
                request.KeepAlive = true;



                var uName = "13485708506";
                var password = "Cq3ve8bxtrrRdglAAAgHpOpQbMKXL34wYS1+5ffkV+OUeVNyd14w/D58PM+/JBcGQOrQByAvaYO39741rTOmk8AZHjjg82RBmwHONJmhpzxY9g+B8ubwtrG07SSvyeMfQwM0jurpWbEJeZq+v6H8sTF/zi/A3bW94ZPvxJNvEqA=";

                var postData = string.Format("username={0}&password={1}&verifycode=aaa", uName, password);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostData = encoding.GetBytes(postData);
                request.ContentLength = bytepostData.Length;

                //发送数据  using结束代码段释放
                using (Stream requestStm = request.GetRequestStream())
                {
                    requestStm.Write(bytepostData, 0, bytepostData.Length);
                }

                //响应
                response = (HttpWebResponse)request.GetResponse();
                string text = string.Empty;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    text = redStm.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;

            }



            //string codeUrl = "https://passport.baidu.com/cgi-bin/genimage";

            //ELOGN_LOGIN agent = new ELOGN_LOGIN();
            //Stream stmImage = agent.getCodeStream(codeUrl);
            //picValidate.Image = Image.FromStream(stmImage);

        }
    }
}
