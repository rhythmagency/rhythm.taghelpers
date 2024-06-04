namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Html;

/// <summary>
/// A contract for creating a helper that gets the content of an SVG file.
/// </summary>
public interface IEmbeddedSvgContentHelper
{
    /// <summary>
    /// Attempts to get the HTML content of an SVG file.
    /// </summary>
    /// <param name="input">The input required to get and process the SVG.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="IHtmlContent"/> if successful.</returns>
    Task<IHtmlContent?> GetContentAsync(GetSvgContentInput input, CancellationToken cancellationToken);
}
