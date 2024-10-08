---
title: 从演示文稿中提取文本
type: docs
weight: 90
url: /zh/php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片上的所有形状中提取文本。本文解释了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for PHP via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取整个文本。要从 PPTX 演示文稿中的幻灯片提取文本，请使用 [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil) 类公开的重载静态方法 [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-)。该方法接受 Slide 对象作为参数。执行时，Slide 方法扫描传入参数的幻灯片中的全部文本，并返回一个 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) 对象的数组。这意味着与文本相关的任何文本格式都可用。以下代码片段提取演示文稿中第一张幻灯片上的所有文本：

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # 从 PPTX 中所有幻灯片获取 ITextFrame 对象数组
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # 遍历 TextFrames 数组
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # 遍历当前 ITextFrame 中的段落
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # 遍历当前 IParagraph 中的部分
          foreach($para->getPortions() as $port) {
            # 显示当前部分中的文本
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

## **从演示文稿中提取文本**
要扫描整个演示文稿中的文本，请使用 SlideUtil 类公开的静态方法 [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-)。它需要两个参数：

1. 首先，一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) 对象，表示要提取文本的演示文稿。
1. 其次，一个布尔值，确定在扫描演示文稿中的文本时，是否包含母版幻灯片。
该方法返回一个包含文本格式信息的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) 对象数组。以下代码从演示文稿中扫描文本及格式信息，包括母版幻灯片。

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # 从 PPTX 中所有幻灯片获取 ITextFrame 对象数组
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # 遍历 TextFrames 数组
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # 遍历当前 ITextFrame 中的段落
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # 遍历当前 IParagraph 中的部分
        foreach($para->getPortions() as $port) {
          # 显示当前部分中的文本
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
Presentation 类中添加了新的静态方法 getPresentationText。该方法有三个重载：

```php

``` 

[TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) 枚举参数指示组织文本结果输出的模式，可以设置为以下值：
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - 不考虑在幻灯片上的位置的原始文本
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - 文本按与幻灯片相同的顺序排列

**Unarranged** 模式可以在速度至关重要时使用，它比 Arranged 模式更快。

[IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) 表示从演示文稿中提取的原始文本。它包含一个 [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) 方法，该方法返回一个 [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) 对象数组。每个对象代表对应幻灯片上的文本。[ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) 对象具有以下方法：

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - 幻灯片形状上的文本
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - 此幻灯片的母版页形状上的文本
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - 此幻灯片的布局页形状上的文本
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - 此幻灯片的备注页形状上的文本

还有一个 [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) 类，它实现了 [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) 接口。

新的 API 可以这样使用：

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```