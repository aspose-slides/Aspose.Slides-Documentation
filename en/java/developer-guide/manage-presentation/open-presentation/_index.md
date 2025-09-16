---
title: Open a Presentation in Java
linktitle: Open Presentations
type: docs
weight: 20
url: /java/open-presentation/
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
- Java
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for Java—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class and pass the file path to its constructor.

The following Java example shows how to open a presentation and get its slide count:

```java
// Instantiate the Presentation class and pass a file path to its constructor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Print the total number of slides in the presentation.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Open Password-Protected Presentations**

When you need to open a password-protected presentation, pass the password through the [setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) method of the [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) class to decrypt and load it. The following Java code demonstrates this operation:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Perform operations on the decrypted presentation.
} finally {
    presentation.dispose();
}
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the [getBlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) method in the [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) class—to help you load large presentations.

The following Java code demonstrates loading a large presentation (for example, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// It is OK to do it here. The source file is no longer locked by the presentation object.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use [BLOB management](/slides/java/manage-blob/) to reduce memory consumption.

{{%/alert %}} 

## **Control External Resources**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) interface that lets you manage external resources. The following Java code shows how to use the `IResourceLoadingCallback` interface:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Load a substitute image.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Set a substitute URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Skip all other images.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Load Presentations Without Embedded Binary Objects**

A PowerPoint presentation can contain the following types of embedded binary objects:

- VBA project (accessible via [IPresentation.getVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getVbaProject--));
- OLE object embedded data (accessible via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX control binary data (accessible via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Using the [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) method, you can load a presentation without any embedded binary objects.

This method is useful for removing potentially malicious binary content. The following Java code demonstrates how to load a presentation without any embedded binary content:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Perform operations on the presentation.
} finally {
    presentation.dispose();
}
```
