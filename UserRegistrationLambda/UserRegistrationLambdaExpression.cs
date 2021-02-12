using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserRegistrationLambda
{
    public class UserRegistrationLambdaExpression
    {
        string firstNamePattern = "^[A-Z]{1}[a-z]{2,}$";
        public bool FirstName(string patternFirstName) => Regex.IsMatch(patternFirstName, firstNamePattern);//lambda Expression


        /// <summary>
        /// First Name Custom Exception
        /// </summary>
        /// <param name="patternFirstName"></param>
        /// <returns></returns>
        public string FirstNameLambda(string patternFirstName)
        {
            bool result = FirstName(patternFirstName);
            try
            {
                if (result == false)
                {

                    if (patternFirstName.Equals(string.Empty))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_EMPTY, "FirstName should not be empty");
                    }
                    
                    if (patternFirstName.Length < 3)
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_LESSTHAN_MINIMUM_LENGTH, "FirstName should contains atleast three characters");
                    }
                    if (patternFirstName.Any(char.IsDigit))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_NUMBER, "FirstName should not contains number");
                    }
                    if (!char.IsUpper(patternFirstName[0]))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_LOWERCASE, "FirstName first letter should not be a lowercase");
                    }
                    if (patternFirstName.Any(char.IsLetterOrDigit))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_SPECIAL_CHARACTER, "FirstName should not contains special characters");
                    }

                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "FirstName is valid";
        }

    }
}
