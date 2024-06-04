namespace Rhythm.TagHelpers.EmbeddedSvg.Implementations;

using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Logging;
using Rhythm.IO.Files;
using Rhythm.TagHelpers.EmbeddedSvg;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IEmbeddedSvgContentHelper"/>.
/// </summary>
internal sealed class DefaultEmbeddedSvgContentHelper : IEmbeddedSvgContentHelper
{
    private readonly IEmbeddedSvgContentProcessor _embeddedSvgContentProcessor;

    private readonly IFileTextHelper _fileTextHelper;

    private readonly ILogger _logger;

    public DefaultEmbeddedSvgContentHelper(IEmbeddedSvgContentProcessor embeddedSvgContentProcessor, ILogger<DefaultEmbeddedSvgContentHelper> logger, IFileTextHelper fileTextHelper)
    {
        _embeddedSvgContentProcessor = embeddedSvgContentProcessor;
        _fileTextHelper = fileTextHelper;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<IHtmlContent?> GetContentAsync(GetSvgContentInput input, CancellationToken cancellationToken)
    {
        try
        {
            var content = await _fileTextHelper.GetTextAsync(input.Path, cancellationToken);
            return _embeddedSvgContentProcessor.ProcessContent(new(content, input.Attributes, input.RemoveComments));
        }
        catch (FileAccessException ex)
        {
            _logger.LogWarning(ex, "Unable to get SVG content for {Path} from {FilePath}. {Reason}", input.Path, ex.FilePath, ex.Reason);
        }
        catch (ParseSvgContentException ex)
        {
            _logger.LogWarning(ex, "Unable to parse SVG content {Path}", input.Path);
        }

        return default;
    }
}
