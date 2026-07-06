---
title: Hämta styckesgränser från presentationer i JavaScript
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/nodejs-java/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckesstorlek
- textram
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för Node.js via Java för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du hämtar gränser, storlek och koordinater för stycken i Aspose.Slides. Den visar hur du hämtar en styckesrektangel från en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) genom att använda [Paragraph.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/getrect/), hur du får styckeskoordinater i en tabellcells textram och belyser viktiga detaljer såsom mätningsenheter, hur textomslag påverkar gränser, pixelkonvertering och effektiva styckeformateringsvärden.

## **Hämta rektangulära koordinater för ett stycke**

Använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/getrect/) för att hämta den omgivande rektangeln för ett stycke.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att hämta storleken och koordinaterna för ett [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) i en tabellcells textram, använd [Paragraph.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/getrect/). Den returnerade rektangeln är relativ till tabellcellens textram, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckesgränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**I vilka enheter mäts styckeskoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar ordbrytning ett styckes gränser?**

Ja. Om [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/setwraptext/) är aktiverad för [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan styckeskoordinater på ett tillförlitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de "effektiva" styckeformateringsparametrarna, med beaktande av stilarv?**

Använd [effective paragraph formatting data structure](/slides/sv/nodejs-java/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, omslag, RTL och mer.