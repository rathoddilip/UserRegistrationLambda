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
        string passwordPattern = "^[A-Z]{1}[a-zA-Z]{7,}([0-9]+)[@#$%^&*+-_]{1}$";
        string emailPattern = "^[0-9a-zA-Z]+([._+-]?[0-9a-zA-Z]+)*@[0-9A-Za-z]+.([c]{1}[o]{1}[m]{1})*([n]{1}[e]{1}[t]{1})*[,]*([.][a]{1}[u]{1})*([.][c]{1}[o]{1}[m]{1})*$";
        public bool FirstName(string patternFirstName) => Regex.IsMatch(patternFirstName, firstNamePattern);//lambda Expression
        public bool LastName(string patternLastName) => Regex.IsMatch(patternLastName, lastNamePattern);
        public bool MobileNumber(string patternMobileNumber) => Regex.IsMatch(patternMobileNumber, mobileNumberPattern);
        public bool Password(string patternPassword) => Regex.IsMatch(patternPassword, passwordPattern);
        public bool Email(string patternEmail) => Regex.IsMatch(patternEmail, emailPattern);



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
            return "MobileNumber is  valid";
        }

        public string PasswordLambda(string patternPassword)
        {
            bool result = Password(patternPassword);
            try
            {
                if (result == false)
                {

                    if (patternPassword.Equals(string.Empty))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_EMPTY, "Password should not be empty");
                    }
                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "Password is valid";
        }

        /// <summary>
        /// Email Custom Exception handling
        /// </summary>
        /// <param name="patternEmail"></param>
        /// <returns></returns>
        public string EmailLambda(string patternEmail)
        {
            bool result = Password(patternEmail);
            try
            {
                if (result == false)
                {

                    if (patternEmail.Equals(string.Empty))
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_EMPTY, "Email should not be empty");
                    }
                    if (patternEmail.Any(char.IsLetterOrDigit) == null)
                    {
                        throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.USER_ENTERED_SPECIAL_CHARACTER, "Email should contains special characters");
                    }

                }
            }

            catch (UserRegistrationCustomException exception)
            {
                throw exception;
            }
            return "Email is valid";
        }


    }
}
