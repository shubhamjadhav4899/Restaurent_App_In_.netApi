using MovieApi.Core.Enums;

namespace MovieApi.Core.Dtos.Compony
{
    public class ComponyGetDto
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public ComponySize Size { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
