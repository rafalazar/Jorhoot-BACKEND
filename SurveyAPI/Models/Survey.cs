using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyAPI.Models
{
    [Table("Survey")]
    public class Survey
    {
        [Key]
        public int Id {  get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
    }
}
