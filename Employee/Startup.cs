using Employee.Entities;
using Employee.Helpers;
using Employee.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Employee
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("TestDb"));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                {
                    config.Authority = "https://localhost:44357/";
                    config.Audience = "EmployeeApi";
                    config.RequireHttpsMetadata = false;
                });
            services.AddHttpClient();
            services.AddControllers();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {

            context.Users.Add(new UserEntity { Id = 1, Name = "client_1", Password = "client_password_1" });

            for (int i = 1; i < 11; i++)
            {
                context.Employees.Add(new EmployeeEntity
                {
                    Id = i,
                    Name = "Employe" + i.ToString(),
                    LastName = "Employe" + i.ToString() + " LastName",
                    Address = "Employee" + i.ToString() + " Address",
                    Department = "Employee" + i.ToString(),
                    Phone = "Employee" + i.ToString() + " Phone"
                });
            }

            context.SaveChanges();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
