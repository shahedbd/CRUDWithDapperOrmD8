using System.Data;

namespace CRUDWithDapperOrmD8.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
