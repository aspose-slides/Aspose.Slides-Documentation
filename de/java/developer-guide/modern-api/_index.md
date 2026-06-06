---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 237
url: /de/java/modern-api/
keywords:
- moderne API
- Zeichnen
- Folien-Miniaturansicht
- Folie zu Bild
- Form-Miniaturansicht
- Form zu Bild
- Präsentations-Miniaturansicht
- Präsentation zu Bildern
- Bild hinzufügen
- Grafik hinzufügen
- Java
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die Java Moderne API ersetzen, für nahtlose PowerPoint- und OpenDocument-Automatisierung."
---
## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und stellt in der öffentlichen API die folgenden Klassen daraus bereit:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 ist diese öffentliche API als veraltet deklariert.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir die sogenannte „Modern API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden soll und deren Signaturen Abhängigkeiten von [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) enthalten. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ist als veraltet deklariert und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

In den aktuellen Versionen ist die öffentliche API, die von java.awt‑Typen abhängt, als Legacy/veraltet zu behandeln. Verwenden Sie die Modern API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) – repräsentiert das Raster‑ oder Vektorbild.
- [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/) – repräsentiert das Dateiformat des Bildes.
- [Images](https://reference.aspose.com/slides/de/java/com.aspose.slides/images/) – Methoden zum Instanziieren und Arbeiten mit dem [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/)-Interface.

Bitte beachten Sie, dass [IImage] entsorgbar ist und seine Verwendung von einem Aufruf von `dispose()` oder einem anderen geeigneten Entsorgungsmuster gefolgt werden sollte.

Verwenden Sie `getImage`, um eine einzelne Folie oder Form zu rendern. Verwenden Sie `getImages`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die Methoden von [Images], um Bilder zu laden, `addImage` mit [IImage], um sie einer Präsentation hinzuzufügen, und `replaceImage` mit [IImage], um ein vorhandenes Präsentationsbild zu aktualisieren.

Ein typisches Szenario für die Nutzung der neuen API kann wie folgt aussehen:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // Instanzieren Sie eine disposable Instanz von IImage aus der Datei auf dem Datenträger.
    IImage image = Images.fromFile("image.png");
    try {
        // Erstellen Sie ein PowerPoint-Bild, indem Sie eine Instanz von IImage zu den Bildern der Präsentation hinzufügen.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügen Sie ein Bild-Shape auf Folie #1 hinzu
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Holen Sie eine Instanz von IImage, die Folie #1 darstellt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // Speichern Sie das Bild auf dem Datenträger.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ersetzen alten Codes durch die Moderne API**

Im Allgemeinen müssen Sie Aufrufe, die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) und ImageIO verwenden, durch die neuen Methoden ersetzen, die [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) nutzen.

Legacy/Deprecated API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Abrufen einer Folien‑Miniaturansicht**

Legacy/Deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abrufen einer Form‑Miniaturansicht**

Legacy/Deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abrufen einer Präsentations‑Miniaturansicht**

Legacy/Deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hinzufügen eines Bildes zu einer Präsentation**

Legacy/Deprecated API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veraltete Methoden und deren Ersatz in der Modernen API**

### **Präsentation**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
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
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Ersetzende Methodensignatur |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑Unterstützung für Graphics2D**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet gekennzeichnet und haben keinen direkten Ersatz in der Modern API.

Verwenden Sie stattdessen die bildrendernden Methoden der Modern API anstelle der API, die zu [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) rendert:

[Slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Warum wurde [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) entfernt?**

Die Unterstützung für [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, Bindungen an plattformspezifische Abhängigkeiten zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) zu wechseln. Verwenden Sie `getImage` oder `getImages` anstelle des Renderns zu [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Welchen praktischen Nutzen bietet [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) gegenüber [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern und vereinfacht das Speichern in verschiedene Formate über [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/).

**Wird die Moderne API die Performance bei der Erzeugung von Miniaturansichten beeinflussen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen, während die Unterstützung für Rendering‑Optionen erhalten bleibt. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.