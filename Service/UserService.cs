using app_web.Models;
using app_web.Repositorye;
using app_web.Repositorye.Interface;
using System.Collections.Generic;

namespace app_web.Service
{
    public class UserService 
    {

        private readonly UserRepositorye _userRepositorye;

        public UserService(UserRepositorye userRepositorye)
        {
            _userRepositorye = userRepositorye;
        }

        public List<User> GetUserAll()
        {
          List<User> users = _userRepositorye.GetAll();

            return users;
        }

        public User UpdateUser(User userUpdate)
        {
           User user = _userRepositorye.UpdateUser(userUpdate);

            return user;
        }

        public User GetaByid(int id)
        {
            User userById = _userRepositorye.GetaByid(id);
            return userById;
        }

        public User DeleteById(int id)
        {
            User userById = _userRepositorye.DeleteById(id);
            return userById;
        }

        public User CreateUser(User userData)
        {
            User user = _userRepositorye.CreateUser(userData);
            return user;
        }

    }
}
