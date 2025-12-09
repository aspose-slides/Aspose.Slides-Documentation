---
title: Moderne API
type: docs
weight: 237
url: /de/nodejs-java/modern-api/
keywords: "CrossPlatform Moderne API"
description: "Moderne API"
---

## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und stellt in der öffentlichen API die folgenden Klassen daraus bereit:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 ist diese öffentliche API als veraltet deklariert.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir die sogenannte „Modern API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden sollte, deren Signaturen Abhängigkeiten von BufferedImage enthalten. Graphics2D ist als veraltet markiert und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing erfolgt in der Version 24.8.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- IImage – repräsentiert das Raster‑ oder Vektorbild.
- ImageFormat – repräsentiert das Dateiformat des Bildes.
- Images – Methoden zum Instanziieren und Arbeiten mit der IImage‑Klasse.

Bitte beachten Sie, dass IImage entladen werden kann (es implementiert die IDisposable‑Schnittstelle und seine Verwendung sollte in einem using‑Block erfolgen oder auf andere geeignete Weise entsorgt werden).

Ein typisches Szenario für die Verwendung der neuen API könnte wie folgt aussehen:
``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // Instanziiere eine disposable Instanz von IImage aus der Datei auf der Festplatte.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // Erstelle ein PowerPoint-Bild, indem du eine Instanz von IImage zu den Bildern der Präsentation hinzufügst.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Füge ein Bild-Shape auf Folie #1 hinzu
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // Erhalte eine Instanz von IImage, die Folie #1 darstellt.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // Speichere das Bild auf der Festplatte.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Austausch alten Codes durch die Moderne API**

Im Allgemeinen müssen Sie den Aufruf der alten Methode, die ImageIO verwendet, durch den neuen ersetzen.

Old:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```

New:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```


### **Abrufen eines Folien‑Thumbnails**

Code mit einer veralteten API:
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


Moderne API:
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


### **Abrufen eines Shape‑Thumbnails**

Code mit einer veralteten API:
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


Moderne API:
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


### **Abrufen eines Präsentations‑Thumbnails**

Code mit einer veralteten API:
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


Moderne API:
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


### **Ein Bild zu einer Präsentation hinzufügen**

Code mit einer veralteten API:
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


Moderne API:
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


## **Zu entfernende Methoden und deren Ersatz in der Modernen API**

### **Presentation**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

### **Output**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Unterstützung für Graphics2D in der API wird eingestellt**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet deklariert und ihre Unterstützung wird aus der öffentlichen API entfernt.

Der Teil der API, der es verwendet, wird entfernt:

[Folie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Was ist der praktische Nutzen von IImage im Vergleich zu Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) vereinheitlicht die Arbeit mit sowohl Raster‑ als auch Vektor‑Bildern und vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/).

**Wird die Moderne API die Leistung beim Erzeugen von Thumbnails beeinflussen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten, Bilder mit Optionen und Größen zu erzeugen, während die Unterstützung für Rendering‑Optionen erhalten bleibt. Der konkrete Gewinn oder Verlust hängt vom Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.