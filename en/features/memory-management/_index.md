---
title: Control memory used by embedded media
description: Set memory thresholds and temporary storage for embedded media.
type: docs
url: /features/memory-management/
weight: 1580
feature_id: memory-management
feature_group: runtime
translationKey: slides-feature-memory-management
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-blob/
---

## **Overview**

Use BLOB-management options to limit how much embedded media is held in memory and allow larger media to use temporary storage. Choose a temporary directory suitable for the application's workload. These controls are useful for decks with large audio or video content.

## **Usage example**

This C# example generates a valid one-second PCM tone and embeds it in media-input.pptx, then loads, saves and disposes that deck twice. It permits temporary BLOB storage in a caller-created directory and sets a 1,024-byte in-memory BLOB threshold. Source locking keeps the input available to the library while each presentation is open. After disposal the example opens that input exclusively and reports remaining temporary files. These settings do not cap total process memory or guarantee that a particular input spills to disk. No input file is required.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Text;

using var audioStream = new MemoryStream();
using (var writer = new BinaryWriter(audioStream, Encoding.ASCII, true))
{
    var frames = 8000;
    writer.Write(Encoding.ASCII.GetBytes("RIFF"));
    writer.Write(36 + frames * 2);
    writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
    writer.Write(16);
    writer.Write((short)1);
    writer.Write((short)1);
    writer.Write(8000);
    writer.Write(16000);
    writer.Write((short)2);
    writer.Write((short)16);
    writer.Write(Encoding.ASCII.GetBytes("data"));
    writer.Write(frames * 2);
    for (var i = 0; i < frames; i++)
    {
        writer.Write((short)(Math.Sin(2 * Math.PI * 440 * i / 8000) * 4000));
    }
}
audioStream.Position = 0;
using (var input = new Presentation())
{
    input.Slides[0].Shapes.AddAudioFrameEmbedded(80, 80, 80, 80, audioStream);
    input.Save("media-input.pptx", SaveFormat.Pptx);
}
var temporaryDirectory = Path.GetFullPath("blob-temp");
Directory.CreateDirectory(temporaryDirectory);
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
for (var i = 0; i < 2; i++)
{
    using var presentation = new Presentation("media-input.pptx", loadOptions);
    presentation.Save($"media-output-{i}.pptx", SaveFormat.Pptx);
}
using (var unlockedInput = File.Open("media-input.pptx", FileMode.Open, FileAccess.ReadWrite, FileShare.None))
{
    Console.WriteLine("Input file is available after presentation disposal.");
}
Console.WriteLine($"Temporary files after disposal: {Directory.GetFiles(temporaryDirectory, "*", SearchOption.AllDirectories).Length}");
```

## **FAQ**

### **Is the media threshold a cap on all memory used by the library?**

No. It applies to embedded binary data. The presentation's slide and shape model still needs memory of its own.

### **Why should I dispose a presentation after use?**

Disposal releases the presentation's unmanaged resources and file/stream locks. Keep the presentation alive while using its objects, then dispose it before reusing or replacing locked input files.

### **How can I choose a temporary directory for BLOB data?**

Create a writable directory and assign its absolute path in the BLOB load options. Budget enough disk space for concurrent work; the library does not create the directory for you.

## **Guides**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)

Related feature: [Stream large media while processing presentations](/slides/features/stream-media/).
