---
title: Förbättra bildbehandling med det moderna API:t
linktitle: Modern API
type: docs
weight: 237
url: /sv/php-java/modern-api/
keywords:
- modernt API
- ritning
- bildspelsminiatyr
- bildspel till bild
- formminiatyr
- form till bild
- presentationsminiatyr
- presentation till bilder
- lägg till bild
- lägg till bild
- PHP
- Aspose.Slides
description: "Modernisera bildspelsbildbehandling genom att ersätta föråldrade bildbehandlings-API:er med PHP Modern API för sömlös PowerPoint- och OpenDocument-automatisering."
---
## **Introduktion**

Historiskt sett har Aspose Slides ett beroende av java.awt och har i det offentliga API:et följande klasser därifrån:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Från och med version 24.4 är detta offentliga API markerat som föråldrat.

För att bli av med beroenden på dessa klasser har vi lagt till det så kallade ”Modern API” – dvs. API:t som ska användas istället för det föråldrade, vars signaturer innehåller beroenden på [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är markerat som föråldrat och dess stöd har tagits bort från det offentliga Slides‑API:et.

I nuvarande versioner bör det offentliga API som beror på java.awt-typer betraktas som arvligt/föråldrat. Använd Modern API för ny kod och när befintliga bildbehandlingsarbetsflöden migreras.

## **Modernt API**

Följande klasser och uppräkningar har lagts till i det offentliga API:et:

- [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) - representerar raster‑ eller vektorbilder.
- [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/) - representerar bildfilens format.
- [Images](https://reference.aspose.com/slides/sv/php-java/aspose.slides/images/) - metoder för att instansiera och arbeta med klassen [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/).

Observera att [IImage] är disposable (den bör avyttras efter användning).

Använd `getImage` för att rendera en enskild bildspelsida eller form. Använd `getImages` för att rendera flera bildspelsidor. Använd [Images](https://reference.aspose.com/slides/sv/php-java/aspose.slides/images/)‑metoder för att läsa in bilder, `addImage` med [IImage] för att lägga till dem i en presentation, och `replaceImage` med [IImage] för att uppdatera en befintlig presentationsbild.

Ett typiskt scenario för att använda det nya API:t kan se ut enligt följande:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instansiera en avyttringbar instans av IImage från filen på disken.
$image = Images::fromFile("image.png");

# skapa en PowerPoint-bild genom att lägga till en instans av IImage i presentationens bilder.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# lägg till en bildform på bildspel #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# hämta en instans av IImage som representerar bildspel #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# spara bilden på disken.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Ersätta gammal kod med Modernt API**

I allmänhet måste du ersätta anrop som använder [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) och [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) med de nya metoderna som använder [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/).

Arvligt/föråldrat API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modernt API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Hämta en bildspelsminiatyr**

Arvligt/föråldrat API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modernt API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Hämta en formminiatyr**

Arvligt/föråldrat API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modernt API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Hämta en presentationsminiatyr**

Arvligt/föråldrat API:

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

Modernt API:

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

### **Lägga till en bild i en presentation**

Arvligt/föråldrat API:

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

Modernt API:

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

## **Förålda metoder och deras ersättningar i Modernt API**

### **Presentation**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------|----------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Form**
| Metodsignatur | Ersättningsmetodsignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Bildspel**
| Metodsignatur | Ersättningsmetodsignatur |
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

### **Utdata**
| Metodsignatur | Ersättningsmetodsignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metodsignatur | Ersättningsmetodsignatur |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metodsignatur | Ersättningsmetodsignatur |
|--------------------------------------|-------------------------------------------|
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

Metoder med [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är markerade som föråldrade och har ingen direkt Modern API‑ersättning.

Använd Modern API‑metoder för bildrendering istället för API:t som renderar till [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Vanliga frågor**

**Varför togs [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bort?**

Stödet för [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) är föråldrat i det offentliga API:t för att förena arbete med rendering och bilder, eliminera beroenden på plattforms‑specifika komponenter samt gå över till ett plattforms‑oberoende tillvägagångssätt med [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/). Använd `getImage` eller `getImages` istället för att rendera till [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Vad är den praktiska fördelen med [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) jämfört med [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/) förenar hantering av både raster‑ och vektorbilder och förenklar sparande till olika format via [ImageFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/imageformat/).

**Kommer Modern API att påverka prestandan vid generering av miniatyrbilder?**

Övergången från `getThumbnail` till `getImage` försämrar inte scenarierna: de nya metoderna ger samma möjligheter att producera bilder med alternativ och storlekar, samtidigt som de behåller stöd för renderingsalternativ. Den konkreta vinsten eller förlusten beror på scenariot, men funktionellt är ersättningarna ekvivalenta.