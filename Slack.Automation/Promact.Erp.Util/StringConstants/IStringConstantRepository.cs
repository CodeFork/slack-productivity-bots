﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promact.Erp.Util.StringConstants
{
    public interface IStringConstantRepository
    {

        string EmailSubject { get; }
        string FromDate { get; }
        string EndDate { get; }
        string Reason { get; }
        string Type { get; }
        string Status { get; }
        string ReJoinDate { get; }
        string CreatedOn { get; }
        string WebRequestContentType { get; }
        string DateFormat { get; }
        string ResponseTypeEphemeral { get; }
        string Approved { get; }
        string Button { get; }
        string Rejected { get; }
        string Fallback { get; }
        string Color { get; }
        string AttachmentType { get; }
        string CancelLeaveError { get; }
        string SlackHelpMessage { get; }
        string SlackErrorMessage { get; }

        
        string ProjectDetailsUrl { get; }
        string UsersDetailByGroupUrl { get; }
        string UserDetailsByIdUrl { get; }
        string UserDetailByUserNameUrl { get; }
        string UrlRtmStart { get; }
        string OAuthAuthorizationScopeAndClientId { get; }
        string UserDetailsUrl { get; }
        string TeamLeaderDetailsUrl { get; }
        string ManagementDetailsUrl { get; }
        string OAuthAcessUrl { get; }
        string ProjectDetailsByUserNameUrl { get; }
        string ProjectUsersByTeamLeaderId { get; }
        string ProjectUserDetailsUrl { get; }
        string ProjectTeamLeaderDetailsUrl { get; }
        string ProjectManagementDetailsUrl { get; }
        string UserDetailUrl { get; }
        string LoginUserDetail { get; }
        string ThankYou { get; }
        string InternalError { get; }
        string SlackUserListUrl { get; }
        string SlackChannelListUrl { get; }
        string SlackGroupListUrl { get; }
        string TaskMailBotStatusErrorMessage { get; }
        string TaskMailBotHourErrorMessage { get; }
        string TaskMailDescription { get; }
        string TaskMailHours { get; }
        string TaskMailComment { get; }
        string TaskMailStatus { get; }
        string ScrumTime { get; }
        string ScrumHalt { get; }
        string ScrumHalted { get; }
        string ScrumAlreadyHalted { get; }
        string ScrumResume { get; }
        string Scrum { get; }
        string ScrumResumed { get; }
        string AnswerToday { get; }
        string ScrumNotHalted { get; }
        string ScrumHelp { get; }
        string ScrumHelpMessage { get; }
        string NotAUser { get; }
        string NotAProject { get; }
        string Leave { get; }
        string Later { get; }
        string LeaveError { get; }
        string ResumeScrum { get; }
        string SlackAppAdded { get; }
        string SlackAuthError { get; }
        string SlackAppError { get; }
        string LoggerErrorMessageHomeControllerAuthorizeStatusPage { get; }
        string LoggerErrorMessageOAuthControllerSlackDetailsAdd { get; }
        string PreviousDayStatus { get; }
        string ScrumBotToken { get; }
        string ScrumBotName { get; }
        string LoggerScrumBot { get; }
        string ScrumLaterDone { get; }
        string AlreadyAnswered { get; }
        string NotExpected { get; }
        string ServerClosed { get; }
        string NoQuestion { get; }
        string NoEmployeeFound { get; }
        string WrongPerson { get; }
        string Unrecognized { get; }
        string UserChange { get;}
        string ChannelCreated { get; }
        string ChannelRename { get; }
        string GroupRename { get; }

        string NoProjectFound { get; }
        string ScrumComplete { get; }
        string ScrumNotStarted { get; }
        string ScrumAlreadyConducted { get; }
        string GoodDay { get; }
        string Time { get; }
        string PleaseAnswer { get; }
        string ScrumConcludedButLater { get; }
        string AllAnswerRecorded { get; }
        string NotLaterYet { get; }
        string SendTaskMailConfirmationErrorMessage { get; }
        string RequestToStartTaskMail { get; }
        string AlreadyMailSend { get; }
        string TaskMailSubject { get; }
        string FirstNameForTest { get; }
        string AccessTokenForTest { get; }
        string EmailForTest { get; }
        string StringIdForTest { get; }
        string LastNameForTest { get; }
        string UserDetailsFromOauthServer { get; }
        string SlashCommandText { get; }
        string PromactStringName { get; }
        string FirstQuestionForTest { get; }
        string TeamLeaderDetailsFromOauthServer { get; }
        string CommentAndDescriptionForTest { get; }
        string ManagementDetailsFromOauthServer { get; }
        string TaskMailReport { get; }
        string TaskMailReportTeamLeader { get; }
        string TeamLeaderEmailForTest { get; }
        string ManagementFirstForTest { get; }
        string ManagementEmailForTest { get; }
        string LeaveReasonForTest { get; }
        string LeaveTypeForTest { get; }
        string ChannelId { get; }
        string ChannelName { get; }
        string ChannelAddInstruction { get; }
        string ProjectNotInOAuth { get; }
        string GroupNameStartsWith { get; }
        string OnlyPrivateChannel { get; }
        string ChannelAddSuccess { get; }
        string Add { get; }
        string Channel { get; }
        string Command { get; }
        string ResponseUrl { get; }
        string TeamDomain { get; }
        string TeamId { get; }
        string Text { get; }
        string Token { get; }
        string UserId { get; }
        string UserName { get; }
        string LeaveBot { get; }
        string UnderConstruction { get; }
        string Hello { get; }
        string All { get; }
        string StringHourForTest { get; }
        string AfterLogIn { get; }
        string Home { get; }
        string Index { get; }
        string WebConfig { get; }
        string MailSetting { get; }
        string SlackChatUpdateUrl { get; }
        string ProjectUserUrl { get; }
        string ProjectUrl { get; }
        string UserUrl { get; }
        string OAuthUrl { get; }
        string ClientReturnUrl { get; }
        string LeaveManagementAuthorizationUrl { get; }
        string ChatPostUrl { get; }
        string SlashCommandLeaveListErrorMessage { get; }
        string SlashCommandLeaveCancelErrorMessage { get; }
        string SlashCommandLeaveStatusErrorMessage { get; }
        string Host { get; }
        string Port { get; }
        string TokenEmpty { get; }
        string ErrorMsg { get; }
        string From { get; }
        string Password { get; }
        string EnableSsl { get; }
        string IncomingWebHookUrl { get; }
        string TaskmailAccessToken { get; }
        string SlackOAuthClientId { get; }
        string SlackOAuthClientSecret { get; }
        string PromactOAuthClientId { get; }
        string PromactOAuthClientSecret { get; }
        string LoggerErrorMessageLeaveRequestControllerSlackRequest { get; }
        string LoggerErrorMessageLeaveRequestControllerSlackButtonRequest { get; }
        string LoggerErrorMessageHomeControllerExtrenalLogin { get; }
        string LoggerErrorMessageHomeControllerExtrenalLoginCallBack { get; }
        string LoggerErrorMessageHomeControllerLogoff { get; }
        string LoggerErrorMessageOAuthControllerRefreshToken { get; }
        string LoggerErrorMessageOAuthControllerSlackOAuth { get; }
        string LoggerErrorMessageOAuthControllerSlackEvent { get; }
        string LoggerErrorMessageTaskMailBot { get; }
        string SlackBotStringName { get; }
        string CasualLeaveUrl { get; }
        string CasualLeaveResponse { get; }
        string SlackChannelIdForTest { get; }
        string MessageTsForTest { get; }
        string SorryYouCannotApplyLeave { get; }
        string LeaveListCommandForTest { get; }
        string LeaveCancelCommandForTest { get; }
        string Cancel { get; }
        string FalseStringNameForTest { get; }
        string LeaveNoUserErrorMessage { get; }
        string LeaveBalanceReplyTextForTest { get; }
        string OrElseString { get; }
        string Admin { get; }
        string Employee { get; }
        string TeamLeader { get; }
        string EmptyString { get; }
        string VerificationUrl { get; }
        string TeamJoin { get; }
        string SlackOAuthResponseText { get; }
        string AccessTokenSlack { get; }
        string UserDetailsResponseText { get; }
        string ChannelDetailsResponseText { get; }
        string GroupDetailsResponseText { get; }
        string LeaveListTestForOwn { get; }
        string WrongLeaveCancelCommandForTest { get; }
        string LeaveStatusTestForOwn { get; }
        string SecondQuestionForTest { get; }
        string ThirdQuestionForTest { get; }
        string ForthQuestionForTest { get; }
        string FifthQuestionForTest { get; }
        string SixthQuestionForTest { get; }
        string SeventhQuestionForTest { get; }
        string YouAreNotInExistInOAuthServer { get; }
        string HourSpentForTest { get; }
        string StatusOfWorkForTest { get; }
        string SendEmailYesForTest { get; }
        string SendEmailNoForTest { get; }
        string NotTypeOfLeave { get; }
        string DateFormatErrorMessage { get; }
        string ErrorWhileSendingEmail { get; }
        string UserIsAdmin { get; }
        string LeaveDoesnotExist { get; }
        string AdminErrorMessageUpdateSickLeave { get; }
        string True { get; }
        string LeaveStatusCommandForTest { get; }
        string LeaveBalanceTestForOwn { get; }
        string LeaveHelpTestForOwn { get; }
        string LeaveBalanceSickReplyTextForTest { get; }
        string SlashCommandTextSick { get; }
        string SlashCommandTextSickForUser { get; }
        string NameForTest { get; }
        string RequestToEnterProperAction { get; }
        string SlashCommandTextErrorLeaveType { get; }
        string SlashCommandTextErrorDateFormatSick { get; }
        string SlashCommandTextErrorDateFormatCasual { get; }
        string SlashCommandTextCasual { get; }
        string SlashCommandUpdate { get; }
        string SlashCommandUpdateDateError { get; }
        string SlashCommandUpdateWrongId { get; }
        string SickLeaveDoesnotExist { get; }
        string UpdateEnterAValidLeaveId { get; }
        string SlashCommandUpdateInValidId { get; }
        string ErrorOfEmailServiceFailureTaskMail { get; }
        string AdminErrorMessageApplySickLeave { get; }
        string UserNotFound { get; }

        #region String Constants for Test Cases

        string UserNameForTest { get; }
        string GroupName { get; }
        string AnswerStatement { get; }
        //  string LeaveApplicant { get; }
        string ChannelIdForTest { get; }
        string PhoneForTest { get; }
        // string TitleForTest { get; }
        string ScrumQuestionForTest { get; }
        string ChannelNameForTest { get; }
        string ProjectDetailsFromOauth { get; }
        string EmployeeDetailsFromOauth { get; }
        string EmployeesListFromOauth { get; }
        string UserBySlackUserName { get; }
        string UserBySlackUserNameForLeaveApplicant { get; }
        string UserIdForTest { get; }
        string TestUser { get; }
        string scrumAnswerForTest { get; }
        int ProjectIdForTest { get; }
        string Halt { get; }
        string Resume { get; }
        string AlreadyMarkedAsAnswered { get; }
        string TeamLeaderIdForTest { get; }
        string EmployeeIdForTest { get; }
        string TestAccessToken { get; }
        string TestUserName { get; }
        string TestUserNameFalse { get; }
        string FirstUserName { get; }
        string FirstUserNameFalse { get; }
        string ProjectUsers { get; }
        string TeamLeaderDetailFromOauthServer { get; }
        string EmployeeDetailFromOauthServer { get; }
        string IdForTest { get; }
        string TestUserId { get; }
        string NextQuestion { get; }
        string QuestionToNextEmployee { get; }
        string PreviousDayStatusForTest { get; }
        string UpdateAnswer { get; }
        #endregion

        string RoleAdmin { get; }
        string RoleTeamLeader { get; }
        string RoleEmployee { get; }

        string TeamMembersUrl { get; }
        string UserRoleUrl { get; }

        string NotAvailable { get; }
        string NextPage { get; }
        string PriviousPage { get; }


    }
}
