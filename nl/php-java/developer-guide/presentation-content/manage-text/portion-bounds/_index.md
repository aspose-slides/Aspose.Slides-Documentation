---
title: Huidige tekstgedeeltegrenzen ophalen uit presentaties in PHP
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/php-java/portion-bounds/
keywords:
- tekstgedeeltegrenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u tekstgedeeltegrenzen kunt ophalen in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen delen worden gebruikt wanneer u de grenzen van een tekstfragment moet ophalen, indeling alleen op een deel van een alinea wilt toepassen, of het gedrag van tekst op een meer gedetailleerd niveau wilt beheersen.

Dit artikel laat zien hoe u de omvattende rechthoek van een tekstgedeelte kunt krijgen met behulp van [Portion::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/getrect/). Het toont ook hoe u de coördinaten van het begin van een tekstgedeelte kunt verkrijgen met [Portion::getCoordinates](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/getcoordinates/). Daarnaast worden veelvoorkomende scenario’s rond tekstgedeelten belicht, zoals het toevoegen van een hyperlink aan één tekstfragment, inzicht in hoe opmaak wordt afgehandeld via tekstgedeelte, alinea, tekstvak en thema‑erfenis, en het omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Grenzen van een tekstgedeelte ophalen**

Gebruik [Portion::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/getrect/) om het omvattende rechthoek van een tekstgedeelte op te halen:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Coördinaten van een tekstgedeelte ophalen**

Gebruik [Portion::getCoordinates](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/getcoordinates/) om de coördinaten van het begin van een tekstgedeelte op te halen:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt [een hyperlink toewijzen](/slides/nl/php-java/manage-hyperlinks/) aan een afzonderlijk tekstgedeelte; alleen dat fragment zal klikbaar zijn, niet de hele alinea.

**Hoe werkt stijl‑erfenis: wat overschrijft een tekstgedeelte en wat wordt overgenomen van een alinea of tekstvak?**

Eigenschappen op tekstgedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/), neemt Aspose.Slides deze over van de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/). Als die daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) of van het [theme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/theme/).

**Wat gebeurt er als het opgegeven lettertype voor een tekstgedeelte ontbreekt op de doelmachine of -server?**

[Font substitution rules](/slides/nl/php-java/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden omlijnd: metriek, afbreking en breedte kunnen veranderen, wat van belang is voor precieze positionering.

**Kan ik een specifiek tekstgedeelte een eigen vultransparantie of een gradient geven, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/)-niveau kunnen verschillen van aangrenzende fragmenten.