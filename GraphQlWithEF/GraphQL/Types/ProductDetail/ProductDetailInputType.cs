using GraphQL.Types;

namespace GraphQlwithEF.GraphQL.Types;

public class ProductDetailInputType : InputObjectGraphType
{
    public ProductDetailInputType()
    {
        Name = "ProductDetailInput";
        Field<NonNullGraphType<StringGraphType>>("description");
        Field<NonNullGraphType<IntGraphType>>("productId");
    }
}