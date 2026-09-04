---
title: Open Presentations in .NET
linktitle: Open Presentation
type: docs
weight: 20
url: /net/open-presentation/
keywords:
- open PowerPoint
- open presentation
- open PPTX
- open PPT
- open ODP
- load presentation
- load PPTX
- load PPT
- load ODP
- protected presentation
- large presentation
- external resource
- binary object
- .NET
- C#
- Aspose.Slides
description: "Learn how to open PowerPoint and OpenDocument presentations in C#, supply opening passwords, control resource loading, and reduce memory use with Aspose.Slides for .NET."
---

## **Introduction**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) can load PowerPoint and OpenDocument presentations from files and streams. After a presentation is loaded, you can inspect its structure, edit slides, manage resources, and save it in the original or another supported format.

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside managed memory, control external resources, or omit embedded binary data.

## **Open Presentations**

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) constructor. Dispose the presentation after use so that file handles, temporary data, and other resources are released promptly.

The following C# example shows how to open a presentation and get its slide count:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Open Password-Protected Presentations**

An opening password encrypts presentation content. To load the complete presentation, assign the correct password to [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) and pass the options to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/net/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/net/presentation-properties/).

## **Open Large Presentations**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) controls how Aspose.Slides handles binary large objects such as images, audio, and video. You can keep the source file locked, allow temporary files, and limit the amount of BLOB data retained in memory.

The following C# code demonstrates loading a large presentation (for example, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}

With `PresentationLockingBehavior.KeepLocked`, the source file remains locked until the `Presentation` object is disposed. Do not move, overwrite, or delete the source file while that object is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/net/manage-blob/) for additional storage and memory-management options.

{{% /alert %}}

## **Control External Resources**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/resourceloadingcallback/) accepts an [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) implementation. The callback can supply replacement data, redirect a resource, use the default loader, or skip the resource. This is useful when presentations contain external images that must be resolved according to application-specific security or storage rules.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Load Presentations without Embedded Binary Objects**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- VBA projects, available through [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/);
- embedded OLE data, available through [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- ActiveX control data, available through [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/).

Set [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) to `true` to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides throws a parsing or format exception during loading. Handle that failure separately from an incorrect-password error so that the application can report the cause accurately.

**What happens if required fonts are missing?**

The presentation can still load, but rendering and export may substitute fonts. You can [configure font substitution](/slides/net/font-substitution/) or [provide custom fonts](/slides/net/custom-font/) to make output more predictable.

**Does loading a presentation also load its embedded media?**

Embedded audio and video become available through the presentation object model. External resources are resolved according to the configured resource-loading behavior and may be unavailable if their locations cannot be accessed.
