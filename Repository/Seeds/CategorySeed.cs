using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seeds
{
    //Migrations
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //C #10 Feature
            //Category c = new()
            builder.HasData(
                new Category { Id = 1, Name = "Pens" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Notebooks" });
        }
    }
}
