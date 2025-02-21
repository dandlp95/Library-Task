namespace Library_Task.Services.Interfaces
{
    public interface IBookService
    {
        public string FormatYear(int year);
        public TDestination MapObjects<TSource, TDestination>(TSource source) where TDestination : new();
        public List<TDestination> MapObjects<TSource, TDestination>(List<TSource> sourceList) where TDestination : new();
    }

}
