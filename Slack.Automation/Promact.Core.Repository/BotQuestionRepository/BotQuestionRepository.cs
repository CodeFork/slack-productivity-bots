﻿using Promact.Erp.DomainModel.Models;
using Promact.Erp.DomainModel.DataRepository;
using System.Threading.Tasks;
using Promact.Erp.DomainModel.ApplicationClass;

namespace Promact.Core.Repository.BotQuestionRepository
{
    public class BotQuestionRepository : IBotQuestionRepository
    {
        #region Private Variable
        private IRepository<Question> _questionRepository;
        #endregion

        #region Constructor
        public BotQuestionRepository(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method to add Question
        /// </summary>
        /// <param name="question">Question object</param>
        public void AddQuestion(Question question)
        {
            _questionRepository.Insert(question);
            _questionRepository.Save();
        }

        /// <summary>
        /// Method to find question by it's id
        /// </summary>
        /// <param name="questionId">question Id</param>
        /// <returns>question</returns>
        public async Task<Question> FindByIdAsync(int questionId)
        {
            var question = await _questionRepository.FirstOrDefaultAsync(x => x.Id == questionId);
            return question;
        }

        /// <summary>
        /// Method to find question by it's type
        /// </summary>
        /// <param name="type">question's type</param>
        /// <returns>question</returns>
        public async Task<Question> FindFirstQuestionByTypeAsync(BotQuestionType type)
        {
            var question = await _questionRepository.FirstOrDefaultAsync(x => x.Type == type);
            return question;
        }

        /// <summary>
        /// Method to find question by it's type and order number
        /// </summary>
        /// <param name="orderNumber">question's order number</param>
        /// <param name="type">question's type</param>
        /// <returns>question</returns>
        public async Task<Question> FindByTypeAndOrderNumberAsync(int orderNumber, int type)
        {
            var orderNumberValue = (QuestionOrder)orderNumber;
            var typeValue = (BotQuestionType)type;
            var question = await _questionRepository.FirstOrDefaultAsync(x => x.OrderNumber == orderNumberValue && x.Type == typeValue);
            return question;
        }
        #endregion
    }
}
