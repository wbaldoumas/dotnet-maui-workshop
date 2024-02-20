using System.Text.Json.Serialization;

namespace MonkeyFinder.Serialization;

[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext
{
}