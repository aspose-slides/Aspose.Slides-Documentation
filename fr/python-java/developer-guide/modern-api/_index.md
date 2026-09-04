---
title: Améliorer le traitement d'images avec l'API Moderne en Python
linktitle: API Moderne
type: docs
weight: 237
url: /fr/python-java/modern-api/
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
- Python
- Java
- Aspose.Slides
description: "Moderniser le traitement d'images en Python via Java : rendre des diapositives et des formes, ajouter des images, et migrer les appels d'imagerie obsolètes vers l'API Moderne d'Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java accède à la bibliothèque Java via JPype. Son API de traitement d'images hérité utilisait [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) et [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) de `java.awt`.

La bibliothèque Java a déprécié ces API d'imagerie à partir de la version 24.4. L'API Moderne utilise [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) pour charger, rendre et enregistrer les images. Utilisez‑la pour le nouveau code Python et lors de la migration des flux de travail de traitement d'images existants.

{{% alert color="info" title="Note" %}}
Les anciens noms de méthodes ci‑dessous sont des références de migration. Ils ne sont plus disponibles dans les versions actuelles. Les exemples exécutables utilisent l'API Moderne.
{{% /alert %}}

## **API Moderne**

Les principaux types de traitement d'images sont :

- [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) — représente une image matricielle ou vectorielle.
- [ImageFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/) — fournit des constantes de formats de fichiers d'image.
- [Images](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/) — crée des images, par exemple avec [Images.fromFile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/#fromFile).

Utilisez [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) ou [Shape.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) pour rendre une diapositive ou une forme. Utilisez [Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec des options de rendu pour rendre plusieurs diapositives. La surcharge sans arguments renvoie la collection d'images de la présentation à la place.

Chargez une image avec [Images.fromFile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/#fromFile), ajoutez‑la avec [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage), ou mettez à jour une image de présentation existante avec [PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage). Les deux opérations de collection d'images acceptent [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/).

Libérez chaque image que vous chargez ou rendez en appelant sa méthode `dispose` dans un bloc `finally`. Libérez la présentation avec [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose).

### **Préparer l’environnement Python**

Installez les packages comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM. Les exemples laissent la JVM en cours d'exécution afin qu'elle puisse être réutilisée. Consultez [Limitations and API Differences](/slides/fr/python-java/limitations-and-api-differences/#import-the-library) pour des conseils sur le notebook et le cycle de vie de la JVM.

Les exemples qui ouvrent `pres.pptx` nécessitent une présentation dans le répertoire de travail. Les exemples qui chargent `image.png` nécessitent un fichier image existant.

### **Charger une image et rendre une diapositive**

Cet exemple ajoute une image à la première diapositive et enregistre la diapositive au format JPEG. [IImage.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/#save) écrit l'image rendue dans le format spécifié.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Remplacer l’ancien code par l’API Moderne**

Remplacez les appels de vignettes hérités par des méthodes qui retournent [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/), puis enregistrez le résultat avec [IImage.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/#save). Cela supprime la nécessité de transmettre les images rendues à [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Rendre une diapositive à une taille spécifiée**

Remplacez l’appel hérité `slide.getThumbnail(image_size)` par [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) en utilisant la même taille d'image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtention d’une vignette de diapositive**

Remplacez l’appel hérité `slide.getThumbnail()` par [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) sans arguments.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtention d’une vignette de forme**

Remplacez l’appel hérité `shape.getThumbnail()` par [Shape.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage). Vérifiez que la diapositive contient une forme avant d’y accéder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Obtention d’une vignette de présentation**

Remplacez l’appel hérité `presentation.getThumbnails(options, image_size)` par [Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages). Utilisez [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/) pour configurer le rendu.

Itérez directement sur le tableau retourné avec `enumerate` de Python. Libérez chaque image retournée dans un bloc `finally` afin qu’un échec d’enregistrement ne laisse pas les images restantes non libérées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Ajouter une image à une présentation**

Remplacez le chargement via [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) par [Images.fromFile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/#fromFile), puis passez l’image résultante à [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage). Ajoutez l’image à la diapositive et enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Méthodes obsolètes et leur remplacement dans l’API Moderne**

Les tableaux utilisent la notation d’appel Python. Les noms dans la colonne legacy identifient les API supprimées ; utilisez les méthodes de remplacement liées. Les méthodes modernes de rendu d’image retournent des objets [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) au lieu d’images tampon Java.

### **Présentation**

[Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) renvoie un tableau d’images rendues lorsqu’il est appelé avec des options de rendu.

| Appel legacy | Remplacement moderne |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec `options, image_size` |

Ici, `slides` est un `int[]` Java de numéros de diapositives indexés à 1 ; créez‑le avec `jpype.JArray(jpype.JInt)([1, 3])` pour sélectionner les diapositives 1 et 3. `image_size` est un [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Forme**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) sans arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) avec `bounds, scale_x, scale_y` |

### **Diapositive**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) sans arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) avec `image_size` |
| `slide.renderToGraphics(options, graphics)` | Aucun remplacement direct ; rendre vers une image à la place |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Aucun remplacement direct ; rendre vers une image à la place |
| `slide.renderToGraphics(options, graphics, image_size)` | Aucun remplacement direct ; rendre vers une image à la place |

Ici, `options` est [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/), et `tiff_options` est [TiffOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tiffoptions/).

### **Sortie**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/output/#add) avec `path, image`, où `image` est [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagecollection/#addImage) avec un [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) |

### **PPImage**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#getImage) |

Pour remplacer le contenu d’une image de présentation existante, utilisez [PPImage.replaceImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/#replaceImage) avec un [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Appel legacy | Remplacement moderne |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/patternformat/#getTile) avec `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/patternformat/#getTile) avec `background, foreground` |

Les arguments de couleur restent des objets Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Pour les données de motif effectives renvoyées par l’API Java via JPype, la méthode de remplacement conserve le nom `getTileIImage`.

| Appel legacy | Remplacement moderne |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, retournant [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/) |

## **Support de l’API pour Graphics2D**

Les surcharges héritées `renderToGraphics` dessinaient dans un contexte [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) fourni par l’appelant. L’API Moderne n’a aucun remplacement direct qui dessine dans ce contexte.

Utilisez [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) pour rendre une diapositive ou [Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) pour rendre plusieurs diapositives, puis enregistrez les images retournées avec [IImage.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/#save). Les applications qui combinaient le rendu de diapositives avec un dessin Java personnalisé doivent adapter leur étape de composition.

## **FAQ**

**Pourquoi l’ancienne API d’imagerie Java a‑t‑elle été remplacée ?**

L’API Moderne déplace le chargement, le rendu et l’enregistrement d’image vers [IImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/iimage/). Cela fournit une abstraction d’image commune au lieu d’exposer des images tampon Java ou un contexte graphique Java.

**Dois‑je toujours utiliser Java et JPype ?**

Oui. Aspose.Slides for Python via Java s’exécute toujours sur la JVM. L’API Moderne ne change que les appels de traitement d’image, pas les exigences d’exécution. Voir [System Requirements](/slides/fr/python-java/system-requirements/).

**Comment libérer les images en Python ?**

Appelez `dispose` sur chaque image que vous chargez ou rendez dans un bloc `finally`. Si vous rendez plusieurs diapositives, libérez chaque image du tableau retourné. Libérez la présentation séparément avec [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose).

**Le passage à l’API Moderne garantit‑il une génération de vignettes plus rapide ?**

Aucune amélioration de performance n’est garantie. Les remplacements prennent en charge les options de rendu, le redimensionnement et les tailles d’image ; mesurez les performances avec vos présentations et paramètres de sortie.

**Pourquoi le getter d’image renvoie‑il parfois une collection ?**

[Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) sans arguments renvoie les images intégrées de la présentation. Ses surcharges avec des options de rendu renvoient des images de diapositives rendues.