using System.Collections.Generic;
using LoginReg.Models;

namespace LoginReg.Data
{
    public interface IDataAccessProvider
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetOneUser(int id);
        List<User> GetAllUsers();
    }
}