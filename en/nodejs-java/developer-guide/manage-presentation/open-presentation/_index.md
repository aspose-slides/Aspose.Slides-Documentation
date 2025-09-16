---
title: Open a Presentation in JavaScript
linktitle: Open Presentations
type: docs
weight: 20
url: /nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Open PowerPoint (.pptx, .ppt) and OpenDocument (.odp) presentations effortlessly with Aspose.Slides for Node.js—fast, reliable, fully featured."
---

## **Overview**

Beyond creating PowerPoint presentations from scratch, Aspose.Slides also lets you open existing presentations. After loading a presentation, you can retrieve information about it, edit slide content, add new slides, remove existing ones, and more.

## **Open Presentations**

To open an existing presentation, instantiate the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and pass the file path to its constructor.

The following JavaScript example shows how to open a presentation and get its slide count:

```js
// Instantiate the Presentation class and pass a file path to its constructor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Print the total number of slides in the presentation.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Open Password-Protected Presentations**

When you need to open a password-protected presentation, pass the password through the [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) method of the [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) class to decrypt and load it. The following JavaScript code demonstrates this operation:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Perform operations on the decrypted presentation.
} finally {
    presentation.dispose();
}
```

## **Open Large Presentations**

Aspose.Slides provides options—particularly the [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) method in the [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) class—to help you load large presentations.

The following JavaScript code demonstrates loading a large presentation (for example, 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.
    
    // Make changes to the presentation.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
    fs.rmSync(filePath);
} finally {
    presentation.dispose();
}

// It is OK to do it here. The source file is no longer locked by the presentation object.
fs.rmSync(filePath);
```

{{% alert color="info" title="Info" %}}

To work around certain limitations when working with streams, Aspose.Slides may copy a stream’s contents. Loading a large presentation from a stream causes the presentation to be copied and can slow loading. Therefore, when you need to load a large presentation, we strongly recommend using the presentation file path rather than a stream.

When creating a presentation that contains large objects (video, audio, high-resolution images, etc.), you can use [BLOB management](/slides/nodejs-java/manage-blob/) to reduce memory consumption.

{{%/alert %}}

## **Control External Resources**

Aspose.Slides provides the [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) interface that lets you manage external resources. The following JavaScript code shows how to use the `IResourceLoadingCallback` interface:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  args: function (args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Load a substitute image.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Set a substitute URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Skip all other images.
        return ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Load Presentations Without Embedded Binary Objects**

A PowerPoint presentation can contain the following types of embedded binary objects:

- VBA project (accessible via [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- OLE object embedded data (accessible via [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX control binary data (accessible via [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Using the [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) method, you can load a presentation without any embedded binary objects.

This method is useful for removing potentially malicious binary content. The following JavaScript code demonstrates how to load a presentation without any embedded binary content:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Perform operations on the presentation.
} finally {
    presentation.dispose();
}
```
