# GraphQL With Entity Framework Application

This project is a demonstration of building a GraphQL API using ASP.NET Core and Entity Framework Core. It showcases basic CRUD operations for categories, products, and product details.

## What is GraphQL?

GraphQL is a query language for APIs that allows clients to request only the data they need. It provides a flexible and efficient alternative to traditional REST APIs.

### Key Features

- Flexible data retrieval with a single request.
- Strongly typed schema for better data management.
- Single endpoint for all queries and mutations.

## Project Features

- **Categories**: Create, update, delete, and list categories.
- **Products**: Create, update, delete, and list products.
- **Product Details**: Create, update, delete, and list product details.

## Installation

**Run Database Migrations**:
   - Using the .NET CLI   
   `dotnet ef database update`   
   - Using Package Manager Console   
   `Update-Database`

## Example Queries and Mutations

Get All Products
```
query{
    products {
    id
    name
    price
    category {
      id
      name
    }
    productDetail{
      description
    }
  }
}
```
Create Category
```
mutation {
  createCategory(category: { name: "New Category" }) {
    id
    name
  }
}
```
Update Product
```
mutation {
  updateProduct(id: 1, product: { name: "Updated Product", price: 150, categoryId: 1 }) {
    id
    name
    price
  }
}
```
Delete Product Detail
```
mutation{
  deleteProductDetail(id: 1)
}
```
