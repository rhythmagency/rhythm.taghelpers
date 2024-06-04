namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// The input required to get SVG content.
/// </summary>
/// <param name="Path">The path to the SVG file.</param>
/// <param name="Attributes">The attributes.</param>
/// <param name="RemoveComments">Whether or not to remove comments.</param>
public sealed record GetSvgContentInput(string Path, ReadOnlyTagHelperAttributeList Attributes, bool RemoveComments);
