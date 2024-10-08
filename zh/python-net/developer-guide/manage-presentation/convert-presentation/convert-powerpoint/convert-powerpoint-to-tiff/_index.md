---
title: 将 PowerPoint 转换为 TIFF
type: docs
weight: 90
url: /python-net/convert-powerpoint-to-tiff/
keywords: "将 PowerPoint 演示文稿转换为 TIFF, PowerPoint 转 TIFF, PPT 转 TIFF, PPTX 转 TIFF, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint 演示文稿转换为 TIFF"
---

**TIFF**（标记图像文件格式）是一种无损的光栅高质量图像格式。专业人士使用 TIFF 进行设计、摄影和桌面出版。例如，如果您想在设计或图像中保留图层和设置，则可能希望将您的工作保存为 TIFF 图像文件。

Aspose.Slides 允许您将 PowerPoint 中的幻灯片直接转换为 TIFF。

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose 的 [免费 PowerPoint 到海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **将 PowerPoint 转换为 TIFF**

使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类中暴露的 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应于幻灯片的默认大小。

以下 Python 代码向您展示如何将 PowerPoint 转换为 TIFF：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
presentation = slides.Presentation("pres.pptx")
# 将演示文稿保存为 TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **将 PowerPoint 转换为黑白 TIFF**

在 Aspose.Slides 23.10 中，Aspose.Slides 向 [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) 类添加了一个新的属性 `bw_conversion_mode`，以允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时遵循的算法。注意，只有当 `compression_type` 属性设置为 `CCITT4` 或 `CCITT3` 时，此设置才会生效。

以下 Python 代码向您展示如何将彩色幻灯片或图像转换为黑白 TIFF：

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **将 PowerPoint 转换为具有自定义大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以通过 [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) 下提供的属性定义您首选的尺寸。例如，使用 `image_size` 属性，您可以为生成的图像设置大小。

以下 Python 代码向您展示如何将 PowerPoint 转换为具有自定义大小的 TIFF 图像：

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("pres.pptx")

# 实例化 TiffOptions 类
opts = slides.export.TiffOptions()

# 设置压缩类型
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 设置图像 DPI
opts.dpi_x = 200
opts.dpi_y = 100

# 设置图像大小
opts.image_size = drawing.Size(1728, 1078)

# 将演示文稿保存为指定大小的 TIFF
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```


## **将 PowerPoint 转换为具有自定义图像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) 类下的 `pixel_format` 属性，您可以为生成的 TIFF 图像指定首选像素格式。

以下 Python 代码向您展示如何将 PowerPoint 转换为具有自定义像素格式的 TIFF 图像：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("pres.pptx")

# 实例化 TiffOptions 类
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# 将演示文稿保存为 TIFF 以指定的像素格式
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```