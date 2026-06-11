---
title: Skapa miniatyrer av presentationsformer i Java
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/java/create-shape-thumbnails/
keywords:
- form miniatyr
- form bild
- rendera form
- formrendering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides for Java kan användas för att skapa presentationsfiler där varje sida motsvarar en bild. Bilderna kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. I vissa situationer behöver utvecklare dock visa bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides for Java dem att skapa miniatyrbilder av bildformerna.

Denna artikel förklarar hur man genererar bild‑miniatyrer på olika sätt:

- Skapa en miniatyrbild av en form inuti en bild.
- Skapa en miniatyrbild av en form för en bildform med användardefinierade dimensioner.
- Skapa en miniatyrbild av en form inom gränserna för formens utseende.

## **Skapa en Form‑miniatyr från en Bild**
För att skapa en form‑miniatyr från vilken bild som helst med Aspose.Slides for Java, gör så här:

1. Skapa en instans av klassen Presentation.
2. Hämta referensen till någon bild med dess ID eller index.
3. Hämta formens miniatyrbild [Get the shape thumbnail image](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getImage--) för den refererade bilden med standardskala.
4. Spara miniatyrbilden i önskat bildformat.

```java
// Instansiera en Presentation-klass som representerar presentationsfilen
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Spara bilden till disk i PNG-format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skapa en Miniatyr med Användardefinierad Skalningsfaktor**
För att skapa formens miniatyr för en bild med Aspose.Slides for Java, gör så här:

1. Skapa en instans av klassen Presentation.
2. Hämta referensen till någon bild med dess ID eller index.
3. Hämta formens miniatyrbild [Get the shape thumbnail image](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape#getImage-int-float-float-) för den refererade bilden med användardefinierade dimensioner.
4. Spara miniatyrbilden i önskat bildformat.

```java
// Instansiera en Presentation-klass som representerar presentationsfilen
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Spara bilden till disk i PNG-format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skapa en Gränsbaserad Formutseende‑miniatyr**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom formens utseendes gränser. Den tar hänsyn till alla formeffekter. Den genererade form‑miniatyren begränsas av bildens gränser. För att skapa en miniatyr av en bildform inom dess utseendes gräns, gör så här:

1. Skapa en instans av klassen Presentation.
2. Hämta referensen till någon bild med dess ID eller index.
3. Hämta miniatyrbilden för den refererade bilden med formens gränser som utseende.
4. Spara miniatyrbilden i önskat bildformat.

```java
// Instansiera en Presentation-klass som representerar presentationsfilen
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Skapa en bild i full skala
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Spara bilden till disk i PNG-format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vilka bildformat kan användas vid sparande av form‑miniatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektorgrafik SVG](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när en miniatyr renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visual effects](/slides/sv/java/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; dold‑flaggan påverkar bara bildspelvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som Shape (inklusive GroupShape, Chart och SmartArt) kan sparas som miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/java/custom-font/) (eller [konfigurera typsnittssubstitutioner](/slides/sv/java/font-substitution/)) för att undvika oönskade fallback‑typsnitt och textomflyttning.