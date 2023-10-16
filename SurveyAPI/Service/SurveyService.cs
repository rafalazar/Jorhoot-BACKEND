using SurveyAPI.Models;
using SurveyAPI.Responses;

namespace SurveyAPI.Service
{
    public class SurveyService : ISurveyService
    {
        private EfDataContext _efDataContext;

        public SurveyService(EfDataContext efDataContext)
        {
            _efDataContext = efDataContext;
        }

        public SurveyResponse GetSurvey(int surveyId)
        {
            var survey = _efDataContext.Surveys.FirstOrDefault(s => s.Id.Equals(surveyId));

            return new SurveyResponse()
            {
                Id = survey.Id,
                Question = survey.Question,
                Description = survey.Description,
            };
        }

        public List<SurveyResponse> GetSurveys()
        {
            var surveys = new List<SurveyResponse>();
            var dataList = _efDataContext.Surveys.ToList();

            dataList.ForEach(survey => surveys.Add(new SurveyResponse()
            {
                Id = survey.Id,
                Question = survey.Question,
                Description = survey.Description,
            }));

            return surveys;
        }

        public OptionResponse GetSurveyOption(int optionId)
        {
            var option = _efDataContext.Options.FirstOrDefault(o => o.Id.Equals(optionId));

            return new OptionResponse()
            {
                Id = option.Id,
                SurveyId = option.SurveyId,
                Alternative = option.Alternative,
                Vote = option.Vote,
            };
        }

        public List<OptionResponse> GetOptionsBySurvey(int surveyId)
        {
            var options = new List<OptionResponse>();
            var dataList = _efDataContext.Options.Where(o => o.Survey != null && o.SurveyId.Equals(surveyId)).ToList();

            options = dataList.Select(option => new OptionResponse()
            {
                Id = option.Id,
                SurveyId = option.SurveyId,
                Alternative = option.Alternative,
                Vote = option.Vote,
            }).ToList();

            return options;
        }

        public bool AddOptionVotePoint(int voteId)
        {
            var option = _efDataContext.Options.FirstOrDefault(o => o.Id.Equals(voteId));

            if (option == null) return false;

            option.Vote = option.Vote + 1;

            _efDataContext.Update(option);
            _efDataContext.SaveChanges();

            return true;
        }
    }
}
