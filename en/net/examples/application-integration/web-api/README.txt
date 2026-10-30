# Build a Presentation Conversion Endpoint

Pinned .NET SDK 8.0.427/net8.0, Aspose.Slides.NET 26.10.0 and locked dependencies.
Set ASPOSE_LICENSE_PATH to your file license for unrestricted output. No license is included.
The complete ASP.NET Core application accepts a PPTX presentation as the raw POST body at /convert and returns application/pdf. It limits uploads to 8 MiB, bounds processing to two independent presentation instances, uses a unique temporary directory per request, and connects request cancellation to the library interruption token.

Run normally to listen on http://127.0.0.1:5088. POST the file bytes with your HTTP client. Add --self-test to start a real ephemeral local server, upload valid/invalid/oversized files concurrently, cancel an active job, and verify temporary-directory cleanup. The sample uses loopback hosting and stable error codes. Add authentication, operational limits and deployment configuration appropriate to your own application before exposing it.

Run: dotnet run --project Example.csproj --configuration Release -- --self-test
