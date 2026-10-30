---
title: Process Presentations with Large Media
type: docs
weight: 30
url: /net/examples/optimization-batch/large-media/
description: "Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements."
---

Process a reproducibly generated large audio presentation with explicit BLOB storage options, disposal and memory measurements.

## Run the example

Download the [complete project](sample.zip), extract it, and run it with the .NET 8 SDK.
The project pins Aspose.Slides.NET 26.10.0. The example was tested on Windows x64.
For the complete data assertions, set `ASPOSE_LICENSE_PATH` to your own valid license;
the visible helper loads it when supplied. Evaluation mode may truncate text or add watermarks.

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The download contains [Program.cs](Program.cs), [Example.cs](Example.cs), the project,
dependency lock, and any JSON/CSV input. The helper source contains fixture generation,
license loading, serialization and assertions; it is part of the runnable project.
All presentation inputs are generated from original synthetic data. Results go to `output/`.

## Example

```csharp
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private static void WriteWav(string path,int samples)
    {
        using var stream=File.Create(path);using var writer=new BinaryWriter(stream);
        writer.Write(Encoding.ASCII.GetBytes("RIFF"));writer.Write(36+samples*2);writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));writer.Write(16);writer.Write((short)1);writer.Write((short)1);writer.Write(8000);writer.Write(16000);writer.Write((short)2);writer.Write((short)16);writer.Write(Encoding.ASCII.GetBytes("data"));writer.Write(samples*2);
        var random=new Random(17);var buffer=new byte[65536];int remaining=samples*2;while(remaining>0){random.NextBytes(buffer);int count=Math.Min(buffer.Length,remaining);writer.Write(buffer,0,count);remaining-=count;}
    }
    private static void Main()
    {
        Example.Setup();WriteWav("output/original.wav",4*1024*1024);
        using(var audio=File.OpenRead("output/original.wav"))using(var p=new Presentation())
        {p.Slides[0].Shapes.AddAudioFrameEmbedded(40,40,80,80,audio);p.Save("output/input.pptx",SaveFormat.Pptx);}
        string temp=Path.GetFullPath("output/blob-temp");Directory.CreateDirectory(temp);
        long baseline=Process.GetCurrentProcess().WorkingSet64;var watch=Stopwatch.StartNew();
        var options=new LoadOptions{BlobManagementOptions=new BlobManagementOptions{PresentationLockingBehavior=PresentationLockingBehavior.KeepLocked,IsTemporaryFilesAllowed=true,TempFilesRootPath=temp,MaxBlobsBytesInMemory=1024}};
        using(var p=new Presentation("output/input.pptx",options)){p.Save("output/processed.pptx",SaveFormat.Pptx);}
        watch.Stop();using(var exclusive=File.Open("output/input.pptx",FileMode.Open,FileAccess.ReadWrite,FileShare.None)){}
        int remainingFiles=Directory.GetFiles(temp,"*",SearchOption.AllDirectories).Length;
        using var result=new Presentation("output/processed.pptx");byte[] actual=((IAudioFrame)result.Slides[0].Shapes[0]).EmbeddedAudio.BinaryData;
        Example.Require(Example.Hash(actual)==Example.HashFile("output/original.wav"),"Audio changed.");Example.Require(remainingFiles==0,"BLOB temporary files remain after disposal.");
        Example.Json("output/measurements.json",new{audio_bytes=actual.Length,baseline_working_set=baseline,process_peak_working_set=Process.GetCurrentProcess().PeakWorkingSet64,processing_elapsed_ms=watch.ElapsedMilliseconds,temp_files_after_disposal=remainingFiles,operating_system=System.Runtime.InteropServices.RuntimeInformation.OSDescription,runtime=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription});
        Example.Result(new{media_bytes_preserved=true,input_unlocked_after_disposal=true,temp_files_cleaned=true,memory_measurement_recorded=true});
    }

}
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
