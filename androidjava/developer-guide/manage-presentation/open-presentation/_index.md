---
title: Open Presentation in Java
linktitle: Open Presentation
type: docs
weight: 20
url: /androidjava/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, Java"
description: "Open or load Presentation PPT, PPTX, ODP in Java"
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class and pass the file path (of the presentation you want to open) to its constructor. 

This Java code shows you how to open a presentation and also find out the number of slides it contains: 

```java
// Instantiates the Presentation class and passes the file path to its constructor
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Prints the total number of slides present in the presentation
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Open Password Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the [Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--) property (from the [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This Java code demonstrates the operation:

```java
 LoadOptions loadOptions = new LoadOptions();
 loadOptions.setPassword("YOUR_PASSWORD");
 Presentation pres = new Presentation("pres.pptx", loadOptions);
 try {
 // Do some work with the decrypted presentation
 } finally {
     if (pres != null) pres.dispose();
 }
```

## Open Large Presentation

Aspose.Slides provides options (the [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) property in particular) under the [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) class to allow you to load large presentations. 

This Java demonstrates an operation in which a large presentation (say 2GB in size) is loaded:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // The large presentation has been loaded and can be used, but the memory consumption is still low.
    // makes changes to the presentation.
    pres.getSlides().get_Item(0).setName("Very large presentation");

    // The presentation will be saved to the other file. The memory consumption stays low during the operation
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="Info" %}}

To circumvent certain limitations when interacting with a stream, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

When you want to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/java/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation

Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This Java code shows you how to use the `IResourceLoadingCallback` interface:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // loads substitute image
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // sets substitute url
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // skips all other images
        return ResourceLoadingAction.Skip;
    }
}
```

## Load Presentation Without Embedded Binary Objects

The PowerPoint presentation can contain the following types of the embedded binary objects:

- VBA Project ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- OLE Object embedded data ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX Control binary data ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Using the [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) property, you can load the presentation without any embedded binary objects.

This property can be useful for removing potentially malicious binary content.

The code demonstrates how to load and save a presentation without any malware content:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## Open and Save Presentation

Steps to Open and Save Presentation:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class and pass the file you want to open. 
2. Save the presentation.  

```java
// Instantiates a Presentation object that represents a PPT file
Presentation pres = new Presentation();
try {
    // ...do some work here...
    
    // Saves your presentation to a file
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```
