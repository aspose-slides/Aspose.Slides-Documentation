---
title: Hämta styckegränser från presentationer i Java
linktitle: Stycke
type: docs
weight: 60
url: /sv/java/paragraph/
keywords:
- styckegränser
- textdelens gränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelens storlek
- textram
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i Aspose.Slides för Java för att optimera textpositionering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränser, storlek och koordinater för stycken och textdelar i Aspose.Slides. Den visar hur man hämtar ett styckes rektangel i en `TextFrame` med `getRect()`, hur man får stycke- och delkoordinater inuti en tabellcells textram, och belyser viktiga detaljer såsom mätenheter, hur textomslag påverkar gränser, pixelkonvertering och effektiva formateringsvärden för stycke.

## **Hämta stycke- och delkoordinater i en TextFrame**
Med Aspose.Slides för Java kan utvecklare nu få de rektangulära koordinaterna för ett stycke i styckeskollektionen i en TextFrame. Det möjliggör även att hämta [koordinaterna för del](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getCoordinates--) i delkollektionen för ett stycke. I detta avsnitt demonstrerar vi med ett exempel hur man får de rektangulära koordinaterna för ett stycke samt positionen för en del i stycket.

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
Med metoden [**getRect()**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IParagraph#getRect--) kan utvecklare få styckets gränsrektangel.

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

## **Hämta storleken för ett stycke och del i en tabellcells TextFrame**

För att hämta [Portion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Portion) eller [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Paragraph) storlek och koordinater i en tabellcells textram kan du använda metoderna [IPortion.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPortion#getRect--) och [IParagraph.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IParagraph#getRect--).

Detta exempel visar den beskrivna operationen:

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

**Påverkar ordomslag ett styckes gränser?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setWrapText-byte-) är aktiverat i [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan stycke‑koordinater på ett pålitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixels = points × (DPI / 72). Resultatet beror på DPI som valts för rendering/export.

**Hur får jag de "effektiva" stycke‑formateringsparametrarna med hänsyn till stilarv?**

Använd den [effektiva stycke‑formateringsdatastrukturen](/slides/sv/java/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, omslag, RTL och mer.