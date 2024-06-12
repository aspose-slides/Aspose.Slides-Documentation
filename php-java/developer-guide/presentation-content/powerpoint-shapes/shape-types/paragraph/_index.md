---
title: Paragraph
type: docs
weight: 60
url: /php-java/paragraph/
---


## Get Paragraph and Portion Coordinates in TextFrame ##
Using Aspose.Slides for PHP via Java, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get [the coordinates of portion](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPortion#getCoordinates--) inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach ($textFrame->getParagraphs() as $paragraph) {
    foreach ($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }

```


## **Get Rectangular Coordinates of Paragraph**
Using [**getRect()**](https://reference.aspose.com/slides/php-java/com.aspose.slides/IParagraph#getRect--) method developers can get paragraph bounds rectangle.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect::$x . " Y: " . $rect::$y . " Width: " . $rect::$width . " Height: " . $rect::$height);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Get size of paragraph and portion inside table cell text frame** ##

To get the [Portion](https://reference.aspose.com/slides/php-java/com.aspose.slides/Portion) or [Paragraph](https://reference.aspose.com/slides/php-java/com.aspose.slides/Paragraph) size and coordinates in a table cell text frame, you can use the [IPortion.getRect](https://reference.aspose.com/slides/php-java/com.aspose.slides/IPortion#getRect--) and [IParagraph.getRect](https://reference.aspose.com/slides/php-java/com.aspose.slides/IParagraph#getRect--) methods.

This sample code demonstrates the described operation:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach ($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach ($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
