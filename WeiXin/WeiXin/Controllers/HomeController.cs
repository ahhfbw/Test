using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXin.Log;
using WeiXin.Common;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WeiXin.Controllers
{
	public class HomeController : Controller
	{
		private static object objLock = new object();

		public string Index()
		{

			lock (objLock)
			{

			}

			Stream s = null;
			if ((s = Request.InputStream) != null && s.Length > 0)
			{
				string strPostData = Comon.GetPostData(s);

				//< xml >
				//  < ToUserName >< ![CDATA[toUser]] ></ ToUserName >
				//  < FromUserName >< ![CDATA[fromUser]] ></ FromUserName >
				//  < CreateTime > 1348831860 </ CreateTime >
				//  < MsgType >< ![CDATA[text]] ></ MsgType >
				//  < Content >< ![CDATA[this is a test]] ></ Content >
				//  < MsgId > 1234567890123456 </ MsgId >
				//</ xml >
				LogUtil.WriteLogWithCheckFile_Ex(strPostData, "PostData");

				//< xml >< ToUserName >< ![CDATA[gh_1843bb44e922]] ></ ToUserName >
				//< FromUserName >< ![CDATA[oVMqz0uOTRHNsAkaOni88mDeyPT0]] ></ FromUserName >
				//< CreateTime > 1568186732 </ CreateTime >
				//< MsgType >< ![CDATA[text]] ></ MsgType >
				//< Content >< ![CDATA[haha]] ></ Content >
				//< MsgId > 22451039011753575 </ MsgId >
				//</ xml >

//				strPostData = @"<xml><ToUserName><![CDATA[gh_1843bb44e922]]></ToUserName>
//<FromUserName><![CDATA[oVMqz0uOTRHNsAkaOni88mDeyPT0]]></FromUserName>
//<CreateTime>1568186732</CreateTime>
//<MsgType><![CDATA[text]]></MsgType>
//<Content><![CDATA[haha]]></Content>
//<MsgId>22451039011753575</MsgId>
//</xml>";
				//https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140453
				//https://www.cnblogs.com/wt627939556/p/6646752.html
				XmlDocument doc = new XmlDocument();
				try
				{
					doc.LoadXml(strPostData);
					XmlNode node = doc.SelectSingleNode("xml/MsgType");
					string ToUserName = "";
					string FromUserName = "";
					if (node !=null)
					{
						 ToUserName = doc.SelectSingleNode("xml/ToUserName").InnerText;
						 FromUserName = doc.SelectSingleNode("xml/FromUserName").InnerText;
					}

					string fensihao = FromUserName;
					string gongzhonghao = ToUserName;

					switch (node.InnerText)
					{
						case "text"://文本消息
							
							string Content =doc.SelectSingleNode("xml/Content").InnerText;
							string msgType = "text";
							string content = "你发送的消息为：" + Content;
							//string returnData = @"<xml>
							//<ToUserName><![CDATA[粉丝号]]></ToUserName>
							//<FromUserName><![CDATA[公众号]]></FromUserName>
							//<CreateTime>1460541339</CreateTime>
							//<MsgType><![CDATA[text]]></MsgType>
							//<Content><![CDATA[test]]></Content>
							//</xml>";
							string returnData =@"<xml>
 <ToUserName><![CDATA["+ fensihao + @"]]></ToUserName>
 <FromUserName><![CDATA["+gongzhonghao+@"]]></FromUserName>
 <CreateTime>"+DateTime.Now.Ticks+@"</CreateTime>
 <MsgType><![CDATA["+ msgType + @"]]></MsgType>
 <Content><![CDATA["+content+@"]]></Content>
 </xml>";
							return returnData;

							//break;
						case "image"://图片消息
									 //							< xml >
									 //< ToUserName >< ![CDATA[公众号]] ></ ToUserName >
									 // < FromUserName >< ![CDATA[粉丝号]] ></ FromUserName >
									 // < CreateTime > 1460536575 </ CreateTime >
									 // < MsgType >< ![CDATA[image]] ></ MsgType >
									 // < PicUrl >< ![CDATA[http://mmbiz.qpic.cn/xxxxxx /0]]></PicUrl>
									 // < MsgId > 6272956824639273066 </ MsgId >
									 // < MediaId >< ![CDATA[gyci5a - xxxxx - OL]] ></ MediaId >
									 // </ xml >
							return @"<xml>
 <ToUserName><![CDATA[" + fensihao + @"]]></ToUserName>
 <FromUserName><![CDATA[" + gongzhonghao + @"]]></FromUserName>
 <CreateTime>" + DateTime.Now.Ticks + @"</CreateTime>
 <MsgType><![CDATA[image]]></MsgType>
 <Image>
 <MediaId><![CDATA["+ doc.SelectSingleNode("xml/MediaId").InnerText + @"]]></MediaId>
 </Image>
 </xml>";
							//break;
						case "voice"://语音消息
							break;
						case "video"://视频
							break;
						case "shortvideo"://小视频
							break;
						case "location"://地理位置
							break;
						case "link"://链接消息
							break;

						case "event"://接收事件推送

							//1 关注 / 取消关注事件
							if (doc.SelectSingleNode("xml/Event").InnerText== "subscribe")
							{
								LogUtil.WriteLogWithCheckFile("subscribe");

								return @"<xml>
 <ToUserName><![CDATA[" + fensihao + @"]]></ToUserName>
 <FromUserName><![CDATA[" + gongzhonghao + @"]]></FromUserName>
 <CreateTime>" + DateTime.Now.Ticks + @"</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[感谢你关注龙城帝国公众号,"+Environment.NewLine+@"小龙将竭诚为您服务]]></Content>
 </xml>";
							}
							if (doc.SelectSingleNode("xml/Event").InnerText == "unsubscribe")
							{
								LogUtil.WriteLogWithCheckFile("unsubscribe");
								return @"<xml>
 <ToUserName><![CDATA[" + fensihao + @"]]></ToUserName>
 <FromUserName><![CDATA[" + gongzhonghao + @"]]></FromUserName>
 <CreateTime>" + DateTime.Now.Ticks + @"</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[谢谢你一直的陪伴，期待下次小龙将更好的为您服务]]></Content>
 </xml>";
							}

							//2 扫描带参数二维码事件

							//3 上报地理位置事件

							//4 自定义菜单事件

							//5 点击菜单拉取消息时的事件推送

							//6 点击菜单跳转链接时的事件推送


							break;
						default:
							break;
					}
					return "success";
				}
				catch (Exception ex)
				{
					return ex.Message;

				}





			}

			if (!string.IsNullOrEmpty(Request.QueryString["signature"]))
			{
				string echostr = Request.QueryString["echostr"];

				string signature = Request.QueryString["signature"];

				string timestamp = Request.QueryString["timestamp"];
				string nonce = Request.QueryString["nonce"];
				string token = Define.TOKEN;

				string[] arrCheck = { timestamp, nonce, token };
				Array.Sort(arrCheck);
				LogUtil.WriteLogWithCheckFile("", "echostr:" + echostr);

				LogUtil.WriteLogWithCheckFile("", "signature:" + signature);
				LogUtil.WriteLogWithCheckFile("", "timestamp:" + timestamp);
				LogUtil.WriteLogWithCheckFile("", "nonce:" + nonce);
				LogUtil.WriteLogWithCheckFile("", "token:" + token);

				string newStr = string.Join("", arrCheck);
				LogUtil.WriteLogWithCheckFile("", "newStr:" + newStr);

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