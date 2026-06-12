---
title: Beheer tekstgedeelten in presentaties met PHP
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/php-java/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint-presentaties beheert met Aspose.Slides voor PHP via Java, waardoor de prestaties en aanpassing worden verbeterd."
---
## **Inleiding**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment moet ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het tekstgedrag op een gedetailleerder niveau wilt beheersen.

## **Coördinaten van een tekstgedeelte ophalen**
[**getCoordinates()**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/getcoordinates/) methode is toegevoegd aan de [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) klasse die het mogelijk maakt de coördinaten van het begin van het gedeelte op te halen.

```php
  # Instantieer Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # De context van de presentatie herstructureren
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

## **FAQ**

**Kan ik een hyperlink alleen op een deel van de tekst binnen één alinea toepassen?**

Ja, u kunt [een hyperlink toewijzen](/slides/nl/php-java/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment is klikbaar, niet de gehele alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**

Eigenschappen op Portion‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/), haalt de engine deze op van de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/); is hij daar ook niet ingesteld, van de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) of van de [theme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/theme/) stijl.

**Wat gebeurt er als het lettertype dat voor een Portion is opgegeven ontbreekt op de doelmachine/-server?**

[Lettertype‑vervangingsregels](/slides/nl/php-java/font-selection-sequence/) worden toegepast. De tekst kan zich opnieuw laten vloeien: metrics, woordafbreking en breedte kunnen veranderen, wat van belang is voor precieze positionering.

**Kan ik een Portion‑specifieke transparantie of verloop van tekstvulling instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) niveau kunnen verschillen van aangrenzende fragmenten.