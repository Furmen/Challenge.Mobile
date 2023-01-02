using Challenge.Mobile.Infrastructure;
using Challenge.Mobile.Models;
using PCLAppConfig;
using SQLite;
using System;
using System.Linq;

namespace Challenge.Mobile.Service
{
    public class LoginService : ILoginService
    {
        private readonly string _username;
        private readonly string _password;
        private readonly SQLiteConnection _conn;

        public LoginService()
        {
            _username = ConfigurationManager.AppSettings["USERNAME"];
            _password = ConfigurationManager.AppSettings["PASSWORD"];

            _conn = Sqlite.ConnectionDB;
        }

        public bool HasValidCredentials(User user) =>
            user.UserName == _username &&
            user.Password == _password;

        public User CleanUser() => new User();

        public void RegisterLogin(User user)
        {
            _conn.Insert(new User
            {
                Password = user.Password,
                UserName = user.UserName
            });
        }

        public User GetRegisteredCredentials()
        {
            var hasUserCredentials = (from x in _conn.Table<User>()
                                      where x.Password == _password &&
                                            x.UserName == _username
                                      select x).LastOrDefault();

            return hasUserCredentials is User ? new User
            {
                Password = hasUserCredentials.Password,
                UserName = hasUserCredentials.UserName
            } : null;
        }

        public void RemoveLastLoggedUserCredentials()
        {
            var lastLoggerUser = GetRegisteredCredentials();

            _ = lastLoggerUser is User ?
                _conn.Table<User>().Delete(x => x.Id == lastLoggerUser.Id) :
                throw new Exception("User credentials not found in database.");
        }
    }
}