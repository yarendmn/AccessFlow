using AccessFlow.Interfaces;
using AccessFlow.Models;

public class Intern : Employee, IAuthenticatable, IAccessController
{
    public Intern(int id, string name, string department, string password)
        : base(id, name, department, password) { }

    public override string GetAccessLevel()
    {
        return "Limited";
    }

    public bool Login(string password)
    {
        if (VerifyPassword(password))
        {
            Console.WriteLine($"[GİRİŞ] Intern {Name} sisteme bağlandı.");
            return true;
        }
        return false;
    }

    public void LogOut() => Console.WriteLine($"[ÇIKIŞ] Intern {Name} sistemden ayrıldı.");

    public bool CanAccess(string systemName)
    {
        // Stajyerlerin erişimi daha kısıtlı
        return systemName == "Slack" || systemName == "E-Learning Portal";
    }

}