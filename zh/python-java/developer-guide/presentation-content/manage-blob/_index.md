---
title: 在 Python via Java 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/python-java/manage-blob/
keywords:
- 大对象
- 大项目
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---
## **概述**

Aspose.Slides 为演示文稿中的大型二进制数据（如图像、音频、视频和演示文件）提供基于 BLOB 的处理，以帮助降低内存消耗。

本文展示了如何使用基于 BLOB 的处理向演示文稿添加大型媒体、从演示文稿导出大型媒体，以及更高效地加载大型演示文稿。还说明了在处理过程中如何使用临时文件以及如何更改存储临时文件的文件夹。

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for Python via Java 允许您以降低内存消耗的方式在对象上使用 BLOB，尤其是在处理大型文件时。

{{% alert color="info" title="注意" %}}
为绕过与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿会导致复制演示文稿的内容并造成加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而不是其流。
{{% /alert %}}

## **使用 BLOB 减少内存消耗**

### **使用 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/python-java/) for Python via Java 允许您通过 BLOB 过程添加大型文件（本例中为大型视频文件），以降低内存消耗。

以下 Python 代码演示了如何通过 BLOB 过程将大型视频文件添加到演示文稿中：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# 创建一个将在其中添加视频的新演示文稿。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # 将流保持锁定，因为我们不打算访问视频文件。
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # 在保持低内存消耗的情况下保存演示文稿。
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **使用 BLOB 从演示文稿导出大型文件**
Aspose.Slides for Python via Java 允许您通过 BLOB 过程从演示文稿中导出大型文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不想将文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存消耗。

以下 Python 代码演示了上述操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# 锁定源文件而不是将其加载到内存中。
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # 通过缓冲区传输视频数据以保持低内存消耗。
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # 使用流而不是将整个视频加载到字节数组中。
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # 如有必要，对音频文件执行相同的步骤。
finally:
    presentation.dispose()
```

### **将图像作为 BLOB 添加到演示文稿**
使用 [ImageCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/) 类的方法，您可以将大型图像作为流添加，使其被视为 BLOB。

以下 Python 代码演示了如何通过 BLOB 过程添加大型图像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 创建一个将在其中添加图像的新演示文稿。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 将流保持锁定，因为我们不打算访问图像文件。
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # 在保持低内存消耗的情况下保存演示文稿。
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **内存与大型演示文稿**

通常，加载大型演示文稿需要大量临时内存。演示文稿的全部内容会被加载到内存中，而用于加载的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 Python 代码展示了加载该演示文稿的标准方法：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

使用 BLOB 处理，您可以在占用极少内存的情况下加载大型演示文稿。以下 Python 代码展示了如何使用 BLOB 处理加载大型演示文稿文件（large.pptx）：

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 更改存储设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="注意" %}}
使用 [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

### **处理完演示文稿对象以释放内存**

在处理大型演示文稿时，请确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例，以释放其占用的内存。完成演示文稿使用后，调用 [Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose) 以释放非托管资源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...处理演示文稿...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # 明确释放资源。
    presentation.dispose()
```

## **FAQ**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频和视频等大型二进制对象会被视为 BLOB。整个演示文稿文件在加载或保存时也会涉及 BLOB 处理。这些对象受 BLOB 策略管控，您可以通过策略管理内存使用并在需要时溢写到临时文件。

**在演示文稿加载期间，我在哪里配置 BLOB 处理规则？**

使用带有 [BlobManagementOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blobmanagementoptions/) 的 [LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/)。在此可以设置 BLOB 的内存上限、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度与内存之间取得平衡？**

会。将 BLOB 保留在内存中可获得最高速度，但会增加 RAM 消耗；降低内存上限会将更多工作转移到临时文件，从而降低 RAM 使用，但会产生额外的 I/O。使用 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) 方法根据工作负载和环境找到合适的平衡点。

**在打开极大（比如 GB 级）演示文稿时，BLOB 选项有帮助吗？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可以显著降低峰值 RAM 使用，并使处理极大文稿更稳定。

**在从流而非磁盘文件加载时，我可以使用 BLOB 策略吗？**

可以。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，以在处理期间保持可预测的内存使用。