---
title: Skapa miniatyrbilder av presentationsformer på Android
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/androidjava/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för Android via Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides för Android via Java kan användas för att skapa presentationsfiler där varje sida motsvarar en bild. Bilderna kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. Ibland behöver utvecklare dock se bildernas former separat i en bildvisare. I sådana fall hjälper Aspose.Slides för Android via Java dem att generera miniatyrbilder av bildformerna.

I detta avsnitt visar vi hur man genererar miniatyrbilder av former i olika situationer:

- Generera en miniatyr av en form i en bild.
- Generera en miniatyr av en form med användardefinierade dimensioner.
- Generera en miniatyr av en form inom begränsningarna för formens utseende.

## **Generera en formminiatyr från en bild**
För att generera en formminiatyr från en valfri bild med Aspose.Slides för Android via Java, gör så här:

1. Skapa en instans av[Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)klassen.
1. Hämta referensen till en valfri bild med dess ID eller index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getImage--)för den refererade bilden med standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Detta exempel visar hur du genererar en formminiatyr från en bild:

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
För att generera formminiatyren för en bild med Aspose.Slides för Android via Java, gör så här:

1. Skapa en instans av[Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)klassen.
1. Hämta referensen till en valfri bild med dess ID eller index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)för den refererade bilden med användardefinierade dimensioner.
1. Spara miniatyrbilden i önskat bildformat.

Detta exempel visar hur du genererar en formminiatyr baserad på en definierad skalningsfaktor:

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

## **Skapa en miniatyr baserad på bildens gränser för formens utseende**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom gränserna för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade formminiatyren begränsas av bildens gränser. För att generera en miniatyr av en bildform i dess utseendes gräns, gör så här:

1. Skapa en instans av[Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)klassen.
1. Hämta referensen till en valfri bild med dess ID eller index.
1. Hämta miniatyrbilden för den refererade bilden med formens gränser som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Detta exempel bygger på stegen ovan:

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

## **Hämta de faktiska visuella gränserna för en form**

Ram‑egenskaperna för[IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)—dess`getX()`, `getY()`, `getWidth()` och`getHeight()`‑metoder—beskriver rektangeln som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axel­justerad rektangel. Rotation, konturer, pilspetsar, textlayout och överflöde, genererad SmartArt‑geometri och andra renderinge­ffekter kan alla förändra det upptagna området.

Använd[Shape.getVisualBounds](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getVisualBounds--)för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar ett[RectF](https://developer.android.com/reference/android/graphics/RectF) i bildkoordinater. Den returnerade rektangeln är inte beskuren till bilden, så dess koordinater kan vara negativa när innehållet sträcker sig utanför bildens ursprung.

[Shape.getVisualBounds](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getVisualBounds--)är för närvarande inte deklarerad i[IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑gränssnittet. Därför bör du behålla formen som hämtas från bildens formsamling som ett gränssnittsvärde och bara kasta den när du anropar metoden.

Följande exempel hämtar och jämför ramen och de visuella gränserna:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Samma[RectF](https://developer.android.com/reference/android/graphics/RectF)kan användas för att justera intilliggande former till dess vänstra, högra, övre eller nedre kant; reservera tillräckligt med utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar hela renderingsresultatet.

Använd[Shape.getVisualBounds](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getVisualBounds--)när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd[IShape.getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getImage--)när du behöver rendera formen. Med[ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapethumbnailbounds/)`ShapeThumbnailBounds.Shape`storlekar bilden från formens gränser, inklusive konturinställningar, medan`ShapeThumbnailBounds.Appearance`storlekar den från formens utseende och begränsar resultatet till bildens gränser. I kontrast returnerar[Shape.getVisualBounds](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getVisualBounds--)endast den beräknade rektangeln och beskär den inte till bilden.

## **FAQ**

**Vilka bildformat kan användas när formminiatyren sparas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imageformat/), och andra. Former kan också[exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när en miniatyr renderas?**

`Shape` använder formens geometri; `Appearance` tar[visual effects](/slides/sv/androidjava/shape-effect/)(skuggor, glöd osv.) i beaktande.

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som[Shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/)(inklusive[GroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/groupshape/),[Chart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/)och[SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/smartart/))kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör[provide the required fonts](/slides/sv/androidjava/custom-font/)(eller[configure font substitutions](/slides/sv/androidjava/font-substitution/))för att undvika oönskade ersättningar och textomslag.