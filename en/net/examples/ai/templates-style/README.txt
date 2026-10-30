# Generate with a Template or Existing Style

Requires .NET SDK8.0.427 and Aspose.Slides.NET26.10.0 (locked).
Set ASPOSE_LICENSE_PATH to your licensed file; full-content checks need a valid license.
AI requests use the network. No key or model is included.
Run: dotnet run --project Example.csproj --configuration Release
Compare generation from a reusable POTX template and from an existing PPTX style source. Both original designs are created visibly in code, passed through freshly loaded instances, and kept on disk for reuse.
The theme, fonts, masters and available layouts supply a design starting point. Generation may modify the in-memory template instance, so load a fresh copy per request. Design reuse does not promise an exact visual replica or fixed text positioning.
