using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace oefproject.models
{
    public class Category
    {
        //[Key]
        public Guid CategoryId {set; get;}
        //[Required]
        //[MaxLength(150)]
        public string Name {set; get;}
        public string Description {set; get;}
        public int Weignt {set; get;}
        [JsonIgnore]
        public ICollection<Task> Tasks {set;  get;}
    }
}