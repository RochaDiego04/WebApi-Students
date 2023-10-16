using System.Data;
using System.Data.SqlClient;
using WEBAPI_Diego_Rocha.Models;

namespace WEBAPI_Diego_Rocha.Repository
{
    public class StudentsSQLServer : iStudentsInMemory
    {
        private string ConnectionString;

        public StudentsSQLServer(DataAccess connectionString)
        {
            ConnectionString = connectionString.ConnectionStringSQL;
        }

        private SqlConnection connection()
        {
            return new SqlConnection(ConnectionString);
        }
        public void CreateStudent(Student student)
        {
            SqlConnection sqlConnection = connection();
            SqlCommand cmd = null;
            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.SubmitStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = student.Name;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = student.Age;
                cmd.Parameters.Add("@EnrollmentNumber", SqlDbType.NVarChar, 20).Value = student.EnrollmentNumber;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error setting up a new student occurred" + ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public void DeleteStudent(string enrollmentNumber)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(string enrollmentNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
