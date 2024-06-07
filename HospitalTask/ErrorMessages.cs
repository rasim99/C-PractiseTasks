using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    internal static class ErrorMessages
    {
        public static string InvalidFormat = "Yanlish format!!";
        public static string NotFoundRandevuOfDoctor = "hemin hekim ucun hecbir randevu elave edilmeyib";
        public static string NotFoundDoctorOfRandevu = "hec bir hekim yoxdur Hekim elave edin" +
            " daha sonra Randevu yaradilmali ve yekunda elave olunmus randevulari gore bilersiz ";
            public static string NotAddedDoctor ="hech bir hekim elave edilmeyib";
            public static string NotFoundDoctor ="hekim tapilmadi";
        public static string InvalidDateFormat = "yanlish {start/end} tarixi  formati !!!";
        public static string WrongGreaterDate = "bitme tarixi baslama tarixinden kicik veya beraber ola bilmez!!";
        public static string NotEmptyOfDateRange = "hemin vaxt araligi artiq doludur";
        public static string AlreadyExistDoctor = "hekim artiq movcuddur"
;    }
}
