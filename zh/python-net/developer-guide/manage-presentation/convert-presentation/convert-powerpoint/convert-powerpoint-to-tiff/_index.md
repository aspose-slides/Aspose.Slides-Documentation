---
title: 转换 PowerPoint 演示文稿 为 TIFF（Python）
titlelink: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/python-net/convert-powerpoint-to-tiff/
keywords:
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- PowerPoint 转 TIFF
- OpenDocument 转 TIFF
- 演示文稿 转 TIFF
- 幻灯片 转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- ODP 转 TIFF
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via .NET，轻松将 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 演示文稿转换为高质量的 TIFF 图像。提供包含代码示例的分步指南。"
---
## **简介**

TIFF（**Tagged Image File Format**）是一种广泛使用的无损栅格图像格式，以其卓越的质量和对图形的细致保存而著称。设计师、摄影师和桌面出版人员通常选择 TIFF 来保持图像中的图层、颜色准确性和原始设置。

使用 Aspose.Slides，您可以轻松地将 PowerPoint 幻灯片（PPT、PPTX）和 OpenDocument 幻灯片（ODP）直接转换为高质量的 TIFF 图像，确保您的演示文稿保持最高的视觉保真度。

## **将演示文稿转换为 TIFF**

使用 [save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/#methods) 方法，由 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类提供，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应默认幻灯片大小。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为 TIFF：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
with slides.Presentation("presentation.pptx") as presentation:
    # 将演示文稿保存为 TIFF。
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **将演示文稿转换为黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/) 类中的属性 [bw_conversion_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，仅当 [compression_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/compression_type/) 属性设置为 `CCITT4` 或 `CCITT3` 时，此设置才有效。

{{% alert color="info" title="注意" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) 是一个导出级别的设置，用于为完整的 TIFF 图像选择像素转换算法。若要定义在黑白显示模式下单个形状的呈现方式，请使用 [Shape.black_white_mode](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/black_white_mode/)。有关示例，请参阅 [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假设我们有一个名为 "sample.pptx" 的文件，其中包含以下幻灯片：

![演示文稿幻灯片](slide_black_and_white.png)

以下 Python 代码演示了如何将彩色幻灯片转换为黑白 TIFF：

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

结果：

![黑白 TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/) 中提供的属性设置所需的值。例如，属性 [image_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/image_size/) 允许您定义生成图像的尺寸。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义尺寸的 TIFF 图像：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # 设置压缩类型。
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # 设置图像 DPI。
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # 设置图像尺寸。
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # 使用指定尺寸将演示文稿保存为 TIFF。
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **将演示文稿转换为具有自定义像素格式的 TIFF**

使用来自 [TiffOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/) 类的属性 [pixel_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/pixel_format/)，您可以指定生成的 TIFF 图像的首选像素格式。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义像素格式的 TIFF 图像：

```py
import aspose.slides as slides

# 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # 使用指定的像素格式将演示文稿保存为 TIFF。
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="提示" color="info" %}}
查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？**

是的。Aspose.Slides 允许您将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片分别转换为 TIFF 图像。

**将演示文稿转换为 TIFF 时，幻灯片数量有限制吗？**

没有，Aspose.Slides 对幻灯片数量没有任何限制。您可以将任意大小的演示文稿转换为 TIFF 格式。

**将幻灯片转换为 TIFF 时，PowerPoint 动画和过渡效果会被保留吗？**

不会，TIFF 是一种静态图像格式。因此，动画和过渡效果不会被保留；仅导出幻灯片的静态快照。