using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooService.Core
{
    /// <summary>
    /// The cus convert.
    /// </summary>
    public class CusConvert
    {
        /// <summary>
        /// The to float.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double ToDouble(string input, double defaultValue = 0.00)
        {
            return double.TryParse(input, out var baseInput) ? baseInput : defaultValue;
        }

        /// <summary>
        /// The to int.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static int ToInt(string input, int defaultValue = 0)
        {
            return int.TryParse(input, out var baseInput) ? baseInput : defaultValue;
        }
    }
}
