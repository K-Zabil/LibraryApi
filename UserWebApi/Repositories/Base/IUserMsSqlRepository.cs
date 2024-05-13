using UserWebApi.Models.UserModels.Entities;

namespace UserWebApi.Repositories.Base;

public interface IUserMsSqlRepository
{
    Task<User?> GetUserByIdAsync(int id);
}
