using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.Models
{
    public class Product
    {
        // ? represent nullable type
        public string? Id { get; set; }
        public string? Maker { get; set; }

        [JsonPropertyName("img")] //annotation
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int[]? Ratings { get; set; }

        /**
         * ToString() is available implicitly in every object by default, so we're overriding here
         * Returns a string that represents the current object.
        **/
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}

