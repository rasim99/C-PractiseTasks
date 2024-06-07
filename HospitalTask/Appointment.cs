using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    internal class Appointment
    {
        private int id = 1;
        public int Id { get; private set; }
        public string PatientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Appointment(string patientName,DateTime startDate,DateTime endTime)
        {
            Id = id++;
            PatientName = patientName;
            StartDate = startDate;
            EndDate = endTime;
        }
        public bool ChekingAppointment(DateTime startDate, DateTime endTime)
        {
            if (StartDate<endTime&& EndDate>startDate)
            {
                return true;
            }
            return false;
        }
        public void GetDetails()
        {
            Console.WriteLine($"Randevu Id {Id} " +
                $" Xeste Adi {PatientName} " +
                $"Baslama vaxti  {StartDate} " +
                $" Bitme Vaxti : {EndDate}");
        }
    }
}
