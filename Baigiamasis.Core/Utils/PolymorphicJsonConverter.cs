using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Utils
{
    public class PolymorphicJsonConverter<TBase> : JsonConverter<TBase>
    {
        public override TBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Deserialization is not implemented in this converter.");
        }

        public override void Write(Utf8JsonWriter writer, TBase value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            var actualType = value.GetType();
            JsonSerializer.Serialize(writer, value, actualType, options);
        }
    }
}
