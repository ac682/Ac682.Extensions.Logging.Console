using System;
using System.Collections.Generic;
using Spectre.Console;

namespace Ac682.Extensions.Logging.Console.Formatters
{
    public class BoolFormatter: IObjectLoggingFormatter
    {
        public bool IsTypeAvailable(Type type)
        {
            return type == typeof(bool);
        }

        public string Format(object obj, Type type, string format = null)
        {
            var line = format?.ToUpper() switch
            {
                "U" => obj.ToString()!.ToUpper(),
                "L" => obj.ToString()!.ToLower(),
                null or _ => obj.ToString()
            };
            return $"[bold fuchsia]{line}[/]";
        }
    }
}