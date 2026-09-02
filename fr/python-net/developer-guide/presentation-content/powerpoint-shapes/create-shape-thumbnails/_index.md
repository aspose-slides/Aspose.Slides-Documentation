---
title: "Créer des miniatures de formes de présentation en Python"
linktitle: "Miniatures de formes"
type: docs
weight: 70
url: /fr/python-net/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- représentation de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET – créez et exportez facilement des miniatures de présentations."
---
## **Introduction**

Aspose.Slides for Python via .NET est utilise pour creer des fichiers de presentation ou chaque page est une diapositive. Vous pouvez visualiser ces diapositives dans Microsoft PowerPoint en ouvrant le fichier de presentation. Cependant, les developpeurs peuvent parfois avoir besoin de visualiser separément les images des formes dans un visualiseur d'images. Dans ces cas, Aspose.Slides peut generer des images miniatures pour les formes des diapositives. Cet article explique comment utiliser cette fonctionnalite.

## **Générer des miniatures de forme à partir des diapositives**

Lorsque vous avez besoin d'un aperçu d'un objet specifique plutot que de la diapositive entiere, vous pouvez rendre une miniature pour une forme individuelle. Aspose.Slides vous permet d'exporter n'importe quelle forme en image, facilitant la creation d'aperçus legers, d'icones ou d'actifs pour le traitement en aval.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une reference a une diapositive par son ID ou son indice.
1. Obtenez une reference a une forme sur cette diapositive.
1. Rendez l'image miniature de la forme.
1. Enregistrez l'image miniature au format souhaite.

```py
import aspose.slides as slides

# Instanciez la classe Presentation pour ouvrir le fichier de présentation.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Créez une image avec l'échelle par défaut.
    with shape.get_image() as thumbnail:
        # Enregistrez l'image sur le disque au format PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Générer des miniatures avec un facteur d'echelle personnalise**

Cette section montre comment generer des miniatures de forme avec un facteur d'echelle defini par l'utilisateur dans Aspose.Slides. En controlant l'echelle, vous pouvez ajuster la taille des miniatures pour les aperçus, les exportations ou les ecrans haute resolution.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une diapositive par son ID ou son indice.
1. Obtenez la forme cible sur cette diapositive.
1. Rendez l'image miniature de la forme avec l'echelle specifiee.
1. Enregistrez l'image miniature au format souhaite.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanciez la classe Presentation pour ouvrir le fichier de présentation.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Créez une image avec l'échelle définie.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Enregistrez l'image sur le disque au format PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Générer des miniatures en utilisant les limites d'apparence d'une forme**

Cette section montre comment generer une miniature a l'interieur des limites d'apparence d'une forme. Elle tient compte de tous les effets de forme. La miniature generee est limitee par les limites de la diapositive.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Obtenez une diapositive par son ID ou son indice.
1. Obtenez la forme cible sur cette diapositive.
1. Rendez l'image miniature de la forme avec les limites specifiees.
1. Enregistrez l'image miniature au format d'image souhaite.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanciez la classe Presentation pour ouvrir le fichier de présentation.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Créez une image de forme avec les limites d'apparence.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Enregistrez l'image sur le disque au format PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Obtenir les limites visuelles reelles d'une forme**

Les proprietes du cadre d'une [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) - `Shape.x`, `Shape.y`, `Shape.width` et `Shape.height` - decrivent le rectangle stocke dans le modele de presentation. Le contenu réellement rendu peut s'etendre au-dela de ce cadre ou occuper un rectangle aligne différemment. La rotation, les contours, les têtes de fleche, la disposition et le depassement du texte, la geometrie SmartArt generee et d'autres effets de rendu peuvent tous modifier la zone occupee.

Utilisez [Shape.get_visual_bounds](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_visual_bounds/) pour calculer cette zone occupee sans creer d'image. La methode renvoie un rectangle a virgule flottante dans les coordonnees de la diapositive. Le rectangle renvoye n'est pas decoupe a la diapositive, ses coordonnees peuvent donc etre negatives lorsque le contenu depasse l'origine de la diapositive.

L'exemple suivant recupere et compare le cadre et les limites visuelles :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Le meme rectangle peut etre utilise pour aligner les formes voisines sur son bord `left`, `right`, `top` ou `bottom`; reserver suffisamment d'espace dans une mise en page generee; ou detecter du contenu en dehors d'une zone autorisee. Les limites visuelles sont particulèrement utiles pour SmartArt, les zones de texte, les fleches, les images, les formes tournees et les formes groupees, lorsque le cadre stocke ne represente pas le resultat rendu complet.

Utilisez [Shape.get_visual_bounds](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_visual_bounds/) lorsque vous avez besoin de coordonnees pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [Shape.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_image/) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` dimensionne l'image a partir des limites de la forme, y compris les parametres de contour, tandis que `ShapeThumbnailBounds.APPEARANCE` la dimensionne a partir de l'apparence de la forme et limite le resultat aux limites de la diapositive. En revanche, `Shape.get_visual_bounds` ne renvoie que le rectangle calcule et ne le decoupe pas a la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportees au format vectoriel SVG](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/write_as_svg/) en enregistrant le contenu de la forme en SVG.

**Quelle est la différence entre les limites SHAPE et APPEARANCE lors du rendu d'une miniature ?**

`SHAPE` utilise la geometrie de la forme ; `APPEARANCE` prend en compte les [effets visuels](/slides/fr/python-net/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquee comme masquee ? Sera-t-elle toujours rendue en miniature ?**

Une forme masquee reste partie du modele et peut etre rendue ; le drapeau masque affecte l'affichage du diaporama mais n'empeche pas la generation de l'image de la forme.

**Les formes groupees, les graphiques, SmartArt et d'autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet represente comme [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/) et [SmartArt](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartart/)) peut être enregistre en tant que miniature ou en SVG.

**Les polices installees sur le systeme affectent-elles la qualite des miniatures des formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/python-net/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/python-net/font-substitution/)) afin d'éviter les retours de police indesirables et le rearrangement du texte.