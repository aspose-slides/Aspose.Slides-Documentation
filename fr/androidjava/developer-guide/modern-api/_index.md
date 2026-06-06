---
title: "Améliorer le traitement d'images avec l'API Moderne"
linktitle: "API Moderne"
type: docs
weight: 237
url: /fr/androidjava/modern-api/
keywords:
- android.graphics
- "API moderne"
- dessin
- "vignette de diapositive"
- "diapositive vers image"
- "vignette de forme"
- "forme vers image"
- "vignette de présentation"
- "présentation vers images"
- "ajouter image"
- "ajouter image"
- Android
- Java
- Aspose.Slides
description: "Modernisez le traitement d'images de diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne Java pour une automatisation fluide de PowerPoint et OpenDocument."
---
## **Introduction**

Historiquement, Aspose Slides dépend de `android.graphics` et expose dans son API publique les classes suivantes provenant de ce package :
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Depuis la version 24.4, cette API publique est déclarée obsolète.

Pour éliminer les dépendances envers ces classes, nous avons ajouté ce que l’on appelle l’« API Moderne » — c’est‑à‑dire l’API qui doit être utilisée à la place de celle obsolète, dont les signatures contiennent des dépendances à [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) est déclaré obsolète et son support est supprimé de l’API publique de Slides.

Dans les versions actuelles, considérez l’API publique qui dépend des types `android.graphics` comme héritée/obsolète. Utilisez l’API Moderne pour le nouveau code et lors de la migration des flux de traitement d’images existants.

## **Modern API**

Ajout des classes et énumérations suivantes à l’API publique :

- [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) – représente l’image raster ou vectorielle.  
- [ImageFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imageformat/) – représente le format de fichier de l’image.  
- [Images](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/images/) – méthodes pour instancier et manipuler l’interface [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/).

Veuillez noter que [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) est jetable et son utilisation doit être suivie d’un appel `dispose()` ou d’un autre schéma de libération pratique.

Utilisez `getImage` pour rendre une diapositive ou une forme unique. Utilisez `getImages` pour rendre plusieurs diapositives de la présentation. Utilisez les méthodes de [Images](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/images/) pour charger des images, `addImage` avec [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) pour les ajouter à une présentation, et `replaceImage` avec [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) pour mettre à jour une image existante de la présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ce qui suit :

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

    // obtenir une instance d'IImage représentant la diapositive #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

## **Replacing Old Code with Modern API**

En général, vous devrez remplacer les appels utilisant [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) par les nouvelles méthodes utilisant [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/).

Legacy/deprecated API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Getting a Slide Thumbnail**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

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

### **Getting a Shape Thumbnail**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

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

### **Getting a Presentation Thumbnail**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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

### **Adding a Picture to a Presentation**

Legacy/deprecated API:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

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

## **Deprecated Methods and Their Replacement in Modern API**

### **Presentation**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|-------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **API Support for Canvas**

Les méthodes avec [Canvas](https://developer.android.com/reference/android/graphics/Canvas) sont déclarées obsolètes et n’ont aucune remise directe dans l’API Moderne.

Utilisez les méthodes de rendu d’image de l’API Moderne à la place de l’API qui rend vers [Canvas](https://developer.android.com/reference/android/graphics/Canvas) :

[Slide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Why was android.graphics.Canvas dropped?**  
**Pourquoi android.graphics.Canvas a‑t‑il été retiré ?**

Le support de [Canvas](https://developer.android.com/reference/android/graphics/Canvas) est obsolète dans l’API publique afin d’unifier le travail de rendu et d’image, d’éliminer les dépendances propres à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/). Utilisez `getImage` ou `getImages` au lieu de rendre vers [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**What is the practical benefit of [IImage] compared to [Bitmap]?**  
**Quel est l’avantage pratique de [IImage] comparé à [Bitmap] ?**

[IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) unifie la manipulation des images raster et vectorielles et simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imageformat/).

**Will the Modern API affect the performance of generating thumbnails?**  
**L’API Moderne aura‑t‑elle un impact sur les performances de génération de vignettes ?**

Passer de `getThumbnail` à `getImage` ne détériore pas les scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifique dépend du scénario, mais fonctionnellement les remplacements sont équivalents.