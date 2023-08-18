using app_web.Models;
using System.Collections.Generic;

namespace app_web.Repositorye.Interface
{
    public interface IUserRepositorye
    {
        public List<User> GetAll();

        public User GetaByid(int id);

        public User GetaByName(string email);

        public User CreateUser(User user);

        public User UpdateUser(User user);

        public User DeleteById(int id);

        public dynamic DeleteAll(List<User> user);
    }
}
