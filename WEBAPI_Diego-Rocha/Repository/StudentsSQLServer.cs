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
        public async Task AsyncCreateStudent(Student student)
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
                await cmd.ExecuteNonQueryAsync();
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
            await Task.CompletedTask;
        }

        public async Task AsyncDeleteStudent(string enrollmentNumber)
        {
            SqlConnection sqlConnection = connection();
            SqlCommand cmd = null;
            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.DeleteStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EnrollmentNumber", SqlDbType.NVarChar, 20).Value = enrollmentNumber;
                await cmd.ExecuteNonQueryAsync();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception("An error deleting the student occurred" + ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public async Task<Student> AsyncGetStudent(string enrollmentNumber)
        {
            SqlConnection sqlConnection = connection();
            SqlCommand cmd = null;
            Student s = null;
            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.GetStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EnrollmentNumber", SqlDbType.NVarChar, 20).Value = enrollmentNumber;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if(reader.Read())
                {
                    s = new Student
                    {
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"].ToString()),
                        EnrollmentNumber = reader["EnrollmentNumber"].ToString()
                    };
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error returning a new student occurred" + ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return s;
        }

        public async Task<IEnumerable<Student>> AsyncGetStudents()
        {
            SqlConnection sqlConnection = connection();
            SqlCommand cmd = null;
            List<Student> students = new List<Student>();
            Student s = null;
            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.GetStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    s = new Student
                    {
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"].ToString()),
                        EnrollmentNumber = reader["EnrollmentNumber"].ToString()
                    };
                    students.Add(s);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error returning a new student occurred" + ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return students;
        }

        public async Task AsyncUpdateStudent(Student student)
        {
            SqlConnection sqlConnection = connection();
            SqlCommand cmd = null;
            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.EditStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 500).Value = student.Name;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = student.Age;
                cmd.Parameters.Add("@EnrollmentNumber", SqlDbType.NVarChar, 20).Value = student.EnrollmentNumber;
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error updating a student occurred" + ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            await Task.CompletedTask;
        }
    }
}
