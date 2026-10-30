# Export PDF/A and Tagged PDF

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. PDF/A is an archival target; tagged PDF and PDF/UA address document structure and accessibility. The sample adds alternative text for its chart and image, then requests PDF/A-2b and PDF/UA separately. Validate the produced files with a standards validator, then inspect headings, reading order, language and alternative text. An export option alone does not establish full accessibility.
