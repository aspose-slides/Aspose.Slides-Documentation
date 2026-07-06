---
title: Hämta styckegränser från presentationer på Android
linktitle: Styckegränser
type: docs
weight: 43
url: /sv/androidjava/paragraph-bounds/
keywords:
- styckegränser
- styckekoordinat
- styckestorlek
- textram
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar styckegränser i Aspose.Slides för Android via Java för att optimera textpositionering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur du får gränserna, storleken och koordinaterna för stycken i Aspose.Slides. Den visar hur du hämtar en styckerektangel från ett [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) genom att använda [IParagraph.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IParagraph#getRect--), hur du får styckekoordinater inuti en tabellcells textramhäft, och framhäver viktiga detaljer såsom mätenheter, effekten av radbrytning på gränser, pixelkonvertering och effektiva styckeformateringsvärden.

## **Hämta rektangulära koordinater för ett stycke**

Använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IParagraph#getRect--) för att få den omgivande rektangeln för ett stycke.

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

## **Få storleken på ett stycke i en tabellcells TextFrame**

För att få storlek och koordinater för ett [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/) i en tabellcells TextFrame, använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IParagraph#getRect--). Den returnerade rektangeln är relativ till tabellcellens TextFrame, så lägg till tabellens position och cellens förskjutning när du behöver koordinater på bildnivå.

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

## **FAQ**

**I vilka enheter mäts styckekoordinater?**

De mäts i punkter, där 1 tum motsvarar 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett styckes gränser?**

Ja. Om [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) är aktiverad för [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan styckekoordinater på ett tillförlitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med formeln: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering eller export.

**Hur får jag de "effektiva" styckeformateringsparametrarna med hänsyn till ärvning av stil?**

Använd den [effective paragraph formatting data structure](/slides/sv/androidjava/shape-effective-properties/); den returnerar de slutgiltiga sammanslagna värdena för indrag, avstånd, radbrytning, RTL och mer.