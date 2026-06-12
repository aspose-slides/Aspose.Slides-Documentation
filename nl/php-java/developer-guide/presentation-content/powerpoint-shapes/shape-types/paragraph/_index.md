---
title: Haal alinea-grenzen op uit presentaties in PHP
linktitle: Alinea
type: docs
weight: 60
url: /nl/php-java/paragraph/
keywords:
- alinea-grenzen
- tekstgedeelte-grenzen
- alinea-coordinaat
- gedeelte-coordinaat
- alinea-grootte
- tekstgedeelte-grootte
- tekstframe
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u alinea- en tekstgedeelte-grenzen kunt ophalen in Aspose.Slides voor PHP via Java om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe je de grenzen, grootte en coördinaten van alinea's en tekstgedeelten in Aspose.Slides kunt verkrijgen. Het toont hoe je een rechthoek van een alinea in een `TextFrame` kunt ophalen met `getRect()`, hoe je de coördinaten van alinea en gedeelte binnen een tabelcel‑tekstframe kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op grenzen, pixelconversie en de effectieve alinea‑opmaakwaarden.

## **Haal de coördinaten van alinea en gedeelte op in een TextFrame**
Met Aspose.Slides voor PHP via Java kunnen ontwikkelaars nu de rechthoekige coördinaten van een Paragraph binnen de alinea‑collectie van een TextFrame ophalen. Het maakt ook mogelijk om [de coördinaten van het gedeelte](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getCoordinates) binnen de gedeelte‑collectie van een alinea te krijgen. In dit onderwerp laten we met behulp van een voorbeeld zien hoe je de rechthoekige coördinaten van een alinea kunt ophalen, samen met de positie van het gedeelte binnen die alinea.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Haal rechthoekige coördinaten van een alinea op**
Met de [**getRect()**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getRect)‑methode kunnen ontwikkelaars de begrenzende rechthoek van een alinea ophalen.

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

## **Haal de grootte van een alinea en gedeelte op binnen een tabelcel‑tekstframe**

Om de grootte en coördinaten van een [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Portion) of [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Paragraph) in een tabelcel‑tekstframe te verkrijgen, kun je de methoden [Portion::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getRect) en [Paragraph::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getRect) gebruiken.

Deze voorbeeldcode demonstreert de beschreven bewerking:

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

**In welke eenheden worden de coördinaten van een alinea en tekstgedeelten geretourneerd?**

In points, waarbij 1 inch = 72 points. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setwraptext/) is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/), wordt de tekst afgebroken om de breedte van het gebied te passen, waardoor de werkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar naar pixels worden omgezet in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor renderen/export.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, rekening houdend met overerving van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/php-java/shape-effective-properties/); het geeft de definitieve samengevoegde waarden voor inspringingen, afstand, omloop, RTL en meer.