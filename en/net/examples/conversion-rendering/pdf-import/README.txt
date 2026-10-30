# Import PDF Pages into Slides

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Create a two-page PDF fixture, import its pages, and save an editable presentation container. The default empty slide is removed before import. Imported object editability depends on the PDF content and reconstruction; this is not a promise to restore the original PowerPoint object model or exact formatting.
