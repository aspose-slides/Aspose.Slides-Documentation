---
title: Process Presentations with Large Media
type: docs
weight: 30
url: /net/examples/optimization-batch/large-media/
description: "Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements."
---

Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements.

## Run the example

Download the [complete project](example.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET6.CrossPlatform 26.10.0. The complete project uses portable image fixtures and the CrossPlatform package.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Buffers.Binary;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;
using Aspose.Slides;
using Microsoft.VisualBasic.FileIO;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private static void ProcessLargeMedia()
    {
        Example.Setup();WriteWav("output/original.wav",4*1024*1024);
        using(var audio=File.OpenRead("output/original.wav"))using(var p=new Presentation())
        {p.Slides[0].Shapes.AddAudioFrameEmbedded(40,40,80,80,audio);p.Save("output/input.pptx",SaveFormat.Pptx);}
        string temp=Path.GetFullPath("output/blob-temp");Directory.CreateDirectory(temp);
        long baseline=Process.GetCurrentProcess().WorkingSet64;var watch=Stopwatch.StartNew();
        var options = new LoadOptions
        {
            BlobManagementOptions = new BlobManagementOptions
            {
                PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
                IsTemporaryFilesAllowed = true,
                TempFilesRootPath = temp,
                MaxBlobsBytesInMemory = 1024
            }
        };
        using(var p=new Presentation("output/input.pptx",options)){p.Save("output/processed.pptx",SaveFormat.Pptx);}
        watch.Stop();using(var exclusive=File.Open("output/input.pptx",FileMode.Open,FileAccess.ReadWrite,FileShare.None)){}
        int remainingFiles=Directory.GetFiles(temp,"*",System.IO.SearchOption.AllDirectories).Length;
        using var result=new Presentation("output/processed.pptx");byte[] actual=result.Slides[0].Shapes.OfType<IAudioFrame>().Single().EmbeddedAudio.BinaryData;
        Example.Require(Example.Hash(actual)==Example.HashFile("output/original.wav"),"Audio changed.");Example.Require(remainingFiles==0,"BLOB temporary files remain after disposal.");
        Example.Json("output/measurements.json",new{audio_bytes=actual.Length,baseline_working_set=baseline,process_peak_working_set=Process.GetCurrentProcess().PeakWorkingSet64,processing_elapsed_ms=watch.ElapsedMilliseconds,temp_files_after_disposal=remainingFiles,operating_system=System.Runtime.InteropServices.RuntimeInformation.OSDescription,runtime=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription});
        Example.Result(new{media_bytes_preserved=true,input_unlocked_after_disposal=true,temp_files_cleaned=true,memory_measurement_recorded=true});
    }

    private static void WriteWav(string path,int samples)
    {
        using var stream=File.Create(path);using var writer=new BinaryWriter(stream);
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));writer.Write(36+samples*2);writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));writer.Write(16);writer.Write((short)1);writer.Write((short)1);writer.Write(8000);writer.Write(16000);writer.Write((short)2);writer.Write((short)16);writer.Write(Encoding.ASCII.GetBytes("data"));writer.Write(samples*2);
        var random=new Random(17);var buffer=new byte[65536];int remaining=samples*2;while(remaining>0){random.NextBytes(buffer);int count=Math.Min(buffer.Length,remaining);writer.Write(buffer,0,count);remaining-=count;}
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ProcessLargeMedia();
        await Task.CompletedTask;
    });
}

internal static class Example
{
    public static ExampleContext Context = null!;

    public static void Setup() { Directory.CreateDirectory("output"); }

    public static void Require(bool value,string message) { if(!value) throw new InvalidOperationException(message); }

    public static string Hash(byte[] data)=>System.Convert.ToHexString(SHA256.HashData(data)).ToLowerInvariant();

    public static string HashFile(string path)=>Hash(File.ReadAllBytes(path));

    public static void Result(object checks)
    { File.WriteAllText("output/result.json",JsonSerializer.Serialize(new {checks},new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }

    public static void Json(string path,object value)
    { File.WriteAllText(path,JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}),new UTF8Encoding(false)); }
}

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(Func<ExampleContext, Task> run)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string start = Environment.CurrentDirectory;
        string output = Directory.CreateDirectory(Path.Combine(start, "example-output")).FullName;
        try
        {
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, !string.IsNullOrWhiteSpace(licensePath)));
            Console.WriteLine("Output: " + output);
            return 0;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed);
```

## Expected result and checks

The program writes its semantic checks to `output/result.json` and throws if a required
result differs. Expected check values are:

```json
{
  "media_bytes_preserved": true,
  "input_unlocked_after_disposal": true,
  "temp_files_cleaned": true,
  "memory_measurement_recorded": true
}
```

The 1,024-byte setting is an in-memory BLOB threshold, not a total process-memory cap. The peak working set covers this process, including fixture creation, and varies by machine. Temporary storage is caller-owned and must have capacity for the workload. The source stream remains alive through embedding; presentation disposal releases its input lock and temporary files.

## Learn more

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](https://docs.aspose.com/slides/net/manage-blob/)


## Open and run the complete project

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
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
