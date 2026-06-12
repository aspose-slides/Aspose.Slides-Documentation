---
title: Alinea-grenzen ophalen uit presentaties in Java
linktitle: Alinea
type: docs
weight: 60
url: /nl/java/paragraph/
keywords:
- alinea-grenzen
- tekstgedeelte-grenzen
- alinea-coördinaat
- gedeelte-coördinaat
- alinea-grootte
- tekstgedeelte-grootte
- tekstframe
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u alinea- en tekstgedeelte-grenzen kunt ophalen in Aspose.Slides for Java om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's en tekstgedeelten in Aspose.Slides kunt ophalen. Het laat zien hoe u de rechthoek van een alinea in een `TextFrame` kunt ophalen met `getRect()`, hoe u de coördinaten van alinea’s en gedeelten binnen een tekstframe van een tabelcel kunt verkrijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomslag op de grenzen, pixelconversie en de effectieve alinea‑opmaakwaarden.

## **Alinea‑ en Gedeelte‑coördinaten ophalen in een TextFrame**
Met Aspose.Slides for Java kunnen ontwikkelaars nu de rechthoekige coördinaten van een alinea binnen de alinea‑collectie van een TextFrame ophalen. Het maakt ook mogelijk om [the coordinates of portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getCoordinates--) binnen de gedeelte‑collectie van een alinea te verkrijgen. In dit onderwerp laten we, aan de hand van een voorbeeld, zien hoe u de rechthoekige coördinaten van een alinea kunt ophalen samen met de positie van een gedeelte binnen die alinea.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Rechthoekige coördinaten van een alinea ophalen**
Met de [**getRect()**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IParagraph#getRect--)‑methode kunnen ontwikkelaars de rechthoek met de grenzen van een alinea verkrijgen.

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

## **De grootte van een alinea en gedeelte binnen een TextFrame van een tabelcel ophalen**
Om de grootte en coördinaten van een [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Portion) of [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Paragraph) in een tekstframe van een tabelcel op te halen, kunt u de methoden [IPortion.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPortion#getRect--) en [IParagraph.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IParagraph#getRect--) gebruiken.

Deze voorbeeldcode toont de beschreven bewerking:

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

**In welke eenheden worden de coördinaten van een alinea en tekstgedeelten gemeten?**

In punten, waarbij 1 inch = 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomslag invloed op de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#setWrapText-byte-) is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/), wordt de tekst afgebroken om te passen binnen de breedte van het gebied, waardoor de werkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die gekozen wordt voor het renderen/exporteren.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, rekening houdend met erfelijke stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/java/shape-effective-properties/); deze retourneert de uiteindelijke geconsolideerde waarden voor inspringingen, spatiëring, omwikkeling, RTL en meer.