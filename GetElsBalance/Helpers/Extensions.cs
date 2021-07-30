using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetElsBalance
{
    static class Extensions
    {
        public static String FormatWith(this String s, params Object[] args)
        {
            return String.Format(s, args);
        }

        public static bool In(this String s, params String[] args)
        {
            return args.Contains(s);
        }

        public static bool ContainSubstr(this String s, params String[] args)
        {
            foreach (var item in args) if (s.IndexOf(item) < 0) return false;
            return true;
        }

        public static bool notnull(this String s)
        {
            return s != null && s.Length > 0;
        }

        public static bool NotIn(this String s, params String[] args)
        {
            return args.Contains(s) == false;
        }

        public static void ShowError(this String s, params String[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format(s, args));
            Console.ResetColor();
        }

        public static void ShowInfo(this String s, params String[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Format(s, args));
            Console.ResetColor();
        }

        public static void ShowKeyWalue(this String s, String val, ConsoleColor clr = ConsoleColor.Yellow)
        {
            Console.Write(s);
            Console.ForegroundColor = clr;
            Console.Write(val + "\r\n");
            Console.ResetColor();
        }


        public static void ShowText(this String s, params String[] args)
        {
            Console.WriteLine(String.Format(s, args));
        }


    }
}
