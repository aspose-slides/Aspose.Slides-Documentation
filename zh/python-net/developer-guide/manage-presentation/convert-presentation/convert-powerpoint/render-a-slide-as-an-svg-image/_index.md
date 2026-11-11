---
title: 使用 Python 将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿 转 SVG
- 幻灯片 转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Python 将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本和图像。"
---
## **概览**

SVG 是一种基于 XML 的可伸缩图像格式，适用于 Web 发布、幻灯片浏览器、无障碍工作流以及自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并允许您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须保持紧凑、在各浏览器之间表现一致或准备好用于交互时，请使用 [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，选择幻灯片并将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

文件名使用 [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) 而不是循环索引。您也可以使用 [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 导出单个形状，以便幻灯片查看器或网页仅需要该形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) 将文本框包含在渲染区域内，而 [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 决定是否应用框的旋转。将 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 设置为 `True`，即可在渲染时去除连字。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **控制文本和字体**

将幻灯片导出为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体的包含或引用方式。以下选项帮助您在导出 SVG 的视觉一致性、文本可选取性和字体依赖之间取得平衡。

### **将所有文本矢量化**

将 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 设置为 `True`，可将所有幻灯片文本写入为矢量图形。这消除了字体依赖，使视觉结果在各浏览器间更一致，但文本不再可作为 SVG 文本进行选取或搜索。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **选择外部字体的处理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 的取值来处理外部加载的字体。选择 `ADD_LINKS_TO_FONT_FILES` 以引用单独的字体文件，`EMBED` 将字体数据嵌入 SVG，或 `VECTORIZE` 将使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **减少嵌入图像大小**

使用 [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 降低嵌入图片的分辨率，使用 [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 省略被裁剪的源区域，并使用 [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 编码质量。这些设置会在降低文件大小的同时牺牲图像保真度或保留的图像数据。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **控制元文件光栅化分辨率**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) 设置在 SVG 导出期间对元文件进行光栅化的最低分辨率限制。使用它可在对 EMF 或 WMF 图像进行光栅化时平衡细节与文件大小。它并不为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都变为光栅图像。

下载 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一张带有密集对角线的 EMF 图像。下面的示例通过 [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) 将其第一张幻灯片以三种光栅化分辨率导出。所有其他导出设置保持一致，以便对比结果。

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

在输出中，EMF 在每个 SVG 中都变为一个嵌入的 PNG。以下测量基于提供的演示文稿；它们并非将 DPI 转换为像素尺寸的通用公式。

| 元文件光栅化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下图显示了相同区域的嵌入光栅在相同放大显示尺寸下的效果。对角线在 72 DPI 时出现明显像素化，在更高分辨率下边缘更平滑，同时 SVG 文件体积增大。提升该数值并不一定能改进所有细节或改变每张导出图像。

![放大后的对角线细节（72、150 和 300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 控制图像分辨率降低，可能会掩盖更改元文件光栅化分辨率的效果。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 编码质量，而非元文件光栅化分辨率。

## **常见问题**

**何时应使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而不是 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)？**

当所有文本必须独立于字体时，请使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)。当仅需要将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)。

**缩小 SVG 的最佳方法是什么？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供字体文件时选择链接字体文件。请测试结果，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自会在质量和大小之间产生不同的权衡。