using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace BaiduLogin
{
    public partial class ELONG_LOGIN_FORM : Form
    {
        public ELONG_LOGIN_FORM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ELOGN_LOGIN elongLogin = new ELOGN_LOGIN();

            var rmsg = elongLogin.requestM(txtUserName.Text, txtPassWord.Text, txtValidateCode.Text);
            MessageBox.Show(rmsg);
        }

        private void ELONG_LOGIN_FORM_Load(object sender, EventArgs e)
        {
            ReflshPicImage();//更新验证码
        }

        //更新验证码
        public void ReflshPicImage()
        {
            string codeUrl = "https://secure.elong.com/passport/getValidateCode";
            ELOGN_LOGIN agent = new ELOGN_LOGIN();
            Stream stmImage = agent.getCodeStream(codeUrl);
            picValidate.Image = Image.FromStream(stmImage);
        }

        private void btnReValidate_Click(object sender, EventArgs e)
        {
            ReflshPicImage();//更新验证码
        }

        private void picValidate_Click(object sender, EventArgs e)
        {
            ReflshPicImage();//更新验证码
        }
    }

}

//电脑版
//BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=ZCdVljS2tUVGxHVnpoRX4zU0pRNmo5LTYyU3FXfmxqYm1kbU9qcE9NRXNuelZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACwSDlssEg5bMk; BD_HOME=1; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_110085_123289; plus_lsv=de8ce127d8872de4; plus_cv=1::m:caddfa4f; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527648863; SE_LAUNCH=5%3A25460814_0%3A25460814; bd_traffictrace=301054_301054_301055_301055; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527648948
//手机版
//BAIDUID=9AE9CD5894B9D826201CF9CF12E86B49:FG=1; BIDUPSID=9AE9CD5894B9D826201CF9CF12E86B49; PSTM=1514370856; BD_UPN=12314753; MCITY=-%3A; BDORZ=B490B5EBF6F3CD402E515D22BCDA1598; H_PS_PSSID=1461_26458_21117_22073; FP_UID=f2bfb97a1d7e36aeb7912e4e5c24f78f; BDUSS=ZCdVljS2tUVGxHVnpoRX4zU0pRNmo5LTYyU3FXfmxqYm1kbU9qcE9NRXNuelZiQVFBQUFBJCQAAAAAAAAAAAEAAADP3n4BYWhoZmJ3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACwSDlssEg5bMk; BD_HOME=1; H_WISE_SIDS=110315_114551_123232_123954_115653_122961_120195_118895_118874_118852_118825_118800_107314_117333_117430_122791_123572_123813_123811_123852_123700_123782_110085_123289; plus_lsv=de8ce127d8872de4; plus_cv=1::m:caddfa4f; Hm_lvt_12423ecbc0e2ca965d84259063d35238=1527648863; SE_LAUNCH=5%3A25460814_0%3A25460814; bd_traffictrace=301054_301055_301055_301109_301110; Hm_lpvt_12423ecbc0e2ca965d84259063d35238=1527649812