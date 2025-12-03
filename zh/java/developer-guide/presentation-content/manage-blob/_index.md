---
title: 在 Java 中管理演示文稿 BLOB，以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/java/manage-blob/
keywords:
- 大型对象
- 大型项目
- 大型文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 减少内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---

## **关于 BLOB**

**BLOB** (**Binary Large Object**) 通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Java 允许您在处理大型文件时，以降低内存消耗的方式为对象使用 BLOB。

{{% alert title="Info" color="info" %}}
为了解决与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿内容，从而导致加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议使用演示文稿的文件路径，而不是流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/zh/java/) for Java 允许您通过 BLOB 过程添加大文件（此处为大型视频文件），以降低内存消耗。

下面的 Java 示例展示了如何通过 BLOB 过程将大型视频文件添加到演示文稿中：
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新的演示文稿，以便添加视频
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // 将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在整个 pres 对象的生命周期内保持低
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
Aspose.Slides for Java 允许您通过 BLOB 过程从演示文稿中导出大文件（此处为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存消耗。

以下 Java 代码演示了上述操作：
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 将源文件锁定且不加载到内存中
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 创建 Presentation 实例，并锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 将每个视频保存为文件。为防止高内存使用，我们需要一个缓冲区来使用
    // 将演示文稿的视频流数据传输到新创建的视频文件的流中.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 打开演示文稿的视频流。请注意，我们有意避免访问属性
        // 如 video.BinaryData —— 因为该属性返回包含完整视频的字节数组，这会
        // 导致字节被加载到内存中。我们使用 video.GetStream，它返回 Stream 且不会
        //  需要我们将整个视频加载到内存中。
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
        // 无论视频或演示文稿的大小如何，内存消耗都将保持低水平。
    }
    // 如有必要，您可以对音频文件执行相同的步骤。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **在演示文稿中将图像添加为 BLOB**
使用 [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) 类的方法，您可以将大图像作为流添加，以将其视为 BLOB。

以下 Java 代码展示了如何通过 BLOB 过程添加大图像：
```java
String pathToLargeImage = "large_image.jpg";

// 创建一个新的演示文稿，将向其添加图像。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
		// 不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。当输出大型演示文稿时，内存消耗
		// 在整个 pres 对象的生命周期内保持低。
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

通常，加载大型演示文稿需要大量临时内存。演示文稿的全部内容会被加载到内存中，而加载该演示文稿的文件则不再使用。

假设有一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿 (large.pptx)。加载该演示文稿的标准方法如下 Java 代码所示：
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**
通过 BLOB 过程，您可以在占用少量内存的情况下加载大型演示文稿。以下 Java 代码描述了使用 BLOB 过程加载大型演示文稿文件 (large.pptx) 的实现：
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
使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可以使用 `TempFilesRootPath` 更改存储设置：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建存放临时文件的文件夹，需要您手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**
图像、音频和视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略约束，您可以通过该策略管理内存使用，并在需要时溢写到临时文件。

**在加载演示文稿时，我在哪里配置 BLOB 处理规则？**
使用带有 [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) 的 [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)。在此可以设置 BLOB 的内存限制，允许或禁止临时文件，选择临时文件的根路径，并选择源锁定行为。

**BLOB 设置会影响性能吗，如何在速度与内存之间取得平衡？**
是的。将 BLOB 保持在内存中可最大化速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而在降低 RAM 使用的同时增加 I/O 开销。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 方法，以在您的工作负载和环境中实现合适的平衡。

**在打开极大型演示文稿（例如，数千兆字节）时，BLOB 选项有帮助吗？**
是的。针对这种情况设计了 [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/)，启用临时文件并使用源锁定可以显著降低峰值 RAM 使用，并在处理极大型演示文稿时保持稳定。

**在从流而非磁盘文件加载时，我可以使用 BLOB 策略吗？**
是的。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），在允许的情况下使用临时文件，从而在处理期间保持内存使用可预测。