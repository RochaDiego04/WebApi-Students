namespace WEBAPI_Diego_Rocha.Repository
{
    public class DataAccess
    {
        private string connectionStringSQL;

        public string ConnectionStringSQL { get => connectionStringSQL; }

        public DataAccess(string ConnectionSQL)
        {
            this.connectionStringSQL = ConnectionSQL;
        }
    }
}
