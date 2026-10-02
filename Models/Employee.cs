using System;
using System.Collections.Generic;
using System.Text;

namespace AccessFlow.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }

        private string password1;

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
            IsActive = true;
        }

        public Employee(int id, string name, string department) : this(id, name)
        {
            Department = department;
        }

        public Employee(int id, string name, string department, string password) : this(id, name, department)
        {
            password1 = password;
        }

        protected bool VerifyPassword(string inputPassword)
        {
            return password1 == inputPassword;
        }

        public virtual string GetAccessLevel()
        {
            return "None";
        }
    }
}
