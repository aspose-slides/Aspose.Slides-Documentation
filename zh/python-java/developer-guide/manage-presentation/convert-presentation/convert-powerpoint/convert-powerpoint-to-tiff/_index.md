---
title: 在 Python 中将 PowerPoint 演示文稿转换为 TIFF
linktitle: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/python-java/convert-powerpoint-to-tiff/
keywords:
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿 转 TIFF
- 幻灯片 转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- 将 PPT 保存为 TIFF
- 将 PPTX 保存为 TIFF
- 导出 PPT 为 TIFF
- 导出 PPTX 为 TIFF
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java，轻松将 PowerPoint (PPT, PPTX) 演示文稿转换为高质量的 TIFF 图像，并附带代码示例。"
---
## **介绍**

TIFF（**Tagged Image File Format**）是一种栅格图像格式，支持多页和无损压缩。它对于在单个图像文件中存储渲染后的幻灯片非常有用。

使用 Aspose.Slides for Python via Java，您可以将 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿转换为 TIFF。下面的每个示例在需要时启动 Java 虚拟机，并在使用后释放演示文稿。

## **将演示文稿转换为 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类提供的 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的多页 TIFF 包含每张幻灯片的渲染图像，尺寸为默认大小。

以下代码演示如何将 PowerPoint 演示文稿转换为 TIFF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 将所有幻灯片保存为多页 TIFF 文件。
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **将演示文稿转换为黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 类中，方法 [setBwConversionMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setBwConversionMode) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，此设置仅在 [setCompressionType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setCompressionType) 方法设置为 [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) 或 [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) 时生效。

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setBwConversionMode) 是一个导出级别的设置，用于为整个 TIFF 图像选择像素转换算法。要定义在黑白显示模式下单个形状的显示方式，请使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setBlackWhiteMode)。有关示例，请参阅 [Control Black-and-White Rendering for Shapes](/slides/zh/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假设我们有一个名为 "sample.pptx" 的文件，其中包含以下幻灯片：

![演示文稿幻灯片](slide_black_and_white.png)

以下代码演示如何将彩色幻灯片转换为黑白 TIFF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jptype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

结果：

![黑白 TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 中提供的方法设置所需的值。例如，方法 [setImageSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setImageSize) 允许您定义生成图像的大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # 设置水平和垂直分辨率。
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # 设置输出尺寸（像素）。
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # 在每张幻灯片下方包含完整的演讲者备注。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **将演示文稿转换为具有自定义像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/) 类中的 [setPixelFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/tiffoptions/#setPixelFormat) 方法，您可以为生成的 TIFF 图像指定首选的像素格式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Tip" color="success" %}}
查看 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？**

可以。Aspose.Slides 允许您将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片分别转换为 TIFF 图像。

**在将演示文稿转换为 TIFF 时，幻灯片数量是否有限制？**

TIFF 导出没有固定的幻灯片数量限制。可用内存、幻灯片复杂度和输出尺寸会影响您能够处理的演示文稿大小。

**在将幻灯片转换为 TIFF 时，PowerPoint 动画和过渡效果会被保留吗？**

不会，TIFF 是一种静态图像格式。因此，动画和过渡效果不会被保留，只会导出幻灯片的静态快照。