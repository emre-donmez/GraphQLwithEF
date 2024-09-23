using GraphQL.Types;

namespace GraphQlwithEF.GraphQL.Types;

public class ProductInputType : InputObjectGraphType
{
    public ProductInputType()
    {
        Name = "ProductInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<DecimalGraphType>>("price");
        Field<NonNullGraphType<IntGraphType>>("categoryId");
    }
}