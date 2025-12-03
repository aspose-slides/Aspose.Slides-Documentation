---
title: Bildverarbeitung mit der Modernen API verbessern
linktitle: Moderne API
type: docs
weight: 237
url: /de/java/modern-api/
keywords:
- moderne API
- Zeichnen
- Folien-Thumbnail
- Folie zu Bild
- Form-Thumbnail
- Form zu Bild
- Präsentations-Thumbnail
- Präsentation zu Bildern
- Bild hinzufügen
- Grafik hinzufügen
- Java
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die Java Moderne API ersetzen, um eine nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---

## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und stellt in der öffentlichen API die folgenden Klassen davon bereit:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 wird diese öffentliche API als veraltet deklariert.

Um diese Abhängigkeiten zu entfernen, haben wir die sogenannte „Moderne API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden sollte, deren Signaturen Abhängigkeiten von BufferedImage enthalten. Graphics2D ist als veraltet deklariert und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing erfolgt in Release 24.8.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- IImage – repräsentiert das Raster‑ oder Vektorbild.
- ImageFormat – repräsentiert das Dateiformat des Bildes.
- Images – Methoden zum Erzeugen und Arbeiten mit dem IImage‑Interface.

Bitte beachten Sie, dass IImage entsorgbar ist (es implementiert das IDisposable‑Interface und seine Verwendung sollte in einem using‑Block oder auf andere geeignete Weise entsorgt werden).

Ein typisches Szenario für die Verwendung der neuen API könnte wie folgt aussehen:
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // Instanziieren einer disposable Instanz von IImage aus der Datei auf dem Datenträger.
    IImage image = Images.fromFile("image.png");
    try {
        // Ein PowerPoint-Bild erstellen, indem eine Instanz von IImage zu den Bildern der Präsentation hinzugefügt wird.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ein Bild-Shape auf Folie #1 hinzufügen.
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // Eine Instanz von IImage erhalten, die Folie #1 darstellt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // Das Bild auf dem Datenträger speichern.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ersetzen alten Codes durch die Moderne API**

Im Allgemeinen müssen Sie den Aufruf der alten Methode, die ImageIO verwendet, durch den neuen ersetzen.

Alt:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```

Neu:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```


### **Abrufen eines Folien-Thumbnails**

Code, der eine veraltete API verwendet:
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


Moderne API:
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


### **Abrufen eines Shape-Thumbnails**

Code, der eine veraltete API verwendet:
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


Moderne API:
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


### **Abrufen eines Präsentations-Thumbnails**

Code, der eine veraltete API verwendet:
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


Moderne API:
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

Code, der eine veraltete API verwendet:
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


Moderne API:
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


## **Methoden, die entfernt werden, und ihre Ersatzmethoden in der Modernen API**

### **Presentation**
| Methodensignatur | Signatur der Ersatzmethode |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodensignatur | Signatur der Ersatzmethode |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Signatur der Ersatzmethode |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
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
| Methodensignatur | Signatur der Ersatzmethode |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Signatur der Ersatzmethode |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Signatur der Ersatzmethode |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Signatur der Ersatzmethode |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Signatur der Ersatzmethode |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Unterstützung für Graphics2D in der API wird eingestellt**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet deklariert und ihre Unterstützung wird aus der öffentlichen API entfernt.

Der Teil der API, der es verwendet, wird entfernt:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Warum wurde java.awt.Graphics2D entfernt?**

Die Unterstützung für `Graphics2D` wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) zu wechseln. Alle Rendering‑Methoden für `Graphics2D` werden entfernt.

**Was ist der praktische Nutzen von IImage im Vergleich zu BufferedImage?**

[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor­bildern und vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/).

**Wird die Moderne API die Leistung bei der Erzeugung von Thumbnails beeinflussen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert keine Szenarien: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen und behalten die Unterstützung für Rendering‑Optionen bei. Der konkrete Gewinn oder Verlust hängt vom jeweiligen Szenario ab, funktional sind die Ersatzmethoden jedoch äquivalent.