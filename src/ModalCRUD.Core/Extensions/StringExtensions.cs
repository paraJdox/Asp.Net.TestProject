using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsEqualToThisHash(this string passwordInput, string hashedPasswordFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(passwordInput, hashedPasswordFromDb);
        }
    }
}
