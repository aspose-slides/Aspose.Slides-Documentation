---
title: 将 PPT 和 PPTX 转换为 .NET 中的 PDF（包含高级功能）
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
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速的 C# 示例代码和高级转换选项。"
---
## **概述**

在 C# 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式具有多种优势，包括在不同设备之间的兼容性以及保留演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项来控制图像质量、包含隐藏幻灯片、对 PDF 文件进行密码保护、检测字体替换、选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 转 PDF 转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [Presentation 类](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ，然后使用 [Save 方法](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 将演示文稿保存为 PDF。[Presentation 类](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 提供了通常用于将演示文稿转换为 PDF 的 [Save 方法](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)。

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET 会将其 API 信息和版本号插入输出文档。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 “*Aspose.Slides*”，在 PDF Producer 字段中填入类似 “*Aspose.Slides v XX.XX*” 的值。**注意**，无法指示 Aspose.Slides 更改或删除输出文档中的此信息。
{{% /alert %}}

Aspose.Slides 允许您转换：
* 整个演示文稿转换为 PDF
* 从演示文稿中选择特定幻灯片转换为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。在转换过程中，元素和属性被准确呈现，包括：
* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置和最高质量级别将提供的演示文稿转换为 PDF。

以下示例加载演示文稿，并使用默认导出设置将所有可见幻灯片保存为 PDF：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ，演示演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实际运行本文所述的步骤。
{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、使用密码锁定 PDF，或指定转换过程的行为。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以定义光栅图像的首选质量设置、指定如何处理元文件、设置文本的压缩级别、配置图像的 DPI 等。

以下示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中包含嵌入的 Excel 工作簿，您可能希望 PDF 接收者能够访问工作簿的数据并查看幻灯片。将 [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) 设置为 `true` 可在生成的 PDF 中将嵌入的 OLE 文件保留为附件。

默认值为 `false`：OLE 对象的预览图像或图标会渲染到 PDF 页面上，但其嵌入文件不会作为附件包含。将此选项设为 `true` 会额外包含文件数据。预览仍然是视觉呈现；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变成交互式的 Excel 工作表。

以下示例加载已经包含嵌入 Excel 工作簿的演示文稿，并将其导出为带有工作簿附件的 PDF：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

检查结果：

1. 在支持文件附件的查看器（例如 Adobe Acrobat Reader）中打开导出的 PDF。  
2. 打开查看器的 **Attachments** 面板，定位嵌入的工作簿。  
3. 保存该附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开则直接打开。PDF 页面上的预览与附件是分离的。

{{% alert color="info" title="Note" %}}
PDF/A 标准对附件有约束：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许包括 Excel 工作簿在内的其他文件类型。这些是标准的要求，而非 Aspose.Slides 特有的限制。本示例使用默认的 PDF 合规设置，并未演示 PDF/A 导出。
{{% /alert %}}

### **使用隐藏幻灯片将 PowerPoint 转换为 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中的 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性将隐藏幻灯片作为页面包含在生成的 PDF 中。

以下示例将演示文稿导出为 PDF，包含所有隐藏幻灯片：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **将 PowerPoint 转换为受密码保护的 PDF**

以下示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **检测字体替换**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下提供了 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 属性，使您能够在演示文稿转 PDF 的过程中检测字体替换。

以下示例将演示文稿导出为 PDF，并在控制台打印字体替换警告。仅当导出期间出现不可用字体被替换时才会打印警告：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
有关字体替换的更多信息，请参阅 [字体替换](/slides/zh/net/font-substitution/) 文章。
{{% /alert %}} 

### **处理没有专用粗体字形的字体**

即使字体本身没有专用的粗体字形，演示文稿仍可能对文本应用粗体格式。此时文本会通过合成加粗（人工加厚常规字形）呈现。当合成加粗的文本在 PDF 中看起来过于沉重或与预期外观不符时，可尝试将 [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) 设置为 `true`。此选项在 PDF 导出期间将受影响的文本渲染为位图，对某些字体可以改善外观。默认值为 `false`。

示例演示文稿包含两个文本框：一个是常规文本，另一个对同一没有专用粗体字形的字体应用了粗体格式。以下示例加载该演示文稿，启用对不支持的字体样式的光栅化，并将其导出为 PDF：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

以下预览显示了禁用和启用选项的输出差异。在本例中，禁用选项时粗体文本的笔划更粗；启用选项后笔划更细，常规文本保持不变。请在决定使用哪种设置前比较结果。

| 选项禁用 (`false`，默认) | 选项启用 (`true`) |
|---|---|
| ![禁用不支持的粗体字形光栅化的 PDF](unsupported-bold-disabled.png) | ![启用不支持的粗体字形光栅化的 PDF](unsupported-bold-enabled.png) |

在本例中，启用该选项仅将粗体文本转换为位图：该文本无法被选中、复制或在没有 OCR 的情况下搜索，且在 800% 放大时边缘显得更柔和。常规文本仍可搜索。禁用选项时，两个字符串均保持为文本。

此选项会在字体没有专用粗体字形时对以粗体格式的文本进行光栅化。[字体替换](/slides/zh/net/font-substitution/) 则会在原始字体不可用时选择其他字体。

## **将 PowerPoint 中选定的幻灯片转换为 PDF**

以下示例将演示文稿中的第 1 张和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用从 1 开始的方式，输入演示文稿必须至少包含三张幻灯片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

以下示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸设为 612 × 792 点（8.5 × 11 英寸）。它会按比例缩放幻灯片内容以适应尺寸，并将单张幻灯片导出为 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**

以下示例将演示文稿导出为 PDF，在每张幻灯片下方放置对应的演讲者备注。请使用包含演讲者备注的演示文稿以查看结果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF 的可访问性和合规标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换过程。您可以使用以下任一合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" title="Note" %}}
Aspose.Slides 支持 PDF 转换操作，允许您将 PDF 文件转换为常见的文件格式。您可以执行 [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 等转换。还支持其他针对专用格式的 PDF 转换操作——[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)。
{{% /alert %}}

> **注意:** 导出为 PDF/UA 时，Aspose.Slides 将 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会保留为独立内容，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

是的，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式执行转换过程。

**是否可以对转换后的 PDF 进行密码保护？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中将 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性设为 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能在 PDF 中保持高图像质量吗？**

可以，您可以通过在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中设置 [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 和 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) 等属性，确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持，Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和存档要求。

## **其他资源**

- [Aspose.Slides for .NET 文档](/slides/zh/net/)
- [Aspose.Slides for .NET API 参考](https://reference.aspose.com/slides/net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)