using System;
using Amazon.DynamoDBv2.Model;

namespace MovieApi.Extensions
{
	public static class Extensions
	{
		public static T ToClass<T>(this Dictionary<string, AttributeValue> dict)
        {
			var type = typeof(T);
			var obj = Activator.CreateInstance(type);

			foreach(var kv in dict)
            {
				var property = type.GetProperty(kv.Key);
				if(property != null)
                {
                    if (!string.IsNullOrEmpty(kv.Value.S))
                    {
                        property.SetValue(obj, kv.Value.S);
                    }
                    else if (!string.IsNullOrEmpty(kv.Value.N))
                    {
                        property.SetValue(obj, double.Parse(kv.Value.N));
                    }
                }
            }
            return (T)obj;
        }
    }
}

