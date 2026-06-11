---
title: Skapa miniatyrbilder av presentationsformer i JavaScript
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/nodejs-java/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med JavaScript och Aspose.Slides för Node.js – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är en slide. Dessa slides kan visas genom att öppna presentationsfilerna med Microsoft PowerPoint. Men ibland kan utvecklare behöva visa bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildspelsformerna. Hur du använder den här funktionen beskrivs i den här artikeln.  
Den här artikeln förklarar hur du genererar slide-miniatyrer på olika sätt:

- Skapa en miniatyr för en form inuti en slide.  
- Skapa en miniatyr för en form på en slide med användardefinierade dimensioner.  
- Skapa en miniatyr för en form inom gränserna för formens utseende.  

## **Generera form‑miniatyrer från slides**
Så här genererar du en form‑miniatyr från en valfri slide med Aspose.Slides för Node.js via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).  
1. Hämta referensen till valfri slide med dess ID eller index.  
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getImage--) av den refererade sliden med standard skala.  
1. Spara miniatyrbilden i ditt föredragna bildformat.  

Detta exempel visar hur du genererar en form‑miniatyr från en slide:

```javascript
// Instansiera en Presentation-klass som representerar presentationsfilen
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Spara bilden till disk i PNG-format
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

## **Generera form‑miniatyrer med användardefinierad skalfaktor**
Så här genererar du en form‑miniatyr för en slide med Aspose.Slides för Node.js via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).  
1. Hämta referensen till valfri slide med dess ID eller index.  
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) av den refererade sliden med användardefinierade dimensioner.  
1. Spara miniatyrbilden i ditt föredragna bildformat.  

Detta exempel visar hur du genererar en form‑miniatyr baserad på en definierad skalfaktor:

```javascript
// Instansiera en Presentation-klass som representerar presentationsfilen
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Spara bilden till disk i PNG-format
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

## **Generera form‑miniatyr för gränser**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom gränserna för formens utseende. Den tar hänsyn till alla formens effekter. Den genererade form‑miniatyren är begränsad av slide‑gränserna. Så här genererar du en miniatyr av en slide‑form inom dess utseendegräns:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).  
1. Hämta referensen till valfri slide med dess ID eller index.  
1. Hämta miniatyrbilden av den refererade sliden med formens gränser som utseende.  
1. Spara miniatyrbilden i ditt föredragna bildformat.  

Detta exempel är baserat på stegen ovan:

```javascript
// Instansiera en Presentation-klass som representerar presentationsfilen
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Spara bilden till disk i PNG-format
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

**Vilka bildformat kan användas när du sparar form‑miniatyrer?**  

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.  

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när en miniatyr renderas?**  

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/nodejs-java/shape-effect/) (skuggor, glöd, etc.).  

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**  

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar endast presentationens visning men hindrar inte genereringen av formens bild.  

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**  

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/)) kan sparas som en miniatyr eller som SVG.  

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrer för textformer?**  

Ja. Du bör [tillhandahålla de nödvändiga teckensnitten](/slides/sv/nodejs-java/custom-font/) (eller [konfigurera teckensnittssubstitutioner](/slides/sv/nodejs-java/font-substitution/)) för att undvika oönskade fallback‑teckensnitt och textomflyttning.