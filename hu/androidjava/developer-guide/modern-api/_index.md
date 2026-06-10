---
title: "Fejlessze a képfeldolgozást a Modern API-val"
linktitle: "Modern API"
type: docs
weight: 237
url: /hu/androidjava/modern-api/
keywords:
- android.graphics
- modern API
- rajzolás
- dia bélyegkép
- dia képbe
- alakzat bélyegkép
- alakzat képbe
- prezentáció bélyegkép
- prezentáció képekké
- kép hozzáadása
- kép beillesztése
- Android
- Java
- Aspose.Slides
description: "Modernizálja a diákképek feldolgozását elavult képi API-k helyettesítésével a Java Modern API-val a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Történelmileg az Aspose Slides függ a android.graphics-tól, és a nyilvános API-jában a következő osztályok találhatók onnan:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

A 24.4-es verziótól kezdve ez a nyilvános API elavultnak van nyilvánítva.

Az ilyen osztályokhoz való függőségek megszüntetése érdekében hozzáadtuk az úgynevezett "Modern API"-t – vagyis az API-t, amelyet a deprecated helyett kell használni, és amelynek aláírásai függnek a [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)-tól. A [Canvas](https://developer.android.com/reference/android/graphics/Canvas) elavultnak van nyilvánítva, és támogatása eltávolításra került a nyilvános Slides API-ból.

Az aktuális verziókban a android.graphics típusokra támaszkodó nyilvános API-t tekintse örököltnek/elavultnak. Új kódhoz és a meglévő képfeldolgozó munkafolyamatok átmigrálásához használja a Modern API-t.

## **Modern API**

A következő osztályokat és felsorolásokat adtuk hozzá a nyilvános API-hoz:

- [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) – a raszteres vagy vektorgrafikus képet képviseli.
- [ImageFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/) – a kép fájlformátumát jelöli.
- [Images](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/images/) – módszerek az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) interfész példányosításához és használatához.

Felhívjuk a figyelmet, hogy az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) felszabadítható, és használata után `dispose()` hívást vagy más kényelmes erőforrás-felszabadítási mintát kell alkalmazni.

Használja a `getImage` metódust egyetlen dia vagy alakzat rendereléséhez. A `getImages` metódus több diát renderel. Használja az [Images](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/images/) metódusait a képek betöltéséhez, a `addImage`-et az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/)‑el a prezentációhoz való hozzáadáshoz, és a `replaceImage`-et az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/)‑el egy meglévő prezentációs kép frissítéséhez.

Egy tipikus szituáció az új API használatára a következőképpen nézhet ki:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // példányosít egy felszabadítható IImage példányt a lemezen lévő fájlból.
    IImage image = Images.fromFile("image.png");
    try {
        // létrehoz egy PowerPoint képet az IImage példány prezentáció képeihez való hozzáadásával.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // képes alakzatot ad hozzá az 1. diára
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // lekér egy IImage példányt, amely az 1. diát képviseli.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // elmenti a képet a lemezre.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **A régi kód cseréje a Modern API-val**

Általánosságban a [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) használatával történő hívásokat az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/)‑et használó új metódusokra kell cserélni.

Legacy/elavult API:
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

### **Dia bélyegkép lekérése**

Legacy/elavult API:

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

### **Alakzat bélyegkép lekérése**

Legacy/elavult API:

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

### **Prezentáció bélyegkép lekérése**

Legacy/elavult API:

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

### **Kép hozzáadása a prezentációhoz**

Legacy/elavult API:

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

## **Elavult metódusok és helyettesítéseik a Modern API-ban**

### **Presentation**
| Metódus aláírás                               | Helyettesítő metódus aláírás                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Metódus aláírás                                                      | Helyettesítő metódus aláírás                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metódus aláírás                                                      | Helyettesítő metódus aláírás                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement  |

### **Output**
| Metódus aláírás                                                | Helyettesítő metódus aláírás                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metódus aláírás                          | Helyettesítő metódus aláírás               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metódus aláírás                     | Helyettesítő metódus aláírás   |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metódus aláírás                                          | Helyettesítő metódus aláírás                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor)   | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Metódus aláírás                                          | Helyettesítő metódus aláírás                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Canvas támogatás az API-ban**

Az [Canvas](https://developer.android.com/reference/android/graphics/Canvas) használatával rendelkező metódusok elavultnak vannak nyilvánítva, és nincs közvetlen Modern API helyettesítőjük.

Használja a Modern API kép-renderelési metódusait a [Canvas](https://developer.android.com/reference/android/graphics/Canvas) felé renderelő API helyett:

[Slide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Miért került a android.graphics.Canvas mellőzésre?**

Az [Canvas](https://developer.android.com/reference/android/graphics/Canvas) támogatása elavult a nyilvános API-ban, hogy egységesítsük a renderelést és a képek kezelését, megszüntessük a platformfüggő függőségeket, és a [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) felé való átállást egy cross-platform megközelítéssel. Használja a `getImage` vagy `getImages` metódusokat a [Canvas](https://developer.android.com/reference/android/graphics/Canvas) helyett.

**Mi a gyakorlati előnye az [IImage] használatának a [Bitmap]-hez képest?**

Az [IImage] egységesíti a raszteres és vektorgrafikus képek kezelését, és egyszerűsíti a különféle formátumokba való mentést a [ImageFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/) segítségével.

**A Modern API befolyásolja a bélyegképek generálásának teljesítményét?**

A `getThumbnail`-ról `getImage`-re való áttérés nem rontja a teljesítményt: az új metódusok ugyanazt a funkcionalitást biztosítják képek előállításához opciókkal és méretekkel, miközben megőrzik a renderelési beállítások támogatását. A konkrét nyereség vagy veszteség a szituációtól függ, de funkcionálisan a helyettesítők egyenértékűek.