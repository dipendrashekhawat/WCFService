using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        string Login(string userName, string password);

        [OperationContract]
        EmployeeDetails SaveMyEmployees(string firstName, string lastName, string department, string designation);

        [OperationContract]
        EmployeeDetails GetMyEmployees();
    }

    [DataContract]
    public class EmployeeDetails
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string Designation { get; set; }
    }
}
