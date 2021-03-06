﻿using PersonInfoManage.DAL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace PersonInfoManage.DAL.Cost
{
    /// <summary>
    /// 费用申请
    /// </summary>
    public class CostApplyDAL:DALBase
    {
        /// <summary>
        /// 添加费用单
        /// </summary>
        /// <param name="cost">费用单主表对象 Main：apply_id、apply_money、status、apply_time、remark 
        /// 费用单审批详情列表 ApprovalList:approval_id
        /// 费用详情列表 DetailList：cost_type、money</param>
        /// <returns>数据表受影响的行数</returns>
        public int Add(cost cost)
        {
            cost_main Main = cost.Main;
            List<cost_detail> DetailList = cost.DetailList;
            //先构造所有的sql语句
            string[] sqlArray = new string[2 + DetailList.Count];
            //构造插入cost_main、cost_approval表的语句
            int timeStamp = TimeTools.Timestamp();
            Main.id = timeStamp;//主键(费用单id)是时间戳
            sqlArray[0] = ConditionsToSql<cost_main>.InsertSql(Main);
            //插入cost_approval表时，鉴于审核逻辑的关系，最多一次插入一个
            cost_approval Approval = cost.ApprovalList.First();
            Approval.cost_id = timeStamp;
            sqlArray[1] = ConditionsToSql<cost_approval>.InsertSql(Approval);
            //构造插入cost_detail表语句
            int count = 1;
            foreach(cost_detail detail in DetailList)
            {
                detail.cost_id = timeStamp;
                sqlArray[count + 1] = ConditionsToSql<cost_detail>.InsertSql(detail);
                count++;
            }
            //调用方法以事务方式执行sql数组里的语句
            return sqlArrayToTran.doTran(sqlArray);            
        }
        /// <summary>
        /// 更新费用单信息
        /// </summary>
        /// <param name="cost">费用单主表对象 Main：id、apply_money、remark 
        /// 费用单审批详情列表 ApprovalList:
        /// 费用详情列表 DetailList：cost_type、money</param>
        /// <returns>数据表受影响的行数</returns>
        public int Update(cost cost)
        {
            cost_main Main = cost.Main;
            List<cost_detail> DetailList = cost.DetailList;
            //构造sql语句数组
            string[] sqlArray = new string[2+DetailList.Count];
            //先更新cost_main表
            //更新费用金额信息和状态
            sqlArray[0]= "update cost_main set " +
                nameof(cost_main.apply_money) + "=" + Main.apply_money +","+
                nameof(cost_main.remark) + "='" +Main.remark+
                "' where id='" + Main.id + "'";
            //再删除cost_detail表数据
            sqlArray[1] = "delete from cost_detail where "+nameof(cost_detail.cost_id)+"='"+Main.id+"'";
            //再插入cost_detail表数据
            int count = 1;
            foreach(cost_detail detail in DetailList)
            {
                detail.cost_id = Main.id;
                sqlArray[count + 1] = ConditionsToSql<cost_detail>.InsertSql(detail);
                count++;
            }
            //调用方法以事务方式执行sql数组里的语句
            return sqlArrayToTran.doTran(sqlArray);            
        }
        /// <summary>
        /// 删除费用信息
        /// </summary>
        /// <param name="id">费用单id</param>
        /// <returns>数据表受影响的行数</returns>
        public int Del(int id)
        {
            //构造sql语句数组
            string[] sqlArray = new string[3];
            //删除费用类型表记录
            sqlArray[0] = "delete from cost_detail where cost_id = "+id;
            //删除费用审批详情表记录
            sqlArray[1] = "delete from cost_approval where cost_id = "+id;
            //再删除费用单表记录
            sqlArray[2] = "delete from cost_main where id='" + id + "'";
            //调用方法以事务方式执行sql数组里的语句
            return sqlArrayToTran.doTran(sqlArray);            
        }
        /// <summary>
        /// 根据费用单id查询审批详情列表
        /// </summary>
        /// <param name="costId"></param>
        /// <returns></returns>
        public List<cost_approval> QueryApproval(int costId)
        {
            List<cost_approval> ListApproval = new List<cost_approval>();
            string sql = "select * from cost_approval where cost_id=" + costId;
            DataTable dataTable = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                cost_approval approval = new cost_approval
                {
                    id = (int)row["id"],
                    cost_id = (int)row["cost_id"],
                    approval_id = (int)row["approval_id"]
                };
                approval.result = (bool?)ConvertTools.DbNullConvert(row["result"]);
                approval.time = (DateTime?)ConvertTools.DbNullConvert(row["time"]);
                approval.opinion = (string)ConvertTools.DbNullConvert(row["opinion"]);
                ListApproval.Add(approval);
            }
            return ListApproval;
        }
        /// <summary>
        /// 根据费用单id查询费用详情列表
        /// </summary>
        /// <param name="costId">费用单id</param>
        /// <returns>指定费用单id的费用详情列表</returns>
        public List<cost_detail> QueryDetail(int costId)
        {
            List<cost_detail> listDetail = new List<cost_detail>();
            string sql = "select * from cost_detail where cost_id=" + costId;
            DataTable dataTable = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                cost_detail detail = new cost_detail
                {
                    id = (int)row["id"],
                    cost_id = (int)row["cost_id"],
                    cost_type_id = (int)row["cost_type_id"],
                    money = (decimal)row["money"]
                };
                listDetail.Add(detail);
            }
            return listDetail;
        }
        /// <summary>
        /// 根据组合条件查询费用单（可分页）
        /// </summary>
        /// <param name="conditions">条件键值对key: "id", "apply_id", "status", "start_time", "end_time","page","limit"</param>
        /// <returns>费用单列表</returns>
        public List<cost_main> QueryMain(Dictionary<string, object> conditions)
        {
            //对组合条件参数进行合法性检验，获取合法的查询参数列表
            string[] keys = new string[] {"id", "apply_id", "status", "start_time", "end_time" };
            List<string> keyList = new List<string>();            
            foreach (string key in conditions.Keys)
            {   
                if (keys.Contains(key))
                    keyList.Add(key);

            }
            //根据参数列表，拼接组合条件sql语句
            string sql = "select ROW_NUMBER () OVER ( ORDER BY id ) AS rowNumber, * from cost_main ";
            foreach (string key in keyList)
            {
                //对第一个key特殊处理
                if (key.Equals(keyList.First()))
                {
                    sql += " where ";
                }
                else
                {
                    sql += " and ";
                }
                //对比较特别的关键字做不同的处理方式
                if (key.Equals("start_time"))
                {
                    DateTime start_time =(DateTime) conditions["start_time"];
                    sql += " apply_time>='" + new DateTime(start_time.Year,start_time.Month,start_time.Day,0,0,0) + "'";
                }
                else if (key.Equals("end_time"))
                {
                    DateTime end_time = (DateTime)conditions["end_time"];
                    sql += " apply_time<='" + new DateTime(end_time.Year,end_time.Month,end_time.Day,23,59,59) + "'";
                }
                else
                {   //增加对中文的支持
                    sql += " " + key + " like N'%" + conditions[key] + "%'";
                }

            }            
            //分页基础参数
            int page = 1, limit = 10;//默认查询第一页，一页十条数据
            if (conditions.Keys.Contains("page"))
            {
                page = (int)conditions["page"];
            }
            if (conditions.Keys.Contains("limit"))
            {
                limit = (int)conditions["limit"];
            }
            //拼接分页sql语句
            sql = "select top " + limit + " * from ( " + sql + " ) as t where rowNumber > " + (limit * (page - 1));
            //执行查询获取数据并封装返回
            List<cost_main> listMain = new List<cost_main>();
            DataTable dataTable = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                cost_main main = new cost_main
                {
                    id = (int)row["id"],
                    apply_id = (int)row["apply_id"],
                    apply_money = (decimal)row["apply_money"],
                    status = (byte)row["status"],
                    apply_time = (DateTime)row["apply_time"],
                    remark = (string)row["remark"]                    
                };                
                listMain.Add(main);
            }
            return listMain;
        }
        /// <summary>
        /// 获取数据字典中的费用类别
        /// </summary>
        /// <returns>费用类别的列表</returns>
        public List<string> GetCostTypes()
        {
            List<string> list = new List<string>();
            string sql = "select * from sys_dict where dict_name=N'Cost'";
            DataTable db = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0];
            for(int i = 0; i < db.Rows.Count; i++)
            {
                DataRow row = db.Rows[i];
                list.Add((int)row["id"]+"."+(string)row["category_name"]);
            }
            return list;
        }
        /// <summary>
        /// 获取用户的上级审核人列表
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public List<string> GetApprovalInfo(int apply_id)
        {
            List<string> approvalList = new List<string>();
            string sql = "select org_id from sys_user where id="+apply_id;
            string org_id = ((int)SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql).Tables[0].Rows[0]["org_id"]).ToString();
            string sql2 = "select parent_id from sys_org where id="+org_id;
            string parent_id = ((int)SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql2).Tables[0].Rows[0]["parent_id"]).ToString();
            if (int.Parse(parent_id) == 0)
            {
                //此时表明apply_id本人是支部领导，不需要继续查询上级领导了
                return approvalList;
            }
            string sql3 = "select parent_id from sys_org where id=" + parent_id;
            string parent_id2 = ((int)SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql3).Tables[0].Rows[0]["parent_id"]).ToString();
            string sql4 = "select id,org_name from sys_org where parent_id="+ parent_id2;
            DataTable dataTable = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql4).Tables[0];
            List<string> listOrg = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string tempOrg = ((int)dataTable.Rows[i]["id"]).ToString()+"."+ (string)dataTable.Rows[i]["org_name"];
                listOrg.Add(tempOrg);
            }
            foreach(string org in listOrg)
            {
                string orgId = org.Split('.')[0];
                string TempSql = "select id,name,job from sys_user where org_id="+orgId;
                DataTable dataTable2 = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, TempSql).Tables[0];
                for (int j= 0;j < dataTable2.Rows.Count; j++)
                {
                    DataRow row = dataTable2.Rows[j];
                    string tId = ((int)row["id"]).ToString();
                    string tName = (string)row["name"];
                    string tJob = (string)row["job"];
                    string approval = tId + "."+org.Split('.')[1]+"." + tJob + "." + tName;
                    //Console.WriteLine(approval);
                    approvalList.Add(approval);
                }
            }
            return approvalList;
        }
        public string GetCostTypeById(int dict_id)
        {
            string sql = "select category_name from sys_dict where id=" + dict_id;
            return (string)SqlHelper.ExecuteDataset(ConStr,CommandType.Text,sql).Tables[0].Rows[0]["category_name"];
        }
    }
}
