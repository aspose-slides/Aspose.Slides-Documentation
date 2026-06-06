---
title: Améliorer le traitement d'images avec l'API Moderne
linktitle: API Moderne
type: docs
weight: 237
url: /fr/nodejs-java/modern-api/
keywords:
- API moderne
- dessin
- vignette de diapositive
- diapositive en image
- vignette de forme
- forme en image
- vignette de présentation
- présentation en images
- ajouter image
- ajouter image
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernisez le traitement d'images des diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne JavaScript pour une automatisation fluide de PowerPoint et OpenDocument."
---
## **Introduction**

Historiquement, Aspose Slides dépend de java.awt et expose dans son API publique les classes suivantes provenant de ce package :
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Afin de se débarrasser des dépendances à ces classes, nous avons ajouté ce que l’on appelle « Modern API » – c’est‑à‑dire l’API qui doit être utilisée à la place de celle‑dépréciée, dont les signatures contiennent des dépendances à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) est déclaré obsolète et son support est supprimé de l’API publique Slides.

Dans les versions actuelles, considérez l’API publique dépendant des types java.awt comme héritée/obsolète. Utilisez la Modern API pour le nouveau code et lors de la migration des flux de travail de traitement d’images existants.

## **Modern API**

Les classes et énumérations suivantes ont été ajoutées à l’API publique :
- [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) - représente l’image raster ou vectorielle.
- [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/) - représente le format de fichier de l’image.
- [Images](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/images/) - méthodes permettant d’instancier et de travailler avec la classe [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/).

Veuillez noter que [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) est jetable et son utilisation doit être suivie d’un appel à `dispose()` ou d’un autre modèle de libération pratique.

Utilisez `getImage` pour rendre une seule diapositive ou forme. Utilisez `getImages` pour rendre plusieurs diapositives de la présentation. Utilisez les méthodes [Images](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/images/) pour charger des images, `addImage` avec [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) pour les ajouter à une présentation, et `replaceImage` avec [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) pour mettre à jour une image existante de la présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à :

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // instancier une instance jetable d'IImage à partir du fichier sur le disque.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // créer une image PowerPoint en ajoutant une instance d'IImage aux images de la présentation.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ajouter une forme image sur la diapositive n°1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // obtenir une instance d'IImage représentant la diapositive n°1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // enregistrer l'image sur le disque.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remplacement du code ancien par la Modern API**

En général, vous devrez remplacer les appels qui utilisent [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) et [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) par les nouvelles méthodes qui utilisent [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/).

API héritée/obsolète :
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
API moderne :
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Obtention d’une miniature de diapositive**

API héritée/obsolète :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderne :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtention d’une miniature de forme**

API héritée/obsolète :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderne :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obtention d’une miniature de présentation**

API héritée/obsolète :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API moderne :

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ajout d’une image à une présentation**

API héritée/obsolète :

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API moderne :

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
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
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

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

## **Prise en charge de Graphics2D dans l’API**

Les méthodes utilisant [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sont déclarées obsolètes et n’ont aucun remplacement direct dans la Modern API.

Utilisez les méthodes de rendu d’images de la Modern API à la place de l’API qui rend vers [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) :

[Slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Quel est l’avantage pratique de [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) par rapport à [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ?**

[IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) unifie la manipulation des images raster et vectorielles et simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/).

**La Modern API affectera‑t‑elle les performances de génération des miniatures ?**

Passer de `getThumbnail` à `getImage` ne détériore pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de génération d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.