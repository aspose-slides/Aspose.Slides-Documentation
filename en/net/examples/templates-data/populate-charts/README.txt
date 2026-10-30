# Populate Charts from Data

Requires the .NET 8 SDK and Aspose.Slides.NET 26.10.0 (locked dependency versions).
This sample was tested on Windows x64. Set ASPOSE_LICENSE_PATH to your own authorized
Aspose.Slides license file for the complete assertions; do not put a license in this folder.
Without a license the SDK evaluation restrictions may alter text or other results.

Run from the extracted project folder:

dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore

The application creates its synthetic presentation inputs and writes results under output/.
Keep the supplied data files beside the project. Example.cs contains the visible license,
rendering, JSON/CSV, assertion and fixture helpers used by Program.cs. No PowerPoint installation is needed.
Original fixtures and data were authored for this example. Arial is an OS-installed font and is
not redistributed. Bitmap helpers use System.Drawing on Windows.
