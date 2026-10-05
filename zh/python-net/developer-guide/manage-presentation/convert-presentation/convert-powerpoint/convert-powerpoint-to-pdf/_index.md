---
title: 在 Python 中将 PPT 与 PPTX 转换为 PDF | 高级选项
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
description: "使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 转换为高质量、符合 WCAG 标准的 PDF 的逐步指南——包括密码保护、幻灯片选择和图像质量控制。"
showReadingTime: true
---
## **概述**

在 Python 中将 PowerPoint 演示文稿（PPT、PPTX、ODP）转换为 PDF 格式具有多种优势，包括确保在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文档进行密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中将演示文稿转换为 PDF，只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python 会在输出文档中插入其 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会在 Application 字段中填入 '*Aspose.Slides*' 值，在 PDF Producer 字段中填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for Python 更改或移除这些信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿转换为 PDF
* 演示文稿中的特定幻灯片转换为 PDF

Aspose.Slides 导出演示文稿为 PDF，确保生成的 PDF 内容与原始演示文稿高度一致。转换过程中准确渲染以下元素和属性，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。

以下示例加载一个演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint to PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。要实际运行本文所述的过程，您可以使用该转换器进行测试。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义转换过程产生的 PDF、使用密码锁定 PDF，甚至指定转换过程的行为方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以设置光栅图像的首选质量、指定元文件的处理方式、设置文本的压缩级别、设置图像的 DPI 等。

以下示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

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

如果演示文稿中包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿的数据并查看幻灯片。将 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 设置为 `True`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `False`：OLE 对象的预览图像或图标会在 PDF 页面上渲染，但其嵌入文件不会作为附件包含。将此选项设为 `True` 会额外包含文件数据。预览仍然是视觉表示；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

以下示例加载一个已经包含嵌入 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

要检查结果：

1. 在支持文件附件的查看器（例如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板并定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开，则直接打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件有约束：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 特有的限制。本示例使用默认的 PDF 合规性设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿中包含隐藏幻灯片，您可以使用自定义选项——来自 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类的 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 属性——指示 Aspose.Slides 在生成的 PDF 中将隐藏幻灯片作为页面包含。

以下示例将演示文稿导出为 PDF，并包括所有隐藏幻灯片。

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

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下示例将演示文稿的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用一基索引，且输入的演示文稿必须至少包含三张幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适应并将单张幻灯片导出为 PDF。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 删除新创建的演示文稿中自动生成的空白幻灯片。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，且每张幻灯片的演讲者备注会放置在幻灯片下方。请使用包含演讲者备注的演示文稿以查看效果。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任何合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

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
Aspose.Slides 对 PDF 转换操作的支持使您能够将 PDF 转换为最流行的文件格式。您可以进行 [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) 和 [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 转换。其他面向专用格式的 PDF 转换操作——[PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) 和 [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——也受到支持。
{{% /alert %}}

> **注意：** 在导出为 PDF/UA 时，Aspose.Slides 将复杂图形（如 SmartArt、图表和公式）视为单个图形。单个路径元素不会保留为独立内容，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**Aspose.Slides for Python 能否从 PDF 中移除应用程序信息？**

不可以，Aspose.Slides for Python 会自动在输出的 PDF 中包含 API 信息和版本号。这些信息无法修改或移除。

**如何仅在 PDF 转换中包含特定幻灯片？**

您可以通过将幻灯片位置数组传递给 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法来指定要转换的幻灯片索引。

**在转换期间是否可以对 PDF 进行密码保护？**

可以，在将演示文稿保存为 PDF 之前，使用 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类设置密码并定义访问权限。

**Aspose.Slides 支持将 PDF 转换为其他格式吗？**

支持，Aspose.Slides 能将 PDF 转换为 HTML、图像格式（JPG、PNG）、SVG、TIFF 和 XML 等格式。

**如何确保我的 PDF 符合可访问性标准？**

在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中设置 [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) 属性为 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA` 等标准，以确保符合可访问性指南。

**我可以在 PDF 输出中包含隐藏幻灯片吗？**

可以，将 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 属性在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中设为 `True`，隐藏幻灯片将被包含在 PDF 中。

**在转换过程中如何调整图像质量和分辨率？**

使用 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 和 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 属性在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中控制生成的 PDF 中的图像质量和分辨率。

**Aspose.Slides 会自动处理字体替换吗？**

Aspose.Slides 在转换期间会检测字体替换，您可以使用 `SaveOptions` 中的 `warning_callback` 属性来处理（目前功能有限）。

## **附加资源**

- [Aspose.Slides for Python via .NET 文档](/slides/zh/python-net/)
- [Aspose.Slides API 参考](https://reference.aspose.com/slides/python-net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)