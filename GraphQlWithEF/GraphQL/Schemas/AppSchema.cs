using GraphQL.Types;
using GraphQlwithEF.GraphQL.Mutations;
using GraphQlwithEF.GraphQL.Queries;

namespace GraphQlwithEF.GraphQL.Schemas;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<AppQuery>();
        Mutation = provider.GetRequiredService<AppMutation>();
    }
}