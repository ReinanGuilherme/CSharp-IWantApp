using Dapper;
using IWantApp_API.EndPoints.Employees;
using MySqlConnector;

namespace IWantApp_API.Infra.Data
{
    public class QueryAllUsersWithClaimName
    {
        private readonly IConfiguration configuration;

        public QueryAllUsersWithClaimName(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<EmployeeResponse> Execute(int page, int rows)
        {
            //utilizar o using para abrir e fechar conexão com o banco mysql
            using (var db = new MySqlConnection(configuration.GetConnectionString("IWantDb")))
            {
                var query =
                    @"select Email, ClaimValue as Name
                    from aspnetusers u INNER JOIN aspnetuserclaims c on u.id = c.UserId and claimtype = 'Name'
                    order by Name
                    LIMIT @rows OFFSET @page";


                return db.Query<EmployeeResponse>(
                        query,
                        new { page = (page - 1), rows }
                    );

            }
        }
    }
}
