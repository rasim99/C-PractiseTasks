using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalTask
{
    internal static class StringExtensions
    {
        public static bool isValidDoctorName(this string name)
        {
            if (Regex.IsMatch(name,@"^[a-zA-Z]+$") &&name.Length>2)
            {
                return true;
            }
            return false;
        }
        public static bool isValidDoctorSurName(this string surname)
        {
            if (Regex.IsMatch(surname,@"^[a-zA-Z]+$") &&surname.Length>4)
            {
                return true;
            }
            return false;
        }
        public static bool isValidDoctorProfession(this string profession)
        {
            if (Regex.IsMatch(profession,@"^[a-zA-Z]+$") &&profession.Length>2)
            {
                return true;
            }
            return false;
        }

        public static bool isValidPatientName(this string name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z]+$") && name.Length > 2)
            {
                return true;
            }
            return false;
        }
    }
}
