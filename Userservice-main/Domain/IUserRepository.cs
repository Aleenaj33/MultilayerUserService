using System.Collections.Generic;

namespace WCFOnionService.Domain
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool Insert(User user);
        void Update(User user);
        void Delete(int id);
    }
}