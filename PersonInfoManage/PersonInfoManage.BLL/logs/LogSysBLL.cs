﻿using PersonInfoManage.BLL.Utils;
using PersonInfoManage.DAL.Logs;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfoManage.BLL.Logs
{
    public class LogSysBLL
    {
        /// <summary>
        /// 系统日志删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result Del(int id)
        {
            Result r = new Result();
            if (new LogSysDAL().Del(id) > 0)
            {
                r.Code = RES.OK;
                r.Message = "删除成功！";
            }
            else
            {
                r.Code = RES.ERROR;
                r.Message = "删除失败！";
            }
            return r;
        }


        /// <summary>
        /// 系统日志查询所有
        /// </summary>
        /// <returns></returns>

        public List<log_sys> Query()
        {
            List<log_sys> sysList = new LogSysDAL().Query();
            return sysList;
        }


        /// <summary>
        /// 系统日志查询
        /// 条件：时间段
        /// </summary>
        /// <param name="create_time"></param>
        /// <returns></returns>
        public List<log_sys> Query(DateTime start_time, DateTime end_time)
        {
            List<log_sys> sysList = new LogSysDAL().Query(start_time, end_time);
            if (sysList == null)
            {
                Console.WriteLine("没有查到相关信息！");
            }
            return sysList;
        }


    }
}