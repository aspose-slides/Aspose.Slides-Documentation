# Export Presentations to HTML

Tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned by global.json. Restores Aspose.Slides.NET26.10.0 from NuGet.
The synthetic image generator uses System.Drawing on Windows. See the Docker example for a separately tested Linux package and environment.
Set ASPOSE_LICENSE_PATH to your license file for unrestricted output. Evaluation mode has limits and adds a watermark.

Run: dotnet run --project Example.csproj --configuration Release

Outputs are written in the current directory. Classic HTML uses SVG-based slide output and can scale to its container. HTML5 has presentation navigation and supported shape/transition animation. Serve the generated HTML together with its supporting asset folders; the example keeps HTML5 images and styles external. The HTML5 copy contains only visible slides so its navigation matches the exported deck. Click its first slide to play the title fade; each visible slide has a title effect and fade transition. In this SDK, generated navigation can remain disabled after a slide without animations, so verify mixed animated/static decks before hosting them. Generated HTML5 also references public JavaScript CDNs; offline hosting must provide those dependencies. The export flags do not add effects to a deck without them.
