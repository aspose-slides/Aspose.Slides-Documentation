---
title: Förbättra bildbehandling med det moderna API:et
linktitle: Moderna API
type: docs
weight: 237
url: /sv/nodejs-java/modern-api/
keywords:
- modernt API
- ritning
- bildsida miniatyr
- bildsida till bild
- form miniatyr
- form till bild
- presentation miniatyr
- presentation till bilder
- lägga till bild
- lägga till bild
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernisera bildbehandling av bildspel genom att ersätta föråldrade bild-API:er med JavaScript Modern API för sömlös PowerPoint- och OpenDocument-automation."
---
## **Introduktion**

Historiskt har Aspose Slides ett beroende på java.awt och har i det offentliga API:et följande klasser därifrån:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Från version 24.4 är detta offentliga API deklarerat som föråldrat.

För att bli av med beroenden på dessa klasser lade vi till det så kallade "Modern API" – dvs. API:et som bör användas i stället för det föråldrade, vars signaturer innehåller beroenden på [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är deklarerat som föråldrat och dess stöd har tagits bort från det offentliga Slides‑API:et.

I nuvarande versioner bör det offentliga API som beror på java.awt‑typer betraktas som legacy/föråldrat. Använd Modern API för ny kod och vid migrering av befintliga bildbehandlingsarbetsflöden.

## **Modern API**

Följande klasser och uppräkningar har lagts till i det offentliga API:et:

- [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) - representerar raster‑ eller vektorbilden.
- [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/) - representerar bildfilens format.
- [Images](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/images/) - metoder för att instansiera och arbeta med klassen [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/).

Observera att [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) är avyttringbar och dess användning bör följas av ett `dispose()`‑anrop eller ett annat bekvämt avyttringsmönster.

Använd `getImage` för att rendera en enskild bild eller form. Använd `getImages` för att rendera flera presentationsbilder. Använd [Images]-metoder för att ladda bilder, `addImage` med [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) för att lägga till dem i en presentation och `replaceImage` med [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) för att uppdatera en befintlig presentationsbild.

Ett typiskt scenario för att använda det nya API:et kan se ut som följer:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // skapa en avyttringbar instans av IImage från filen på disken.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // skapa en PowerPoint-bild genom att lägga till en instans av IImage i presentationens bilder.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // lägg till en bildform på bild #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // hämta en instans av IImage som representerar bild #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // spara bilden på disken.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ersätta gammal kod med Modern API**

Generellt måste du ersätta anrop som använder [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) och [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) med de nya metoderna som använder [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/).

Legacy/föråldrat API:
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

### **Hämta en bild för en bildsida**

Legacy/föråldrat API:

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

### **Hämta en bild för en form**

Legacy/föråldrat API:

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

### **Hämta en bild för en presentation**

Legacy/föråldrat API:

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

### **Lägga till en bild i en presentation**

Legacy/föråldrat API:

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

## **Föråldrade metoder och deras ersättning i Modern API**

### **Presentation**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metodsignatur | Ersättningsmetodsignatur |
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
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metodsignatur | Ersättningsmetodsignatur |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑stöd för Graphics2D**

Metoder med [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är deklarerade som föråldrade och har ingen direkt Modern API‑ersättning.

Använd Modern API:s bildrenderingsmetoder i stället för API:t som renderar till [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Vad är den praktiska fördelen med [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) jämfört med [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) förenar arbete med både raster- och vektorbilder och förenklar sparandet till olika format via [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/).

**Kommer Modern API att påverka prestandan vid generering av miniatyrbilder?**

Att byta från `getThumbnail` till `getImage` försämrar inte scenarierna: de nya metoderna ger samma möjligheter att producera bilder med alternativ och storlekar, samtidigt som stöd för renderingsalternativ behålls. Den specifika vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna ekvivalenta.