﻿using IWantApp_API.Domain.Products;
using IWantApp_API.Infra.Data;

namespace IWantApp_API.EndPoints.Categories
{
    public class CategoryPost
    {
        public static string Template => "/categories";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                CreatedBy = "Teste",
                CreatedOn = DateTime.Now,
                EditedBy = "Teste",
                EditedOn = DateTime.Now
            };
            context.Categories.Add(category);
            context.SaveChanges();

            return Results.Created($"/categories/{category.Id}", category.Id);
        }
    }
}