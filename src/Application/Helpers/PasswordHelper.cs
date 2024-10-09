using System.Security.Cryptography;
using System.Text;

namespace AuthMicroservice.src.Application.Helpers
{

    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }

}
