using Dapper;
using IWantApp_API.Domain.Products;
using IWantApp_API.Infra.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System.Security.Claims;

namespace IWantApp_API.EndPoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
        {
            if (page == null || page == 0)
            {
                page = 1;
            }

            if (rows == null || rows == 0)
            {
                rows = 10;
            }


            return Results.Ok(query.Execute(page.Value,rows.Value));
        }
    }
}
