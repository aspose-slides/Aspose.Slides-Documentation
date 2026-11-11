---
title: 在 .NET 中将 PPT 和 PPTX 转换为 PDF [包含高级功能]
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
  - .NET
  - C#
  - Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将 PowerPoint PPT/PPTX 转换为高质量、可搜索的 PDF，提供快速的 C# 代码示例和高级转换选项。"
---
## **概述**

在 C# 中将 PowerPoint 演示文稿（PPT、PPTX、ODP 等）转换为 PDF 格式有多种优势，包括在不同设备之间的兼容性以及保持演示文稿的布局和格式。本指南演示了如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，对 PDF 文件设置密码，检测字体替换，选择特定幻灯片进行转换，以及对输出文档应用合规标准。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* **PPT**
* **PPTX**
* **ODP**

要将演示文稿转换为 PDF，请将文件名作为参数传递给 [演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，然后使用 [保存](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类公开的 [保存](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法通常用于将演示文稿转换为 PDF。

{{% alert color="info" title="注意" %}}

Aspose.Slides for .NET 会将其 API 信息和版本号插入到输出文档中。例如，在将演示文稿转换为 PDF 时，Aspose.Slides 会在 Application 字段中填入 “*Aspose.Slides*”，在 PDF Producer 字段中填入 “*Aspose.Slides v XX.XX*”。**注意**，您无法指示 Aspose.Slides 更改或删除这些信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 整个演示文稿为 PDF
* 演示文稿中的特定幻灯片为 PDF

Aspose.Slides 将演示文稿导出为 PDF，确保生成的 PDF 与原始演示文稿高度匹配。转换过程会准确渲染以下元素和属性：

* 图像
* 文本框和形状
* 文本格式
* 段落格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint 到 PDF 转换过程使用默认选项。在此情况下，Aspose.Slides 会尝试使用最佳设置、最高质量级别将提供的演示文稿转换为 PDF。

下面的示例加载演示文稿并使用默认导出设置将所有可见幻灯片保存为 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="注意" %}}

Aspose 提供了一个免费的在线 [**PowerPoint 转 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。您可以使用此转换器进行测试，以实时实现本文所述的步骤。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供自定义选项——位于 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义生成的 PDF、为 PDF 设置密码，或指定转换过程的执行方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

使用自定义转换选项，您可以为光栅图像定义首选质量设置，指定元文件的处理方式，为文本设置压缩级别，配置图像 DPI 等。

下面的示例将演示文稿导出为 PDF 1.5，JPEG 质量设为 90，图像分辨率设为 300 DPI，元文件保存为 PNG，并使用 Flate 文本压缩。

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

> **注意：** 通过将 `PdfOptions.SufficientResolution` 设置为更高的值（例如 `300`），可以提高文本阴影和反射效果的渲染质量。这样生成的 PDF 更加接近 Microsoft PowerPoint 中的外观。

### **自动选择图像压缩**

当演示文稿包含大量照片或屏幕截图时，减小导出 PDF 的大小可使其更容易通过电子邮件发送或下载。将 [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) 设置为 `true`，即可在 PDF 导出期间为每个图像自动选择最合适的压缩算法。

下面的示例加载现有演示文稿，启用自动图像压缩选择，并将其保存为 PDF 文档。所有其他 PDF 导出设置保持默认值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

此选项为每个图像选择压缩算法。降低 [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 会降低 JPEG 图像质量，而降低 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) 会将图像下采样到更低的分辨率，从而可能降低细节。启用自动压缩选择本身不会降低上述任一设置。

选择图像压缩算法会增加额外的处理时间和内存消耗。大小的缩减取决于演示文稿的图像和导出设置；并非每个演示文稿都能保证固定的缩减幅度。

### **将嵌入的 OLE 文件保留为 PDF 附件**

如果演示文稿中嵌入了 Excel 工作簿，您可能希望 PDF 接收者既能访问工作簿数据，又能查看幻灯片。将 [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) 设置为 `true`，即可将嵌入的 OLE 文件保留为生成的 PDF 附件。

默认值为 `false`：OLE 对象的预览图像或图标会渲染在 PDF 页面上，但其嵌入文件不会作为附件包含。将此选项设为 `true` 还会额外包含文件数据。预览仍是视觉表示；附件则允许接收者单独打开或保存嵌入文件。OLE 对象不会在 PDF 页面上变为可交互的 Excel 工作表。

下面的示例加载已经嵌入 Excel 工作簿的演示文稿，并将其导出为附带工作簿的 PDF。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

检查结果的步骤：

1. 在支持文件附件的查看器（如 Adobe Acrobat Reader）中打开导出的 PDF。
2. 打开查看器的 **Attachments** 面板，定位嵌入的工作簿。
3. 保存附件并在 Excel 中打开以检查其数据，或如果查看器允许直接打开则直接打开。PDF 页面上的预览与附件分离。

{{% alert color="info" title="注意" %}}

PDF/A 标准对附件有约束：PDF/A-1 禁止嵌入文件，PDF/A-2 仅允许 PDF/A 附件，PDF/A-3 允许其他文件类型，包括 Excel 工作簿。这些是标准的要求，而非 Aspose.Slides 的特定限制。此示例使用默认的 PDF 合规设置，未演示 PDF/A 导出。

{{% /alert %}}

### **将隐藏幻灯片包含在 PDF 中**

如果演示文稿包含隐藏幻灯片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中的 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性，将隐藏幻灯片作为页面包含在生成的 PDF 中。

下面的示例将演示文稿导出为 PDF，并包括所有隐藏幻灯片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **将 PowerPoint 转换为受密码保护的 PDF**

下面的示例将演示文稿导出为需要密码 `password` 才能打开的 PDF。访问权限允许打印，包括高质量打印。

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

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下提供 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 属性，使您能够在演示文稿到 PDF 的转换过程中检测字体替换。

下面的示例将演示文稿导出为 PDF，并将字体替换警告打印到控制台。仅当在导出期间替换了不可用字体时才会打印警告。

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

{{% alert color="info" title="注意" %}}

有关字体替换的更多信息，请参阅 [Font Substitution](/slides/zh/net/font-substitution/) 文章。

{{% /alert %}} 

### **处理没有专用粗体字形的字体**

即使字体本身没有专用的粗体字形，演示文稿仍可能对文本应用粗体格式。此时文本会通过合成粗体（人工加粗常规字形）显示。当该文本在 PDF 中显得过于粗重或与预期外观不符时，可尝试将 [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) 设置为 `true`。该选项在 PDF 导出期间将受影响的文本渲染为位图，可改善某些字体的显示效果。默认值为 `false`。

示例演示文稿包含两个文本框：一个普通文本，一个对同一字体（没有专用粗体字形）应用了粗体格式。下面的示例加载该演示文稿，启用对不支持的字体样式进行光栅化，并将其导出为 PDF：

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

下图展示了关闭和开启该选项的输出对比。示例中，禁用选项时粗体文本的笔画更重；开启选项后笔画更轻，普通文本保持不变。请在为您的演示文稿选择设置前比较结果。

| 选项关闭 (`false`，默认) | 选项开启 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此示例中，开启选项仅将粗体文本光栅化为位图：它无法被选中、复制或在没有 OCR 的情况下搜索，且在 800% 放大时边缘更柔和。普通文本仍保持可搜索。关闭选项时，两段文字均为文本。

此选项会在字体没有专用粗体字形时将粗体文本光栅化。[Font substitution](/slides/zh/net/font-substitution/) 则会在原字体不可用时选择另一种字体。

## **将选定的幻灯片从 PowerPoint 导出为 PDF**

下面的示例将演示文稿的第 1 和第 3 张幻灯片导出为 PDF。数组中的幻灯片编号采用从 1 开始的方式，输入演示文稿必须至少包含三张幻灯片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **使用自定义幻灯片尺寸将 PowerPoint 转换为 PDF**

下面的示例将演示文稿的第一张幻灯片复制到一个新演示文稿中，幻灯片尺寸设为 612 × 792 点（8.5 × 11 英寸）。它会缩放幻灯片内容以适配，并将单张幻灯片导出为 PDF。

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

## **在备注幻灯片视图下将 PowerPoint 转换为 PDF**

下面的示例将演示文稿导出为 PDF，在每张幻灯片下方放置对应的讲者备注。请使用包含讲者备注的演示文稿以查看效果。

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

## **PDF 的可访问性与合规标准**

Aspose.Slides 允许您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换流程。您可以使用以下任一合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 C# 代码演示了基于不同合规标准生成多个 PDF 的 PowerPoint 到 PDF 的转换过程：

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

{{% alert color="info" title="注意" %}}

Aspose.Slides 支持 PDF 转换操作，您可以将 PDF 文件转换为流行的文件格式。支持的转换包括 [PDF 转 HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF 转图像](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF 转 JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、以及 [PDF 转 PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/)。此外，还支持将 PDF 转换为专用格式的操作——[PDF 转 SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF 转 TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、和 [PDF 转 XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)。

{{% /alert %}}

> **注意：** 在导出为 PDF/UA 时，Aspose.Slides 会将 SmartArt、图表和公式等复杂图形视为单个图形。单独的路径元素不会保留为独立内容，可能被标记为伪影；仅为整个图形提供替代文本。

## **常见问题解答**

**我可以批量将多个 PowerPoint 文件转换为 PDF 吗？**

可以，Aspose.Slides 支持将多个 PPT 或 PPTX 文件批量转换为 PDF。您可以遍历文件并以编程方式应用转换过程。

**可以对转换后的 PDF 设置密码保护吗？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类在转换过程中设置密码并定义访问权限。

**如何在 PDF 中包含隐藏幻灯片？**

在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中将 [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性设为 `true`，即可在生成的 PDF 中包含隐藏幻灯片。

**Aspose.Slides 能在 PDF 中保持高图像质量吗？**

能。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类中设置 [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) 和 [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) 等属性，确保 PDF 中的图像保持高质量。

**Aspose.Slides 是否支持 PDF/A 合规标准？**

支持。Aspose.Slides 允许您导出符合多种标准的 PDF，包括 PDF/A1a、PDF/A1b 和 PDF/UA，确保文档满足可访问性和归档要求。

## **补充资源**

- [Aspose.Slides for .NET 文档](/slides/zh/net/)
- [Aspose.Slides for .NET API 参考](https://reference.aspose.com/slides/net/)
- [Aspose 免费在线转换器](https://products.aspose.app/slides/conversion)

相关功能：[Export presentations to PDF](/slides/zh/features/pdf-export/).