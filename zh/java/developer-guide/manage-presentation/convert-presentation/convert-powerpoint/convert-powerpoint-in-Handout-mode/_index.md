---
title: 在 Java 中以讲义模式转换 PowerPoint 演示文稿
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/java/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在 Java 中将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides 导出为 PDF 或图像，并提供示例 Java 代码。免费试用。"
---
## **简介**

Aspose.Slides 允许您将演示文稿转换为支持讲义模式的输出格式。在此模式下，多个幻灯片会排列在同一页面上，适用于为会议、研讨会等活动打印演示材料。

可以通过 `setSlidesLayoutOptions` 方法配置讲义模式，该方法在 [IPdfOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itiffoptions/) 中可用。要定义讲义布局，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handoutlayoutingoptions/) 对象。

## **讲义模式导出**

要以讲义模式导出演示文稿，请在目标导出选项上设置 `setSlidesLayoutOptions` 方法，并分配一个定义每页幻灯片数量及相关显示参数的 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handoutlayoutingoptions/) 实例。

下面的代码示例演示了如何将演示文稿转换为 PDF 并使用讲义模式。

```java
// 加载演示文稿。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 设置导出选项。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // 打印幻灯片编号
    slidesLayoutOptions.setPrintFrameSlide(true);                     // 在幻灯片周围打印边框
    slidesLayoutOptions.setPrintComments(false);                      // 不包含批注

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 使用所选布局将演示文稿导出为 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式中可用，例如 PDF、HTML、TIFF，以及渲染为图像时。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页最多可以显示多少个幻灯片缩略图？**

Aspose.Slides 支持最多每页 9 张缩略图的[预设](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handouttype/)（水平或垂直排列），包括 1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列方式严格由 [HandoutType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/handouttype/) 类控制，不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。使用目标格式的导出设置中的 `setShowHiddenSlides` 方法启用隐藏幻灯片，例如 [PdfOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tiffoptions/)。