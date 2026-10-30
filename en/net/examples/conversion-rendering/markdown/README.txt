# Export Presentations to Markdown

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Export headings, text, lists, tables and images to Markdown using visual export. The example explicitly writes images under the images subfolder of its working directory. Copy that folder with slides.md so its relative image links continue to work.
