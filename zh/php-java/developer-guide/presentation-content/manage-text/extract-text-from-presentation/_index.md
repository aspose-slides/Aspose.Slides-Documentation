---
title: PHP 中高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/php-java/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。遵循我们的简明分步指南，以节省时间。"
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不少见。为此，您需要提取演示文稿中所有幻灯片上所有形状的文本。本文介绍了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。 

{{% /alert %}} 
## **从幻灯片提取文本**
Aspose.Slides for PHP via Java provides the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, use the [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) overloaded static method exposed by the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:
```php
  # 实例化代表 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # 从 PPTX 的所有幻灯片获取 ITextFrame 对象的数组
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # 遍历 TextFrames 数组
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 遍历当前 ITextFrame 中的段落
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 遍历当前 IParagraph 中的部分
          foreach($para->getPortions() as $port) {
            # 显示当前部分的文本
            echo($port->getText());
            # 显示文本的字体大小
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
To scan the text from the whole presentation, use the
[getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) object that represents the presentation from which the text is being extracted.
2. Second, a boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 从 PPTX 的所有幻灯片获取 ITextFrame 对象数组
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
The new static method getPresentationText has been added to Presentation class. There are three overloads for this method:
```php

```


## **FAQ**

**在文本提取过程中，Aspose.Slides 处理大型演示文稿的速度如何？**

Aspose.Slides 经过高性能优化，即使是 [large presentations](/slides/zh/php-java/open-presentation/) 也能高效处理，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

是的，Aspose.Slides 完全支持从表格、图表以及其他复杂幻灯片元素中提取文本，让您能够轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版提取文本，但它会有一些限制，例如只能处理有限数量的幻灯片。若要无限制使用并处理更大的演示文稿，建议购买正式许可证。