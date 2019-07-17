﻿using PersonInfoManage.DAL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfoManage.DAL.System
{
    /// <summary>
    /// 权限管理
    /// </summary>
    public class Perm :DALBase
    {
        /// <summary>
        ///添加用户组
        /// </summary>
        /// <param name="group">用户组信息</param>
        /// <returns>添加条数</returns>
        public int InsertPermission(sys_group group)
        {
           

            int res;
            string sql1 = "Insert into sys_group(group_name,remark) values(@p1,@p2)";
            SqlParameter sqlparameter1 = new SqlParameter("@p1", group.group_name);
            SqlParameter sqlparameter2 = new SqlParameter("@p2", group.remark);
            res = SqlHelper.ExecuteNonQuery(ConStr, CommandType.Text, sql1, sqlparameter1, sqlparameter2);       
            return res;
        }

        /// <summary>
        /// 用户组权限修改
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="newValues">需要修改的值</param>
        /// <returns>修改条数</returns>
        public int UpdatePermission(int group_id,  string menu_name)
        {
            
            int res = 0;
            string sql1 = "Update sys_menu set menu_name=@p3 where id=@p4";
            SqlParameter sqlparameter3 = new SqlParameter("@p3", menu_name);
            SqlParameter sqlparameter4 = new SqlParameter("@p4", group_id);
            res=SqlHelper.ExecuteNonQuery(ConStr, CommandType.Text, sql1,  sqlparameter3, sqlparameter4);
            return res;
            
            
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>删除条数</returns>
        public int DeletePermission(int group_id)
        {
            int res;
            string sql1 = "Delete from sys_group where id=@p1";
            SqlParameter sqlparameter1 = new SqlParameter("@p1", group_id);
            res = SqlHelper.ExecuteNonQuery(ConStr, CommandType.Text, sql1, sqlparameter1);
            return res;
            // return new DBOperationsDelete<sys_u2r, DBNull>().DeleteById(userId);
        }

        /// <summary>
        /// 通过输入条件进行权限检索
        /// </summary>
        /// <param name="conditions">输入条件</param>
        /// <returns>权限信息</returns>
        public List<sys_group> SelectPermissionByConditions(string group_name)
        {
            DataSet ds = new DataSet();
            string sql1 = "Select * from sys_group where group_name=@p1 ";
            SqlParameter sqlparameter1 = new SqlParameter("@p1", group_name);
            
            ds = SqlHelper.ExecuteDataset(ConStr, CommandType.Text, sql1);
            sys_group group1 = new sys_group();
            List<sys_group> role = new List<sys_group>();        
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                group1.id = int.Parse((string)ds.Tables[0].Rows[i][nameof(sys_group.id)]);
                group1.group_name= (string)ds.Tables[0].Rows[i][nameof(sys_group.group_name)];
              
                group1.remark = (string)ds.Tables[0].Rows[i][nameof(sys_group.remark)];
                group1.create_time = (DateTime)ds.Tables[0].Rows[i][nameof(sys_group.create_time)];
                group1.modify_time = (DateTime)ds.Tables[0].Rows[i][nameof(sys_group.modify_time)];
            }
            role.Add(group1);
            return role;

            //return new DBOperationsSelect<sys_u2r>().SelectByConditions(conditions);
        }
    }
}
