using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace DataBase.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Location { get; set; }

        public ICollection<Journal> Journals { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<ActivityLog> ActivityLogs { get; set; }

        public ICollection<GameReview> GameReviews { get; set; }

        public ICollection<Achievement> Achievements { get; set; }

        public ICollection<JournalComment> JournalComments { get; set; }

        public static (string hash, string salt) HashPassword(string password)
        {
            byte[] saltBytes = GnrtSalt();
            string salt = Convert.ToBase64String(saltBytes);
            string hash = HashPasswordWSalt(password, saltBytes);
            return (hash, salt);
        }

        public static bool VerifyPass(string password, string salt, string hash)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string computedHash = HashPasswordWSalt(password, saltBytes);
            return hash == computedHash;
        }

        private static string HashPasswordWSalt(string password, byte[] saltBytes)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] combinedBytes = new byte[passwordBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, combinedBytes, passwordBytes.Length, saltBytes.Length);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private static byte[] GnrtSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return saltBytes;
        }
    }
}
