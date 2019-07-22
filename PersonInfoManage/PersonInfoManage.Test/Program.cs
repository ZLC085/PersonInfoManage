﻿using PersonInfoManage.DAL.Logs;
using PersonInfoManage.DAL.PersonInfo;
using PersonInfoManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInfoManage.DAL.Cost;
using PersonInfoManage.BLL.System;
using PersonInfoManage.DAL.System;

namespace PersonInfoManage.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试函数-数据字典bll 
            //SysSettingBLL set = new SysSettingBLL();
            //sys_dict SysDict = new sys_dict();
            //SysDict.category_name = "其他4";
            //SysDict.dict_name = "费用类别";
            //Console.WriteLine(set.Add(SysDict));

            //测试set.Update(SysDict)
            //SysSettingBLL set = new SysSettingBLL();
            //sys_dict SysDict = new sys_dict();
            //SysDict.category_name = "其他3";
            //SysDict.dict_name = "费用类别";
            //SysDict.id = 13;
            //Console.WriteLine(set.Update(SysDict));

            //测试set.Del(id)
            //SysSettingBLL set = new SysSettingBLL();
            //sys_dict SysDict = new sys_dict();
            //int id = 13;
            //Console.WriteLine(set.Del(id));

            //测试
            //SysSettingBLL set = new SysSettingBLL();
            //Console.WriteLine(set.SeleteAll());
            //List<sys_dict> list = set.SeleteAll();
            //foreach (sys_dict a in list)
            //{
            //    Console.WriteLine(a.category_name + "  " + a.dict_name + "  " + a.create_time + "  " + a.modify_time);
            //}


            //测试函数：login.Login(user)  测试成功BLL
            //LoginBLL login = new LoginBLL();
            //string userName = "lihua";
            //string password = "456";
            //Console.WriteLine(login.Login(userName,password));

            //测试函数：perm.Add(group)  测试成功BLL
            //PermBLL perm = new PermBLL();
            //sys_group group = new sys_group();
            //group.group_name = "员工";
            //group.remark = "民警";
            //Console.WriteLine(perm.Add(group));

            //测试函数：perm.Addu2g(groupId,userId)  测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 26;
            //int userId = 32;
            //Console.WriteLine(perm.Addu2g(groupId,userId));

            //测试函数：perm.Addg2m(groupId,menuId)  测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 26;
            //int menuId = 4;
            //Console.WriteLine(perm.Addg2m(groupId, menuId));

            //测试函数：perm.Updateu2g(groupId,userId)  测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 23;
            //int userId = 32;
            //Console.WriteLine(perm.Updateu2g(groupId, userId));

            //测试函数:perm.Update(group) 测试成功BLL
            //PermBLL perm = new PermBLL();
            //sys_group group = new sys_group();
            //group.id = 26;
            //group.group_name = "普通用户";
            //group.remark = "实习民警";
            //Console.WriteLine(perm.Update(group));

            //测试函数：perm.Updateg2m(groupId,menuId)  测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 23;
            //int menuId = 5;
            //Console.WriteLine(perm.Updateg2m(groupId, menuId));

            //测试函数：perm.Del(groupId) 测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 25;
            //Console.WriteLine(perm.Del(groupId));

            //测试函数：perm.DelG2m(groupId) 测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 23;
            //int menuId = 6;
            //Console.WriteLine(perm.DelG2m(groupId,menuId));

            //测试函数：perm.DelG2u(groupId) 测试成功BLL
            //PermBLL perm = new PermBLL();
            //int groupId = 23;
            //int userId = 32;
            //Console.WriteLine(perm.DelG2u(groupId, userId));

            //测试函数：perm.Selectall() 测试成功
            //PermBLL perm = new PermBLL();
            //sys_group group = new sys_group();
            //group.group_name = "admin";
            //Console.WriteLine(perm.SelectGroup(group));

            //测试函数：perm.Selectu2g() 测试成功
            //PermBLL perm = new PermBLL();
            //int groupId = 15;
            //Console.WriteLine(perm.Selectu2g(groupId));

            //测试函数：perm.Selectg2m() 测试成功
            //PermBLL perm = new PermBLL();
            //int groupId = 15;
            //Console.WriteLine(perm.Selectg2m(groupId));

            //测试函数：per.
            //PermBLL perm = new PermBLL();
            //sys_group group = new sys_group();
            //group.group_name = "普通用户";
            //DateTime a = new DateTime(2011, 1, 1, 0, 0, 0);
            //group.create_time = a;
            //group.modify_time = new DateTime(2022, 1, 1, 1, 1, 1);
            //List<sys_group> list1 = perm.SelectGroup(group);
            //foreach (sys_group b in list1)
            //{
            //    Console.WriteLine(b.group_name + "" + b.remark + "" + b.create_time + "" + b.modify_time);
            //}


            //PermDAL perm = new PermDAL();
            //sys_group group = new sys_group();
            //group.group_name = "普通用户";
            //DateTime a = new DateTime(2011, 1, 1, 0, 0, 0);
            //group.create_time = a;
            //group.modify_time = new DateTime(2022, 1, 1, 1, 1, 1);
            //List<sys_group> list1 = perm.Selectgroup(group);
            //foreach (sys_group b in list1)
            //{
            //    Console.WriteLine(b.group_name + "" + b.remark + "" + b.create_time + "" + b.modify_time);
            //}
            // Console.WriteLine(perm.Selectgroup(group));


            //测试函数：SysUser.add(sys_user user,int groupid)  测试成功BLL
            //SysUserBLL userbll = new SysUserBLL();
            //sys_user user = new sys_user();
            //user.username = "xiaoming";
            //user.name = "小明";
            //user.password = "789";
            //user.gender = "男";
            //user.job = "领导";
            //user.phone = "17396226172";
            //user.email = "1258323278@qq.com";
            //user.status = false;
            //Console.WriteLine(userbll.add(user));

            //测试函数：SysUser.Update(sys_user user,int groupid)  测试成功BLL
            //SysUserBLL userbll = new SysUserBLL();
            //sys_user user = new sys_user();
            //user.id = 27;
            //user.username = "lihua";
            //user.name = "李华";
            //user.password = "456";
            //user.gender = "女";
            //user.job = "领导";
            //user.phone = "17396226172";
            //user.email = "873257742@qq.com";
            //user.status = false;
            //Console.WriteLine(userbll.Update(user));

            //测试函数：SysUser.Del(id)  测试成功BLL
            //SysUserBLL userbll = new SysUserBLL();
            //int userId = 39;
            //Console.WriteLine(userbll.Del(userId));

            //测试函数：Sysuser.Select(user, group） 测试成功BLL 
            //SysUserBLL userbll = new SysUserBLL();
            //sys_user user = new sys_user();
            //user.name = "李华";
            //Console.WriteLine(userbll.Select(user));

            //数据字典测试开始
            //测试函数：set.Add(dict)  测试成功 
            //SysSettingDAL set = new SysSettingDAL();
            //sys_dict dict = new sys_dict();
            //dict.dict_name = "费用类别";
            //dict.category_name = "其他3";
            //Console.WriteLine(set.Add(dict));

            //测试函数：set.Update(dict)  测试成功 
            //SysSettingDAL set = new SysSettingDAL();
            //sys_dict dict = new sys_dict();
            //dict.category_name = "其他1";
            //dict.dict_name = "费用类别";
            //dict.id = 12;
            //Console.WriteLine(set.Update(dict));

            //测试函数：set.Del(dict)  测试成功 
            //SysSettingDAL set = new SysSettingDAL();
            //sys_dict dict = new sys_dict();
            //int id = 12;
            //Console.WriteLine(set.Del(id));

            //测试函数：set.SelectAll()  测试成功
            //SysSettingDAL set = new SysSettingDAL();        
            //List<sys_dict> list = set.SelectAll();
            //foreach (sys_dict a in list)
            //{
            //    Console.WriteLine(a.category_name + "  " + a.dict_name + "  " + a.create_time + "  " + a.modify_time);
            //}

            CostApplyDAL apply = new CostApplyDAL();

            ///测试函数：costApply.Add(cost cost)
            ///返回类型：int
            ///测试结果：成功

            //cost_main main = new cost_main
            //{
            //    applicant = "小蒋",
            //    apply_money = 996,
            //    apply_time = DateTime.Now
            //};
            //cost_detail detail = new cost_detail
            //{
            //    cost_type_name = "住宿",
            //    cost_type = 4,
            //    money = 496
            //};
            //cost_detail detail2 = new cost_detail
            //{
            //    cost_type_name = "餐饮",
            //    cost_type = 5,
            //    money = 160
            //};
            //cost_detail detail3 = new cost_detail
            //{
            //    cost_type_name = "出行",
            //    cost_type = 8,
            //    money = 340
            //};
            //List<cost_detail> listDetail = new List<cost_detail>
            //{
            //    detail,
            //    detail2,
            //    detail3
            //};
            //Console.WriteLine(apply.Add(new cost { main = main, DetailList = listDetail }));

            ///测试函数：costApply.Update(cost cost)
            ///返回类型：int
            ///测试结果：成功


            //cost_main main = new cost_main
            //{
            //    id = 1563758936,
            //    apply_money = 900
            //};

            //cost_detail detail = new cost_detail
            //{
            //    cost_type_name = "其他",
            //    cost_type = 7,
            //    money = 500
            //};

            //cost_detail detail2 = new cost_detail
            //{
            //    cost_type_name = "餐饮",
            //    cost_type = 5,
            //    money = 400
            //};

            //List<cost_detail> listDetail = new List<cost_detail>
            //{
            //    detail,
            //    detail2
            //};

            //Console.WriteLine(apply.Update(new cost { main = main, DetailList = listDetail }));



            ///测试函数：costApply.QueryMain(Dictionary<string, object> conditions)
            ///返回类型：
            ///测试结果：成功
            ///参数中必需的属性:


            //Dictionary<string, object> conditions = new Dictionary<string, object>
            //{
            //    //{ "id", 1563517332 },
            //    //{ "applicant", "测试add" },
            //    //{ "status", 1 },
            //    //{ "start_time", new DateTime(2019, 7, 20,19,20,0) },
            //    //{ "end_time", new DateTime(2017, 5, 5) }
            //    {"page",2 },
            //    //{"limit",20 }
            //};
            //List<cost_main> list = apply.QueryMain(conditions);
            //foreach (cost_main cm in list)
            //{
            //    Console.WriteLine(cm.id + "  " + cm.applicant + "  " + cm.approver + "  " + cm.apply_time + "  " + cm.approval_time + "  " + cm.apply_money + "  " + cm.approval_money + "  " + cm.status + "  " + cm.remark);

            //}

            ///测试函数：costApproval.Update(cost_main main)
            ///返回类型：int
            ///测试结果：成功
            ///参数中必需的属性:
            ///     main:approver、approval_time、approval_money、status、id

            //cost_main main = new cost_main
            //{
            //    id = 1563621993,
            //    approver = "小Abor",
            //    approval_time = DateTime.Now,
            //    approval_money = 951,
            //    status = 1
            //};
            //Console.WriteLine(new CostApprovaDAL().Update(main));


            ///测试函数：costPlan.Add(List<cost_plan> listPlan)
            ///返回类型：int
            ///测试结果：成功
            ///参数中必需的属性:
            ///     plan:cost_type、money、start_time、end_time、cost_type_name

            //CostPlanDAL costplan = new CostPlanDAL();
            //cost_plan plan = new cost_plan();
            //plan.cost_type = 3;
            //plan.cost_type_name = "出行";
            //plan.money = 99;
            //plan.start_time = new DateTime(2017, 1, 1);
            //plan.end_time = new DateTime(2017, 2, 1);


            //cost_plan plan2 = new cost_plan();
            //plan2.cost_type = 3;
            //plan2.cost_type_name = "交通";
            //plan2.money = 222;
            //plan2.start_time = new DateTime(2017, 1, 1);
            //plan2.end_time = new DateTime(2017, 3, 1);

            //List<cost_plan> ListPlan = new List<cost_plan>();
            //ListPlan.Add(plan);
            //ListPlan.Add(plan2);

            //Console.WriteLine(costplan.Add(ListPlan));

            ///测试函数：costPlan.Update(List<cost_plan> ListPlan)
            ///返回类型：int
            ///测试结果：成功
            ///参数中必需的属性:
            ///     plan:id、cost_type、money、start_time、end_time、cost_type_name

            //CostPlanDAL costPlan = new CostPlanDAL();
            //cost_plan plan = new cost_plan();
            //plan.cost_type = 3;
            //plan.cost_type_name = "公交";
            //plan.money = 999;
            //plan.start_time = new DateTime(2017, 1, 1);
            //plan.end_time = new DateTime(2017, 2, 1);

            //cost_plan plan2 = new cost_plan();
            //plan2.cost_type = 3;
            //plan2.cost_type_name = "交通";
            //plan2.money = 999;
            //plan2.start_time = new DateTime(2017, 1, 1);
            //plan2.end_time = new DateTime(2017, 3, 1);

            //List<cost_plan> ListPlan = new List<cost_plan>();
            //ListPlan.Add(plan);
            //ListPlan.Add(plan2);

            //Console.WriteLine(costPlan.Update(ListPlan));

            ///测试函数：costPlan.Del(Dictionary<string,DateTime> period )
            ///返回类型：int
            ///测试结果：成功
            ///参数中必需的属性:
            ///     plan:start_time,end_time
            //CostPlanDAL costPlan = new CostPlanDAL();
            //Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
            //dic.Add("start_time",new DateTime(2017,1,1));
            //dic.Add("end_time",new DateTime(2017,3,1));

            //Console.WriteLine(costPlan.Del(dic));


            ///测试函数：costPlan.Query(Dictionary<string, object> conditions)
            ///返回类型：List<cost_plan> 
            ///测试结果：成功
            ///参数中必需的属性:
            ///     conditions：条件键值对词典  key建议是"start_time", "end_time", "cost_type","cost_type_name", "id"其中的，否则无效

            //Dictionary<string, object> conditions = new Dictionary<string, object>();
            //conditions.Add("cost_type", "3");
            //List<cost_plan> listPlan = new CostPlanDAL().Query(conditions);
            //foreach (cost_plan plan in listPlan)
            //{
            //    Console.WriteLine(plan.id + " " + plan.cost_type + " " + plan.cost_type_name + " " + plan.start_time + " " + plan.end_time + " " + plan.money);
            //}

            ///测试函数：CostStastic.Query(Dictionary<string, object> conditions)
            ///返回类型：List<cost>
            ///测试结果：成功
            ///参数中必需的属性:
            ///     conditions：条件键值对词典  key建议是"start_time", "end_time", "applicant"其中的，否则无效

            //Dictionary<string, object> conditions = new Dictionary<string, object>();
            //conditions.Add("applicant", "小明");
            //conditions.Add("start_time", new DateTime(2019, 7, 1));
            //conditions.Add("end_time", new DateTime(2019, 8, 1));
            //List<cost> costlist = new CostStatisticDAL().Query(conditions);
            //foreach (cost cm in costlist)
            //{
            //    Console.WriteLine(cm.main.id + "  " + cm.main.applicant + "  " + cm.main.approver + "  " + cm.main.apply_time + "  " + cm.main.approval_time + "  " + cm.main.apply_money + "  " + cm.main.approval_money + "  " + cm.main.status + "  " + cm.main.remark);
            //    foreach (cost_detail cd in cm.DetailList)
            //    {
            //        Console.WriteLine("\t" + cd.id + "  " + cd.cost_id + "  " + cd.cost_type + " " + cd.cost_type_name + " " + cd.money);
            //    }
            //}

            ///添加文件
            //PersonFileDAL files = new PersonFileDAL();
            //person_file A = new person_file();
            //A.id = 22;
            //A.person_id = 1;
            //A.filename = "张安的XXX";
            //A.filetype = "222";
            //A.create_time = new DateTime(2019, 4, 1);
            //A.modify_time = new DateTime(2018, 1, 18);
            //Console.WriteLine(files.Add(A));


            ////更改文件名

            //PersonFileDAL files = new PersonFileDAL();
            //person_file A = new person_file();
            //A.id = 12;
            //A.filename = "zhao";
            //Console.WriteLine(files.Update(A));


            ////删除文件
            //PersonFileDAL files = new PersonFileDAL();
            //person_file A = new person_file();
            //A.id = 25;
            //Console.WriteLine(files.Del(A));


            //根据ID查询文件
            //PersonFileDAL files = new PersonFileDAL();
            //List<person_file> Listfile = files.GetById(26);
            //foreach (person_file B in Listfile)
            //{
            //    Console.WriteLine(B.id + " " + B.person_id + " " + B.filename + " " + B.file + " " + B.filetype + " " + B.create_time + " " + B.modify_time);

            //}





            // 删除信息，测试
            //根据id删除
            //测试结果：成功
            //LogSysDAL sys = new LogSysDAL();
            //Console.WriteLine(sys.Del(4));//1成功，0失败

            ////日志查询   测试
            //查询所有
            //测试结果：成功
            //LogUserDAL user = new LogUserDAL();
            //List<log_user> listuser = user.Query(18);
            //foreach (log_user loguser in listuser)
            //{
            //    Console.WriteLine(loguser.id + "  " + loguser.user_id + "  " + loguser.username + "  " + loguser.operation + "  " + loguser.ip + "  " + loguser.create_time);
            //}

            //////系统日志查询，所有
            //LogSysDAL sys = new LogSysDAL();
            //List<log_sys> listsys = sys.Query();
            //foreach (log_sys logsys in listsys)
            //{
            //    Console.WriteLine(logsys.id + "  " + logsys.log_message + "  " + logsys.create_time);
            //}
            //////日志查询   测试
            ////根据用户名查询
            ////测试结果：成功
            //LogUser user = new LogUser();
            //List<log_user> listuser = user.GetByUserName("1");
            //foreach (log_user loguser in listuser)
            //{
            //    Console.WriteLine(loguser.id + "  " + loguser.user_id + "  " + loguser.username + "  " + loguser.operation + "  " + loguser.ip + "  " + loguser.create_time);
            //}

            ////日志条件查询
            ////用户名，时间段查询
            ////测试结果：
            //Dictionary<string, object> conditions = new Dictionary<string, object>();
            //conditions.Add("username", "1");
            //conditions.Add("start_time", new DateTime(2017, 1, 1));
            //conditions.Add("end_time", new DateTime(2019, 7, 19));
            //List<log_user> user = new LogUser().GetByConditionns(conditions);
            //foreach (log_user loguser in user)
            //{
            //    Console.WriteLine(loguser.id + "  " + loguser.user_id + "  " + loguser.username + "  " + loguser.operation + "  " + loguser.ip + "  " + loguser.create_time);

            //}


            ////日志条件查询
            ////用户名，时间段查询
            ////测试结果：
            //Dictionary<string, object> conditions = new Dictionary<string, object>();
            //conditions.Add("start_time", new DateTime(2017,7,1));
            //conditions.Add("end_time", new DateTime(2019, 7, 20));
            //List<log_sys> sys = new LogSysDAL().GetByConditionns(conditions);
            //foreach (log_sys logsys in sys)
            //{
            //    Console.WriteLine(logsys.id + " " + logsys.create_time + "  " + logsys.log_message);

            //}

            //PersonBasicDAL PB = new PersonBasicDAL();
            //person_basic pb = new person_basic();

            //pb.name = "赵四";
            //pb.former_name = "尼古拉斯";
            //pb.gender = "男";
            //pb.identity_number = "123456789";
            //pb.birth_date = DateTime.Now;
            //pb.native_place = "四川成都";
            //pb.marry_status = true;
            //pb.job_status = "养猪";
            //pb.income = 2000;
            //pb.temper = "未知";
            //pb.family = "未知";
            //pb.person_type = 1;
            //pb.person_type_name = "未知";
            //pb.qq = "123456789";
            //pb.address = "成都市双流区养猪场";
            //pb.phone = "123456789";
            //pb.belong_place = 1;
            //pb.belong_place_name = "成都市双流区公安局";
            //pb.nation = "汉";
            //pb.input_time = DateTime.Now;
            //pb.user_id = 1001;
            //pb.isdel = 1;

            // 插入
            //if (PB.Add(pb) > 0)
            //{
            //    Console.WriteLine("插入成功！");
            //}
            //else
            //{
            //    Console.WriteLine("插入失败！");
            //}

            // 修改
            //pb.id = 1001;
            //if (PB.Update(pb) > 0)
            //{
            //    Console.WriteLine("修改成功！");
            //}
            //else
            //{
            //    Console.WriteLine("修改失败！");
            //}

            // 移除
            //int id = 1001;
            //if (PB.Remove(id) > 0)
            //{
            //    Console.WriteLine("移除成功！");
            //}
            //else
            //{
            //    Console.WriteLine("移除失败！");
            //}

            // 删除
            //int id = 1002;
            //if (PB.Del(id) > 0)
            //{
            //    Console.WriteLine("删除成功！");
            //}
            //else
            //{
            //    Console.WriteLine("删除失败！");
            //}

            //List<person_basic> list = new List<person_basic>();
            //pb.name = "赵四";
            //pb.identity_number = "123456789";
            //pb.person_type_name = "未知";
            //pb.native_place = "四川成都";

            // 查询
            //list = PB.Query(pb);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i].id + "\t" + list[i].name + "\t" + list[i].former_name + "\t" + list[i].gender + "\t" + list[i].identity_number + "\t"
            //        + list[i].birth_date + "\t" + list[i].native_place + "\t" + list[i].marry_status + "\t" + list[i].job_status + "\t"
            //        + list[i].income + "\t" + list[i].temper + "\t" + list[i].family + "\t" + list[i].person_type + "\t" + list[i].person_type_name + "\t" + list[i].qq + "\t"
            //        + list[i].address + "\t" + list[i].phone + "\t" + list[i].belong_place + "\t" + list[i].belong_place_name + "\t" + list[i].nation + "\t" + list[i].input_time + "\t"
            //        + list[i].user_id + "\t" + list[i].isdel + "\t\n");
            //}

            //NativePlaceDAL NP = new NativePlaceDAL();
            //List<string> list = new List<string>();
            //list = NP.Query("province", null);
            //list = NP.Query("city", "");
            //list = NP.Query("place", "");
            //Console.WriteLine("START...");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i].ToString());
            //}
            //Console.WriteLine("END...");

            Console.ReadKey();
        }
    }
}
