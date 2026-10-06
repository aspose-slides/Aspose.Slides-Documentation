---
title: 在 .NET 中将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/net/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PowerPoint
- 演示文稿
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并提供示例 C# 代码。免费试用。"
---
## **介绍**

Aspose.Slides 允许您将演示文稿转换为支持讲义模式的输出格式。在此模式下，多个幻灯片会排列在同一页面上，这对于为会议、研讨会及类似活动打印演示材料非常有用。

可以通过 `SlidesLayoutOptions` 属性来配置讲义模式，该属性在 [IPdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/itiffoptions/) 中可用。要定义讲义布局，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handoutlayoutingoptions/) 对象。

若要在导出前设置讲义页面的尺寸和方向，请参见 [Notes Page Size](/slides/zh/net/notes-size/).

## **讲义模式导出**

要以讲义模式导出演示文稿，请为目标导出选项设置 `SlidesLayoutOptions` 属性，并分配一个定义每页幻灯片数量及相关显示参数的 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handoutlayoutingoptions/) 实例。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 每页水平放置 4 张幻灯片
        PrintSlideNumbers = true,                   // 打印幻灯片编号
        PrintFrameSlide = true,                     // 在幻灯片周围打印边框
        PrintComments = false                       // 没有评论
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
请注意，`SlidesLayoutOptions` 属性仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。
{{% /alert %}} 

## **常见问题**

### 在讲义模式下，每页幻灯片缩略图的最大数量是多少？

Aspose.Slides 支持最多 9 张缩略图每页的 [presets](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handouttype/) ，并可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

### 我可以定义自定义网格，例如每页 5 或 8 张幻灯片吗？

不可以。缩略图的数量和顺序严格受 [HandoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.export/handouttype/) 枚举控制；不支持任意布局。

### 我可以在讲义输出中包含隐藏的幻灯片吗？

可以。请在目标格式的导出设置中启用 `ShowHiddenSlides` 选项，例如 [PdfOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/)。