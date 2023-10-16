using SurveyAPI.Responses;

namespace SurveyAPI.Service
{
    public interface ISurveyService
    {
        List<SurveyResponse> GetSurveys();
        SurveyResponse GetSurvey(int surveyId);
        OptionResponse GetSurveyOption(int optionId);
        List<OptionResponse> GetOptionsBySurvey(int surveyId);
        bool AddOptionVotePoint(int voteId);
    }
}
