using MovieApi.Core.Enums;

namespace MovieApi.Core.Entites
{
    public class Job:BaseEntity
    {
        public String Title {  get; set; }  
        public JobLevel Level { get; set; }

        public long ComponyId {  get; set; }

        public Compony Compony { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}
