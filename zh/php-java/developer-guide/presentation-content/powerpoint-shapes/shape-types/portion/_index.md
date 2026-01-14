---
title: 使用 PHP 管理演示文稿中的文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/php-java/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中管理文本片段，从而提升性能和自定义能力。"
---

## **获取文本片段的坐标**
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) 方法已添加到 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) 类，允许检索片段起始位置的坐标。
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 重塑演示文稿的上下文
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以仅对单段落中的部分文本应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/php-java/manage-hyperlinks/)到单个片段；只有该片段可点击，而不是整段。

**样式继承是如何工作的：Portion 会覆盖哪些属性，哪些属性来自 Paragraph/TextFrame？**

片段级属性具有最高优先级。如果属性未在[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)上设置，引擎会从[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)获取；如果在那里也未设置，则从[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/)样式获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体会怎样？**

将应用[字体替换规则](/slides/zh/php-java/font-selection-sequence/)。文本可能重新排版：度量、连字符和宽度可能会变化，这对精确定位很重要。

**我能为特定 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，位于[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)级别的文本颜色、填充和透明度可以与相邻片段不同。