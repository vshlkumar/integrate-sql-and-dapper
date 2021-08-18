using System.IO;

namespace APIApplication.Infrastructure.Models
{
    public class ConnectionStrings
    {
        public LocalMongoDb LocalMongoDb { get; set; }
        public ConnectionInfo SqlDatabase { get; set; }
    }

    public class LocalMongoDb : ConnectionBase
    {
        public string BookCollectionName { get; set; }
    }

    public class ConnectionInfo
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }

        public string FullConnectionString
        {
            get
            {
                return $"{Path.Combine(ConnectionString ?? "", Name)?.Replace("\\", "/")}";
            }
        }
    }

    public class ConnectionBase
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string Params { get; set; }
        public string FullConnectionString { 
            get {
                return $"{Path.Combine(ConnectionString ?? "", Name)?.Replace("\\","/")}{Params}";
            } 
        }
    }
}
