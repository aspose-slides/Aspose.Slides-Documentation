# Convert Presentation Formats

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. The sample exports PPTX, PPT and ODP, reopens each file and writes a PPTX copy from each input format. It checks text and slide counts and produces a preview for each result. Format-specific features may be changed or omitted; inspect the features your deck uses.
