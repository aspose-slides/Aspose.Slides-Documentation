---
title: 在 PHP 中将 PPT 转换为 PPTX
linktitle: PPT 到 PPTX
type: docs
weight: 20
url: /zh/php-java/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 到 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将旧版 PPT 演示文稿快速转换为现代 PPTX — 清晰的教程、免费代码示例，无需 Microsoft Office。"
---

## **概述**

本文介绍如何使用 PHP 以及在线 PPT 到 PPTX 转换应用将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涵盖以下主题。

- 将 PPT 转换为 PPTX

## **在 PHP 中将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Java 示例代码，请参阅下面的章节，即 [Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [Convert PPT to PDF in PHP](/slides/zh/php-java/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in PHP](/slides/zh/php-java/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in PHP](/slides/zh/php-java/convert-powerpoint-to-html/)
- [Convert PPT to ODP in PHP](/slides/zh/php-java/save-presentation/)
- [Convert PPT to PNG in PHP](/slides/zh/php-java/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 的转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最佳方案是以编程方式完成。使用 Aspose.Slides API 只需几行代码即可实现。该 API 完全兼容 PPT 转 PPTX，并且能够：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、自定义几何形状的演示文稿。
- 转换具有纹理和图片填充样式的自动形状。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 
了解更多 [**Aspose.Slides PPT 到 PPTX 转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) 构建，可实时查看基本 PPT 到 PPTX 转换功能。Aspose.Slides Conversion 是一个 Web 应用，允许拖拽 PPT 格式的演示文件并下载转换后的 PPTX。

查看其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
Aspose.Slides for PHP via Java 现已支持开发者使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类实例访问 PPT，并将其转换为相应的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前，它支持对 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分转换为 PPTX。有关 PPT 到 PPTX 转换支持的功能和不支持的功能的更多详情，请参阅本文档 [link](/slides/zh/php-java/ppt-to-pptx-conversion/)。

Aspose.Slides for PHP via Java 提供了表示 **PPTX** 演示文件的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类。实例化对象后，Presentation 类现在也可以访问 **PPT**。以下示例演示如何将 PPT 演示文稿转换为 PPTX 演示文稿。
```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("Aspose.ppt");
  try {
    # 将 PPTX 演示文稿保存为 PPTX 格式
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**图 1：源 PPT 演示文稿**|

上述代码片段在转换后生成了以下 PPTX 演示文稿

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**图 2：转换后生成的 PPTX 演示文稿**|

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较旧的二进制文件格式，而 PPTX 是自 Microsoft Office 2007 起引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小以及改进的数据恢复能力。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 以编程方式将多个 PPT 文件批量转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 到 PPTX 转换过程中都会被保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

可以，Aspose.Slides 支持将 PPT 文件转换为 [多种格式](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等图像格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下进行 PPT 到 PPTX 的转换？**

可以，Aspose.Slides 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可完成转换。

**是否有在线工具可用于 PPT 到 PPTX 的转换？**

可以，您可以使用免费的 [Aspose.Slides PPT 到 PPTX 转换器](https://products.aspose.app/slides/conversion/ppt-to-pptx) 网页应用，在浏览器中直接完成转换，无需编写任何代码。