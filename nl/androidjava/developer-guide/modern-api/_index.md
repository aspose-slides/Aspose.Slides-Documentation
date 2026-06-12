---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 237
url: /nl/androidjava/modern-api/
keywords:
- android.graphics
- moderne API
- tekenen
- dia-miniatuur
- dia naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- Android
- Java
- Aspose.Slides
description: "Moderniseer de verwerking van dia-afbeeldingen door verouderde beeldverwerkings-API's te vervangen door de Java Moderne API voor naadloze PowerPoint- en OpenDocument-automatisering."
---
## **Introductie**

Historisch gezien heeft Aspose Slides een afhankelijkheid van android.graphics en heeft in de openbare API de volgende klassen van daar:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Vanaf versie 24.4 wordt deze openbare API gemarkeerd als verouderd.

Om van deze afhankelijkheden af te komen, hebben we de zogenaamde “Modern API” toegevoegd – de API die in plaats van de verouderde moet worden gebruikt, waarvan de handtekeningen afhankelijkheden van [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) bevatten. [Canvas](https://developer.android.com/reference/android/graphics/Canvas) is gemarkeerd als verouderd en de ondersteuning ervan is verwijderd uit de openbare Slides API.

In de huidige versies moet de openbare API die afhankelijk is van android.graphics‑typen als legacy/verouderd worden beschouwd. Gebruik de Modern API voor nieuwe code en bij het migreren van bestaande beeldverwerkings‑workflows.

## **Moderne API**

De volgende klassen en enumeraties zijn toegevoegd aan de openbare API:

- [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) - stelt de raster- of vectorafbeelding voor.
- [ImageFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/) - geeft het bestandsformaat van de afbeelding weer.
- [Images](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/images/) - methoden om instanties te maken en te werken met de [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)-interface.

Let op dat [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) disposable is en het gebruik ervan moet worden gevolgd door een `dispose()`‑aanroep of een ander handig disposingspatroon.

Gebruik `getImage` om een enkele dia of vorm te renderen. Gebruik `getImages` om meerdere presentatiedia's te renderen. Gebruik de [Images](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/images/)-methoden om afbeeldingen te laden, `addImage` met [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `replaceImage` met [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) om een bestaande presentatie‑afbeelding bij te werken.

Een typisch scenario voor het gebruik van de nieuwe API kan er als volgt uitzien:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instantieer een disposable instantie van IImage vanaf het bestand op de schijf.
    IImage image = Images.fromFile("image.png");
    try {
        // maak een PowerPoint-afbeelding door een IImage‑instantie toe te voegen aan de afbeeldingen van de presentatie.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // voeg een picture‑shape toe op de dia #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // verkrijg een instantie van IImage die dia #1 vertegenwoordigt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // sla de afbeelding op op de schijf.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vervangen van oude code met Moderne API**

Over het algemeen moet u oproepen die [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) gebruiken vervangen door de nieuwe methoden die [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) gebruiken.

Legacy/deprecated API:
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
Modern API:
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

### **Een dia‑miniatuur ophalen**

Legacy/deprecated API:

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

### **Een vorm‑miniatuur ophalen**

Legacy/deprecated API:

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

### **Een presentatie‑miniatuur ophalen**

Legacy/deprecated API:

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

Modern API:

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

### **Een afbeelding toevoegen aan een presentatie**

Legacy/deprecated API:

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

## **Verouderde methoden en hun vervanging in Moderne API**

### **Presentation**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
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
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **API‑ondersteuning voor Canvas**

Methoden met [Canvas](https://developer.android.com/reference/android/graphics/Canvas) zijn gemarkeerd als verouderd en hebben geen directe vervanging in de Moderne API.

Gebruik de beeldrenderingsmethoden van de Moderne API in plaats van de API die rendert naar [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Waarom is android.graphics.Canvas verwijderd?**

De ondersteuning voor [Canvas](https://developer.android.com/reference/android/graphics/Canvas) is verouderd in de openbare API om het werken met rendering en afbeeldingen te verenigen, platform‑specifieke afhankelijkheden te elimineren en over te stappen op een cross‑platform aanpak met [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/). Gebruik `getImage` of `getImages` in plaats van rendering naar [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) ten opzichte van [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vectorafbeeldingen en vereenvoudigt het opslaan naar diverse formaten via [ImageFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/).

**Zal de Moderne API de prestaties van het genereren van miniaturen beïnvloeden?**

Overschakelen van `getThumbnail` naar `getImage` verslechtert scenario’s niet: de nieuwe methoden bieden dezelfde mogelijkheden voor het produceren van afbeeldingen met opties en maten, terwijl ze de ondersteuning voor rendering‑opties behouden. De specifieke winst of verlies hangt af van het scenario, maar functioneel zijn de vervangingen equivalent.