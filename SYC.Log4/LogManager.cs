///////////////////////////////////////////////////////////
//  LogManager.cs
//  Implementation of the Class LogManager
//  Generated by Enterprise Architect
//  Created on:      13-9月-2016 22:31:03
//  Original author: dazhuangtage
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace SYC.Log4
{
    /// <summary>
    /// 日志管理类,负责创建日志实例
    /// </summary>
    public sealed class LogManager
    {

        public INoticeable[] Noticeables;
        private ILogProvider _iLogPorvider;
        private IQueueProvider _iQueueProvider;
        private ILogProviderBuild _iLogProviderBuild;
        private IQueueProviderBulid _iQueueProviderBuild;
        private bool _isLoadConfig = false;
        private bool _isLoad = false;
        private bool _isStatrLisent = false;
        private bool _isQueue = false;
        public LogManager()
        {
            _isLoadConfig = true;
        }
        public LogManager(ILogProvider logProvider, params INoticeable[] notices)
        {
            _iLogPorvider = logProvider;
            Noticeables = notices;
        }


        public LogManager(ILogProvider logProvider, IQueueProvider queueProvider, params INoticeable[] notices) : this(logProvider)
        {
            _iQueueProvider = queueProvider;
            Noticeables = notices;
        }

        public LogManager(ILogProvider logProvider, IQueueProviderBulid queueProviderBuild, params INoticeable[] notices) : this(logProvider)
        {
            _iLogPorvider = logProvider;
            _iQueueProviderBuild = queueProviderBuild;
            Noticeables = notices;
        }

        public LogManager(ILogProviderBuild logProviderBuild, params INoticeable[] notices)
        {
            _iLogProviderBuild = logProviderBuild;
            Noticeables = notices;
        }

        public LogManager(ILogProviderBuild logProviderBuild, IQueueProvider queueProvider, params INoticeable[] notices) : this(logProviderBuild)
        {
            _iQueueProvider = queueProvider;
            Noticeables = notices;
        }
        public LogManager(ILogProviderBuild logProviderBuild, IQueueProviderBulid queueProviderBulid, params INoticeable[] notices) : this(logProviderBuild)
        {
            _iQueueProviderBuild = queueProviderBulid;
            Noticeables = notices;
        }

        private object o = new object();
        public void Write(LogModel logModel)
        {
            if (_isQueue)
            {
                if (_isLoadConfig)
                {
                    CreateQueueProvider().Set(logModel);
                }
                else
                {
                    if (_iQueueProviderBuild != null)
                        _iQueueProviderBuild.CreateQueueProvider(null).Set(logModel);
                    else if (_iQueueProviderBuild == null && _iQueueProvider != null)
                        _iQueueProvider.Set(logModel);

                }
            }
            else
            {

            }
        }

        private ILogProvider CreateLogProvider()
        {
            if (_isLoadConfig)
            {
                if (!_isLoad)
                {
                    lock (o)
                    {
                        if (!_isLoad)
                        {
                            //todo:从配置文件加载指定类型
                        }
                    }
                }
            }
            return _iLogPorvider;
        }



        /// <summary>
        /// 监听队列线程
        /// </summary>
        private void LisentQueue()
        {

            System.Threading.Thread th = new System.Threading.Thread((c) =>
            {
                while (true)
                {
                    var logModel = CreateQueueProvider().Get();
                    if (logModel != null)
                    {
                        CreateLogProvider().Write(logModel);
                    }
                    System.Threading.Thread.Sleep(500);
                }
            });
            th.Start();

        }

        private IQueueProvider CreateQueueProvider()
        {
            throw new Exception();

        }

        public void Write(LogModel logModel, eLogErrorType logType)
        {

        }

    }//end LogManager
}