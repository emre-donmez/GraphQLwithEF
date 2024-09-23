using GraphQL;
using GraphQL.Types;
using GraphQlwithEF.Data;
using GraphQlwithEF.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQlwithEF.GraphQL.Queries;

public class AppQuery : ObjectGraphType
{
    public AppQuery(ApplicationDbContext dbContext)
    {
        Field<CategoryType>("category")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                return dbContext.Categories
                    .Include(c => c.Products)
                        .FirstOrDefault(c => c.Id == id);
            });

        Field<ListGraphType<CategoryType>>("categories")
            .Resolve(context => dbContext.Categories
                                    .Include(c => c.Products)
                                        .ToList());

        Field<ProductType>("product")
            .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                return dbContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductDetail)
                        .FirstOrDefault(p => p.Id == id);
            });

        Field<ListGraphType<ProductType>>("products")
            .Resolve(context => dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductDetail)
                    .ToList());
    }
}