namespace Rhythm.TagHelpers.EmbeddedSvg;

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

/// <summary>
/// A tag helper that attempts to embed an SVG file.
/// </summary>
[HtmlTargetElement(TagName)]
public sealed class EmbeddedSvgTagHelper : TagHelper
{
    private readonly IEmbeddedSvgContentHelper _embeddedSvgContentHelper;

    /// <summary>
    /// Constructs a new <see cref="EmbeddedSvgTagHelper"/> instance.
    /// </summary>
    /// <param name="embeddedSvgContentHelper">The embedded SVG content helper.</param>
    public EmbeddedSvgTagHelper(IEmbeddedSvgContentHelper embeddedSvgContentHelper)
    {
        _embeddedSvgContentHelper = embeddedSvgContentHelper;
    }

    /// <summary>
    /// The tag name for <see cref="EmbeddedSvgTagHelper"/>
    /// </summary>
    public const string TagName = "embedded-svg";

    /// <summary>
    /// Gets or sets the path to the SVG file.
    /// </summary>
    [HtmlAttributeName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// Gets or sets whether to remove comments from the SVG File.
    /// </summary>
    [HtmlAttributeName("remove-comments")]
    public bool RemoveComments { get; set; } = true;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (context.TryGetEmbeddedSvgPath(out var path))
        {
            Path = path;
        }

        if (string.IsNullOrEmpty(Path))
        {
            output.SuppressOutput();
            return;
        }

        // TODO: Replace this with .net supported option in future versions.
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
        var content = await _embeddedSvgContentHelper.GetContentAsync(new(Path, output.Attributes, RemoveComments), token);

        output.TagName = default;
        output.Content.SetHtmlContent(content);
    }
}
