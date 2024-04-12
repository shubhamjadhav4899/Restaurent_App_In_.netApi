using System.ComponentModel.DataAnnotations;

namespace MovieApi.Core.Entites
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool isActive {  get; set; }
    }
}
