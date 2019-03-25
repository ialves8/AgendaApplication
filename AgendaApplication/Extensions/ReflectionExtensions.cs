namespace AgendaApplication.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetPropertyValue<T>(this T item, string propertyNome)
        {
            return item.GetType().GetProperty(propertyNome).GetValue(item, null).ToString();
        }
    }
}
