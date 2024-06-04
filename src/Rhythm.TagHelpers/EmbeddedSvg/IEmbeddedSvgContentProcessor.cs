namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Html;

/// <summary>
/// A contract for creating a processor of SVG content.
/// </summary>
/// <remarks>This will content </remarks>
public interface IEmbeddedSvgContentProcessor
{
    /// <summary>
    /// Process the input into a <see cref="IHtmlContent"/>.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A <see cref="IHtmlContent"/> if successful.</returns>
    IHtmlContent? ProcessContent(ProcessSvgContentInput input);
}
