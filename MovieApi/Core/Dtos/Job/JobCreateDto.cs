using MovieApi.Core.Enums;

namespace MovieApi.Core.Dtos.Job
{
    public class JobCreateDto
    {
        public String Title { get; set; }
        public JobLevel Level { get; set; }
        public long ComponyId { get; set; }
    }
}
