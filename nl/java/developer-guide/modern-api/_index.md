---
title: Verbeter beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 237
url: /nl/java/modern-api/
keywords:
- moderne API
- tekenen
- dia-miniatuurfoto
- dia naar afbeelding
- vorm-miniatuurfoto
- vorm naar afbeelding
- presentatie-miniatuurfoto
- presentatie naar afbeeldingen
- afbeelding toevoegen
- foto toevoegen
- Java
- Aspose.Slides
description: "Moderniseer de verwerking van dia-afbeeldingen door verouderde beeld-API's te vervangen door de Java Moderne API voor naadloze automatisering van PowerPoint en OpenDocument."
---
## **Introductie**

Historisch gezien heeft Aspose Slides een afhankelijkheid van java.awt en bevat de openbare API de volgende klassen daarvan:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Vanaf versie 24.4 wordt deze openbare API gemarkeerd als verouderd.

Om van deze afhankelijkheden af te komen, hebben we de zogenoemde “Moderne API” toegevoegd – dat wil zeggen de API die in plaats van de verouderde moet worden gebruikt, waarvan de handtekeningen afhankelijk zijn van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) is gemarkeerd als verouderd en de ondersteuning ervan is uit de openbare Slides‑API verwijderd.

In de huidige versies wordt de openbare API die afhankelijk is van java.awt‑typen behandeld als legacy/verouderd. Gebruik de Moderne API voor nieuwe code en bij het migreren van bestaande beeldverwerkings‑workflows.

## **Moderne API**

De volgende klassen en enumeraties zijn toegevoegd aan de openbare API:

- [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) – vertegenwoordigt de raster‑ of vectorafbeelding.
- [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/) – vertegenwoordigt het bestandsformaat van de afbeelding.
- [Images](https://reference.aspose.com/slides/nl/java/com.aspose.slides/images/) – methoden om een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) instantie te maken en ermee te werken.

Let op: [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) is disposable en het gebruik ervan dient te worden gevolgd door een `dispose()`‑aanroep of een ander geschikt disposalkader.

Gebruik `getImage` om één dia of vorm te renderen. Gebruik `getImages` om meerdere presentatiedia’s te renderen. Gebruik [Images](https://reference.aspose.com/slides/nl/java/com.aspose.slides/images/)‑methoden om afbeeldingen te laden, `addImage` met [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `replaceImage` met [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) om een bestaande presentatie‑afbeelding bij te werken.

Een typisch scenario van gebruik van de nieuwe API kan er als volgt uitzien:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // maak een disposable instantie van IImage van het bestand op schijf.
    IImage image = Images.fromFile("image.png");
    try {
        // creëer een PowerPoint-afbeelding door een IImage-instantie toe te voegen aan de afbeeldingen van de presentatie.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // voeg een foto-vorm toe op dia #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // verkrijg een instantie van de IImage die dia #1 vertegenwoordigt.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // sla de afbeelding op schijf op.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Oude code vervangen door Moderne API**

In het algemeen moet u aanroepen die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) en ImageIO gebruiken, vervangen door de nieuwe methoden die [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) gebruiken.

Legacy/verouderde API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Moderne API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Een dia‑miniatuurfoto ophalen**

Legacy/verouderde API:

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

### **Een vorm‑miniatuurfoto ophalen**

Legacy/verouderde API:

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

### **Een presentaties‑miniatuurfoto ophalen**

Legacy/verouderde API:

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

### **Een afbeelding aan een presentatie toevoegen**

Legacy/verouderde API:

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

## **Verouderde methoden en hun vervanging in Moderne API**

### **Presentation**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodehandtekening | Vervangende methodehandtekening |
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
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodehandtekening | Vervangende methodehandtekening |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑ondersteuning voor Graphics2D**

Methoden met [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) zijn gemarkeerd als verouderd en hebben geen directe Moderne API‑vervanging.

Gebruik de Moderne API‑methoden voor beeldrenderen in plaats van de API die naar [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) rendert:

[Slide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Veelgestelde vragen**

**Waarom is [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) verwijderd?**

Ondersteuning voor [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) is verouderd in de openbare API om het werk met renderen en afbeeldingen te uniformiseren, afhankelijkheden van platform‑specifieke componenten te elimineren en over te stappen op een cross‑platform benadering met [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/). Gebruik `getImage` of `getImages` in plaats van renderen naar [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) ten opzichte van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vectorafbeeldingen en vereenvoudigt het opslaan naar diverse formaten via [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/).

**Zal de Moderne API de prestaties van het genereren van miniaturen beïnvloeden?**

Overschakelen van `getThumbnail` naar `getImage` verslechtert de scenario’s niet: de nieuwe methoden bieden dezelfde mogelijkheden om afbeeldingen met opties en afmetingen te produceren, terwijl de ondersteuning voor renderopties behouden blijft. De specifieke winst of verlies hangt af van het scenario, maar functioneel zijn de vervangingen gelijkwaardig.