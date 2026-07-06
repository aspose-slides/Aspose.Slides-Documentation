---
title: Haal alinea‑grenzen op van presentaties in JavaScript
linktitle: Alinea‑grenzen
type: docs
weight: 43
url: /nl/nodejs-java/paragraph-bounds/
keywords:
- alinea‑grenzen
- alinea‑coördinaat
- alinea‑grootte
- tekstvak
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u alinea‑grenzen kunt ophalen in Aspose.Slides voor Node.js via Java om de tekstpositionering in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea’s in Aspose.Slides kunt verkrijgen. Het laat zien hoe u een alinea‑rechthoek kunt ophalen uit een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) met behulp van [Paragraph.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/getrect/), hoe u alinea‑coördinaten binnen een tekstvak van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea**

Gebruik [Paragraph.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/getrect/) om de omvattende rechthoek van een alinea op te halen.

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

## **Grootte van een alinea binnen een TextFrame van een tabelcel ophalen**

Om de grootte en coördinaten van een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) in een tekstvak van een tabelcel te krijgen, gebruikt u [Paragraph.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/getrect/). De geretourneerde rechthoek is relatief ten opzichte van het tekstvak van de tabelcel, dus voeg de tabelpositie en cel‑offset toe wanneer u coördinaten op dia‑niveau nodig hebt.

Het volgende voorbeeld haalt de grenzen van een alinea binnen een tabelcel op en tekent rechthoeken op de dia om die grenzen te visualiseren:

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

## **Veelgestelde vragen**

**In welke eenheden worden de coördinaten van een alinea gemeten?**

Ze worden gemeten in punten, waarbij 1 inch overeenkomt met 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de grenzen van een alinea?**

Ja. Als [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/setwraptext/) is ingeschakeld voor het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/), wordt de tekst afgebroken om in de breedte van het gebied te passen, wat de werkelijke grenzen van de alinea wijzigt.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met deze formule: pixels = punten x (DPI / 72). Het resultaat hangt af van de DPI die gekozen is voor weergave of export.

**Hoe krijg ik de "effectieve" alinea‑opmaakparameters, rekening houdend met erfelijkheid van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/nodejs-java/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden voor inspringingen, afstand, omloop, RTL en meer.