using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TechConference.Data;
using Microsoft.EntityFrameworkCore;
using TechConference.Data.GraphQL;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Caching;

using GraphQL.SystemTextJson;
using TechConference.Repository;

namespace TechConference
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
            services.AddControllers();
            services.AddDbContext<TechConferenceDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:TechConference"]));

            services.AddScoped<SessionRepository>();

            services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
            services.AddScoped<TechConferenceSchema>();

            services.AddGraphQL().
                AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);


            //services.AddGraphQL(o => { o.NameConverter })
            //    .AddSystemTextJson()
            //    .AddGraphTypes(ServiceLifetime.Scoped);
            //services.AddGraphQL(b => b
            //   //.AddSchema<TechConferenceSchema>()
            //   .AddSystemTextJson()
            //   .AddMemoryCache()
            //   .AddApolloTracing(options => options.RequestServices!.GetRequiredService<IOptions<GraphQLSettings>>().Value.EnableMetrics));

            //services.AddGraphQL(b => b

            //);
            //    //.AddGraphTypes(ServiceLifetime.Scoped);
            //    //.AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TechConferenceDbContext dbContext)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseGraphQL<TechConferenceSchema>();

            app.UseGraphQLPlayground();

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            dbContext.Seed();
        }
    }
}
