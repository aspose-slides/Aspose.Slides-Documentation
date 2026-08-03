---
title: Skapa miniatyrb bilder av presentationsformer i JavaScript
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/nodejs-java/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med JavaScript och Aspose.Slides för Node.js – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är en bild. Dessa bilder kan visas genom att öppna presentationsfilen i Microsoft PowerPoint. Ibland kan utvecklare behöva se bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildformerna. Hur du använder denna funktion beskrivs i den här artikeln.
Denna artikel förklarar hur du genererar bildminiatyrer på olika sätt:

- Generera en miniatyr av en form inom en bild.
- Generera en miniatyr av en form för en bildform med användardefinierade dimensioner.
- Generera en miniatyr av en form inom formens utseendegränser.

## **Generera formminiatyrer från bilder**
För att generera en formminiatyr från valfri bild med Aspose.Slides för Node.js via Java, gör följande:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta referensen till en valfri bild med dess ID eller index.
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getImage--) av den refererade bilden i standard skala.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en formminiatyr från en bild:

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

## **Generera formminiatyrer med användardefinierad skalningsfaktor**
För att generera formens miniatyr för en bild med Aspose.Slides för Node.js via Java, gör följande:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta referensen till en valfri bild med dess ID eller index.
1. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) av den refererade bilden med användardefinierade dimensioner.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en formminiatyr baserad på en definierad skalningsfaktor:

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

## **Generera formminiatyr av gränser**
Denna metod för att skapa miniatyrer av former gör det möjligt för utvecklare att generera en miniatyr inom formens utseendegränser. Den tar hänsyn till alla formeffekter. Den genererade formminiatyren begränsas av bildens gränser. För att generera en miniatyr av en bildform i dess utseendegräns, gör följande:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta referensen till en valfri bild med dess ID eller index.
1. Hämta miniatyrbilden av den refererade bilden med formgränser som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod är baserad på stegen ovan:

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

## **Hämta de faktiska visuella gränserna för en form**

Ramverksegenskaperna för en [Shape]—dess `getX()`, `getY()`, `getWidth()` och `getHeight()`-metoder—beskriver den rektangel som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig bortom den ramen eller uppta en annan axelriktad rektangel. Rotation, konturer, pilhuvuden, textlayout och översvämning, genererad SmartArt-geometri och andra renderings‑effekter kan alla förändra det upptagna området.

Använd [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getVisualBounds--) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar ett [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)-objekt i bildkoordinater. Den returnerade rektangeln klipps inte till bilden, så dess koordinater kan vara negativa när innehållet sträcker sig bortom bildens ursprung.

Följande exempel hämtar och jämför ramen och de visuella gränserna:

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

Den samma rektangeln kan användas för att justera närliggande former till dess vänstra, högra, övre eller nedre kant; reservera tillräckligt utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar det fullständiga renderade resultatet.

Använd [Shape.getVisualBounds] när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [Shape.getImage] när du behöver rendera formen. Med [ShapeThumbnailBounds] bestämmer `ShapeThumbnailBounds.Shape` bildens storlek utifrån formens gränser, inklusive konturinställningar, medan `ShapeThumbnailBounds.Appearance` bestämmer den utifrån formens utseende och begränsar resultatet till bildens gränser. I kontrast returnerar [Shape.getVisualBounds] endast den beräknade rektangeln och klipper den inte till bilden.

## **FAQ**

**Vilka bildformat kan användas när du sparar formminiatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape- och Appearance‑gränser när en miniatyr renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visual effects](/slides/sv/nodejs-java/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En gömd form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning men hindrar inte genereringen av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape] (inklusive [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de erforderliga teckensnitten](/slides/sv/nodejs-java/custom-font/) (eller [konfigurera teckensnittsersättningar](/slides/sv/nodejs-java/font-substitution/)) för att undvika oönskade reservkopior och textomflyttning.