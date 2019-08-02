using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

// ReSharper disable once CheckNamespace
namespace Thinktecture
{
   /// <summary>
   /// Extension methods for <see cref="DbContext"/>.
   /// </summary>
   public static class DbContextExtensions
   {
      /// <summary>
      /// Fetches meta data for entity of provided <paramref name="type"/>.
      /// </summary>
      /// <param name="model">Model of a database context.</param>
      /// <param name="type">Entity type.</param>
      /// <returns>An instance of type <see cref="IEntityType"/>.</returns>
      /// <exception cref="ArgumentNullException">
      /// <paramref name="model"/> is <c>null</c>
      /// - or
      /// <paramref name="type"/> is <c>null</c>.
      /// </exception>
      /// <exception cref="ArgumentException">The provided type <paramref name="type"/> is not known by provided <paramref name="model"/>.</exception>
      [NotNull]
      public static IEntityType GetEntityType([NotNull] this IModel model, [NotNull] Type type)
      {
         if (model == null)
            throw new ArgumentNullException(nameof(model));
         if (type == null)
            throw new ArgumentNullException(nameof(type));

         var entityType = model.FindEntityType(type);

         if (entityType == null)
            throw new ArgumentException($"The provided type '{type.DisplayName()}' is not part of the provided Entity Framework model.", nameof(type));

         return entityType;
      }
   }
}
