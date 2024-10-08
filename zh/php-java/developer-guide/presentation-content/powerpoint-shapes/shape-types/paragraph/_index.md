---
title: 段落
type: docs
weight: 60
url: /php-java/paragraph/
---

## 在TextFrame中获取段落和部分坐标 ##
使用Aspose.Slides for PHP via Java，开发人员现在可以获取TextFrame的段落集合中段落的矩形坐标。它还允许您获取段落内部分部分的[坐标](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--)。在本主题中，我们将通过示例演示如何获取段落的矩形坐标以及部分在段落内的位置。

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
使用[**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)方法，开发人员可以获取段落边界矩形。

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

## **获取表格单元格文本框中段落和部分的大小** ##

要获取表格单元格文本框中的[部分](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)或[段落](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)的大小和坐标，可以使用[IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--)和[IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--)方法。

该示例代码演示了上述操作：

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