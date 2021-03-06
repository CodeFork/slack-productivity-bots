﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Promact.Erp.DomainModel.ApplicationClass.SlackRequestAndResponse;
using Promact.Erp.DomainModel.DataRepository;
using Promact.Erp.Util.StringConstants;


namespace Promact.Core.Repository.SlackUserRepository
{
    public class SlackUserRepository : ISlackUserRepository
    {

        #region Private Variable 


        private readonly IRepository<SlackUserDetails> _slackUserDetailsRepository;
        private readonly IStringConstantRepository _stringConstant;
        private readonly IMapper _mapper;


        #endregion


        #region Constructor


        public SlackUserRepository(IRepository<SlackUserDetails> slackUserDetailsRepository,
        IStringConstantRepository stringConstant, IMapper mapper)
        {
            _slackUserDetailsRepository = slackUserDetailsRepository;
            _stringConstant = stringConstant;
            _mapper = mapper;
        }
        #endregion


        #region Public Methods


        /// <summary>
        /// Method to add/update slack user 
        /// </summary>
        /// <param name="slackUserDetails">slack user details. Object of SlackUserDetails</param>
        public async Task AddSlackUserAsync(SlackUserDetails slackUserDetails)
        {
            SlackUserDetails slackUser = await _slackUserDetailsRepository.FirstOrDefaultAsync(x => x.UserId == slackUserDetails.UserId);
            if (slackUser == null)
            {
                if (!slackUserDetails.Deleted)
                {
                    //Added to database only if the user is not deleted
                    await AddSlackUserDetailAsync(slackUserDetails);
                }
            }
            else
                await UpdateSlackUserAsync(slackUserDetails);
        }


        /// <summary>
        /// Method to update slack user. - JJ
        /// </summary>
        /// <param name="slackUserDetails">slack user details. Object of SlackUserDetails</param>
        public async Task UpdateSlackUserAsync(SlackUserDetails slackUserDetails)
        {
            SlackUserDetails user = await _slackUserDetailsRepository.FirstOrDefaultAsync(x => x.UserId == slackUserDetails.UserId);
            if (slackUserDetails.Deleted)
            {
                //delete the deleted user from database
                _slackUserDetailsRepository.Delete(user.Id);
                await _slackUserDetailsRepository.SaveChangesAsync();
            }
            else
            {
                // Perform mapping
                user = _mapper.Map(slackUserDetails, user);
                _slackUserDetailsRepository.Update(user);
                await _slackUserDetailsRepository.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Method to get slack user information by their slack user id
        /// </summary>
        /// <param name="slackId">slack user id</param>
        /// <returns>object of SlackUserDetailAc</returns>
        public async Task<SlackUserDetailAc> GetByIdAsync(string slackId)
        {
            SlackUserDetails slackUserDetail = await _slackUserDetailsRepository.FirstOrDefaultAsync(x => x.UserId == slackId);
            SlackUserDetailAc slackUserDetailAc = _mapper.Map<SlackUserDetailAc>(slackUserDetail);
            return slackUserDetailAc;
        }


        /// <summary>
        /// Method to get slack user information by their slack user name. - JJ
        /// </summary>
        /// <param name="userSlackName">slack user name</param>
        /// <returns>object of SlackUserDetailAc</returns>
        public async Task<SlackUserDetailAc> GetBySlackNameAsync(string userSlackName)
        {
            SlackUserDetails slackUserDetail = await _slackUserDetailsRepository.FirstOrDefaultAsync(x => x.Name == userSlackName);
            SlackUserDetailAc slackUserDetailAc = _mapper.Map<SlackUserDetailAc>(slackUserDetail);
            return slackUserDetailAc;
        }


        #endregion


        #region Private Methods


        /// <summary>
        /// Add Slack User Details to the database - JJ
        /// </summary>
        /// <param name="slackUserDetails">slack user details. Object of SlackUserDetails</param>
        private async Task AddSlackUserDetailAsync(SlackUserDetails slackUserDetails)
        {
            // Perform mapping
            slackUserDetails = _mapper.Map<SlackUserDetails>(slackUserDetails);
            slackUserDetails.CreatedOn = DateTime.UtcNow;
            _slackUserDetailsRepository.Insert(slackUserDetails);
            await _slackUserDetailsRepository.SaveChangesAsync();
        }


        #endregion


    }
}