---
title: 在 Python via Java 中将 PPT 和 PPTX 转换为 PDF [包含高级功能]
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/python-java/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- PowerPoint 转 PDF
- 演示文稿 转 PDF
- PPT 转 PDF
- 转换 PPT 为 PDF
- PPTX 转 PDF
- 转换 PPTX 为 PDF
- 将 PowerPoint 保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---
## **概述**

通过 Java 的 Python 将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括跨设备兼容性以及保持演示文稿的布局和格式。本指南演示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件进行密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 会将其 API 信息和版本号插入到输出文档中。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段填入 “*Aspose.Slides*”，在 PDF Producer 字段填入形式为 “*Aspose.Slides v XX.XX*” 的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。
{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中会准确呈现元素和属性，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准转换使用默认的 PDF 导出设置。当需要控制图像质量、页面内容或 PDF 合规性时，请使用自定义选项。

在运行示例之前，请安装 [Aspose.Slides for Python via Java](/slides/zh/python-java/installation/) 并配置兼容的 Java 运行时。每个示例都会从当前工作目录读取 `presentation.pptx`；请将其替换为您的 PPT、PPTX 或 ODP 文件。每个 Python 进程仅需要启动一次 JVM。

以下代码将演示文稿转换为 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 到 PDF 转换器**](https://products.aspose.app/slides/zh/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现本文所述的步骤。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类下的属性——允许您自定义生成的 PDF，使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以定义栅格图像的首选质量设置，指定如何处理矢量图形文件，设置文本的压缩级别，配置图像的 DPI 等。

下面的代码示例演示如何使用多种自定义选项将 PowerPoint 演示文稿转换为 PDF。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类中的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下代码展示了如何在转换为 PDF 时包含隐藏幻灯片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下代码演示如何使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类的保护参数，将 PowerPoint 演示文稿转换为受密码保护的 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setWarningCallback) 方法，使您能够在演示文稿转换为 PDF 的过程中检测字体替换。

使用 JPype 代理接收来自 Java API 的警告回调。在检查前缀之前，将 Java 描述字符串转换为 Python 字符串：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
有关在渲染过程中接收字体替换回调的更多信息，请参阅 [获取字体替换警告回调](/slides/zh/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。
有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/python-java/font-substitution/) 文章。
{{% /alert %}}

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 的幻灯片编号从 1 开始计数。此示例在幻灯片 1 和 3 存在时导出它们：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

此示例将第一张幻灯片导出到尺寸为 612 x 792 点（美国信纸）的页面上。它将幻灯片克隆到具有指定尺寸的新演示文稿中：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下代码演示如何将 PowerPoint 演示文稿转换为包含备注的 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF 的可访问性和合规标准**

在准备可访问的 PDF 时，请参阅 [网页内容可访问性指南（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)。使用 [PdfOptions.setCompliance](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setCompliance) 选择输出标准：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下代码演示了根据不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 转换过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **注意：** 导出为 PDF/UA 时，Aspose.Slides 将复杂图形（如 SmartArt、图表和公式）视为单个图形。单独的路径元素不会作为独立内容保存，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**是否可以批量将多个 PowerPoint 文件转换为 PDF？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以对转换后的 PDF 进行密码保护？**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类中的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能够在 PDF 中保持高图像质量吗？**

是的，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/) 类中的 [setJpegQuality](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setJpegQuality) 和 [setSufficientResolution](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSufficientResolution) 方法控制图像质量，确保 PDF 中的图像高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合 [各种标准](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，满足可访问性或存档需求。请选择相应的标准并根据您的要求检查输出。

## **其他资源**

- [Aspose.Slides for Python via Java 文档](/slides/zh/python-java/)
- [Aspose.Slides for Python via Java API 参考](https://reference.aspose.com/slides/zh/python-java/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/zh/conversion)