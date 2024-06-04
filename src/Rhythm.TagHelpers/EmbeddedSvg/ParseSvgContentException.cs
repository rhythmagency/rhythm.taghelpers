namespace Rhythm.TagHelpers.EmbeddedSvg;

using System;

/// <summary>
/// Represents an error in parsing SVG content.
/// </summary>
[Serializable]
public sealed class ParseSvgContentException : Exception
{
    /// <summary>
    /// Creates a new <see cref="ParseSvgContentException"/> instance.
    /// </summary>
    /// <param name="ex">The exception.</param>
    public ParseSvgContentException(Exception ex) : base(string.Empty, ex)
    {
    }
}
