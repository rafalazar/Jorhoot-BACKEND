using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyAPI.Responses;
using SurveyAPI.Service;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet("surveys")]
        public IActionResult GetAllSurveys()
        {
            try
            {
                var response = _surveyService.GetSurveys();
                if (!response.Any()) return NotFound(new List<SurveyResponse>());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("survey/{id}")]
        public IActionResult GetSingleSurvey(int id)
        {
            try
            {
                var survey = _surveyService.GetSurvey(id);

                if (survey == null) return NotFound();

                return Ok(survey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("option/{surveyId}")]
        public IActionResult GetOptionsBySurvey(int surveyId)
        {
            try
            {
                var optionsBySurvey = _surveyService.GetOptionsBySurvey(surveyId);

                if (!optionsBySurvey.Any()) return NotFound(new List<OptionResponse>());

                return Ok(optionsBySurvey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("option/{voteId}")]
        public IActionResult AddOptionVoteValue(int voteId)
        {
            try
            {
                var response = _surveyService.AddOptionVotePoint(voteId);

                if (response != true || response != false) return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
