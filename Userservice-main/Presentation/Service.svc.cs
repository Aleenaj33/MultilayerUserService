using System.Collections.Generic;
using WCFOnionService.Application;
using WCFOnionService.Infrastructure;

namespace WCFOnionService.Presentation
{
    public class Service : IService
    {
        private readonly IUserService _userService;

        public Service()
        {
            // Initialize with DBContext
            var dbContext = new DBContext();
            var userRepository = new UserRepository(dbContext);
            _userService = new UserService(userRepository);
        }

        public List<UserDTO> Get()
        {
            return _userService.GetAllUsers();
        }

        public UserDTO GetUserById(string id)
        {
            // Convert string id to int
            if (int.TryParse(id, out int userId))
            {
                return _userService.GetUserById(userId);
            }
            return null;
        }

        public bool InsertUser(UserDTO user)
        {
            return _userService.InsertUser(user);
        }

        public void UpdateUser(UserDTO user)
        {
            _userService.UpdateUser(user);
        }

        public void DeleteUser(string id)
        {
            // Convert string id to int
            if (int.TryParse(id, out int userId))
            {
                _userService.DeleteUser(userId);
            }
        }
    }
}