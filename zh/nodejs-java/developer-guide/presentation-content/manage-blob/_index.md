---
title: 管理 Blob
type: docs
weight: 10
url: /zh/nodejs-java/manage-blob/
description: 使用 JavaScript 在 PowerPoint 演示文稿中管理 Blob。使用 Blob 通过 JavaScript 减少 PowerPoint 演示文稿的内存消耗。使用 JavaScript 通过 Blob 将大型文件添加到 PowerPoint 演示文稿。使用 JavaScript 通过 Blob 从 PowerPoint 演示文稿导出大型文件。使用 JavaScript 将大型 PowerPoint 演示文稿以 Blob 形式加载。
---

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Node.js via Java 允许您以一种在处理大型文件时减少内存消耗的方式为对象使用 BLOB。

{{% alert title="Info" color="info" %}}
为了规避与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿的内容，从而导致加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议使用演示文稿的文件路径，而不是其流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/nodejs-java/) for Node.js via Java 允许您通过 BLOB 过程将大型文件（在本例中为大型视频文件）添加到演示文稿，以减少内存消耗。

此 JavaScript 示例展示了如何通过 BLOB 过程将大型视频文件添加到演示文稿：
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// 创建一个将添加视频的新演示文稿
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // 让我们将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件.
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在整个 pres 对象的生命周期内保持低水平
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


### **通过 BLOB 从演示文稿导出大型文件**

Aspose.Slides for Node.js via Java 允许您通过 BLOB 过程从演示文稿中导出大型文件（本例中为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

以下 JavaScript 代码演示了上述操作：
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// 锁定源文件且不将其加载到内存中
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// 创建 Presentation 实例，并锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 将每个视频保存到文件。为防止高内存使用，我们需要一个缓冲区来
    // 将演示文稿的视频流数据传输到新创建的视频文件的流中。
    var buffer = new byte[8 * 1024];
    // 遍历所有视频
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // 打开演示文稿的视频流。请注意，我们有意避免访问属性
        // 如 video.BinaryData - 因为此属性返回包含完整视频的字节数组，进而
        // 导致字节被加载到内存中。我们使用 video.GetStream，它返回 Stream 且不会
        // 需要我们将整个视频加载到内存中。
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
        // 无论视频或演示文稿的大小如何，内存消耗都将保持低水平。
    }
    // 如有必要，您可以对音频文件执行相同的步骤。
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **在演示文稿中以 BLOB 形式添加图像**

使用 [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) 类和 [**ImageCollection** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) 类的方法，您可以将大型图像作为流添加，以使其被视为 BLOB。

此 JavaScript 代码展示了如何通过 BLOB 过程添加大型图像：
```javascript
var pathToLargeImage = "large_image.jpg";
// 创建一个将要添加图像的新演示文稿。
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "largeImage.png" 文件。
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在整个 pres 对象的生命周期内保持低水平。
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


## **内存和大型演示文稿**

通常，加载大型演示文稿时，计算机需要大量临时内存。演示文稿的所有内容都会加载到内存中，而加载该演示文稿的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。加载该演示文稿的标准方法在以下 JavaScript 代码中描述：

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


但此方法会消耗约 1.6 GB 的临时内存。

### **以 BLOB 方式加载大型演示文稿**

通过 BLOB 过程，您可以在使用很少内存的情况下加载大型演示文稿。以下 JavaScript 代码展示了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果您希望将临时文件保存在其他文件夹中，可使用 `setTempFilesRootPath` 更改存储设置：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
当您使用 `setTempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频和视频等大型二进制对象被视为 BLOB。当演示文稿被加载或保存时，整个演示文稿文件也涉及 BLOB 处理。这些对象受 BLOB 策略控制，允许您管理内存使用并在需要时将数据转存到临时文件。

**在加载演示文稿时，我在哪里配置 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) 与 [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/)。在此可以设置 BLOB 的内存上限，是否允许临时文件，选择临时文件根路径，并选择源锁定行为。

**BLOB 设置会影响性能吗？我该如何在速度与内存之间平衡？**

是的。将 BLOB 保持在内存中可最大化速度，但会增加 RAM 消耗；降低内存上限会将更多工作转移到临时文件，从而在牺牲额外 I/O 的情况下减少 RAM。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 方法可为您的工作负载与环境找到合适的平衡。

**在打开极大（例如数 GB）演示文稿时，BLOB 选项有帮助吗？**

是的。[BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用并在处理极大演示文稿时保持稳定。

**在从流而非磁盘文件加载时，我可以使用 BLOB 策略吗？**

是的。相同规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选锁定模式），在允许时会使用临时文件，从而在处理过程中保持内存使用可预测。