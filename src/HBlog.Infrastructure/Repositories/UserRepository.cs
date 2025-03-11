using HBlog.Domain.Entities;
using HBlog.Domain.Repositories;
using HBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace HBlog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.Include(p=> p.Photos).AsNoTracking().ToListAsync();
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public void Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
        }

        public IQueryable<User> GetUserLikesQuery(string predicate, Guid userId)
        {
            var users = _dbContext.Users.OrderBy(x => x.UserName).AsQueryable();
            var likes = _dbContext.Likes.AsQueryable();

            if (predicate == "liked")
            {
                likes = likes.Where(l => l.SourceUserId == userId);
                users = likes.Select(l => l.TargetUser);
            }
            if (predicate == "likedBy")
            {
                likes = likes.Where(l => l.TargetUserId == userId);
                users = likes.Select(l => l.SourceUser);
            }
            return users;
        }


    }
}