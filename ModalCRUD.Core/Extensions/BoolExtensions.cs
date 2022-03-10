using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Core.Extensions
{
    public static class BoolExtensions
    {
        public static bool VerifyHash(this string currentUserPassword, string hashedPasswordFromDb)
        {
            return BCrypt.Net.BCrypt.Verify(currentUserPassword, hashedPasswordFromDb);
        }
    }
}
