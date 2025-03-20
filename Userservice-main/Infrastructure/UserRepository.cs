using System.Collections.Generic;
using System.Linq;
using WCFOnionService.Domain;

namespace WCFOnionService.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dbContext;

        public UserRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            return _dbContext.User.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.User.FirstOrDefault(u => u.Id == id);
        }

        public bool Insert(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return true;
        }

        public void Update(User user)
        {
            var existingUser = _dbContext.User.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.EnrollmentDate = user.EnrollmentDate;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.User.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}