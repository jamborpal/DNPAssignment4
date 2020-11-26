using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPAssignment3.ContextClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Assignment2.Login
{
    public class UserDataService : IUserService
    {
        private AdultContext AdultContext;

        public UserDataService(AdultContext adultContext)
        {
            this.AdultContext = adultContext;
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            List<User> users = AdultContext.Users.Where(users =>
                users.UserName.Equals(username) && users.Password.Equals(password)).ToList();
            return users[0];
        }

        public async Task<User> AddUserAsync(User user)
        {
            EntityEntry<User> newUser = await AdultContext.Users.AddAsync(user);
            await AdultContext.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task<IList<User>> getUsersAsync()
        {
            return await AdultContext.Users.ToListAsync();
        }

        public async Task RemoveUserAsync(string usernametoRemove)
        {
            User toDelete = await AdultContext.Users.FirstOrDefaultAsync(t => t.UserName == usernametoRemove);
            if (toDelete != null)
            {
                AdultContext.Users.Remove(toDelete);
                await AdultContext.SaveChangesAsync();
            }
        }
    }
}