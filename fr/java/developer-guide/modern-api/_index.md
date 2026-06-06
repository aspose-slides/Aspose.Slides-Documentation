---
title: Améliorer le traitement d'images avec l'API moderne
linktitle: API moderne
type: docs
weight: 237
url: /fr/java/modern-api/
keywords:
- API moderne
- dessin
- miniature de diapositive
- diapositive en image
- miniature de forme
- forme en image
- miniature de présentation
- présentation en images
- ajouter image
- ajouter illustration
- Java
- Aspose.Slides
description: "Modernisez le traitement d'images de diapositives en remplaçant les API d'imagerie obsolètes par l'API Java moderne pour une automatisation fluide de PowerPoint et OpenDocument."
---
## **Introduction**

Historiquement, Aspose Slides dépend de **java.awt** et expose dans son API publique les classes suivantes :
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Depuis la version 24.4, cette API publique est déclarée obsolète.

Pour supprimer les dépendances à ces classes, nous avons ajouté la dite « Modern API » — c’est‑à‑dire l’API qui doit être utilisée à la place de celle marquée obsolète, dont les signatures ne contiennent plus de dépendances à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) est déclaré obsolète et son support est retiré de l’API publique Slides.

Dans les versions actuelles, considérez l’API publique qui dépend des types **java.awt** comme héritée/obsolète. Utilisez la Modern API pour le nouveau code et lors de la migration des flux de traitement d’images existants.

## **Modern API**

Ajout des classes et énumérations suivantes à l’API publique :

- [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) — représente l’image raster ou vectorielle.  
- [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/) — représente le format de fichier de l’image.  
- [Images](https://reference.aspose.com/slides/fr/java/com.aspose.slides/images/) — méthodes pour instancier et manipuler l’interface [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/).

Veuillez noter que [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) est jetable et son utilisation doit être suivie d’un appel à `dispose()` ou d’un autre mode de libération approprié.

Utilisez `getImage` pour rendre une seule diapositive ou forme. Utilisez `getImages` pour rendre plusieurs diapositives d’une présentation. Utilisez les méthodes de [Images](https://reference.aspose.com/slides/fr/java/com.aspose.slides/images/) pour charger des images, `addImage` avec [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) pour les ajouter à une présentation, et `replaceImage` avec [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) pour mettre à jour une image existante d’une présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ceci :

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instancier une instance jetable d'IImage à partir du fichier sur le disque.
    IImage image = Images.fromFile("image.png");
    try {
        // créer une image PowerPoint en ajoutant une instance d'IImage aux images de la présentation.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ajouter une forme image sur la diapositive #1
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

## **Remplacement du code ancien par la Modern API**

En général, vous devrez remplacer les appels qui utilisent [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) et ImageIO par les nouvelles méthodes qui utilisent [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/).

API héritée/obsolète :
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API moderne :
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Obtention d’une miniature de diapositive**

API héritée/obsolète :

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

### **Obtention d’une miniature de forme**

API héritée/obsolète :

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

### **Obtention d’une miniature de présentation**

API héritée/obsolète :

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

API héritée/obsolète :

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

## **Méthodes obsolètes et leurs remplacements dans la Modern API**

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
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

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

## **Prise en charge de Graphics2D par l’API**

Les méthodes utilisant [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sont déclarées obsolètes et n’ont aucun remplacement direct dans la Modern API.

Utilisez les méthodes de rendu d’image de la Modern API à la place de l’API qui rend vers [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) :

[Slide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Pourquoi [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) a‑t‑il été retiré ?**

Le support de [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) est obsolète dans l’API publique afin d’unifier le travail de rendu et d’image, d’éliminer les dépendances spécifiques à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/). Utilisez `getImage` ou `getImages` au lieu de rendre vers [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Quel est l’avantage pratique de [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) par rapport à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ?**

[IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) unifie la manipulation des images raster et vectorielles et simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/).

**La Modern API affectera‑t‑elle les performances de génération des miniatures ?**

Passer de `getThumbnail` à `getImage` n’altère pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.