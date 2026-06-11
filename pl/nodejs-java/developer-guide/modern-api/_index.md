---
title: Ulepsz przetwarzanie obrazów za pomocą Modern API
linktitle: Nowoczesne API
type: docs
weight: 237
url: /pl/nodejs-java/modern-api/
keywords:
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd do obrazu
- miniatura kształtu
- kształt do obrazu
- miniatura prezentacji
- prezentacja do obrazów
- dodaj obraz
- dodaj zdjęcie
- Node.js
- JavaScript
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe API obrazowania nowoczesnym API JavaScript, aby uzyskać płynną automatyzację PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Historycznie Aspose Slides ma zależność od java.awt i w publicznym API posiada następujące klasy z tej biblioteki:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od wersji 24.4 to publiczne API zostało oznaczone jako przestarzałe.

Aby pozbyć się zależności od tych klas, dodaliśmy tzw. “Modern API” – czyli API, które powinno być używane zamiast przestarzałego, którego sygnatury zawierają zależności od [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jest oznaczone jako przestarzałe i jego wsparcie zostało usunięte z publicznego API Slides.

W bieżących wersjach traktuj publiczne API zależne od typów java.awt jako przestarzałe/legacy. Używaj Modern API w nowym kodzie oraz przy migracji istniejących przepływów przetwarzania obrazów.

## **Modern API**

Dodano następujące klasy i wyliczenia do publicznego API:

- [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Images](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/images/) – metody do tworzenia i pracy z klasą [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/).

Należy zauważyć, że [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) jest obiektem, który należy zwolnić i jego użycie powinno być zakończone wywołaniem `dispose()` lub innym wygodnym wzorcem zwalniania.

Użyj `getImage`, aby wyrenderować pojedynczy slajd lub kształt. Użyj `getImages`, aby wyrenderować kilka slajdów prezentacji. Użyj metod z [Images](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/images/) do ładowania obrazów, `addImage` z [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) aby dodać je do prezentacji oraz `replaceImage` z [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // utwórz instancję IImage, którą można zwolnić, z pliku na dysku.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // utwórz obraz PowerPoint, dodając instancję IImage do obrazów prezentacji.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // dodaj kształt obrazu na slajdzie nr 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // pobierz instancję IImage reprezentującą slajd nr 1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // zapisz obraz na dysku.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastępowanie starego kodu Modern API**

Ogólnie rzecz biorąc, będziesz musiał zamienić wywołania korzystające z [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) i [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) na nowe metody używające [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/).

Starsze/przestarzałe API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Nowoczesne API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Uzyskiwanie miniatury slajdu**

Starsze/przestarzałe API:

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

Nowoczesne API:

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

### **Uzyskiwanie miniatury kształtu**

Starsze/przestarzałe API:

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

Nowoczesne API:

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

### **Uzyskiwanie miniatury prezentacji**

Starsze/przestarzałe API:

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

Nowoczesne API:

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

### **Dodawanie obrazu do prezentacji**

Starsze/przestarzałe API:

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

Nowoczesne API:

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

## **Przestarzałe metody i ich zamienniki w Modern API**

### **Presentation**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Podpis metody | Podpis metody zastępczej |
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
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Podpis metody | Podpis metody zastępczej |
|---|---|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Obsługa Graphics2D w API**

Metody wykorzystujące [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) zostały oznaczone jako przestarzałe i nie mają bezpośredniego zamiennika w Modern API.

Użyj metod renderowania obrazów z Modern API zamiast API renderującego do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Jaką praktyczną korzyść daje [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) w porównaniu do [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) ujednolica pracę zarówno z obrazami rastrowymi, jak i wektorowymi oraz upraszcza zapisywanie w różnych formatach za pomocą [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/).

**Czy Modern API wpłynie na wydajność generowania miniatur?**

Przejście z `getThumbnail` na `getImage` nie pogarsza scenariuszy: nowe metody zapewniają te same możliwości generowania obrazów z opcjami i rozmiarami, zachowując jednocześnie obsługę opcji renderowania. Konkretne zyski lub straty zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.