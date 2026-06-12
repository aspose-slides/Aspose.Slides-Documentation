---
title: Paragraafgrenzen ophalen uit presentaties op Android
linktitle: Paragraaf
type: docs
weight: 60
url: /nl/androidjava/paragraph/
keywords:
- paragraafgrenzen
- tekstgedeeltegrenzen
- paragraafcoördinaten
- gedeeltecoördinaten
- paragraafgrootte
- tekstgedeeltegrootte
- tekstframe
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u de grenzen van alinea's en tekstgedeelten kunt ophalen in Aspose.Slides voor Android via Java om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's en tekstgedeelten in Aspose.Slides kunt verkrijgen. Het laat zien hoe u een rechthoek van een alinea in een `TextFrame` kunt ophalen met `getRect()`, hoe u de coördinaten van alinea's en gedeelten binnen een tekstframe van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomslag op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Coördinaten van alinea en gedeelte ophalen in een TextFrame**
Met Aspose.Slides voor Android via Java kunnen ontwikkelaars nu de rechthoekige coördinaten van een alinea ophalen binnen de alinea‑collectie van een TextFrame. Het maakt ook mogelijk om [de coördinaten van een gedeelte](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getCoordinates--) op te halen binnen de gedeelte‑collectie van een alinea. In dit onderwerp laten we, aan de hand van een voorbeeld, zien hoe u de rechthoekige coördinaten van een alinea kunt verkrijgen, samen met de positie van het gedeelte binnen die alinea.

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
Met de [**getRect()**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IParagraph#getRect--) methode kunnen ontwikkelaars de begrenzingsrechthoek van een alinea ophalen.

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

## **De grootte van een alinea en gedeelte binnen een TextFrame in een tabelcel ophalen**
Om de grootte en coördinaten van een [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Portion) of [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Paragraph) in een tekstframe van een tabelcel op te halen, kunt u de methoden [IPortion.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPortion#getRect--) en [IParagraph.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IParagraph#getRect--) gebruiken.

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

**In welke meeteenheden worden de coördinaten van een alinea en tekstgedeelten geretourneerd?**

In punten, waarbij 1 inch = 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomslag invloed op de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) is ingeschakeld in het [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de feitelijke grenzen van de alinea veranderen.

**Kunnen alinea-coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor rendering/export.

**Hoe haal ik de “effectieve” alinea‑opmaakparameters op, rekening houdend met het erven van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/androidjava/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden terug voor inspringingen, regelafstand, omhulling, RTL en meer.