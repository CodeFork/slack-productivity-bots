﻿using Newtonsoft.Json;
using Promact.Core.Repository.LeaveRequestRepository;
using Promact.Core.Repository.ProjectUserCall;
using Promact.Erp.DomainModel.ApplicationClass;
using Promact.Erp.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promact.Core.Repository.SlackRepository
{
    public class SlackRepository : ISlackRepository
    {
        private readonly IProjectUserCallRepository _projectUser;
        private readonly ILeaveRequestRepository _leaveRepository;
        string replyText = "";
        public SlackRepository(ILeaveRequestRepository leaveRepository, IProjectUserCallRepository projectUser)
        {
            _projectUser = projectUser;
            _leaveRepository = leaveRepository;
        }
        public LeaveRequest LeaveApply(List<string> slackRequest, string userName)
        {
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.Reason = slackRequest[1];
            leaveRequest.FromDate = Convert.ToDateTime(slackRequest[2]);
            leaveRequest.EndDate = Convert.ToDateTime(slackRequest[3]);
            leaveRequest.Type = slackRequest[4];
            leaveRequest.RejoinDate = Convert.ToDateTime(slackRequest[5]);
            leaveRequest.Status = Condition.Pending;
            leaveRequest.EmployeeId = _projectUser.GetUserByUsername(userName).Id;
            leaveRequest.CreatedOn = DateTime.UtcNow;
            _leaveRepository.ApplyLeave(leaveRequest);
            return leaveRequest;
        }
        public string LeaveList(string userName)
        {
            var userId = _projectUser.GetUserByUsername(userName).Id;
            var leaveList = _leaveRepository.LeaveListByUserId(userId);
            foreach (var leave in leaveList)
            {
                replyText += string.Format("{0} {1} {2} {3} {4}", leave.Id + ",", leave.Reason + ",", leave.FromDate.ToShortDateString() + ",", leave.EndDate.ToShortDateString() + ",", leave.Status + System.Environment.NewLine);
            }
            return replyText;
        }
        public string CancelLeave(int leaveId, string userName)
        {
            var userId = _projectUser.GetUserByUsername(userName).Id;
            if (userId == _leaveRepository.LeaveById(leaveId).EmployeeId)
            {
                var leave = _leaveRepository.CancelLeave(leaveId);
                replyText = "Your leave Id no: " + leave.Id + " From " + leave.FromDate.ToShortDateString() + " To " + leave.EndDate.ToShortDateString() + " has been " + leave.Status;
            }
            else
            {
                replyText = "You are trying with wrong which not belong to you";
            }
            return replyText;
        }
        public string LeaveStatus(string userName)
        {
            var userId = _projectUser.GetUserByUsername(userName).Id;
            var leave = _leaveRepository.LeaveListStatusByUserId(userId);
            replyText = "Your leave Id no: " + leave.Id + " From " + leave.FromDate.ToShortDateString() + " To " + leave.EndDate.ToShortDateString() + " for " + leave.Reason + " is " + leave.Status;
            return replyText;
        }
        public string ChatPostAttachment(string text)
        {
            List<SlashAttachmentAction> ActionList = new List<SlashAttachmentAction>();
            List<SlashAttachment> attachmentList = new List<SlashAttachment>();
            SlashAttachment attachment = new SlashAttachment();
            SlashAttachmentAction Approved = new SlashAttachmentAction()
            {
                name = "Approved",
                text = "Approved",
                type = "button",
                value = "approved",
            };
            ActionList.Add(Approved);
            SlashAttachmentAction Rejected = new SlashAttachmentAction()
            {
                name = "Rejected",
                text = "Rejected",
                type = "button",
                value = "Rejected",
            };
            ActionList.Add(Rejected);
            attachment.fallback = "Leave Applied";
            attachment.title = "Leave Applied";
            attachment.callback_id = "promactLMS";
            attachment.color = "#3AA3E3";
            attachment.attachment_type = "default";
            attachment.actions = ActionList;
            attachmentList.Add(attachment);
            attachment.title = text;
            var attachments = JsonConvert.SerializeObject(attachmentList);
            return attachments;
        }
        public List<SlashAttachment> SlackResponseAttachment(string leaveRequestId, string replyText)
        {
            List<SlashAttachmentAction> ActionList = new List<SlashAttachmentAction>();
            List<SlashAttachment> attachment = new List<SlashAttachment>();
            SlashAttachment attachmentList = new SlashAttachment();
            SlashAttachmentAction Approved = new SlashAttachmentAction()
            {
                name = "Approved",
                text = "Approved",
                type = "button",
                value = "approved",
            };
            ActionList.Add(Approved);
            SlashAttachmentAction Rejected = new SlashAttachmentAction()
            {
                name = "Rejected",
                text = "Rejected",
                type = "button",
                value = "Rejected",
            };
            ActionList.Add(Rejected);
            attachmentList.actions = ActionList;
            attachmentList.fallback = "Leave Applied";
            attachmentList.title = replyText;
            attachmentList.callback_id = leaveRequestId;
            attachmentList.color = "#3AA3E3";
            attachmentList.attachment_type = "default";
            attachment.Add(attachmentList);
            return attachment;
        }
        public LeaveRequest UpdateLeave(int leaveId, string status)
        {
            var leave = _leaveRepository.LeaveById(leaveId);
            if (status == "approved")
            {
                leave.Status = Condition.Approved;
            }
            else
            {
                leave.Status = Condition.Rejected;
            }
            if (leave.Status == Condition.Pending)
            {
                _leaveRepository.UpdateLeave(leave);
            }
            return leave;
        }
    }
}
