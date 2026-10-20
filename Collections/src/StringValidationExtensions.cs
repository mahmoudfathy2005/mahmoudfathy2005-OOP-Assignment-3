using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollectionsApp
{
    public static class StringValidationExtensions
    {
        public static bool IsValidEgyptianPhone(this string? phone)
        {
            if(string.IsNullOrWhiteSpace(phone)) return false;

            const string pattern = @"^(?:(?:01[0125])[0-9]{8}|\+20(?:1[0125])[0-9]{8})$";

            return Regex.IsMatch(phone, pattern);

        }

        public static bool IsValidEgyptianNationalId(this string? nationalId ) { 

            if(string.IsNullOrWhiteSpace(nationalId)) return false;

            const string pattern = @"^[23][0-9]{13}$";

            return Regex.IsMatch(nationalId, pattern);
        }
    }
}
