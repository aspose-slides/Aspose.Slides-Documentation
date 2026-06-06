---
title: "Verbessern Sie die Bildverarbeitung mit der Modernen API"
linktitle: "Moderne API"
type: docs
weight: 237
url: /de/androidjava/modern-api/
keywords:
- android.graphics
- "Moderne API"
- Zeichnen
- Folien-Miniaturansicht
- Folie zu Bild
- Form-Miniaturansicht
- Form zu Bild
- Präsentations-Miniaturansicht
- Präsentation zu Bildern
- Bild hinzufügen
- Bild hinzufügen
- Android
- Java
- Aspose.Slides
description: "Modernisieren Sie die Folien-Bildverarbeitung, indem Sie veraltete Bild-APIs durch die Java Moderne API für nahtlose PowerPoint- und OpenDocument-Automatisierung ersetzen."
---
## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von android.graphics und stellt in der öffentlichen API die folgenden Klassen davon bereit:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Ab Version 24.4 wird diese öffentliche API als veraltet deklariert.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir die sogenannte „Moderne API“ hinzugefügt – d. h. die API, die anstelle der veralteten verwendet werden soll und deren Signaturen keine Abhängigkeiten von [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) mehr enthalten. [Canvas](https://developer.android.com/reference/android/graphics/Canvas) ist als veraltet gekennzeichnet und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

In den aktuellen Versionen sollte die öffentliche API, die von android.graphics‑Typen abhängt, als Legacy/veraltet behandelt werden. Verwenden Sie die Moderne API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Enumerationen wurden zur öffentlichen API hinzugefügt:

- [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) – stellt das Raster‑ oder Vektorbild dar.
- [ImageFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/) – stellt das Dateiformat des Bildes dar.
- [Images](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/images/) – Methoden zum Instanziieren und Arbeiten mit dem [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/)-Interface.

Bitte beachten Sie, dass [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) disposable ist und seine Verwendung von einem Aufruf von `dispose()` oder einem anderen geeigneten Entsorgungsmuster gefolgt werden sollte.

Verwenden Sie `getImage`, um eine einzelne Folie oder Form zu rendern. Verwenden Sie `getImages`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die Methoden von [Images](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/images/), um Bilder zu laden, `addImage` mit [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/), um sie einer Präsentation hinzuzufügen, und `replaceImage` mit [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/), um ein bestehendes Präsentationsbild zu aktualisieren.

Ein typisches Anwendungsszenario der neuen API kann wie folgt aussehen:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instanziieren Sie eine disposable Instanz von IImage aus der Datei auf dem Datenträger.
    IImage image = Images.fromFile("image.png");
    try {
        // erstellen Sie ein PowerPoint‑Bild, indem Sie eine IImage‑Instanz zu den Bildern der Präsentation hinzufügen.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ein Bild‑Shape auf Folie #1 hinzufügen
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // erhalten Sie eine IImage‑Instanz, die Folie #1 darstellt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // das Bild auf dem Datenträger speichern.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ersetzen des alten Codes durch die Moderne API**

Im Allgemeinen müssen Sie Aufrufe, die [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) verwenden, durch die neuen Methoden ersetzen, die [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) nutzen.

Legacy/veraltete API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Moderne API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Abrufen einer Folien‑Miniaturansicht**

Legacy/veraltete API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

Legacy/veraltete API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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

Legacy/veraltete API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **Ein Bild zu einer Präsentation hinzufügen**

Legacy/veraltete API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **Veraltete Methoden und ihre Ersetzungen in der Modernen API**

### **Presentation**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Ersetzungsmethodensignatur |
|------------------|----------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **API‑Unterstützung für Canvas**

Methoden mit [Canvas](https://developer.android.com/reference/android/graphics/Canvas) sind als veraltet gekennzeichnet und haben keinen direkten Ersatz in der Modernen API.

Verwenden Sie die Bild‑Rendering‑Methoden der Modernen API anstelle der API, die zu [Canvas](https://developer.android.com/reference/android/graphics/Canvas) rendert:

[Slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Warum wurde android.graphics.Canvas entfernt?**

Die Unterstützung für [Canvas](https://developer.android.com/reference/android/graphics/Canvas) ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu beseitigen und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) zu wechseln. Verwenden Sie `getImage` oder `getImages` anstelle des Renderns zu [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Welchen praktischen Nutzen bietet [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) im Vergleich zu [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektorbildern und vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imageformat/).

**Wirkt sich die Moderne API auf die Leistung der Thumbnail‑Erstellung aus?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert keine Szenarien: Die neuen Methoden bieten dieselben Möglichkeiten zur Bildproduktion mit Optionen und Größen, während sie die Unterstützung für Rendering‑Optionen beibehalten. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersetzungen jedoch äquivalent.