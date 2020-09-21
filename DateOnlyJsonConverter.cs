using System;


namespace Newtonsoft.Json.Converters
{
    public class DateOnlyJsonConverter : DateTimeConverterBase
    {
        private string dateFormat;

        public DateOnlyJsonConverter()
        {
            dateFormat = "yyyy-MM-dd";
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTime))
            {
                throw new InvalidCastException();
            }
            return Convert.ToDateTime(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is DateTime))
            {
                throw new InvalidCastException();
            }
            writer.WriteValue(((DateTime)value).ToString(dateFormat));
            writer.Flush();
        }
    }
}
