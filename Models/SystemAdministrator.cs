using AccessFlow.Interfaces;

namespace AccessFlow.Models
{
    public class SystemAdministrator : Employee, IAuthenticatable, IAccessController, IAuditable
    {
        public SystemAdministrator(int id, string name, string department, string password)
            : base(id, name, department, password) { }

        public override string GetAccessLevel()
        {
            return "Full Access";
        }

        public bool Login(string password)
        {
            if (VerifyPassword(password))
            {
                Console.WriteLine($"[GİRİŞ] SysAdmin {Name} root yetkileriyle bağlandı.");
                return true;
            }
            return false;
        }

        public void Logout() => Console.WriteLine($"[ÇIKIŞ] SysAdmin {Name} sistemden ayrıldı.");

        public bool CanAccess(string systemName)
        {
            // Sistem yöneticisi her yere erişebilir
            return true;
        }

        public void GenerateAccessReport()
        {
            Console.WriteLine($"[RAPOR] SysAdmin {Name}, tüm sunucuların güvenlik ve erişim loglarını dışa aktardı.");
        }
    }
}
