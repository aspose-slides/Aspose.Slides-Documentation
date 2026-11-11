---
title: 在 Python 中更改备注页尺寸和方向
linktitle: 备注页尺寸
type: docs
weight: 10
url: /zh/python-net/notes-size/
keywords:
- 备注页尺寸
- 备注方向
- 横向备注
- 纵向备注
- 讲义尺寸
- PowerPoint
- 演示文稿
- PPT
- PPTX
- Python
- Aspose.Slides
description: "通过 .NET 在 Aspose.Slides for Python 中读取并更改备注页尺寸，切换方向，验证已保存的尺寸，并将备注或讲义导出为 PDF 和图像。"
---
## **概述**

使用 [Presentation.notes_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/notes_size/) 来访问演示文稿的备注页设置。它返回一个 [NotesSize](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notessize/) 对象，其 [size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notessize/size/) 属性是可写的。虽然设置对象本身是只读的，但您可以为其 size 属性分配新尺寸。

宽度和高度以 **点** 为单位指定，1 英寸等于 72 点。例如，900 × 600 点相当于 12.5 × 8⅓ 英寸。这些设置适用于整个演示文稿，而非单个幻灯片的备注。

| 设置 | 目的 |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/notes_size/) | 控制备注页尺寸以及用于讲义导出的页面尺寸。 |
| [Presentation.slide_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/slide_size/) | 通过 [SlideSize](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesize/) 控制普通演示文稿幻灯片的尺寸。 |

更改任一设置不会自动更改另一个。更改备注页方向也不会旋转普通幻灯片。参见 [Slide Size](/slides/zh/python-net/slide-size/) 以调整普通幻灯片的大小。

下面的示例使用已有的 `sample.pptx`。对于导出示例，请使用至少包含一张带有讲稿备注的幻灯片的演示文稿。每个示例都可以独立运行。

## **读取备注页尺寸和方向**

读取宽度和高度并比较它们以确定方向：宽的页面为横向，高的页面为纵向，尺寸相等则为方形页面。此示例以点为单位打印实际尺寸，未假设任何标准纸张尺寸。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **在不更改纸张尺寸的情况下切换为横向**

若仅更改方向，只需交换现有的宽度和高度。这样可以保留两边的长度，包括自定义纸张尺寸的长度。下面的条件可防止已经是横向的页面被切换回纵向，并保持方形页面不变。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

对于纵向方向，当 `size.width > size.height` 时使用相同的赋值。除非您也想更改纸张尺寸，否则不要替换为 A4 或 Letter 尺寸。

## **设置并验证自定义备注页尺寸**

同时赋值两个维度，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 将演示文稿写入文件。此示例设置一个 900 × 600 点的横向页面，保存为 PPTX，并再次打开保存的文件以检查持久化的值。比较允许 0.01 点的浮点容差；这并不能保证每种文件格式的精度。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

预期结果为 `900 x 600 points` 和 `Size preserved: True`。检查新打开的演示文稿可验证已保存的文件，而不仅仅是内存中的设置。

## **导出备注和讲义**

页面尺寸定义了备注或讲义布局的可用区域。它们本身并不会启用这些布局：还需配置导出选项。普通幻灯片的导出仍使用幻灯片尺寸。

### **导出备注为 PDF 和 PNG**

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/) 赋给 [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) 以在 PDF 中包含备注。此示例还使用 [Slide.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/) 和 [RenderingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/renderingoptions/) 将带备注的第一张幻灯片渲染为 PNG。

[BOTTOM_TRUNCATED](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notespositions/) 模式将备注保持在单页上；不适配的备注会被截断。PDF 使用 900 × 600 点的页面。以下使用的 1 × 1 图像比例下，PNG 为 900 × 600 像素。点描述页面几何；像素描述光栅输出，其尺寸还取决于渲染比例。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

对于包含长备注的 PDF 导出，[BOTTOM_FULL](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notespositions/) 根据需要允许额外页面。不要在上述单幻灯片图像调用中使用该模式，因为它不受支持。调整尺寸后，检查输出是否有被裁剪的备注以及现有 notes-master 对象的放置；仅更改页面尺寸不能保证所有内容都能适配。有关备注导出的更多信息，请参见 [Convert PowerPoint to PDF with Notes](/slides/zh/python-net/convert-powerpoint-to-pdf-with-notes/)。

### **导出讲义为 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/handoutlayoutingoptions/) 在单页上放置多张幻灯片缩略图。以下示例设置 900 × 600 点的页面，并使用 [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/handouttype/) 将每页排列至多四张幻灯片。水平预设控制幻灯片顺序；页面方向取决于其宽度和高度。

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

更改页面尺寸会改变讲义网格的可用区域，但不影响源幻灯片的尺寸。对于讲义图像，请使用带有讲义布局的 [Presentation.get_images](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/get_images/)，而不是单个幻灯片的图像方法。在 Aspose.Slides 中，演示文稿级别的讲义渲染使用备注页尺寸，而单个幻灯片的图像调用不会生成讲义页面。有关布局选项，请参见 [Handout Mode](/slides/zh/python-net/convert-powerpoint-in-handout-mode/)。

## **查看器、导出和打印中的页面尺寸**

保持存储的演示文稿尺寸、导出的页面尺寸和打印的纸张尺寸之间的区别：

- **Presentation viewers:** 查看器可以使用其自身的布局规则显示或打印备注。如果其他应用程序保存文件，请重新打开并再次检查尺寸；该应用的格式转换可能会将其标准化。
- **Export formats:** 上述备注和讲义 PDF 示例使用配置的页面尺寸。光栅图像使用整数像素尺寸和渲染比例，因此在图像输出中可能会对小数点的点值进行四舍五入。导出普通幻灯片时不使用备注页尺寸。
- **Printer drivers:** 纸张选择、自动旋转和适合页面设置可在不更改演示文稿或 PDF 中存储的尺寸的情况下改变实际输出。针对特定纸张尺寸，请匹配打印机设置并检查打印预览。

## **FAQ**

**我可以只为单个幻灯片设置备注尺寸吗？**

备注页尺寸是演示文稿级别的设置。单个幻灯片可以有不同的备注内容，但此属性不提供每张幻灯片单独的页面尺寸。

**为什么更改备注方向没有影响我的幻灯片？**

备注页和普通幻灯片的尺寸是独立的。若想调整幻灯片本身，请使用普通幻灯片尺寸设置。

**为什么我保存或打印的结果尺寸不同？**

首先重新打开已保存的演示文稿并比较其备注尺寸。如果这些尺寸已改变，请检查是否在其他应用程序中保存或转换文件时更改了页面设置。如果没有，更检查导出布局、图像比例、查看器设置以及打印机纸张选择。