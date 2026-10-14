---
title: PowerPoint‑slides converteren naar PNG in JavaScript
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- slide naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint‑presentaties snel naar PNG‑afbeeldingen van hoge kwaliteit in JavaScript met Aspose.Slides voor Node.js, en zorg voor nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt converteren naar PNG‑afbeeldingen met Aspose.Slides voor Node.js via Java. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke slide renderen en deze opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden tonen het renderen op de standaardschaal, het vergroten van de schaal, het specificeren van de uitvoerafmetingen in pixels, en het kiezen van een gradientrenderingsstijl.

## **PowerPoint converteren naar PNG**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) klasse en krijg toegang tot de slides via de [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) collectie. Het voorbeeld rendert elke slide met [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) zonder parameters om een miniatuur te maken. Vervolgens wordt [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) aangeroepen met [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) om elke gerenderde slide op te slaan als een PNG‑afbeelding.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
De parameterloze [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) overload rendert op een schaal van 0.2. Bijvoorbeeld, een slide van 720 × 540 punten produceert een miniatuur van 144 × 108 pixels. Om de uitvoerafmetingen te beheersen, gebruik de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder getoond.
{{% /alert %}}

## **PowerPoint converteren naar PNG met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) om de gerenderde afmetingen te bepalen. In dit voorbeeld zijn beide factoren 2, waardoor een slide van 720 × 540 punten een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de slide. Elke afbeelding wordt opgeslagen in PNG‑formaat met [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint converteren naar PNG met aangepaste grootte**

Om de uitvoerafmetingen in pixels op te geven, geeft u een grootte door aan [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) in plaats van schaalfactoren. Dit voorbeeld rendert elke slide op 960 × 720 pixels en slaat het resultaat op met [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Kies afmetingen die overeenkomen met de beeldverhouding van de slide om uitrekken van de afbeelding te voorkomen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kies een gradientrenderingsstijl**

Stel dat een slide gradientvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan in PowerPoint. U kunt de methode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) gebruiken, geërfd door [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), om te kiezen hoe de gradients worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste slide bevat twee lineaire gradients: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradient heeft twee stops, bij 0% en 100%.

Het onderstaande voorbeeld laadt deze presentatie en rendert dezelfde eerste slide in beide modi met [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

De onderstaande afbeeldingen tonen de uitvoer van dezelfde slide, met beide gradients in elke afbeelding:

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel gradients gerenderd met Default](gradient-Default.png) | ![Dezelfde gradients gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld produceert `Default` lichtere tussenkleuren, terwijl `PowerPointUI` donkerdere tussenkleuren oplevert. Het verschil hangt af van de kleuren en stops in de gradient.

Kies `Default` wanneer de standaard Aspose.Slides‑uitvoer aan uw wensen voldoet. Probeer `PowerPointUI` wanneer uw prioriteit het overeenkomen van het uiterlijk in PowerPoint is. Vergelijk beide uitvoer met uw beoogde resultaat; geen van beide modi is universeel preferabel.

## **FAQ**

**Hoe kan ik een specifieke vorm, zoals een diagram of afbeelding, exporteren in plaats van de volledige slide?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele vormen](/slides/nl/nodejs-java/create-shape-thumbnails/), waardoor u een vorm kunt renderen als een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een afzonderlijke presentatie‑instantie voor elke thread of proces; [deel geen enkele instantie over threads](/slides/nl/nodejs-java/multithreading/).

**Wat zijn de beperkingen in de evaluatiemodus bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en past [andere beperkingen](/slides/nl/nodejs-java/licensing/) toe totdat een licentie is geïnstalleerd.