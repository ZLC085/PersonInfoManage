﻿using PersonInfoManage.DAL.Utils;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfoManage.DAL.System
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class SysUser : DALBase
    {
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>添加条数</returns>
        public int InsertSysUser(sys_user user, string group_id)
        {
            string sql = "Insert into sys_user (username,name,password,gender,job,phone,email) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
            string sql1 = "Insert into sys_u2g (user_id,group_id) values(@p8,@p9)";
            string SelectSql = "select form sys_user where user_name='"+user.name+"'";
            DataSet ds = new DataSet();
            SqlParameter sqlparameter = new SqlParameter("@p1", user.username);
            SqlParameter sqlparameter1 = new SqlParameter("@p2", user.name);
            SqlParameter sqlparameter2 = new SqlParameter("@p3", user.password);
            SqlParameter sqlparameter3 = new SqlParameter("@p4", user.gender);
            SqlParameter sqlparameter4 = new SqlParameter("@p5", user.job);
            SqlParameter sqlparameter5 = new SqlParameter("@p6", user.phone);
            SqlParameter sqlparameter6 = new SqlParameter("@p7", user.email);      
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = trans;
                try
                {
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql, sqlparameter, sqlparameter1, sqlparameter2, sqlparameter3, sqlparameter4, sqlparameter5, sqlparameter6);
                    ds=SqlHelper.ExecuteDataset(connection, CommandType.Text, SelectSql);
                    user.id = int.Parse((string)ds.Tables[0].Rows[0][nameof(sys_user.id)]);
                    SqlParameter sqlparameter7 = new SqlParameter("@p8", user.id);
                    SqlParameter sqlparameter8 = new SqlParameter("@p9", group_id);
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql1, sqlparameter7,sqlparameter8);
                    trans.Commit();
                    return 1;
                }
                catch
                {
                    trans.Rollback();
                    return 0;
                }
            }
            //return new DBOperationsInsert<sys_user, DBNull>().Insert(user);
        }
        /// <summary>
        /// 用户信息修改
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="newValues">用户信息</param>
        /// <returns>修改条数</returns>
        public int UpdateSysUser(int id, sys_user user,int group_id)
        {
            string sql = "updata sys_user set (username,name,password,gender,job,phone,email) = (@p1,@p2,@p3,@p4,@p5,@p6,@p7) where id=id";
            string sql1 = "updata sys_u2g set group_id=@p9 where user_id=id";
            SqlParameter sqlParameter = new SqlParameter("@p1",user.username);
            SqlParameter sqlParameter1 = new SqlParameter("@p2", user.name);
            SqlParameter sqlParameter2 = new SqlParameter("@p3", user.password);
            SqlParameter sqlParameter3 = new SqlParameter("@p4", user.gender);
            SqlParameter sqlParameter4 = new SqlParameter("@p5", user.job);
            SqlParameter sqlParameter5 = new SqlParameter("@p6", user.phone);
            SqlParameter sqlParameter6 = new SqlParameter("@p7", user.email);
            SqlParameter sqlParameter7 = new SqlParameter("@p8", user.status);
            SqlParameter sqlParameter8 = new SqlParameter("@p9", group_id);
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = trans;
                try
                {
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql, sqlParameter, sqlParameter1, sqlParameter2, sqlParameter3, sqlParameter4, sqlParameter5, sqlParameter6, sqlParameter7);
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql1, sqlParameter8);
                    trans.Commit();
                    return 1;
                }
                catch
                {
                    trans.Rollback();
                    return 0;
                }
            }
            
            //return new DBOperationsUpdate<sys_dict>().UpdateById(id, newValues);
        }
 


        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>删除条数</returns>
        public int DeleteSysUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = trans;
                try
                {
                    string sql = "delete from sys_user where id=id";
                    string sql1 = "delete from sys_u2g where user_id=id";
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql);
                    SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql1);
                    trans.Commit();
                    return 1;
                    
                }
                catch
                {
                    trans.Rollback();
                    return 0;
                }
            }
            //return new DBOperationsDelete<sys_user, DBNull>().DeleteById(userId);
        }


        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>所有用户</returns>
        public Dictionary<sys_user, List<sys_group>> SelectAllSysUser()
        {
            Dictionary<sys_user, List<sys_group>> user = new Dictionary<sys_user, List<sys_group>>();
            sys_user user1 = new sys_user();
            List<sys_group> listrole = new List<sys_group>();
            sys_group role = new sys_group();
            sys_group user2 = new sys_group();
            sys_u2g u2g = new sys_u2g();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string sql = "select * from sys_user";
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = trans;
                try
                {
                    ds = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        user1.id = int.Parse((string)ds.Tables[0].Rows[i][nameof(sys_user.id)]);
                        user1.username = (string)ds.Tables[0].Rows[i][nameof(sys_user.username)];
                        user1.name = (string)ds.Tables[0].Rows[i][nameof(sys_user.name)];
                        user1.gender = (string)ds.Tables[0].Rows[i][nameof(sys_user.gender)];
                        user1.phone = (string)ds.Tables[0].Rows[i][nameof(sys_user.phone)];
                        user1.job = (string)ds.Tables[0].Rows[i][nameof(sys_user.job)];
                        user1.status = Boolean.Parse((string)ds.Tables[0].Rows[i][nameof(sys_user.status)]);
                        string sql1 = "select from sys_u2g where user_id='" + user1.id + "'";
                        ds1 = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql);
                        u2g.group_id = int.Parse((string)ds.Tables[0].Rows[0][nameof(sys_u2g.user_id)]);
                        string sql2 = "select from sys_group where id='" + u2g.group_id + "'";
                        ds2 = SqlHelper.ExecuteDataset(connection, CommandType.Text, sql);
                        role.group_name = (string)ds.Tables[0].Rows[0][nameof(sys_group.group_name)];
                        listrole.Add(role);
                        user.Add(user1, listrole);
                    }
                    trans.Commit();
                    return user;
                }
                catch
                {
                    trans.Rollback();
                    return null;
                } 
            }
            //return new DBOperationsSelect<sys_user>().SelectAll();
        }


        /// <summary>
        /// 通过输入条件查询用户
        /// </summary>
        /// <param name="conditions">查询条件</param>
        /// <returns>通过用户名查询到的用户</returns>
        public Dictionary<sys_user, List<sys_group>> SelectSysUserByConditions(Dictionary<string, object> conditions)
        {
            Dictionary<sys_user, List<sys_group>> Dic = new Dictionary<sys_user, List<sys_group>>();
            foreach (var Kit in Dic)
            {
                string name = Kit.Key.ToString();
            }
            string sql = "select * from sys_user where ";

            return Dic;
            }
            //return new DBOperationsSelect<sys_user>().SelectByConditions(conditions);
        }
    }


