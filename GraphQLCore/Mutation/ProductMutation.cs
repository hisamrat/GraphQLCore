using GraphQL;
using GraphQL.Types;
using GraphQLCore.Interfaces;
using GraphQLCore.Models;
using GraphQLCore.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct product)
        {
            Field<ProductType>("createProduct", arguments: new QueryArguments
               (new QueryArgument<ProductInputType> { Name = "product" }),
               resolve: contxt =>
               {
                   return product.AddProduct(contxt.GetArgument<Product>("product"));
               }
               );
            Field<ProductType>("updateProduct", arguments: new QueryArguments
              (new QueryArgument<IntGraphType> { Name = "id" },new QueryArgument<ProductInputType> { Name = "product" }),
              resolve: contxt =>
              {
                  var prodcutobj = contxt.GetArgument<Product>("product");
                  var prodcutid = contxt.GetArgument<int>("id");
                  return product.UpdateProduct(prodcutid, prodcutobj);
              }
              );

            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments
             (new QueryArgument<IntGraphType> { Name = "id" }),
             resolve: contxt =>
             {
              
                 var prodcutid = contxt.GetArgument<int>("id");
                  product.DeleteProduct(prodcutid);
                 return "This product is deleted";
             }
             );
        }
    }
}
