---
title: "Bildverarbeitung mit dem Modern API verbessern"
linktitle: "Modern API"
type: docs
weight: 237
url: /de/nodejs-java/modern-api/
keywords:
- Modernes API
- Zeichnen
- Folien-Thumbnail
- Folie zu Bild
- Form-Thumbnail
- Form zu Bild
- Präsentations-Thumbnail
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernisieren Sie die Folien‑Bildverarbeitung, indem Sie veraltete Bild‑APIs durch die JavaScript Modern API ersetzen, um eine nahtlose PowerPoint‑ und OpenDocument‑Automatisierung zu ermöglichen."
---
## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und enthält in der öffentlichen API die folgenden Klassen davon:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 ist diese öffentliche API als veraltet markiert.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir das sogenannte "Modern API" hinzugefügt – also die API, die anstelle der veralteten verwendet werden soll, deren Signaturen Abhängigkeiten von [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) enthalten. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ist als veraltet markiert und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

In aktuellen Versionen sollte die öffentliche API, die von java.awt‑Typen abhängt, als Legacy/veraltet behandelt werden. Verwenden Sie das Modern API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Modernes API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) – repräsentiert das Raster‑ oder Vektor‑Bild.
- [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/) – repräsentiert das Dateiformat des Bildes.
- [Images](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/images/) – Methoden zum Instanziieren und Arbeiten mit der [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/)-Klasse.

Bitte beachten Sie, dass [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) entsorgbar ist und seine Verwendung von einem Aufruf von `dispose()` oder einem anderen praktischen Entsorgungsmuster gefolgt werden sollte.

Verwenden Sie `getImage`, um eine einzelne Folie oder Form zu rendern. Verwenden Sie `getImages`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die Methoden von [Images](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/images/), um Bilder zu laden, `addImage` mit [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/), um sie zu einer Präsentation hinzuzufügen, und `replaceImage` mit [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/), um ein vorhandenes Präsentationsbild zu aktualisieren.

Ein typisches Szenario für die Verwendung der neuen API könnte wie folgt aussehen:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // Instanziieren einer entsorgbaren IImage‑Instanz aus der Datei auf dem Datenträger.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // Erstellen eines PowerPoint‑Bildes, indem eine IImage‑Instanz zu den Bildern der Präsentation hinzugefügt wird.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Bildform auf Folie #1 hinzufügen
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // Eine IImage‑Instanz erhalten, die Folie #1 darstellt.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // Das Bild auf dem Datenträger speichern.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alten Code durch Modernes API ersetzen**

Im Allgemeinen müssen Sie Aufrufe, die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) und [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) verwenden, durch die neuen Methoden ersetzen, die [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) nutzen.

Legacy/veraltete API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modernes API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Abrufen eines Folien-Thumbnails**

Legacy/veraltete API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modernes API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abrufen eines Form-Thumbnails**

Legacy/veraltete API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modernes API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abrufen eines Präsentations-Thumbnails**

Legacy/veraltete API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modernes API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hinzufügen eines Bildes zu einer Präsentation**

Legacy/veraltete API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modernes API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veraltete Methoden und deren Ersatz im Modernen API**

### **Presentation**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Ersatz-Methodensignatur |
|------------------|--------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API-Unterstützung für Graphics2D**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet markiert und haben keinen direkten Ersatz im Modern API.

Verwenden Sie die Bildrender‑Methoden des Modern API anstelle der API, die nach [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) rendert:

[Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Was ist der praktische Nutzen von [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) im Vergleich zu [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern und vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/).

**Wird das Modern API die Leistung bei der Erzeugung von Thumbnails beeinflussen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten die gleichen Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen und behalten die Unterstützung von Rendering‑Optionen bei. Der konkrete Gewinn oder Verlust hängt vom Szenario ab, aber funktional sind die Ersetzungen äquivalent.