using GraphQL;
using GraphQL.Types;
using GraphQLCore.Interfaces;
using GraphQLCore.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore.Query
{
    public class ProductQuery:ObjectGraphType
    {
        public ProductQuery(IProduct product)
        {
            Field<ListGraphType<ProductType>>
                ("products", resolve: context => 
                { return product.GetAllProducts(); });

            Field<ProductType>("product", arguments: new QueryArguments
                (new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: contxt =>
                 {
                     return product.GetProductById(contxt.GetArgument<int>("id"));
                 }
                );
        }
    }
}
