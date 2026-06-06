---
title: Verbesserung der Bildverarbeitung mit der Modernen API
linktitle: Moderne API
type: docs
weight: 237
url: /de/php-java/modern-api/
keywords:
- Moderne API
- Zeichnen
- Folienminiatur
- Folie zu Bild
- Formminiatur
- Form zu Bild
- Präsentationsminiatur
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- PHP
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die PHP Moderne API ersetzen, um nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---
## **Einleitung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und stellt in der öffentlichen API die folgenden Klassen davon bereit:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 ist diese öffentliche API als veraltet gekennzeichnet.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir die sogenannte „Moderne API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden soll und deren Signaturen nicht von [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) abhängen. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ist als veraltet markiert und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

In aktuellen Versionen sollte die öffentliche API, die von java.awt‑Typen abhängt, als veraltet/Legacy behandelt werden. Verwenden Sie die Moderne API für neuen Code und beim Migrieren bestehender Bildverarbeitungs‑Workflows.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden der öffentlichen API hinzugefügt:

- [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) - stellt das Raster‑ oder Vektorbild dar.
- [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/) - gibt das Dateiformat des Bildes an.
- [Images](https://reference.aspose.com/slides/de/php-java/aspose.slides/images/) - Methoden zum Instanziieren und Arbeiten mit der Klasse [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/).

Beachten Sie, dass [IImage] freigebbar ist (es sollte nach der Verwendung entsorgt werden).

Verwenden Sie `getImage`, um eine einzelne Folie oder Form zu rendern. Verwenden Sie `getImages`, um mehrere Präsentationsfolien zu rendern. Verwenden Sie die Methoden von [Images](https://reference.aspose.com/slides/de/php-java/aspose.slides/images/), um Bilder zu laden, `addImage` mit [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) zum Hinzufügen zu einer Präsentation und `replaceImage` mit [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) zum Aktualisieren eines vorhandenen Präsentationsbildes.

Ein typisches Szenario der Nutzung der neuen API kann wie folgt aussehen:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# Instanziiere eine freigebbare Instanz von IImage aus der Datei auf der Festplatte.
$image = Images::fromFile("image.png");

# Erstelle ein PowerPoint-Bild, indem eine Instanz von IImage zu den Bildern der Präsentation hinzugefügt wird.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# Füge eine Bildform auf Folie #1 hinzu
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# Hole eine Instanz von IImage, die Folie #1 darstellt.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# Speichere das Bild auf der Festplatte.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Ersetzen von altem Code durch die Moderne API**

Im Allgemeinen müssen Sie Aufrufe, die [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) und [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) verwenden, durch die neuen Methoden ersetzen, die [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) nutzen.

Veraltete API:
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

### **Abrufen einer Folien‑Miniatur**

Veraltete API:

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

### **Abrufen einer Form‑Miniatur**

Veraltete API:

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

### **Abrufen einer Präsentations‑Miniatur**

Veraltete API:

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

### **Hinzufügen eines Bildes zu einer Präsentation**

Veraltete API:

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

## **Veraltete Methoden und deren Ersatz in der Modernen API**

### **Präsentation**
| Methodensignatur | Ersatz‑Methodensignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Form**
| Methodensignatur | Ersatz‑Methodensignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Folie**
| Methodensignatur | Ersatz‑Methodensignatur |
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

### **Ausgabe**
| Methodensignatur | Ersatz‑Methodensignatur |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Methodensignatur | Ersatz‑Methodensignatur |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Methodensignatur | Ersatz‑Methodensignatur |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Methodensignatur | Ersatz‑Methodensignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Methodensignatur | Ersatz‑Methodensignatur |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API‑Unterstützung für Graphics2D**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet deklariert und haben keinen direkten Ersatz in der Modernen API.

Verwenden Sie die bildrendernden Methoden der Modernen API anstelle der API, die nach [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) rendert:

[Slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Warum wurde [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) entfernt?**

Die Unterstützung für [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ist in der öffentlichen API veraltet, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) zu wechseln. Verwenden Sie `getImage` oder `getImages` anstelle des Renderns nach [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Welchen praktischen Nutzen bietet [IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) im Vergleich zu [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/iimage/) vereint die Arbeit mit Raster‑ und Vektor‑Bildern und vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/imageformat/).

**Wird die Moderne API die Leistung bei der Erzeugung von Miniatur‑Bildern beeinträchtigen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten die gleichen Möglichkeiten zur Bildgenerierung mit Optionen und Größen, während sie weiterhin Rendering‑Optionen unterstützen. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersatzmethoden jedoch gleichwertig.