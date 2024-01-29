using EmpleadosApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmpleadosApp.Data
{
    public class EmployeeData
    {
        string connectionString = "Data Source=ENVY\\SQLEXPRESS;Initial Catalog=EmpleadosDemo;Integrated Security=True;Encrypt=False";

        public IEnumerable<EmployeeModel> GetAll()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, FirstName, LastName, Phone FROM Employees;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeModel employeeModel = new EmployeeModel();
                            employeeModel.Id = Convert.ToInt32(reader["Id"]);
                            employeeModel.FirstName = reader["FirstName"].ToString();
                            employeeModel.LastName = reader["LastName"].ToString();
                            employeeModel.Phone = reader["Phone"].ToString();

                            employeeList.Add(employeeModel);
                        }
                    }
                }
            }

            return employeeList;
        }

        public EmployeeModel ?GetById(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, FirstName, LastName, Phone FROM Employees
                                            WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);  

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {      
                            employeeModel.Id = Convert.ToInt32(reader["Id"]);
                            employeeModel.FirstName = reader["FirstName"].ToString();
                            employeeModel.LastName = reader["LastName"].ToString();
                            employeeModel.Phone = reader["Phone"].ToString();
                        }
                    }
                }
            }

            return employeeModel;
        }

        public void Add(EmployeeModel employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Employees 
                                           VALUES(@FirstName, @LastName, @Phone)";
                    
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(EmployeeModel employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Employees 
                                           SET FirstName = @FirstName,
                                           LastName = @LastName,
                                           Phone = @Phone
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@Id", employee.Id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqLConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqLCommand())
                {
                    command.Connection = connection;
                    command.ComandText = @"DELETE FROM Employees WHERE Id=@Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ComandType = ComandTyper.Text;
                    command.ExecuteNonQuery();

                }  
            }
        }
    }
}
