using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    internal class Doctor
    {
        private int id=1;
        public int Id { get; private set; }
        public string  Name { get; set; }
        public string  SurName { get; set; }
        public string  Profession { get; set; }
        public List<Appointment> Appointments { get; private set; }
        public Doctor(string name,string surname,string profession)
        {
            Id = id++;
            Name = name;
            SurName = surname;
            Profession = profession;
            Appointments = new List<Appointment>();
        }
        public void GetDetails()
        {
            Console.WriteLine($"Doctor's Id : {Id} Name : {Name}  Surname : {SurName}  Profession : {Profession}");
        }
    }
}
