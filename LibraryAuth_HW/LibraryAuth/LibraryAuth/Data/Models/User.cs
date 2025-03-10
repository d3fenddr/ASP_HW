using Microsoft.AspNetCore.Identity;

namespace LibraryAuth.Data.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
    }
}