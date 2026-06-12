---
title: Beheer tekstgedeelten in presentaties met JavaScript
linktitle: Tekstgedeelte
type: docs
weight: 70
url: /nl/nodejs-java/portion/
keywords:
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u tekstgedeelten in PowerPoint‑presentaties kunt beheren met JavaScript en Aspose.Slides voor Node.js via Java, waardoor de prestaties en maatwerk worden verbeterd."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment van tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de positie van een tekstfragment moet ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het gedrag van tekst op een gedetailleerder niveau wilt regelen.

Dit artikel laat zien hoe u de coördinaten van het begin van een gedeelte kunt ophalen met de `getCoordinates()`‑methode. Het belicht tevens veelvoorkomende scenario's met gedeelten, zoals het toepassen van een hyperlink op een enkel tekstfragment, het begrijpen van hoe opmaak wordt afgeleid via gedeelte, alinea, tekstframe en themastijl, en het afhandelen van gevallen waarin een opgegeven lettertype niet beschikbaar is. Daarnaast wordt opgemerkt dat tekstvulling, kleur en transparantie verschillend kunnen worden ingesteld voor individuele gedeelten binnen dezelfde alinea.

## **Coördinaten van de positie van een gedeelte**
[**getCoordinates()**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Portion#getCoordinates--) methode is toegevoegd aan de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/)‑klasse, waarmee de coördinaten van het begin van het gedeelte kunnen worden opgehaald.

```javascript
// Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // De context van de presentatie opnieuw vormgeven
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

## **FAQ**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt een [hyperlink toewijzen](/slides/nl/nodejs-java/manage-hyperlinks/) aan een individueel gedeelte; alleen dat fragment zal klikbaar zijn, niet de volledige alinea.

**Hoe werkt stijl‑erfelijkheid: wat overschrijft een Portion en wat wordt overgenomen van Paragraph/TextFrame?**

Eigenschappen op Portion‑niveau hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/), neemt de engine deze over van de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/); als deze daar ook niet is ingesteld, van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) of de [theme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/theme/) stijl.

**Wat gebeurt er als het opgegeven lettertype voor een Portion ontbreekt op de doelmachine/server?**

[Regels voor lettertypevervanging](/slides/nl/nodejs-java/font-selection-sequence/) zijn van toepassing. De tekst kan opnieuw worden omlijnd: metriek, afbreking en breedte kunnen wijzigen, wat van belang is voor nauwkeurige positionering.

**Kan ik een Portion‑specifieke tekstvulling, transparantie of gradient instellen onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, vulling en transparantie op het [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) niveau kunnen verschillen van aangrenzende fragmenten.