using GraphQL;
using GraphQL.Types;
using GraphQlwithEF.Data;
using GraphQlwithEF.GraphQL.Types;
using GraphQlwithEF.Models;

namespace GraphQlwithEF.GraphQL.Mutations;

public class AppMutation : ObjectGraphType
{
    public AppMutation(ApplicationDbContext dbContext)
    {
        Field<CategoryType>("createCategory")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }
            ))
            .Resolve(context =>
            {
                var categoryInput = context.GetArgument<Category>("category");
                var category = new Category { Name = categoryInput.Name };

                dbContext.Categories.Add(category);
                dbContext.SaveChanges();

                return category;
            });

        Field<CategoryType>("updateCategory")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<CategoryInputType>> { Name = "category" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var categoryInput = context.GetArgument<Category>("category");
                var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null) throw new ExecutionError("Category not found.");

                category.Name = categoryInput.Name;

                dbContext.SaveChanges();
                return category;
            });

        Field<BooleanGraphType>("deleteCategory")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);

                if (category == null) throw new ExecutionError("Category not found.");

                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
                return true;
            });

        Field<ProductType>("createProduct")
          .Arguments(new QueryArguments(
              new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
          ))
          .Resolve(context =>
          {
              var productInput = context.GetArgument<Product>("product");
              var product = new Product
              {
                  Name = productInput.Name,
                  Price = productInput.Price,
                  CategoryId = productInput.CategoryId
              };

              dbContext.Products.Add(product);
              dbContext.SaveChanges();

              return product;
          });

        Field<ProductType>("updateProduct")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var productInput = context.GetArgument<Product>("product");
                var product = dbContext.Products.FirstOrDefault(p => p.Id == id);

                if (product == null) throw new ExecutionError("Product not found.");

                product.Name = productInput.Name;
                product.Price = productInput.Price;
                product.CategoryId = productInput.CategoryId;

                dbContext.SaveChanges();
                return product;
            });

        Field<BooleanGraphType>("deleteProduct")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var product = dbContext.Products.FirstOrDefault(p => p.Id == id);

                if (product == null) throw new ExecutionError("Product not found.");

                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
                return true;
            });

        Field<ProductDetailType>("createProductDetail")
           .Arguments(new QueryArguments(
               new QueryArgument<NonNullGraphType<ProductDetailInputType>> { Name = "productDetail" }
           ))
           .Resolve(context =>
           {
               var productDetailInput = context.GetArgument<ProductDetail>("productDetail");
               var productDetail = new ProductDetail
               {
                   Description = productDetailInput.Description,
                   ProductId = productDetailInput.ProductId
               };

               dbContext.ProductDetails.Add(productDetail);
               dbContext.SaveChanges();

               return productDetail;
           });

        Field<ProductDetailType>("updateProductDetail")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<ProductDetailInputType>> { Name = "productDetail" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var productDetailInput = context.GetArgument<ProductDetail>("productDetail");
                var productDetail = dbContext.ProductDetails.FirstOrDefault(pd => pd.Id == id);

                if (productDetail == null) throw new ExecutionError("ProductDetail not found.");

                productDetail.Description = productDetailInput.Description;
                productDetail.ProductId = productDetailInput.ProductId;

                dbContext.SaveChanges();
                return productDetail;
            });

        Field<BooleanGraphType>("deleteProductDetail")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<int>("id");
                var productDetail = dbContext.ProductDetails.FirstOrDefault(pd => pd.Id == id);

                if (productDetail == null) throw new ExecutionError("ProductDetail not found.");

                dbContext.ProductDetails.Remove(productDetail);
                dbContext.SaveChanges();
                return true;
            });
    }
}