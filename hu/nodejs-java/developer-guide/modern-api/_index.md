---
title: A képfeldolgozás fejlesztése a Modern API-val
linktitle: Modern API
type: docs
weight: 237
url: /hu/nodejs-java/modern-api/
keywords:
- modern API
- rajzolás
- dia bélyegkép
- dia képpé konvertálás
- forma bélyegkép
- forma képpé konvertálás
- prezentáció bélyegkép
- prezentáció képekké konvertálás
- kép hozzáadása
- kép beillesztése
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernizálja a diasorok képfeldolgozását az elavult kép API-k helyettesítésével a JavaScript Modern API-val, a PowerPoint és OpenDocument automatizálás zökkenőmentes megvalósításához."
---
## **Bevezetés**

Történelmileg az Aspose Slides a java.awt-re támaszkodik, és a nyilvános API-jában a következő osztályok találhatók:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A 24.4-es verziótól ez a nyilvános API elavultnak lett jelölve.

Annak érdekében, hogy megszabaduljunk ezektől a függőségektől, bevezettük a úgynevezett „Modern API”-t – azaz azt az API-t, amelyet a elavult helyett kell használni, és amely aláírásai már nem tartalmazzák a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) függőséget. A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) elavultnak lett nyilvánítva, és támogatása eltávolításra került a nyilvános Slides API-ból.

A jelenlegi verziókban tekintsük a java.awt típusokra épülő nyilvános API-t örököltnek/elavultnak. Használjuk a Modern API-t új kódoknál és a meglévő képfeldolgozó munkafolyamatok átköltöztetésekor.

## **Modern API**

A nyilvános API-hoz a következő osztályok és felsorolások kerültek hozzáadásra:

- [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) – a raszteres vagy vektoros képet képviseli.
- [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) – a kép fájlformátumát jelöli.
- [Images](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/images/) – módszerek az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) osztály példányosításához és kezeléséhez.

Kérjük, vegye figyelembe, hogy az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) eldobható, és használata után egy `dispose()` hívást vagy más megfelelő eldobási mintát kell alkalmazni.

Használja a `getImage` metódust egyetlen dia vagy alakzat rendereléséhez. A `getImages` metódus több prezentációs dia renderelésére szolgál. Használja az [Images](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/images/) módszereket képek betöltéséhez, a `addImage`-et az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) segítségével a prezentációhoz való hozzáadáshoz, és a `replaceImage`-et az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) segítségével egy meglévő prezentációs kép frissítéséhez.

Egy tipikus példa az új API használatára a következő lehet:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // példányosít egy eldobható IImage példányt a lemezen lévő fájlból.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // létrehozzon egy PowerPoint képet egy IImage példány prezentáció képeihez való hozzáadásával.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // helyezzen egy kép alakzatot az 1. diára
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // szerezzen egy IImage példányt, amely az 1. diát képviseli.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // mentse a képet a lemezre.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Régi kód cseréje Modern API-val**

Általánosságban ki kell cserélni azokat a hívásokat, amelyek a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) és a [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) osztályokat használják, az új módszerekre, amelyek az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) osztályt használják.

Örökölt/elavult API:
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

### **Dia bélyegkép lekérése**

Örökölt/elavult API:

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

### **Forma bélyegkép lekérése**

Örökölt/elavult API:

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

### **Prezentáció bélyegkép lekérése**

Örökölt/elavult API:

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

### **Kép hozzáadása a prezentációhoz**

Örökölt/elavult API:

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

## **Elavult metódusok és helyettesítőik a Modern API-ban**

### **Presentation**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metódus aláírás | Helyettesítő metódus aláírás |
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
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metódus aláírás | Helyettesítő metódus aláírás |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API támogatás a Graphics2D-hez**

A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) használatával ellátott metódusok elavultnak vannak nyilvánítva, és nincs közvetlen Modern API helyettesítőjük.

Használja a Modern API képrenderelési metódusait a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) felé irányuló API helyett:

[Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **GYIK**

**Mi a gyakorlati előnye az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) használatának a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)-hez képest?**

Az [IImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/iimage/) egységesíti a raszteres és vektoros képek kezelését, és egyszerűsíti a különböző formátumokba való mentést a [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) segítségével.

**A Modern API befolyásolja a bélyegképek generálásának teljesítményét?**

A `getThumbnail`-ról `getImage`-re való átállás nem rontja a helyzetet: az új módszerek ugyanazokat a képalkotási lehetőségeket és méreteket biztosítják, miközben megőrzik a renderelési opciók támogatását. A konkrét nyereség vagy csökkenés a szituációtól függ, de funkcionálisan a helyettesítők ekvivalensek.