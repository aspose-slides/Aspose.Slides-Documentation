---
title: "Améliorer le traitement d'images avec l'API Moderne"
linktitle: "API Moderne"
type: docs
weight: 237
url: /fr/php-java/modern-api/
keywords:
- "API Moderne"
- "dessin"
- "miniature de diapositive"
- "diapositive en image"
- "miniature de forme"
- "forme en image"
- "miniature de présentation"
- "présentation en images"
- "ajouter une image"
- "ajouter une image"
- PHP
- Aspose.Slides
description: "Modernisez le traitement des images de diapositive en remplaçant les API d'imagerie obsolètes par l'API Moderne PHP pour une automatisation fluide de PowerPoint et OpenDocument."
---

## **Introduction**

Historiquement, Aspose Slides dépend de java.awt et expose dans son API publique les classes suivantes provenant de ce package :
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Depuis la version 24.4, cette API publique est déclarée obsolète.

Afin d’éliminer les dépendances à ces classes, nous avons ajouté ce que l’on appelle l’« API Moderne » – c’est‑à‑dire l’API qui doit être utilisée à la place de celle déclarée obsolète, dont les signatures contiennent des dépendances à BufferedImage. Graphics2D est déclaré obsolète et son support est retiré de l’API publique Slides.

La suppression de l’API publique obsolète contenant des dépendances à System.Drawing sera réalisée dans la version 24.8.

## **Modern API**

Ajout des classes et énumérations suivantes à l’API publique :

- IImage – représente l’image raster ou vectorielle.
- ImageFormat – représente le format de fichier de l’image.
- Images – méthodes pour instancier et travailler avec l’interface IImage.

Veuillez noter que IImage est jetable (elle implémente l’interface IDisposable et son utilisation doit être encapsulée dans un using ou être disposée d’une autre manière pratique).

Un scénario typique d’utilisation de la nouvelle API peut ressembler à :
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# instancier une instance jetable de IImage à partir du fichier sur le disque.
$image = Images::fromFile("image.png");

# créer une image PowerPoint en ajoutant une instance de IImage aux images de la présentation.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# ajouter une forme d'image sur la diapositive #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# obtenir une instance de IImage représentant la diapositive #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# enregistrer l'image sur le disque.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **Replacing Old Code with Modern API**

En général, vous devrez remplacer l’appel à l’ancienne méthode utilisant ImageIO par la nouvelle.

Old:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

New:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **Obtention d’une miniature de diapositive**

Code utilisant une API obsolète :
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```


API moderne :
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```


### **Obtention d’une miniature de forme**

Code utilisant une API obsolète :
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```


API moderne :
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```


### **Obtention d’une miniature de présentation**

Code utilisant une API obsolète :
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


API moderne :
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


### **Ajout d’une image à une présentation**

Code utilisant une API obsolète :
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


API moderne :
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


## **Methods to Be Removed and Their Replacement in Modern API**

### **Presentation**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
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
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API Support for Graphics2D Will Be Discontinued**

Les méthodes utilisant [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sont déclarées obsolètes et leur support sera retiré de l’API publique.

La partie de l’API qui l’utilise sera supprimée :

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Pourquoi java.awt.Graphics2D a-t-il été supprimé ?**

Le support de `Graphics2D` est retiré de l’API publique afin d’unifier le travail de rendu et d’image, d’éliminer les dépendances propres à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). Toutes les méthodes de rendu vers `Graphics2D` seront supprimées.

**Quel est l’avantage pratique d’IImage par rapport à BufferedImage ?**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) unifie la gestion des images raster et vectorielles et simplifie l’enregistrement dans différents formats via [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/).

**L’API moderne affectera-t-elle les performances de génération des miniatures ?**

Passer de `getThumbnail` à `getImage` ne détériore pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifiques dépendent du scénario, mais fonctionnellement les remplacements sont équivalents.