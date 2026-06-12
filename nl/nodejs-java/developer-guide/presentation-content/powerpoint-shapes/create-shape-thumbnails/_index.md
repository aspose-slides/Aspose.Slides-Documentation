---
title: Miniaturen van presentatievormen maken in JavaScript
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/nodejs-java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormweergave
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met JavaScript en Aspose.Slides voor Node.js – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Introductie**

Aspose.Slides wordt gebruikt om presentatiebestanden te maken waarbij elke pagina een dia is. Deze dia’s kunnen bekeken worden door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen apart bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides u bij het genereren van miniatuurafbeeldingen van de dia‑vormen. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.  
Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een vormminiatuur genereren binnen een dia.  
- Een vormminiatuur genereren voor een dia‑vorm met door de gebruiker opgegeven afmetingen.  
- Een vormminiatuur genereren binnen de grenzen van de weergave van een vorm.

## **Vormminiaturen genereren vanuit dia's**

Om een vormminiatuur van een willekeurige dia te genereren met Aspose.Slides voor Node.js via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van diens ID of index.  
1. [Haal de vormminiatuur‑afbeelding](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getImage--) van de referentie‑dia op de standaard schaal.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een vormminiatuur van een dia kunt genereren:

```javascript
// Instantieer een Presentation‑klasse die het presentatie‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Sla de afbeelding op de schijf op in PNG‑formaat
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vormminiaturen genereren met door de gebruiker gedefinieerde schaalfactor**

Om de vormminiatuur van een dia te genereren met Aspose.Slides voor Node.js via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van diens ID of index.  
1. [Haal de vormminiatuur‑afbeelding](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) van de referentie‑dia met door de gebruiker opgegeven afmetingen.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een vormminiatuur kunt genereren op basis van een gedefinieerde schaalfactor:

```javascript
// Instantieer een Presentation‑klasse die het presentatie‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Sla de afbeelding op de schijf op in PNG‑formaat
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vormminiatuur genereren binnen de grenzen**

Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vorm‑effecten in overweging genomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de weergave‑grens te genereren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van diens ID of index.  
1. Haal de miniatuurafbeelding van de referentie‑dia op met de vormgrenzen als weergave.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode is gebaseerd op de bovenstaande stappen:

```javascript
// Instantieer een Presentation-klasse die het presentatie-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Sla de afbeelding op de schijf op in PNG-formaat
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/nodejs-java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als miniatuur?**

Een verborgen vorm blijft onderdeel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt alleen de weergave van de diavoorstelling, maar verhindert niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, diagrammen, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de vereiste lettertypen leveren](/slides/nl/nodejs-java/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/nodejs-java/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑herindeling te voorkomen.