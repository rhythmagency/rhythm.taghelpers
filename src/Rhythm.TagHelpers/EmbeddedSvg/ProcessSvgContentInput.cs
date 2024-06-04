namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// A record which represents the input required to process an SVG for embedding.
/// </summary>
/// <param name="Content">The content of the SVG file.</param>
/// <param name="Attributes">The attributes pased from the tag helper.</param>
/// <param name="RemoveComments">Whether to remove comments or not.</param>
public sealed record ProcessSvgContentInput(string? Content, ReadOnlyTagHelperAttributeList Attributes, bool RemoveComments);
