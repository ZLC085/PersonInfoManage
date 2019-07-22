﻿using PersonInfoManage.DAL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfoManage.DAL.PersonInfo
{
    public class NativePlaceDAL
    {
        #region test1
        //public List<native_place> Select(native_place info)
        //{
        //    // 用于返回的列表
        //    List<native_place> list = new List<native_place>();
        //    try
        //    {
        //        string sql = "";
        //        //sql语句
        //        if (!string.IsNullOrEmpty(info.province))
        //        {
        //            sql = "select province from native_place group by " + info.province;
        //            if (!string.IsNullOrEmpty(info.city))
        //            {
        //                sql = "select city from native_place where province = " + info.province + " group by city";
        //                if (!string.IsNullOrEmpty(info.place))
        //                {
        //                    sql = "select place from native_place where city = " + info.city + " group by place";
        //                }
        //            }
        //        }


        //        DataSet ds = new DataSet();
        //        // 执行sql语句并返回数据集
        //        ds = SqlHelper.ExecuteDataset(DALBase.ConStr, CommandType.Text, sql);
        //        // 遍历表中的行
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            native_place np = new native_place();
        //            if (!string.IsNullOrEmpty(info.province))
        //            {
        //                np.province = dr[0].ToString();
        //                if (!string.IsNullOrEmpty(info.city))
        //                {
        //                    np.city = dr[1].ToString();
        //                    if (!string.IsNullOrEmpty(info.place))
        //                    {
        //                        np.place = dr[2].ToString();
        //                    }
        //                }
        //            }
        //            list.Add(np);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw e;
        //    }
        //    // 返回列表
        //    return list;
        //}
        #endregion

        /// <summary>
        /// 三级查询
        /// </summary>
        /// <param name="type">选项类型</param>
        /// <param name="parent">父级类型</param>
        /// <returns>list类型</returns>
        public List<string> Query(string type, string parent)
        {
            // 用于返回的列表
            List<string> list = new List<string>();
            try
            {
                // sql语句
                string sql = "";
                if (type.Equals("province"))
                {
                    sql = "select province from native_place group by province";
                }
                else if (type.Equals("city") && !string.IsNullOrEmpty(parent))
                {
                    sql = "select city from native_place where province = N'" + parent + "' group by city";
                }
                else if (type.Equals("place") && !string.IsNullOrEmpty(parent))
                {
                    sql = "select place from native_place where city = N'" + parent + "' group by place";
                }
                else
                {
                    // 返回空列表
                    return list;
                }

                DataSet ds = new DataSet();
                // 执行sql语句并返回数据集
                ds = SqlHelper.ExecuteDataset(DALBase.ConStr, CommandType.Text, sql);
                // 遍历表中的行
                string str = "";
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // 封装
                    str = dr[0].ToString();
                    list.Add(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            // 返回列表
            return list;
        }
    }
}
