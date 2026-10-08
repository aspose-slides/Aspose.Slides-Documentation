---
title: 在 Java 中将 PPT 和 PPTX 转换为 PDF（包含高级功能）
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/java/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- PowerPoint 转 PDF
- 演示文稿转 PDF
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
description: "在 Java 中使用 Aspose.Slides 将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---
## **概述**

在 Java 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多项优势，包括在不同设备上的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件进行密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法将演示文稿另存为 PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类公开的 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法通常用于将演示文稿转换为 PDF。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java 会在输出文档中插入其 API 信息和版本号。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 “*Aspose.Slides*”，在 PDF Producer 字段中填入类似 “*Aspose.Slides v XX.XX*” 的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿转换为 PDF
* 从演示文稿中选择特定幻灯片转换为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度吻合。转换过程中准确渲染以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量水平将提供的演示文稿转换为 PDF。

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

Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 来演示演示文稿到 PDF 的转换过程。您可以使用该转换器进行测试，以实时实现本指南中描述的过程。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、为 PDF 设置密码，或指定转换过程的行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像定义首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

以下示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

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

如果演示文稿中包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿数据并查看幻灯片。调用 [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) 并传入 `true`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `false`：OLE 对象的预览图像或图标会渲染在 PDF 页面上，但其嵌入文件不会作为附件包含。将此选项设为 `true` 会额外包含文件数据。预览仍然是视觉表现；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成可交互的 Excel 工作表。

以下示例加载一个已经包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

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

检查结果的步骤：

1. 在支持文件附件的查看器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板，定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查数据，或直接在查看器允许的情况下打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}

PDF/A 标准对附件有约束：PDF/A‑1 禁止嵌入文件，PDF/A‑2 只允许 PDF/A 附件，PDF/A‑3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准本身的要求，而非 Aspose.Slides 的限制。此示例使用默认的 PDF 合规性设置，并未演示 PDF/A 导出。

{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类中的 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下示例将演示文稿导出为 PDF，包含所有隐藏幻灯片。

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

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，帮助您在演示文稿转 PDF 的过程中检测字体替换。

以下示例将演示文稿导出为 PDF，并在控制台打印字体替换警告。仅当导出过程中使用了不可用字体的替代品时才会打印警告。

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

### **处理没有专用粗体字形的字体**

即使某字体没有专用的粗体字形，演示文稿仍可能对文本应用粗体格式。此时文本会通过合成加粗（人工加粗字形）来显示为粗体。如果合成加粗后在 PDF 中看起来过于粗重或与预期不符，可尝试调用 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) 并传入 `true`。此选项会在 PDF 导出时将受影响的文本渲染为位图，从而在某些字体下改善显示效果。默认值为 `false`。

示例演示文稿包含两个文本框：一个普通文本框，另一个对同一字体（没有专用粗体字形）应用了粗体格式。以下示例加载该演示文稿，启用不支持的字体样式光栅化，并将其导出为 PDF：

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

以下预览展示了关闭和开启该选项的输出差异。在本例中，关闭选项时粗体文本的笔画更粗；开启选项后笔画更细；普通文本保持不变。请比较结果后决定在您的演示文稿中使用哪种设置。

| 选项已禁用 (`false`，默认) | 选项已启用 (`true`) |
|---|---|
| ![禁用不支持的粗体字体光栅化的 PDF](unsupported-bold-disabled.png) | ![启用不支持的粗体字体光栅化的 PDF](unsupported-bold-enabled.png) |

在此示例中，启用该选项仅将粗体文本转换为位图：它无法被选中、复制或在未 OCR 的情况下搜索，且在 800% 放大时边缘更柔和。普通文本仍保持可搜索。关闭选项时，两段文字均保持为文本。

此选项会对字体没有专用粗体字形的加粗文本进行光栅化。相比之下，[字体替换](/slides/zh/java/font-substitution/) 会在原始字体不可用时选用其他字体。

## **从 PowerPoint 中选择幻灯片转换为 PDF**

以下示例将演示文稿中的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用从 1 开始的索引，且输入演示文稿必须至少包含三张幻灯片。

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

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸设为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适配尺寸，并将单张幻灯片导出为 PDF。

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

    // 删除新创建的演示文稿中默认的空幻灯片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，在每张幻灯片下方放置对应的演讲者备注。请使用包含演讲者备注的演示文稿以查看效果。

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

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 到 PDF 转换过程：

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

Aspose.Slides 支持 PDF 转换操作，您可以将 PDF 文件转换为流行的文件格式。支持的转换包括 [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/)。此外，还支持将 PDF 转换为专用格式，如 [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)。

{{% /alert %}}

> **注意：** 在导出为 PDF/UA 时，Aspose.Slides 会将 SmartArt、图表、公式等复杂图形视为单个图形。单独的路径元素不会保留为独立内容，可能被标记为伪影；仅为整体图形提供替代文本。

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持对多个 PPT 或 PPTX 文件进行批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以对转换后的 PDF 加密（密码保护）？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏的幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类中调用 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 并传入 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) 和 [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 中控制图像质量，以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合 [各种标准](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，从而满足可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for Java 文档](/slides/zh/java/)
- [Aspose.Slides for Java API 参考文档](https://reference.aspose.com/slides/java/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)