# Render Slides as Images

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Render PNG/JPEG images and small previews at explicit pixel dimensions. The source is 16:9 and the requested sizes use the same ratio. Choose matching dimensions to avoid distortion; preserve or pad the aspect ratio in your application when a fixed container has a different shape. This explicit loop also renders the hidden slide.
