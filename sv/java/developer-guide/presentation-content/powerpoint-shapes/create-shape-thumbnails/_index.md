---
title: Skapa miniatyrbilder av presentationsformer i Java
linktitle: Formminiatyrbilder
type: docs
weight: 70
url: /sv/java/create-shape-thumbnails/
keywords:
- formminiatyrbild
- form bild
- rendera form
- formrendering
- visuella avgränsningar
- formavgränsningar
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa högkvalitativa miniatyrbilder av former från PowerPoint-bilder med Aspose.Slides för Java – skapa och exportera presentationsminiatyrbilder enkelt."
---
## **Introduktion**

Aspose.Slides for Java kan användas för att skapa presentationsfiler där varje sida motsvarar en bild. Bilden kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. I vissa fall behöver utvecklare dock visa formernas bilder separat i en bildvisare. I sådana fall hjälper Aspose.Slides for Java dem att generera miniatyrbilder av bildformerna.

Den här artikeln förklarar hur man genererar bildminiatyrer på olika sätt:

- Generera en miniatyrbild av en form inom en bild.
- Generera en miniatyrbild av en form för en bildform med användardefinierade dimensioner.
- Generera en miniatyrbild av en form inom ramen för formens utseende.

## **Generera en miniatyrbild av en form från en bild**
För att generera en miniatyrbild av en form från någon bild med Aspose.Slides for Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta referensen till någon bild med dess ID eller index.
1. [Hämta miniatyrbild för formen](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getImage--) av den refererade bilden med standard skala.
1. Spara miniatyrbilden i ditt föredragna bildformat.

Den här exempelkoden visar hur du genererar en miniatyrbild av en form från en bild:

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

## **Generera en miniatyrbild med användardefinierad skalningsfaktor**
För att generera en miniatyrbild av en form för en bild med Aspose.Slides for Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta referensen till någon bild med dess ID eller index.
1. [Hämta miniatyrbild för formen](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getImage-int-float-float-) av den refererade bilden med användardefinierade dimensioner.
1. Spara miniatyrbilden i ditt föredragna bildformat.

Den här exempelkoden visar hur du genererar en miniatyrbild av en form baserat på en definierad skalningsfaktor:

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

## **Skapa en miniatyrbild av formens utseende baserad på avgränsningar**
Denna metod för att skapa miniatyrbilder av former låter utvecklare generera en miniatyrbild inom ramen för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade miniatyrbilden är begränsad av bildens avgränsningar. För att generera en miniatyrbild av en bildform inom ramen för dess utseende, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta referensen till någon bild med dess ID eller index.
1. Hämta miniatyrbilden för den refererade bilden med formens avgränsning som utseende.
1. Spara miniatyrbilden i ditt föredragna bildformat.

Den här exempelkoden är baserad på stegen ovan:

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

## **Hämta den faktiska visuella avgränsningen för en form**

Ramens egenskaper för [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) — dess `getX()`, `getY()`, `getWidth()`‑ och `getHeight()`‑metoder — beskriver den rektangel som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axel‑aligned rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt‑geometri och andra renderingseffekter kan alla förändra det upptagna området.

Använd [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getVisualBounds--) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar en [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) i bildkoordinater. Den returnerade rektangeln är inte beskuren till bilden, så dess koordinater kan vara negativa när innehållet sträcker sig bortom bildens ursprung.

[Shape.getVisualBounds](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getVisualBounds--) är för närvarande inte deklarerad i [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑gränssnittet. Därför bör du behålla formen som hämtas från bildens formssamling som ett gränssnittsvärde och endast kasta den när du anropar metoden.

Följande exempel hämtar och jämför ramen och den visuella avgränsningen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Samma [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan användas för att justera närliggande former till dess vänstra, högra, övre eller nedre kant; reservera tillräckligt med utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella avgränsningar är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar hela det renderade resultatet.

Använd [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getVisualBounds--) när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [IShape.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getImage--) när du behöver rendera formen. Med [ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapethumbnailbounds/) gör `ShapeThumbnailBounds.Shape` storleken på bilden utifrån formens avgränsning, inklusive konturinställningar, medan `ShapeThumbnailBounds.Appearance` storlekar den utifrån formens utseende och begränsar resultatet till bildens avgränsning. I kontrast returnerar [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getVisualBounds--) endast den beräknade rektangeln och beskär den inte till bilden.

## **FAQ**

**Vilka bildformat kan användas när du sparar miniatyrbilder av former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑avgränsningarna när en miniatyrbild renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/java/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyrbild?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelets visning men hindrar inte genereringen av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/smartart/)) kan sparas som en miniatyrbild eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrbilder för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/java/custom-font/) (eller [konfigurera typsnitts‑substitutioner](/slides/sv/java/font-substitution/)) för att undvika oönskade fallback‑tecken och textomflöde.