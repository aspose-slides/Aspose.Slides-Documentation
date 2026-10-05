---
title: 在 Java 中将 PPT 和 PPTX 转换为 PDF [包含高级功能]
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，并提供快速代码示例和高级转换选项。"
---
## **概述**

在 Java 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档、使用各种选项控制图像质量、包含隐藏幻灯片、对 PDF 文件进行密码保护、检测字体替换、选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java 会在输出文档中插入其 API 信息和版本号。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 “*Aspose.Slides*”，在 PDF Producer 字段中填入形如 “*Aspose.Slides v XX.XX*” 的值。**Note** 您无法指示 Aspose.Slides 更改或删除这些信息。  
{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿到 PDF
* 演示文稿的特定幻灯片到 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。在转换过程中，元素和属性会被准确呈现，包括：

* 图像
* 文本框和形状
* 文字格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。

以下示例加载一个演示文稿，并使用默认导出设置将所有可见幻灯片保存为 PDF。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 到 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现本文中描述的步骤。  
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像定义首选的质量设置，指定元文件的处理方式，设置文本的压缩级别，配置图像的 DPI 等。

以下示例将演示文稿导出为 PDF 1.5，JPEG 质量设置为 90，图像分辨率设置为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿的数据并查看幻灯片。调用 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 并传入 `true`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `false`：OLE 对象的预览图像或图标会在 PDF 页面上呈现，但其嵌入的文件不会作为附件包含。将此选项设置为 `true` 则会额外包含文件数据。预览仍然是可视化的表示；附件使接收者能够单独打开或保存嵌入的文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

以下示例加载一个已包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

要检查结果：

1. 使用支持文件附件的查看器（如 Adobe Acrobat Reader）打开导出的 PDF。  
2. 打开查看器的 **Attachments** 面板，定位嵌入的工作簿。  
3. 保存附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开则直接打开。PDF 页面上的预览与附件分离。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件有一定限制：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 特有的限制。本示例使用默认的 PDF 合规设置，并未演示 PDF/A 导出。  
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用来自 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类的 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下示例将演示文稿导出为 PDF，并包含所有隐藏幻灯片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

以下示例将演示文稿导出为 PDF，并将字体替换警告打印到控制台。仅在导出时出现不可用字体被替换时才会打印警告。

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/java/font-substitution/) 文章。  
{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下示例将演示文稿的第 1 张和第 3 张幻灯片导出为 PDF。此数组中的幻灯片编号从 1 开始，且输入的演示文稿必须至少包含三张幻灯片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适应并将该单张幻灯片导出为 PDF。

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 删除新创建的演示文稿中的空白幻灯片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，并将每张幻灯片的演讲者备注放置在幻灯片下方。请使用包含演讲者备注的演示文稿以查看结果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的代码演示了一种 PowerPoint 到 PDF 的转换过程，可根据不同的合规标准生成多个 PDF：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为流行的文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF 转 图像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、[PDF 转 PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 转换。其他面向专用格式的 PDF 转换操作——[PDF 转 SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF 转 XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)——也受支持。  
{{% /alert %}}

> **Note:** 当导出为 PDF/UA 时，Aspose.Slides 将诸如 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会被保留为独立内容，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持批量将多个 PPT 或 PPTX 文件转换为 PDF。您可以遍历文件并以编程方式执行转换过程。

**是否可以对转换后的 PDF 进行密码保护？**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

调用 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 并传入 `true`，使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能在 PDF 中保持高图像质量吗？**

是的，您可以通过在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类中使用诸如 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 和 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法来控制图像质量，从而确保 PDF 中的高质量图像。

**Aspose.Slides 支持 PDF/A 合规标准吗？**

是的，Aspose.Slides 允许您导出符合 [各种标准](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档符合可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for Java 文档](/slides/zh/java/)
- [Aspose.Slides for Java API 参考](https://reference.aspose.com/slides/java/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)