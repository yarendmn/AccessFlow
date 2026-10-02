using System;
using System.Collections.Generic;
using System.Text;

namespace AccessFlow.Interfaces
{
    public interface IAuthenticatable
    {
        bool Login(string password);
        void Logout();
    }
}
