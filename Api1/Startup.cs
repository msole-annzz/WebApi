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
using Microsoft.EntityFrameworkCore;
using Api1.Models;
using Microsoft.AspNetCore.Http;
// ниже дл€ настройки swagger
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;//дл€ использовани€ в классе OpenApiInfo
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace Api1
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
            ////ƒобавл€ет контекст базы данных в контейнер внедрени€ зависимостей.
            //// ”казывает, что контекст базы данных будет использовать базу данных в пам€ти.
            //services.AddDbContext<TodoContext>(opt =>
              //opt.UseInMemoryDatabase("TodoList"));
           
            
            //services.AddDbContext<FilesContext>(opt =>
            // opt.UseInMemoryDatabase("FilesList"));

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DocContext>(options =>
                options.UseSqlServer(connection));




            //конвертирует Enum в Json, благодар€ этому на странице в cswagger отображаетс€ категори€ текстом, а не цифрами
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            //подключаем swagger
            //ƒействие по настройке, передаваемое в метод AddSwaggerGen, 
            //можно использовать дл€ добавлени€ таких сведений, как автор, 
            //лицензи€ и описание
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api1",
                    Description = "It's my first API ",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Olga",
                        Email = "annzz@yandex.ru",
                        //Email = string.Empty,
                        //Url = new Uri("https://twitter.com/spboyer"),
                    },
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Use under LICX",
                    //    Url = new Uri("https://example.com/license"),
                    //}
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //дл€ логировани€
          
            loggerFactory.AddFile("logger.txt");
            //var logger = loggerFactory.CreateLogger("FileLogger");

            // дл€ обслуживани€ созданного документа JSON и пользовательского интерфейса Swagger.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //„тобы предоставить пользовательский интерфейс Swagger в корневом 
                //каталоге приложени€ (http://localhost:<port>/)
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
