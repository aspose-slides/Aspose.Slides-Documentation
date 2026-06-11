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
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder i JavaScript snabbt med Aspose.Slides för Node.js, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Denna artikel förklarar hur man konverterar PowerPoint-presentationer till PNG-bilder med Aspose.Slides. Den visar hur man läser in presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultatet i PNG-format.

Artikeln demonstrerar också hur man anpassar de genererade PNG-bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta bildobjektet från samlingen som returneras av metoden [Presentation.getSlides()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) under klassen [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide).
3. Använd metoden [Slide.getImage()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide) för att hämta miniatyrbilden för varje bild.
4. Använd metoden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/#save) för att spara bildens miniatyr till PNG-format.

JavaScript‑koden visar hur du konverterar en PowerPoint-presentation till PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG-filer i en viss skala kan du ange värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyrbilden. 

Denna kod i JavaScript demonstrerar den beskrivna operationen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

Om du vill få PNG-filer i en viss storlek kan du skicka dina föredragna argument `width` och `height` för `ImageSize`. 

Denna kod visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar bildens storlek: 

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?**

Aspose.Slides stöder att generera miniatyrbilder för enskilda former; du kan rendera en form till en PNG-bild.

**Stöds parallell konvertering på en server?**

Ja, men dela inte en enda presentationsinstans över trådar. Använd en separat instans per tråd eller process.

**Vilka är begränsningarna i provversionen när man exporterar till PNG?**

Utvärderingsläget lägger till ett vattenmärke i utdata bilder och tillämpar andra begränsningar tills en licens har tillämpats.