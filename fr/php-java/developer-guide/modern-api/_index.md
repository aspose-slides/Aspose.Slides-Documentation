---
title: "Améliorer le traitement d'images avec l'API moderne"
linktitle: "API moderne"
type: docs
weight: 237
url: /fr/php-java/modern-api/
keywords:
- "API moderne"
- "dessin"
- "miniature de diapositive"
- "diapositive en image"
- "miniature de forme"
- "forme en image"
- "miniature de présentation"
- "présentation en images"
- "ajouter une image"
- "ajouter une photo"
- "PHP"
- "Aspose.Slides"
description: "Moderniser le traitement d'images des diapositives en remplaçant les API d'imagerie obsolètes par l'API moderne PHP pour une automatisation fluide de PowerPoint et d'OpenDocument."
---
## **Introduction**

Historiquement, Aspose Slides dépend de java.awt et expose dans son API publique les classes suivantes provenant de ce package :
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Afin de se débarrasser des dépendances à ces classes, nous avons ajouté ce que l’on appelle l’« API moderne » – c’est‑à‑dire l’API qui doit être utilisée à la place de celle obsolète, dont les signatures contiennent des dépendances à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) est déclaré obsolète et son support a été retiré de l’API publique Slides.

Dans les versions actuelles, considérez l’API publique qui dépend des types java.awt comme héritée/obsolète. Utilisez l’API moderne pour le nouveau code et lors de la migration des flux de travail de traitement d’image existants.

## **API moderne**

Les classes et énumérations suivantes ont été ajoutées à l’API publique :
- [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) – représente l’image raster ou vectorielle.
- [ImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/) – représente le format de fichier de l’image.
- [Images](https://reference.aspose.com/slides/fr/php-java/aspose.slides/images/) – méthodes pour instancier et travailler avec la classe [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/).

Notez que [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) est jetable (elle doit être libérée après utilisation).

Utilisez `getImage` pour rendre une seule diapositive ou forme. Utilisez `getImages` pour rendre plusieurs diapositives d’une présentation. Utilisez les méthodes de [Images](https://reference.aspose.com/slides/fr/php-java/aspose.slides/images/) pour charger des images, `addImage` avec [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) pour les ajouter à une présentation, et `replaceImage` avec [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) pour mettre à jour une image existante d’une présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ce qui suit :

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

# ajouter une forme image sur la diapositive #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# obtenir une instance de IImage représentant la diapositive #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# enregistrer l'image sur le disque.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Remplacement du code ancien par l’API moderne**

En général, vous devrez remplacer les appels qui utilisent [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) et [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) par les nouvelles méthodes qui utilisent [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/).

API hérité/obsolète :
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
API moderne :
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **Obtenir une miniature de diapositive**

API hérité/obsolète :
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

### **Obtenir une miniature de forme**

API hérité/obsolète :
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

### **Obtenir une miniature de présentation**

API hérité/obsolète :
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

### **Ajouter une image à une présentation**

API hérité/obsolète :
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

## **Méthodes obsolètes et leurs remplacements dans l’API moderne**

### **Présentation**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Forme**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Diapositive**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
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

### **Sortie**
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

## **Support de l’API pour Graphics2D**

Les méthodes avec [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sont déclarées obsolètes et n’ont pas de remplacement direct dans l’API moderne.

Utilisez les méthodes de rendu d’image de l’API moderne au lieu de l’API qui rend vers [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) :

[Diapositive](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Pourquoi [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) a-t-il été abandonné ?**

Le support de [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) est obsolète dans l’API publique afin d’unifier le travail de rendu et d’images, d’éliminer les dépendances spécifiques à la plateforme, et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/). Utilisez `getImage` ou `getImages` au lieu de rendre vers [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Quel est l’avantage pratique de [IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) par rapport à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ?**

[IImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/iimage/) unifie la manipulation à la fois d’images raster et vectorielles et simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imageformat/).

**Le passage à l’API moderne affectera-t-il les performances de génération de miniatures ?**

Le passage de `getThumbnail` à `getImage` n’altère pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec les options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.