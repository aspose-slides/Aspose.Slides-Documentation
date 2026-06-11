---
title: Ulepsz przetwarzanie obrazów za pomocą nowoczesnego API
linktitle: Nowoczesne API
type: docs
weight: 237
url: /pl/php-java/modern-api/
keywords:
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd na obraz
- miniatura kształtu
- kształt na obraz
- miniatura prezentacji
- prezentacja na obrazy
- dodaj obraz
- dodaj obrazek
- PHP
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe API obrazowania nowoczesnym API PHP, aby zapewnić płynną automatyzację PowerPoint i OpenDocument."
---
## **Wstęp**

Historycznie Aspose Slides ma zależność od java.awt i w publicznym API posiada następujące klasy z tego pakietu:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od wersji 24.4 to publiczne API jest oznaczone jako przestarzałe.

Aby usunąć zależności od tych klas, dodaliśmy tzw. „Nowoczesne API” – czyli API, które powinno być używane zamiast przestarzałego, którego sygnatury zawierają zależności od [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jest oznaczone jako przestarzałe i jego wsparcie zostało usunięte z publicznego API Slides.

W bieżących wersjach publiczne API zależne od typów java.awt należy traktować jako przestarzałe/legacy. Używaj Nowoczesnego API dla nowego kodu oraz przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Do publicznego API dodano następujące klasy i wyliczenia:
- [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) – reprezentuje obraz rastrowy lub wektorowy.
- [ImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/) – reprezentuje format pliku obrazu.
- [Images](https://reference.aspose.com/slides/pl/php-java/aspose.slides/images/) – metody służące do tworzenia i pracy z klasą [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/).

Należy zauważyć, że [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) jest obiektem zwalnianym (powinien być zwolniony po użyciu).

Użyj `getImage`, aby renderować pojedynczy slajd lub kształt. Użyj `getImages`, aby renderować kilka slajdów prezentacji. Użyj metod [Images](https://reference.aspose.com/slides/pl/php-java/aspose.slides/images/), aby wczytać obrazy, `addImage` z [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) aby dodać je do prezentacji, oraz `replaceImage` z [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# utwórz instancję zwalnianego obiektu IImage z pliku na dysku.
$image = Images::fromFile("image.png");

# utwórz obraz PowerPoint, dodając instancję IImage do obrazów prezentacji.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# dodaj kształt obrazu na slajdzie #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# pobierz instancję IImage reprezentującą slajd #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# zapisz obraz na dysku.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Zastępowanie starego kodu nowoczesnym API**

Ogólnie należy zastąpić wywołania używające [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) i [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) nowymi metodami wykorzystującymi [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/).

API przestarzałe/legacy:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Nowoczesne API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Pobieranie miniatury slajdu**

API przestarzałe/legacy:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Nowoczesne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Pobieranie miniatury kształtu**

API przestarzałe/legacy:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Nowoczesne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Pobieranie miniatury prezentacji**

API przestarzałe/legacy:

``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```

Nowoczesne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Dodawanie obrazu do prezentacji**

API przestarzałe/legacy:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

Nowoczesne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```

## **Przestarzałe metody i ich zamienniki w Nowoczesnym API**

### **Presentation**
| Sygnatura metody                               | Sygnatura metody zastępczej                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Sygnatura metody                                                      | Sygnatura metody zastępczej                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Sygnatura metody                                                      | Sygnatura metody zastępczej                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement  |

### **Output**
| Sygnatura metody                                                | Sygnatura metody zastępczej                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Sygnatura metody                          | Sygnatura metody zastępczej               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Sygnatura metody                     | Sygnatura metody zastępcza   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Sygnatura metody                                          | Sygnatura metody zastępcza                        |
|-----------------------------------------------------------|---------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Sygnatura metody                                          | Sygnatura metody zastępcza                        |
|-----------------------------------------------------------|---------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Wsparcie API dla Graphics2D**

Metody z [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) są oznaczone jako przestarzałe i nie mają bezpośredniego zamiennika w Nowoczesnym API.

Użyj metod renderowania obrazów z Nowoczesnego API zamiast API renderującego do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Dlaczego [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) został usunięty?**

Wsparcie dla [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jest przestarzałe w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, wyeliminować powiązania z zależnościami specyficznymi dla platformy oraz przejść na podejście cross‑platform z użyciem [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/). Użyj `getImage` lub `getImages` zamiast renderowania do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Jaka jest praktyczna korzyść z użycia [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) w porównaniu do [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) ujednolica pracę zarówno z obrazami rastrowymi, jak i wektorowymi oraz upraszcza zapisywanie w różnych formatach dzięki [ImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/).

**Czy Nowoczesne API wpłynie na wydajność generowania miniatur?**

Przejście z `getThumbnail` na `getImage` nie pogarsza scenariuszy: nowe metody zapewniają te same możliwości generowania obrazów z opcjami i rozmiarami, zachowując wsparcie dla opcji renderowania. Konkretne zyski lub straty zależą od scenariusza, ale funkcjonalnie zamienniki są równoważne.