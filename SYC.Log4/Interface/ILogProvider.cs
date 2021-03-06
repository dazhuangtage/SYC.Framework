///////////////////////////////////////////////////////////
//  ILogProvider.cs
//  Implementation of the Interface ILogProvider
//  Generated by Enterprise Architect
//  Created on:      13-9月-2016 22:33:53
//  Original author: dazhuangtage
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace SYC.Log4
{
    /// <summary>
    /// 日志实现类接口
    /// </summary>
    public interface ILogProvider
    {
        void Write(LogModel logModel);
    }//end ILogProvider

}//end namespace 域模型