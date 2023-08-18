using app_web.Context;
using app_web.Models;
using app_web.Repositorye.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app_web.Repositorye
{
    public class UserRepositorye : IUserRepositorye
    {
        private readonly Entityes _context;
        private readonly DbSet<User> _entityUser;

        public UserRepositorye(Entityes context)
        {
            _context = context;
            _entityUser = _context.Users;
        }

        public User CreateUser(User userData)
        {
            User user = new User();

            user.Email = userData.Email;

            user.Password = userData.Password;

            _entityUser.Add(user);

            _context.SaveChanges();

            return user;
        }

        public dynamic DeleteAll(List<User> user)
        {
            throw new NotImplementedException();
        }

        public User DeleteById(int id)
        {
            User userById = _entityUser.FirstOrDefault(x => x.Id == id);

            _context.Remove(userById);
            _context.SaveChanges();

            return userById;
        }

        public User GetaByid(int id)
        {
            User userById = _entityUser.FirstOrDefault(x => x.Id == id);
            return userById;
        }

        public User GetaByName(string email)
        {
            User userByName = (User)_entityUser.Where(x => x.Email == email);
            return userByName;
        }

        public List<User> GetAll()
        {
            List<User> users = _entityUser.ToList();

            return users;
        }

        public User UpdateUser(User user)
        {
            User userById = _entityUser.FirstOrDefault(x => x.Id == user.Id);

            if (userById != null)
            {
                userById.Email = user.Email;
                userById.Password = user.Password;
                _context.SaveChanges();

                return userById;
            }

            return null;
        }
    }
}
