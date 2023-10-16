using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyAPI.Models
{
    [Table("Option")]
    public class Option
    {
        [Key]
        public int Id {  get; set; }
        [ForeignKey("Survey")]
        public int SurveyId { get; set;}
        public Survey Survey { get; set; }
        public string Alternative { get; set;}
        public int Vote { get; set;}
    }
}
