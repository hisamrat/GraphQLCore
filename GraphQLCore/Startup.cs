using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLCore.Data;
using GraphQLCore.Interfaces;
using GraphQLCore.Mutation;
using GraphQLCore.Query;
using GraphQLCore.Schema;
using GraphQLCore.Services;
using GraphQLCore.Type;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GraphQLDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddScoped<IProduct, ProductService>();
            services.AddTransient<ProductType>();
            services.AddTransient<ProductQuery>();
            services.AddTransient<ProductMutation>();
            services.AddTransient<ISchema,ProductSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;

            }).AddSystemTextJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
