﻿using Autofac;
using Moq;
using Promact.Core.Repository.HttpClientRepository;
using Promact.Core.Repository.OauthCallsRepository;
using Promact.Erp.Util.StringConstants;
using System.Threading.Tasks;
using Xunit;

namespace Promact.Core.Test
{
    /// <summary>
    /// Test Cases of Project User Call Repository
    /// </summary>
    public class OauthCallsRepositoryTest
    {
        private readonly IComponentContext _componentContext;
        private readonly IOauthCallsRepository _oauthCallsRepository;
        private readonly Mock<IHttpClientRepository> _mockHttpClient;
        private readonly IStringConstantRepository _stringConstant;
        public OauthCallsRepositoryTest()
        {
            _componentContext = AutofacConfig.RegisterDependancies();
            _oauthCallsRepository = _componentContext.Resolve<IOauthCallsRepository>();
            _mockHttpClient = _componentContext.Resolve<Mock<IHttpClientRepository>>();
            _stringConstant = _componentContext.Resolve<IStringConstantRepository>();
        }

        /// <summary>
        /// Method GetUserByUserId Testing with True Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserByUserId()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserDetailsUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var user = _oauthCallsRepository.GetUserByUserId(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.Equal(user.Email, _stringConstant.ManagementEmailForTest);
        }

        /// <summary>
        /// Method GetTeamLeaderUserName Testing with True Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetTeamLeaderUserName()
        {
            var teamLeaderResponse = Task.FromResult(_stringConstant.TeamLeaderDetailsFromOauthServer);
            var teamLeaderRequestUrl = string.Format("{0}{1}", _stringConstant.TeamLeaderDetailsUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, teamLeaderRequestUrl, _stringConstant.AccessTokenForTest)).Returns(teamLeaderResponse);
            string teamLeaderUsername = "";
            var teamLeader = _oauthCallsRepository.GetTeamLeaderUserId(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            foreach (var team in teamLeader)
            {
                teamLeaderUsername = team.Email;
            }
            Assert.Equal(teamLeaderUsername, _stringConstant.TeamLeaderEmailForTest);
        }

