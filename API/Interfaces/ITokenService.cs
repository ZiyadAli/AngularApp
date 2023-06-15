using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService
    {
      public string CreateToke(AppUser user);
    }
}
