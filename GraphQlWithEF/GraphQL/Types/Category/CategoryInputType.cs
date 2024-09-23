using GraphQL.Types;

namespace GraphQlwithEF.GraphQL.Types;

public class CategoryInputType : InputObjectGraphType
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field<NonNullGraphType<StringGraphType>>("name");
    }
}