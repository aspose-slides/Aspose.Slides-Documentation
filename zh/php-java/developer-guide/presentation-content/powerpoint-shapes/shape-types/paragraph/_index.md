---
title: 从 PHP 演示文稿中获取段落边界
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
使用 Aspose.Slides for PHP via Java，开发人员现在可以获取 TextFrame 段落集合中段落的矩形坐标。它还允许您获取[部分的坐标](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getCoordinates)在段落的部分集合中。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及段落内部分的位置。
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
使用[**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect)方法，开发人员可以获取段落的边界矩形。
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
要获取表格单元格 TextFrame 中[Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)的大小和坐标，您可以使用[Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect)和[Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect)方法。

此示例代码演示了上述操作：
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


## **常见问题**

**段落和文本部分的坐标以什么单位返回？**

使用点（points），1 英寸 = 72 点。此单位适用于幻灯片上的所有坐标和尺寸。

**自动换行会影响段落的边界吗？**

是的。如果在[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)中启用了[wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)，文本会根据区域宽度换行，从而改变段落的实际边界。

**段落坐标能可靠地映射到导出图像的像素吗？**

可以。使用公式：像素 = 点 × (DPI / 72)。结果取决于渲染/导出时选择的 DPI。

**如何获取“实际”段落格式参数，并考虑样式继承？**

使用[effective paragraph formatting data structure](/slides/zh/php-java/shape-effective-properties/)，它返回缩进、间距、换行、RTL 等参数的最终合并值。