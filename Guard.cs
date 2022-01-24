using System.Runtime.CompilerServices;

public static class Guard
{
    public static void AgainstNegative<T>(int i, Func<string, T> createException, [CallerArgumentExpression("i")] string argName = null) where T : Exception
    {
        if (i < 0)
        {
            var msg = $"Invalid '{argName}' = '{i}' is a negative value";
            throw createException(msg);
        }
    }

    public static void AgainstNegative(int i, [CallerArgumentExpression("i")] string argName = null)
    {
        if (i < 0)
        {
            var msg = $"Invalid '{argName}' = '{i}' is a negative value";
            throw new ArgumentException(msg);
        }
    }
}
