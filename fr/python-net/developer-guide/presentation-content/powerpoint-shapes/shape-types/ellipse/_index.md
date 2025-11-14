---
title: Ajouter des ellipses aux présentations en Python
linktitle: Ellipse
type: docs
weight: 30
url: /fr/python-net/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment créer, formater et manipuler des formes d'ellipse dans Aspose.Slides for Python via .NET pour les présentations PPT, PPTX et ODP — exemples de code inclus."
---


## **Créer une Ellipse**
Dans ce sujet, nous allons introduire les développeurs à l'ajout de formes ellipse à leurs diapositives en utilisant Aspose.Slides pour Python via .NET. Aspose.Slides pour Python via .NET fournit un ensemble d'APIs plus facile à utiliser pour dessiner différents types de formes en quelques lignes de code. Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Obtenez la référence d'une diapositive en utilisant son index
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes
1. Écrivez la présentation modifiée sous forme de fichier PPTX

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse à la première diapositive.

```py
import aspose.slides as slides

# Instanciez la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type ellipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Écrivez le fichier PPTX sur le disque
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Créer une Ellipse Formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le type de remplissage de l'ellipse sur Solide.
1. Définissez la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la couleur des lignes de l'ellipse.
1. Définissez la largeur des lignes de l'ellipse.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciez la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type ellipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Appliquez quelques formats à la forme ellipse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Appliquez quelques formats à la ligne de l'ellipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Écrivez le fichier PPTX sur le disque
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```