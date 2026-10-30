# Export Slides to SVG

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Write one slide to a scalable SVG. Text appearance still depends on the output representation and fonts; SVG does not imply that each PowerPoint object becomes an editable browser element. Inspect the SVG in a browser and check any resource references before embedding it elsewhere.
