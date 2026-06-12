---
title: Verbeter de beeldverwerking met de Moderne API
linktitle: Moderne API
type: docs
weight: 237
url: /nl/php-java/modern-api/
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
- foto toevoegen
- PHP
- Aspose.Slides
description: "Moderniseer de beeldverwerking van dia's door verouderde beeldverwerkings-API's te vervangen door de PHP Moderne API voor naadloze automatisering van PowerPoint en OpenDocument."
---
## **Inleiding**

Historisch heeft Aspose Slides een afhankelijkheid van java.awt en bevat de openbare API de volgende klassen daarvan:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Vanaf versie 24.4 is deze openbare API als verouderd gemarkeerd.

Om van deze afhankelijkheden af te komen, hebben we de zogenoemde “Modern API” toegevoegd – d.w.z. de API die in plaats van de verouderde moet worden gebruikt, maar waarvan de handtekeningen nog afhankelijk zijn van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) is gemarkeerd als verouderd en de ondersteuning ervan is verwijderd uit de openbare Slides‑API.

In huidige versies moet de openbare API die afhankelijk is van java.awt‑typen als legacy/verouderd worden beschouwd. Gebruik de Modern API voor nieuwe code en bij het migreren van bestaande beeldverwerkings‑workflows.

## **Moderne API**

We hebben de volgende klassen en enumeraties aan de openbare API toegevoegd:

- [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) - representeert de raster‑ of vectorafbeelding.
- [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/) - geeft het bestandsformaat van de afbeelding weer.
- [Images](https://reference.aspose.com/slides/nl/php-java/aspose.slides/images/) - methoden om de [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) klasse te instantieren en ermee te werken.

Opmerking: [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) is disposable (moet na gebruik worden vrijgegeven).

Gebruik `getImage` om een enkele dia of vorm te renderen. Gebruik `getImages` om meerdere presentatie‑dia’s te renderen. Gebruik [Images](https://reference.aspose.com/slides/nl/php-java/aspose.slides/images/) methoden om afbeeldingen te laden, `addImage` met [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) om ze aan een presentatie toe te voegen, en `replaceImage` met [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) om een bestaande presentatie‑afbeelding bij te werken.

Een typisch scenario met de nieuwe API ziet er als volgt uit:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instantieer een disposable instantie van IImage vanaf het bestand op de schijf.
$image = Images::fromFile("image.png");

# maak een PowerPoint‑afbeelding door een instantie van IImage toe te voegen aan de afbeeldingen van de presentatie.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# voeg een afbeelding‑vorm toe op dia #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# verkrijg een instantie van IImage die dia #1 representeert.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# sla de afbeelding op de schijf op.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Oude code vervangen door Moderne API**

In het algemeen moet u oproepen die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) en [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) gebruiken vervangen door de nieuwe methoden die [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) gebruiken.

Legacy/Verouderde API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Moderne API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Miniatuur van een dia ophalen**

Legacy/Verouderde API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Moderne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Miniatuur van een vorm ophalen**

Legacy/Verouderde API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Moderne API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Miniatuur van een presentatie ophalen**

Legacy/Verouderde API:

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

Moderne API:

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

### **Afbeelding toevoegen aan een presentatie**

Legacy/Verouderde API:

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

Moderne API:

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

## **Verouderde methoden en hun vervanging in Moderne API**

### **Presentatie**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Vorm**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Dia**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
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

### **Uitvoer**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodehandtekening | Vervangende methodehandtekening |
|----------------------|---------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑ondersteuning voor Graphics2D**

Methoden met [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) zijn gemarkeerd als verouderd en hebben geen directe Moderne API‑vervanging.

Gebruik de Moderne API‑methoden voor beeldrendering in plaats van de API die naar [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) rendert:

[Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **Veelgestelde vragen**

**Waarom werd [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) verwijderd?**

De ondersteuning voor [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) is verouderd in de openbare API om het werk met renderen en afbeeldingen te verenigen, afhankelijkheden van platform‑specifieke bibliotheken te elimineren en over te stappen naar een platform‑onafhankelijke benadering met [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/). Gebruik `getImage` of `getImages` in plaats van renderen naar [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Wat is het praktische voordeel van [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) ten opzichte van [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) verenigt het werken met zowel raster‑ als vectorafbeeldingen en vereenvoudigt het opslaan naar diverse formaten via [ImageFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/).

**Zal de Moderne API de prestaties van het genereren van miniaturen beïnvloeden?**

Overschakelen van `getThumbnail` naar `getImage` verslechtert de scenario’s niet: de nieuwe methoden bieden dezelfde mogelijkheden om beelden met opties en afmetingen te produceren, terwijl ze de ondersteuning voor render‑opties behouden. Het specifieke winst‑ of verlies‑potentieel hangt af van het scenario, maar functioneel zijn de vervangingen gelijkwaardig.