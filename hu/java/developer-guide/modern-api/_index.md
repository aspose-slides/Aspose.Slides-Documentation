---
title: Képfeldolgozás fejlesztése a Modern API-val
linktitle: Modern API
type: docs
weight: 237
url: /hu/java/modern-api/
keywords:
- modern API
- rajzolás
- dia bélyegkép
- dia képpé alakítása
- alakzat bélyegkép
- alakzat képpé alakítása
- prezentáció bélyegkép
- prezentáció képekké alakítása
- kép hozzáadása
- kép beillesztése
- Java
- Aspose.Slides
description: "Modernizálja a dia képfeldolgozást az elavult képes API-k Java Modern API-val történő helyettesítésével a zökkenőmentes PowerPoint és OpenDocument automatizálás érdekében."
---
## **Bevezetés**

Történelmileg az Aspose Slides függőségben áll a java.awt-tól, és a nyilvános API-ban a következő osztályok találhatók onnan:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A 24.4-es verziótól ez a nyilvános API elavultként van jelölve.

Az ilyen osztályokkal való függőségek megszüntetése érdekében hozzáadtuk az úgynevezett „Modern API”-t – vagyis azt az API-t, amelyet az elavult helyett kell használni, és amelynek aláírásai függnek a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) osztálytól. A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) elavultként van megjelölve, és támogatása eltávolításra került a nyilvános Slides API-ból.

A jelenlegi verziókban a java.awt típusokra támaszkodó nyilvános API-t tekintse örökölt/elavultnak. Új kódokhoz és a meglévő képfeldolgozási munkafolyamatok migrálásához használja a Modern API-t.

## **Modern API**

A következő osztályok és felsorolások kerültek hozzáadásra a nyilvános API-hoz:

- [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) – a raszter vagy vektor képet képviseli.
- [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) – a kép fájlformátumát képviseli.
- [Images](https://reference.aspose.com/slides/hu/java/com.aspose.slides/images/) – metódusok az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) interfész példányosításához és használatához.

Felhívjuk a figyelmet, hogy az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) eldobható, és használata után `dispose()` hívást vagy más kényelmes erőforrás‑felszabadítási mintát kell alkalmazni.

Használja a `getImage` metódust egyetlen dia vagy alakzat rendereléséhez. Használja a `getImages` metódust több prezentációs dia rendereléséhez. Használja a [Images](https://reference.aspose.com/slides/hu/java/com.aspose.slides/images/) metódusait képek betöltéséhez, a `addImage`‑et az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, és a `replaceImage`‑et az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) segítségével egy meglévő prezentációs kép frissítéséhez.

Egy tipikus szcenárió az új API használatára a következőképpen nézhet ki:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // példányosít egy lebontható IImage példányt a lemezen lévő fájlból.
    IImage image = Images.fromFile("image.png");
    try {
        // létrehozza a PowerPoint képet az IImage példány prezentáció képeihez történő hozzáadásával.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // kép alakzatot ad hozzá az 1. diára
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // lekéri az IImage példányt, amely az 1. diát képviseli.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
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

## **Régi kód cseréje Modern API-val**

Általánosságban a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) és az ImageIO‑t használó hívásokat a [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/)‑t használó új metódusokra kell cserélni.

Örökölt/elavult API:
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

### **Diakép előnézetének lekérése**

Örökölt/elavult API:

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

### **Alakzat előnézetének lekérése**

Örökölt/elavult API:

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

### **Prezentáció előnézetének lekérése**

Örökölt/elavult API:

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

### **Kép hozzáadása a prezentációhoz**

Örökölt/elavult API:

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

## **Elavult metódusok és helyettesítéseik a Modern API-ban**

### **Presentation**
| Metódus aláírás | Helyettesítő metódus aláírás |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Metódus aláírás | Helyettesítő metódus aláírás |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metódus aláírás | Helyettesítő metódus aláírás |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
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
| Metódus aláírás | Helyettesítő metódus aláírás |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metódus aláírás | Helyettesítő metódus aláírás |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metódus aláírás | Helyettesítő metódus aláírás |
|--------------------------------------|------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metódus aláírás | Helyettesítő metódus aláírás |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metódus aláírás | Helyettesítő metódus aláírás |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D API támogatás**

A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) használatával rendelkező metódusok elavultként vannak jelölve, és nincs közvetlen Modern API helyettesítőjük.

Használja a Modern API képrenderelő metódusait a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) felé renderelő API helyett:

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **GYIK**

**Miért lett elvetve a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) támogatása elavult a nyilvános API-ban, hogy egységesítsék a renderelést és a képeket, megszüntessék a platform‑specifikus függőségeket, és egy keresztplatformos megközelítésre váltsanak a [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) segítségével. Használja a `getImage` vagy `getImages` metódusokat a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) felé történő renderelés helyett.

**Mi a gyakorlati előnye a [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) használatának a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) helyett?**

Az [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) egységessé teszi a raszter és vektor képek kezelését, és egyszerűsíti a mentést különböző formátumokba a [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) segítségével.

**A Modern API befolyásolja a bélyegkép generálás teljesítményét?**

A `getThumbnail`‑ről `getImage`‑re való áttérés nem rontja a teljesítményt: az új metódusok ugyanazokat a lehetőségeket biztosítják képek előállításához opciókkal és méretekkel, miközben megtartják a renderelési beállítások támogatását. A konkrét nyereség vagy veszteség a forgatókönyvtől függ, de funkcionálisan a helyettesítők egyenértékűek.