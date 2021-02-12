using NUnit.Framework;
using UserRegistrationLambda;
namespace NUnitTestProject
{
    public class Tests
    {
        UserRegistrationLambdaExpression userRegistration;
        [SetUp]
        public void Setup()
        {
            userRegistration = new UserRegistrationLambdaExpression();
        }

        /// <summary>
        /// TC-1 Throw Custom Exception for Invalid FirstName
        /// </summary>
        [TestCase("Dilip")]//Valid Input
        [TestCase("Ra")]//Invalid Input- Exception Occured 
        public void GivenFirstNameExpectingThrowCustomException(string firstName)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.FirstNameLambda(firstName);
            }
            catch (UserRegistrationCustomException exception)
            {
                string expected = "FirstName should contains atleast three characters";
                Assert.AreEqual(expected, exception.Message);
            }
            
        }
        [TestCase("Rathod")]//valid Input
        [TestCase("Ra")]//Invalid Input - Exception Occured and handled by custome exception
        public void Given_LastName_Expecting_ThrowCustomException(string lastName)
        {
            string actual = " ";
            try
            {
                actual = userRegistration.LastNameLambda(lastName);
            }
            catch (UserRegistrationCustomException exception)
            {
                string exptected = "LastName should contains atleast three characters";
                Assert.AreEqual(exptected, exception.Message);
            }
        }

    }
}