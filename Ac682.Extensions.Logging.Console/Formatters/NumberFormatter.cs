using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Spectre.Console;

namespace Ac682.Extensions.Logging.Console.Formatters
{
    public class NumberFormatter: IObjectLoggingFormatter
    {
        private readonly IEnumerable<Type> numberTypes = new Type[]
        {
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(Double),
            typeof(Single),
            typeof(Decimal)
        };
        public bool IsTypeAvailable(Type type)
        {
            return numberTypes.Any(x => type == x);
        }

        public Markup Format(object obj, Type type, string format = null)
        {
            var number = obj.ToString();
            if (format != null && obj is IFormattable formattable)
            {
                number = formattable.ToString(format, CultureInfo.CurrentCulture);
            }
            
            return new Markup(number, new Style(Color.Orange1));
        }
    }
}