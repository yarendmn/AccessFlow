using System;
using AccessFlow.Models;
using AccessFlow.Interfaces;

namespace AccessFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[100];
            CompanySystem[] systems = new CompanySystem[10];

            int empCount = 0;

            systems[0] = new CompanySystem("Production Server");
            systems[1] = new CompanySystem("Source Code Repository");
            systems[2] = new CompanySystem("Employee Database");
            systems[3] = new CompanySystem("Finance System");
            systems[4] = new CompanySystem("Test Server");

            employees[empCount++] = new Developer(1, "Ahmet", "IT", "123");
            employees[empCount++] = new SystemAdministrator(2, "Zehra", "IT", "admin123");

            bool isRunning = true;

            while (isRunning)
            {
                // İstenen menü tasarımı[cite: 6]
                Console.WriteLine("\n========= ACCESS FLOW =========");
                Console.WriteLine("1 - Employee oluştur");
                Console.WriteLine("2 - Employee listele");
                Console.WriteLine("3 - Sisteme giriş yap");
                Console.WriteLine("4 - Sisteme erişmeye çalış");
                Console.WriteLine("5 - Çalışan erişim raporu");
                Console.WriteLine("6 - Kullanıcı aktifleştir");
                Console.WriteLine("7 - Kullanıcı devre dışı bırak");
                Console.WriteLine("8 - Çıkış");
                Console.Write("Seçiminiz: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Employee oluştur
                        Console.WriteLine("Çalışan Tipi Seçin (1-Developer, 2-Intern, 3-Manager, 4-SysAdmin):");
                        string type = Console.ReadLine();
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("İsim: ");
                        string name = Console.ReadLine();
                        Console.Write("Departman: ");
                        string dept = Console.ReadLine();
                        Console.Write("Şifre: ");
                        string pass = Console.ReadLine();

                        if (type == "1") employees[empCount++] = new Developer(id, name, dept, pass);
                        else if (type == "2") employees[empCount++] = new Intern(id, name, dept, pass);
                        else if (type == "3") employees[empCount++] = new Manager(id, name, dept, pass);
                        else if (type == "4") employees[empCount++] = new SystemAdministrator(id, name, dept, pass);

                        Console.WriteLine("Çalışan başarıyla eklendi.");
                        break;

                    case "2": // Employee listele
                        Console.WriteLine("\n--- Çalışan Listesi ---");
                        for (int i = 0; i < empCount; i++)
                        {
                            string status = employees[i].IsActive ? "Aktif" : "Pasif";
                            Console.WriteLine($"ID: {employees[i].Id} | {employees[i].Name} ({employees[i].GetType().Name}) | Yetki: {employees[i].GetAccessLevel()} | Durum: {status}");
                        }
                        break;

                    case "3": // Sisteme giriş yap
                        Console.Write("Giriş yapmak için Çalışan ID girin: ");
                        int loginId = int.Parse(Console.ReadLine());
                        Console.Write("Şifre: ");
                        string loginPass = Console.ReadLine();

                        bool userFound = false;
                        for (int i = 0; i < empCount; i++)
                        {
                            if (employees[i].Id == loginId)
                            {
                                userFound = true;
                                // IAuthenticatable interface'ine sahip mi kontrolü (Polymorphism)
                                if (employees[i] is IAuthenticatable authUser)
                                {
                                    authUser.Login(loginPass);
                                }
                                else
                                {
                                    Console.WriteLine("Bu çalışanın sisteme giriş yetkisi yok.");
                                }
                                break;
                            }
                        }
                        if (!userFound) Console.WriteLine("Kullanıcı bulunamadı.");
                        break;

                    case "4": // 4 - Sisteme erişmeye çalış (Simülasyon testi)
                              // Simülasyon için 1. sıradaki Developer'ı ve Production Server'ı baz alıyoruz.
                        Employee emp = employees[0]; // Ahmet (Developer)
                        CompanySystem sys = systems[0]; // Production Server

                        Console.WriteLine($"{emp.GetType().Name} {sys.Name}'a erişmeye çalıştı.");

                        if (emp is IAccessController accessController)
                        {
                            if (accessController.CanAccess(sys.Name))
                            {
                                Console.WriteLine("Access granted."); // Başarılı erişim simülasyonu[cite: 5]
                            }
                            else
                            {
                                // Başarısız erişim simülasyonu ve red sebebi[cite: 5]
                                Console.WriteLine($"Access denied.\nReason: {emp.GetType().Name} does not have production permission.");
                            }
                        }
                        break;

                    case "5": // Çalışan erişim raporu
                        Console.WriteLine("\n--- Erişim Raporları ---");
                        bool reportGenerated = false;
                        for (int i = 0; i < empCount; i++)
                        {
                            // Sadece IAuditable (Manager, SystemAdministrator) olanlar rapor üretebilir
                            if (employees[i] is IAuditable auditor)
                            {
                                auditor.GenerateAccessReport();
                                reportGenerated = true;
                            }
                        }
                        if (!reportGenerated) Console.WriteLine("Sistemde rapor üretecek yetkiye sahip çalışan yok.");
                        break;

                    case "6": // Kullanıcı aktifleştir
                        Console.Write("Aktifleştirilecek Çalışan ID: ");
                        int activeId = int.Parse(Console.ReadLine());
                        for (int i = 0; i < empCount; i++)
                        {
                            if (employees[i].Id == activeId)
                            {
                                employees[i].IsActive = true;
                                Console.WriteLine($"{employees[i].Name} başarıyla aktifleştirildi.");
                            }
                        }
                        break;

                    case "7": // Kullanıcı devre dışı bırak
                        Console.Write("Devre dışı bırakılacak Çalışan ID: ");
                        int passiveId = int.Parse(Console.ReadLine());
                        for (int i = 0; i < empCount; i++)
                        {
                            if (employees[i].Id == passiveId)
                            {
                                employees[i].IsActive = false;
                                Console.WriteLine($"{employees[i].Name} başarıyla devre dışı bırakıldı.");
                            }
                        }
                        break;

                    case "8": // Çıkış
                        isRunning = false;
                        Console.WriteLine("Sistemden çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
            
        }
    }
}
