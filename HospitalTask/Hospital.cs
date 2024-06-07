using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    internal class Hospital
    {
        public int id = 1;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Doctor>Doctors=new List<Doctor>();
        public Hospital(string name)
        {
            Id = id++;
            Doctors = new List<Doctor>();
            Name = name;

        }
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }

        public void ViewAllDoctors()
        {
            foreach (var doctor in Doctors)
            {
                doctor.GetDetails();
            }
        }
    }
}
