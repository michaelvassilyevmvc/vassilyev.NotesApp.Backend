﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace NotesApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NotesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<INotesDbContext>(provider => provider.GetService<INotesDbContext>());
            return services;
        }
    }
}
