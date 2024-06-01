using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Achievement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; } 
        public DateTime AchievementDate { get; set; } = DateTime.UtcNow;
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
