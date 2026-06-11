---
title: Hämta styckegränser från presentationer på Android
linktitle: Stycke
type: docs
weight: 60
url: /sv/androidjava/paragraph/
keywords:
- styckegränser
- textdelgränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i Aspose.Slides för Android via Java för att optimera textpositionering i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man får gränserna, storleken och koordinaterna för stycken och textdelar i Aspose.Slides. Den visar hur man hämtar ett styckes rektangel i en `TextFrame` genom att använda `getRect()`, hur man får stycke‑ och del‑koordinater inuti en tabellcells textframe, och lyfter fram viktiga detaljer såsom måttenheter, effekten av textbrytning på gränser, pixelkonvertering och effektiva stycke‑formateringsvärden.

## **Hämta paragraf‑ och del‑koordinater i en TextFrame**
Genom att använda Aspose.Slides för Android via Java kan utvecklare nu hämta de rektangulära koordinaterna för ett stycke i styckeskollektionen i en TextFrame. Det gör det också möjligt att hämta [koordinaterna för del](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getCoordinates--) i delkollektionen för ett stycke. I det här ämnet kommer vi att visa med ett exempel hur man får de rektangulära koordinaterna för ett stycke samt positionen för del inom ett stycke.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Hämta rektangulära koordinater för ett stycke**
Genom att använda metoden [**getRect()**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IParagraph#getRect--) kan utvecklare hämta styckets avgränsningsrektangel.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta storleken på ett stycke och en del i en tabellcells TextFrame**
För att hämta [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Portion)‑ eller [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Paragraph)‑storlek och koordinater i en tabellcells textframe kan du använda metoderna [IPortion.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPortion#getRect--) och [IParagraph.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IParagraph#getRect--) .

Denna exempelkod demonstrerar den beskrivna operationen:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**I vilka enheter returneras koordinaterna för ett stycke och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning styckets avgränsningar?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) är aktiverad i [TextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket förändrar styckets faktiska avgränsningar.

**Kan styckekoordinater på ett tillförlitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixels = points × (DPI / 72). Resultatet beror på den DPI som valts för rendering/export.

**Hur får jag de "effektiva" styckeformateringsparametrarna med hänsyn till stil‑arv?**

Använd den [effektiva styckeformateringsdatstrukturen](/slides/sv/androidjava/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.