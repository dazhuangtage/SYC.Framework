///////////////////////////////////////////////////////////
//  SqlServerLogProvider.cs
//  Implementation of the Class SqlServerLogProvider
//  Generated by Enterprise Architect
//  Created on:      13-9月-2016 22:36:15
//  Original author: dazhuangtage
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace SYC.Log4
{
	/// <summary>
	/// 持久化到SqlServer数据库
	/// </summary>
	public class SqlServerLogProvider : ILogProvider {

		public string ConnectionStr;
		public string TableName;

		public SqlServerLogProvider(){

		}

		~SqlServerLogProvider(){

		}

		/// 
		/// <param name="logModel"></param>
		public void Write(LogModel logModel){

		}

	}//end SqlServerLogProvider

}//end namespace 默认日志提供程序