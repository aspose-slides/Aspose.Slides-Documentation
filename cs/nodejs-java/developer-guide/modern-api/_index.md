---
title: Vylepšete zpracování obrázků pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 237
url: /cs/nodejs-java/modern-api/
keywords:
- moderní API
- kreslení
- náhled snímku
- snímek na obrázek
- náhled tvaru
- tvar na obrázek
- náhled prezentace
- prezentace na obrázky
- přidat obrázek
- přidat obrázek
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých imaging API moderním JavaScript API pro plynulou automatizaci PowerPoint a OpenDocument."
---
## **Úvod**

Historicky má Aspose Slides závislost na java.awt a v veřejném API obsahuje následující třídy z této knihovny:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Abychom se zbavili závislostí na těchto třídách, přidali jsme takzvané „Moderní API“ – tj. API, které by mělo být používáno místo zastaralého, jehož podpisy obsahují závislosti na [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) je označeno jako zastaralé a jeho podpora je odstraněna z veřejného Slides API.

V aktuálních verzích považujte veřejné API závislé na typech java.awt za legacy/zastaralé. Používejte Moderní API pro nový kód i při migraci stávajících workflow zpracování obrázků.

## **Moderní API**

Do veřejného API byly přidány následující třídy a výčty:

- [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [Images](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/images/) – metody pro vytvoření a práci s třídou [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/).

Všimněte si, že [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) je disposable a po jeho použití by měl následovat volání `dispose()` nebo jiný vhodný vzor uvolnění zdrojů.

Použijte `getImage` k vykreslení jedné snímku nebo tvaru. Použijte `getImages` k vykreslení několika snímků prezentace. Použijte metody z [Images](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/images/) pro načtení obrázků, `addImage` s [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) pro jejich přidání do prezentace a `replaceImage` s [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat takto:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // vytvořit odhazovatelnou instanci IImage ze souboru na disku.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // vytvořit obrázek PowerPoint přidáním instance IImage do obrázků prezentace.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // přidat obrázkový tvar na snímek #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // získat instanci IImage představující snímek #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // uložit obrázek na disk.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nahrazení starého kódu Moderním API**

Obecně budete muset nahradit volání, která používají [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) a [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html), novými metodami, které používají [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/).

Legacy/zastaralé API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Moderní API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Získání náhledu snímku**

Legacy/zastaralé API:

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

Moderní API:

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

### **Získání náhledu tvaru**

Legacy/zastaralé API:

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

Moderní API:

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

### **Získání náhledu prezentace**

Legacy/zastaralé API:

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

Moderní API:

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

### **Přidání obrázku do prezentace**

Legacy/zastaralé API:

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

Moderní API:

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

## **Zastaralé metody a jejich náhrada v Moderním API**

### **Prezentace**
| Podpis metody | Podpis nahrazovací metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Tvar**
| Podpis metody | Podpis nahrazovací metody |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Snímek**
| Podpis metody | Podpis nahrazovací metody |
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

### **Výstup**
| Podpis metody | Podpis nahrazovací metody |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Podpis metody | Podpis nahrazovací metody |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Podpis metody | Podpis nahrazovací metody |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Podpis metody | Podpis nahrazovací metody |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Podpis metody | Podpis nahrazovací metody |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Podpora API pro Graphics2D**

Metody s [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

Používejte metody Moderního API pro vykreslování obrázků místo API, které vykresluje do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **Často kladené otázky**

**Jaká je praktická výhoda [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) oproti [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrázky a zjednodušuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/).

**Ovlivní Moderní API výkon generování náhledů?**

Přechod z `getThumbnail` na `getImage` nesnižuje výkon v žádném scénáři: nové metody poskytují stejné možnosti pro vytváření obrázků s volbami a rozměry, přičemž zachovávají podporu vykreslovacích možností. Konkrétní zisk nebo ztráta závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.