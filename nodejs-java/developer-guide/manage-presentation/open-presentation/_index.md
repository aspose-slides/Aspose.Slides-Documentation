---
title: Open Presentation in Java
linktitle: Open Presentation
type: docs
weight: 20
url: /nodejs-java/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, Java"
description: "Open or load Presentation PPT, PPTX, ODP in Javascript"
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and pass the file path (of the presentation you want to open) to its constructor.

This Javascript code shows you how to open a presentation and also find out the number of slides it contains:

```javascript
    // Instantiates the Presentation class and passes the file path to its constructor
    var pres = new  aspose.slides.Presentation("Presentation.pptx");
    try {
        // Prints the total number of slides present in the presentation
        console.log(pres.getSlides().size());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Open Password Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the [Password](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getPassword--) property (from the [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This Javascript code demonstrates the operation:

```javascript
    var loadOptions = new  aspose.slides.LoadOptions();
    loadOptions.setPassword("YOUR_PASSWORD");
    var pres = new  aspose.slides.Presentation("pres.pptx", loadOptions);
    try {
        // Do some work with the decrypted presentation
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Open Large Presentation

Aspose.Slides provides options (the [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setBlobManagementOptions-aspose.slides.IBlobManagementOptions-) property in particular) under the [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions) class to allow you to load large presentations.

This Java demonstrates an operation in which a large presentation (say 2GB in size) is loaded:

```javascript
    var loadOptions = new  aspose.slides.LoadOptions();
    loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
    loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
    loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0);
    var pres = new  aspose.slides.Presentation("veryLargePresentation.pptx", loadOptions);
    try {
        // The large presentation has been loaded and can be used, but the memory consumption is still low.
        // makes changes to the presentation.
        pres.getSlides().get_Item(0).setName("Very large presentation");
        // The presentation will be saved to the other file. The memory consumption stays low during the operation
        pres.save("veryLargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert color="info" title="Info" %}}

To circumvent certain limitations when interacting with a stream, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

When you want to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/nodejs-java/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation

Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This Javascript code shows you how to use the `IResourceLoadingCallback` interface:

```javascript
    var opts = new  aspose.slides.LoadOptions();
    opts.setResourceLoadingCallback(java.newInstanceSync("ImageLoadingHandler"));
    var pres = new  aspose.slides.Presentation("presentation.pptx", opts);
```

```javascript
    class ImageLoadingHandler implements aspose.slides.IResourceLoadingCallback {
        public int resourceLoading(aspose.slides.IResourceLoadingArgs args) {
            if (args.getOriginalUri().endsWith(".jpg")) {
                // loads substitute image
                try {
                    var imageBytes = java.callStaticMethodSync("java.nio.file.Files", "readAllBytes", java.newInstanceSync("java.io.File", "aspose-logo.jpg").toPath());
                    args.setData(imageBytes);
                    return aspose.slides.ResourceLoadingAction.UserProvided;
                } catch (ex) {
                    return aspose.slides.ResourceLoadingAction.Skip;
                } catch (ex) {
                    console.log(ex);
                }
            } else if (args.getOriginalUri().endsWith(".png")) {
                // sets substitute url
                args.setUri("http://www.google.com/images/logos/ps_logo2.png");
                return aspose.slides.ResourceLoadingAction.Default;
            }
            // skips all other images
            return aspose.slides.ResourceLoadingAction.Skip;
        }
    }
```

## Load Presentation Without Embedded Binary Objects

The PowerPoint presentation can contain the following types of the embedded binary objects:

- VBA Project ([IPresentation.VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/));
- OLE Object embedded data ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX Control binary data ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/icontrol/#getActiveXControlBinary--));

Using the [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) property, you can load the presentation without any embedded binary objects.

This property can be useful for removing potentially malicious binary content.

The code demonstrates how to load and save a presentation without any malware content:

```javascript
    var loadOptions = new  aspose.slides.LoadOptions();
    loadOptions.setDeleteEmbeddedBinaryObjects(true);
    var pres = new  aspose.slides.Presentation("malware.ppt", loadOptions);
    try {
        pres.save("clean.ppt", aspose.slides.SaveFormat.Ppt);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Open and Save Presentation

Steps to Open and Save Presentation:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class and pass the file you want to open.
2. Save the presentation.  

```javascript
    // Instantiates a Presentation object that represents a PPT file
    var pres = new  aspose.slides.Presentation();
    try {
        // ...do some work here...
        // Saves your presentation to a file
        pres.save("demoPass.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
