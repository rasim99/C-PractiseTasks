using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseC_
{
    internal static class Errormessages
    {
        public static string InvalidIntFormat= " daxil edilmis {int} duzgun formatda deyil";
        public static string InvalidDateTimeFormat= " daxil edilmis tarix duzgun formatda deyil";
        public static string InvalidGroupNameFormat = "Daxil edilmis group ad formati duzgun deyil!!! Hemcinin minimum 3 xarakter olmalidi";
        public static string InvalidStudentNameFormat= "Daxil edilmis telebe ad formati duzgun deyil!!! Hemcinin minimum 3 xarakter olmalidi";
        public static string InvalidStudentSurNameFormat= "Daxil edilmis telebe soyad formati duzgun deyil!!! Hemcinin minimum 4 xarakter olmalidi";
        public static string InvalidStudentGradeNameFormat= "Daxil edilmis fenn adiformati duzgun deyil!!! Hemcinin minimum 4 xarakter olmalidi";
        public static string AlreadyExists = "{Name} artiq movcuddur";
        public static string MinimalLimit = "Minimal limit {int} olmalidir";
        public static string MaximalLimit = "Maximal limit {int} olmalidir";
        public static string NotFoundElement = "Hech bir {name} movcud deyil";
        public static string NotFoundForInput = "daxil edilen {prop} ucun uygun {name} tapilmadi";
        public static string NotFoundElementOfOperation = "her hansisa {name} yaradildiqdan sonra bu emeliyyati heyata kecire bilersiz";
        public static string OutOfStudentCount = "telbelerin sayi limiti kece bilmez";
        public static string NotFoundStudentOnCourse = "kursda telebe yoxdur";
        public static string NotFoundStudentOnGroup = "qrupda telebe yoxdur";
        public static string RangeOfStudentGrade = "bal 0 - 100 araliginda ola biler";
    };

}
