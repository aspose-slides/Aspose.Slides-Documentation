---
title: Tekstgedeeltegrenzen ophalen uit presentaties in JavaScript
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/nodejs-java/portion-bounds/
keywords:
- grenzen van tekstgedeelte
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u de grenzen van tekstgedeelten kunt ophalen in PowerPoint‑presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen delen worden gebruikt wanneer u de grenzen van een tekstfragment moet ophalen, alleen een deel van een alinea moet opmaken, of het tekstgedrag op een gedetailleerder niveau wilt beheersen. Dit artikel laat zien hoe u de omhullende rechthoek van een gedeelte kunt ophalen met behulp van [Portion.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/getrect/). Het toont ook hoe u de coördinaten van het begin van een gedeelte kunt verkrijgen met [Portion.getCoordinates](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/getcoordinates/). Bovendien belicht het veelvoorkomende scenario’s met betrekking tot gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, begrijpen hoe opmaak wordt bepaald via gedeelte, alinea, tekstvak en thema‑overerving, en omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Grenzen van een Tekstgedeelte**

Gebruik [Portion.getRect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/getrect/) om de omhullende rechthoek van een tekstgedeelte op te halen:

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

## **Coördinaten van een Tekstgedeelte**

Gebruik [Portion.getCoordinates](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/getcoordinates/) om de coördinaten van het begin van een tekstgedeelte op te halen:

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

**Kan ik een hyperlink alleen op een deel van de tekst binnen één alinea toepassen?**

Ja, u kunt een [hyperlink toewijzen](/slides/nl/nodejs-java/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de volledige alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een gedeelte, en wat wordt overgenomen vanuit een alinea of een tekstvak?**

Eigenschappen op gedeelte‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/), neemt Aspose.Slides deze over van de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/). Als deze daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) of [theme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/theme/).

**Wat gebeurt er als het voor een gedeelte opgegeven lettertype ontbreekt op de doelcomputer of -server?**

[Lettertype‑vervangingsregels](/slides/nl/nodejs-java/font-selection-sequence/) worden toegepast. De tekst kan opnieuw vloeien: metriek, afbreking en breedte kunnen wijzigen, wat belangrijk is voor nauwkeurige positionering.

**Kan ik transparantie of een verloop van de tekstvulling specifiek voor een gedeelte instellen, onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) niveau kunnen verschillen van aangrenzende fragmenten.