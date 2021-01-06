using System;
using Application.TodoLists.Queries;
using AutoMapper;
using Core;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services.QueryHandlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCommonServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddMediatR(typeof(GetTodoByIdQuery).Assembly, typeof(GetTodoByIdQueryHandler).Assembly);
            services.AddScoped<ITodoRepository, TodoRepository>();

            //services.AddDbContext<EfContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("TodoDatabase")));


        }
    }
}
