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
            _conn.Insert(new SiginModel
            {
                Password = user.Password,
                Username = user.UserName,
                CreateLoginDate = DateTime.Now.ToShortDateString(),
                UpdateLoginDate = DateTime.Now.ToShortDateString()
            });
        }

        public User GetRegisteredCredentials()
        {
            var hasUserCredentials = (from x in _conn.Table<SiginModel>()
                                      where x.Password == _password &&
                                            x.Username == _username
                                      select x).LastOrDefault();

            return hasUserCredentials is SiginModel ? new User
            {
                Password = hasUserCredentials.Password,
                UserName = hasUserCredentials.Username
            } : null;
        }
    }
}