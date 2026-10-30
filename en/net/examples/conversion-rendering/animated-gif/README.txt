# Export an Animated GIF

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Export the fixture as an animated GIF with a chosen frame size, slide delay and transition frame rate. GIF is a rendered animation, so its text and shapes are not editable. Inspect decoded frames and timing; supported transition rendering does not imply that every PowerPoint effect or interactive trigger is reproduced.
