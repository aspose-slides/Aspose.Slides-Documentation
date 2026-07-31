---
title: 在 Android 上以讲义模式转换 PowerPoint 演示文稿
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/androidjava/convert-powerpoint-in-handout-mode/
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
description: "在 Java 中将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用适用于 Android 的 Aspose.Slides 导出为 PDF 或图像，并附带示例代码。免费试用。"
---
## **简介**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在 Handout 模式下创建可打印的讲义。此模式允许您配置多张幻灯片在单页上的显示方式，非常适用于会议、研讨会等活动。您可以通过在 [IPdfOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ihtmloptions/) 和 [ITiffOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiffoptions/) 接口中设置 `setSlidesLayoutOptions` 方法来启用此模式。

## **Handout 模式导出**

要配置 Handout 模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/handoutlayoutingoptions/) 对象，它决定单页放置的幻灯片数量以及其他显示参数。

下面是一个代码示例，展示如何在 Handout 模式下将演示文稿转换为 PDF。

```java
// 加载演示文稿。
Presentation presentation = new Presentation("sample.pptx");
try {
	// 设置导出选项。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 在单页水平放置 4 张幻灯片
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // 打印幻灯片编号
	slidesLayoutOptions.setPrintFrameSlide(true);                     // 在幻灯片周围打印框架
	slidesLayoutOptions.setPrintComments(false);                      // 无评论

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 使用选定的布局将演示文稿导出为 PDF。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及渲染为图像时可用。 
{{% /alert %}} 

## **常见问题**

**Handout 模式下每页最大幻灯片缩略图数量是多少？**

Aspose.Slides 支持最多每页 9 张缩略图的[预设](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/handouttype/)，可采用水平或垂直排列方式：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**能否自定义网格，例如每页 5 张或 8 张幻灯片？**

不能。缩略图的数量和排列方式严格由 [HandoutType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/handouttype/) 类控制，不支持自定义布局。

**可以在 Handout 输出中包含隐藏的幻灯片吗？**

可以。通过在目标格式的导出设置中使用 `setShowHiddenSlides` 方法（如 [PdfOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/tiffoptions/)），即可包含隐藏幻灯片。