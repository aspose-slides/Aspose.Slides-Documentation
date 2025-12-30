---
title: 获取 PHP 中演示文稿的段落边界
linktitle: 段落
type: docs
weight: 60
url: /zh/php-java/paragraph/
keywords:
- 段落边界
- 文本部分边界
- 段落坐标
- 部分坐标
- 段落大小
- 文本部分大小
- 文本框
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中检索段落和文本部分的边界，以优化 PowerPoint 演示文稿中的文本定位。"
---

## **获取 TextFrame 中段落和部分的坐标**
使用通过 Java 的 Aspose.Slides for PHP，开发人员现在可以获取 TextFrame 段落集合中段落的矩形坐标。它还允许您获取段落中部分集合的[部分坐标](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--)。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部分的位置。
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **获取段落的矩形坐标**
使用[**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)方法，开发人员可以获取段落的边界矩形。
```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取表格单元格 TextFrame 中段落和部分的大小**

要获取表格单元格文本框中[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)的大小和坐标，可以使用[IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--)和[IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)方法。

以下示例代码演示了上述操作：
```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**段落和文本部分的坐标以什么单位返回？**

以点为单位，1 英寸 = 72 点。这适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

会。如果在[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)中启用了[换行](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式：像素 = 点 × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取“有效”的段落格式化参数，以考虑样式继承？**

使用[有效段落格式化数据结构](/slides/zh/php-java/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等属性的最终合并值。