using GraphQL;
using GraphQL.Types;
using GraphQlwithEF.Data;
using GraphQlwithEF.GraphQL.Mutations;
using GraphQlwithEF.GraphQL.Queries;
using GraphQlwithEF.GraphQL.Schemas;
using GraphQlwithEF.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ISchema, AppSchema>();
builder.Services.AddScoped<CategoryType>();
builder.Services.AddScoped<ProductType>();
builder.Services.AddScoped<ProductDetailType>();
builder.Services.AddScoped<CategoryInputType>();
builder.Services.AddScoped<ProductInputType>();
builder.Services.AddScoped<ProductDetailInputType>();

builder.Services.AddScoped<AppQuery>();
builder.Services.AddScoped<AppMutation>();

builder.Services.AddGraphQL(x => x.AddAutoSchema<ISchema>().AddSystemTextJson());

var app = builder.Build();

app.UseHttpsRedirection();
app.UseGraphQL<ISchema>();

app.UseGraphQLPlayground();
app.Run();