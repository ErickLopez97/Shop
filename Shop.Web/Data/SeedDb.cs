﻿namespace Shop.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("Samsung S9");
                this.AddProduct("Huawei P20");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }
}
