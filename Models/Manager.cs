using AccessFlow.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessFlow.Models
{
    public class Manager : Employee, IAuthenticatable, IAccessController, IAuditable
    {
        public Manager(int id, string name, string department, string password)
            : base(id, name, department, password) { }

        public override string GetAccessLevel()
        {
            return "Management";
        }

        public bool Login(string password)
        {
            if (VerifyPassword(password))
            {
                Console.WriteLine($"[GİRİŞ] Manager {Name} sisteme bağlandı.");
                return true;
            }
            return false;
        }

        public void Logout() => Console.WriteLine($"[ÇIKIŞ] Manager {Name} sistemden ayrıldı.");

        public bool CanAccess(string systemName)
        {
            return systemName == "HR System" || systemName == "Jira" || systemName == "Financial Dashboards";
        }

        public void GenerateAccessReport()
        {
            Console.WriteLine($"[RAPOR] Manager {Name}, departman bazlı haftalık erişim raporunu oluşturdu.");
        }
    }
}
