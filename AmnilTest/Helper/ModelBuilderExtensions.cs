using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmnilTest.Model;

namespace AmnilTest.Helper
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>().HasData(
                new District
                {
                    Id = 1,
                    Name = "Kathmandu"
                },
                new District
                {
                    Id = 2,
                    Name = "Lalitpur"
                },
                new District
                {
                    Id = 3,
                    Name = "Kaski"
                }
                );
            modelBuilder.Entity<Contestant>().HasData(

                new Contestant
                {
                    Id = 1,
                    Firstname = "Nischhal",
                    Lastname = "Shrestha",
                    Address = "Kathmandu",
                    DateOfBirth = Convert.ToDateTime("1970 /01/01"),
                    DistrictId = 1,
                    Gender = "Male",
                    IsActive = false
                },
                new Contestant
                {
                    Id = 2,
                    Firstname = "Ram",
                    Lastname = "Shrestha",
                    Address = "Lalitpur",
                    DateOfBirth = Convert.ToDateTime("1976 /01/08"),
                    DistrictId = 2,
                    Gender = "Male",
                    IsActive = false
                },
                 new Contestant
                 {
                     Id = 3,
                     Firstname = "Sita",
                     Lastname = "Malla",
                     Address = "Kaski",
                     DateOfBirth = Convert.ToDateTime("1960/01/08"),
                     DistrictId = 3,
                     Gender = "Male",
                     IsActive = false
                 });
        }
    }
}
