---
title: Créer des miniatures de formes de présentation en Python
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/python-net/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Générez des miniatures de haute qualité des formes à partir de diapositives PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET – créez et exportez facilement des miniatures de présentations."
---

## **Introduction**

Aspose.Slides for Python via .NET est utilisé pour créer des fichiers de présentation dans lesquels chaque page est une diapositive. Vous pouvez visualiser ces diapositives dans Microsoft PowerPoint en ouvrant le fichier de présentation. Cependant, les développeurs ont parfois besoin de voir les images des formes séparément dans un visualiseur d’images. Dans ces cas, Aspose.Slides peut générer des images miniatures pour les formes des diapositives. Cet article explique comment utiliser cette fonctionnalité.

## **Générer des miniatures de formes à partir de diapositives**

Lorsque vous avez besoin d’un aperçu d’un objet spécifique plutôt que de la diapositive entière, vous pouvez rendre une miniature pour une forme individuelle. Aspose.Slides vous permet d’exporter n’importe quelle forme vers une image, ce qui facilite la création d’aperçus légers, d’icônes ou d’actifs pour le traitement en aval.

Pour générer une miniature à partir de n’importe quelle forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son ID ou son index.
1. Obtenez une référence à une forme sur cette diapositive.
1. Rendu de l’image miniature de la forme.
1. Enregistrez l’image miniature dans le format souhaité.

L’exemple ci‑dessous génère une miniature de forme.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create a image with the default scale.
    with shape.get_image() as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Générer des miniatures avec un facteur d'échelle personnalisé**

Cette section montre comment générer des miniatures de forme avec un facteur d’échelle défini par l’utilisateur dans Aspose.Slides. En contrôlant l’échelle, vous pouvez ajuster la taille de la miniature pour les aperçus, les exportations ou les écrans haute densité.

Pour générer une miniature pour n’importe quelle forme sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une diapositive par son ID ou son index.
1. Obtenez la forme cible sur cette diapositive.
1. Rendu de l’image miniature de la forme avec l’échelle spécifiée.
1. Enregistrez l’image miniature dans le format souhaité.

L’exemple ci‑dessous génère une miniature avec un facteur d’échelle défini par l’utilisateur.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create an image with the defined scale.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Générer des miniatures en utilisant les limites d'apparence d'une forme**

Cette section montre comment générer une miniature à l’intérieur des limites d’apparence d’une forme. Elle prend en compte tous les effets de la forme. La miniature générée est limitée par les limites de la diapositive.

Pour générer une miniature de n’importe quelle forme de diapositive à l’intérieur des limites de son apparence :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une diapositive par son ID ou son index.
1. Obtenez la forme cible sur cette diapositive.
1. Rendu de l’image miniature de la forme avec les limites spécifiées.
1. Enregistrez l’image miniature dans le format d’image souhaité.

L’exemple ci‑dessous crée une miniature avec des limites définies par l’utilisateur.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Create an appearance-bounds shape image.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Quels formats d’image peuvent être utilisés lors de l’enregistrement des miniatures de formes ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), et d’autres. Les formes peuvent également être [exportées au format vectoriel SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) en enregistrant le contenu de la forme en SVG.

**Quelle est la différence entre les limites SHAPE et APPEARANCE lors du rendu d’une miniature ?**

`SHAPE` utilise la géométrie de la forme ; `APPEARANCE` prend en compte les [effets visuels](/slides/fr/python-net/shape-effect/) (ombres, lueurs, etc.).

**Que se passe‑t‑il si une forme est marquée comme cachée ? Sera‑t‑elle toujours rendue en miniature ?**

Une forme cachée reste partie du modèle et peut être rendue ; le drapeau caché affecte l’affichage du diaporama mais n’empêche pas la génération de l’image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont‑ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), et [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système influent‑elles sur la qualité des miniatures des formes texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/python-net/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/python-net/font-substitution/)) pour éviter des substitutions indésirables et des réarrangements de texte.