using Challenge.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Mobile.Service
{
    public interface ILoginService
    {
        bool HasValidCredentials(User user);

        User CleanUser();

        void RegisterLogin(User user);

        User GetRegisteredCredentials();
    }
}