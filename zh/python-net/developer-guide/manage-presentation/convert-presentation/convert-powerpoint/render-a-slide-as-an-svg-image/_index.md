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

SVG 是一种基于 XML 的可伸缩图像格式，适用于网页发布、幻灯片查看器、辅助功能工作流以及自动后处理。Aspose.Slides 将每张幻灯片导出为单独的 SVG 文件，并允许您控制文本、字体、图片以及 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在各浏览器之间可预测，或准备好用于交互式使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/)。

## **导出幻灯片为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，选择幻灯片，并将其写入流。以下示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

文件名使用 [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) 而不是循环索引。当幻灯片查看器或网页仅需要某个形状时，您还可以使用 [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) 将文本框包含在渲染区域中，而[SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) 决定是否应用框的旋转。当必须在不使用连字的情况下渲染文本时，将[SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) 设置为 `True`。

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

## **控制箭头端点的线端裁剪**

SVG 1.1 没有标记内缩设置来指定线条在箭头下方的停止位置。默认情况下，Aspose.Slides 会缩短导出的线条，使其描边不会穿透标记。将[SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) 设置为 `True` 可将描边绘制到线条的原始端点。这一设置仅影响 SVG 输出，线条在幻灯片上的位置和长度保持不变。

示例在宽度为 2 磅和 10 磅的线条上绘制三角形和菱形箭头。它导出同一张幻灯片两次，仅更改裁剪选项。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

比较显示了 10 磅线条上的三角形箭头。启用裁剪时，尖端锋利；禁用裁剪时，描边穿透标记的斜侧，形成平坦的末端。

![裁剪启用时 10 磅三角形箭头尖锐，裁剪禁用时呈平坦末端的放大图](line-end-cropping.png)

在示例的其他线条中，2 磅三角形的突出描边不太明显。填充的菱形在两种宽度下都覆盖了描边的末端。

## **控制文本和字体**

在将幻灯片导出为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体的包含或引用方式。以下选项帮助您在视觉一致性、文本可选取性和字体依赖性之间取得平衡。

### **矢量化所有文本**

将[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 设置为 `True`，即可将所有幻灯片文本写入为矢量图形。这消除了字体依赖，使视觉效果在各浏览器之间更一致，但文本不再可作为 SVG 文本进行选择或搜索。

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **选择外部字体的处理方式**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) 使用一个 [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) 值来处理外部加载的字体。选择 `ADD_LINKS_TO_FONT_FILES` 以引用单独的字体文件，`EMBED` 将字体数据嵌入 SVG，`VECTORIZE` 则仅将使用外部字体的文本渲染为图形。在嵌入字体之前请确认字体的授权许可。

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

使用[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 降低嵌入图片的分辨率，使用[SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) 删除裁剪后的源区域，并使用[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 编码质量。这些设置会以牺牲图像保真度或保留图像数据为代价来减小文件大小。

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

## **控制图元文件栅格化分辨率**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) 为 SVG 导出期间对图元文件进行栅格化设定了下限分辨率。可在对 EMF 或 WMF 图像进行栅格化时平衡细节与文件大小。它并未为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都转为栅格图像。

下载 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有紧密对角线的 EMF 图像。以下示例通过 [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) 将其第一张幻灯片以三种栅格化分辨率导出。所有其他导出设置保持相同，以便进行对比。

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

在输出中，EMF 成为每个 SVG 中的一个嵌入 PNG。以下测量数据仅针对所提供的演示文稿；它们并不是将 DPI 转换为像素尺寸的通用公式。

| 图元文件栅格化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小（字节） |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比较展示了相同区域的嵌入栅格在相同放大显示尺寸下的效果。对角线在 72 DPI 时出现明显像素化，较高分辨率下边缘更平滑，同时 SVG 文件体积增大。提高该值并不一定能改进所有细节或改变每个导出的图像。

![在 72、150 和 300 DPI 下放大的对角线细节](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) 控制图像分辨率的降低，可能掩盖更改图元文件栅格化分辨率的效果。[SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) 控制 JPEG 编码质量，而非图元文件栅格化分辨率。

## **常见问题**

**何时应使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) 而不是 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/)。当仅需将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)。

**如何让 SVG 更小？**

首先压缩嵌入的图片、删除裁剪后的图像区域，并在目标环境能够提供这些文件时选择链接的字体文件。对结果进行测试，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各自都有不同的质量和大小权衡。