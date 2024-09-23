using GraphQL.Types;
using GraphQlwithEF.Models;

namespace GraphQlwithEF.GraphQL.Types;

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(x => x.Id).Description("Product ID");
        Field(x => x.Name).Description("Product Name");
        Field(x => x.Price).Description("Product Price");
        Field<CategoryType>("category")
         .Resolve(context => context.Source.Category);
        Field<ProductDetailType>("productDetail")
            .Resolve(context => context.Source.ProductDetail);
    }
}