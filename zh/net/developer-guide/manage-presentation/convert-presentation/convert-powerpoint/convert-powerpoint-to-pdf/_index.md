---
title: 在 .NET 中将 PPT 和 PPTX 转换为 PDF【含高级功能】
linktitle: PowerPoint 转 PDF
type: docs
weight: 40
url: /zh/net/convert-powerpoint-to-pdf/
keywords:
- 将 PowerPoint 转换
- 将演示文稿转换
- PowerPoint 转 PDF
- 演示文稿转 PDF
- PPT 转 PDF
- 将 PPT 转换为 PDF
- PPTX 转 PDF
- 将 PPTX 转换为 PDF
- 将 PowerPoint 保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 将 PPT 导出为 PDF
- 将 PPTX 导出为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速的 C# 代码示例和高级转换选项。"
---

## **概述**

在 C# 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备上的兼容性以及保持演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，为 PDF 文件设置密码，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类，然后使用[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法将演示文稿保存为 PDF。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类公开的[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法通常用于将演示文稿转换为 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 “*Aspose.Slides*”，在 PDF Producer 字段中填入形如 “*Aspose.Slides v XX.XX*” 的值。**注意**，您无法指示 Aspose.Slides 更改或移除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿到 PDF
* 演示文稿中的特定幻灯片到 PDF

Aspose.Slides 导出演示文稿为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程中准确渲染的元素和属性包括：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 转 PDF 过程使用默认选项。在此情况下，Aspose.Slides 会使用最高质量级别的最佳设置将提供的演示文稿转换为 PDF。

下面的 C# 代码演示如何将演示文稿（PPT、PPTX、ODP 等）转换为 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.ppt");

// 将演示文稿保存为 PDF。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose 提供一个免费的在线[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时体验本文所述的实现步骤。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类下的属性——让您自定义生成的 PDF，使用密码锁定 PDF，或指定转换过程的行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过自定义转换选项，您可以为光栅图像定义首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像的 DPI 等。

下面的代码示例演示如何使用多个自定义选项将 PowerPoint 演示文稿转换为 PDF：
```c#
// 实例化 PdfOptions 类。
var pdfOptions = new PdfOptions
{
    // 为 JPG 图像设置质量。
    JpegQuality = 90,

    // 为图像设置 DPI。
    SufficientResolution = 300,

    // 设置元文件的处理方式。
    SaveMetafilesAsPng = true,

    // 为文本内容设置压缩级别。
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

如果演示文稿包含隐藏幻灯片，您可以使用[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类中的[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)属性，将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的 C# 代码展示了如何在转换为 PDF 时包含隐藏幻灯片：
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

下面的 C# 代码演示如何使用[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类的保护参数，将 PowerPoint 演示文稿转换为受密码保护的 PDF：
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

Aspose.Slides 在[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类下提供[WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)属性，使您能够在演示文稿转 PDF 的过程中检测字体替换。

下面的 C# 代码展示了如何检测字体替换：
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

有关在渲染过程中接收字体替换回调的更多信息，请参阅[Getting Warning Callbacks for Fonts Substitution](/slides/zh/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替换的更多信息，请参阅[Font Substitution](/slides/zh/net/font-substitution/)文章。

{{% /alert %}} 

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

下面的 C# 代码演示如何仅将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：
```c#
// 实例化表示 PowerPoint 或 OpenDocument 文件的 Presentation 类。
using var presentation = new Presentation("PowerPoint.pptx");

// 设置幻灯片编号数组。
int[] slides = { 1, 3 };

// 将演示文稿保存为 PDF。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

下面的 C# 代码演示如何使用指定的幻灯片尺寸将 PowerPoint 演示文稿转换为 PDF：
```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

下面的 C# 代码演示如何将 PowerPoint 演示文稿转换为包含备注的 PDF：
```c#
// 加载 PowerPoint 演示文稿。
using var presentation = new Presentation("NotesFile.pptx");

// 使用备注布局配置 PDF 选项。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// 将演示文稿保存为带备注的 PDF。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的转换过程。您可以使用以下任意合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

下面的 C# 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 转 PDF 过程：
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

Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为流行的文件格式。您可以执行[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、以及[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/)转换。其他针对特定格式的 PDF 转换操作——如[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、以及[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)——也受到支持。

{{% /alert %}}

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

可以，Aspose.Slides 支持批量将多个 PPT 或 PPTX 文件转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**是否可以为生成的 PDF 设置密码保护？**

当然。使用[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类即可在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类中将`ShowHiddenSlides`属性设置为 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能否在 PDF 中保持高图像质量？**

可以。通过在[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)类中设置 `JpegQuality`、`SufficientResolution` 等属性，您可以确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持。Aspose.Slides 允许您导出符合 PDF/A1a、PDF/A1b 和 PDF/UA 等多种标准的 PDF，确保文档满足可访问性和归档要求。

## **其他资源**

- [Aspose.Slides for .NET Documentation](/slides/zh/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)