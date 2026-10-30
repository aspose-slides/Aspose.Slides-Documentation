# Export Presentations to XPS

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Save the presentation as an XPS document for fixed-layout viewing. Reopen it with an XPS-capable viewer or renderer and inspect the pages. The sample reports the visible source count; verification must also inspect the actual XPS package and rendered output.
