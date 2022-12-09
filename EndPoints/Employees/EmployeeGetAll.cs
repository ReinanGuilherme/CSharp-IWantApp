using IWantApp_API.Domain.Products;
using IWantApp_API.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IWantApp_API.EndPoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(UserManager<IdentityUser> userManager)
        {
            var users = userManager.Users.ToList();
            var employees = users.Select(u => new EmployeeResponse(u.Email, "Name"));

            return Results.Ok(employees);
        }
    }
}
