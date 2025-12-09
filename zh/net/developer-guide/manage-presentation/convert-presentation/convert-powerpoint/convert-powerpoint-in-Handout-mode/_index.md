---
title: 在 .NET 中以讲义模式转换 PowerPoint 演示文稿
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/net/convert-powerpoint-in-Handout-mode/
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
description: "在 .NET 中将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，附带示例 C# 代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为各种格式的功能，包括在讲义模式下创建用于打印的讲义。此模式允许您配置多张幻灯片在单页上的排列方式，适用于会议、研讨会和其他活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) 接口中设置 `SlidesLayoutOptions` 属性来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/handoutlayoutingoptions/) 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

以下代码示例演示了如何在讲义模式下将演示文稿转换为 PDF。
```c#
// 加载演示文稿。
using var presentation = new Presentation("sample.pptx");

// 设置导出选项。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 每页水平排列 4 张幻灯片
        PrintSlideNumbers = true,                   // 打印幻灯片编号
        PrintFrameSlide = true,                     // 在幻灯片周围打印边框
        PrintComments = false                       // 无评论
    }
};

// 导出演示文稿为 PDF 并使用所选布局。
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```


{{% alert color="warning" %}} 
请注意，`SlidesLayoutOptions` 属性仅在某些输出格式（例如 PDF、HTML、TIFF）以及以图像形式渲染时可用。 
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页可显示的幻灯片缩略图的最大数量是多少？**

Aspose.Slides 支持最多 9 张缩略图每页的 [presets](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/)，并支持水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列方式严格受 [HandoutType](https://reference.aspose.com/slides/net/aspose.slides.export/handouttype/) 枚举控制；不支持任意布局。

**我可以在讲义输出中包含隐藏幻灯片吗？**

可以。为目标格式的导出设置启用 `ShowHiddenSlides` 选项，例如 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/)。