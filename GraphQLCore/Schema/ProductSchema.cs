using GraphQLCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLCore.Mutation;

namespace GraphQLCore.Schema
{
    public class ProductSchema:GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery,ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
