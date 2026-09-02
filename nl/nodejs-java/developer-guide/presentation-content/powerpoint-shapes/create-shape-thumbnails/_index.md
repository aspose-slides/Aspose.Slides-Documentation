---
title: Miniaturen van presentatiesvormen maken in JavaScript
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/nodejs-java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met JavaScript en Aspose.Slides voor Node.js – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides wordt gebruikt om presentatiedocumenten te maken waarbij elke pagina een dia is. Deze dia's kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen apart bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides u bij het genereren van miniatuurafbeeldingen van de dia‑vormen. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.

Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een vormminiatuur binnen een dia genereren.
- Een vormminiatuur voor een dia‑vorm met gebruikersgedefinieerde afmetingen genereren.
- Een vormminiatuur binnen de grenzen van de weergave van een vorm genereren.

## **Vormminiaturen genereren vanuit dia's**

Om een vormminiatuur van een willekeurige dia te genereren met Aspose.Slides voor Node.js via Java, doet u het volgende:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse aan.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de vormminiatuurafbeelding op](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getImage--) van de referentie‑dia op met de standaard schaal.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

```javascript
// Instantieer een Presentation-klasse die het presentatie-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Sla de afbeelding op schijf op in PNG-formaat
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

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse aan.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de vormminiatuurafbeelding op](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) van de referentie‑dia met door de gebruiker gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

```javascript
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Sla de afbeelding op schijf in PNG-formaat
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

Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de weergave van een vorm. Hierbij worden alle vorm‑effecten meegewogen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de grenzen van zijn weergave te genereren, doet u het volgende:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse aan.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding van de referentie‑dia op met de vormgrenzen als weergave.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

```javascript
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Sla de afbeelding op schijf in PNG-formaat
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

## **De werkelijke visuele grenzen van een vorm ophalen**

De frame‑eigenschappen van een [Vorm](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)—de `getX()`, `getY()`, `getWidth()` en `getHeight()`‑methoden—gebruiken het rechthoekige gebied dat in het presentatiemodel is opgeslagen. De inhoud die daadwerkelijk wordt gerenderd kan buiten dat frame uitsteken of een ander rechthoekig gebied innemen. Rotatie, omtreklijnen, pijlpuntjes, tekstlayout en -overloop, gegenereerde SmartArt‑geometrie en andere rendereffecten kunnen allemaal het bezette gebied wijzigen.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getVisualBounds--) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)‑object in dia‑coördinaten. Het geretourneerde rechthoek wordt niet bijgesneden op de dia, zodat de coördinaten negatief kunnen zijn wanneer de inhoud buiten de oorsprong van de dia reikt.

Het volgende voorbeeld haalt de frame‑ en visuele grenzen op en vergelijkt ze:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Hetzelfde rechthoek kan worden gebruikt om naburige vormen uit te lijnen aan de linker-, rechter-, boven‑ of onderkant; om voldoende ruimte te reserveren in een gegenereerde lay-out; of om inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, gedraaid vormen en groep‑vormen, waar het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getVisualBounds--) wanneer u coördinaten nodig heeft voor lay‑out of validatie en geen bitmap nodig heeft. Gebruik [Shape.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage--) wanneer u de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapethumbnailbounds/), bepaalt `ShapeThumbnailBounds.Shape` de afbeelding op basis van de vormgrenzen, inclusief omtrekinstellingen, terwijl `ShapeThumbnailBounds.Appearance` de afbeelding baseert op de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getVisualBounds--) alleen het berekende rechthoek en snijdt het niet bij de dia.

## **FAQ**

**Welke afbeeldingformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/), en andere. Vormen kunnen ook [geëxporteerd worden als vector‑SVG](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/nodejs-java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm als verborgen is gemarkeerd? Wordt er toch een miniatuur gerenderd?**

Een verborgen vorm blijft deel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt alleen de weergave in de diavoorstelling maar verhindert niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groeperende vormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Vorm](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/), en [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de benodigde lettertypen leveren](/slides/nl/nodejs-java/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/nodejs-java/font-substitution/)) om ongewenste fallback‑opties en tekst‑herindeling te voorkomen.