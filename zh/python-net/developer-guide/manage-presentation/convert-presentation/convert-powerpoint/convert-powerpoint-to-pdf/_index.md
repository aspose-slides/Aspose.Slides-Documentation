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
description: "使用 Aspose.Slides 的分步指南，在 Python 中将 PPT、PPTX 和 ODP 转换为高质量、符合 WCAG 标准的 PDF——包括密码保护、幻灯片选择和图像质量控制。"
showReadingTime: true
---
## **概述**

将 PowerPoint 演示文稿（PPT、PPTX、ODP）转换为 Python 中的 PDF 格式具有多种优势，包括确保在不同设备上的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，利用各种选项控制图像质量、包含隐藏幻灯片、为 PDF 文档设置密码、检测字体替换、选择特定幻灯片进行转换以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中将演示文稿转换为 PDF，只需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python 会将其 API 信息和版本号插入到输出文档中。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会在 Application 字段中填入 '*Aspose.Slides*' 值，在 PDF Producer 字段中填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for Python 更改或删除这些信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 将整个演示文稿转换为 PDF
* 将演示文稿中的特定幻灯片转换为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 内容与原始演示文稿高度匹配。转换中准确渲染的元素和属性包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在这种情况下，Aspose.Slides 会尝试使用最佳设置和最高质量水平将提供的演示文稿转换为 PDF。

下面的示例加载演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 来演示演示文稿到 PDF 的转换过程。要实际运行本文所述的过程，您可以使用该转换器进行测试。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类下的属性——可让您自定义转换后生成的 PDF，使用密码锁定 PDF，或指定转换过程的其他行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以设置光栅图像的首选质量设置，指定元文件的处理方式，为文本设置压缩级别，为图像设置 DPI 等。

下面的示例将演示文稿导出为 PDF 1.5，JPEG 质量设置为 90，图像分辨率设置为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

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

### **自动选择图像压缩**

当演示文稿包含大量照片或截图时，减小导出 PDF 的大小可以更方便地通过电子邮件发送或下载。将 [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) 设置为 `True`，即可在 PDF 导出期间为每个图像自动选择最合适的压缩算法。

下面的示例加载已有演示文稿，启用自动图像压缩选择，并将其保存为 PDF 文档。所有其他 PDF 导出设置保持默认值。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

此选项为每个图像选择压缩算法。降低 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 会降低 JPEG 图像质量，而降低 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 则允许图像降采样到较低分辨率，从而可能减少细节。启用自动压缩选择本身并不会降低上述任一设置。

选择图像压缩算法需要额外的处理时间和内存。大小的减少取决于演示文稿中的图像和导出设置；并非每个演示文稿都能保证固定的减少幅度。

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中嵌入了 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿数据以及查看幻灯片。将 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 设置为 `True`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `False`：OLE 对象的预览图像或图标会在 PDF 页面上渲染，但其嵌入文件不会作为附件包含。将该选项设为 `True` 会额外包含文件数据。预览仍然是视觉表示；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

下面的示例加载一个已经包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

检查结果的方法：

1. 在支持文件附件的阅读器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开阅读器的 **Attachments** 面板并定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或在阅读器允许的情况下直接打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件施加了限制：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 的特定限制。本示例使用默认的 PDF 合规设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 属性（来自 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 类）——指示 Aspose.Slides 将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的示例将演示文稿导出为 PDF，包含所有隐藏幻灯片。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **将 PowerPoint 转换为受密码保护的 PDF**

下面的示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **处理没有专用粗体字形的字体**

即使字体没有专用的粗体字形，演示文稿仍可对文本应用粗体格式。通过合成加粗（synthetic bolding），文本仍可表现为粗体，即人为加粗常规字形。当该文本在 PDF 中看起来过于沉重或与预期外观不符时，尝试将 [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) 设置为 `True`。此选项在 PDF 导出期间将受影响的文本渲染为位图，可能改善某些字体的显示效果。默认值为 `False`。

示例演示文稿包含两个文本框：一个使用常规文本，另一个对同一字体应用了粗体格式，而该字体没有专用的粗体字形。下面的示例加载该演示文稿，启用不支持的字体样式栅格化，并将其导出为 PDF：

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

以下预览显示了禁用输出和启用输出的对比。在本例中，禁用选项时粗体文本的笔画更重；启用选项后笔画更轻；常规文本保持不变。请在为您的演示文稿选择设置前进行比较。

| 选项禁用 (`False`, 默认) | 选项启用 (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在本例中，启用该选项仅将粗体文本转为位图：它无法被选中、复制或在没有 OCR 的情况下搜索，且在 800% 缩放时边缘显得更柔和。常规文本仍可搜索。禁用选项时，两段文字均保持为文本。

此选项将在字体没有专用粗体字形时对粗体文本进行栅格化。[字体替换](/slides/zh/python-net/font-substitution/) 则在原始字体不可用时选择其他字体。

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

下面的示例将演示文稿中的第 1 和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用从 1 开始的方式，输入的演示文稿必须至少包含三张幻灯片。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

下面的示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸设为 612 × 792 points（8.5 × 11 英寸）。它会缩放幻灯片内容以适应尺寸，并将单张幻灯片导出为 PDF。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 删除新创建的演示文稿中默认的空白幻灯片。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

下面的示例将演示文稿导出为 PDF，在每张幻灯片下方放置对应的演讲者备注。请使用包含演讲者备注的演示文稿以查看结果。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

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
Aspose.Slides 对 PDF 转换操作的支持使您能够将 PDF 转换为最流行的文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 转图像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) 和 [PDF 转 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 转换。其他面向专用格式的 PDF 转换操作——[PDF 转 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、[PDF 转 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——也得到支持。
{{% /alert %}}

> **注意:** 在导出为 PDF/UA 时，Aspose.Slides 会将 SmartArt、图表和公式等复杂图形视为单个图形。单个路径元素不会作为独立内容保留，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**Can Aspose.Slides for Python remove the application information from the PDF?**  
No, Aspose.Slides for Python automatically includes API information and the version number in the output PDF. This information cannot be modified or removed.

**How do I include only specific slides in the PDF conversion?**  
You can specify the slide indices you want to convert by passing an array of slide positions to the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method.

**Is it possible to password-protect the PDF during conversion?**  
Yes, you can set a password and define access permissions using the [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) class before saving the presentation as a PDF.

**Does Aspose.Slides support converting PDF to other formats?**  
Yes, Aspose.Slides supports converting PDFs to formats like HTML, image formats (JPG, PNG), SVG, TIFF, and XML.

**How can I ensure my PDF complies with accessibility standards?**  
Set the [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) property in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to standards like `PDF_A1A`, `PDF_A1B`, or `PDF_UA` to ensure compliance with accessibility guidelines.

**Can I include hidden slides in the PDF output?**  
Yes, by setting the [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) property in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to `True`, hidden slides will be included in the PDF.

**How do I adjust image quality and resolution during conversion?**  
Use the [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) and [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) properties in [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) to control image quality and resolution in the resulting PDF.

**Does Aspose.Slides handle font substitutions automatically?**  
Aspose.Slides detects font substitutions during conversion, and you can handle them using the `warning_callback` property in `SaveOptions` (currently limited).

## **其他资源**

- [Aspose.Slides for Python via .NET Documentation](/slides/zh/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)