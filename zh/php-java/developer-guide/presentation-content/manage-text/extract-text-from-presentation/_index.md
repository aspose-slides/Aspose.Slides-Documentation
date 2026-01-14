---
title: PHP 中的高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/php-java/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从PowerPoint提取文本
- 从OpenDocument提取文本
- 从PPT提取文本
- 从PPTX提取文本
- 从ODP提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从PowerPoint检索文本
- 从OpenDocument检索文本
- 从PPT检索文本
- 从PPTX检索文本
- 从ODP检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。遵循我们的简单一步步指南，节省时间。"
---

{{% alert color="primary" %}} 
开发者需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿的所有幻灯片上的所有形状中提取文本。本文介绍如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。 
{{% /alert %}} 
## **从幻灯片提取文本**
Aspose.Slides for PHP via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) 类。该类公开了多种重载的静态方法，用于从演示文稿或幻灯片中提取完整文本。要从 PPTX 演示文稿中的幻灯片提取文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) 类公开的 [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/) 重载静态方法。此方法接受 Slide 对象作为参数。
执行后，Slide 方法会扫描作为参数传入的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象数组。这意味着可以获取与文本关联的任何文本格式。以下代码片段提取了演示文稿第一张幻灯片上的所有文本：
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # 获取 PPTX 中所有幻灯片的 ITextFrame 对象数组
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # 遍历 TextFrames 数组
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 遍历当前 ITextFrame 中的段落
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 遍历当前 IParagraph 中的部分
          foreach($para->getPortions() as $port) {
            # 显示当前部分的文本
            echo($port->getText());
            # 显示文本的字体高度
            echo($port->getPortionFormat()->getFontHeight());
            # 显示文本的字体名称
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **从演示文稿提取文本**
要扫描整个演示文稿的文本，请使用 SlideUtil 类公开的 [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/) 静态方法。该方法接受两个参数：

1. 第一个参数是表示要提取文本的演示文稿的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 对象。
1. 第二个参数是布尔值，用于确定在扫描演示文稿文本时是否包含母版幻灯片。
   该方法返回一个 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 对象数组，包含完整的文本格式信息。以下代码扫描演示文稿的文本及其格式信息，包括母版幻灯片。
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 获取 PPTX 中所有幻灯片的 ITextFrame 对象数组
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # 遍历 TextFrames 数组
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # 遍历当前 ITextFrame 中的段落
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # 遍历当前 IParagraph 中的部分
        foreach($para->getPortions() as $port) {
          # 显示当前部分的文本
          echo($port->getText());
          # 显示文本的字体高度
          echo($port->getPortionFormat()->getFontHeight());
          # 显示文本的字体名称
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **分类和快速文本提取**
Presentation 类新增了静态方法 getPresentationText。该方法有三个重载版本：
```php

```


## **常见问题**

**Aspose.Slides 在文本提取过程中处理大型演示文稿的速度如何？**

Aspose.Slides 针对高性能进行了优化，能够高效处理甚至[大型演示文稿](/slides/zh/php-java/open-presentation/)，因此适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

是的，Aspose.Slides 完全支持从表格、图表及其他复杂幻灯片元素中提取文本，帮助您轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版提取文本，但它会有一些限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。