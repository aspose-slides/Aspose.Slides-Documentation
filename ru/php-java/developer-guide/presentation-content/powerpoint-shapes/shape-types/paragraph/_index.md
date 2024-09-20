---
title: Параграф
type: docs
weight: 60
url: /php-java/paragraph/
---

## Получение координат параграфа и частей текста в TextFrame ##
Используя Aspose.Slides для PHP через Java, разработчики теперь могут получать прямоугольные координаты для параграфов внутри коллекции параграфов TextFrame. Это также позволяет получать [координаты части текста](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) внутри коллекции частей текста параграфа. В этой теме мы собираемся продемонстрировать с помощью примера, как получить прямоугольные координаты для параграфа вместе с положением части текста внутри параграфа.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Получение прямоугольных координат параграфа**
Используя метод [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--), разработчики могут получать прямоугольник границ параграфа.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Ширина: " . $rect->$width . " Высота: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение размера параграфа и частей текста внутри текстового поля ячейки таблицы** ##

Чтобы получить размер и координаты [Части текста](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) или [Параграфа](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) в текстовом поле ячейки таблицы, вы можете использовать методы [IPortion.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getRect--) и [IParagraph.getRect](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraph#getRect--).

В этом образце кода демонстрируется описанная операция:

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