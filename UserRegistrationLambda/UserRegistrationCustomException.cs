using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationLambda
{
    public class UserRegistrationCustomException:Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            USER_ENTERED_EMPTY,
            USER_ENTERED_LESSTHAN_MINIMUM_LENGTH,
            USER_ENTERED_NUMBER,
            USER_ENTERED_LOWERCASE,
            USER_ENTERED_SPECIAL_CHARACTER,
        }
        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
