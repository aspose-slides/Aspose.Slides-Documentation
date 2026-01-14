---
title: 使用 Python 管理演示文稿中的 BLOB，实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/python-net/manage-blob/
keywords:
- 大对象
- 大项目
- 大文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 降低内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---

## **关于 BLOB**

**BLOB** (**Binary Large Object**) 通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Python via .NET 允许您在处理大型文件时，以降低内存消耗的方式为对象使用 BLOB。

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/zh/python-net/) for .NET 允许您通过涉及 BLOB 的过程添加大文件（在本例中为大型视频文件），以减少内存消耗。

此 Python 示例演示如何通过 BLOB 过程将大型视频文件添加到演示文稿中：
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 创建一个将添加视频的新演示文稿
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
        # 并不打算访问 "veryLargeVideo.avi" 文件。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # 保存演示文稿。当生成大型演示文稿时，
        # 在 pres 对象的整个生命周期内，内存消耗保持低水平 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **通过 BLOB 从演示文稿导出大文件**

Aspose.Slides for Python via .NET 允许您通过涉及 BLOB 的过程从演示文稿中导出大文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望该文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

下面的 Python 代码演示了上述操作：
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 将每个视频保存到文件。为防止高内存使用，我们需要一个缓冲区来使用
	# 将演示文稿的视频流数据传输到新创建的视频文件流中。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# 遍历视频
    index = 0
    # 如有必要，您可以对音频文件执行相同的步骤。 
    for video in pres.videos:
		# 打开演示文稿的视频流。请注意，我们有意避免访问属性
		# 如 video.BinaryData —— 因为此属性返回包含完整视频的字节数组，随后
		# 会导致字节加载到内存中。我们使用 video.GetStream，它将返回 Stream——且不会
		#  需要我们将整个视频加载到内存中。
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


### **在演示文稿中将图像作为 BLOB 添加**

使用 [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，以便将其视为 BLOB。

以下 Python 代码展示如何通过 BLOB 过程添加大型图像：
```py
import aspose.slides as slides

# 创建一个将添加图像的新演示文稿。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **内存与大型演示文稿**

通常，要加载大型演示文稿，计算机需要大量临时内存。演示文稿的所有内容都会加载到内存中，而用于加载演示文稿的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。加载该演示文稿的标准方法在以下 Python 代码中描述：
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用极少内存的情况下加载大型演示文稿。以下 Python 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：
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
使用 `temp_files_root_path` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹，需要您手动创建该文件夹。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 演示文稿中哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频、视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略管控，您可以管理内存使用并在需要时将数据溢写到临时文件。

**在哪里配置演示文稿加载期间的 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 与 [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/)。在此处设置 BLOB 的内存上限、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗？如何在速度与内存之间取得平衡？**

会。将 BLOB 保持在内存中可提升速度，但会增加 RAM 使用；降低内存上限会将更多工作转移到临时文件，从而降低 RAM 占用，但会产生额外的 I/O。调节 [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) 阈值，以在您的工作负载和环境中实现合适的平衡。

**在打开极大型演示文稿（例如数 GB）时，BLOB 选项有帮助吗？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，提升对超大文件的处理稳定性。

**是否可以在从流而非磁盘文件加载时使用 BLOB 策略？**

可以。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。