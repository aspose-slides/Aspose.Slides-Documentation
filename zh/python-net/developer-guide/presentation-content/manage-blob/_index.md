---
title: 使用 Python 在演示文稿中管理 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/python-net/manage-blob/
keywords:
- 大型对象
- 大型项目
- 大文件
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
- Python
- Aspose.Slides
description: 通过 .NET 为 Python 的 Aspose.Slides 管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。
---

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Python via .NET 允许您以降低大文件涉及时内存消耗的方式为对象使用 BLOB。

## **使用 BLOB 降低内存消耗**

### **通过 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/python-net/) for .NET 允许您通过涉及 BLOB 的过程添加大型文件（此示例为大型视频文件），以降低内存消耗。

此 Python 示例演示如何通过 BLOB 过程将大型视频文件添加到演示文稿：

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 创建一个将添加视频的新演示文稿
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 让我们将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们不打算访问 "veryLargeVideo.avi" 文件。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # 保存演示文稿。虽然输出了大型演示文稿，但在 pres 对象的整个生命周期中内存消耗保持低位
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **通过 BLOB 从演示文稿导出大型文件**
Aspose.Slides for Python via .NET 允许您通过涉及 BLOB 的过程从演示文稿中导出大型文件（如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不想将文件加载到计算机的内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

下面的 Python 代码演示了上述操作：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 将每个视频保存到文件。为防止高内存使用，我们需要一个缓冲区，用于将演示文稿的视频流的数据传输到新创建的视频文件流中。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# 遍历视频
    index = 0
    # 如有必要，您也可以对音频文件应用相同的步骤。
    for video in pres.videos:
		# 打开演示文稿视频流。请注意，我们特意避免访问诸如 video.BinaryData 之类的属性——因为该属性返回包含完整视频的字节数组，这会导致字节被加载到内存中。我们使用 video.GetStream，它将返回 Stream，并且 **不** 需要我们将整个视频加载到内存中。
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **在演示文稿中将图像添加为 BLOB**
使用 [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 接口和 [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，以使其被视为 BLOB。

下面的 Python 代码展示了如何通过 BLOB 过程添加大型图像：

```py
import aspose.slides as slides

# 创建一个将添加图像的新演示文稿
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **内存和大型演示文稿**

通常，要加载大型演示文稿，计算机需要大量临时内存。演示文稿的所有内容都会加载到内存中，而加载演示文稿的文件则不再使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 Python 代码描述了加载该演示文稿的标准方法：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用很少内存的情况下加载大型演示文稿。下面的 Python 代码演示了使用 BLOB 过程加载大型演示文稿（large.pptx）的实现：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹中，可以使用 `temp_files_root_path` 更改存储设置：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
使用 `temp_files_root_path` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**  
图像、音频和视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管控，您可以通过这些策略管理内存使用并在需要时转储到临时文件。

**在演示文稿加载期间在哪里配置 BLOB 处理规则？**  
使用 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 配合 [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/)。在此处可以设置 BLOB 的内存限制、是否允许临时文件、临时文件根路径，以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度与内存之间取得平衡？**  
会。将 BLOB 保持在内存中可获得最高速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用，但会产生额外的 I/O。调节 [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) 阈值，以实现适合工作负载和环境的平衡。

**在打开极大演示文稿（如数 GB）时，BLOB 选项是否有帮助？**  
有。[BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，并使处理极大演示文稿更加稳定。

**从流而非磁盘文件加载时，是否同样可以使用 BLOB 策略？**  
可以。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。