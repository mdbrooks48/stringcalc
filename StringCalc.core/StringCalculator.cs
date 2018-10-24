using System;

namespace StringCalc.core
{
    /// <summary>
    /// Library to calculate integer values from strings
    /// </summary>
    public class StringCalculator : IStringCalculator
    {
        /// <summary>
        /// Adds all the integer values in a delimited string
        /// </summary>
        /// <param name="values">The string to parse and sum</param>
        /// <returns>integer</returns>
        public int Add(string values) {
            if (string.IsNullOrEmpty(values)) return 0;
            var delimiters = new char[] { ',', '\n' };

            string source = values;
            if (values.StartsWith("//")) {
                delimiters = values.Substring(0, values.IndexOf('\n')).Replace("//","").Replace("\n", "").ToCharArray();
                source = values.Substring(values.IndexOf("\n") + 1);
            }

            var valuesArray = source.Split(delimiters);

            int value = 0;
            foreach(string stringVal in valuesArray) {
                int intVal = 0;
                if (int.TryParse(stringVal, out intVal)) {
                    value += intVal;
                }
            }
            return value;
        }
    }
}
