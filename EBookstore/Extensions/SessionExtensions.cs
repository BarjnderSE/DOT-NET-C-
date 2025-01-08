using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EBookStore.Extensions  // Use your actual namespace, change this accordingly
{
    public static class SessionExtensions
    {
        // Method to store complex objects in session
        public static void Set<T>(this ISession session, string key, T value)
        {
            var json = JsonSerializer.Serialize(value);  // Serialize object to JSON
            session.SetString(key, json);  // Store the serialized object as a string in session
        }

        // Method to retrieve complex objects from session
        public static T Get<T>(this ISession session, string key)
        {
            var json = session.GetString(key);  // Retrieve the JSON string from session
            return json == null ? default : JsonSerializer.Deserialize<T>(json);  // Deserialize and return the object
        }
    }
}
