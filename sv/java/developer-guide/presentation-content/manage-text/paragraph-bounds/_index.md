---
title: Hämta styckesgränser från presentationer i Java
linktitle: Styckesgränser
type: docs
weight: 43
url: /sv/java/paragraph-bounds/
keywords:
- styckesgränser
- styckeskoordinat
- styckesstorlek
- textram
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar styckesgränser i Aspose.Slides för Java för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man får gränser, storlek och koordinater för stycken i Aspose.Slides. Den visar hur man hämtar ett styckesrektangel från en [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) genom att använda [IParagraph.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IParagraph#getRect--), hur man får styckeskoordinater i en tabellcells textram, och lyfter fram viktiga detaljer såsom mätenheter, effekten av textomslag på gränser, pixelkonvertering och effektiva formateringsvärden för stycket.

## **Hämta rektangulära koordinater för ett stycke**

Använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IParagraph#getRect--) för att hämta den omgivande rektangeln för ett stycke.

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

## **Hämta storleken på ett stycke i en tabellcells TextFrame**

För att få storlek och koordinater för ett [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/) i en tabellcells textram, använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IParagraph#getRect--). Den returnerade rektangeln är relativ till tabellcellens textram, så lägg till tabellens position och cellens offset när du behöver koordinater på bildnivå.

Följande exempel hämtar styckets gränser i en tabellcell och ritar rektanglar på bilden för att visualisera dessa gränser:

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

**I vilka enheter mäts styckekoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar ordomslag styckets gränser?**

Ja. Om [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) är aktiverad för [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan styckekoordinater på ett pålitligt sätt omvandlas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de ”effektiva” formateringsparametrena för ett stycke, med tanke på stilarv?**

Använd den [effektiva styckeformateringsdatastrukturen](/slides/sv/java/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, omslag, RTL och mer.