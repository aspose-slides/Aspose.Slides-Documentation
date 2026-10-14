---
title: Konvertera PowerPoint-bilder till PNG i JavaScript
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/nodejs-java/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder i JavaScript snabbt med Aspose.Slides för Node.js, vilket säkerställer precisa och automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar presentationsbilder till PNG‑bilder med Aspose.Slides för Node.js via Java. Du kan läsa in presentationer i format som PPT, PPTX och ODP, rendera varje bild och spara den som en separat PNG‑bild.

Exemplen nedan visar rendering med standardskala, ökning av skalan, specificering av utgångsdimensioner i pixlar samt val av en gradientrenderingsstil.

## **Konvertera PowerPoint till PNG**

Läs in en presentation med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och få åtkomst till dess bilder via samlingen [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Exemplet renderar varje bild med [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) utan parametrar för att skapa en miniatyr. Därefter anropas [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) med [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) för att spara varje renderad bild som en PNG‑fil.

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
Den parameterlösa överlagringen [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) renderar med en skala på 0,2. Till exempel ger en bild som mäter 720 × 540 punkter en miniatyr på 144 × 108 pixlar. För att styra utgångsdimensionerna, använd överlagringarna med skalfaktorer eller en explicit bildstorlek som visas nedan.
{{% /alert %}}

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Skicka horisontella och vertikala skalfaktorer till [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) för att kontrollera de renderade dimensionerna. I detta exempel är båda faktorerna 2, så en bild som mäter 720 × 540 punkter ger en bild på 1440 × 1080 pixlar. Lika skalfaktorer bevarar bildens bildförhållande. Varje bild sparas i PNG‑format med [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

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

## **Konvertera PowerPoint till PNG med anpassad storlek**

För att ange utgångsdimensioner i pixlar, skicka en storlek till [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) istället för skalfaktorer. Detta exempel renderar varje bild i 960 × 720 pixlar och sparar resultatet med [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Välj dimensioner som matchar bildens bildförhållande för att undvika att bilden sträcks.

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

## **Välj en gradientrenderingsstil**

Anta att en bild innehåller gradientfyllningar, men övergångarna i den exporterade PNG‑filen ser ljusare eller på annat sätt annorlunda ut än i PowerPoint. Du kan använda metoden [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) som ärvs av [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) för att välja hur gradienterna renderas.

Ladda ner [gradient-styles.pptx](gradient-styles.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller två linjära gradienter: cyan till orange högst upp och blå till gul längst ner. Varje gradient har två stopp, på 0 % och 100 %.

Följande exempel läser in denna presentation och renderar den första bilden i båda lägena med [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

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

Bilderna nedan visar resultatet från samma bild, med båda gradienterna i varje bild:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan‑till‑orange och blå‑till‑gul gradienter renderade med Default](gradient-Default.png) | ![Samma gradienter renderade med PowerPointUI](gradient-PowerPointUI.png) |

I detta exempel ger `Default` ljusare mellanfärger, medan `PowerPointUI` ger mörkare mellanfärger. Skillnaden beror på färgerna och stoppen i gradienten.

Välj `Default` när den standardmässiga Aspose.Slides‑utdata passar dina behov. Prova `PowerPointUI` när din prioritet är att matcha utseendet i PowerPoint. Jämför båda utdata med ditt önskade resultat; inget läge är generellt att föredra.

## **Vanliga frågor**

**Hur kan jag exportera en specifik form, till exempel ett diagram eller en bild, istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrbilder för enskilda former](/slides/sv/nodejs-java/create-shape-thumbnails/), vilket gör att du kan rendera en form som en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja. Använd en separat presentationsinstans för varje tråd eller process; [dela inte en enda instans över trådar](/slides/sv/nodejs-java/multithreading/).

**Vilka är begränsningarna i evalueringsläget vid export till PNG?**

Evalueringsläget lägger till ett vattenmärke på utdata bilder och tillämpar [andra begränsningar](/slides/sv/nodejs-java/licensing/) tills en licens har aktiverats.