using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProblemSolving.Framework;

public class RunConfigConverter : JsonConverter<RunConfig>
{
    public override RunConfig? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Invalid runconfig.json");
        }

        string propertyName;
        var config = new RunConfig();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return config;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                propertyName = reader.GetString();
                reader.Read();
                if (string.Equals(propertyName, "ProblemId"))
                {
                    config.ProblemId = reader.GetInt32();
                }
                else if (string.Equals(propertyName, "Argument"))
                {
                    switch (reader.TokenType)
                    {
                        case JsonTokenType.String:
                            config.Arguments = config.Arguments.Append(reader.GetString()).ToArray();
                            break;
                        case JsonTokenType.Number:
                            config.Arguments = config.Arguments.Append(reader.GetInt32()).ToArray();
                            break;
                        case JsonTokenType.StartArray:
                            var arr = Array.Empty<object>();
                            while (reader.Read())
                            {
                                if (reader.TokenType == JsonTokenType.EndArray)
                                {
                                    switch(arr[0].GetType())
                                    {
                                        case Type t when t == typeof(int):
                                            var newArrInt = arr.Cast<int>().ToArray();
                                            config.Arguments = config.Arguments.Append(newArrInt).ToArray();
                                            break;
                                        case Type t when t == typeof(string):
                                            var newArrString = arr.Cast<string>().ToArray();
                                            config.Arguments = config.Arguments.Append(newArrString).ToArray();
                                            break;
                                        default:
                                            throw new JsonException("Invalid Array type");
                                    }   
                                    break;
                                }
                                switch (reader.TokenType)
                                {
                                    case JsonTokenType.String:
                                        arr = arr.Append(reader.GetString()).ToArray();
                                        break;
                                    case JsonTokenType.Number:
                                        arr = arr.Append(reader.GetInt32()).ToArray();
                                        break;
                                }
                            }
                            break;
                        default: throw new JsonException("Invalid Argument type");
                    }
                }
            }
        }
        throw new JsonException("Invalid runconfig.json");
    }

    public override void Write(Utf8JsonWriter writer, RunConfig value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}

