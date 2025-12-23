---
title: Verbessern Sie die Bildverarbeitung mit der Modernen API
linktitle: Moderne API
type: docs
weight: 237
url: /de/php-java/modern-api/
keywords:
- moderne API
- Zeichnen
- Folienvorschaubild
- Folie zu Bild
- Formvorschaubild
- Form zu Bild
- Präsentationsvorschaubild
- Präsentation zu Bildern
- Bild hinzufügen
- Bild einfügen
- PHP
- Aspose.Slides
description: "Modernisieren Sie die Folienbildverarbeitung, indem Sie veraltete Bild-APIs durch die PHP Moderne API ersetzen, um nahtlose PowerPoint- und OpenDocument-Automatisierung zu ermöglichen."
---

## **Einführung**

Historisch hat Aspose Slides eine Abhängigkeit von java.awt und enthält in der öffentlichen API die folgenden Klassen davon:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Ab Version 24.4 ist diese öffentliche API als veraltet gekennzeichnet.

Um die Abhängigkeiten von diesen Klassen zu entfernen, haben wir die sogenannte „Modern API“ hinzugefügt – also die API, die anstelle der veralteten verwendet werden soll und deren Signaturen Abhängigkeiten von BufferedImage enthalten. Graphics2D ist als veraltet gekennzeichnet und seine Unterstützung wurde aus der öffentlichen Slides‑API entfernt.

Die Entfernung der veralteten öffentlichen API mit Abhängigkeiten von System.Drawing erfolgt in der Version 24.8.

## **Moderne API**

Folgende Klassen und Aufzählungen wurden zur öffentlichen API hinzugefügt:

- IImage – repräsentiert das Raster‑ oder Vektor‑Bild.
- ImageFormat – repräsentiert das Dateiformat des Bildes.
- Images – Methoden zum Instanziieren und Arbeiten mit dem IImage‑Interface.

Bitte beachten Sie, dass IImage entbehrlich ist (es implementiert das IDisposable‑Interface und seine Verwendung sollte in einem using‑Block eingeschlossen oder auf andere geeignete Weise entsorgt werden).

Ein typisches Anwendungsbeispiel der neuen API könnte wie folgt aussehen:
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# Instanziiere eine verwertbare Instanz von IImage aus der Datei auf der Festplatte.
$image = Images::fromFile("image.png");

# Erstelle ein PowerPoint‑Bild, indem du eine IImage‑Instanz zu den Bildern der Präsentation hinzufügst.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# Füge ein Bildobjekt auf Folie #1 hinzu
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# Erhalte eine IImage‑Instanz, die Folie #1 darstellt.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# Speichere das Bild auf der Festplatte.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **Ersetzen alten Codes durch die Moderne API**

Im Allgemeinen müssen Sie den Aufruf der alten Methode, die ImageIO verwendet, durch die neue ersetzen.

Alt:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

Neu:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **Abrufen eines Folien‑Vorschaubildes**

Code mit einer veralteten API:
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


### **Abrufen eines Form‑Vorschaubildes**

Code mit einer veralteten API:
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


### **Abrufen eines Präsentations‑Vorschaubildes**

Code mit einer veralteten API:
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


### **Ein Bild zu einer Präsentation hinzufügen**

Code mit einer veralteten API:
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


## **Methoden, die entfernt werden und ihre Ersatzmethoden in der Modernen API**

### **Presentation**
| Methodensignatur | Ersatz‑Methodensignatur |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Methodensignatur | Ersatz‑Methodensignatur |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Methodensignatur | Ersatz‑Methodensignatur |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

### **Output**
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

## **Die Unterstützung von Graphics2D in der API wird eingestellt**

Methoden mit [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sind als veraltet gekennzeichnet und ihre Unterstützung wird aus der öffentlichen API entfernt.

Der Teil der API, der es verwendet, wird entfernt:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Warum wurde java.awt.Graphics2D entfernt?**

Die Unterstützung für `Graphics2D` wird aus der öffentlichen API entfernt, um die Arbeit mit Rendering und Bildern zu vereinheitlichen, plattformspezifische Abhängigkeiten zu eliminieren und zu einem plattformübergreifenden Ansatz mit [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) zu wechseln. Alle Rendering‑Methoden für `Graphics2D` werden entfernt.

**Welchen praktischen Nutzen bietet IImage im Vergleich zu BufferedImage?**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) vereinheitlicht die Arbeit mit Raster‑ und Vektor‑Bildern und vereinfacht das Speichern in verschiedenen Formaten über [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/).

**Wird die Moderne API die Performance bei der Erstellung von Vorschaubildern beeinflussen?**

Der Wechsel von `getThumbnail` zu `getImage` verschlechtert die Szenarien nicht: Die neuen Methoden bieten dieselben Möglichkeiten zur Erzeugung von Bildern mit Optionen und Größen, während sie die Unterstützung für Rendering‑Optionen beibehalten. Der konkrete Gewinn oder Verlust hängt vom Einzelfall ab, funktional sind die Ersatzmethoden jedoch äquivalent.