---
title: 在 JavaScript 中使用 Handout 模式转换 PowerPoint 演示文稿
linktitle: Handout 模式
type: docs
weight: 150
url: /zh/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- handout 模式
- handout
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides for Node.js 导出为 PDF 或图像，并提供示例代码。免费试用。"
---
## **简介**

Aspose.Slides 提供将演示文稿转换为各种格式的功能，包括在讲义模式下创建用于打印的讲义。此模式允许您配置多张幻灯片在单页上的显示方式，非常适用于会议、研讨会等活动。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/), 和 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类中设置 `setSlidesLayoutOptions` 方法来启用此模式。

## **讲义模式导出**

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handoutlayoutingoptions/) 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

以下代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。

```js
// 加载演示文稿.
let presentation = new asposeSlides.Presentation("sample.pptx");

// 设置导出选项.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 打印幻灯片编号
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 为幻灯片打印框架
slidesLayoutOptions.setPrintComments(false);                                   // 不打印评论

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// 使用所选布局将演示文稿导出为 PDF.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
请记住，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。 
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页最多可以显示多少个幻灯片缩略图？**

Aspose.Slides 支持的[预设](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handouttype/)最多每页可放置 9 个缩略图，支持水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 或 8 张幻灯片吗？**

不能。缩略图的数量和顺序严格受 [HandoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handouttype/) 枚举控制；不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。请在目标格式的导出设置中使用 `setShowHiddenSlides` 方法，例如 [PdfOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/)。