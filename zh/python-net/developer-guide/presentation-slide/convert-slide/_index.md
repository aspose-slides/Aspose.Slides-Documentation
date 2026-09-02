---
title: 在 Python 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 41
url: /zh/python-net/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 演示文稿的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 等图像格式。"
---
## **简介**

Aspose.Slides for Python via .NET 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请遵循以下步骤：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/) 类配置渲染。
4. 调用 [Slide.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/) 方法。它返回一个 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 对象。
5. 调用 [IImage.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/save/) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/) 对象可以在内存中处理或保存为文件。

以下 Python 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **使用自定义尺寸将幻灯片转换为图像**

使用接受 [Size](https://reference.aspose.com/slides/zh/python-net/aspose.pydrawing/size/) 参数的 [Slide.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 重载，可按精确像素尺寸渲染幻灯片。

以下示例创建一个 1820 × 1040 的 JPEG 图像：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **将带有批注和备注的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或批注。将一个 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/) 对象分配给 [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) 属性，以控制备注和批注的显示位置。

以下示例将截断的备注放在幻灯片下方，将批注放在右侧：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
在幻灯片转图像的过程中，请勿将 [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) 属性设为 [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notespositions/)。备注的文字可能超过固定图像尺寸的容纳量。请改用 [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/tiffoptions/) 类允许控制渲染出的 TIFF 图像的大小、分辨率及其他属性。

以下示例以 300 DPI 渲染第一张幻灯片为 2160 × 2880 的 TIFF 图像：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **将所有幻灯片转换为图像**

遍历幻灯片集合即可将整个演示文稿转换为一系列图像。除非显式跳过，否则隐藏幻灯片也会被包含。

以下示例将每张幻灯片渲染为水平和垂直缩放系数均为 2 的 JPEG 图像：

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **创建增强型元文件（EMF）输出**

增强型元文件（EMF）在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 能保留矢量绘图操作，在放大时不会出现相同的清晰度损失。但 EMF 主要是为具备 Windows 元文件支持的应用提供兼容格式，而非通用的交换格式。此外，复杂的幻灯片内容（如位图图像和某些效果）可能会以栅格化元素存入矢量元文件容器中。

### **将幻灯片导出为 EMF**

[Slide.write_as_emf](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/write_as_emf/) 方法将一个 [Slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/) 以 EMF 格式写入目标流。以下示例加载演示文稿，选取第一张幻灯片，并将其写入 EMF 文件流：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

调用方拥有传递给 [Slide.write_as_emf](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/write_as_emf/) 的流并必须关闭它。Aspose.Slides 在流的当前位置写入数据并保持流打开。

### **将 SVG 图像转换为 EMF 并添加到演示文稿**

使用 [SvgImage.write_as_emf](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/write_as_emf/) 可以将 SVG 内容转换为 EMF。生成的字节可以通过 [ImageCollection.add_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/add_image/) 添加到演示文稿，并使用 [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_picture_frame/) 放置在幻灯片上。

以下示例从 SVG 标记创建一个 [SvgImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/)，将其转换为内存中的 EMF，插入第一张幻灯片，并保存演示文稿：

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/zh/python-net/aspose.slides/svgimage/write_as_emf/) 不会取得目标流的所有权。写入后，流位置位于生成数据的末尾。请调用 `getvalue` 来获取完整缓冲区，避免受当前流位置影响，如上例所示。保持流打开直至读取完数据，随后再关闭。

EMF 生成功能在 Aspose.Slides for Python via .NET 支持的操作系统上可用，但当字体或本地图形依赖不可用时，不同平台的渲染可能会有所差异。请安装源内容使用的字体或配置合适的替代方案，遵循 Aspose.Slides 的 [平台要求](/slides/zh/python-net/system-requirements/)，并在目标 EMF 使用应用中验证结果。Linux 和 macOS 应用通常对 Windows 元文件的显示和编辑支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时若要正确渲染彩色表情符号，必须在执行转换的系统上安装并提供幻灯片使用的表情符号字体。例如，若演示文稿使用 **Segoe UI Emoji** 且该字体缺失，输出图像中的表情符号可能会以单色形式显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带有动画的幻灯片？**

不支持。[Slide.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/) 方法仅渲染幻灯片的静态图像，不会导出动画。

**是否可以将隐藏幻灯片导出为图像？**

可以。隐藏幻灯片可以像普通幻灯片一样渲染。请在处理循环中包含它们，如上例所示。

**幻灯片图像是否会保留阴影和其他效果？**

会。Aspose.Slides 会在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。