---
title: 在 PHP 中为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/php-java/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于理解且经过优化的代码示例。"
---

## **向段落添加动画效果**

我们在 [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) 类中添加了 [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法允许您为单个段落添加动画效果。以下示例代码演示了如何为单个段落添加动画效果：
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # 选择要添加效果的段落
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 为选定的段落添加飞入动画效果
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **获取段落的动画效果**

您可能需要查找已添加到段落的动画效果——例如，在某种场景下，您想获取段落中的动画效果，以便将这些效果应用到另一个段落或形状。

Aspose.Slides for PHP via Java 允许您获取文本框（形状）中段落所应用的所有动画效果。以下示例代码演示了如何获取段落中的动画效果：
```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **常见问题**

**文本动画与幻灯片切换有什么区别，能否同时使用？**

文本动画控制对象在幻灯片上的时间行为，而 [transitions](/slides/zh/php-java/slide-transition/) 控制幻灯片之间的切换方式。它们相互独立且可以一起使用；播放顺序由动画时间线和切换设置决定。

**导出为 PDF 或图像时，文本动画会被保留吗？**

不会。PDF 和光栅图像是静态的，您只能看到幻灯片的单一状态而没有运动。若需保留动画，请使用 [video](/slides/zh/php-java/convert-powerpoint-to-video/) 或 [HTML](/slides/zh/php-java/export-to-html5/) 导出。

**文本动画在布局和母版中有效吗？**

应用于布局/母版对象的效果会被幻灯片继承，但它们的时序和与幻灯片级别动画的交互取决于幻灯片上的最终顺序。