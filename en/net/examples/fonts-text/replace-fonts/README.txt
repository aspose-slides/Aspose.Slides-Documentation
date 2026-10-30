# Replace Presentation Fonts

Complete C# example, tested on Windows with .NET SDK 8.0.427 and Aspose.Slides.NET 26.10.0.
Set ASPOSE_LICENSE_PATH to your own valid license file. The license is not included.
The code downloads pinned Noto fonts from their official repositories and verifies SHA-256 before loading them from an application folder. Internet access is required on the first run; the fonts are not installed system-wide or included in this project ZIP. See the [Noto font license](https://github.com/notofonts/noto-fonts/blob/ffebf8c1ee449e544955a7e813c54f9b73848eac/LICENSE) and [Noto CJK license](https://github.com/notofonts/noto-cjk/blob/f8d157532fbfaeda587e826d4cd5b21a49186f7c/Sans/LICENSE). Both are SIL Open Font License 1.1. Preserve their notices if you redistribute the fonts.

Run dotnet restore Example.csproj --locked-mode, then dotnet run --project Example.csproj --configuration Release --no-restore.
The program raises an exception on failed assertions and writes result.json on success.
