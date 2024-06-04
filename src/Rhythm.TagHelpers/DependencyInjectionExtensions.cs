namespace Rhythm.TagHelpers;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rhythm.TagHelpers.EmbeddedSvg;

/// <summary>
/// Extension methods for registering dependencies.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Adds dependencies for Rhythm IO to the current <see cref="WebApplicationBuilder"/>.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The current <see cref="IServiceCollection"/>.</returns>
    public static WebApplicationBuilder AddRhythmTagHelpers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRhythmTagHelpers();

        return builder;
    }

    /// <summary>
    /// Adds dependencies for Rhythm IO to the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>The current <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddRhythmTagHelpers(this IServiceCollection services)
    {
        return services
            .AddRhythmIO()
            .AddEmbeddedSvgDependencies();
    }
}
