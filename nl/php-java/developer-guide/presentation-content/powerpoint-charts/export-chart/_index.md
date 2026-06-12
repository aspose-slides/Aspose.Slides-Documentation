---
title: Export Presentatiegrafieken in PHP
linktitle: Export Grafiek
type: docs
weight: 90
url: /nl/php-java/export-chart/
keywords:
- diagram
- diagram naar afbeelding
- diagram als afbeelding
- diagramafbeelding extraheren
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u presentatiediagrammen kunt exporteren met Aspose.Slides voor PHP via Java, met ondersteuning voor PPT- en PPTX-formaten, en stroomlijn rapportage in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een diagram uit een presentatie te exporteren als afbeelding. Dit artikel laat zien hoe u een afbeelding van een diagram kunt verkrijgen en opslaan, wat handig is wanneer u diagramvisualisaties buiten een PowerPoint-presentatie wilt hergebruiken.

## **Een grafiekafbeelding ophalen**
Aspose.Slides for PHP via Java biedt ondersteuning voor het extraheren van een afbeelding van een specifiek diagram. Hieronder staat een voorbeeld.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik een diagram exporteren als vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een diagram is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [shape-to-SVG saving method](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/).

**Hoe kan ik de exacte grootte van de geëxporteerde diagram in pixels instellen?**

Gebruik de image-rendering overloads waarmee u de grootte of schaal kunt opgeven - de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/scale.

**Wat moet ik doen als lettertypen in labels en de legenda er na het exporteren verkeerd uitzien?**

[Load the required fonts](/slides/nl/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/) zodat de rendering van het diagram de metriek en weergave van de tekst behoudt.

**Houdt de export rekening met het PowerPoint-thema, stijlen en effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema's, stijlen, vullingen, effecten), waardoor het uiterlijk van het diagram behouden blijft.

**Waar kan ik de beschikbare render-/exportmogelijkheden vinden, buiten diagramafbeeldingen?**

Zie de [API](https://reference.aspose.com/slides/nl/php-java/aspose.slides/)/[documentation](/slides/nl/php-java/convert-powerpoint/) voor doelformaten ([PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), enz.) en gerelateerde render-opties.