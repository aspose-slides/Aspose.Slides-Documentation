---
title: 使用 PHP 将 PowerPoint 演示文稿转换为讲义模式
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/php-java/convert-powerpoint-in-handout-mode/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 讲义模式
- 讲义
- PPT
- PPTX
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 PHP 将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides for PHP 导出为 PDF 或图像，并附带示例代码。免费试用。"
---
## **简介**

Aspose.Slides 提供将演示文稿转换为多种格式的能力，包括在 Handout 模式下创建用于打印的讲义。该模式允许您配置在单页上显示多个幻灯片的方式，非常适用于会议、研讨会等活动。通过在 [PdfOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 和 [TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/) 类中设置 `setSlidesLayoutOptions` 方法即可启用此模式。

## **Handout 模式导出**

要配置 Handout 模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/handoutlayoutingoptions/) 对象，该对象决定了单页上放置的幻灯片数量以及其他显示参数。

下面是一个将演示文稿转换为 PDF（Handout 模式）的代码示例。

```php
// 加载演示文稿。
$presentation = new Presentation("sample.pptx");

// 设置导出选项。
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 打印幻灯片编号
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 为幻灯片打印框架
$slidesLayoutOptions->setPrintComments(false);                       // 不包含批注

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及渲染为图像时可用。

{{% /alert %}} 

## **常见问题解答**

**在 Handout 模式下，每页最大的幻灯片缩略图数量是多少？**

Aspose.Slides 支持的预设最多每页 9 张缩略图，可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列由 [HandoutType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/handouttype/) 类严格控制；不支持任意布局。

**我可以在 Handout 输出中包含隐藏的幻灯片吗？**

可以。 在目标格式的导出设置中使用 `setShowHiddenSlides` 方法启用隐藏幻灯片，例如 [PdfOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/)。