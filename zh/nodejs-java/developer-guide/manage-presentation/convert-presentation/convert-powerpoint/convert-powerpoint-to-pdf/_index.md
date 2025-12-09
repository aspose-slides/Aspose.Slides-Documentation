---
title: 将 PPT 和 PPTX 在 JavaScript 中转换为 PDF（包含高级功能）
linktitle: 将 PPT 和 PPTX 转换为 PDF
type: docs
weight: 40
url: /zh/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- PowerPoint 转 PDF
- 演示文稿转 PDF
- PPT 转 PDF
- 将 PPT 转换为 PDF
- PPTX 转 PDF
- 将 PPTX 转换为 PDF
- ODP 转 PDF
- 将 ODP 转换为 PDF
- 将 PowerPoint 保存为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- JavaScript
- Node.js
- Aspose.Slides for Node.js via Java
description: "了解如何使用 Aspose.Slides 在 JavaScript 中将 PPT、PPTX 和 ODP 演示文稿转换为 PDF。实现高级功能，如密码保护、合规标准和自定义选项，以获取高质量、可访问的 PDF 文档。"
---

## **概述**

在 JavaScript 中将 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档、使用各种选项控制图像质量、包含隐藏幻灯片、对 PDF 文件进行密码保护、检测字体替换、选择特定幻灯片进行转换，以及对输出文档应用合规性标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类，然后使用 `save` 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类公开的 `save` 方法通常用于将演示文稿转换为 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段填入 "*Aspose.Slides*"，在 PDF Producer 字段填入类似 "*Aspose.Slides v XX.XX*" 的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中准确呈现的元素和属性包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在这种情况下，Aspose.Slides 会尝试使用最高质量水平的最佳设置将提供的演示文稿转换为 PDF。

以下代码演示了如何将演示文稿（PPT、PPTX、ODP 等）转换为 PDF：
```js
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // 将演示文稿保存为 PDF。
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose 提供了免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现此处描述的步骤。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以定义光栅图像的首选质量设置、指定元文件的处理方式、设置文本的压缩级别、配置图像的 DPI 等。

下面的代码示例演示了如何使用多个自定义选项将 PowerPoint 演示文稿转换为 PDF：
```js
// 实例化 PdfOptions 类。
let pdfOptions = new aspose.slides.PdfOptions();

// 设置 JPG 图像的质量。
pdfOptions.setJpegQuality(java.newByte(90));

// 设置图像的 DPI。
pdfOptions.setSufficientResolution(300);

// 设置元文件的行为。
pdfOptions.setSaveMetafilesAsPng(true);

// 设置文本内容的压缩级别。
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// 定义 PDF 合规模式。
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 将演示文稿保存为 PDF 文档。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 类的 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) 方法将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下 JavaScript 代码演示了如何在转换为 PDF 时包含隐藏幻灯片：
```js
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 添加隐藏幻灯片。
    pdfOptions.setShowHiddenSlides(true);

    // 将演示文稿保存为 PDF。
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **将 PowerPoint 转换为受密码保护的 PDF**

以下 JavaScript 代码演示了如何使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 类的保护参数将 PowerPoint 演示文稿转换为受密码保护的 PDF：
```js
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类。
    let pdfOptions = new aspose.slides.PdfOptions();

    // 设置 PDF 密码和访问权限。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // 将演示文稿保存为 PDF。
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) 方法，使您能够在演示文稿转 PDF 的过程中检测字体替换。

以下 JavaScript 代码演示了如何检测字体替换：
```js
// 在 PDF 选项中设置警告回调。
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("sample.pptx");

// 将演示文稿保存为 PDF。
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 

有关在渲染过程中接收字体替换回调的更多信息，请参阅 [获取字体替换警告回调](/slides/zh/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/nodejs-java/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下 JavaScript 代码演示了如何仅将 PowerPoint 演示文稿的特定幻灯片转换为 PDF：
```js
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // 设置幻灯片编号数组。
    let slides = java.newArray("int", [1, 3]);

    // 将演示文稿保存为 PDF。
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下 JavaScript 代码演示了如何使用指定的幻灯片尺寸将 PowerPoint 演示文稿转换为 PDF：
```js
const slideWidth = 612;
const slideHeight = 792;

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// 创建一个具有调整后幻灯片尺寸的新演示文稿。
let resizedPresentation = new aspose.slides.Presentation();

try {
    // 设置自定义幻灯片尺寸。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // 从原始演示文稿克隆第一张幻灯片。
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 将调整大小的演示文稿保存为带有备注的 PDF。
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下 JavaScript 代码演示了如何将包含备注的 PowerPoint 演示文稿转换为 PDF：
```js
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // 配置带有备注布局的 PDF 选项。
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 将演示文稿保存为带有备注的 PDF。
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 JavaScript 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 到 PDF 转换过程：
```js
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为流行的文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/)、[PDF 转 JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/)、以及 [PDF 转 PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) 转换。其他针对特定格式的 PDF 转换操作——如 [PDF 转 SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)——也受到支持。

{{% /alert %}}

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以对转换后的 PDF 进行密码保护？**

完全可以。使用 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 类中使用 `setShowHiddenSlides` 方法即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以。您可以使用诸如 `setJpegQuality` 和 `setSufficientResolution` 等方法在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) 中控制图像质量，以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

是的，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for Node.js via Java 文档](/slides/zh/nodejs-java/)
- [Aspose.Slides for Node.js via Java API 参考]((https://reference.aspose.com/slides/nodejs-java/))
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)