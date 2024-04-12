using MovieApi.Core.Enums;

namespace MovieApi.Core.Entites
{
    public class Compony: BaseEntity
    {
        public String Name {  get; set; }
        public ComponySize Size { get; set; }

        public ICollection<Job> Jobs { get; set; }

    }
}
