---
title: 在 Android 上以讲义模式转换 PowerPoint 演示文稿
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Java 中将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用适用于 Android 的 Aspose.Slides 导出为 PDF 或图像，并提供示例代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在讲义模式下创建用于打印的讲义。该模式允许您配置多张幻灯片在单页上的显示方式，适用于会议、研讨会等活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), 和 [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) 接口中设置 `setSlidesLayoutOptions` 方法来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

以下示例演示如何在讲义模式下将演示文稿转换为 PDF。
```java
// 加载演示文稿。
Presentation presentation = new Presentation("sample.pptx");
try {
	// 设置导出选项。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // 打印幻灯片编号
	slidesLayoutOptions.setPrintFrameSlide(true);                     // 在幻灯片周围打印框架
	slidesLayoutOptions.setPrintComments(false);                      // 不打印批注

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 使用所选布局将演示文稿导出为 PDF。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。 
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页的幻灯片缩略图最大数量是多少？**

Aspose.Slides 支持最多 9 张缩略图的 [presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/)（水平或垂直排列），具体包括 1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不可以。缩略图的数量和排列方式严格受 [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) 类控制，不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。通过在目标格式的导出设置（如 [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), 或 [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/)) 中使用 `setShowHiddenSlides` 方法来启用隐藏幻灯片。