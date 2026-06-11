---
title: "Ulepsz przetwarzanie obrazów za pomocą nowoczesnego API"
linktitle: "Nowoczesne API"
type: docs
weight: 237
url: /pl/java/modern-api/
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
- Java
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe interfejsy API obrazowania nowoczesnym API Java, aby uzyskać płynną automatyzację PowerPoint i OpenDocument."
---
## **Wstęp**

Historycznie Aspose Slides ma zależność od java.awt i posiada w publicznym API następujące klasy z tego pakietu:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od wersji 24.4, to publiczne API zostało oznaczone jako przestarzałe.

Aby pozbyć się zależności od tych klas, dodaliśmy tzw. „Nowoczesne API” – czyli API, które powinno być używane zamiast przestarzałego, którego sygnatury zawierają zależności od [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) został oznaczony jako przestarzały i jego wsparcie zostało usunięte z publicznego API Slides.

Obecnie traktuj publiczne API zależne od typów java.awt jako dziedzictwo/przestarzałe. Używaj Nowoczesnego API dla nowego kodu i przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Dodano następujące klasy i wyliczenia do publicznego API:

- [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Images](https://reference.aspose.com/slides/pl/java/com.aspose.slides/images/) – metody do tworzenia i pracy z interfejsem [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/).

Zwróć uwagę, że [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) jest obiektem podlegającym zwolnieniu i jego użycie powinno być zakończone wywołaniem `dispose()` lub innym wygodnym wzorcem zwalniania.

Użyj `getImage`, aby wyrenderować pojedynczy slajd lub kształt. Użyj `getImages`, aby wyrenderować kilka slajdów prezentacji. Użyj metod z [Images](https://reference.aspose.com/slides/pl/java/com.aspose.slides/images/) do ładowania obrazów, `addImage` z [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) aby dodać je do prezentacji, oraz `replaceImage` z [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // utwórz obiekt IImage, który należy zwolnić, z pliku na dysku.
    IImage image = Images.fromFile("image.png");
    try {
        // utwórz obraz PowerPoint, dodając egzemplarz IImage do obrazów prezentacji.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // dodaj kształt obrazu na slajdzie #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // pobierz egzemplarz IImage reprezentujący slajd #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // zapisz obraz na dysku.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastępowanie starego kodu nowoczesnym API**

Ogólnie rzecz biorąc, będziesz musiał zastąpić wywołania używające [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) i ImageIO nowymi metodami korzystającymi z [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/).

Stare/przestarzałe API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Nowe API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Uzyskiwanie miniatury slajdu**

Stare/przestarzałe API:

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

Nowe API:

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

### **Uzyskiwanie miniatury kształtu**

Stare/przestarzałe API:

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

Nowe API:

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

### **Uzyskiwanie miniatury prezentacji**

Stare/przestarzałe API:

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

Nowe API:

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

### **Dodawanie obrazu do prezentacji**

Stare/przestarzałe API:

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

Nowe API:

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

## **Przestarzałe metody i ich zamienniki w nowoczesnym API**

### **Prezentacja**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Kształt**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slajd**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
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

### **Wyjście**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Sygnatura metody | Sygnatura metody zamiennej |
|------------------|----------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Wsparcie API dla Graphics2D**

Metody z [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) są oznaczone jako przestarzałe i nie mają bezpośredniego zamiennika w nowoczesnym API.

Użyj metod renderowania obrazu z Modern API zamiast API renderującego do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Dlaczego [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) został usunięty?**

Wsparcie dla [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jest przestarzałe w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, usunąć zależności od specyficznych platform oraz przejść na podejście wieloplatformowe z [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/). Użyj `getImage` lub `getImages` zamiast renderowania do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Jaka jest praktyczna korzyść z używania [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) w porównaniu do [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) ujednolica pracę zarówno z obrazami rastrowymi, jak i wektorowymi oraz upraszcza zapisywanie w różnych formatach za pomocą [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/).

**Czy Nowoczesne API wpłynie na wydajność generowania miniatur?**

Przejście z `getThumbnail` na `getImage` nie pogarsza sytuacji: nowe metody zapewniają te same możliwości tworzenia obrazów z opcjami i rozmiarami, zachowując wsparcie dla opcji renderowania. Konkretne zyski lub spadki zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.