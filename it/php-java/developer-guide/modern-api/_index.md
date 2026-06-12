---
title: "Migliora l'elaborazione delle immagini con l'API Moderna"
linktitle: "API Moderna"
type: docs
weight: 237
url: /it/php-java/modern-api/
keywords:
- "API moderna"
- disegno
- "miniatura diapositiva"
- "diapositiva in immagine"
- "miniatura forma"
- "forma in immagine"
- "miniatura presentazione"
- "presentazione in immagini"
- "aggiungi immagine"
- "aggiungi foto"
- PHP
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging deprecate con l'API Moderna PHP per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

Storicamente, Aspose Slides dipende da java.awt e nell'API pubblica ha le seguenti classi da lì:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partire dalla versione 24.4, questa API pubblica è dichiarata deprecata.

Per eliminare le dipendenze da queste classi, abbiamo aggiunto quella che viene chiamata "Modern API" - ovvero l'API da utilizzare al posto di quella deprecata, le cui firme contengono dipendenze da [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) è dichiarata deprecata e il suo supporto è stato rimosso dall'API pubblica di Slides.

Nelle versioni attuali, trattare l'API pubblica che dipende dai tipi java.awt come legacy/deprecata. Utilizzare la Modern API per nuovo codice e quando si migra i workflow di elaborazione delle immagini esistenti.

## **API Moderna**

Aggiunte le seguenti classi ed enum all'API pubblica:

- [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) - rappresenta l'immagine raster o vettoriale.
- [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/) - rappresenta il formato file dell'immagine.
- [Images](https://reference.aspose.com/slides/it/php-java/aspose.slides/images/) - metodi per istanziare e lavorare con la classe [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/).

Nota che [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) è disposable (deve essere rilasciata dopo l'uso).

Utilizza `getImage` per renderizzare una singola diapositiva o forma. Utilizza `getImages` per renderizzare più diapositive della presentazione. Utilizza i metodi di [Images](https://reference.aspose.com/slides/it/php-java/aspose.slides/images/) per caricare le immagini, `addImage` con [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) per aggiungerle a una presentazione, e `replaceImage` con [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) per aggiornare un'immagine esistente nella presentazione.

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instanzia un'istanza disposable di IImage dal file sul disco.
$image = Images::fromFile("image.png");

# crea un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# aggiungi una forma immagine sulla diapositiva #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# ottieni un'istanza di IImage che rappresenta la diapositiva #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# salva l'immagine su disco.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Sostituire il Codice Obsoleto con l'API Moderna**

In generale, sarà necessario sostituire le chiamate che usano [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) con i nuovi metodi che utilizzano [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/).

API legacy/deprecata:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
API Moderna:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Ottenere una Miniatura della Diapositiva**

API legacy/deprecata:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **Ottenere una Miniatura della Forma**

API legacy/deprecata:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

API Moderna:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **Ottenere una Miniatura della Presentazione**

API legacy/deprecata:

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

API Moderna:

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

### **Aggiungere un'Immagine a una Presentazione**

API legacy/deprecata:

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

API Moderna:

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

## **Metodi Deprecati e la Loro Sostituzione nell'API Moderna**

### **Presentation**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
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
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del Metodo | Firma del Metodo di Sostituzione |
|------------------|----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Supporto API per Graphics2D**

Metodi con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sono dichiarati deprecati e non hanno una sostituzione diretta nella Modern API.

Utilizza i metodi di rendering delle immagini della Modern API invece dell'API che renderizza su [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Perché è stata rimossa [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

Il supporto per [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) è deprecato nell'API pubblica per unificare il lavoro di rendering e immagini, eliminare i legami a dipendenze specifiche di piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/). Usa `getImage` o `getImages` invece di renderizzare su [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Qual è il beneficio pratico di [IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) rispetto a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/iimage/) unifica il lavoro con immagini raster e vettoriali e semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/imageformat/).

**La Modern API influenzerà le prestazioni nella generazione delle miniature?**

Il passaggio da `getThumbnail` a `getImage` non peggiora gli scenari: i nuovi metodi offrono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.