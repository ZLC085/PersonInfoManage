﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInfoManage.BLL.Utils;
using PersonInfoManage.DAL.Cost;
using PersonInfoManage.Model;

namespace PersonInfoManage.BLL.Cost
{
    public class CostApplyBLL
    {
        /// <summary>
        /// 添加费用单
        /// </summary>
        /// <param name="cost">费用单主表对象 Main：apply_id、apply_money、status、apply_time、remark 
        /// 费用单审批详情列表 ApprovalList:approval_id
        /// 费用详情列表 DetailList：cost_type、money</param> 
        /// <returns>添加是否成功</returns>
        public Result Add(cost cost)
        {
            cost_main Main = cost.Main;
            List<cost_detail> DetailList = cost.DetailList;
            Result res = new Result()
            {
                Code = RES.ERROR,
                Message = "添加失败！"
            };
            if (Main == null || DetailList == null || DetailList.Count == 0)
            {
                return res;
            }
            int rows = new CostApplyDAL().Add(cost);
            if(rows == 2 + DetailList.Count)
            {
                res.Code = RES.OK;
                res.Message="添加成功！";
            }
            return res;
        }
        /// <summary>
        /// 更新费用单信息
        /// </summary>
        /// <param name="cost">费用单主表对象 Main：id、apply_money、remark 
        /// 费用单审批详情列表 ApprovalList:
        /// 费用详情列表 DetailList：cost_type、cost_type_name、money</param>
        /// <returns>更新是否成功</returns>
        public Result Update(cost cost)
        {
            cost_main main = cost.Main;
            List<cost_detail> listDeatil = cost.DetailList;
            Result res = new Result()
            {
                Code = RES.ERROR,
                Message = "更新失败！"
            };
            if (main == null || listDeatil == null || listDeatil.Count == 0)
            {
                return res;
            }
            CostApplyDAL apply = new CostApplyDAL();
            //获取该费用单的审批状态
            byte status = apply.QueryMain(new Dictionary<string, object>
            {
                {"id",main.id }
            }).First().status;
            //如果费用单不是未审批状态，则更新信息失败
            if (status != 0)
            {
                return res;
            }
            //先获取未更新时费用详情记录数           
            int originDetailCount = apply.QueryDetail(main.id).Count;
            //再更新费用单
            int rows = apply.Update(cost);
            if (rows == 1 + originDetailCount + listDeatil.Count)
            {
                res.Code = RES.OK;
                res.Message = "更新成功！";
            }
            return res;
        }
        /// <summary>
        /// 删除费用单信息
        /// </summary>
        /// <param name="id">费用单id</param>
        /// <returns>删除是否成功</returns>
        public Result Del(int id)
        {
            Result res = new Result()
            {
                Code = RES.ERROR,
                Message = "删除失败"
            };
            CostApplyDAL apply = new CostApplyDAL();
            //获取该费用单的审批状态
            byte status = apply.QueryMain(new Dictionary<string, object>
            {
                {"id",id }
            }).First().status;
            //如果费用单不是未审批状态，则删除失败
            if (status != 0)
            {
                return res;
            }
            List<cost_detail> listDetail = apply.QueryDetail(id);
            List<cost_approval> ListApproval = apply.QueryApproval(id);
            if (apply.Del(id) ==ListApproval.Count+ listDetail.Count + 1)
            {
                res.Code = RES.OK;
                res.Message = "删除成功！";
            }
            return res;
        }
        /// <summary>
        /// 根据组合条件查询费用单（可分页）
        /// </summary>
        /// <param name="consitions">条件键值对key: "id", "apply_id", "status", "start_time", "end_time","page","limit"</param>
        /// <returns>费用单列表</returns>
        public List<cost> Query(Dictionary<string,object> conditions)
        {
            return new CostApprovaDAL().Query(conditions);
        }
        /// <summary>
        /// 费用类型列表
        /// </summary>
        public List<string> CostTypes
        {
            get
            {
                return new CostApplyDAL().GetCostTypes();
            }
        }
        /// <summary>
        /// 获取审批人列表
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public List<string> ApproverInfo(int apply_id)
        {
            return new CostApplyDAL().GetApprovalInfo(apply_id);
        }
    }
}
