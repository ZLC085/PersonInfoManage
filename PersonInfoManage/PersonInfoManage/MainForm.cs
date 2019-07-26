﻿using PersonInfoManage.BLL.Cost;
using PersonInfoManage.BLL.Logs;
using PersonInfoManage.BLL.System;
using PersonInfoManage.BLL.Utils;
using PersonInfoManage.DAL.PersonInfo;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonInfoManage
{
   
    public partial class MainForm : Form
    {
        private List<view_sys_u2g> UserInfo = new SysUserBLL().SelectAll();
        private List<sys_group> GroupInfo;
        private List<int> UserId;
        public MainForm()
        {
            InitializeComponent();
            //dgvPerson.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 1000;
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Start();
            metroShell1.SelectedTab = MenuHome;
            //List<cost> costs = ShowMessage();
            //if (costs.Count == 0)
            //{
            //    this.PnlMessage.Visible = false;
            //}
            //else
            //{
            //    this.LblMessageCount.Text = costs.Count.ToString();
            //}

        }
        #region 王继能
        //<王继能_1>
        //
        //</王继能_1>
        #endregion

        #region 毛宇航
        //<毛宇航_1>
        private void BtnAddPerson_Click(object sender, EventArgs e)
        {
            PersonBasicForm personBasicForm = new PersonBasicForm();
            personBasicForm.Text = "人员信息录入";
            personBasicForm.ShowDialog();
        }

        private void BtnQueryPerson_Click(object sender, EventArgs e)
        {
            PersonDetailForm personDetailForm = new PersonDetailForm(1);
            personDetailForm.ShowDialog();
            for (int i = 0; i < dgvPerson.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)dgvPerson.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(check.Value);
                if (flag == true)
                {
                    string indentity = this.dgvPerson.Rows[i].Cells[2].Value.ToString();
                }
            }
           
        }

        private void BtnUpdatePerson_Click(object sender, EventArgs e)
        {
            PersonBasicForm personBasicForm = new PersonBasicForm();
            personBasicForm.Text = "人员信息修改";
            personBasicForm.ShowDialog();
        }

        private void BtnDelPerson_Click(object sender, EventArgs e)
        {

        }
        
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {

        }

        private void BtnRecycle_Click(object sender, EventArgs e)
        {

        }


        private void BtnComdelPerson_Click(object sender, EventArgs e)
        {

        }
        //</毛宇航_1>
        #endregion 毛宇航

        #region 李鸽鸽
        //<李鸽鸽_1>
        //
        //</李鸽鸽_1>
        #endregion

        #region 坤吉心
        //<坤吉心_1>
        private void BtnDelUserlog_Click(object sender, EventArgs e)
        {

        }
        
        private void BtnSearchUserlog_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelSyslog_Click(object sender, EventArgs e)
        {

        }
        
        private void BtnSearchSyslog_Click(object sender, EventArgs e)
        {

        }
        //</坤吉心_1>
        #endregion

        #region 苏文杰
        //<苏文杰_2>
        //首页timer控件tick事件
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lableTime.Text = DateTime.Now.ToString("yyyy年MM月dd日-HH:mm:ss");
        }

        //首页退出按钮点击事件
        private void BtnEsc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出系统吗？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 消息提示方法
        /// </summary>
        /// <returns></returns>
        //private List<cost> ShowMessage()
        //{
        //    String localUser = LocalUserInfo.LoginInfo.UserName;
        //    CostApprovalBLL costApprovalBLL = new CostApprovalBLL();
        //    Dictionary<string, object> conditions = new Dictionary<string, object>();
        //    conditions.Add(nameof(cost_main.approver), localUser);
        //    conditions.Add(nameof(cost_main.status), 0);
        //    return costApprovalBLL.Query(conditions);
        //}

        //消息框"下次再说"linklable
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.PnlMessage.Visible = false;
        }

        //消息框"点击查看"linklable
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            metroShell1.SelectedTab = MenuCost;
            TabControlCost.SelectedTab = TabCostAudit;
        }

        //主页切换事件

        private void MenuHome_Click(object sender, EventArgs e)
        {
            //List<cost> costs = ShowMessage();
            //if (costs.Count == 0)
            //{
            //    this.PnlMessage.Visible = false;
            //}
            //else
            //{
            //    this.LblMessageCount.Text = costs.Count.ToString();
            //}
        }

        //基本信息管理Tab页点击事件（二级）
        private void TabPersonBasic_Click(object sender, EventArgs e)
        {
            dgvPerson.AutoGenerateColumns = false;
            int localUserid = UserInfoBLL.UserId;
            dgvPerson.DataSource = new PersonBasicDAL().Query(new person_basic { user_id = localUserid,isdel=1});
        }
        //人员信息管理菜单Tab页切换事件（一级）
        private void MenuPersoninfo_Click(object sender, EventArgs e)
        {
            TabControlPerson.SelectedTab = TabPersonBasic;
            dgvPerson.AutoGenerateColumns = false;
            int localUserid = UserInfoBLL.UserId;
            dgvPerson.DataSource = new PersonBasicDAL().Query(new person_basic { user_id = localUserid,isdel=0 });
        }

        //回收站Tab页点击事件（二级）
        private void TabPersonRecycle_Click(object sender, EventArgs e)
        {
            DgvRecycle.AutoGenerateColumns = false;
            person_basic person = new person_basic();
            person.isdel = 1;
            DgvRecycle.DataSource = new PersonBasicDAL().Query(person);
        }

        //日志管理菜单Tab页切换事件（一级）
        
        private void MenuLog_Click(object sender, EventArgs e)
        {
            TabControlLog.SelectedTab = TabUserLog;
            DgvUserLog.AutoGenerateColumns = false;
            DgvUserLog.DataSource = new LogUserBLL().Query();
        }

        //用户日志Tab页点击事件（二级）
        private void TabUserLog_Click(object sender, EventArgs e)
        {
            DgvUserLog.AutoGenerateColumns = false;
            DgvUserLog.DataSource = new LogUserBLL().Query();
        }

        //系统日志Tab页点击事件（二级）
        private void TabSysLog_Click(object sender, EventArgs e)
        {
            DgvSysLog.AutoGenerateColumns = false;
            DgvSysLog.DataSource = new LogSysBLL().Query();
        }

        //费用管理菜单Tab页切换事件（一级）
        private void MenuCost_Click(object sender, EventArgs e)
        {
            TabControlCost.SelectedTab = TabCostApply;
            DgvCostApply.AutoGenerateColumns = false;
            //获取本地用户id
            int localUserId = UserInfoBLL.UserId;
            Dictionary<string,object> dic = new Dictionary<string, object>();
            dic.Add(nameof(cost_main.apply_id), localUserId);
            DgvCostApply.DataSource = new CostApplyBLL().Query(dic);
        }

        //费用申请Tab页点击事件（二级）
        private void TabCostApply_Click(object sender, EventArgs e)
        {
            DgvCostApply.AutoGenerateColumns = false;
            //获取本地用户id
            int localUserId = UserInfoBLL.UserId;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(nameof(cost_main.apply_id), localUserId);
            DgvCostApply.DataSource = new CostApplyBLL().Query(dic);
        }

        //费用审批Tab页点击事件（二级）
        private void TabCostAudit_Click(object sender, EventArgs e)
        {
            DgvCostApprove.AutoGenerateColumns = false;
            //获取本地用户id
            int localUserId = UserInfoBLL.UserId;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(nameof(cost_approval.approval_id), localUserId);
            DgvCostApprove.DataSource = new CostApprovalBLL().Query(dic);
        }

        //费用规划Tab页点击事件（二级）
        private void TabCostPlan_Click(object sender, EventArgs e)
        {
            DgvCostPlan.AutoGenerateColumns = false;
            Dictionary<string, object> dic = new Dictionary<string, object>();
            DgvCostPlan.DataSource = new CostPlanBLL().Query(dic);
        }
        
        //系统设置菜单Tab页切换事件（一级）
        private void MenuSys_Click(object sender, EventArgs e)
        {
            TabControlSys.SelectedTab = TabUserMan;
            DgvUserMan.AutoGenerateColumns = false;
            DgvUserMan.DataSource = new SysUserBLL().Select(new sys_user());
        }

        //用户管理Tab页点击事件(二级)
        private void TabUserMan_Click(object sender, EventArgs e)
        {
            DgvUserMan.AutoGenerateColumns = false;
            DgvUserMan.DataSource = new SysUserBLL().Select(new sys_user());
        }

        //用户组管理Tab页点击事件（二级）
        private void TabGroupMan_Click(object sender, EventArgs e)
        {
            DgvGroupMan.AutoGenerateColumns = false;
            //DgvGroupMan.DataSource = new PermBLL().SelectGroup(new sys_group());
        }

        //系统设置Tab页点击事件（二级）
        private void TabSysSet_Click(object sender, EventArgs e)
        {
            DgvSysSet.AutoGenerateColumns = false;
            var ds = new SysSettingBLL().SeleteAll();
            foreach (var item in ds)
            {
                if (item.dict_name.Equals(sys_dict_type.Cost.ToString()))
                {
                    item.dict_name = "费用类别";
                }
                else if (item.dict_name.Equals(sys_dict_type.Person.ToString()))
                {
                    item.dict_name = "重点人员类别";
                }
                //else if (item.dict_name.Equals(sys_dict_type.NativePlace.ToString()))
                {
                    item.dict_name = "归属地";
                }
            }
            DgvSysSet.DataSource = ds;
        }


        private void MenuOperation_Click(object sender, EventArgs e)
        {

        }
        //</苏文杰_2>
        #endregion

        #region 王尔沛
        //<王尔沛_2>
        private List<int> selectid()
        {
            UserId = new List<int>();
            for (int i = 0; i < DgvUserMan.Rows.Count; i++)
            {
                if (Convert.ToBoolean(DgvUserMan.Rows[i].Cells["Column36"].Value))
                {
                    int id = int.Parse(DgvUserMan.Rows[i].Cells["user_id"].Value.ToString());
                    UserId.Add(id);
                }
            }
            return UserId;
        }
        private void DgvUserMan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.DgvUserMan.IsCurrentCellDirty) //有未提交的更改
            {
                this.DgvUserMan.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();
        }

        private void BtnQueryUser_Click(object sender, EventArgs e)
        {
            UserDetailForm userDetailForm = new UserDetailForm(selectid());
            userDetailForm.ShowDialog();
        }
        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            UpdateUserForm UpdateUserForm = new UpdateUserForm(selectid());
            UpdateUserForm.ShowDialog();
        }
        private void BtnGroupManage_Click(object sender, EventArgs e)
        {
            GroupManageForm groupManageForm = new GroupManageForm();
            groupManageForm.ShowDialog();
        }
        private void BtnRoleManage_Click(object sender, EventArgs e)
        {
            GroupRoleManageForm groupRoleManageForm = new GroupRoleManageForm();
            groupRoleManageForm.ShowDialog();
       }
       private void BtnResetPsw_Click(object sender, EventArgs e)
        {
            if (selectid() == null)
            {
                MessageBox.Show("请勾选用户");
            }
            else
            {
                DialogResult = MessageBoxCustom.Show("确认重置？", "操作确认", MessageBoxButtons.YesNo, this);
                if (DialogResult == DialogResult.Yes)
                {
                    new SysUserBLL().RePassword(selectid());
                    DgvUserMan.DataSource = null;
                    DgvUserMan.DataSource = new SysUserBLL().Select(new sys_user());
                }
            }
        }
        private void BtnDelUser_Click(object sender, EventArgs e)
        {
            if (selectid() == null)
            {
                MessageBox.Show("请勾选用户");
            }
            else
            {
                DialogResult = MessageBoxCustom.Show("确认删除？", "操作确认", MessageBoxButtons.YesNo, this);
                if (DialogResult == DialogResult.Yes)
                {
                    new SysUserBLL().Del(selectid());
                    DgvUserMan.DataSource = null;
                    DgvUserMan.DataSource = new SysUserBLL().Select(new sys_user());
                }
            }
        }
        private void BtnSearchUser_Click(object sender, EventArgs e)
        {
            sys_user user = new sys_user();
            user.name = TxtUserName.Text;
            user.username = TxtLoginName.Text;
            user.gender = CmbUserSex.Text;
            user.job = TxtUserJob.Text;
            DgvUserMan.DataSource = null;
            DgvUserMan.DataSource = new SysUserBLL().Select(user);
        }
        //</王尔沛_2>
        #endregion

        #region 曾丽川
        //<曾丽川_2>
        private void BtnAddRole_Click(object sender, EventArgs e)
        {
            AddUserGroupForm addUserGroupForm = new AddUserGroupForm();
            addUserGroupForm.ShowDialog();
        }

        private void BtnUpdateRole_Click(object sender, EventArgs e)
        {
            AddUserGroupForm addUserGroupForm = new AddUserGroupForm();
            addUserGroupForm.Text = "修改用户组";
            addUserGroupForm.ShowDialog();
        }

        private void BtnAddKind_Click(object sender, EventArgs e)
        {
            AddCategoreTypeForm addCategoreTypeForm = new AddCategoreTypeForm();
            addCategoreTypeForm.ShowDialog();
        }

        private void BtnUpdateKind_Click(object sender, EventArgs e)
        {
            AddCategoreTypeForm addCategoreTypeForm = new AddCategoreTypeForm();
            addCategoreTypeForm.Text = "修改数据字典";
            addCategoreTypeForm.ShowDialog();
        }


        private void BtnDelGroup_Click(object sender, EventArgs e)
        {

        }

        private void BtnsearchGroup_Click(object sender, EventArgs e)
        {

        }


        private void BtnDelType_Click(object sender, EventArgs e)
        {

        }

        //数据字典下拉框选择事件
        private void CmbDictType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //</曾丽川_2>
        #endregion

        #region 张乐
        //<张乐_3>
        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {

        }


        private void BtnBusinessDetail_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelBusiness_Click(object sender, EventArgs e)
        {

        }
        private void BtnApproveBus_Click(object sender, EventArgs e)
        {

        }
        //</张乐_3>
        #endregion

        #region 陈波
        //<陈波_3>
        //
        private void BtnAddCost_Click(object sender, EventArgs e)
        {
            CostApplyForm costApplyForm = new CostApplyForm();
            costApplyForm.ShowDialog();
        }

        private void BtnQueryCost_Click(object sender, EventArgs e)
        {
            CostApplyDetailForm costApplyDetailForm = new CostApplyDetailForm();
            costApplyDetailForm.ShowDialog();
        }

        private void BtnUpdateCost_Click(object sender, EventArgs e)
        {
            CostApplyForm costApplyForm = new CostApplyForm();
            costApplyForm.Text = "费用单修改";
            costApplyForm.ShowDialog();
        }

        private void BtnQueryAudit_Click(object sender, EventArgs e)
        {
            CostApplyDetailForm costApplyDetailForm = new CostApplyDetailForm();
            costApplyDetailForm.ShowDialog();
        }

        private void BtnAudit_Click(object sender, EventArgs e)
        {
            CostApprovalForm costApprovalForm = new CostApprovalForm();
            costApprovalForm.ShowDialog();
        }


        private void BtnRepealCost_Click(object sender, EventArgs e)
        {

        }


        private void BtnSearchCostApply_Click(object sender, EventArgs e)
        {

        }


        private void BtnDelApprove_Click(object sender, EventArgs e)
        {

        }


        private void BtnSearchApprove_Click(object sender, EventArgs e)
        {

        }
        
        private void BtnSearchBus1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearchBus2_Click(object sender, EventArgs e)
        {

        }
        //</陈波_3>
        #endregion

        #region 蒋媛
        //<蒋媛_3>
        private void BtnUpdatePlan_Click(object sender, EventArgs e)
        {
            CostPlanForm costPlanForm = new CostPlanForm();
            costPlanForm.Text = "修改费用规划";
            costPlanForm.ShowDialog();
        }

        private void BtnPlanCost_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCheckStats_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelCostPlan_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddCostPlan_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdateCostPlan_Click(object sender, EventArgs e)
        {

        }
        //</蒋媛_3>
        #endregion
    }
}
