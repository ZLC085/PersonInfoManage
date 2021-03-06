﻿using System.Collections.Generic;
using System.Linq;
using PersonInfoManage.DAL.System;
using PersonInfoManage.Model;
using PersonInfoManage.BLL.Utils;
using System;
using PersonInfoManage.DAL.Logs;

namespace PersonInfoManage.BLL.System
{
    public class SysUserBLL
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>影响行数</returns>
        public Result add(sys_user user)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            Result res = new Result();
            try
            {
                if (Sysuser.Add(user) == 0)
                {
                    res.Code = RES.ERROR;
                    res.Message = "添加失败！";
                    return res;
                }
                else
                {
                    res.Code = RES.OK;
                    res.Message = "添加成功！";
                    return res;
                }
            }
            catch
            { 
                res.Code = RES.ERROR;
                res.Message = "添加失败！";
                return res;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>影响行数</returns>
        public Result Update(sys_user user,int userid)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            Result res = new Result();
            try
            {
                if (Sysuser.Update(user,userid) == 0)
                {
                    res.Code = RES.ERROR;
                    res.Message = "添加失败！";
                    return res;
                }
                else
                {
                    res.Code = RES.OK;
                    res.Message = "添加成功！";
                    return res;
                }
            }
            catch
            {
                res.Code = RES.ERROR;
                res.Message = "添加失败！";
                return res;
            }
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>影响行数</returns>
        public Result RePassword(List<int> userid)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            Result res = new Result();
            int re = 0;
            try
            {
                foreach (var userId in userid)
                {
                    re += Sysuser.RePassword(userId);
                }
                if (re == 0)
                {
                    res.Code = RES.ERROR;
                    res.Message = "修改失败！";
                    return res;
                }
                else
                {
                    res.Code = RES.OK;
                    res.Message = "修改成功！";
                    return res;
                }
            }
            catch
            {
                res.Code = RES.ERROR;
                res.Message = "修改失败！";
                return res;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <returns>影响行数</returns>
        public Result Del(List<int> user_id)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            Result res = new Result();
            int re = 0;
            try
            {
                foreach (var userId in user_id)
                {
                    re += Sysuser.Del(userId);
                }
                if (re == 0)
                {
                    res.Code = RES.ERROR;
                    res.Message = "修改失败！";
                    return res;
                }
                else
                {
                    res.Code = RES.OK;
                    res.Message = "删除成功！";
                    return res;
                }
            }
            catch
            {
                res.Code = RES.ERROR;
                res.Message = "删除失败！";
                return res;
            }
        }


        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户信息</returns>
        public List<view_sys_u2g> SelectAll()
        {
            SysUserDAL Sysuser = new SysUserDAL();
            return Sysuser.SelectAll();
        }

        /// <summary>
        /// 条件查询用户
        /// </summary>
        /// <param name="UserInfo">查询条件</param>
        /// <returns>用户信息</returns>
        public List<view_sys_u2g> Select(sys_user UserInfo)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            return Sysuser.Select(UserInfo);
        }

        /// <summary>
        /// 通过用户id查询用户
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <returns>用户信息</returns>
        public List<view_sys_u2g> SelectById(int UserId)
        {
            SysUserDAL Sysuser = new SysUserDAL();
            return Sysuser.SelectById(UserId);
        }
    }
}
