---
title: Hämta styckesgränser från presentationer i JavaScript
linktitle: Stycke
type: docs
weight: 60
url: /sv/nodejs-java/paragraph/
keywords:
- styckesgränser
- textdelgränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i JavaScript med Aspose.Slides för Node.js för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man får gränser, storlek och koordinater för stycken och textdelar i Aspose.Slides. Den visar hur man hämtar ett stycks rektangel i ett `TextFrame` med `getRect()`, hur man får koordinater för stycke och del i ett tabellcells‑textframe, samt belyser viktiga detaljer som mätenheter, effekten av radbrytning på gränser, pixelomvandling och effektiva formatvärden för stycken.

## **Hämta koordinater för paragraf och del i TextFrame**
Med Aspose.Slides för Node.js via Java kan utvecklare nu hämta de rektangulära koordinaterna för paragraf i paragrafkollektionen i ett TextFrame. Det gör det också möjligt att få [koordinaterna för delen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion#getCoordinates--) i del‑kollektionen för ett stycke. I detta avsnitt demonstreras med ett exempel hur man får de rektangulära koordinaterna för ett stycke samt positionen för en del i ett stycke.

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

## **Hämta rektangulära koordinater för paragraf**
Genom att använda metoden [**getRect()**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Paragraph#getRect--) kan utvecklare få paragrafens gränsrektangel.

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

## **Hämta storlek på paragraf och del i textram i tabellcell**
För att få [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion) eller [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Paragraph) storlek och koordinater i en textram i en tabellcell kan du använda metoderna [Portion.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion#getRect--) och [Paragraph.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Paragraph#getRect--) .

Denna exempel‑kod demonstrerar den beskrivna operationen:

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

## **Vanliga frågor**

**I vilka enheter returneras koordinaterna för ett stycke och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning styckets gränser?**

Ja. Om [radbrytning](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/setwraptext/) är aktiverad i [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska gränser.

**Kan styckekoordinater på ett pålitligt sätt mappas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixlar = punkter × (DPI / 72). Resultatet beror på den DPI som valts för rendering/export.

**Hur får jag de ”effektiva” formatparametrarna för ett stycke med hänsyn till ärftlighet av stil?**

Använd datastrukturen för [effektiv styckeformat]( /slides/sv/nodejs-java/shape-effective-properties/ ); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.