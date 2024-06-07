using System.Globalization;

namespace HospitalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital=new Hospital("InterNationalHospital");

            while (true)
            {
                     MainDesc:   Console.WriteLine("    __ Menu __ \n\n" +
                     "1 - Hekim Elave Et \n" +
                     "2 - Butun Hekimleri gor \n" +
                     "3 - Randevu Hazirla \n" +
                     "4 - Hekim Randevularini Goster \n" +
                     "0 - Cixish");
                string input=Console.ReadLine();
                int option;
                bool isSuccessed=int.TryParse(input, out option);
                if (isSuccessed)
                {
                    switch ((Operations)option)
                    {
                        case Operations.Exit:
                            return;
                        case Operations.AddDoctor:
                            DoctorNameDesc: Console.WriteLine("Hekimin Adini elave edin");
                            string doctNameOfAdd=Console.ReadLine();
                            if (!doctNameOfAdd.isValidDoctorName())
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto DoctorNameDesc;
                            }
                             DoctorSurNameDesc: Console.WriteLine("Hekimin Soyadini elave edin");
                            string doctSurNameOfAdd=Console.ReadLine();
                            if (!doctSurNameOfAdd.isValidDoctorSurName())
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto DoctorSurNameDesc;
                            }
                            DoctorProfessionDesc: Console.WriteLine("Hekimin ixtisasini elave edin");
                            string doctProfessionOfAdd=Console.ReadLine();
                            if (!doctProfessionOfAdd.isValidDoctorProfession())
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto DoctorProfessionDesc;
                            }
                            foreach (var doct in hospital.Doctors)
                            {
                                if (doct.Name.ToLower()==doctNameOfAdd.ToLower() &&
                                    doct.SurName.ToLower()==doctSurNameOfAdd.ToLower() &&
                                    doct.Profession.ToLower()==doctProfessionOfAdd.ToLower())
                                {
                                    Console.WriteLine(ErrorMessages.AlreadyExistDoctor);
                                    goto DoctorNameDesc;
                                }
                            }
                            hospital.AddDoctor(new Doctor(doctNameOfAdd,doctSurNameOfAdd,doctProfessionOfAdd));
                            Console.WriteLine("hekim elave edildi");
                            break;
                        case Operations.ViewAllDoctors:
                            if (hospital.Doctors.Count==0)
                            {
                                Console.WriteLine(ErrorMessages.NotAddedDoctor);
                            }
                            else
                            {
                                hospital.ViewAllDoctors();
                            }
                            break;
                        case Operations.ScheduleAppointment:
                            if (hospital.Doctors.Count == 0)
                            {
                                Console.WriteLine(ErrorMessages.NotAddedDoctor);
                                goto MainDesc;
                            }
                           RandevuDesc:  Console.WriteLine("Randevu ucun hekim secin ");
                            hospital.ViewAllDoctors();
                            Console.WriteLine(" secdiyiniz hekimin id-ni daxil edin");
                            input=Console.ReadLine();
                            int doctorId;
                            isSuccessed = int.TryParse(input, out doctorId);
                            if (!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto RandevuDesc;
                            }
                            var existDoctor =hospital.Doctors.FirstOrDefault(d=>d.Id==doctorId);
                           
                            if (existDoctor is null)
                            {
                                Console.WriteLine(ErrorMessages.NotFoundDoctor);
                                goto RandevuDesc;
                            }

                             RandevuForPatientDesc: Console.WriteLine(" Xeste adini daxil edin :");
                            string patientNameOfRandevu=Console.ReadLine();
                            if (!patientNameOfRandevu.isValidPatientName())
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto RandevuForPatientDesc;
                            }
                              StartDateDesc: Console.WriteLine(" qebul baslama vaxtini qeyd edin (dd.MM.yyyy HH:mm)");
                            input=Console.ReadLine();
                            DateTime startDate;
                            isSuccessed = DateTime.TryParseExact(input,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.RoundtripKind,out startDate);
                            if(!isSuccessed)
                            {
                                Console.WriteLine( ErrorMessages.InvalidDateFormat.Replace("{start/end}","baslama"));
                                goto StartDateDesc;
                            }
                             EndDateDesc: Console.WriteLine(" qebul bitme vaxtini qeyd edin (dd.MM.yyyy HH:mm)");
                            input=Console.ReadLine();
                            DateTime endTime;
                            isSuccessed = DateTime.TryParseExact(input,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.RoundtripKind,out endTime);
                            if(!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidDateFormat.Replace("{start/end}", "bitme"));
                                goto EndDateDesc;
                            }
                            if (endTime<=startDate)
                            {
                                Console.WriteLine(ErrorMessages.WrongGreaterDate);
                                goto EndDateDesc;
                            }
                            foreach (var appt in existDoctor.Appointments)
                            {
                                if (appt.ChekingAppointment(startDate,endTime))
                                {
                                       Console.WriteLine(ErrorMessages.NotEmptyOfDateRange);
                                    goto StartDateDesc;
                                }
                            }
                            existDoctor.Appointments.Add(new Appointment(patientNameOfRandevu,startDate,endTime));
                            Console.WriteLine("randevu elave olundu");
                            break;
                        case Operations.ViewAppointmentsOfDoctor:
                            if (hospital.Doctors.Count==0)
                            {
                                Console.WriteLine(ErrorMessages.NotFoundDoctorOfRandevu);
                                goto MainDesc;
                            }
                            hospital.ViewAllDoctors();
                             ViewAllRandevuOfDoctor:
                            Console.WriteLine("randveularini gormekistediyiniz hekimin id-ni daxil edin");
                            input=Console.ReadLine();
                            int viewDoctorId;
                            isSuccessed = int.TryParse(input, out viewDoctorId);
                            if (!isSuccessed)
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat);
                                goto ViewAllRandevuOfDoctor;
                            }
                            var existDoctorOfViewRandevu = hospital.Doctors.FirstOrDefault(x=>x.Id==viewDoctorId);
                            if (existDoctorOfViewRandevu is null)
                            {
                                Console.WriteLine(ErrorMessages.NotFoundRandevuOfDoctor);
                                goto ViewAllRandevuOfDoctor;
                            }
                            Console.WriteLine($"{existDoctorOfViewRandevu.Name} hekimin Randevulari");
                            foreach (var apt in existDoctorOfViewRandevu.Appointments)
                            {
                                apt.GetDetails();
                            }
                            break;
                        default:
                            Console.WriteLine(ErrorMessages.InvalidFormat);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(ErrorMessages.InvalidFormat);
                }
            }
            
            
        }
    }
}
