---
title: 在 Python 中将 PowerPoint 转换为 PDF
linktitle: 将 PowerPoint 转换为 PDF
type: docs
weight: 40
url: /python-net/convert-powerpoint-to-pdf/
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
description: "在 Python 中将 PowerPoint 演示文稿转换为 PDF。按照合规性或可访问性标准将 PowerPoint 保存为 PDF。"
---

## **概述**

将 PowerPoint 文档转换为 PDF 格式提供了多个优点，包括确保在不同设备之间的兼容性，并保留演示文稿的布局和格式。本文将向您展示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，给 PDF 文档加密，检测字体替代，选择要转换的幻灯片，并将合规性标准应用于输出文档。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* PPT
* PPTX
* ODP

要在 Python 中将演示文稿转换为 PDF，您只需将文件名作为参数传递给 [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类，然后使用 [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) 方法将演示文稿保存为 PDF。[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类暴露了通常用于将演示文稿转换为 PDF 的 [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) 方法。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Python 直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for Python 会将应用程序字段填充为 '*Aspose.Slides*' 值，并将 PDF 制作者字段填充为 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您无法指示 Aspose.Slides for Python 更改或移除此信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿到 PDF
* 演示文稿中的特定幻灯片到 PDF
* 演示文稿 

Aspose.Slides 以使最终 PDF 内容非常类似于原始演示文稿的方式将演示文稿导出为 PDF。以下已知元素和属性通常会在演示文稿到 PDF 转换时正确呈现：

* 图像
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint PDF 转换操作使用默认选项执行。在这种情况下，Aspose.Slides 尝试以最佳设置和最高质量级别将提供的演示文稿转换为 PDF。以下 Python 代码演示了如何将 PowerPoint 转换为 PDF：

_步骤：在 Python 中将 PowerPoint 转换为 PDF_

以下示例代码通过 .NET 使用 Python 解释这些转换
- <a name="python-net-powerpoint-to-pdf"><strong>步骤：通过 .NET 使用 Python 将 PowerPoint 转换为 PDF</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>步骤：通过 .NET 使用 Python 将 PPT 转换为 PDF</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>步骤：通过 .NET 使用 Python 将 PPTX 转换为 PDF</a></strong>
- <a name="python-net-odp-to-pdf"><strong>步骤：通过 .NET 使用 Python 将 ODP 转换为 PDF</a></strong>
- <a name="python-net-odp-to-pdf"><strong>步骤：通过 .NET 使用 Python 将 PPS 转换为 PDF</a></strong>

_代码步骤：_

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并提供 PowerPoint 文件。
  * _.ppt_ 扩展名用于加载 _Presentation_ 类中的 **PPT** 文件。
  * _.pptx_ 扩展名用于加载 _Presentation_ 类中的 **PPTX** 文件。
  * _.odp_ 扩展名用于加载 _Presentation_ 类中的 **ODP** 文件。
  * _.pps_ 扩展名用于加载 _Presentation_ 类中的 **PPS** 文件。
- 通过调用 **Save** 方法并使用 **SaveFormat.PDF** 枚举将 _Presentation_ 保存为 **PDF** 格式。
  

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("PowerPoint.ppt")

# 将演示文稿保存为 PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose 提供一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。要测试此处描述的过程的实时实现，您可以使用该转换器进行测试。

{{% /alert %}}

## 将 PowerPoint 转换为带选项的 PDF

Aspose.Slides 提供自定义选项——[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义转换过程生成的 PDF，给 PDF 加密，甚至指定转换过程应如何进行。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像设置首选质量设置，指定元文件的处理方式，设置文本的压缩级别，设置图像的 DPI 等。

以下代码示例演示了将 PowerPoint 演示文稿转换为 PDF，同时应用多个自定义选项的操作：

```python
import aspose.slides as slides

# 实例化 PdfOptions 类
pdf_options = slides.export.PdfOptions()

# 设置 JPG 图像的质量
pdf_options.jpeg_quality = 90

# 设置图像的 DPI
pdf_options.sufficient_resolution = 300

# 设置元文件的处理方式
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

### **将 PowerPoint 转换为包含隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用自定义选项——[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类中的 `show_hidden_slides` 属性——指示 Aspose.Slides 将隐藏幻灯片作为页面包含在结果 PDF 中。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为包含隐藏幻灯片的 PDF：

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("PowerPoint.pptx")

# 实例化 PdfOptions 类
pdfOptions = slides.export.PdfOptions()

# 添加隐藏幻灯片
pdfOptions.show_hidden_slides = True

# 将演示文稿保存为 PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **将 PowerPoint 转换为带密码保护的 PDF**

以下 Python 代码演示了如何将 PowerPoint 转换为密码保护的 PDF（使用 [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) 类中的保护参数）：

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 对象
presentation = slides.Presentation("PowerPoint.pptx")

# 实例化 PdfOptions 类
pdfOptions = slides.export.PdfOptions()

# 设置 PDF 密码和访问权限
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# 将演示文稿保存为 PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### 检测字体替代

Aspose.Slides 在 [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) 类下提供了 `warning_callback` 属性，以允许您在演示文稿到 PDF 转换过程中检测字体替代。

以下 Python 代码演示了如何检测字体替代：

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

有关字体替代的更多信息，请参阅 [字体替代](https://docs.aspose.com/slides/python-net/font-substitution/) 文章。

{{% /alert %}} 

## **将选定的幻灯片从 PowerPoint 转换为 PDF**

以下 Python 代码演示了如何将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 对象
presentation = slides.Presentation("PowerPoint.pptx")

# 设置幻灯片位置的数组
slides_array = [ 1, 3 ]

# 将演示文稿保存为 PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **将 PowerPoint 转换为 PDF，并指定自定义幻灯片大小**

以下 Python 代码演示了如何在指定幻灯片大小的情况下将 PowerPoint 转换为 PDF：

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 对象 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# 设置幻灯片类型和大小 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **以注释幻灯片视图转换 PowerPoint 为 PDF**

以下 Python 代码演示了如何将 PowerPoint 转换为 PDF 注释：

```python
import aspose.slides as slides

# 实例化表示 PowerPoint 文件的 Presentation 类
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 将演示文稿保存为 PDF 注释
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换程序。您可以使用以下任何合规性标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 Python 代码演示了一种 PowerPoint 到 PDF 的转换操作，其中基于不同合规性标准获得多个 PDF：

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

Aspose.Slides 对 PDF 转换操作的支持扩展到允许您将 PDF 转换为最流行的文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 转图像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) 和 [PDF 转 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 转换。其他 PDF 转换操作到专业格式——[PDF 转 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) 和 [PDF 转 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——也得到支持。

{{% /alert %}}