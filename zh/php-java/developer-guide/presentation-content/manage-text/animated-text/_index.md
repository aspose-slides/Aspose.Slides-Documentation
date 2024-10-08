---
title: 动画文本
type: docs
weight: 60
url: /zh/php-java/animated-text/
keywords: "PowerPoint 中的动画文本"
description: "使用 Java 在 PowerPoint 中创建动画文本"
---

## 为段落添加动画效果

我们向 [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) 和 [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence) 类添加了 [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法允许您为单个段落添加动画效果。以下示例代码演示了如何为单个段落添加动画效果：

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # 选择要添加效果的段落
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 为选定段落添加飞入动画效果
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## 获取段落中的动画效果

您可能希望了解添加到段落的动画效果——例如，在某种情况下，您要获取段落中的动画效果，因为您计划将这些效果应用于另一个段落或形状。

Aspose.Slides for PHP via Java 允许您获取应用于文本框（形状）中段落的所有动画效果。以下示例代码演示了如何获取段落中的动画效果：

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("段落 \"" . $paragraph->getText() . "\" 具有 " . $effects[0]->getType() . " 效果。");
      }
    }
  } finally {
    $pres->dispose();
  }
```