namespace Rhythm.TagHelpers.EmbeddedSvg.Implementations;

using Microsoft.AspNetCore.Html;
using System.Xml.Linq;

/// <summary>
/// The default implementation of <see cref="IEmbeddedSvgContentProcessor"/>.
/// </summary>
internal sealed class DefaultEmbeddedSvgContentProcessor : IEmbeddedSvgContentProcessor
{
    /// <inheritdoc/>
    public IHtmlContent? ProcessContent(ProcessSvgContentInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Content))
        {
            return default;
        }

        var document = LoadContent(input.Content);
        if (document is null)
        {
            return default;
        }

        var root = document.Root;
        if (root is null)
        {
            return default;
        }

        foreach (var attribute in input.Attributes)
        {
            root.SetAttributeValue(attribute.Name, attribute.Value);
        }

        if (input.RemoveComments)
        {
            document.DescendantNodes().OfType<XComment>().Remove();
        }

        return new HtmlString(document.ToString());
    }

    private static XDocument? LoadContent(string content)
    {
        XDocument? document;

        try
        {
            document = XDocument.Parse(content);
        }
        catch (Exception ex)
        {
            throw new ParseSvgContentException(ex);
        }

        if (document.Root is null)
        {
            return default;
        }
        if (document.Root.Name.LocalName.Equals("svg", StringComparison.OrdinalIgnoreCase) is false)
        {
            return default;
        }

        return document;
    }
}
