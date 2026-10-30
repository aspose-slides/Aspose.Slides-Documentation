# Translate Presentation Text with AI

Requires .NET SDK8.0.427 and Aspose.Slides.NET26.10.0 (locked).
Set ASPOSE_LICENSE_PATH to your licensed file; full-content checks need a valid license.
AI requests use the network. No key or model is included.
Run: dotnet run --project Example.csproj --configuration Release
Create a small English deck with ordinary shape text, grouped text and a table cell, translate it to Spanish, and save a separate copy. The program verifies the changed text and retained source, then renders before/after previews.
This fixture has no charts or speaker notes. Speaker notes are outside this workflow, and charts can prevent translation. Review language quality and text expansion; retained shape coordinates do not guarantee that every translated paragraph fits.
