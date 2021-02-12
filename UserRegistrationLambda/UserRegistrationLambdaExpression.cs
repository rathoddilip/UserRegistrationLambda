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
        string lastNamePattern = "^[A-Z]{1}[a-z]{2,}$";
        string mobileNumberPattern = "^[9]{1}[1]{1}[ ][0-9]{10}$";
        public bool FirstName(string patternFirstName) => Regex.IsMatch(patternFirstName, firstNamePattern);//lambda Expression
        public bool LastName(string patternLastName) => Regex.IsMatch(patternLastName, lastNamePattern);
        public bool MobileNumber(string patternMobileNumber) => Regex.IsMatch(patternMobileNumber, mobileNumberPattern);

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

                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "FirstName is valid";
        }
        /// <summary>
        /// LastName Custom Exception
        /// </summary>
        /// <param name="patternLastName"></param>
        /// <returns></returns>
        public string LastNameLambda(string patternLastName)
        {
            bool result = LastName(patternLastName);
            try
            {
                if (result == false)
                {

                    if (patternLastName.Equals(string.Empty))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_EMPTY, "LastName should not be empty");
                    }
                    if (patternLastName.Length < 3)
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_LESSTHAN_MINIMUM_LENGTH, "LastName should contains atleast three characters");

                    }

                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "LastName is valid";
        }
        public string MobileNumberLambda(string patternMobileNumber)
        {
            bool result = MobileNumber(patternMobileNumber);
            try
            {
                if (result == false)
                {

                    if (patternMobileNumber.Equals(string.Empty))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_EMPTY, "MobileNumber should not be empty");
                    }

                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "MobileNumber is not valid";
        }


    }
}
