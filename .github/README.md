# rhythm.taghelpers [![Publish to NuGet](https://github.com/rhythmagency/rhythm.taghelpers/actions/workflows/Publish-to-NuGet.yml/badge.svg)](https://github.com/rhythmagency/rhythm.taghelpers/actions/workflows/Publish-to-NuGet.yml) [![NuGet](https://img.shields.io/nuget/v/Rhythm.TagHelpers?logo=nuget)](https://www.nuget.org/packages/Rhythm.TagHelpers)
A Razor TagHelpers library.

## Startup

To get started with Rhythm Tag Helpers you will be the following;

 - .net 6+ web project
 - Install the Rhythm.TagHelpers NuGet package

Once installed add the following to your Program.cs during the `WebApplicationBuilder` before `Build()` is called.

```csharp
builder.AddRhythmTagHelpers();
```

Alternatively if you are using Startup.cs `ConfigureServices(IServiceCollection services)` add the following:

```csharp
public void ConfigureServices(IServiceCollection services) {
    services.AddRhythmTagHelpers();
}
```

Finally, be sure to add the following line to your _\_ViewImports.cshtml_ file.

```razor
@addTagHelper *, Rhythm.TagHelpers
```

# Contributing

If you would like to contibute please check our [contributing guide](CONTRIBUTING.md)!
