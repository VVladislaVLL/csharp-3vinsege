using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.CourseWorks.Any())
            {
                context.CourseWorks.AddRange(
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS", Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 275
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 48.95m
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 19.50m
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 34.95m
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 79500
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 16
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 29.95m
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 75
                    },
                    new CourseWork
                    {
                        TopicOfCourseWork = "Game on native JS",
                        Mentor = "Luk'yanovich Inna Robertovna",
                        Department = "Sergey department", Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}