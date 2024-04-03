using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameStoreFrontEnd.Converters;

public class StringConverter :JsonConverter<string?>
{
    //Converter to deserialize int to string
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32().ToString();
        }
        else
        {
            return reader.GetString();
        }
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}