---
title: 在 Java 中将 PPT 和 PPTX 转换为 PDF [包括高级功能]
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
- 将 PPT 转换为 PDF
- PPTX 转 PDF
- 将 PPTX 转换为 PDF
- 将 PowerPoint 保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速代码示例和高级转换选项。"
---

## **概述**

在 Java 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多项优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件设置密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类，然后使用 `save` 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 `save` 方法。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java 会在输出文档中插入其 API 信息和版本号。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 "*Aspose.Slides*"，在 PDF Producer 字段中填入 "*Aspose.Slides v XX.XX*" 形式的值。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您进行以下转换：

* 将整个演示文稿导出为 PDF
* 将演示文稿的特定幻灯片导出为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中会准确渲染以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。

以下代码展示了如何将演示文稿（PPT、PPTX、ODP 等）转换为 PDF：
```java
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // 将演示文稿保存为 PDF。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose 提供了免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现本文所述的过程。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下的属性，允许您自定义生成的 PDF，使用密码锁定 PDF，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以为光栅图像定义首选的质量设置，指定如何处理元文件，为文本设置压缩级别，配置图像的 DPI 等。

下面的代码示例演示了如何使用多个自定义选项将 PowerPoint 演示文稿转换为 PDF：
```java
// 实例化 PdfOptions 类。
PdfOptions pdfOptions = new PdfOptions();

// 设置 JPG 图像的质量。
pdfOptions.setJpegQuality((byte)90);

// 设置图像的 DPI。
pdfOptions.setSufficientResolution(300);

// 设置元文件的处理方式。
pdfOptions.setSaveMetafilesAsPng(true);

// 设置文本内容的压缩级别。
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// 定义 PDF 合规模式。
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // 将演示文稿保存为 PDF 文档。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **将 PowerPoint 转换为包含隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用来自 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类的 [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) 方法，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下代码展示了如何在 PDF 中包含隐藏幻灯片进行转换：
```java
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类。
    PdfOptions pdfOptions = new PdfOptions();

    // 添加隐藏幻灯片。
    pdfOptions.setShowHiddenSlides(true);

    // 将演示文稿保存为 PDF。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **将 PowerPoint 转换为受密码保护的 PDF**

以下代码演示了如何使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类的保护参数，将 PowerPoint 演示文稿转换为受密码保护的 PDF：
```java
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 实例化 PdfOptions 类。
    PdfOptions pdfOptions = new PdfOptions();

    // 设置 PDF 密码和访问权限。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // 将演示文稿保存为 PDF。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类下提供了 [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) 方法，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

以下代码展示了如何检测字体替换：
```java
public static void main(String[] args) {
    // 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
    Presentation presentation = new Presentation("sample.pptx");

    // 在 PDF 选项中设置警告回调。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // 将演示文稿保存为 PDF。
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// 警告回调的实现。
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

有关在渲染过程中接收字体替换回调的更多信息，请参阅 [获取字体替换警告回调](/slides/zh/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/java/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中的选定幻灯片转换为 PDF**

以下代码演示了如何仅将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：
```java
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // 设置幻灯片编号数组。
    int[] slides = { 1, 3 };

    // 将演示文稿保存为 PDF。
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下代码演示了如何使用指定的幻灯片尺寸将 PowerPoint 演示文稿转换为 PDF：
```java
float slideWidth = 612;
float slideHeight = 792;

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// 创建一个具有调整后幻灯片尺寸的新演示文稿。
Presentation resizedPresentation = new Presentation();

try {
    // 设置自定义幻灯片尺寸。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // 从原始演示文稿克隆第一张幻灯片。
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // 将调整尺寸的演示文稿保存为带有备注的 PDF。
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下代码演示了如何将 PowerPoint 演示文稿转换为包含备注的 PDF：
```java
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // 使用备注布局配置 PDF 选项。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // 将演示文稿保存为带备注的 PDF。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 过程：
```java
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为流行的文件格式。您可以执行 [PDF 转 HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF 转图像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、以及 [PDF 转 PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) 转换。其他针对特定格式的 PDF 转换操作——[PDF 转 SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、以及 [PDF 转 XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}

## **常见问题解答**

1. **我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

   是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

2. **能否对转换后的 PDF 设置密码保护？**

   完全可以。使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

3. **如何在 PDF 中包含隐藏幻灯片？**

   使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类的 `setShowHiddenSlides` 方法即可在生成的 PDF 中包含隐藏幻灯片。

4. **Aspose.Slides 能否在 PDF 中保持高图像质量？**

   能。您可以通过使用 [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) 类中的 `setJpegQuality`、`setSufficientResolution` 等方法来控制图像质量，确保 PDF 中的图像保持高质量。

5. **Aspose.Slides 是否支持 PDF/A 合规标准？**

   支持。Aspose.Slides 允许您导出符合各种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for Java 文档](/slides/zh/java/)
- [Aspose.Slides for Java API 参考]((https://reference.aspose.com/slides/java/))
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)