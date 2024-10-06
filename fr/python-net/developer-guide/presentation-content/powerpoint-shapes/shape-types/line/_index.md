---
title: Ligne
type: docs
weight: 50
url: /python-net/line/
keywords: "Ligne, forme PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter une ligne dans une présentation PowerPoint en Python"
---

Aspose.Slides pour Python via .NET prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec des formes en ajoutant des lignes aux diapositives. Grâce à Aspose.Slides pour Python via .NET, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes plus élaborées sur les diapositives.
## **Créer une Ligne Simple**
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) exposée par l'objet Shapes.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```py
import aspose.slides as slides

# Instancier la classe PresentationEx qui représente le fichier PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type ligne
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    #Écrire le PPTX sur le disque
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Créer une Ligne en Forme de Flèche**
Aspose.Slides pour Python via .NET permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour lui donner l'apparence d'une flèche. Veuillez suivre les étapes ci-dessous pour ce faire :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
- Définissez le style de la ligne sur l'un des styles proposés par Aspose.Slides pour Python via .NET.
- Définissez la largeur de la ligne.
- Définissez le [Style de Tiret](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) de la ligne sur l'un des styles proposés par Aspose.Slides pour Python via .NET.
- Définissez le [Style de Tête de Flèche](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) et la longueur du point de départ de la ligne.
- Définissez le Style de Tête de Flèche et la Longueur du point final de la ligne.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe PresentationEx qui représente le fichier PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type ligne
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Appliquer un formatage sur la ligne
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    #Écrire le PPTX sur le disque
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```