namespace Rhythm.TagHelpers.EmbeddedSvg;
using Microsoft.Extensions.DependencyInjection;
using Rhythm.TagHelpers.EmbeddedSvg.Implementations;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddEmbeddedSvgDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IEmbeddedSvgContentProcessor, DefaultEmbeddedSvgContentProcessor>();
        services.AddSingleton<IEmbeddedSvgContentHelper, DefaultEmbeddedSvgContentHelper>();

        return services;
    }
}
