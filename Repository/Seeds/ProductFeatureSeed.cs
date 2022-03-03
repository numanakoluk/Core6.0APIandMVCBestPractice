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
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
            new ProductFeature { Id=1, Color="Red",  Height=100, Width=200, ProductId=1},
            new ProductFeature { Id = 2, Color = "Blue", Height = 300, Width = 300, ProductId = 2 });
        }
    }
}
