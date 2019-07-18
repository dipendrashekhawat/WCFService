using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class EmployeeService : IEmployeeService
    {
        string UserToken = string.Empty;

        // Login using credentials
        public string Login(string userName, string password)
        {
            if (userName == "guest1" && password == "ABC")
            {
                UserToken = OperationContext.Current.SessionId;
            }
            else
            {
                UserToken = "";
            }
            return UserToken;
        }

        // Saving Employee details
        public EmployeeDetails SaveMyEmployees(string firstName, string lastName, string department, string designation)
        {
            //Validating user token
            if (IsValidateUser())
            {
                EmployeeDetails objEmployee = new EmployeeDetails();
                objEmployee.FirstName = firstName;
                objEmployee.LastName = lastName;
                objEmployee.Department = department;
                objEmployee.Designation = designation;

                return objEmployee;
            }
            else
            {
                throw new FaultException("Invalid User token to access data.");
            }
        }

        // Fetching Employee details
        public EmployeeDetails GetMyEmployees()
        {
            //Validating user token
            if (IsValidateUser())
            {
                EmployeeDetails objEmployee = new EmployeeDetails();
                objEmployee.FirstName = "Alan";
                objEmployee.LastName = "James";
                objEmployee.Department = "IT";
                objEmployee.Designation = "Manager";

                return objEmployee;
            }
            else
            {
                throw new FaultException("Invalid User token to access data.");
            }
        }

        //Method to validate user with token
        public bool IsValidateUser()
        {
            if (OperationContext.Current.IncomingMessageHeaders.FindHeader("TokenHeader", "TokenNameSpace") == -1)
            {
                return false;
            }

            string userIdentityToken = Convert.ToString(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("TokenHeader", "TokenNameSpace"));

            if (userIdentityToken == UserToken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
