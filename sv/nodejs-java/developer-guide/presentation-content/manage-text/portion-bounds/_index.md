---
title: Hämta gränser för textavsnitt från presentationer i JavaScript
linktitle: Avsnittsgränser
type: docs
weight: 47
url: /sv/nodejs-java/portion-bounds/
keywords:
- gränser för textavsnitt
- textavsnitt
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textavsnitt i PowerPoint-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Ett textavsnitt representerar ett specifikt fragment av text i ett stycke och gör det möjligt att arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan avsnitt användas när du behöver hämta gränserna för ett textfragment, tillämpa formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Denna artikel visar hur du hämtar den omgivande rektangeln för ett avsnitt med [Portion.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/getrect/). Den visar också hur du får koordinaterna för början av ett avsnitt med [Portion.getCoordinates](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/getcoordinates/). Dessutom belyser den vanliga scenarier relaterade till avsnitt, såsom att tillämpa en hyperlänk på ett enskilt textfragment, förstå hur formatering löser sig genom avsnitt, stycke, textruta och temaarv, samt hantera fall där ett specificerat teckensnitt saknas.

## **Hämta gränser för ett textavsnitt**

Använd [Portion.getRect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/getrect/) för att hämta den omgivande rektangeln för ett textavsnitt:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Hämta koordinater för ett textavsnitt**

Använd [Portion.getCoordinates](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/getcoordinates/) för att hämta koordinaterna för början av ett textavsnitt:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag tillämpa en hyperlänk på endast en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/nodejs-java/manage-hyperlinks/) till ett enskilt avsnitt; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad överskriver ett avsnitt, och vad tas från ett stycke eller en textruta?**

Egenskaper på avsnittsnivå har högst prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/), hämtar Aspose.Slides den från [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/). Om den inte är angiven där heller, använder Aspose.Slides stil från [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/theme/)-stilen.

**Vad händer om det teckensnitt som specificerats för ett avsnitt saknas på målmaskinen eller servern?**

[Font substitution rules](/slides/sv/nodejs-java/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, avstavning och bredd kan förändras, vilket är viktigt för exakt placering.

**Kan jag ställa in avsnittsspecifik fyllnadstransparens eller en gradient för text oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)‑nivå kan skilja sig från närliggande fragment.