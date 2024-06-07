using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PractiseC_
{
    internal static class StringExtensions
    {
        public static bool isValidGroupName(this string name) 
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length > 2)
            {
                return true;
            }
            return false;

        }   
        public static bool isValidStudentName(this string name) 
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length > 2 && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;

        }
        public static bool isValidStudentSurName(this string surName) 
        {
            if (!string.IsNullOrWhiteSpace(surName) && surName.Length > 3 && Regex.IsMatch(surName, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;

        }  
        public static bool isValidStudentGradeName(this string gradeName) 
        {
            if (!string.IsNullOrWhiteSpace(gradeName) && gradeName.Length > 3 && Regex.IsMatch(gradeName, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;

        }
    }
}
