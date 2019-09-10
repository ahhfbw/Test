using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXin.Log;
using WeiXin.Common;

namespace WeiXin.Controllers
{
	public class HomeController : Controller
	{
		public string Index()
		{

			if (!string.IsNullOrEmpty( Request.QueryString["signature"]))
			{
				string echostr = Request.QueryString["echostr"];

				string signature = Request.QueryString["signature"];

				string timestamp = Request.QueryString["timestamp"];
				string nonce = Request.QueryString["nonce"];
				string token = Define.TOKEN;

				string[] arrCheck = { timestamp ,nonce,token};
				Array.Sort(arrCheck);
				LogUtil.WriteLogWithCheckFile("", "echostr:" + echostr);

				LogUtil.WriteLogWithCheckFile("", "signature:" + signature);
				LogUtil.WriteLogWithCheckFile("", "timestamp:"+ timestamp);
				LogUtil.WriteLogWithCheckFile("", "nonce:" + nonce);
				LogUtil.WriteLogWithCheckFile("", "token:" + token);

				string newStr = string.Join("", arrCheck);
				LogUtil.WriteLogWithCheckFile("", "newStr:"+newStr);

				LogUtil.WriteLogWithCheckFile("", "jiamiGetSha1Hash:" + Encryptcs.GetSha1Hash(newStr));
				LogUtil.WriteLogWithCheckFile("", "jiamiSHA1_Encrypt:" + Encryptcs.SHA1_Encrypt(newStr));
				LogUtil.WriteLogWithCheckFile("", "jiamiSha1Signature:" + Encryptcs.Sha1Signature(newStr));

				//微信服务器发过来的请求
				if (Encryptcs.VerifySha1Hash(newStr, signature))
				{
					LogUtil.WriteLogWithCheckFile("", "echostr(success):" + echostr);
					return echostr;
					//Response.Write(echostr);
				}
			}
			return "Invalid Request";
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}