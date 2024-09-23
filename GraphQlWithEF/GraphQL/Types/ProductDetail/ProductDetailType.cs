using GraphQL.Types;
using GraphQlwithEF.Models;

namespace GraphQlwithEF.GraphQL.Types;

public class ProductDetailType : ObjectGraphType<ProductDetail>
{
    public ProductDetailType()
    {
        Field(x => x.Id).Description("ProductDetail ID");
        Field(x => x.Description).Description("Description of the Product");
        Field<ProductType>("product").Resolve(context => context.Source.Product);
    }
}