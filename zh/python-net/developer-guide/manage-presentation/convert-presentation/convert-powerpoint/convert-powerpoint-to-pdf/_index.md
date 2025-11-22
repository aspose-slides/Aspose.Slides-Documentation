---
title: 将 PPT 与 PPTX 转换为 PDF（Python） | 高级选项
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/python-net/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将 PowerPoint 保存为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "使用 Aspose.Slides 在 Python 中将 PPT、PPTX 和 ODP 转换为高质量、符合 WCAG 标准的 PDF 的分步指南——包括密码保护、幻灯片选择和图像质量控制。"
showReadingTime: true
---

## **概述**

将 PowerPoint 演示文稿（PPT、PPTX、ODP）转换为 Python 中的 PDF 格式可带来多种优势，包括确保在不同设备间的兼容性并保留演示文稿的布局和格式。本指南演示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，为 PDF 文档设置密码，检测字体替代，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中将演示文稿转换为 PDF，只需在 [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类中将文件名作为参数传递，然后使用 [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) 方法将演示文稿另存为 PDF。[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类公开的 [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) 方法通常用于将演示文稿转换为 PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Python 会直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会在 Application 字段填入 '*Aspose.Slides*' 值，在 PDF Producer 字段填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for Python 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 内容与原始演示文稿高度匹配。转换过程中会准确渲染以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

使用默认选项执行标准的 PowerPoint PDF 转换操作。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。以下 Python 代码展示了如何将 PowerPoint 转换为 PDF：

_Steps: PowerPoint to PDF Conversions in Python_

以下示例代码通过 .NET 使用 Python 说明这些转换  
- <a name="python-net-powerpoint-to-pdf"><strong>步骤：使用 Python 通过 .NET 将 PowerPoint 转换为 PDF</strong></a>  
- <a name="python-net-ppt-to-pdf"><strong>步骤：使用 Python 通过 .NET 将 PPT 转换为 PDF</strong></a>  
- <a name="python-net-pptx-to-pdf"><strong>步骤：使用 Python 通过 .NET 将 PPTX 转换为 PDF</strong></a>  
- <a name="python-net-odp-to-pdf"><strong>步骤：使用 Python 通过 .NET 将 ODP 转换为 PDF</strong></a>  
- <a name="python-net-odp-to-pdf"><strong>步骤：使用 Python 通过 .NET 将 PPS 转换为 PDF</strong></a>  

_Code Steps:_

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并提供 PowerPoint 文件。  
  * _.ppt_ 扩展名加载 **PPT** 文件到 _Presentation_ 类。  
  * _.pptx_ 扩展名加载 **PPTX** 文件到 _Presentation_ 类。  
  * _.odp_ 扩展名加载 **ODP** 文件到 _Presentation_ 类。  
  * _.pps_ 扩展名加载 **PPS** 文件到 _Presentation_ 类。  
- 通过调用 **Save** 方法并使用 **SaveFormat.PDF** 枚举，将 _Presentation_ 保存为 **PDF** 格式。

```python
import aspose.slides as slides

# 实例化一个表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("PowerPoint.ppt")

# 将演示文稿保存为 PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```


{{%  alert  color="primary"  %}} 

Aspose 提供免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 演示演示文稿到 PDF 的转换过程。要实际运行本文描述的过程，您可以使用该转换器进行测试。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义 PDF（转换过程产生的文件），为 PDF 设置密码，甚至指定转换过程的方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以设置光栅图像的首选质量设置，指定元文件的处理方式，设置文本的压缩级别，设置图像的 DPI 等。

以下代码示例演示了将 PowerPoint 演示文稿转换为 PDF 并使用多个自定义选项的操作：

```python
import aspose.slides as slides

# 实例化 PdfOptions 类
pdf_options = slides.export.PdfOptions()

# 设置 JPG 图像的质量
pdf_options.jpeg_quality = 90

# 设置图像的 DPI
pdf_options.sufficient_resolution = 300

# 设置元文件的行为
pdf_options.save_metafiles_as_png = True

# 设置文本内容的压缩级别
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# 定义 PDF 合规模式
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# 实例化表示 PowerPoint 文档的 Presentation 类
with slides.Presentation("PowerPoint.pptx") as presentation:
    # 将演示文稿保存为 PDF 文档
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类中的 `show_hidden_slides` 属性——指示 Aspose.Slides 将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下 Python 代码展示了如何在包含隐藏幻灯片的情况下将 PowerPoint 演示文稿转换为 PDF：

```python
import aspose.slides as slides

# 实例化一个表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("PowerPoint.pptx")

# 实例化 PdfOptions 类
pdfOptions = slides.export.PdfOptions()

# 添加隐藏幻灯片
pdfOptions.show_hidden_slides = True

# 将演示文稿保存为 PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **将 PowerPoint 转换为受密码保护的 PDF**

以下 Python 代码展示了如何使用 [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类的保护参数将 PowerPoint 转换为受密码保护的 PDF：

```python
import aspose.slides as slides

# 实例化一个表示 PowerPoint 文件的 Presentation 对象
presentation = slides.Presentation("PowerPoint.pptx")

# 实例化 PdfOptions 类
pdfOptions = slides.export.PdfOptions()

# 设置 PDF 密码和访问权限
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# 将演示文稿保存为 PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```


### **检测字体替代**

Aspose.Slides 在 [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) 类下提供 `warning_callback` 属性，以便您在演示文稿到 PDF 的转换过程中检测字体替代。

以下 Python 代码展示了如何检测字体替代：

```python
[TODO[SLIDESPYNET-91]: 回调目前不受支持]
```


{{%  alert color="primary"  %}} 

有关字体替代的更多信息，请参阅 [字体替代](https://docs.aspose.com/slides/python-net/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下 Python 代码展示了如何将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：

```python
import aspose.slides as slides

# 实例化一个表示 PowerPoint 文件的 Presentation 对象
presentation = slides.Presentation("PowerPoint.pptx")

# 设置幻灯片位置的数组
slides_array = [ 1, 3 ]

# 将演示文稿保存为 PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```


## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下 Python 代码展示了在指定幻灯片大小的情况下将 PowerPoint 转换为 PDF：

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 创建一个调整了幻灯片尺寸的新演示文稿。
    with slides.Presentation() as resized_presentation:

        # 设置自定义幻灯片尺寸。
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 从原始演示文稿克隆第一张幻灯片。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 将调整尺寸的演示文稿保存为带备注的 PDF。
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下 Python 代码展示了如何将 PowerPoint 转换为 PDF 备注：

```python
import aspose.slides as slides

# 实例化一个表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 将演示文稿保存为 PDF 注释
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```


## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 Python 代码演示了一个 PowerPoint 到 PDF 的转换操作，其中生成了基于不同合规标准的多个 PDF：

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


{{% alert title="注意" color="warning" %}} 

Aspose.Slides 对 PDF 转换操作的支持扩展到允许您将 PDF 转换为最流行的文件格式。您可以进行 [PDF 转 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 转图像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、以及 [PDF 转 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 转换。其他针对特化格式的 PDF 转换操作——[PDF 转 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、以及 [PDF 转 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}

## **常见问题**

**Aspose.Slides for Python 能否从 PDF 中移除应用程序信息？**

不能，Aspose.Slides for Python 会自动在输出 PDF 中包含 API 信息和版本号。此信息无法修改或移除。

**如何仅在 PDF 转换中包含特定幻灯片？**

您可以通过将幻灯片索引数组传递给 `save` 方法来指定要转换的幻灯片。

**是否可以在转换期间为 PDF 设置密码保护？**

可以，您可以在将演示文稿保存为 PDF 之前使用 `PdfOptions` 类设置密码并定义访问权限。

**Aspose.Slides 是否支持将 PDF 转换为其他格式？**

支持，Aspose.Slides 能将 PDF 转换为 HTML、图像格式（JPG、PNG）、SVG、TIFF 和 XML 等格式。

**如何确保我的 PDF 符合可访问性标准？**

在 `PdfOptions` 中将 `compliance` 属性设置为 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA`，即可确保符合可访问性指南。

**是否可以在 PDF 输出中包含隐藏幻灯片？**

可以，通过将 `PdfOptions` 中的 `show_hidden_slides` 属性设为 `True`，隐藏幻灯片将被包含在 PDF 中。

**如何在转换期间调整图像质量和分辨率？**

使用 `PdfOptions` 中的 `jpeg_quality` 和 `sufficient_resolution` 属性来控制生成的 PDF 中图像的质量和分辨率。

**Aspose.Slides 会自动处理字体替代吗？**

Aspose.Slides 会在转换过程中检测字体替代，您可以使用 `SaveOptions` 中的 `warning_callback` 属性（目前受限）来处理它们。

## **其他资源**

- [Aspose.Slides for .NET 文档](https://docs.aspose.com/slides/python-net/)
- [Aspose.Slides API 参考](https://reference.aspose.com/slides/python-net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)