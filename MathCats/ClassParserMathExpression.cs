using System.Text.RegularExpressions;

namespace MathCats
{
    class ClassParserMathExpression
    {
        public static string CreateFormula(string str, string src)
        {
            str = Regex.Replace(str.ToLower(), @"(((?<f1>\((([0-9].*)|(([a-z]{3})|([a-z]{2})(?<f1_1>\(.*\))))\))\^(?<f2>\((([0-9].*)"+
                @"|(([a-z]{3})|([a-z]{2})(?<f2_1>\(.*\))))\)))|(\b((?<f1>x{1}|[0-9])\^(?<f2>x{1}|[0-9]))\b))|([a-z]{3})|([a-z]{2})", x =>
            {
                if (x.Value.Contains("^"))
                {
                    if(x.Groups["f1"].Value==$"(sin{x.Groups["f1_1"].Value})") return $"Math.Pow(Math.Sin{x.Groups["f1_1"].Value},{x.Groups["f2"].Value})";
                    if(x.Groups["f1"].Value== $"(cos{x.Groups["f1_1"].Value})") return $"Math.Pow(Math.Cos{x.Groups["f1_1"].Value},{x.Groups["f2"].Value})";
                    if(x.Groups["f1"].Value== $"(log{x.Groups["f1_1"].Value})") return $"Math.Pow(Math.Log{x.Groups["f1_1"].Value},{x.Groups["f2"].Value})";
                    if(x.Groups["f1"].Value== $"(tg{x.Groups["f1_1"].Value})") return $"Math.Pow(Math.Tan{x.Groups["f1_1"].Value},{x.Groups["f2"].Value})";
                    return $"Math.Pow({x.Groups["f1"].Value},{x.Groups["f2"].Value})";
                }
                if (x.Value == "sin") return "Math.Sin";
                if (x.Value == "cos") return "Math.Cos";
                if (x.Value == "log") return "Math.Log";
                if (x.Value == "tg") return "Math.Tan";
                return x.Value;
            });
            return src.Replace("{source}", str);
        }
    }
}