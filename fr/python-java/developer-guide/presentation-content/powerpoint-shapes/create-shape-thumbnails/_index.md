---
title: Créer des miniatures de formes de présentation en Python via Java
linktitle: Miniatures de forme
type: docs
weight: 70
url: /fr/python-java/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint avec Aspose.Slides pour Python via Java – créez et exportez facilement des miniatures de présentation."
---
## **Introduction**

Aspose.Slides for Python via Java peut être utilisé pour créer des fichiers de présentation dans lesquels chaque page correspond à une diapositive. Les diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Cependant, les développeurs ont parfois besoin de voir les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides for Python via Java les aide à générer des images miniatures des formes de la diapositive.

Cet article explique comment générer des miniatures de forme de différentes manières :

- Générer une miniature de forme à l'intérieur d'une diapositive.
- Générer une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature de forme dans les limites de l'apparence d'une forme.

## **Générer une miniature de forme à partir d'une diapositive**
Pour générer une miniature de forme à partir de n'importe quelle diapositive avec Aspose.Slides for Python via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive en utilisant son ID ou son indice.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) d'une forme sur la diapositive référencée à l'échelle par défaut.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple montre comment générer une miniature de forme à partir d'une diapositive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instancier une classe Presentation qui représente le fichier de présentation.
presentation = Presentation("Thumbnail.pptx")
try:
    # Créer une image à l'échelle réelle.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Enregistrer l'image sur le disque au format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Générer une miniature avec un facteur d'échelle défini par l'utilisateur**
Pour générer la miniature de forme d'une diapositive avec Aspose.Slides for Python via Java, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive en utilisant son ID ou son indice.
1. [Obtenez l'image miniature de la forme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) d'une forme sur la diapositive référencée avec des dimensions définies par l'utilisateur.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple montre comment générer une miniature de forme basée sur un facteur d'échelle défini :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instancier une classe Presentation qui représente le fichier de présentation.
presentation = Presentation("Thumbnail.pptx")
try:
    # Créer une image mise à l'échelle d'un facteur 2 dans les deux directions.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Enregistrer l'image sur le disque au format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Créer une miniature d'apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature d'une forme de diapositive à l'intérieur des limites de son apparence, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive en utilisant son ID ou son indice.
1. Obtenez l'image miniature d'une forme sur la diapositive référencée en utilisant ses limites d'apparence.
1. Enregistrez l'image miniature dans le format d'image de votre choix.

Ce code d'exemple est basé sur les étapes ci‑dessus :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instancier une classe Presentation qui représente le fichier de présentation.
presentation = Presentation("Thumbnail.pptx")
try:
    # Créer une image à l'échelle réelle.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Enregistrer l'image sur le disque au format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) — ses méthodes [getX](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getWidth) et [getHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getHeight) — décrivent le rectangle stocké dans le modèle de présentation. Le contenu réellement rendu peut dépasser ce cadre ou occuper un rectangle aligné sur les axes différent. La rotation, les contours, les pointes de flèches, la disposition du texte et le débordement, la géométrie SmartArt générée et d'autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getVisualBounds) pour calculer cette zone occupée sans créer d'image. La méthode renvoie un [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) dans les coordonnées de la diapositive. Le rectangle renvoyé n'est pas découpé selon la diapositive, de sorte que ses coordonnées peuvent être négatives lorsque le contenu dépasse l'origine de la diapositive.

L'exemple suivant obtient et compare les limites de cadre et les limites visuelles :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Le même [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) peut être utilisé pour aligner les formes voisines à son bord gauche, droit, supérieur ou inférieur ; réserver suffisamment d'espace dans une mise en page générée ; ou détecter du contenu hors d'une région autorisée. Les limites visuelles sont particulièrement utiles pour les SmartArt, les zones de texte, les flèches, les images, les formes tournées et les formes groupées, où le cadre stocké peut ne pas représenter le rendu complet.

Utilisez [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getVisualBounds) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [Shape.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapethumbnailbounds/#Shape) dimensionne l'image à partir des limites de la forme, y compris les paramètres de contour, tandis que [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapethumbnailbounds/#Appearance) la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [Shape.getVisualBounds](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getVisualBounds) ne renvoie que le rectangle calculé et ne le découpe pas selon la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en SVG vectoriel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#writeAsSvgToBytes) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/python-java/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme masquée ? Sera‑t‑elle toujours rendue en tant que miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, les graphiques, SmartArt et d'autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/), et [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/)) peut être enregistré en tant que miniature ou en SVG.

**Les polices installées sur le système affectent‑elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/python-java/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/python-java/font-substitution/)) pour éviter les substitutions indésirables et le re‑flux du texte.