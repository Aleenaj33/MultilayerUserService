using System.Collections.Generic;
using WCFOnionService.Infrastructure;

namespace WCFOnionService.Application
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        bool InsertUser(UserDTO user);
        void UpdateUser(UserDTO user);
        void DeleteUser(int id);
    }
}