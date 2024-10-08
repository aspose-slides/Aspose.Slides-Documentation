---
title: 将 PowerPoint 转换为 PDF 的 C#
linktitle: 将 PowerPoint 转换为 PDF
type: docs
weight: 40
url: /zh/net/convert-powerpoint-to-pdf/
keywords:
- 转换 PowerPoint
- 演示文稿
- PowerPoint 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 保存 PowerPoint 为 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 PDF。保存 PowerPoint 为符合性或可访问性标准的 PDF。"
---

## **概述**

将 PowerPoint 文档转换为 PDF 格式具有多个优点，包括确保不同设备之间的兼容性以及保持演示文稿的布局和格式。本文将向您展示如何将演示文稿转换为 PDF 文档，使用各种选项控制图像质量，包含隐藏幻灯片，给 PDF 文档加密，检测字体替代，选择要转换的幻灯片，并将符合性标准应用于输出文档。

## **PowerPoint 到 PDF 的转换**

使用 Aspose.Slides，您可以将以下格式的演示文稿转换为 PDF：

* PPT
* PPTX
* ODP

要将演示文稿转换为 PDF，您只需将文件名作为参数传递给 [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，然后使用 [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PDF。[`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类公开了 [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) 方法，该方法通常用于将演示文稿转换为 PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for .NET 直接在输出文档中写入 API 信息和版本号。例如，当它将演示文稿转换为 PDF 时，Aspose.Slides for .NET 会将应用程序字段填充为 '*Aspose.Slides*' 值，而 PDF 生产者字段填充为 '*Aspose.Slides v XX.XX*' 形式的值。 **注意**，您无法指示 Aspose.Slides for .NET 更改或删除此信息。

{{% /alert %}}

Aspose.Slides 允许您转换：

* 将整个演示文稿转换为 PDF
* 将演示文稿中的特定幻灯片转换为 PDF
* 一个演示文稿

Aspose.Slides 以一种方式将演示文稿导出为 PDF，使得结果 PDF 的内容与原始演示文稿非常相似。这些已知的元素和属性在演示文稿到 PDF 的转换中通常会正确呈现：

* 图像
* 文本框和其他形状
* 文本及其格式
* 段落及其格式
* 超链接
* 页眉和页脚
* 项目符号
* 表格

## **将 PowerPoint 转换为 PDF**

标准的 PowerPoint PDF 转换操作使用默认选项执行。在这种情况下，Aspose.Slides 试图使用最佳设置在最高质量级别下将提供的演示文稿转换为 PDF。

以下 C# 代码演示了如何将 PowerPoint (PPT, PPTX, ODP) 转换为 PDF：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 类，可以是 PPT、PPTX、ODP 等
Presentation presentation = new Presentation("PowerPoint.ppt");

// 将演示文稿保存为 PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose 提供了一个免费的在线 [**PowerPoint 到 PDF 转换器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，演示了演示文稿到 PDF 的转换过程。要实时实现此处描述的过程，您可以使用该转换器进行测试。

{{% /alert %}}

## **使用选项将 PowerPoint 转换为 PDF**

Aspose.Slides 提供了自定义选项——[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类下的属性——允许您自定义 PDF（转换过程生成的 PDF），用密码锁定 PDF，甚至指定转换过程的操作方式。

### **使用自定义选项将 PowerPoint 转换为 PDF**

通过使用自定义转换选项，您可以设置所需的光栅图像质量设置，指定如何处理元文件，为文本设置压缩级别，为图像设置 DPI 等。

以下代码示例演示了一个操作，其中 PowerPoint 演示文稿使用多个自定义选项转换为 PDF：

```c#
// 实例化 PdfOptions 类
PdfOptions pdfOptions = new PdfOptions
{
    // 设置 JPG 图像的质量
    JpegQuality = 90,

    // 设置图像的 DPI
    SufficientResolution = 300,

    // 设置元文件的行为
    SaveMetafilesAsPng = true,

    // 设置文本内容的压缩级别
    TextCompression = PdfTextCompression.Flate,

    // 定义 PDF 合规模式
    Compliance = PdfCompliance.Pdf15
};

// 实例化一个表示 PowerPoint 文档的 Presentation 类
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // 将演示文稿保存为 PDF 文档
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **将 PowerPoint 转换为包含隐藏幻灯片的 PDF**

如果演示文稿包含隐藏幻灯片，您可以使用一个自定义选项——[`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) 属性来自 [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类——来指示 Aspose.Slides 将隐藏幻灯片作为页面包含到生成的 PDF 中。

以下 C# 代码演示了如何将 PowerPoint 演示文稿转换为包含隐藏幻灯片的 PDF：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 类
Presentation presentation = new Presentation("PowerPoint.pptx");

// 实例化 PdfOptions 类
PdfOptions pdfOptions = new PdfOptions();

// 添加隐藏的幻灯片
pdfOptions.ShowHiddenSlides = true;

// 将演示文稿保存为 PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **将 PowerPoint 转换为密码保护的 PDF**

以下 C# 代码演示了如何将 PowerPoint 转换为一个密码保护的 PDF（使用来自 [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) 类的保护参数）：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 对象
Presentation presentation = new Presentation("PowerPoint.pptx");

/// 实例化 PdfOptions 类
PdfOptions pdfOptions = new PdfOptions();

// 设置 PDF 密码和访问权限
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// 将演示文稿保存为 PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **检测字体替代**

Aspose.Slides 在 [`SaveOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) 类下提供 [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) 属性，以允许您检测演示文稿到 PDF 转换过程中的字体替代。 

以下 C# 代码演示了如何检测字体替代：

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"字体替代警告: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

有关如何获取字体替代的回调的更多信息，请参见 [获取字体替代的警告回调](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

有关字体替代的更多信息，请参见 [字体替代](https://docs.aspose.com/slides/net/font-substitution/) 文章。

{{% /alert %}} 

## **将选定的 PowerPoint 幻灯片转换为 PDF**

以下 C# 代码演示了如何将 PowerPoint 演示文稿中的特定幻灯片转换为 PDF：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 对象
Presentation presentation = new Presentation("PowerPoint.pptx");

// 设置幻灯片位置的数组
int[] slides = { 1, 3 };

// 将演示文稿保存为 PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **将 PowerPoint 转换为具有自定义幻灯片大小的 PDF**

以下 C# 代码演示了如何在指定幻灯片大小时将 PowerPoint 转换为 PDF：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 对象 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// 设置幻灯片类型和大小 
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **以讲义幻灯片视图将 PowerPoint 转换为 PDF**

以下 C# 代码演示了如何将 PowerPoint 转换为 PDF 讲义：

```c#
// 实例化一个表示 PowerPoint 文件的 Presentation 类
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// 将演示文稿保存为 PDF 讲义
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **PDF 的可访问性和合规性标准**

Aspose.Slides 允许您使用符合 [Web 内容可访问性指南 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的转换程序。您可以使用以下任何合规标准将 PowerPoint 文档导出为 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

以下 C# 代码演示了一次 PowerPoint 到 PDF 的转换操作，其中获取了基于不同合规标准的多个 PDF：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 对 PDF 转换操作的支持范围包括允许您转换 PDF 到最流行的文件格式。您可以进行 [PDF 到 HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF 到图像](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF 到 JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) 和 [PDF 到 PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 的转换。其他 PDF 转换操作到专业格式——[PDF 到 SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF 到 TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) 和 [PDF 到 XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)——也得到了支持。

{{% /alert %}}