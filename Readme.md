# Kurumsal Erişim ve Yetkilendirme Simülatörü (Corporate Access Simulator)

Bu proje, bir şirketteki farklı çalışan tiplerinin (Developer, Manager, SystemAdministrator, Intern) çeşitli kurumsal sistemlere (Production Server, Source Code Repository vb.) erişim haklarını simüle eden konsol tabanlı bir uygulamadır. 

Proje, Nesne Yönelimli Programlama (OOP) prensiplerini pekiştirmek amacıyla geliştirilmiştir.

## 🚀 Kullanılan Teknolojiler ve Prensipler
- **C# & .NET Console Application**
- **Kalıtım (Inheritance):** Tüm çalışan tiplerinin temel `Employee` sınıfından türetilmesi.
- **Kapsülleme (Encapsulation):** Çalışan şifrelerinin dış erişime kapatılması ve sadece metotlar aracılığıyla doğrulanması.
- **Çok Biçimlilik (Polymorphism):** Aynı metoda (örn. `GetAccessLevel()`) farklı alt sınıfların kendi erişim seviyelerine göre yanıt vermesi.
- **Arayüzler (Interfaces):** Yetkilendirme (`IAuthenticatable`), erişim kontrolü (`IAccessController`) ve denetim/raporlama (`IAuditable`) işlemlerinin sözleşmelere bağlanması.

## 🏗️ Sistem Mimarisi (UML)

Sınıfların ve uyguladıkları arayüzlerin (interface) hiyerarşisi aşağıdaki gibidir:

```text
           Employee
              |
   -------------------------
   |       |       |       |
Developer Manager Admin   Intern

Developer ------- IAuthenticatable
Developer ------- IAccessController

Manager --------- IAuthenticatable
Manager --------- IAccessController
Manager --------- IAuditable