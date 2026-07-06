---
title: Hämta styckegränser från presentationer i PHP
linktitle: Styckegränser
type: docs
weight: 43
url: /sv/php-java/paragraph-bounds/
keywords:
- styckegränser
- styckekoordinat
- styckestorlek
- textram
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: Lär dig hur du hämtar styckegränser i Aspose.Slides för PHP via Java för att optimera textplacering i PowerPoint-presentationer.
---
## **Översikt**

Denna artikel förklarar hur man får gränser, storlek och koordinater för stycken i Aspose.Slides. Den visar hur man hämtar ett stycke‑rektangel från en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) med hjälp av [Paragraph::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/getrect/), hur man får styckekoordinater i en tabellcells TextFrame, och lyfter fram viktiga detaljer såsom mätenheter, hur radbrytning påverkar gränser, pixelkonvertering och effektiva styckeformateringsvärden.

## **Hämta rektangulära koordinater för ett stycke**

Använd [Paragraph::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/getrect/) för att få styckets omgivande rektangel.

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

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att få storlek och koordinater för ett [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) i en tabellcells TextFrame, använd [Paragraph::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/getrect/). Den returnerade rektangeln är relativ till tabellcellens TextFrame, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckets gränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

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

**I vilka enheter mäts koordinaterna för ett stycke?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett styckes avgränsningar?**

Ja. Om [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setwraptext/) är aktiverat för [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska avgränsningar.

**Kan styckekoordinater på ett tillförlitligt sätt omvandlas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de "effektiva" styckeformateringsparametrarna med hänsyn till stilärv?**

Använd den [effektiva styckeformateringsdatastrukturen](/slides/sv/php-java/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.