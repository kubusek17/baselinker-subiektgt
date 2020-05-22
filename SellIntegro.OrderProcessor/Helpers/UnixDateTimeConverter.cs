using Newtonsoft.Json;
using System;

namespace SellIntegro.OrderProcessor.Helpers
{
    public class UnixDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var t = long.Parse((string)reader.Value ?? string.Empty);
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public static long ConvertToUnixDate(DateTime dateTime)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0,dateTime.Kind);
            var unixTimestamp = Convert.ToInt64((dateTime - date).TotalSeconds);

            return unixTimestamp;
        }
    }
}
