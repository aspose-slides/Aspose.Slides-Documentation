# Export Notes and Handouts

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Export speaker notes below slides and create handouts with several slides per PDF page. The notes example omits hidden slides by default; the handout explicitly selects three slides so its final page is partially filled. Check the final partially filled handout page when your slide count is not a multiple of the chosen layout.
