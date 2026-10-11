---
title: 使用 JavaScript 将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides for Node.js 导出为 PDF 或图像，并提供示例代码。免费试用。"
---
## **介绍**

Aspose.Slides 提供将演示文稿转换为各种格式的功能，包括在 Handout 模式下创建用于打印的讲义。此模式允许您配置多个幻灯片在单页上的显示方式，适用于会议、研讨会及其他活动。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 和 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类中设置 `setSlidesLayoutOptions` 方法来启用此模式。

要在导出前设置讲义页的尺寸和方向，请参阅 [Notes Page Size](/slides/zh/nodejs-java/notes-size/)。

## **讲义模式导出**

要配置 Handout 模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handoutlayoutingoptions/) 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

下面是一个代码示例，演示如何在 Handout 模式下将演示文稿转换为 PDF。

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 打印幻灯片编号
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 在幻灯片周围打印边框
slidesLayoutOptions.setPrintComments(false);                                   // 无评论

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及以图像形式渲染时可用。
{{% /alert %}} 

## **常见问题**

**在 Handout 模式下，每页最大幻灯片缩略图数量是多少？**

Aspose.Slides 支持最多每页 9 个缩略图的[预设](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handouttype/)，可横向或纵向排列：1、2、3、4（横向/纵向）、6（横向/纵向）和 9（横向/纵向）。

**我可以自定义网格，例如每页 5 或 8 张幻灯片吗？**

不可以。缩略图的数量和排列方式严格受 [HandoutType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/handouttype/) 枚举控制，不支持任意布局。

**我可以在 Handout 输出中包含隐藏的幻灯片吗？**

可以。请在目标格式的导出设置中使用 `setShowHiddenSlides` 方法，例如 [PdfOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/)。