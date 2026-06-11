---
title: Skapa miniatyrer av presentationsformer på Android
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/androidjava/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för Android via Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides for Android via Java kan användas för att skapa presentationsfiler där varje sida motsvarar en bild. Bilderna kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. I vissa fall behöver utvecklare se bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides for Android via Java dem att generera miniatyrbilder av bildformerna.

I det här avsnittet visar vi hur man genererar bildminiatyrer i olika situationer:

- Generera en formminiatur inne i en bild.
- Generera en formminiatur för en bildform med användardefinierade dimensioner.
- Generera en formminiatur inom gränsen för en forms utseende.

## **Generera en formminiatur från en bild**
För att generera en formminiatur från vilken bild som helst med Aspose.Slides for Android via Java, gör så här:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) class.
2. Hämta referensen till någon bild med dess ID eller index.
3. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getImage--) av den refererade bilden på standardskala.
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

## **Generera en miniatyr med användardefinierad skalningsfaktor**
För att generera formminiaturen för en bild med Aspose.Slides for Android via Java, gör så här:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) class.
2. Hämta referensen till någon bild med dess ID eller index.
3. [Hämta formens miniatyrbild](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) av den refererade bilden med användardefinierade dimensioner.
4. Spara miniatyrbilden i ditt föredragna bildformat.

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

## **Skapa en miniatyr baserad på gränser för formens utseende**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom gränsen för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade formminiaturen begränsas av bildens gränser. För att generera en miniatyr av en bildform inom dess utseendes gräns, gör så här:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) class.
2. Hämta referensen till någon bild med dess ID eller index.
3. Hämta miniatyrbilden av den refererade bilden med formens gränser som utseende.
4. Spara miniatyrbilden i ditt föredragna bildformat.

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

## **Vanliga frågor**

**Vilka bildformat kan användas när man sparar formminiaturer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape- och Appearance-gränser när en miniatyr renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/androidjava/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelets visning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga teckensnitten](/slides/sv/androidjava/custom-font/) (eller [konfigurera teckensnittsersättningar](/slides/sv/androidjava/font-substitution/)) för att undvika oönskade nedfallsplaner och textomflöde.