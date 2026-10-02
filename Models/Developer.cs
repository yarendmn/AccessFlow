using AccessFlow.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessFlow.Models
{
    public class Developer : Employee, IAuthenticatable, IAccessController
    {
        public Developer(int id, string name, string department, string password)
        : base(id, name, department, password) { }

        public override string GetAccessLevel()
        {
            return "Development";
        }

        public bool Login(string password)
        {
            if (VerifyPassword(password))
            {
                Console.WriteLine($"[GİRİŞ] Developer {Name} sisteme bağlandı.");
                return true;
            }
            Console.WriteLine($"[HATA] Developer {Name} için hatalı şifre.");
            return false;

        }

        public void Logout() => Console.WriteLine($"[ÇIKIŞ] Developer {Name} sistemden ayrıldı.");

        public bool CanAccess(string systemName)
        {
            return systemName == "GitHub" || systemName == "Azure Devops" || systemName == "DevServer";
        }
    }
}
