namespace CustomerClaims.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateUserCredentialsAsync(string username, string password);
    }
}

