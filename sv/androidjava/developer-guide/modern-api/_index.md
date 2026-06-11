---
title: Förbättra bildbehandling med Modern API
linktitle: Modernt API
type: docs
weight: 237
url: /sv/androidjava/modern-api/
keywords:
- android.graphics
- modernt API
- ritning
- bildspelsminiatyr
- bildspel till bild
- formminiatyr
- form till bild
- presentationsminiatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- Android
- Java
- Aspose.Slides
description: "Modernisera bildbehandling för bildspel genom att ersätta föråldrade bild-API:er med Java Modern API för sömlös PowerPoint- och OpenDocument-automatisering."
---
## **Introduktion**

Historiskt har Aspose Slides ett beroende på android.graphics och har i det offentliga API:et följande klasser därifrån:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Från och med version 24.4 är detta offentliga API förklarat som föråldrat.

För att bli av med beroenden på dessa klasser lade vi till det så kallade "Modern API" – det vill säga API:et som ska användas istället för det föråldrade, vars signaturer innehåller beroenden på [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) är förklarat som föråldrat och dess stöd har tagits bort från det offentliga Slides API:et.

I nuvarande versioner ska det offentliga API som är beroende av android.graphics-typer behandlas som legacy/föråldrat. Använd Modern API för ny kod och när du migrerar befintliga bildbehandlingsarbetsflöden.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:et:

- [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) – representerar raster- eller vektorbilder.
- [ImageFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imageformat/) – representerar bildfilens format.
- [Images](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/images/) – metoder för att instansiera och arbeta med [IImage]-gränssnittet.

Observera att [IImage] är disposable och att dess användning bör följs av ett `dispose()`‑anrop eller ett annat bekvämt avvecklingsmönster.

Använd `getImage` för att rendera en enskild bild eller form. Använd `getImages` för att rendera flera presentationsbilder. Använd [Images]-metoder för att läsa in bilder, `addImage` med [IImage] för att lägga till dem i en presentation, och `replaceImage` med [IImage] för att uppdatera en befintlig presentationsbild.

Ett typiskt scenario för att använda det nya API:t kan se ut som följer:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instansiera en disposable-instans av IImage från filen på disken.
    IImage image = Images.fromFile("image.png");
    try {
        // skapa en PowerPoint-bild genom att lägga till en IImage-instans i presentationens bilder.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // lägg till en bildform på bildspel #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // hämta en instans av IImage som representerar bildspel #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // spara bilden på disken.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ersätta gammal kod med Modern API**

I allmänhet måste du ersätta anrop som använder [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) med de nya metoderna som använder [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/).

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

### **Hämta en miniatyr för en bild**

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

### **Hämta en miniatyr för en form**

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

### **Hämta en miniatyr för en presentation**

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

### **Lägga till en bild i en presentation**

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

## **Föråldrade metoder och deras ersättningar i Modern API**

### **Presentation**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
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
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Metodsignatur | Ersättande metodsignatur |
|---|---|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **API‑stöd för Canvas**

Metoder med [Canvas](https://developer.android.com/reference/android/graphics/Canvas) är förklarade som föråldrade och har ingen direkt Modern API‑ersättning.

Använd Modern API:s bildrenderingsmetoder istället för API:et som renderar till [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Varför togs android.graphics.Canvas bort?**

Stödet för [Canvas](https://developer.android.com/reference/android/graphics/Canvas) är föråldrat i det offentliga API:et för att förena arbete med rendering och bilder, eliminera beroenden på plattforms‑specifika komponenter och gå över till ett plattformsoberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/). Använd `getImage` eller `getImages` istället för att rendera till [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Vilken är den praktiska fördelen med [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) jämfört med [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/) förenar arbete med både raster‑ och vektorbilder och förenklar lagring i olika format via [ImageFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imageformat/).

**Kommer Modern API att påverka prestandan för att generera miniatyrbilder?**

Att gå från `getThumbnail` till `getImage` försämrar inte scenarierna: de nya metoderna erbjuder samma möjligheter att skapa bilder med alternativ och storlekar, samtidigt som de behåller stöd för renderingsalternativ. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna likvärdiga.