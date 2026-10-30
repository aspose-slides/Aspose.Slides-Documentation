---
title: Stream large media while processing presentations
description: Keep large embedded media on disk while processing a presentation.
type: docs
url: /features/stream-media/
weight: 280
feature_id: stream-media
feature_group: operations
translationKey: slides-feature-stream-media
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-blob/
---

## **Overview**

Use the library's BLOB-management options for presentations with large video, audio or image data. These options can keep media in the source stream or temporary files instead of loading every media byte into memory. Keep the required stream open for the chosen locking behavior.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It generates a valid 60-second silent PCM WAV and embeds it in *audio.pptx*. Loading with a 1 KB in-memory BLOB budget permits media to spill to the caller-created *blob-temp* directory. The media is copied out through a stream, and disposing the presentation releases its temporary files. This example does not measure total process memory.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

const int sampleRate = 44100;
const int dataLength = sampleRate * 2 * 60;
using (var stream = File.Create("silence.wav"))
using (var writer = new BinaryWriter(stream))
{
    writer.Write(Encoding.ASCII.GetBytes("RIFF"));
    writer.Write(36 + dataLength);
    writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
    writer.Write(16);
    writer.Write((short)1);
    writer.Write((short)1);
    writer.Write(sampleRate);
    writer.Write(sampleRate * 2);
    writer.Write((short)2);
    writer.Write((short)16);
    writer.Write(Encoding.ASCII.GetBytes("data"));
    writer.Write(dataLength);
    writer.Write(new byte[dataLength]);
}
using (var source = new Presentation())
{
    using var audioStream = File.OpenRead("silence.wav");
    source.Slides[0].Shapes.AddAudioFrameEmbedded(40, 40, 80, 80, audioStream);
    source.Save("audio.pptx", SaveFormat.Pptx);
}
Directory.CreateDirectory("blob-temp");
var options = new LoadOptions
{
    BlobManagementOptions = new BlobManagementOptions
    {
        PresentationLockingBehavior = PresentationLockingBehavior.LoadAndRelease,
        IsTemporaryFilesAllowed = true,
        TempFilesRootPath = "blob-temp",
        MaxBlobsBytesInMemory = 1024
    }
};
using (var presentation = new Presentation("audio.pptx", options))
{
    var audio = presentation.Audios[0];
    using var media = audio.GetStream();
    using var output = File.Create("extracted.wav");
    media.CopyTo(output);
    Console.WriteLine($"Temporary files while open: {Directory.GetFiles("blob-temp", "*", SearchOption.AllDirectories).Length}");
}
Console.WriteLine($"Temporary files after disposal: {Directory.GetFiles("blob-temp", "*", SearchOption.AllDirectories).Length}");
```

## **FAQ**

### **Does this stream the entire slide model?**

No. Slides, shapes and other document objects are still held in memory. The savings mainly concern embedded binary media.

### **Which presentation data can BLOB options spill to disk?**

Large embedded audio, video and image BLOBs can use disk or source-stream storage under the selected options. Slide and shape objects still occupy memory; see the [BLOB guide](/slides/net/manage-blob/).

### **How long must I keep an input stream open?**

Keep it open while the presentation depends on it, especially with locking behavior that retains the source stream. Dispose the presentation before closing or changing the retained input stream.

## **Guides**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)

Related feature: [Control memory used by embedded media](/slides/features/memory-management/).

## Runnable .NET examples

- [Process Presentations with Large Media](/slides/net/examples/optimization-batch/large-media/)
