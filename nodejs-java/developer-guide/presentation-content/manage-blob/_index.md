---
title: Manage Blob
type: docs
weight: 10
url: /nodejs-java/manage-blob/
description: Manage Blob in PowerPoint Presentation using Java. Use Blob to reduce memory consumption in PowerPoint Presentation using Java. Add large file through Blob to PowerPoint Presentation using Java. Export large file through Blob from PowerPoint Presentation using Java. Load a large PowerPoint Presentation as Blob using Java.
---

## **About BLOB**

**BLOB** (**Binary Large Object**) is usually a large item (photo, presentation, document, or media) saved in binary formats. 

Aspose.Slides for Node.js via Java allows you to use BLOBs for objects in a way that reduces memory consumption when large files are involved.

{{% alert title="Info" color="info" %}}

To circumvent certain limitations when interacting with streams, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

{{% /alert %}}

## **Use BLOB to Reduce Memory Consumption**

### **Add Large File through BLOB to a Presentation**

[Aspose.Slides](/slides/nodejs-java/) for Java allows you to add large files (in this case, a large video file) through a process involving BLOBs to reduce memory consumption.

This Java shows you how to add a large video file through the BLOB process to a presentation:

```javascript
    var pathToVeryLargeVideo = "veryLargeVideo.avi";
    // Creates a new presentation to which the video will be added
    var pres = new  aspose.slides.Presentation();
    try {
        var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
        try {
            // Let's add the video to the presentation - we chose the KeepLocked behavior because we do
            // not intend to access the "veryLargeVideo.avi" file.
            var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
            pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
            // Saves the presentation. While a large presentation gets outputted, the memory consumption
            // stays low through the pres object's lifecycle
            pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
        } finally {
            if (fileStream != null) {
                fileStream.close();
            }
        }
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


### **Export Large File Through BLOB from Presentation**
Aspose.Slides for Node.js via Java allows you to export large files (in this case, an audio or video file) through a process involving BLOBs from presentations. For example, you may need to extract a large media file from a presentation but do not want the file to be loaded into your computer's memory. By exporting the file through the BLOB process, you get to keep memory consumption low.

This code in Java demonstrates the described operation:

```javascript
    var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
    var loadOptions = new  aspose.slides.LoadOptions();
    // Locks the source file and does NOT load it into memory
    loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
    // create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
    var pres = new  aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
    try {
        // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
        // to transfer the data from the presentation's video stream to a stream for a newly created video file.
        var buffer = new byte[8 * 1024];
        // Iterates through the videos
        for (var index = 0; index < pres.getVideos().size(); index++) {
            var video = pres.getVideos().get_Item(index);
            // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
            // like video.BinaryData - because this property returns a byte array containing a full video, which then
            // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
            // require us to load the whole video into the memory.
            var presVideoStream = video.getStream();
            try {
                var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
                try {
                    var bytesRead;
                    while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                        outputFileStream.write(buffer, 0, bytesRead);
                    }
                } finally {
                    outputFileStream.close();
                }
            } finally {
                presVideoStream.close();
            }
            // Memory consumption will remain low regardless of the size of the video or presentation.
        }
        // If necessary, you can apply the same steps for audio files.
    } catch (e) {console.log(e);
    } finally {
        pres.dispose();
    }
```

### **Add Image as BLOB in Presentation**
With methods from the [**IImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/IImageCollection) interface and [**ImageCollection** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) class, you can add a large image as a stream to get it treated as a BLOB.

This Java code shows you how to add a large image through the BLOB process:

```javascript
    var pathToLargeImage = "large_image.jpg";
    // creates a new presentation to which the image will be added.
    var pres = new  aspose.slides.Presentation();
    try {
        var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
        try {
            // Let's add the image to the presentation - we choose KeepLocked behavior because we do
            // NOT intend to access the "largeImage.png" file.
            var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
            pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            // Saves the presentation. While a large presentation gets outputted, the memory consumption
            // stays low through the pres object's lifecycle
            pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
        } finally {
            if (fileStream != null) {
                fileStream.close();
            }
        }
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Memory and Large Presentations**

Typically, to load a large presentation, computers require a lot of temporary memory. All the presentation's content is loaded into the memory and the file (from which the presentation was loaded) stops being used. 

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this Java code:

```javascript
    var pres = new  aspose.slides.Presentation("large.pptx");
    try {
        pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

But this method consumes around 1.6 GB of temporary memory. 

### **Load a Large Presentation as BLOB**

Through the process involving a BLOB, you can load up a large presentation while using little memory. This Java code describes the implementation where the BLOB process is used to load up a large presentation file (large.pptx):

```javascript
    var loadOptions = new  aspose.slides.LoadOptions();
    loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
    loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
    var pres = new  aspose.slides.Presentation("large.pptx", loadOptions);
    try {
        pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Change the Folder for Temporary Files**

When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using `TempFilesRootPath`:

```javascript
    var loadOptions = new  aspose.slides.LoadOptions();
    loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
    loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
    loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

When you use `TempFilesRootPath`, Aspose.Slides does not automatically create a folder to store temporary files. You have to create the folder manually. 

{{% /alert %}}
