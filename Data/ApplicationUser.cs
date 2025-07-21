using Microsoft.AspNetCore.Identity;

namespace DahiraAgency.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
