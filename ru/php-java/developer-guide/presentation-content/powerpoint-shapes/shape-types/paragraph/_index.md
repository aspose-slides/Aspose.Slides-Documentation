---
title: Получить границы абзаца из презентаций в PHP
linktitle: Абзац
type: docs
weight: 60
url: /ru/php-java/paragraph/
keywords:
- границы абзаца
- границы текстовой части
- координата абзаца
- координата части
- размер абзаца
- размер текстовой части
- текстовый фрейм
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как получить границы абзаца и текстовой части в Aspose.Slides for PHP via Java, чтобы оптимизировать позиционирование текста в презентациях PowerPoint."
---

## **Получить координаты абзаца и части в TextFrame**
С помощью Aspose.Slides for PHP via Java разработчики теперь могут получить прямоугольные координаты Paragraph внутри коллекции абзацев TextFrame. Это также позволяет получить [координаты части](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getCoordinates) внутри коллекции частей абзаца. В этой статье мы покажем на примере, как получить прямоугольные координаты абзаца вместе с позицией части внутри абзаца.
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```


## **Получить прямоугольные координаты абзаца**
С помощью метода [**getRect()**](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) разработчики могут получить прямоугольник ограничений абзаца.
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


## **Получить размер абзаца и части внутри TextFrame ячейки таблицы**
Чтобы получить размер и координаты [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) или [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) в TextFrame ячейки таблицы, можно использовать методы [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) и [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect).
Этот пример кода демонстрирует описанную операцию:
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

**В каких единицах измеряются координаты, возвращаемые для абзаца и текстовых частей?**  
В пунктах, где 1 дюйм = 72 пункта. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**  
Да. Если [wrapping](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/) включен в [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), текст переносится, чтобы вписаться в ширину области, что изменяет фактические границы абзаца.

**Можно ли надежно преобразовать координаты абзаца в пиксели в экспортированном изображении?**  
Да. Преобразуйте пункты в пиксели с помощью формулы: pixels = points × (DPI / 72). Результат зависит от выбранного DPI для рендеринга/экспорта.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**  
Используйте [effective paragraph formatting data structure](/slides/ru/php-java/shape-effective-properties/); он возвращает окончательные согласованные значения отступов, интервалов, переноса, RTL и прочего.