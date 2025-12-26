using System.Diagnostics.CodeAnalysis;

namespace DustyPig.IMDB;

internal static class Extensions
{
    public static bool HasValue([NotNullWhen(true)] this string? s) => !string.IsNullOrWhiteSpace(s);
}
