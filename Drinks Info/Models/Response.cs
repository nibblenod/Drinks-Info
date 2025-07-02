using System.Text.Json.Serialization;

namespace Drinks_Info.Models;

public record class Response<T>(
    [property: JsonPropertyName("drinks")] List<T> responses);
