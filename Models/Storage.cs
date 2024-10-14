using System.Text.Encodings.Web;
using System.Text.Json;

namespace Kundkorg.models;

public class Storage<T>
{
    private static JsonSerializerOptions _options = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true
  };
  public static List<T> ReadJson(string path)
  {
    _options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    var json = File.ReadAllText(path);
    var product = JsonSerializer.Deserialize<List<T>>(json, _options);
    return product!;
  }
  public static void WriteJson(string path, List<T> orders)
  {

    var json = JsonSerializer.Serialize(orders, _options);
    File.WriteAllText(path, json);
  }
}