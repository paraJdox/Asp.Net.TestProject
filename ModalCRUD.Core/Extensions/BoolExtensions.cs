using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Core.Extensions
{
    public static class BoolExtensions
    {
        public static bool IsEqualToThisHash(this string passwordInput, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(passwordInput, hashedPassword);
        }
    }
}
