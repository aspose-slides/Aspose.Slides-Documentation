---
title: Förbättra bildbehandling med det moderna API:t
linktitle: Moderna API
type: docs
weight: 237
url: /sv/java/modern-api/
keywords:
- modernt API
- ritning
- bildruta miniatyr
- bildruta till bild
- form miniatyr
- form till bild
- presentation miniatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- Java
- Aspose.Slides
description: "Modernisera bildbehandling av bildspel genom att ersätta föråldrade bild-API:er med Java Modern API för sömlös PowerPoint- och OpenDocument-automatisering."
---
## **Introduktion**

Historiskt har Aspose Slides ett beroende av java.awt och har i det offentliga API:t följande klasser därifrån:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Från och med version 24.4 är detta offentliga API deklarerat som föråldrat.

För att bli av med beroendet på dessa klasser har vi lagt till det så kallade "Modern API" – dvs. API:t som ska användas i stället för det föråldrade, vars signaturer innehåller beroenden på [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är deklarerat som föråldrat och dess stöd har tagits bort från det offentliga Slides‑API:t.

I de nuvarande versionerna ska det offentliga API:t som är beroende av java.awt‑typer betraktas som ärftligt/föråldrat. Använd Modern API för ny kod och när befintliga bildbehandlingsarbetsflöden migreras.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:t:

- [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) – representerar raster‑ eller vektorbilden.
- [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/) – representerar bildfilens format.
- [Images](https://reference.aspose.com/slides/sv/java/com.aspose.slides/images/) – metoder för att instansiera och arbeta med [IImage]-gränssnittet.

Observera att [IImage] är avyttrbar och dess användning bör följas av ett `dispose()`‑anrop eller ett annat bekvämt avyttringsmönster.

Använd `getImage` för att rendera en enskild bild eller form. Använd `getImages` för att rendera flera presentationsbilder. Använd [Images]-metoder för att läsa in bilder, `addImage` med [IImage] för att lägga till dem i en presentation, och `replaceImage` med [IImage] för att uppdatera en befintlig presentationsbild.

Ett typiskt scenario för att använda det nya API:t kan se ut som följer:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // skapa en avyttrbar instans av IImage från filen på disken.
    IImage image = Images.fromFile("image.png");
    try {
        // skapa en PowerPoint-bild genom att lägga till en IImage-instans till presentationens bilder.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // lägg till en bildform på bildruta #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // hämta en instans av IImage som representerar bildruta #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
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

I allmänhet måste du ersätta anrop som använder [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) och ImageIO med de nya metoderna som använder [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/).

Legacy/föråldrat API:
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

### **Hämta en bildruta‑miniatyr**

Legacy/föråldrat API:

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

### **Hämta en form‑miniatyr**

Legacy/föråldrat API:

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

### **Hämta en presentations‑miniatyr**

Legacy/föråldrat API:

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

### **Lägg till en bild i en presentation**

Legacy/föråldrat API:

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

## **Föråldrade metoder och deras ersättning i Modern API**

### **Presentation**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Ingen ersättning i Modern API |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Ingen ersättning i Modern API |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Ingen ersättning i Modern API |

### **Output**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metodsignatur | Ersättningsmetodsignatur |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metodsignatur | Ersättningsmetodsignatur |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑stöd för Graphics2D**

Metoder med [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är deklarerade som föråldrade och har ingen direkt ersättning i Modern API.

Använd Modern API:s bildrenderingsmetoder i stället för API:t som renderar till [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Vanliga frågor**

**Varför togs [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bort?**

Stödet för [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är föråldrat i det offentliga API:t för att förena arbete med rendering och bilder, eliminera beroenden på plattforms‑specifika komponenter och gå över till ett plattformsoberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/). Använd `getImage` eller `getImages` i stället för att rendera till [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Vad är den praktiska fördelen med [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) jämfört med [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/) förenar arbete med både raster‑ och vektorbilder och förenklar sparande till olika format via [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/).

**Kommer Modern API att påverka prestandan vid generering av miniatyrer?**

Att byta från `getThumbnail` till `getImage` försämrar inte scenarierna: de nya metoderna ger samma möjlighet att producera bilder med alternativ och storlekar, samtidigt som stöd för renderingsalternativ behålls. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna ekvivalenta.