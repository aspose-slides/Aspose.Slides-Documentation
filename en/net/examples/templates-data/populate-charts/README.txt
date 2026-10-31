# Populate Charts from Data

Open Example.sln in a compatible .NET IDE, or run these commands here:

    dotnet restore Example.sln
    dotnet build Example.sln -c Release --no-restore
    dotnet run --project Example.csproj -c Release --no-build -- --mode evaluation

The stable target is .NET 8 / C# 12. A supported .NET 10 SDK and runtime can build
and run it; Major runtime roll-forward is explicit. The SDK file accepts installed
release SDKs from 8.0.100 onward and does not require that exact version.
.NET 8/9 runtime support ends on 2026-11-10; prefer current LTS .NET 10.
Normal restore may update its dependency graph; no locked restore is required.

CrossPlatform requires fontconfig, fonts and ICU on glibc Linux; glibc>=2.23 on
x64 or >=2.39 on ARM64. Windows x86/x64 may require the Visual C++ runtime.
macOS x64/ARM64 is supported by the package; runtime OS support also applies.
Alpine/musl and native Windows ARM64 need a separately tested package profile.

Evaluation needs no license. Its watermark and truncated read-back text are
expected; output checks must still pass. For full text/no watermark, set
ASPOSE_LICENSE_PATH or pass --mode licensed --license PATH with an authorized
license covering this release. Explicit --mode evaluation ignores license settings.
Never include your license, certificate private key or API credentials in the project.

Fixtures are copied from the application Fixtures folder into a separate output
workspace; originals remain unchanged. The absolute output location is printed.
Use --output DIRECTORY to choose it. execution.json records each action and the
actual runtime. Exit 0 means verified actions passed; 1 means failed checks; 2
means an unmet prerequisite. A prerequisite diagnostic is not a functional pass.

VS Code needs Microsoft's C# extension for the included coreclr launch profile.
