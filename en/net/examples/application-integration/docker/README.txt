# Run a Converter in Docker

Pinned .NET SDK 8.0.427/net8.0, Aspose.Slides.NET6.CrossPlatform 26.10.0 and locked dependencies.
Set ASPOSE_LICENSE_PATH to your file license for unrestricted output. No license is included.
Build and run a complete Linux converter using the pinned Aspose.Slides.NET6.CrossPlatform package. The multi-stage image contains fontconfig and DejaVu fonts. Input is mounted read-only, output has its own mount, and a file license is supplied only at runtime.

Docker Desktop or a Linux Docker engine must be available. Run the project with --verify-container on the host: it generates two input slides, builds the actual image, runs conversion with container networking disabled, and verifies saved text and an unchanged input. It also inspects the application image for copied license files. The fixed official .NET 8 image versions and NuGet lock make the tested dependencies explicit. Linux font availability still affects rendering; inspect the returned substitution list and preview. No license is copied during image build.

Run: dotnet run --project Example.csproj --configuration Release -- --verify-container
