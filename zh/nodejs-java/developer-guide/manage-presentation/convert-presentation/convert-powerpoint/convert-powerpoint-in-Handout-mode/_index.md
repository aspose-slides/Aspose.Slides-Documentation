---
title: 在 JavaScript 中将演示文稿转换为讲义模式
type: docs
weight: 150
url: /zh/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- 转换 PowerPoint
- 讲义模式
- 讲义
- PowerPoint
- PPT
- PPTX
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中将演示文稿转换为讲义模式"
---

## **讲义模式导出**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在 Handout 模式下创建用于打印的讲义。此模式允许您配置多张幻灯片在单页上的显示方式，非常适合会议、研讨会等活动。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) 和 [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) 类中设置 `setSlidesLayoutOptions` 方法来启用此模式。

要配置 Handout 模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/) 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

下面的代码示例展示了如何在 Handout 模式下将演示文稿转换为 PDF。
```js
// 加载演示文稿。
let presentation = new asposeSlides.Presentation("sample.pptx");

// 设置导出选项。
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 打印幻灯片编号
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 在幻灯片周围打印框架
slidesLayoutOptions.setPrintComments(false);                                   // 无评论

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式中可用，例如 PDF、HTML、TIFF，以及以图像形式渲染时。
{{% /alert %}} 

## **常见问题**

**Handout 模式下每页的幻灯片缩略图最大数量是多少？**

Aspose.Slides 支持的 [presets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) 每页最多可放置 9 张缩略图，排列方式可为水平或垂直：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列方式严格受 [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) 枚举控制，不支持自定义布局。

**我可以在 Handout 输出中包含隐藏的幻灯片吗？**

可以。请在目标格式的导出设置中使用 `setShowHiddenSlides` 方法，例如在 [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) 中。