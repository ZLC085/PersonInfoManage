﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInfoManage.DAL.System;
using PersonInfoManage.Model;


namespace PersonInfoManage.BLL.System
{
    class PermBLL
    {
        /// <summary>
        /// 添加用户组
        /// </summary>
        /// <param name="group"></param>
        /// <returns>影响条数</returns>
        public bool add(sys_group group)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.add(group);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 添加用户组和用户关联
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="group_id"></param>
        /// <returns>影响条数</returns>
        public bool add(int user_id,int group_id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.add(user_id, group_id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用户组权限修改
        /// </summary>
        /// <param name="group_id">用户组id</param>
        /// <param name="menu_id">菜单id</param>
        /// <returns>修改条数</returns>
        public bool Updateg2m(int group_id,int menu_id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.Updateg2m(group_id, menu_id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用户所在用户组修改
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <param name="group_id">用户组id</param>
        /// <returns>修改条数</returns>
        public bool Updateu2g(int user_id, int group_id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.Updateg2m(user_id, group_id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 用户组修改
        /// </summary>
        /// <param name="user_id">用户id</param>
        /// <param name="group_id">用户组id</param>
        /// <returns>修改条数</returns>
        public bool Update(sys_group group)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.Update(group);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id"></param>
        /// <returns>影响条数</returns>
        public bool Del(int id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.Del(id);
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 删除用户组和权限关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns>影响条数</returns>
        public bool DelG2m(int id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.DelG2m(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除用户组和用户关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns>影响条数</returns>
        public bool Delu2g(int id)
        {
            PermDAL perm = new PermDAL();
            try
            {
                perm.Delu2g(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 查询用户组
        /// </summary>
        /// <param name="group">查询条件</param>
        /// <returns>用户组信息</returns>
        public List<sys_group> Selectgroup(sys_group group)
        {
            PermDAL perm = new PermDAL();
            return perm.Selectgroup(group);

        }







    }
}
