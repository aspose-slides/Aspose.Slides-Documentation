---
title: Verkrijg alinea‑begrenzingen uit presentaties in PHP
linktitle: Alinea‑begrenzingen
type: docs
weight: 43
url: /nl/php-java/paragraph-bounds/
keywords:
- alinea‑begrenzingen
- alinea‑coördinaat
- alinea‑grootte
- tekstkader
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u alinea‑begrenzingen kunt ophalen in Aspose.Slides voor PHP via Java om de tekstpositionering in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de begrenzingen, grootte en coördinaten van alinea's in Aspose.Slides kunt ophalen. Het laat zien hoe u een alinea‑rechthoek kunt verkrijgen uit een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) met behulp van [Paragraph::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/getrect/), hoe u alinea‑coördinaten binnen een tekstframe van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op de begrenzingen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea ophalen**

Gebruik [Paragraph::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/getrect/) om de begrenzende rechthoek van een alinea op te halen.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Grootte van een alinea binnen een tekstframe van een tabelcel ophalen**

Om de grootte en coördinaten van een [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) in een tekstframe van een tabelcel te verkrijgen, gebruikt u [Paragraph::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/getrect/). De geretourneerde rechthoek is relatief ten opzichte van het tekstframe van de tabelcel, dus voeg de tabelpositie en celoffset toe wanneer u coördinaten op slide‑niveau nodig heeft.

Het volgende voorbeeld haalt de begrenzingen van een alinea binnen een tabelcel op en tekent rechthoeken op de slide om die begrenzingen te visualiseren:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**In welke eenheden worden alinea‑coördinaten gemeten?**

Ze worden gemeten in points, waarbij 1 inch gelijk is aan 72 points. Dit geldt voor alle coördinaten en afmetingen op de slide.

**Heeft woordomloop invloed op de begrenzingen van een alinea?**

Ja. Als [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setwraptext/) is ingeschakeld voor de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de werkelijke begrenzingen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met deze formule: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die gekozen is voor het renderen of exporteren.

**Hoe krijg ik de "effectieve" alinea‑opmaakparameters, rekening houdend met overerving van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/php-java/shape-effective-properties/); deze retourneert de uiteindelijke geconsolideerde waarden voor inspringingen, regelafstand, omloop, RTL en meer.