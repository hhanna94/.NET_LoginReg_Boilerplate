using System.Collections.Generic;
using System.Linq;
using LoginReg.Models;

namespace LoginReg.Data
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DataContext _context;

        public DataAccessProvider(DataContext context) {
            _context = context;
        }

        public void AddUser(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user) {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id) {
            var entity = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User GetOneUser(int id) {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public List<User> GetAllUsers() {
            return _context.Users.ToList();
        }
    }
}