        /// <summary>
        /// Method GetManagementUserName Testing with True Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetManagementUserName()
        {
            var managementResponse = Task.FromResult(_stringConstant.ManagementDetailsFromOauthServer);
            var managementRequestUrl = string.Format("{0}", _stringConstant.ManagementDetailsUrl);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, managementRequestUrl, _stringConstant.AccessTokenForTest)).Returns(managementResponse);
            string managementUsername = "";
            var management = _oauthCallsRepository.GetManagementUserName(_stringConstant.AccessTokenForTest).Result;
            foreach (var team in management)
            {
                managementUsername = team.FirstName;
            }
            Assert.Equal(managementUsername, _stringConstant.ManagementFirstForTest);
        }

        /// <summary>
        /// Method GetUserByUserIdFalse Testing with False Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserByUserIdFalse()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserDetailsUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var user = _oauthCallsRepository.GetUserByUserId(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.NotEqual(user.Email, _stringConstant.TeamLeaderEmailForTest);
        }

        /// <summary>
        /// Method GetTeamLeaderUserIdFalse Testing with False Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetTeamLeaderUserIdFalse()
        {
            var teamLeaderResponse = Task.FromResult(_stringConstant.TeamLeaderDetailsFromOauthServer);
            var teamLeaderRequestUrl = string.Format("{0}{1}", _stringConstant.TeamLeaderDetailsUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, teamLeaderRequestUrl, _stringConstant.AccessTokenForTest)).Returns(teamLeaderResponse);
            string teamLeaderUsername = "";
            var teamLeader = _oauthCallsRepository.GetTeamLeaderUserId(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            foreach (var team in teamLeader)
            {
                teamLeaderUsername = team.FirstName;
            }
            Assert.NotEqual(teamLeaderUsername, _stringConstant.ManagementFirstForTest);
        }

        /// <summary>
        /// Method GetManagementUserNameFalse Testing with False Value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetManagementUserNameFalse()
        {
            var managementResponse = Task.FromResult(_stringConstant.ManagementDetailsFromOauthServer);
            var managementRequestUrl = string.Format("{0}", _stringConstant.ManagementDetailsUrl);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, managementRequestUrl, _stringConstant.AccessTokenForTest)).Returns(managementResponse);
            string managementUsername = "";
            var management = _oauthCallsRepository.GetManagementUserName(_stringConstant.AccessTokenForTest).Result;
            foreach (var team in management)
            {
                managementUsername = team.FirstName;
            }
            Assert.NotEqual(managementUsername, _stringConstant.FirstNameForTest);
        }

        /// <summary>
        /// Method CasualLeave testing with true value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void CasualLeave()
        {
            var response = Task.FromResult(_stringConstant.CasualLeaveResponse);
            var requestUrl = string.Format("{0}{1}", _stringConstant.CasualLeaveUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var casualLeave = _oauthCallsRepository.CasualLeave(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.Equal(10, casualLeave.CasualLeave);
        }

        /// <summary>
        /// Method CasualLeave testing with false value
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void CasualLeaveFalse()
        {
            var response = Task.FromResult(_stringConstant.CasualLeaveResponse);
            var requestUrl = string.Format("{0}{1}", _stringConstant.CasualLeaveUrl, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var casualLeave = _oauthCallsRepository.CasualLeave(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.NotEqual(14, casualLeave.CasualLeave);
        }

        /// <summary>
        /// Method to test GetUserByEmployeeId with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserByEmployeeId()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserDetailUrl, _stringConstant.EmployeeIdForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.UserUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userDetails = _oauthCallsRepository.GetUserByEmployeeIdAsync(_stringConstant.EmployeeIdForTest, _stringConstant.TestAccessToken).Result;
            Assert.Equal(userDetails.UserName, _stringConstant.TestUserName);
        }

        /// <summary>
        /// Method to test GetUserByEmployeeId with incorrect values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserByEmployeeIdFalse()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserDetailUrl, _stringConstant.EmployeeIdForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.UserUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userDetails = _oauthCallsRepository.GetUserByEmployeeIdAsync(_stringConstant.EmployeeIdForTest, _stringConstant.TestAccessToken).Result;
            Assert.NotEqual(userDetails.UserName, _stringConstant.TestUserNameFalse);
        }

        /// <summary>
        /// Method to test GetUserByUserName with correct values 
        /// </summary>
        [Fact, Trait("Category","Required")]
        public void GetUserByUserName()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}",_stringConstant.LoginUserDetail, _stringConstant.TestUserName);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.UserUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userDetails = _oauthCallsRepository.GetUserByUserNameAsync(_stringConstant.TestUserName, _stringConstant.TestAccessToken).Result;
            Assert.Equal(userDetails.UserName, _stringConstant.TestUserName);
        }

        /// <summary>
        /// Method to test GetUserByUserName with incorrect values 
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserByUserNameFalse()
        {
            var response = Task.FromResult(_stringConstant.UserDetailsFromOauthServer);
            var requestUrl = string.Format("{0}{1}", _stringConstant.LoginUserDetail, _stringConstant.TestUserName);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.UserUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userDetails = _oauthCallsRepository.GetUserByUserNameAsync(_stringConstant.TestUserName, _stringConstant.TestAccessToken).Result;
            Assert.NotEqual(userDetails.UserName, _stringConstant.TestUserNameFalse);
        }

        /// <summary>
        /// Method to test GetProjectUsersByTeamLeaderId with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetProjectUsersByTeamLeaderId()
        {
            var response = Task.FromResult(_stringConstant.ProjectUsers);
            var requestUrl = string.Format("{0}{1}", _stringConstant.ProjectUsersByTeamLeaderId, _stringConstant.EmployeeIdForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userName = _stringConstant.EmptyString;
            var users = _oauthCallsRepository.GetProjectUsersByTeamLeaderIdAsync(_stringConstant.EmployeeIdForTest, _stringConstant.TestAccessToken).Result;
            foreach (var user in users)
            {
                userName = user.UserName;
            }
            Assert.Equal(userName, _stringConstant.FirstUserName);
        }

        /// <summary>
        /// Method to test GetProjectUsersByTeamLeaderId with incorrect values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetProjectUsersByTeamLeaderIdFalse()
        {
            var response = Task.FromResult(_stringConstant.ProjectUsers);
            var requestUrl = string.Format("{0}{1}", _stringConstant.ProjectUsersByTeamLeaderId, _stringConstant.EmployeeIdForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUrl, requestUrl, _stringConstant.TestAccessToken)).Returns(response);
            var userName = _stringConstant.EmptyString;
            var users = _oauthCallsRepository.GetProjectUsersByTeamLeaderIdAsync(_stringConstant.EmployeeIdForTest, _stringConstant.TestAccessToken).Result;
            foreach (var user in users)
            {
                userName = user.UserName;
            }
            Assert.NotEqual(userName, _stringConstant.FirstUserNameFalse);
        }

        /// <summary>
        /// Method to test UserIsAdmin with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void UserIsAdmin()
        {
            var response = Task.FromResult(_stringConstant.True);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserIsAdmin, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var result = _oauthCallsRepository.UserIsAdmin(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.Equal(true, result);
        }

        /// <summary>
        /// Method to test UserIsAdmin with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void UserIsAdminWrong()
        {
            var response = Task.FromResult(_stringConstant.True);
            var requestUrl = string.Format("{0}{1}", _stringConstant.UserIsAdmin, _stringConstant.FirstNameForTest);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var result = _oauthCallsRepository.UserIsAdmin(_stringConstant.FirstNameForTest, _stringConstant.AccessTokenForTest).Result;
            Assert.NotEqual(false, result);
        }

      

        /// <summary>
        /// Test case for conduct task mail after started
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetUserRole()
        {
            var response = Task.FromResult(_stringConstant.TaskMailReport);
            var requestUrl = string.Format("{0}{1}", _stringConstant.EmailForTest, _stringConstant.UserRoleUrl);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.UserUrl, requestUrl, _stringConstant.AccessTokenForTest)).Returns(response);
            var userRole = _oauthCallsRepository.GetUserRole(_stringConstant.EmailForTest,_stringConstant.AccessTokenForTest);
            Assert.Equal(3, userRole.Result.Count);
        }

      

        /// <summary>
        /// Method to test GetALlProjects with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetAllProjectsTrue()
        {
            var responseProjects = Task.FromResult(_stringConstant.ProjectDetailsForAdminFromOauth);
            var requestUrlProjects = _stringConstant.AllProjectUrl;
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUrl, requestUrlProjects, _stringConstant.TestAccessToken)).Returns(responseProjects);
            var projects = _oauthCallsRepository.GetAllProjectsAsync(_stringConstant.TestAccessToken).Result;
            Assert.Equal(1, projects.Count);
        }

        /// <summary>
        /// Method to test GetProjectDetails with correct values
        /// </summary>
        [Fact, Trait("Category", "Required")]
        public void GetProjectDetailsTrue()
        {
            int testProjectId = 1012;
            var responseProject = Task.FromResult(_stringConstant.ProjectDetail);
            var requestProjectUrl = string.Format("{0}{1}", testProjectId, _stringConstant.GetProjectDetails);
            _mockHttpClient.Setup(x => x.GetAsync(_stringConstant.ProjectUrl, requestProjectUrl, _stringConstant.TestAccessToken)).Returns(responseProject);
            var project = _oauthCallsRepository.GetProjectDetailsAsync(testProjectId, _stringConstant.TestAccessToken).Result;
            Assert.Equal(2, project.ApplicationUsers.Count);
        }

    }
}