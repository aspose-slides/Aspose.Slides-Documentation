---
title: Process Presentations with Large Media
type: docs
weight: 30
url: /net/examples/optimization-batch/large-media/
description: "Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements."
---

Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

The program generates its WAV and PPTX inputs. The BLOB memory limit is 1 KiB to make temporary-file use observable. Working-set figures are observations; the peak belongs to the entire process lifetime, not just this conversion.

```csharp
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using System.Runtime.InteropServices;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        // Generate an 8 MiB PCM payload and embed it in a source deck.
        WriteAudioFixture("example-output/original.wav");
        using (var audio = File.OpenRead("example-output/original.wav"))
        using (var source = new Presentation())
        {
            source.Slides[0].Shapes.AddAudioFrameEmbedded(40, 40, 80, 80, audio);
            source.Save("example-output/input.pptx", SaveFormat.Pptx);
        }

        var temporaryDirectory = Directory.CreateDirectory("example-output/blob-temp").FullName;
        var loadOptions = new LoadOptions
        {
            BlobManagementOptions = new BlobManagementOptions
            {
                PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
                IsTemporaryFilesAllowed = true,
                TempFilesRootPath = temporaryDirectory,
                MaxBlobsBytesInMemory = 1024
            }
        };
        var baselineBytes = Process.GetCurrentProcess().WorkingSet64;
        var stopwatch = Stopwatch.StartNew();
        using (var presentation = new Presentation("example-output/input.pptx", loadOptions))
            presentation.Save("example-output/processed.pptx", SaveFormat.Pptx);
        stopwatch.Stop();
        // These checks run after disposal releases the input and BLOB files.
        using (var exclusiveInput = File.Open("example-output/input.pptx", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
        }

        var temporaryFiles = Directory.GetFiles(temporaryDirectory, "*", SearchOption.AllDirectories).Length;
        using var reopened = new Presentation("example-output/processed.pptx");
        var savedAudio = reopened.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData;
        var originalAudio = File.ReadAllBytes("example-output/original.wav");
        var audioPreserved = SHA256.HashData(savedAudio).SequenceEqual(SHA256.HashData(originalAudio));
        Console.WriteLine($"Audio bytes: {savedAudio.Length}; unchanged: {audioPreserved}; remaining BLOB files: {temporaryFiles}");
        Console.WriteLine($"{RuntimeInformation.FrameworkDescription}; elapsed: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Observed baseline: {baselineBytes}; process lifetime peak: {Process.GetCurrentProcess().PeakWorkingSet64} bytes");
        if (!audioPreserved || temporaryFiles != 0)
            Console.Error.WriteLine("Media preservation or BLOB cleanup failed.");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static void WriteAudioFixture(string path)
    {
        const int channels = 1;
        const int sampleRate = 44100;
        const int bitsPerSample = 16;
        const int sampleCount = 4 * 1024 * 1024;
        const int bytesPerSample = bitsPerSample / 8;
        const int dataLength = sampleCount * channels * bytesPerSample;
        using var writer = new BinaryWriter(File.Create(path));
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));
        writer.Write(36 + dataLength);
        writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
        writer.Write(16);
        writer.Write((short)1); // PCM format.
        writer.Write((short)channels);
        writer.Write(sampleRate);
        writer.Write(sampleRate * channels * bytesPerSample);
        writer.Write((short)(channels * bytesPerSample));
        writer.Write((short)bitsPerSample);
        writer.Write(Encoding.ASCII.GetBytes("data"));
        writer.Write(dataLength);
        for (var index = 0; index < sampleCount; index++)
            writer.Write((short)(Math.Sin(index * 2 * Math.PI * 440 / sampleRate) * 10000));
    }
}
```

## **Expected result and checks**

The output deck preserves the 8 MiB audio payload. After the conversion is disposed, an exclusive input open succeeds and the BLOB directory is empty. Console output records hashes via their equality verdict, runtime, elapsed time, and memory observations.

## **Learn more**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)


## **Open and run the complete project**

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
