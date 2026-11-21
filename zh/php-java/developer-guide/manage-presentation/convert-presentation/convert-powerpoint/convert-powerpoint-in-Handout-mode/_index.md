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
description: "在 PHP 中将演示文稿转换为讲义。设置每页幻灯片数量，保留备注，使用 Aspose.Slides for PHP 导出为 PDF 或图像，并提供示例代码。免费试用。"
---
## **介绍**

Aspose.Slides 提供将演示文稿转换为多种格式的功能，包括在讲义模式下创建用于打印的讲义。该模式允许您配置多张幻灯片在单页上的显示方式，适用于会议、研讨会以及其他活动。您可以在 [PdfOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/}}、[RenderingOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/renderingoptions/}}、[HtmlOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/}} 和 [TiffOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/}} 类中调用 `setSlidesLayoutOptions` 方法来启用此模式。

如需在导出前设置讲义页面尺寸和方向，请参阅 [Notes Page Size](/slides/zh/php-java/notes-size/)。

## **讲义模式导出**

要配置讲义模式，请使用 [HandoutLayoutingOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/handoutlayoutingoptions/}} 对象，它决定单页上放置的幻灯片数量以及其他显示参数。

下面的代码示例展示了如何在讲义模式下将演示文稿转换为 PDF。

```php
// 加载演示文稿。
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 每页水平放置 4 张幻灯片
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 打印幻灯片编号
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 在幻灯片周围打印框
$slidesLayoutOptions->setPrintComments(false);                       // 不包含评论

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
请注意，`setSlidesLayoutOptions` 方法仅在某些输出格式（如 PDF、HTML、TIFF）以及渲染为图像时可用。
{{% /alert %}} 

## **常见问题**

**在讲义模式下，每页最大可以放置多少个幻灯片缩略图？**

Aspose.Slides 支持的 [presets]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/handouttype/}} 最多可在每页放置 9 个缩略图，支持横向或纵向排列：1、2、3、4（横向/纵向）、6（横向/纵向）和 9（横向/纵向）。

**我可以自定义网格，例如每页 5 或 8 张幻灯片吗？**

不可以。缩略图的数量和排列方式严格受 [HandoutType]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/handouttype/}} 类控制，不支持任意布局。

**我可以在讲义输出中包含隐藏的幻灯片吗？**

可以。通过在目标格式的导出设置（如 [PdfOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/pdfoptions/}}、[HtmlOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/}} 或 [TiffOptions]{{https://reference.aspose.com/slides/zh/php-java/aspose.slides/tiffoptions/}}）中使用 `setShowHiddenSlides` 方法来启用隐藏幻灯片。