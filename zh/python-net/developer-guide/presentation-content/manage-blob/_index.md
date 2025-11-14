---
title: 使用 Python 在演示文稿中管理 BLOB，实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/python-net/manage-blob/
keywords:
- 大型对象
- 大型项
- 大型文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 减少内存使用
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，从而高效处理演示文稿。"
---

### **关于 BLOB**

**BLOB** (**二进制大型对象**) 通常是指以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Python via .NET 允许您以降低内存消耗的方式使用 BLOB 处理大型文件。

# **使用 BLOB 减少内存消耗**

### **通过 BLOB 向演示文稿添加大型文件**

[Aspose.Slides](/slides/zh/python-net/) for .NET 允许您通过涉及 BLOB 的过程向演示文稿添加大型文件（在本例中是一个大型视频文件），以减少内存消耗。

下面的 Python 代码展示了如何通过 BLOB 过程向演示文稿添加大型视频文件：

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 创建一个新的演示文稿，视频将被添加到其中
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们不打算访问 "veryLargeVideo.avi" 文件。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # 保存演示文稿。尽管将输出一个大型演示文稿，但在 pres 对象的生命周期中内存消耗保持较低
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **通过 BLOB 从演示文稿导出大型文件**
Aspose.Slides for Python via .NET 允许您通过涉及 BLOB 的过程从演示文稿导出大型文件（在本例中是音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望将文件加载到计算机的内存中。通过 BLOB 过程导出该文件，可以保持低内存消耗。

下面的 Python 代码演示了描述的操作：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 保存每个视频到文件。为了防止高内存使用，我们需要一个缓冲区，用于将数据从演示文稿的视频流传输到新创建的视频文件的流中。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# 遍历视频
    index = 0
    # 如果有必要，您可以对音频文件应用相同的步骤。
    for video in pres.videos:
		# 打开演示文稿视频流。请注意，我们故意避免访问诸如 video.BinaryData 的属性 - 因为此属性会返回一个字节数组，包含完整视频，这会导致字节加载到内存中。我们使用 video.GetStream，该方法会返回 Stream - 并且不需要我们将整个视频加载到内存中。
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

### **将图像作为 BLOB 添加到演示文稿中**
使用 [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 接口和 [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，以将其视为 BLOB。

下面的 Python 代码展示了如何通过 BLOB 过程添加大型图像：

```py
import aspose.slides as slides

# 创建一个新的演示文稿，将图像添加到其中。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **内存和大型演示文稿**

通常，加载大型演示文稿需要很多临时内存。演示文稿的所有内容都会加载到内存中，并且不再使用加载演示文稿的文件。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。加载演示文稿的标准方法在下面的 Python 代码中进行了说明：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

但这种方法消耗大约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用很少内存的情况下加载大型演示文稿。下面的 Python 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **更改临时文件的文件夹**

当使用 BLOB 过程时，您的计算机会在默认的临时文件夹中创建临时文件。如果您希望将临时文件保存在不同的文件夹中，可以通过 `temp_files_root_path` 更改存储设置：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="信息" color="info" %}}

使用 `temp_files_root_path` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您必须手动创建该文件夹。

{{% /alert %}}