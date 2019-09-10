using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WeiXin.Common
{
	public class Comon
	{
		//access_token 获取
		//https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxbc353613b2bf24fd&secret=5f2440cc2b0243de9b60ee8087c8f6bd
		//{"access_token":"25_C8W4gOCGWH-i3hmsxFYeMw7HO9EjpBP8RryytmkwyKOSqf-oMisBymrtJp4Qux2Bzp4gBeB4u2SGNEJJGribwkP2YpS-PXEJgVdopmNKICxBD3uvRgyHjCZ6HQStCZRlGFxyyPZqHP7ccPt2LWVeACAQBA","expires_in":7200}


		/// <summary>
		/// 发送HttpGet请求,返回string格式的json数据
		/// </summary>
		/// <param name="strUrl"></param>
		/// <param name="strPostData"></param>
		/// <returns></returns>
		public static string HttpGet(string strUrl, string strPostData)
		{
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strUrl + (strPostData == "" ? "" : "?") + strPostData);
			objRequest.Method = "GET";
			objRequest.ContentType = "text/html;charset=UTF-8";
			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			Stream objMyResponseStream = objResponse.GetResponseStream();
			StreamReader objMyStreamReader = new StreamReader(objMyResponseStream, Encoding.GetEncoding("utf-8"));
			string strRet = objMyStreamReader.ReadToEnd();
			objMyStreamReader.Close();
			objMyResponseStream.Close();
			return strRet;
		}

		/// <summary>
		/// 发送HttpPost请求,返回string格式的json数据
		/// </summary>
		/// <param name="strUrl"></param>
		/// <param name="strPostData"></param>
		/// <returns></returns>
		public static string HttpPost(string strUrl, string strPostData, string strBody)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl + (strPostData == "" ? "" : "?") + strPostData);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			UTF8Encoding objEncoding = new UTF8Encoding();
			byte[] bytBytes = objEncoding.GetBytes(strBody);
			request.ContentLength = bytBytes.Length;

			using (Stream writeStream = request.GetRequestStream())
			{
				writeStream.Write(bytBytes, 0, bytBytes.Length);
			}

			HttpWebResponse objResponse = (HttpWebResponse)request.GetResponse();
			Stream objMyResponseStream = objResponse.GetResponseStream();
			StreamReader objMyStreamReader = new StreamReader(objMyResponseStream, Encoding.GetEncoding("utf-8"));
			string strRet = objMyStreamReader.ReadToEnd();
			objMyStreamReader.Close();
			objMyResponseStream.Close();
			return strRet;
		}
	}
}