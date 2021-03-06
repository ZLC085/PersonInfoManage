﻿using PersonInfoManage.DAL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfoManage.DAL.Cost
{
    /// <summary>
    /// 费用规划
    /// </summary>
    public class CostPlanDAL : DALBase
    {
       
        /// <summary>
        /// 费用规划添加
        /// </summary>
        /// <param name="ListPlan"></param>
        /// <returns>添加数目</returns>
        public int Add(List<cost_plan> ListPlan)
        {
            string[] sqlPlan = new string[ListPlan.Count];
            
            int count = 0;
            foreach (cost_plan plan in ListPlan)
            {
                sqlPlan[count] = "insert into cost_plan(cost_type_id,money,start_time,end_time) values('"+plan .cost_type_id+ "','" + plan.money+"','"+plan.start_time+"','"+plan.end_time+"')";
                count++;
            }
            return sqlArrayToTran.doTran(sqlPlan);
        }
       
        /// <summary>
        /// 费用规划修改
        /// </summary>
        /// <param name="ListPlan"></param>
        /// <returns>修改条数</returns>
        public int Update(List<cost_plan> ListPlan)
        {
            string[] sqlPlan = new string[ListPlan.Count];

            int count = 0;
            foreach (cost_plan plan in ListPlan)
            {
                sqlPlan[count] = "update cost_plan set  "+nameof(cost_plan.money)+"= '"+plan.money+ "' where " +
                    "" + nameof(cost_plan.cost_type_id) + " ='" + plan.cost_type_id + "' and " + 
                    nameof(cost_plan.start_time) + "='" + plan.start_time + "' and " + 
                    nameof(cost_plan.end_time) + "='" + plan.end_time + "'";
                //Console.WriteLine(sqlPlan[count]);
                count++;
            }
            return sqlArrayToTran.doTran(sqlPlan); 
        }

        /// <summary>
        /// 费用规划删除，根据时间
        /// </summary>
        /// <param name="ListPlan"></param>
        /// <returns>删除条数</returns>
        public int Del(Dictionary<string,DateTime> period)
        {
            DateTime start_time = period["start_time"];
            DateTime end_time = period["end_time"];
            int startYear = start_time.Year;
            int startMonth = start_time.Month;
            int startDay = start_time.Day;
            int endYear = end_time.Year;
            int endMonth = end_time.Month;
            int endDay = end_time.Day;
            string sql = "delete from cost_plan where " +
                nameof(cost_plan.start_time) + ">='" + new DateTime(startYear, startMonth, startDay, 0, 0, 0) + "' and " +
                nameof(cost_plan.start_time) + "<='" + new DateTime(startYear, startMonth, startDay, 23, 59, 59) + "' and " +
                nameof(cost_plan.end_time) + ">='" + new DateTime(endYear, endMonth, endDay, 0, 0, 0) + "' and " +
                nameof(cost_plan.end_time) + "<='" + new DateTime(endYear, endMonth, endDay, 23, 59, 59) + "'";
            return SqlHelper.ExecuteNonQuery(ConStr, CommandType.Text, sql);
        }
      
        /// <summary>
        /// 费用规划检索，根据组合条件
        /// </summary>
        /// <param name="conditions">组合条件词典</param>
        /// <returns>费用规划列表</returns>
        public List<cost_plan> Query(Dictionary<string, object> conditions)
        {
            string[] keys = new string[] { "start_time", "end_time" };
            List<cost_plan> retList = new List<cost_plan>();
            List<string> listKey = new List<string>();
            foreach (string key in conditions.Keys)
            {
                if (keys.Contains(key))
                {
                    listKey.Add(key);
                }
            }
            string sql = "select * from cost_plan ";
            foreach (string key in listKey)
            {
                if (!key.Equals(listKey.First()))
                {
                    sql += " and ";
                }else
                {
                    sql += " where ";
                }
                if (key.Equals("start_time"))
                {
                    DateTime start_time =(DateTime) conditions[key];
                    sql += " start_time >='" + new DateTime(start_time.Year,start_time.Month,start_time.Day,0,0,0) + "'";
                }
                else if (key.Equals("end_time"))
                {
                    DateTime end_time = (DateTime)conditions[key];
                    sql += " end_time<='" + new DateTime(end_time.Year,end_time.Month,end_time.Day,23,59,59) + "'";
                }
                else
                {
                    sql += " " + key + " like N'%" + conditions[key] + "%'";
                }
            }
            DataSet ds = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cost_plan plan = new cost_plan();
                plan.cost_type_id = (int)dt.Rows[i]["cost_type_id"];
                plan.start_time = (DateTime)dt.Rows[i]["start_time"];
                plan.end_time = (DateTime)dt.Rows[i]["end_time"];
                plan.money = (decimal)dt.Rows[i]["money"];
                retList.Add(plan);
            }
            return retList;
        }
        /// <summary>
        /// 费用规划，根据时间段求和
        /// </summary>
        /// <param name="SrartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns>费用规划列表中费用“总计”</returns>
        public decimal QuerySum(DateTime SrartTime,DateTime EndTime)
        {
            decimal money = 0;
            string sql = "SELECT start_time,end_time,SUM(money) as money from cost_plan WHERE start_time>='"+new DateTime(SrartTime.Year,SrartTime.Month,SrartTime.Day,0,0,0)+ "' and start_time<='" 
                + new DateTime(SrartTime.Year, SrartTime.Month, SrartTime.Day, 23, 59, 59) + "' and end_time >= '" 
                + new DateTime(EndTime.Year, EndTime.Month, EndTime.Day, 0, 0, 0) + "' and end_time <= '" 
                + new DateTime(EndTime.Year, EndTime.Month, EndTime.Day, 23, 59, 59) + "' GROUP BY start_time,end_time";
            try
            {
                DataRow row = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0].Rows[0];

                money = (decimal)row["money"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return money;
        }
    }
}