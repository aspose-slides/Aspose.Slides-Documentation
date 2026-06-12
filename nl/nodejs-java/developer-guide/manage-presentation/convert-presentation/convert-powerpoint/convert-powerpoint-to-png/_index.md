---
title: PowerPoint-dia's converteren naar PNG in JavaScript
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit in JavaScript met Aspose.Slides voor Node.js, waardoor nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar PNG‑afbeeldingen kunt converteren met Aspose.Slides. Het laat zien hoe u presentaties kunt laden in formaten zoals PPT, PPTX en ODP, dia’s kunt renderen als afbeeldingen en de resultaten opslaat in PNG‑formaat.

Het artikel toont ook hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint converteren naar PNG**

Volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal het dia‑object op uit de collectie die wordt geretourneerd door de [Presentation.getSlides()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) methode van de [Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide) klasse.
3. Gebruik de [Slide.getImage()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Slide) methode om de miniatuur voor elke dia op te halen.
4. Gebruik de [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) methode om de miniatuur van de dia op te slaan in PNG‑formaat.

Deze JavaScript‑code laat zien hoe u een PowerPoint‑presentatie naar PNG kunt converteren:

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

## **PowerPoint converteren naar PNG met aangepaste afmetingen**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde schaal, kunt u de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende miniatuur bepalen.

Deze JavaScript‑code demonstreert de beschreven bewerking:

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

## **PowerPoint converteren naar PNG met aangepaste grootte**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven voor `ImageSize`.

Deze code laat zien hoe u een PowerPoint naar PNG kunt converteren terwijl u de grootte voor de afbeeldingen opgeeft:

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

**Hoe kan ik alleen een specifiek vorm (bijv. diagram of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/nodejs-java/create-shape-thumbnails/); u kunt een vorm renderen naar een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel](/slides/nl/nodejs-java/multithreading/) een enkele presentatie‑instantie niet over threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en handhaaft [andere beperkingen](/slides/nl/nodejs-java/licensing/) totdat er een licentie is toegepast.