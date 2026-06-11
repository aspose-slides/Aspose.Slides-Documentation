---
title: Hämta styckegränser från presentationer i PHP
linktitle: Stycke
type: docs
weight: 60
url: /sv/php-java/paragraph/
keywords:
- styckegränser
- textdelgränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i Aspose.Slides för PHP via Java för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du får gränserna, storleken och koordinaterna för stycken och textdelar i Aspose.Slides. Den visar hur du hämtar ett styckes rektangel i ett `TextFrame` med `getRect()`, hur du får stycke- och delkoordinater inne i en tabellcells textram, samt framhäver viktiga detaljer såsom mätenheter, effekten av textomslag på gränser, pixelkonvertering och effektiva styckeformateringsvärden.

## **Hämta koordinater för stycke och del i en TextFrame**
Med Aspose.Slides för PHP via Java kan utvecklare nu hämta de rektangulära koordinaterna för Paragraph i styckeskollektionen i ett TextFrame. Det möjliggör även att hämta [koordinaterna för delen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getCoordinates) i delkollektionen för ett stycke. I det här avsnittet kommer vi att demonstrera med ett exempel hur du får de rektangulära koordinaterna för ett stycke samt positionen för en del i ett stycke.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Hämta rektangulära koordinater för ett stycke**
Genom att använda [**getRect()**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getRect)-metoden kan utvecklare hämta styckegränsrutan.

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

## **Hämta storleken för ett stycke och en del i en tabellcells TextFrame**
För att hämta storleken och koordinaterna för [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Portion) eller [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Paragraph) i en tabellcells textram kan du använda metoderna [Portion::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getRect) och [Paragraph::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getRect).

Denna exempelkod demonstrerar den beskrivna operationen:

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

## **Vanliga frågor**

**I vilka enheter returneras koordinaterna för ett stycke och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och mått på bilden.

**Påverkar ordbrytning ett styckes gränser?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setwraptext/) är aktiverat i [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan stycke‑koordinater på ett tillförlitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering/export.

**Hur får jag de ”effektiva” styckeformateringsparametrarna, med hänsyn till stilarv?**

Använd [effective paragraph formatting data structure](/slides/sv/php-java/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, omslag, RTL och mer.