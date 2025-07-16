using System.Text.Json;
using System.Text.Json.Serialization;

//namespace CadastroClientesAPI.Converter;

public class DateOnlyJsonConverter : JsonConverter<DateTime>
{
    private readonly string _format = "dd/MM/yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (DateTime.TryParseExact(dateString, _format, null, System.Globalization.DateTimeStyles.None, out var date))
        {
            return date;
        }
        throw new JsonException($"Formato de data inválido. Use o formato {_format}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}

