---
title: Alinea‑begrenzingen ophalen uit presentaties in Java
linktitle: Alinea‑begrenzingen
type: docs
weight: 43
url: /nl/java/paragraph-bounds/
keywords:
- alinea‑begrenzingen
- alinea‑coördinaat
- alinea‑grootte
- tekstframe
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u alinea‑begrenzingen kunt ophalen in Aspose.Slides voor Java om de positionering van tekst in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de begrenzingen, grootte en coördinaten van alinea's in Aspose.Slides kunt ophalen. Het toont hoe u een alinea‑rechthoek kunt ophalen vanuit een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) met behulp van [IParagraph.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IParagraph#getRect--), hoe u alinea‑coördinaten binnen een tabelcel‑tekstframe kunt krijgen, en benadrukt belangrijke details zoals meeteenheden, het effect van tekstomloop op de begrenzingen, pixelconversie, en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea ophalen**

Gebruik [IParagraph.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IParagraph#getRect--) om de omvattende rechthoek van een alinea op te halen.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **De grootte van een alinea binnen een tabelcel‑tekstframe ophalen**

Om de grootte en coördinaten van een [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) in een tabelcel‑tekstframe op te halen, gebruikt u [IParagraph.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IParagraph#getRect--). De geretourneerde rechthoek is relatief ten opzichte van het tabelcel‑tekstframe, dus voeg de tabelpositie en celoffset toe wanneer u coördinaten op dia‑niveau nodig heeft.

Het volgende voorbeeld haalt de begrenzingen van een alinea binnen een tabelcel op en tekent rechthoeken op de dia om die begrenzingen te visualiseren:

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

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**In welke eenheden worden alinea‑coördinaten gemeten?**

Ze worden gemeten in points, waarbij 1 inch gelijk is aan 72 points. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomloop invloed op de begrenzingen van een alinea?**

Ja. Als [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) is ingeschakeld voor de [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, wat de werkelijke begrenzingen van de alinea wijzigt.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met deze formule: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor weergave of export.

**Hoe krijg ik de "effectieve" alinea‑opmaakparameters, rekening houdend met stijl‑overerving?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/java/shape-effective-properties/); deze retourneert de definitieve samengevoegde waarden voor inspringingen, regelafstand, omloop, RTL en meer.