---
title: 在 C# 中将演示文稿转换为讲义模式
type: docs
weight: 150
url: /zh/net/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 讲义模式
- 讲义
- PowerPoint
- PPT
- PPTX
- 演示文稿
- C#
- Csharp
- .NET
- Aspose.Slides
description: "在 C# 中将演示文稿转换为讲义模式"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为各种格式的功能，包括在讲义模式下创建用于打印的讲义。该模式允许您配置多个幻灯片在单页上的呈现方式，非常适用于会议、研讨会和其他活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) 接口中设置 `SlidesLayoutOptions` 属性来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) 对象，该对象决定单页上放置的幻灯片数量以及其他显示参数。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。
```c#
// 加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// 设置导出选项。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 每页水平放置4张幻灯片
        PrintSlideNumbers = true,                   // 打印幻灯片编号
        PrintFrameSlide = true,                     // 为幻灯片打印框架
        PrintComments = false                       // 不打印评论
    }
};

// 将演示文稿导出为 PDF 并使用所选布局。
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
请注意，`SlidesLayoutOptions` 属性仅在特定输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页幻灯片缩略图的最大数量是多少？**

Aspose.Slides 支持的 [presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 每页最多可放置 9 张缩略图，支持横向或纵向排列：1、2、3、4（横向/纵向）、6（横向/纵向）和 9（横向/纵向）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列方式严格由 [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 枚举控制；不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。通过在目标格式的导出设置中启用 `ShowHiddenSlides` 选项，例如在 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) 中。