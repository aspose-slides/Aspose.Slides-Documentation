---
title: Hantera textdelar i presentationer med JavaScript
linktitle: Textdel
type: docs
weight: 70
url: /sv/nodejs-java/portion/
keywords:
- textdel
- textavsnitt
- textkoordinater
- textposition
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar textdelar i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js via Java, vilket förbättrar prestanda och anpassning."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text inom ett stycke och låter dig arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan portioner användas när du behöver hämta positionen för ett textfragment, tillämpa formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Denna artikel visar hur man får koordinaterna för början av en portion genom att använda metoden `getCoordinates()`. Den tar också upp vanliga scenarier relaterade till portioner, såsom att applicera en hyperlänk på ett enskilt textfragment, förstå hur formatering löser sig genom portion, stycke, textram och temaarv, samt hantera fall där ett specificerat teckensnitt inte är tillgängligt. Dessutom noteras att textfyllning, färg och genomskinlighet kan ställas in olika för enskilda portioner inom samma stycke.

## **Hämta positionskoordinater för portion**
[**getCoordinates()**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Portion#getCoordinates--) metoden har lagts till i klassen [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) som möjliggör att hämta koordinaterna för början av portionen.

```javascript
// Instansiera Presentation-klassen som representerar PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Omformar kontexten för presentationen
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag applicera en hyperlänk på endast en del av texten inom ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/nodejs-java/manage-hyperlinks/) till en enskild portion; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en Portion och vad tas från Paragraph/TextFrame?**

Egenskaper på portionsnivå har högsta prioritet. Om en egenskap inte är inställd på [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/), hämtar motorn den från [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/); om den inte är inställd där heller, från [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/theme/) stilen.

**Vad händer om det teckensnitt som specificerats för en Portion saknas på målmaskinen/servern?**

[Regler för teckensnittssubstitution](/slides/sv/nodejs-java/font-selection-sequence/) tillämpas. Texten kan flöda om: mått, avstavning och bredd kan ändras, vilket är viktigt för exakt positionering.

**Kan jag ställa in en portionsspecifik textfyllnadsgennomsiktighet eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och genomskinlighet på [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) nivå kan skilja sig från närliggande fragment.