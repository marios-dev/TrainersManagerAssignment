using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainersManagerAssignment.Models;

namespace TrainersManagerAssignment.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
    }
}