using System;

namespace Bv.Tools.Utils
{
    public static class GuardClauses
    {
        public static T IsNotNull<T>(T argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return argumentValue;
        }

        public static string IsNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentNullException(argumentName);
            }
            return argumentValue;
        }
    }
}
