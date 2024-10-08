---
title: 管理 Blob
type: docs
weight: 10
url: /java/manage-blob/
description: 使用 Java 在 PowerPoint 演示文稿中管理 Blob。使用 Blob 减少 PowerPoint 演示文稿的内存消耗。通过 Blob 将大文件添加到 PowerPoint 演示文稿中。通过 Blob 从 PowerPoint 演示文稿导出大文件。使用 Java 将大 PowerPoint 演示文稿作为 Blob 加载。
---

## **关于 BLOB**

**BLOB** （**二进制大对象**）通常是以二进制格式保存的大项（照片、演示文稿、文档或媒体）。 

Aspose.Slides for Java 允许您以减少内存消耗的方式使用 BLOB 处理大文件。

{{% alert title="信息" color="info" %}}

为了规避与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大演示文稿会导致演示文稿的内容被复制，并造成加载缓慢。因此，当您打算加载大演示文稿时，我们强烈建议您使用演示文稿文件路径而不是其流。

{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 向演示文稿添加大文件**

[Aspose.Slides](/slides/java/) for Java 允许您通过涉及 BLOB 的处理过程向演示文稿添加大文件（在这种情况下是一个大视频文件），以减少内存消耗。

以下 Java 示例演示如何通过 BLOB 处理过程向演示文稿添加大视频文件：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新的演示文稿，将视频添加到其中
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们无意访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。在输出大演示文稿的同时，内存消耗在 pres 对象的生命周期中保持低。
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **通过 BLOB 从演示文稿导出大文件**
Aspose.Slides for Java 允许您通过涉及 BLOB 的处理过程从演示文稿导出大文件（在这种情况下是音频或视频文件）。例如，您可能需要从演示文稿中提取一个大媒体文件，但又不希望将文件加载到计算机内存中。通过 BLOB 处理过程导出文件可以保持低内存消耗。 

以下 Java 代码演示了所描述的操作：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 锁定源文件并不将其加载到内存
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 创建演示文稿实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 将每个视频保存到文件。为了防止高内存使用，我们需要一个缓冲区，用于将数据从演示文稿的视频流传输到新创建的视频文件的流中。
    byte[] buffer = new byte[8 * 1024];

    // 遍历视频
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 打开演示文稿视频流。请注意，我们故意避免访问诸如 video.BinaryData 的属性 - 因为此属性返回一个包含完整视频的字节数组，这会导致字节被加载到内存中。我们使用 video.GetStream，它会返回一个流，并且不需要将整个视频加载到内存中。
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // 无论视频或演示文稿的大小如何，内存消耗都会保持较低。
    }
    // 如有必要，您可以对音频文件应用相同的步骤。
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **在演示文稿中作为 BLOB 添加图像**
使用 [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) 类中的方法，您可以作为流添加大型图像，以将其视为 BLOB。

以下 Java 代码演示了如何通过 BLOB 处理过程添加大型图像：

```java
String pathToLargeImage = "large_image.jpg";

// 创建一个新的演示文稿，将图像添加到其中。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们无意访问 "largeImage.png" 文件。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。在输出大型演示文稿的同时，内存消耗在 pres 对象的生命周期中保持低。
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **内存和大型演示文稿**

通常，加载大型演示文稿时，计算机需要大量临时内存。演示文稿的所有内容都加载到内存中，并且不再使用加载演示文稿的文件。

考虑一个包含 1.5 GB 视频文件的大 PowerPoint 演示文稿（large.pptx）。加载演示文稿的标准方法如下 Java 代码所示：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

但这种方法消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用少量内存的同时加载一个大型演示文稿。以下 Java 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **更改临时文件的文件夹**

使用 BLOB 过程时，您的计算机会在默认的临时文件夹中创建临时文件。如果您希望临时文件保存在不同的文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="信息" color="info" %}}

当您使用 `TempFilesRootPath` 时，Aspose.Slides 并不会自动创建存储临时文件的文件夹。您需要手动创建该文件夹。

{{% /alert %}}