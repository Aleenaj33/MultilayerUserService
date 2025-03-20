using System.Collections.Generic;
using System.Linq;
using WCFOnionService.Domain;
using WCFOnionService.Infrastructure;

namespace WCFOnionService.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAll().Select(MapToDTO).ToList();
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user != null ? MapToDTO(user) : null;
        }

        public bool InsertUser(UserDTO user)
        {
            var entity = MapToEntity(user);
            return _userRepository.Insert(entity);
        }

        public void UpdateUser(UserDTO user)
        {
            var entity = MapToEntity(user);
            entity.Id = user.Id;
            _userRepository.Update(entity);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                EnrollmentDate = user.EnrollmentDate
            };
        }

        private User MapToEntity(UserDTO dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                Password = dto.Password,
                EnrollmentDate = dto.EnrollmentDate
            };
        }
    }
}