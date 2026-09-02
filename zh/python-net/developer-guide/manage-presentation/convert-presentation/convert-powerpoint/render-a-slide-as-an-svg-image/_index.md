---
title: 在 Python 中将演示文稿幻灯片渲染为 SVG 图像
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
description: "在 Python 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本和图像。"
---
## **概述**

SVG 是一种基于 XML 的可缩放图像格式，适用于网页发布、幻灯片查看器、可访问性工作流以及自动化后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在浏览器间保持可预期，或准备好用于交互时，请使用 [SVGOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)，选择幻灯片并将其写入流。下面的示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

文件名使用 [Slide.slide_number](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/slide_number/) 而不是循环索引。当幻灯片查看器或网页只需要某个形状时，您也可以使用 [Shape.write_as_svg](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/write_as_svg/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.use_frame_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/use_frame_size/) 将文本框包含在渲染区域内，且 [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 决定是否应用框的旋转。当文本必须在不使用连字的情况下渲染时，将 [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 设置为 `True`。

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

### **向量化所有文本**

将 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/vectorize_text/) 设置为 `True`，即可将所有幻灯片文本写为向量图形。这消除了对字体的依赖，使视觉效果在不同浏览器之间更一致，但文本将不再可作为 SVG 文本进行选择或搜索。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **选择外部字体的处理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgexternalfontshandling/) 的取值来处理外部加载的字体。请选择 `ADD_LINKS_TO_FONT_FILES` 以引用独立的字体文件，`EMBED` 将字体数据嵌入 SVG，或 `VECTORIZE` 将仅使用外部字体的文本渲染为图形。在嵌入字体之前请确认字体授权。

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

## **减小嵌入图像的大小**

使用 [SVGOptions.pictures_compression](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/pictures_compression/) 可降低嵌入图片的分辨率，使用 [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 可省略已裁剪的源区域，使用 [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 可控制 JPEG 编码质量。这些设置会在降低文件大小的同时牺牲图像保真度或保留的图像数据。

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

## **常见问题**

**何时应使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而不是 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/vectorize_text/)。当仅需将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgexternalfontshandling/)。

**缩小 SVG 的最佳方法是什么？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供这些文件时选择链接的字体文件。需要测试结果，因为降低图片分辨率、降低 JPEG 质量以及向量化文本各自会带来不同的质量和体积权衡。