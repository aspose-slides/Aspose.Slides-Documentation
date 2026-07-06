---
title: Alinea-grenzen ophalen uit presentaties op Android
linktitle: Alinea-grenzen
type: docs
weight: 43
url: /nl/androidjava/paragraph-bounds/
keywords:
- alinea-grenzen
- alinea-coördinaat
- alinea-grootte
- tekstframe
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u alinea-grenzen kunt ophalen in Aspose.Slides voor Android via Java om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's in Aspose.Slides kunt verkrijgen. Het toont hoe u een alinearechthoek kunt ophalen vanuit een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) door gebruik te maken van [IParagraph.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IParagraph#getRect--), hoe u de coördinaten van een alinea binnen een tabelcel‑tekstframe kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea ophalen**

Gebruik [IParagraph.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IParagraph#getRect--) om de begrenzende rechthoek van een alinea op te halen.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **De grootte van een alinea in een tabelcel‑tekstframe ophalen**

Om de grootte en coördinaten van een [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) in een tabelcel‑tekstframe te verkrijgen, gebruikt u [IParagraph.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IParagraph#getRect--). De geretourneerde rechthoek is relatief ten opzichte van het tabelcel‑tekstframe, dus voeg de tabelpositie en celoffset toe wanneer u slide‑niveau coördinaten nodig hebt.

Het onderstaande voorbeeld haalt de grenzen van een alinea binnen een tabelcel op en tekent rechthoeken op de dia om die grenzen te visualiseren:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**In welke eenheden worden de coördinaten van een alinea gemeten?**

Ze worden gemeten in punten, waarbij 1 inch gelijk is aan 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft tekstomloop invloed op de grenzen van een alinea?**

Ja. Als [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) is ingeschakeld voor het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/), wordt de tekst afgebroken zodat deze binnen de breedte van het gebied past, wat de werkelijke grenzen van de alinea wijzigt.

**Kunnen de coördinaten van een alinea betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met deze formule: pixels = punten × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor weergave of export.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, met inachtneming van stijl‑overerving?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/androidjava/shape-effective-properties/); deze retourneert de uiteindelijke geconsolideerde waarden voor inspringingen, afstand, omloop, RTL en meer.