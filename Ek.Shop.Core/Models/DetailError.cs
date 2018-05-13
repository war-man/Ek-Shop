﻿namespace Ek.Shop.Core.Models
{
    public class DetailError
    {
        public DetailError()
        { }

        public DetailError(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
