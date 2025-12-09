---
title: 在 .NET 中将 PPT 和 PPTX 转换为 PDF（包含高级功能）
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速的 C# 示例代码和高级转换选项。"
---

## **概述**

在 C# 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件设置密码保护，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，然后使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类公开了通常用于将演示文稿转换为 PDF 的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段填入 “*Aspose.Slides*”，在 PDF Producer 字段填入形如 “*Aspose.Slides v XX.XX*” 的值。**请注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中会准确呈现以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置在最高质量级别下将提供的演示文稿转换为 PDF。

以下 C# 代码展示了如何将演示文稿（PPT、PPTX、ODP 等）转换为 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.ppt");

// 将演示文稿保存为 PDF。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose 提供了免费在线的 [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实现本文所述的实际操作。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、为 PDF 设置密码，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像定义首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

以下代码示例演示了如何使用多个自定义选项将 PowerPoint 演示文稿转换为 PDF。
```c#
// 实例化 PdfOptions 类。
var pdfOptions = new PdfOptions
{
    // 设置 JPG 图像的质量。
    JpegQuality = 90,

    // 设置图像的 DPI。
    SufficientResolution = 300,

    // 设置元文件的行为。
    SaveMetafilesAsPng = true,

    // 设置文本内容的压缩级别。
    TextCompression = PdfTextCompression.Flate,

    // 定义 PDF 合规模式。
    Compliance = PdfCompliance.Pdf15
};

// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.pptx");

// 将演示文稿保存为 PDF 文档。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **将 PowerPoint 转换为包含隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中的 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性，将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下 C# 代码展示了如何将包含隐藏幻灯片的 PowerPoint 演示文稿转换为 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.pptx");

// 实例化 PdfOptions 类。
var pdfOptions = new PdfOptions();

// 添加隐藏幻灯片。
pdfOptions.ShowHiddenSlides = true;

// 将演示文稿保存为 PDF。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **将 PowerPoint 转换为受密码保护的 PDF**

以下 C# 代码演示了如何使用来自 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类的保护参数，将 PowerPoint 演示文稿转换为受密码保护的 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.pptx");

// 实例化 PdfOptions 类。
var pdfOptions = new PdfOptions();

// 设置 PDF 密码和访问权限。
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// 将演示文稿保存为 PDF。
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下提供了 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 属性，使您能够在演示文稿转 PDF 的过程中检测字体替换。

以下 C# 代码展示了如何检测字体替换：
```c#
public static void Main()
{
    // 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
    using var presentation = new Presentation("sample.pptx");

    // 在 PDF 选项中设置警告回调。
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // 将演示文稿保存为 PDF。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 警告回调的实现。
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

有关在渲染过程中接收字体替换回调的更多信息，请参阅 [Getting Warning Callbacks for Fonts Substitution](/slides/zh/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参阅 [Font Substitution](/slides/zh/net/font-substitution/) 文章。

{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下 C# 代码演示了如何仅将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.pptx");

// Set array of slide numbers.
int[] slides = { 1, 3 };

// Save the presentation as a PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**

以下 C# 代码演示了如何使用指定的幻灯片大小将 PowerPoint 演示文稿转换为 PDF：
```c#
var slideWidth = 612;
var slideHeight = 792;

// 加载 PowerPoint 演示文稿。
using var presentation = new Presentation("SelectedSlides.pptx");

// 创建一个具有调整后幻灯片大小的新演示文稿。
using var resizedPresentation = new Presentation();

// 设置自定义幻灯片大小。
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// 从原始演示文稿克隆第一张幻灯片。
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// 将调整大小的演示文稿保存为带备注的 PDF。
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下 C# 代码演示了如何将包含备注的 PowerPoint 演示文稿转换为 PDF：
```c#
// 加载 PowerPoint 演示文稿。
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任一合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 C# 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 过程：
```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为流行的文件格式。您可以执行 [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) 和 [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 转换。其他针对专用格式的 PDF 转换操作——[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) 和 [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

可以，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以对转换后的 PDF 设置密码保护？**

完全可以。使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

将 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类的 `ShowHiddenSlides` 属性设为 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以，您可以通过设置 `JpegQuality`、`SufficientResolution` 等属性来控制图像质量，确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和存档要求。

## **其他资源**

- [Aspose.Slides for .NET 文档](/slides/zh/net/)
- [Aspose.Slides for .NET API 参考](https://reference.aspose.com/slides/net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)