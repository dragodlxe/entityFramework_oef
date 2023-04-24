using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oefproject.models
{
    public class Task
    {
        // [Key]
        public Guid TaskId { set; get; }

        // [ForeignKey("CategoryId")]
        public Guid CategoryId { set; get; }
        // [Required]
        // [MaxLength(200)]
        public string Title { set; get; }
        public string Description { set;  get; }
        public Priority TaskPriority { set; get; }
        public DateTime CreateDt { set; get; }
        public virtual Category  Category{ set;  get; }
        // [NotMapped]
        public string Summary { set;  get; }
    }
    public enum Priority 
    {
        Low,
        Mid,
        High
    }
}