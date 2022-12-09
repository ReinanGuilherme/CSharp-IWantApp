﻿using IWantApp_API.Domain.Products;
using IWantApp_API.Infra.Data;

namespace IWantApp_API.EndPoints.Categories
{
    public class CategoryGetAll
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var category = context.Categories.ToList();
            var response = category.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });

            return Results.Ok(category);
        }
    }
}
