---
title: Verbeter beeldverwerking met de Modern API
linktitle: Moderne API
type: docs
weight: 237
url: /nl/nodejs-java/modern-api/
keywords:
- moderne API
- tekenen
- dia-miniatuur
- dia naar afbeelding
- vorm-miniatuur
- vorm naar afbeelding
- presentatie-miniatuur
- presentatie naar afbeeldingen
- afbeelding toevoegen
- afbeelding invoegen
- Node.js
- JavaScript
- Aspose.Slides
description: "Moderniseer de beeldverwerking van dia's door verouderde beeld-API's te vervangen door de JavaScript Moderne API voor naadloze automatisering van PowerPoint en OpenDocument."
---
## **Inleiding**

Historisch heeft Aspose Slides een afhankelijkheid van java.awt en bevat de openbare API de volgende klassen daarvan:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Vanaf versie 24.4 is deze openbare API gemarkeerd als verouderd.

Om van deze afhankelijkheden af te komen, hebben we de zogenaamde "Modern API" toegevoegd - dat wil zeggen de API die in plaats van de verouderde moet worden gebruikt, waarvan de handtekeningen geen afhankelijkheden meer bevatten van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) is gemarkeerd als verouderd en de ondersteuning ervan is verwijderd uit de openbare Slides API.

In de huidige versies moet u de openbare API die afhankelijk is van java.awt-typen beschouwen als legacy/verouderd. Gebruik de Modern API voor nieuwe code en bij het migreren van bestaande beeldverwerkings-workflows.

## **Modern API**

De volgende klassen en enumeraties zijn toegevoegd aan de openbare API:

- [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) - vertegenwoordigt de raster- of vectorafbeelding.
- [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/) - vertegenwoordigt het bestandsformaat van de afbeelding.
- [Images](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/images/) - methoden om de klasse [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) te instantieren en ermee te werken.

Let op dat [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) disposabel is en dat het gebruik ervan moet worden gevolgd door een `dispose()`-aanroep of een ander handig disposingspatroon.

Gebruik `getImage` om een enkele dia of vorm te renderen. Gebruik `getImages` om meerdere presentatiedia's te renderen. Gebruik de methoden van [Images](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/images/) om afbeeldingen te laden, `addImage` met [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `replaceImage` met [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) om een bestaande presentatie-afbeelding bij te werken.

Een typisch scenario voor het gebruik van de nieuwe API kan er als volgt uitzien:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // instantiateer een wegwerpbare instantie van IImage vanaf het bestand op de schijf.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // maak een PowerPoint-afbeelding door een instantie van IImage toe te voegen aan de afbeeldingen van de presentatie.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // voeg een afbeeldingvorm toe op dia #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // verkrijg een instantie van IImage die dia #1 vertegenwoordigt.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // sla de afbeelding op de schijf op.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vervangen van oude code met Modern API**

Over het algemeen moet u aanroepen die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) en [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) gebruiken vervangen door de nieuwe methoden die [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) gebruiken.

Legacy/deprecated API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Een dia-miniatuur ophalen**

Legacy/deprecated API:

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

Modern API:

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

### **Een vorm-miniatuur ophalen**

Legacy/deprecated API:

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

Modern API:

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

### **Een presentatieminiatuur ophalen**

Legacy/deprecated API:

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

Modern API:

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

### **Een afbeelding aan een presentatie toevoegen**

Legacy/deprecated API:

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

Modern API:

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

## **Verouderde methoden en hun vervanging in Modern API**

### **Presentation**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
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
|---------------------|----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|---------------------|----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **API-ondersteuning voor Graphics2D**

Methoden met [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) zijn gemarkeerd als verouderd en hebben geen directe Modern API-vervanging.

Gebruik de beeldrenderingsmethoden van de Modern API in plaats van de API die rendert naar [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) ten opzichte van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) verenigt het werken met zowel raster- als vectorafbeeldingen en vereenvoudigt het opslaan naar verschillende formaten via [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/).

**Zal de Modern API de prestaties van het genereren van miniaturen beïnvloeden?**

Het overschakelen van `getThumbnail` naar `getImage` verslechtert de scenario's niet: de nieuwe methoden bieden dezelfde mogelijkheden om afbeeldingen te produceren met opties en afmetingen, terwijl de ondersteuning voor renderopties behouden blijft. De specifieke winst of verlies hangt af van het scenario, maar functioneel zijn de vervangingen equivalent.