﻿using Ek.Shop.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ek.Shop.Base.Data.Configurations
{
    public class CategoryCharacteristicTranslationConfiguration : IEntityTypeConfiguration<CategoryCharacteristicTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryCharacteristicTranslation> entity)
        {
            entity.HasKey(e => new { e.Id });

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.Property(r => r.Code)
                .HasMaxLength(255);

            entity.HasIndex(e => e.CharacteristicId);

            entity.HasIndex(e => e.Code)
                .IsUnique();

            entity.HasIndex(e => e.LanguageId);

            entity.HasOne(d => d.Characteristic)
                .WithMany(p => p.Translations)
                .HasForeignKey(d => d.CharacteristicId);

            entity.HasOne(d => d.Language)
                .WithMany(p => p.CategoryCharacteristicTranslations)
                .HasForeignKey(d => d.LanguageId);
        }
    }
}
