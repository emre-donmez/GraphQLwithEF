using GraphQL.Types;
using GraphQlwithEF.Models;

namespace GraphQlwithEF.GraphQL.Types;

public class CategoryType : ObjectGraphType<Category>
{
    public CategoryType()
    {
        Field(x => x.Id).Description("Category ID");
        Field(x => x.Name).Description("Category Name");
        Field<ListGraphType<ProductType>>("products").Resolve(context => context.Source.Products);
    }
}