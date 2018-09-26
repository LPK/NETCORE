using InterviewAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewAPI.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<InterviewAPIContext>();
            context.Database.EnsureCreated();
            if (!context.Student.Any())
            {
                context.Student.Add(new Student() { Address1 = "Siri Newawa,Nawana,Mirigama", City = "Mirigama", Email = "abc@gmail.com" , FirstName = "Lesley" ,PhoneNumber="0712234454"});
                context.Student.Add(new Student() { Address1 = "Ebulahena, Nawana", City = "Dompe", Email = "xyz@gmail.com",FirstName="Dini", PhoneNumber = "07123236454" });
                context.SaveChanges();
            }
        }
    }
}
