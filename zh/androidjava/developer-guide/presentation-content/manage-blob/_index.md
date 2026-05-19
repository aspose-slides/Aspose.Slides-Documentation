---
title: 在 Android 上管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/androidjava/manage-blob/
keywords:
- 大对象
- 大项
- 大文件
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
description: "在 Aspose.Slides for Android via Java 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---
## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常指以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Android via Java 允许您以降低内存消耗的方式在对象中使用 BLOB，特别是在处理大文件时。

{{% alert title="Info" color="info" %}}
为规避在流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致演示文稿内容被复制，从而出现加载缓慢的情况。因此，当您打算加载大型演示文稿时，强烈建议使用演示文稿文件路径而不是其流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/androidjava/) for Java 允许您通过 BLOB 过程添加大型文件（本例中为大型视频文件），以降低内存消耗。

下面的 Java 示例演示了如何通过 BLOB 过程将大型视频文件添加到演示文稿：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新演示文稿以添加视频
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
            // 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
            // 不打算访问 "veryLargeVideo.avi" 文件。
            IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
            pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

            // 保存演示文稿。在输出大型演示文稿时，内存消耗
            // 在 pres 对象的整个生命周期保持较低 
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
Aspose.Slides for Android via Java 允许您通过 BLOB 过程从演示文稿中导出大型文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件被加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存占用。

下面的 Java 代码演示了上述操作：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// 锁定源文件并且不将其加载到内存中
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// 创建 Presentation 实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 让我们将每个视频保存为文件。为防止高内存使用，我们需要一个缓冲区用于
    // 将演示文稿视频流的数据传输到新创建的视频文件流。
    byte[] buffer = new byte[8 * 1024];

    // 遍历视频
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // 打开演示文稿视频流。请注意，我们刻意避免访问属性
        // 如 video.BinaryData —— 因为该属性返回包含完整视频的字节数组，这会
        // 导致字节被加载到内存中。我们使用 video.GetStream，它将返回 Stream —— 并且不
        //  要求我们将整个视频加载到内存中。
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
        // 无论视频或演示文稿的大小，内存消耗都将保持低水平。
    }
    // 如有必要，您可以对音频文件执行相同的步骤。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **在演示文稿中将图像作为 BLOB 添加**
使用 [**IImageCollection**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IImageCollection) 接口和 [**ImageCollection**](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ImageCollection) 类的方法，您可以将大型图像以流的形式添加，从而将其视为 BLOB。

下面的 Java 代码展示了如何通过 BLOB 过程添加大型图像：

```java
String pathToLargeImage = "large_image.jpg";

// 创建一个新的演示文稿以添加图像。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
		// 不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。在输出大型演示文稿时，内存消耗
		// 在 pres 对象的整个生命周期保持低水平
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **内存与大型演示文稿**

通常情况下，加载大型演示文稿需要大量临时内存。所有演示文稿的内容都会被加载到内存中，而加载该演示文稿的文件则不再被使用。

设想有一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 Java 代码展示了加载该演示文稿的标准方法：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

但该方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过 BLOB 过程，您可以在使用很少内存的情况下加载大型演示文稿。下面的 Java 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

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

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存到其他文件夹，可以使用 `TempFilesRootPath` 更改存储设置：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

### **释放演示文稿对象以释放内存**

在处理大型演示文稿时，请确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例，以释放其占用的内存。使用完演示文稿后调用 `dispose()`，以释放非托管资源。

```java
Presentation presentation = new Presentation("large.pptx");

// ...处理演示文稿...
presentation.save("large.pdf", SaveFormat.Pdf);

// 显式释放资源。
presentation.dispose();
```

## **FAQ**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频、视频等大型二进制对象被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管理，您可以通过策略控制内存使用并在需要时溢写到临时文件。

**在哪里配置演示文稿加载期间的 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/blobmanagementoptions/)。在此可以设置 BLOB 的内存上限、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度与内存之间取得平衡？**

会。将 BLOB 保留在内存中可提升速度，但会增加 RAM 使用；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 占用但增加 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) 方法，根据工作负载和环境找到合适的平衡点。

**在打开极大型演示文稿（例如数 GB）时，BLOB 选项是否有帮助？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，并使处理非常大型演示文稿更加稳定。

**可以在从流而非磁盘文件加载时使用 BLOB 策略吗？**

可以。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于选定的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。