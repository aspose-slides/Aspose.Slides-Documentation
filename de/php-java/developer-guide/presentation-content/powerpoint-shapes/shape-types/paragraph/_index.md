---
title: Absatz
type: docs
weight: 60
url: /de/php-java/paragraph/
---


## Paragraph- und Portion-Koordinaten im TextFrame erhalten ##
Mit Aspose.Slides für PHP über Java können Entwickler nun die rechteckigen Koordinaten für den Absatz innerhalb der Absatzsammlung des TextFrames abrufen. Es ermöglicht auch, [die Koordinaten der Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) innerhalb der Portionssammlung eines Absatzes zu erhalten. In diesem Thema werden wir mit Hilfe eines Beispiels demonstrieren, wie man die rechteckigen Koordinaten für den Absatz zusammen mit der Position der Portion innerhalb eines Absatzes erhält.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Rechteckige Koordinaten des Absatzes erhalten**
Mit der [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) Methode können Entwickler die Grenzrechtecke für den Absatz abrufen.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Breite: " . $rect->$width . " Höhe: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Größe des Absatzes und der Portion innerhalb des Textrahmens der Tabellenzelle erhalten** ##

Um die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) oder die [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) Größe und Koordinaten in einem Textrahmen einer Tabellenzelle zu erhalten, können Sie die [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) und [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--) Methoden verwenden.

Dieser Beispielcode demonstriert die beschriebene Operation:

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