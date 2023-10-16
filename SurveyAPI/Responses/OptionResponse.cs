using SurveyAPI.Models;

namespace SurveyAPI.Responses
{
    public class OptionResponse
    {
        public int Id { get; set; }
        public int? SurveyId { get; set; }
        public string Alternative { get; set; }
        public int Vote { get; set; }
    }
}
