using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WeiXin.Log;

namespace WeiXin.Common
{
	public class Encryptcs
	{

		/// <summary>
		/// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
		/// </summary>
		/// <param name="str">要加密的字符串</param>
		/// <returns>加密后的十六进制的哈希散列（字符串）</returns>
		public static string Sha1Signature(string str)
		{
			var buffer = Encoding.UTF8.GetBytes(str);
			var data = SHA1.Create().ComputeHash(buffer);

			StringBuilder sub = new StringBuilder();
			foreach (var t in data)
			{
				sub.Append(t.ToString("X2"));
			}

			return sub.ToString();
		}


		/// <summary>
		/// 对字符串进行SHA1加密
		/// </summary>
		/// <param name="strIN">需要加密的字符串</param>
		/// <returns>密文</returns>
		public static string SHA1_Encrypt(string Source_String)
		{
			byte[] StrRes = Encoding.Default.GetBytes(Source_String);
			HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
			StrRes = iSHA.ComputeHash(StrRes);
			StringBuilder EnText = new StringBuilder();
			foreach (byte iByte in StrRes)
			{
				EnText.AppendFormat("{0:x2}", iByte);
			}
			return EnText.ToString().ToUpper();
		}


		public static string GetSha1Hash(string input)
		{
			byte[] inputBytes = Encoding.Default.GetBytes(input);

			SHA1 sha = new SHA1CryptoServiceProvider();

			byte[] result = sha.ComputeHash(inputBytes);

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < result.Length; i++)
			{
				sBuilder.Append(result[i].ToString("x2"));
			}
			
			return sBuilder.ToString().ToUpper();
		}


		public static bool VerifySha1Hash(string input, string hash)
		{
			string hashOfInput = GetSha1Hash(input);

			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// SHA1加密
		/// </summary>
		/// <param name="content">待加密的字符串</param>
		/// <param name="encode">编码方式</param>
		/// <returns></returns>
		public static String Sha1Sign(String content, Encoding encode)
		{
			try
			{
				SHA1 sha1 = new SHA1CryptoServiceProvider();//创建SHA1对象
				byte[] bytes_in = encode.GetBytes(content);//将待加密字符串转为byte类型
				byte[] bytes_out = sha1.ComputeHash(bytes_in);//Hash运算
				sha1.Dispose();//释放当前实例使用的所有资源
				String result = BitConverter.ToString(bytes_out);//将运算结果转为string类型
				result = result.Replace("-", "").ToUpper();
				return result;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}