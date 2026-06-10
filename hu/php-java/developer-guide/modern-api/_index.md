---
title: "Modern API-val a képfeldolgozás fejlesztése"
linktitle: "Modern API"
type: docs
weight: 237
url: /hu/php-java/modern-api/
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
- PHP
- Aspose.Slides
description: "Modernizálja a dia képfeldolgozást az elavult képalkotó API-k helyettesítésével a PHP Modern API-val a PowerPoint és OpenDocument automatizálás zökkenőmentes megoldásához."
---
## **Bevezetés**

Történelmileg az Aspose Slides függ a java.awt-tól, és a nyilvános API-jában a következő osztályok találhatók ebből:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A 24.4-es verziótól ez a nyilvános API elavultként van jelölve.

Az ezzel a osztályokkal kapcsolatos függőségek megszüntetése érdekében hozzáadtuk a úgynevezett “Modern API”-t – vagyis azt az API-t, amelyet az elavult helyett kell használni, és amelynek aláírásai tartalmazzák a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) függőséget. A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) elavultként van jelölve, és támogatása eltávolításra került a nyilvános Slides API-ból.

A jelenlegi verziókban a java.awt típusokra támaszkodó nyilvános API-t tekintse örökölt/elavultnak. Használja a Modern API-t új kódokhoz és a meglévő képfeldolgozó munkafolyamatok átültetésekor.

## **Modern API**

A következő osztályokat és felsorolásokat adtuk hozzá a nyilvános API-hoz:

- [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) – a raszteres vagy vektorgrafikus képet képviseli.
- [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) – a kép fájlformátumát reprezentálja.
- [Images](https://reference.aspose.com/slides/hu/php-java/aspose.slides/images/) – metódusok az [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) osztály példányosításához és kezeléséhez.

Vedd figyelembe, hogy az [IImage] felszabadítható (használat után el kell dobni).

Használja a `getImage` metódust egyetlen dia vagy alakzat rendereléséhez. Használja a `getImages` metódust több prezentációs dia rendereléséhez. Használja az [Images](https://reference.aspose.com/slides/hu/php-java/aspose.slides/images/) metódusait képek betöltéséhez, az `addImage`-et [IImage]‑vel a prezentációba való hozzáadáshoz, valamint a `replaceImage`-et [IImage]‑vel egy meglévő prezentációs kép frissítéséhez.

Egy tipikus scenárió az új API használatára a következő lehet:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# példányosít egy eldobható IImage példányt a lemezen lévő fájlból.
$image = Images::fromFile("image.png");

# PowerPoint képet hoz létre az IImage példány prezentáció képeihez való hozzáadásával.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# egy kép alakzat hozzáadása az 1. diára
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# lekéri az IImage példányt, amely az 1. diát reprezentálja.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# a kép mentése a lemezre.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Az elavult kód helyettesítése Modern API-val**

Általában le kell cserélni azokat a hívásokat, amelyek a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) és a [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) osztályokat használják, az új, [IImage]‑t használó metódusokra.

Örökölt / elavult API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Dia bélyegkép lekérése**

Örökölt / elavult API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Alakzat bélyegkép lekérése**

Örökölt / elavult API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Prezentáció bélyegkép lekérése**

Örökölt / elavult API:

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

Modern API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Kép hozzáadása a prezentációhoz**

Örökölt / elavult API:

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

Modern API:

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

## **Elavult metódusok és helyettesítőik a Modern API-ban**

### **Presentation**
| Módszignév | Helyettesítő módszignév |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Módszignév | Helyettesítő módszignév |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Módszignév | Helyettesítő módszignév |
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
| Módszignév | Helyettesítő módszignév |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Módszignév | Helyettesítő módszignév |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Módszignév | Helyettesítő módszignév |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Módszignév | Helyettesítő módszignév |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Módszignév | Helyettesítő módszignév |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D támogatás az API-ban**

A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)‑val ellátott metódusok elavultnak vannak jelölve, és nincs közvetlen Modern API helyettesítőjük.

Használja a Modern API képrenderelő metódusait a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)‑ra renderelő API helyett:

[Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **GYIK**

**Miért lett eltávolítva a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

A [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) támogatása elavult a nyilvános API-ban, hogy egységesítsük a renderelést és a képeket, megszüntessük a platformfüggő függőségeket, és egy keresztplatformos megközelítést alkalmazzunk az [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) használatával. Használja a `getImage` vagy `getImages` metódusokat a [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) helyett.

**Mi a gyakorlati előnye az [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/)‑nek a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)‑hez képest?**

Az [IImage] egyesíti a raszteres és vektorgrafikus képek kezelését, és egyszerűsíti a mentést különböző formátumokba a [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) használatával.

**Befolyásolja a Modern API a bélyegképek generálásának teljesítményét?**

A `getThumbnail`‑ról a `getImage`‑re való átállás önmagában nem rontja a teljesítményt: az új metódusok ugyanazokat a lehetőségeket kínálják a képek létrehozására opciókkal és méretekkel, miközben megtartják a renderelési beállítások támogatását. A konkrét nyereség vagy csökkenés a felhasználási esetektől függ, de funkcionálisan a helyettesítések ekvivalensek.