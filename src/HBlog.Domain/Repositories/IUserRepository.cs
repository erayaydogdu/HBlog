using HBlog.Domain.Entities;
namespace HBlog.Domain.Repositories
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUsernameAsync(string username);
        IQueryable<User> GetUserLikesQuery(string predicate, Guid userId);
    }
}