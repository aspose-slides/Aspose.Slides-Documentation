---
title: 在 JavaScript 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---
## **概述**

Aspose.Slides 提供基于 BLOB 的大二进制数据处理，以帮助在处理大图像、音频、视频和演示文稿文件时降低内存消耗。

本文展示了如何使用基于 BLOB 的处理向演示文稿添加大媒体、从演示文稿导出大媒体，以及更高效地加载大型演示文稿。还解释了在处理期间如何使用临时文件以及如何更改存储临时文件的文件夹。

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Node.js via Java 允许您在涉及大型文件时以降低内存消耗的方式使用对象的 BLOB。

{{% alert title="Info" color="info" %}}
为规避在与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿内容，从而导致加载缓慢。因此，当您打算加载大型演示文稿时，强烈建议使用演示文稿文件路径而非其流。
{{% /alert %}}

## **使用 BLOB 降低内存消耗**

### **通过 BLOB 向演示文稿添加大文件**

[Aspose.Slides](/slides/zh/nodejs-java/) for Node.js via Java 允许您通过 BLOB 过程添加大型文件（此处为大型视频文件），以降低内存消耗。

下面的 JavaScript 示例演示了如何通过 BLOB 过程向演示文稿添加大视频文件：

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// 创建一个将添加视频的新演示文稿
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // 让我们将视频添加到演示文稿中——我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件。
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在 pres 对象的整个生命周期中保持低水平
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

### **通过 BLOB 从演示文稿导出大文件**

Aspose.Slides for Node.js via Java 允许您通过 BLOB 过程从演示文稿导出大型文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存消耗。

下面的 JavaScript 代码演示了上述操作：

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// 锁定源文件并且不将其加载到内存中
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// 创建 Presentation 实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 让我们将每个视频保存到文件。为防止高内存使用，我们需要一个缓冲区用于
    // 从演示文稿的视频流传输数据到新创建的视频文件的流。
    var buffer = new byte[8 * 1024];
    // 遍历所有视频
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // 打开演示文稿的视频流。请注意，我们刻意避免访问属性
        // 例如 video.BinaryData ——因为此属性返回包含完整视频的字节数组，这会
        // 导致字节被加载到内存中。我们使用 video.GetStream，它将返回 Stream ——并且不会
        // 要求我们将整个视频加载到内存中。
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
        // 无论视频或演示文稿大小如何，内存消耗都将保持低水平。
    }
    // 如有必要，您可以对音频文件执行相同的步骤。
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **在演示文稿中将图像作为 BLOB 添加**

使用 [**ImageCollection**](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/ImageCollection) 类的方法，您可以将大型图像作为流添加，使其被视为 BLOB。

下面的 JavaScript 代码展示了如何通过 BLOB 过程添加大型图像：

```javascript
var pathToLargeImage = "large_image.jpg";
// 创建一个将添加图像的新演示文稿。
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 让我们将图像添加到演示文稿中——我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "largeImage.png" 文件。
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // 保存演示文稿。当输出大型演示文稿时，内存消耗
        // 在 pres 对象的整个生命周期中保持低水平
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

## **内存与大型演示文稿**

通常，加载大型演示文稿需要大量临时内存。演示文稿的所有内容会被加载到内存中，加载来源的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 JavaScript 代码展示了标准的加载方法：

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

### **将大型演示文稿作为 BLOB 加载**

通过 BLOB 过程，您可以在使用很少内存的情况下加载大型演示文稿。下面的 JavaScript 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

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

### **更改临时文件的文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可使用 `setTempFilesRootPath` 更改存储设置：

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
使用 `setTempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

### **释放演示文稿对象以释放内存**

在处理大型演示文稿时，请确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例，以释放其占用的内存。在完成演示文稿使用后调用 `dispose()`，以释放非托管资源。

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **常见问题**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频、视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略控制，您可以管理内存使用情况并在需要时将数据转储到临时文件。

**在哪里配置演示文稿加载期间的 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/) 配合 [BlobManagementOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/blobmanagementoptions/)。在此处设置 BLOB 的内存上限、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗？如何在速度与内存之间取得平衡？**

会。将 BLOB 保持在内存中可最大化速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用，但会产生额外的 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 方法，根据工作负载和环境找到合适的平衡点。

**在打开极大（例如数 GB）演示文稿时，BLOB 选项是否有帮助？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用并提升大型演示文稿的处理稳定性。

**在从流而非磁盘文件加载时，是否可以使用 BLOB 策略？**

可以。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。