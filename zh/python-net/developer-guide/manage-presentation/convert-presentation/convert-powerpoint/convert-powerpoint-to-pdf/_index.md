---
title: 将 PPT 与 PPTX 转换为 Python 中的 PDF | 高级选项
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将 PowerPoint 保存为 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 转换为高质量、符合 WCAG 标准的 PDF 的一步步指南——包括密码保护、幻灯片选择和图像质量控制。"
showReadingTime: true
---
## **概述**

在 Python 中将 PowerPoint 演示文稿（PPT、PPTX、ODP）转换为 PDF 格式具有多项优势，包括确保在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示如何将演示文稿转换为 PDF 文档，利用各种选项控制图像质量、包含隐藏幻灯片、对 PDF 文档进行密码保护、检测字体替换、选择特定幻灯片进行转换，以及对输出文档应用合规性标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中将演示文稿转换为 PDF，只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python 将其 API 信息和版本号插入输出文档。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会在 Application 字段中填入 '*Aspose.Slides*' 值，并在 PDF Producer 字段中填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for Python 更改或删除输出文档中的此信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 完整的演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 内容与原始演示文稿高度吻合。转换期间会准确渲染以下元素和属性，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint‑to‑PDF 转换过程使用默认选项。在这种情况下，Aspose.Slides 会尝试使用最佳设置和最高质量水平将提供的演示文稿转换为 PDF。

以下示例加载一个演示文稿，并使用默认导出设置将所有可见幻灯片保存为 PDF。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ，演示演示文稿到 PDF 的转换过程。若要实时实现此处描述的过程，您可以使用该转换器进行测试。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义 PDF（转换过程的产物），使用密码锁定 PDF，或甚至指定转换过程的方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以设置光栅图像的首选质量、指定元文件的处理方式、设置文本压缩级别、设定图像 DPI 等。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿的数据并查看幻灯片。将 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 设置为 `True` 可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `False`：OLE 对象的预览图像或图标会渲染在 PDF 页面上，但其嵌入文件不会作为附件包含。将该选项设为 `True` 会额外包含文件数据。预览仍然是视觉表现；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成可交互的 Excel 工作表。

以下示例加载一个已经包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

检查结果：

1. 在支持文件附件的查看器（如 Adobe Acrobat Reader）中打开导出的 PDF。  
2. 打开查看器的 **附件** 面板并定位嵌入的工作簿。  
3. 保存附件并在 Excel 中打开以检查其数据，或在查看器允许的情况下直接打开。PDF 页面上的预览与附件是分离的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件施加限制：PDF/A-1 禁止嵌入文件，PDF/A-2 只允许 PDF/A 附件，PDF/A-3 允许其他文件类型，包括 Excel 工作簿。这些是标准的要求，而不是 Aspose.Slides 的特定限制。本示例使用默认的 PDF 合规性设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 属性（位于 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类）——指示 Aspose.Slides 将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下示例将演示文稿导出为 PDF，包含所有隐藏幻灯片。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **处理没有专用粗体字体的字体**

即使字体没有专用的粗体字形，演示文稿仍可对文本应用粗体格式。文本可以通过合成粗体（人工加粗常规字形）实现粗体效果。当该文本在 PDF 中显得过重或与预期外观不符时，尝试将 [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) 设置为 `True`。此选项在 PDF 导出期间将受影响的文本渲染为位图，可能改善某些字体的显示效果。默认值为 `False`。

示例演示文稿包含两个文本框：一个包含常规文本，另一个对同一字体（无专用粗体）应用了粗体格式。以下示例加载该演示文稿，启用不支持的字体样式光栅化，并将其导出为 PDF：

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

以下预览显示了禁用和启用两种输出。在本例中，禁用选项时粗体文本的笔画更重；启用选项后笔画更轻，常规文本保持不变。请比较结果后再为您的演示文稿选择设置。

| 选项禁用 (`False`, the default) | 选项启用 (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在本例中，启用该选项仅将粗体文本转为位图：无法选择、复制或在无 OCR 的情况下搜索该文本，且在 800% 缩放时其边缘更柔和。常规文本仍可搜索。禁用选项时，两段文字均保持为文本。

此选项在字体没有专用粗体字形时，对粗体文本进行光栅化。[字体替换](/slides/zh/python-net/font-substitution/) 则在原始字体不可用时选择其他字体。

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下示例将演示文稿的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号使用基于 1 的索引，输入演示文稿必须至少包含三张幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适配尺寸，并将单张幻灯片导出为 PDF。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 删除在创建新演示文稿时产生的空白幻灯片。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，在每张幻灯片下方放置该幻灯片的演讲者备注。使用包含备注的演示文稿以查看效果。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的 Python 代码演示了一个 PowerPoint 到 PDF 的转换操作，其中获取了基于不同合规标准的多个 PDF：

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
Aspose.Slides 支持将 PDF 转换为最流行的文件格式。您可以进行 [PDF 到 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 到图像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 到 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、以及 [PDF 到 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 转换。其他 PDF 转换操作到专用格式——[PDF 到 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 到 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、和 [PDF 到 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——也受支持。
{{% /alert %}}

> **注意:** 导出为 PDF/UA 时，Aspose.Slides 将复杂图形（如 SmartArt、图表和公式）视为单个图形。单独的路径元素不会作为独立内容保留，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**Aspose.Slides for Python 能否从 PDF 中移除应用程序信息？**

不能，Aspose.Slides for Python 会自动在输出 PDF 中包含 API 信息和版本号。此信息无法修改或移除。

**如何仅在 PDF 转换中包含特定幻灯片？**

您可以通过将幻灯片位置数组传递给 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法来指定要转换的幻灯片索引。

**在转换过程中是否可以对 PDF 进行密码保护？**

可以，在将演示文稿保存为 PDF 之前，使用 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类设置密码并定义访问权限。

**Aspose.Slides 是否支持将 PDF 转换为其他格式？**

支持，Aspose.Slides 可以将 PDF 转换为 HTML、图像格式（JPG、PNG）、SVG、TIFF 和 XML 等格式。

**如何确保我的 PDF 符合可访问性标准？**

在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中将 [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) 属性设置为 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA` 等标准，以确保符合可访问性指南。

**可以在 PDF 输出中包含隐藏幻灯片吗？**

可以，将 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 属性在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中设为 `True`，隐藏幻灯片将被包含在 PDF 中。

**如何在转换期间调整图像质量和分辨率？**

使用 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 和 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 属性，在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中控制生成 PDF 的图像质量和分辨率。

**Aspose.Slides 是否会自动处理字体替换？**

Aspose.Slides 在转换期间会检测字体替换，您可以使用 `warning_callback` 属性在 `SaveOptions` 中进行处理（目前受限）。

## **其他资源**

- [Aspose.Slides for Python via .NET 文档](/slides/zh/python-net/)
- [Aspose.Slides API 参考](https://reference.aspose.com/slides/python-net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)