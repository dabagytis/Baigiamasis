using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baigiamasis.Core.Utils
{
    public class JsonCustomConverter
    {
        public static string SerializeWithPolymorphism<TBase>(List<TBase> items)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new PolymorphicJsonConverter<TBase>() }
            };
            return JsonSerializer.Serialize(items, options);
        }
    }
}
