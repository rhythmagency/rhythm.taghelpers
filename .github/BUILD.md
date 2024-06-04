# Running a local build

The following is a powershell script which will create a local packages. 

You will need to setup your IDE to support a local NuGet feed or include these packages in the project some other way.

> [!TIP]
> Generally it is a good idea to set the NuGet package version to have a `-beta{number}` or `-alpha{number}` suffix so as not to get a conflict with released versions on a remote NuGet feed.

```powershell
# This script is intended to be placed and run outside of the git repo so it is not accidentally committed.
# To run this script you will need dotnet-cli (v6) installed
$CONFIG = 'Release';
$IN_FOLDER = 'C:\Path\To\Rhythm.TagHelpers\Repo\Root'
$OUT_FOLDER = 'C:\Path\To\Your\Local\nuget';
# NuGet package version (e.g. 1.0.1-beta1)
$VERSION = '1.0.0';

$START_FOLDER = (get-location).path;

Set-Location $IN_FOLDER;

# Restore dependencies
dotnet restore ./src/Rhythm.TagHelpers.sln

# Build Rhythm.TagHelpers
dotnet pack ./src/Rhythm.TagHelpers/Rhythm.TagHelpers.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

Set-Location $START_FOLDER;
```
