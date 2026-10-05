---
title: 在 Python via Java 中将 PPT 和 PPTX 转换为 PDF（包括高级功能）
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
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---
## **概述**

在 Python via Java 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括跨设备兼容性以及保留演示文稿的布局和格式。本指南演示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，为 PDF 文件设置密码，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，需将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 方法将演示文稿保存为 PDF。 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入“*Aspose.Slides*”，在 PDF Producer 字段中填入形如“*Aspose.Slides v XX.XX*”的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。
{{% /alert %}}

Aspose.Slides 允许您进行以下转换：

* 将整个演示文稿转换为 PDF
* 将演示文稿的特定幻灯片转换为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中准确渲染元素和属性，包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准转换使用默认的 PDF 导出设置。当您需要控制图像质量、页面内容或 PDF 合规性时，请使用自定义选项。

在运行示例之前，请安装 [Aspose.Slides for Python via Java](/slides/zh/python-java/installation/) 和兼容的 Java 运行时。每个示例都会从当前工作目录读取 `presentation.pptx`；请用您的 PPT、PPTX 或 ODP 文件替换它。每个 Python 进程只需启动一次 JVM。

下面的示例加载一个演示文稿，并使用默认导出设置将所有可见幻灯片保存为 PDF。

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
Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现此处描述的步骤。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类下的属性——允许您自定义生成的 PDF，使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以定义光栅图像的首选质量设置，指定元文件的处理方式，设置文本的压缩级别，配置图像的 DPI，等等。

下面的示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿数据并查看幻灯片。使用 `True` 调用 [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) 可将嵌入的 OLE 文件保留为生成的 PDF 中的附件。

默认值为 `False`：OLE 对象的预览图像或图标会在 PDF 页面上呈现，但其嵌入的文件不会作为附件包含。将该选项设为 `True` 则额外包括文件数据。预览仍然是视觉表示；附件允许接收者单独打开或保存嵌入的文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

下面的示例加载一个已包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

要检查结果：

1. 在支持文件附件的查看器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板并定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件施加限制：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 的特定限制。此示例使用默认的 PDF 合规性设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类中的 [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的示例将演示文稿导出为 PDF，并包含所有隐藏幻灯片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **将 PowerPoint 转换为受密码保护的 PDF**

下面的示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) 方法，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

下面的示例将演示文稿导出为 PDF，并将字体替换警告打印到控制台。仅当导出期间替换了不可用字体时才会打印警告。使用 JPype 代理从 Java API 接收警告回调。在检查前缀之前，将 Java 描述字符串转换为 Python 字符串：

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/python-java/font-substitution/) 文章。
{{% /alert %}}

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

传递给 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 的幻灯片编号是从 1 开始的。此示例在幻灯片 1 和 3 均存在时导出它们：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

此示例将第一页幻灯片导出到尺寸为 612×792 点（美国信纸）的页面上。它将该幻灯片克隆到具有指定尺寸的新演示文稿中，并缩放幻灯片内容以适应页面。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # 删除新演示文稿创建时的空白幻灯片。
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **在备注幻灯片视图下将 PowerPoint 转换为 PDF**

下面的示例将演示文稿导出为 PDF，并将每张幻灯片的演讲者备注放置在幻灯片下方。请使用包含演讲者备注的演示文稿以查看效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF 的可访问性和合规性标准**

在准备可访问的 PDF 时，请参考 [Web 内容可访问性指南（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)。使用 [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) 选择输出标准：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下代码演示了一个 PowerPoint 转 PDF 的转换过程，根据不同的合规性标准生成多个 PDF：

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

> **注意：** 导出为 PDF/UA 时，Aspose.Slides 将诸如 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会作为独立内容保留，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**可以为转换后的 PDF 设置密码保护吗？**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类中调用 [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 并将其设为 `True`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能在 PDF 中保持高图像质量吗？**

是的，您可以通过在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 类中使用 [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) 和 [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) 等方法来控制图像质量，确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合 [各种标准](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，用于可访问性或存档。请选择合适的标准并根据您的要求检查输出。

## **其他资源**

- [Aspose.Slides for Python via Java 文档](/slides/zh/python-java/)
- [Aspose.Slides for Python via Java API 参考](https://reference.aspose.com/slides/python-java/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)