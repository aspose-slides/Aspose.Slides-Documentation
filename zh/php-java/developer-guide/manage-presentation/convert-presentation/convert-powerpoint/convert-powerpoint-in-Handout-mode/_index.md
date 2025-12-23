---
title: 使用 PHP 在讲义模式下转换 PowerPoint 演示文稿
linktitle: 讲义模式
type: docs
weight: 150
url: /zh/php-java/convert-powerpoint-in-Handout-mode/
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
description: "在 PHP 中将演示文稿转换为讲义。设置每页幻灯片数，保留备注，使用 Aspose.Slides for PHP 导出为 PDF 或图像，并提供示例代码。免费试用。"
---

## **讲义模式导出**

Aspose.Slides 提供了将演示文稿转换为多种格式的能力，包括在讲义模式下创建用于打印的讲义。该模式允许您配置多个幻灯片在单页上的显示方式，适用于会议、研讨会等场景。您可以通过在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) 和 [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) 类中设置 `setSlidesLayoutOptions` 方法来启用此模式。

要配置讲义模式，请使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/) 对象，该对象决定了单页上放置多少张幻灯片以及其他显示参数。

以下代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。
```php
// 加载演示文稿。
$presentation = new Presentation("sample.pptx");

// 设置导出选项。
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 打印幻灯片编号
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 在幻灯片周围打印框架
$slidesLayoutOptions->setPrintComments(false);                       // 无评论

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// 使用所选布局将演示文稿导出为 PDF。
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```


{{% alert color="warning" %}} 
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式下可用，例如 PDF、HTML、TIFF，以及渲染为图像时。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页最大的幻灯片缩略图数量是多少？**

Aspose.Slides 支持的 [presets](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) 最多每页 9 张缩略图，并可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）和 9（水平/垂直）。

**我可以自定义网格，例如每页 5 张或 8 张幻灯片吗？**

不能。缩略图的数量和排列方式严格由 [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) 类控制；不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。通过在目标格式的导出设置中使用 `setShowHiddenSlides` 方法启用隐藏幻灯片，例如在 [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) 中。