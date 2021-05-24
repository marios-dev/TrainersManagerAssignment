namespace TrainersManagerAssignment.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrainersManagerAssignment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainersManagerAssignment.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrainersManagerAssignment.DAL.ApplicationDbContext";
        }

        protected override void Seed(TrainersManagerAssignment.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var trainers = new List<Trainer>
            {
                new Trainer
                {
                    FirstName="Νικηφόρος",
                    LastName="Φωκάς",
                    Subject="Javascript"
                },
                new Trainer
                {
                    FirstName="Νικολέττα",
                    LastName="Παλιού",
                    Subject="Python"
                },
                new Trainer
                {
                    FirstName="Δήμητρα",
                    LastName="Μπιζέλη",
                    Subject="C#"
                },
                new Trainer
                {
                    FirstName="Νίκος",
                    LastName="Ευαγγελάτος",
                    Subject="Javascript"
                },
                new Trainer
                {
                    FirstName="Χρήστος",
                    LastName="Τσόκας",
                    Subject="Java"
                },
                new Trainer
                {
                    FirstName="Λάκης",
                    LastName="Μαμαλάκης",
                    Subject="C#"
                },
                new Trainer
                {
                    FirstName="Νίκη",
                    LastName="Παβλίνου",
                    Subject="Python"
                },
                new Trainer
                {
                    FirstName="Ιάσωνας",
                    LastName="Πέτρου",
                    Subject="Java"
                }
            };
            trainers.ForEach(t => context.Trainers.Add(t));
            context.SaveChanges();
        }
    }
}
