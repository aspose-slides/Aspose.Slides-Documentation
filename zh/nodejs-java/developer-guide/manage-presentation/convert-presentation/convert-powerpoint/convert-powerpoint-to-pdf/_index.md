---
title: 在 JavaScript 中将 PPT 和 PPTX 转换为 PDF（包含高级功能）
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/nodejs-java/convert-powerpoint-to-pdf/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---
## **概述**

在 JavaScript 中将 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备上的兼容性以及保持演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件进行密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用符合性标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类，然后使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java 会在输出文档中插入其 API 信息和版本号。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 将 Application 字段填充为 "*Aspose.Slides*"，将 PDF Producer 字段填充为 "*Aspose.Slides v XX.XX*" 形式。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 导出演示文稿为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换中准确呈现的元素和属性包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 转换过程使用默认选项。在这种情况下，Aspose.Slides 会尝试使用最高质量水平的最佳设置将提供的演示文稿转换为 PDF。

下面的示例加载一个演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose 提供免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用该转换器进行实时实现的测试。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类下的属性——可让您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以为栅格图像定义首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像 DPI 等。

下面的示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **自动选择图像压缩**

当演示文稿包含大量照片或屏幕截图时，减小导出 PDF 的大小可以更方便地通过电子邮件发送或下载。调用 [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) 并传入 `true`，即可在 PDF 导出期间为每张图像自动选择最合适的压缩算法。

下面的示例加载已有演示文稿，启用自动图像压缩选择，并将其保存为 PDF 文档。所有其他 PDF 导出设置保持默认值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

此选项为每张图像选择压缩算法。将传递给 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) 的值降低会降低 JPEG 图像质量，而将传递给 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 的值降低则允许图像降采样至更低分辨率，从而可能降低细节。启用自动压缩选择本身并不降低上述任一设置。

选择图像压缩算法会增加额外的处理时间和内存。大小的减小取决于演示文稿的图像和导出设置；并非每个演示文稿都能保证固定的减小比例。

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中嵌入了 Excel 工作簿，您可能希望 PDF 接收者既能访问工作簿的数据，又能查看幻灯片。调用 [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 并传入 `true`，即可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `false`：OLE 对象的预览图像或图标会渲染在 PDF 页面上，但其嵌入文件不会作为附件包含。将该选项设为 `true` 还会额外包含文件数据。预览仍然是视觉表示；附件则允许接收者单独打开或保存嵌入的文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

下面的示例加载一个已经包含嵌入式 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

检查结果的方法：

1. 在支持文件附件的阅读器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开阅读器的 **Attachments** 面板，定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或在阅读器允许的情况下直接打开。PDF 页面上的预览与附件是分开的。

{{% alert color="info" title="Note" %}}

PDF/A 标准对附件有限制：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 的特定限制。本示例使用默认的 PDF 合规性设置，并未展示 PDF/A 导出。

{{% /alert %}}

### **将 PowerPoint 转换为包含隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用来自 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类的 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的示例导出演示文稿为 PDF，并包含所有隐藏幻灯片。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **将 PowerPoint 转换为受密码保护的 PDF**

下面的示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 方法，使您能够在演示文稿转 PDF 的过程中检测字体替换。

下面的示例将演示文稿导出为 PDF，并将字体替换警告打印到控制台。只有在导出期间发生不可用字体替换时才会打印警告。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

有关字体替换的更多信息，请参阅 [Font Substitution](/slides/zh/nodejs-java/font-substitution/) 文章。

{{% /alert %}} 

### **处理没有专用粗体字形的字体**

即使字体没有专用的粗体字形，演示文稿仍可对文本应用粗体格式。文本可以通过合成粗体（人为加粗常规字形）显示为粗体。当该文本在 PDF 中看起来过于粗重或与预期外观不符时，尝试调用 [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 并传入 `true`。此选项在 PDF 导出期间将受影响的文本渲染为位图，可改善某些字体的显示效果。默认值为 `false`。

示例演示文稿包含两个文本框：一个使用常规文本，另一个对同一没有专用粗体字形的字体应用了粗体。下面的示例加载该演示文稿，启用不支持粗体字形的字体样式光栅化，并将其导出为 PDF：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

以下预览显示了禁用和启用选项后的输出。在本例中，禁用选项时粗体文本的笔画更重；启用选项后，粗体文本的笔画更轻；常规文本保持不变。在为您的演示文稿选择设置之前，请比较这些结果。

| 禁用选项 (`false`，默认) | 启用选项 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在本示例中，启用该选项仅将粗体文本转换为位图：它无法被选中、复制或在没有 OCR 的情况下搜索，并且在 800% 缩放时边缘更柔和。常规文本仍保持可搜索。禁用选项时，两段文字均保持为文本。

此选项会对字体没有专用粗体字形的粗体文本进行光栅化。[Font substitution](/slides/zh/nodejs-java/font-substitution/) 则在原始字体不可用时选择其他字体。

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

下面的示例将演示文稿的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号为基于 1 的索引，输入演示文稿必须至少包含三张幻灯片。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

下面的示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片大小设置为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适应尺寸，并将单张幻灯片导出为 PDF。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 删除新创建的演示文稿中为空的幻灯片。
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

下面的示例将演示文稿导出为 PDF，在每张幻灯片下方放置对应的演讲者备注。请使用包含演讲者备注的演示文稿以查看结果。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 过程：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为常见文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF 转 JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、和 [PDF 转 PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 转换。其他针对特定格式的 PDF 转换操作——[PDF 转 SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)——也受到支持。

{{% /alert %}}

> **注意：** 导出为 PDF/UA 时，Aspose.Slides 会将 SmartArt、图表和公式等复杂图形视为单个图形。单个路径元素不会作为独立内容保留下来，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题解答**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

可以，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**可以对转换后的 PDF 设置密码保护吗？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏的幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类中调用 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) 并传入 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能够在 PDF 中保持高图像质量吗？**

可以，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) 和 [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) 等方法在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类中控制图像质量，以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持，Aspose.Slides 允许您导出符合 [各种标准](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for Node.js via Java 文档](/slides/zh/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 参考](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)