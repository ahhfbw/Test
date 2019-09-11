using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace WeiXin.Log
{
	public class LogUtil
	{
		/// <summary>
		/// filePath
		/// </summary>
		/// <param name="filePath"></param>
		public static void CreateLog(string filePath = "")
		{
			if (filePath == "")
			{
				filePath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "Log_AttendanceReminding.txt";
			}
			StreamWriter sw = null;
			if (!File.Exists(filePath))
			{
				sw = File.CreateText(filePath);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath">filePath</param>
		/// <param name="str">msg</param>
		public static void WriteLog(string filePath = "", string str = "")
		{
			if (filePath == "")
			{
				filePath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "Log_AttendanceReminding.txt";
			}

			StreamWriter sw = null;
			//if (!File.Exists(filePath))
			//{
			//    sw = File.CreateText(filePath);
			//}
			//else
			//{
			sw = File.AppendText(filePath);
			//}
			sw.Write(str + DateTime.Now.ToString() + Environment.NewLine);
			sw.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filePath">filePath</param>
		/// <param name="str">str</param>
		public static void WriteLogWithCheckFile(string filePath = "", string str = "")
		{
			if (filePath == "")
			{
				//Environment.CurrentDirectory
				filePath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "Log_AttendanceReminding.txt";
			}

			StreamWriter sw = null;
			if (!File.Exists(filePath))
			{
				sw = File.CreateText(filePath);
			}
			else
			{
				sw = File.AppendText(filePath);
			}
			sw.Write(str + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + Environment.NewLine);
			sw.Close();
		}


		public static void WriteLogWithCheckFile(string str = "")
		{
			string filePath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "Log_AttendanceReminding.txt";
			StreamWriter sw = null;
			if (!File.Exists(filePath))
			{
				sw = File.CreateText(filePath);
			}
			else
			{
				sw = File.AppendText(filePath);
			}
			sw.Write(str + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + Environment.NewLine);
			sw.Close();
		}


		public static void WriteLogWithCheckFile_Ex(string strLog ,string strName)
		{
			string filePath = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + "Log_AttendanceReminding.txt";
			StreamWriter sw = null;
			if (!File.Exists(filePath))
			{
				sw = File.CreateText(filePath);
			}
			else
			{
				sw = File.AppendText(filePath);
			}
			sw.Write(strName+":"+ strLog + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + Environment.NewLine);
			sw.Close();
		}
	}
}
