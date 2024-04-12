using MovieApi.Core.Enums;

namespace MovieApi.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }
        public String Title { get; set; }
        public JobLevel Level { get; set; }

        public long ComponyId { get; set; }

        public string componyName { get;set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
       
       

       
    }
}
