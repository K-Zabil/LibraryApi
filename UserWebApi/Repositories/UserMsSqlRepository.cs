using Dapper;
using Microsoft.Data.SqlClient;
using UserWebApi.Models.UserModels.Entities;
using UserWebApi.Repositories.Base;

namespace UserWebApi.Repositories;

public class UserMsSqlRepository : IUserMsSqlRepository
{
    private const string connectionString = "";
    private readonly SqlConnection connection = new SqlConnection(connectionString);
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var query = "Select * from Users u Where u.Id == @id";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { id });
    }
}