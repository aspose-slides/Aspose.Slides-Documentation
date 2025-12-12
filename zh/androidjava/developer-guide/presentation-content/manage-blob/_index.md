---
title: 在 Android 上管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/androidjava/manage-blob/
keywords:
- 大型对象
- 大型项目
- 大型文件
- 添加 BLOB
- 导出 BLOB
- 将图像作为 BLOB 添加
- 降低内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上通过 Java 使用 Aspose.Slides 管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---

## **关于 BLOB**

**BLOB** (**二进制大对象**) 通常是以二进制格式保存的大型项（照片、演示文稿、文档或媒体）。

Aspose.Slides for Android via Java 允许您在处理大型文件时，以降低内存消耗的方式对对象使用 BLOB。

{{% alert title="Info" color="info" %}}
为了解决与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿内容并导致加载缓慢。因此，当您打算加载大型演示文稿时，强烈建议使用演示文稿文件路径而不是流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/androidjava/) for Java 允许您通过涉及 BLOB 的过程将大型文件（此处为大型视频文件）添加到演示文稿，以减少内存消耗。

以下 Java 示例演示如何通过 BLOB 过程将大型视频文件添加到演示文稿：
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个将要添加视频的新演示文稿
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在 pres 对象的整个生命周期内保持低水平 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **通过 BLOB 从演示文稿导出大型文件**

Aspose.Slides for Android via Java 允许您通过涉及 BLOB 的过程从演示文稿中导出大型文件（此处为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

以下 Java 代码演示上述操作：
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 锁定源文件且不将其加载到内存中
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 创建 Presentation 实例，并锁定 “hugePresentationWithAudiosAndVideos.pptx” 文件。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 让我们将每个视频保存到文件。为防止高内存使用，需要一个缓冲区
    // 用于将演示文稿的视频流数据传输到新创建的视频文件流。
    byte[] buffer = new byte[8 * 1024];

    // 遍历视频
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 打开演示文稿的视频流。请注意，我们有意避免访问属性
        // 如 video.BinaryData —— 因为此属性返回包含完整视频的字节数组，随后
        // 会导致字节加载到内存中。我们使用 video.GetStream，它返回 Stream 并且不
        //  不需要我们将整个视频加载到内存中。
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
        // 无论视频或演示文稿大小如何，内存消耗都保持低。
    }
    // 如有必要，您可以对音频文件执行相同的步骤。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **在演示文稿中将图像作为 BLOB 添加**

使用 [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) 类的方法，您可以将大型图像作为流添加，以使其被视为 BLOB。

以下 Java 代码展示如何通过 BLOB 过程添加大型图像：
```java
String pathToLargeImage = "large_image.jpg";

// 创建一个将要添加图像的新演示文稿。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
		// 不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。当输出大型演示文稿时，内存消耗
		// 在 pres 对象的整个生命周期内保持低水平。
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

通常，加载大型演示文稿需要大量临时内存。演示文稿的所有内容都会加载到内存中，而加载演示文稿的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。此 Java 代码描述了加载该演示文稿的标准方法：
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


但此方法会消耗约 1.6 GB 的临时内存。

### **以 BLOB 方式加载大型演示文稿**

通过 BLOB 过程，您可以在使用少量内存的情况下加载大型演示文稿。以下 Java 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：
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


### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可使用 `TempFilesRootPath` 更改存储设置：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹，需要您手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**

大型二进制对象，如图像、音频和视频，被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管理，您可以通过该策略控制内存使用并在需要时将数据溢写到临时文件。

**在加载演示文稿时，我在哪里配置 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) 和 [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/)。在此处可以设置 BLOB 的内存限制，是否允许临时文件，临时文件的根路径，以及源锁定行为。

**BLOB 设置会影响性能吗？我该如何在速度与内存之间取得平衡？**

是的。将 BLOB 保持在内存中可最大化速度，但会增加 RAM 使用；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用但会产生额外的 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 方法来为您的工作负载和环境找到合适的平衡。

**在打开极大（例如几 GB）演示文稿时，BLOB 选项有帮助吗？**

是的。[BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，并使处理极大文稿更稳定。

**在从流而非磁盘文件加载时，我可以使用 BLOB 策略吗？**

是的。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。