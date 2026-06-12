---
title: Alinea‑grenzen ophalen uit presentaties in JavaScript
linktitle: Alinea
type: docs
weight: 60
url: /nl/nodejs-java/paragraph/
keywords:
- alinea‑grenzen
- tekstgedeelte‑grenzen
- alinea‑coördinaat
- gedeelte‑coördinaat
- alinea‑grootte
- tekstgedeelte‑grootte
- tekstframe
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u alinea‑ en tekstgedeelte‑grenzen kunt ophalen in JavaScript met Aspose.Slides voor Node.js om de tekstplaatsing in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, de grootte en de coördinaten van alinea's en tekstgedeelten in Aspose.Slides kunt verkrijgen. Het toont hoe u de rechthoek van een alinea in een `TextFrame` kunt ophalen met `getRect()`, hoe u de coördinaten van alinea's en gedeelten binnen een tekstframe in een tabelcel kunt krijgen, en benadrukt belangrijke details zoals meeteenheden, de invloed van tekstterugloop op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Coördinaten van alinea en gedeelte in TextFrame ophalen**
Met Aspose.Slides voor Node.js via Java kunnen ontwikkelaars nu de rechthoekige coördinaten van een Paragraph binnen de alinea‑verzameling van een TextFrame ophalen. Het stelt u ook in staat om [de coördinaten van het gedeelte](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion#getCoordinates--) op te halen binnen de gedeelte‑verzameling van een alinea. In dit onderwerp laten we, met behulp van een voorbeeld, zien hoe u de rechthoekige coördinaten van een alinea kunt krijgen samen met de positie van het gedeelte binnen die alinea.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Rechthoekige coördinaten van alinea ophalen**
Met de [**getRect()**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Paragraph#getRect--) methode kunnen ontwikkelaars de begrenzingsrechthoek van een alinea ophalen.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grootte van alinea en gedeelte binnen tekstframe van tabelcel ophalen**
Om de grootte en coördinaten van een [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion) of [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Paragraph) in een tekstframe van een tabelcel te verkrijgen, kunt u de methoden [Portion.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion#getRect--) en [Paragraph.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Paragraph#getRect--) gebruiken.

Deze voorbeeldcode toont de beschreven bewerking:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**In welke eenheden worden de coördinaten van een alinea en tekstgedeelten geretourneerd?**

In punten, waarbij 1 inch = 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Beïnvloedt woordterugloop de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/setwraptext/) is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/), wordt de tekst afgebroken om binnen de breedte van het gebied te passen, waardoor de werkelijke grenzen van de alinea wijzigen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met: pixels = points × (DPI / 72). Het resultaat hangt af van de DPI die is gekozen voor het renderen/exporteren.

**Hoe haal ik de "effectieve" alinea‑opmaakparameters op, rekening houdend met stijl‑overerving?**

Gebruik de [effectieve alinea‑opmaakdatastructuur](/slides/nl/nodejs-java/shape-effective-properties/); deze retourneert de eindgeconsolideerde waarden voor inspringingen, spatiëring, terugloop, RTL en meer.