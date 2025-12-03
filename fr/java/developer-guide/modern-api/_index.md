---
title: Améliorer le traitement des images avec l'API moderne
linktitle: API moderne
type: docs
weight: 237
url: /fr/java/modern-api/
keywords:
- API moderne
- dessin
- vignette de diapositive
- diapositive vers image
- vignette de forme
- forme vers image
- vignette de présentation
- présentation vers images
- ajouter image
- ajouter image
- Java
- Aspose.Slides
description: "Modernisez le traitement des images de diapositives en remplaçant les API d'imagerie obsolètes par l'API moderne Java pour une automatisation fluide de PowerPoint et d'OpenDocument."
---

## **Introduction**

Historiquement, Aspose Slides dépend de `java.awt` et expose dans son API publique les classes suivantes provenant de ce package :
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Afin de se débarrasser de ces dépendances, nous avons ajouté ce que l’on appelle l’« API moderne » : l’API qui doit être utilisée à la place de l’ancienne, dont les signatures ne contiennent plus de dépendances à `BufferedImage`. `Graphics2D` est déclaré obsolète et son support est retiré de l’API publique Slides.

Le retrait de l’API publique obsolète dépendante de `System.Drawing` sera effectué dans la version 24.8.

## **API moderne**

Ajout des classes et énumérations suivantes à l’API publique :

- `IImage` – représente l’image raster ou vectorielle.
- `ImageFormat` – représente le format de fichier de l’image.
- `Images` – méthodes pour créer et manipuler l’interface `IImage`.

Veuillez noter que `IImage` est jetable (il implémente l’interface `IDisposable` et son utilisation doit être entourée d’un `using` ou d’une libération explicite).

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ceci :
``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instancier une instance jetable de IImage à partir du fichier sur le disque.
    IImage image = Images.fromFile("image.png");
    try {
        // créer une image PowerPoint en ajoutant une instance de IImage aux images de la présentation.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ajouter une forme d'image sur la diapositive #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtenir une instance de IImage représentant la diapositive #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // enregistrer l'image sur le disque.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Remplacement du code ancien par l’API moderne**

En général, vous devez remplacer l’appel à l’ancienne méthode utilisant `ImageIO` par le nouvel appel.

Ancien :
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```

Nouveau :
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```


### **Obtention d’une vignette de diapositive**

Code utilisant une API obsolète :
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


API moderne :
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


### **Obtention d’une vignette de forme**

Code utilisant une API obsolète :
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


API moderne :
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


### **Obtention d’une vignette de présentation**

Code utilisant une API obsolète :
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


API moderne :
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


### **Ajout d’une image à une présentation**

Code utilisant une API obsolète :
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


API moderne :
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


## **Méthodes à supprimer et leurs remplacements dans l’API moderne**

### **Presentation**
| Signature de méthode                               | Signature de méthode de remplacement                             |
|----------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Signature de méthode                                                      | Signature de méthode de remplacement                                       |
|--------------------------------------------------------------------------|-----------------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                 | public final IImage getImage()                                             |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Signature de méthode                                                      | Signature de méthode de remplacement                                           |
|--------------------------------------------------------------------------|---------------------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                 | public final IImage getImage()                                                 |
| public final BufferedImage getThumbnail(float scaleX, float scaleY)       | public final IImage getImage(float scaleX, float scaleY)                       |
| public final BufferedImage getThumbnail(IRenderingOptions options)        | public final IImage getImage(IRenderingOptions options)                        |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options)                        |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize)   |
| public final BufferedImage getThumbnail(ITiffOptions options)             | public final IImage getImage(ITiffOptions options)                             |
| public final BufferedImage getThumbnail(Dimension imageSize)              | public final IImage getImage(Dimension imageSize)                              |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely  |

### **Output**
| Signature de méthode                                                | Signature de méthode de remplacement                                |
|---------------------------------------------------------------------|---------------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image)     | public final IOutputFile add(String path, IImage image)            |

### **ImageCollection**
| Signature de méthode                          | Signature de méthode de remplacement               |
|-----------------------------------------------|----------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image)      |

### **PPImage**
| Signature de méthode                     | Signature de méthode de remplacement   |
|------------------------------------------|----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage()         |

### **PatternFormat**
| Signature de méthode                                          | Signature de méthode de remplacement                        |
|---------------------------------------------------------------|-------------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)     | public final IImage getTile(Color styleColor)               |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Signature de méthode                                          | Signature de méthode de remplacement                        |
|---------------------------------------------------------------|-------------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Le support de Graphics2D sera interrompu**

Les méthodes utilisant [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sont déclarées obsolètes et leur support sera retiré de l’API publique.

La partie de l’API qui l’emploie sera supprimée :

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Pourquoi `java.awt.Graphics2D` a‑t‑il été abandonné ?**

Le support de `Graphics2D` est retiré de l’API publique afin d’unifier le rendu et la gestion des images, d’éliminer les dépendances spécifiques à la plateforme et d’adopter une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Toutes les méthodes de rendu vers `Graphics2D` seront supprimées.

**Quel est l’avantage pratique de `IImage` par rapport à `BufferedImage` ?**

[IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) unifie la manipulation des images raster et vectorielles et simplifie l’enregistrement dans différents formats via [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/).

**L’API moderne affectera‑t‑elle les performances de génération des vignettes ?**

Passer de `getThumbnail` à `getImage` n’empêche pas les scénarios existants : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant le support des options de rendu. Le gain ou la perte spécifiques dépendent du scénario, mais fonctionnellement les remplacements sont équivalents.