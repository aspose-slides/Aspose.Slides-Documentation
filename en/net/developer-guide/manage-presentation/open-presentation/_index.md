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
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for .NET—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and pass the file path to its constructor.

The following C# example shows how to open a presentation and get its slide count:

```cs
// Instantiate the Presentation class and pass a file path to its constructor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Print the total number of slides in the presentation.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Open Password-Protected Presentations**

When you need to open a password-protected presentation, pass the password through the [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) property of the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) class to decrypt and load it. The following C# code demonstrates this operation:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Perform operations on the decrypted presentation.
}
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) property in the [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) class—to help you load large presentations.

The following C# code demonstrates loading a large presentation (for example, 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of 
        // the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    presentation.Slides[0].Name = "Large presentation";

    // Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    File.Delete(filePath);
}

// It is OK to do it here. The source file is no longer locked by the presentation object.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use [BLOB management](/slides/net/manage-blob/) to reduce memory consumption.

{{%/alert %}}

## **Control External Resources**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) interface that lets you manage external resources. The following C# code shows how to use the `IResourceLoadingCallback` interface:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Load a substitute image.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Set a substitute URL.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Skip all other images.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Load Presentations Without Embedded Binary Objects**

A PowerPoint presentation can contain the following types of embedded binary objects:

- VBA project (accessible via [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLE object embedded data (accessible via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX control binary data (accessible via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

Using the [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) property, you can load a presentation without any embedded binary objects.

This property is useful for removing potentially malicious binary content. The following C# code demonstrates how to load a presentation without any embedded binary content:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Perform operations on the presentation.
}
```

## **FAQ**

**How can I tell that a file is corrupted and can’t be opened?**

You’ll get a parsing/format validation exception during load. Such errors often mention an invalid ZIP structure or broken PowerPoint records.

**What happens if required fonts are missing when opening?**

The file will open, but later [rendering/export](/slides/net/convert-presentation/) may substitute fonts. [Configure font substitutions](/slides/net/font-substitution/) or [add the required fonts](/slides/net/custom-font/) to the runtime environment.

**What about embedded media (video/audio) when opening?**

They become available as presentation resources. If media are referenced via external paths, ensure those paths are accessible in your environment; otherwise [rendering/export](/slides/net/convert-presentation/) may omit the media.
