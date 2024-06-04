namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// A collection of extension methods to augment the <see cref="TagHelperContext"/> when used with <see cref="EmbeddedSvgTagHelper"/> and supporting implementations.
/// </summary>
public static class EmbeddedSvgTagHelperContextExtensions
{
    private const string PathContextKey = $"{nameof(EmbeddedSvgTagHelper)}:{nameof(EmbeddedSvgTagHelper.Path)}";

    /// <summary>
    /// Tries to get the embedded SVG path from the current context.
    /// </summary>
    /// <param name="context">The current context.</param>
    /// <param name="path">The output path if successful.</param>
    /// <returns>A <see cref="bool"/>. <see langword="true"/> if successful and <see langword="false"/> if not.</returns>
    public static bool TryGetEmbeddedSvgPath(this TagHelperContext context, [NotNullWhen(true)] out string? path)
    {
        if (context.Items.TryGetValue(PathContextKey, out var value) is false)
        {
            path = default;
            return false;
        }

        if (value is not string valueAsString)
        {
            path = default;
            return false;
        }

        path = valueAsString;
        return string.IsNullOrEmpty(valueAsString) is false;
    }

    /// <summary>
    /// Sets the embedded SVG path to the current context.
    /// </summary>
    /// <param name="context">The current context.</param>
    /// <param name="path">The path.</param>
    public static void SetEmbeddedSvgPath(this TagHelperContext context, string? path)
    {
        context.Items[PathContextKey] = path;
    }
}
