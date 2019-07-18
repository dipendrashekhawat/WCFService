using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel.Channels;
using System.ServiceModel;
using EmployeeServiceWebClient.EmployeeServiceRef;
using System.IO;
using System.Data;

namespace EmployeeServiceWebClient
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetEmployeeData_Click(object sender, EventArgs e)
        {
            try
            {
                MessageHeader header;
                OperationContextScope scope;
                string userToken = string.Empty;

                EmployeeServiceClient objEmployeeClient = new EmployeeServiceClient();

                userToken = objEmployeeClient.Login("guest1", "ABC");

                scope = new OperationContextScope(objEmployeeClient.InnerChannel);

                header = MessageHeader.CreateHeader("TokenHeader", "TokenNameSpace", userToken);

                OperationContext.Current.OutgoingMessageHeaders.Add(header);

                EmployeeDetails objEmployee1 = new EmployeeDetails();
                objEmployee1 = objEmployeeClient.GetMyEmployees();

                //Displaying result
                FirstName.Text = objEmployee1.FirstName;
                LastName.Text = objEmployee1.LastName;
                Department.Text = objEmployee1.Department;
                Designation.Text = objEmployee1.Designation;
                DisplayMessage.Text = "No Error";

            }
            catch (Exception ex)
            {
                DisplayMessage.Text = ex.Message;
            }
        }

        protected void ImportCSV_Click(object sender, EventArgs e)
        {
            //Upload and save the file  
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            //Create a DataTable.  
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] {   
                                new DataColumn("FirstName", typeof(string)),  
                                new DataColumn("LastName", typeof(string)),  
                                new DataColumn("Department", typeof(string)),  
                                new DataColumn("Designation",typeof(string)) 
            });

            //Read the contents of CSV file.  
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.  
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    //Execute a loop over the columns.  
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            //Bind the DataTable.  
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

}