using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore.Type
{
    public class ProductInputType:InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("price");
        }
    }
}
