using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Thinktecture.EntityFrameworkCore.TempTables;
using Xunit;
using Xunit.Abstractions;

namespace Thinktecture.Extensions.ModelBuilderExtensionsTests
{
   // ReSharper disable once InconsistentNaming
   public class ConfigureTempTable_1_Column : IntegrationTestsBase
   {
      public ConfigureTempTable_1_Column([NotNull] ITestOutputHelper testOutputHelper)
         : base(testOutputHelper, true)
      {
      }

      [Fact]
      public void Should_introduce_temp_table()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int>));
         entityType.Should().NotBeNull();
         entityType.IsQueryType.Should().BeTrue();
      }

      [Fact]
      public void Should_introduce_temp_table_with_int()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int>));
         entityType.Name.Should().Be("Thinktecture.EntityFrameworkCore.TempTables.TempTable<int>");

         var properties = entityType.GetProperties().ToList();
         properties.Should().HaveCount(1);

         var property = properties.First();
         property.Name.Should().Be("Column1");
         property.IsNullable.Should().BeFalse();
      }

      [Fact]
      public void Should_introduce_temp_table_with_nullable_int()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int?>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int?>));
         entityType.Name.Should().Be("Thinktecture.EntityFrameworkCore.TempTables.TempTable<System.Nullable<int>>");

         var properties = entityType.GetProperties();
         properties.Should().HaveCount(1);

         var property = properties.First();
         property.Name.Should().Be("Column1");
         property.IsNullable.Should().BeTrue();
      }

      [Fact]
      public void Should_flag_nullable_int_as_not_nullable_if_set_via_modelbuilder()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int?>().Property(t => t.Column1).IsRequired();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int?>));
         entityType.Name.Should().Be("Thinktecture.EntityFrameworkCore.TempTables.TempTable<System.Nullable<int>>");

         var properties = entityType.GetProperties();
         properties.First().IsNullable.Should().BeFalse();
      }

      [Fact]
      public void Should_introduce_temp_table_with_string()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<string>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<string>));
         entityType.Name.Should().Be("Thinktecture.EntityFrameworkCore.TempTables.TempTable<string>");

         var properties = entityType.GetProperties();
         properties.Should().HaveCount(1);

         var property = properties.First();
         property.Name.Should().Be("Column1");
         property.IsNullable.Should().BeTrue();
      }

      [Fact]
      public void Should_generate_table_name_for_int()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int>));
         entityType.Relational().TableName.Should().Be("#TempTable<int>");
      }

      [Fact]
      public void Should_generate_table_name_for_nullable_int()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<int?>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<int?>));
         entityType.Relational().TableName.Should().Be("#TempTable<Nullable<int>>");
      }

      [Fact]
      public void Should_generate_table_name_for_string()
      {
         ConfigureModel = builder => builder.ConfigureTempTable<string>();

         var entityType = ActDbContext.Model.FindEntityType(typeof(TempTable<string>));
         entityType.Relational().TableName.Should().Be("#TempTable<string>");
      }
   }
}
