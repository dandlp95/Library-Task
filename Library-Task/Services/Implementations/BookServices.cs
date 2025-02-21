using System;
using System.Reflection;
using Library_Task.Models;
using Library_Task.Services.Interfaces;

namespace Library_Task.Services.Implementations
{
    public class BookService : IBookService
    {
        /// <summary>
        /// Formats the year of a book by appending "(classic)" if it is older than 10 years.
        /// </summary>
        /// <param name="year">The publication year of the book.</param>
        /// <returns>A formatted string of the year with "(classic)" if applicable.</returns>
        public string FormatYear(int year)
        {
            return DateTime.Now.Year - year > 10 ? $"{year} (classic)" : year.ToString();
        }

        /// <summary>
        /// Maps properties from a source object to a destination object of different types.
        /// </summary>
        /// <param name="source">The source object to map from.</param>
        /// <returns>A new instance of TDestination with properties mapped from the source object.</returns>
        public TDestination MapObjects<TSource, TDestination>(TSource source) where TDestination : new()
        {
            TDestination destObject = new();

            // Gets both the source and destination types.
            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            // Gets the properties of the source object.
            PropertyInfo[] sourceProperties = sourceType.GetProperties();

            // If the properties have the same names, it maps the property values from the source object to the destination object.
            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                object? value = sourceProperty.GetValue(source);
                PropertyInfo? destProperty = destinationType.GetProperty(sourceProperty.Name);
                destProperty?.SetValue(destObject, value);
            }

            return destObject;
        }

        public List<TDestination> MapObjects<TSource, TDestination>(List<TSource> sourceList) where TDestination : new()
        {
            List<TDestination> destList = new();
            foreach (TSource source in sourceList)
            {
                TDestination destObject = MapObjects<TSource, TDestination>(source);
                destList.Add(destObject);
            }
            return destList;
        }

    }
}
