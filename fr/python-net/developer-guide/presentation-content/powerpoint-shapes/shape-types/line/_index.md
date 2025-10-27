---
title: Créer des formes de ligne dans les présentations avec Python
linktitle: Ligne
type: docs
weight: 50
url: /fr/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Apprenez à manipuler le format des lignes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET. Découvrez les propriétés, méthodes et exemples."
---

## **Vue d'ensemble**

Aspose.Slides for Python via .NET prend en charge l’ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec les formes en ajoutant des lignes aux diapositives. Avec Aspose.Slides, les développeurs peuvent non seulement créer des lignes simples, mais aussi tracer des lignes plus élaborées sur les diapositives.

## **Créer des lignes simples**

Utilisez Aspose.Slides pour ajouter une ligne simple à une diapositive en tant que séparateur ou connecteur. Pour ajouter une ligne simple à une diapositive sélectionnée dans une présentation, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `LINE` à l’aide de la méthode `add_auto_shape` sur l’objet [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Enregistrez la présentation sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, une ligne est ajoutée à la première diapositive de la présentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer des lignes en forme de flèche**

Aspose.Slides vous permet de configurer les propriétés des lignes pour les rendre plus attrayantes visuellement. Ci‑dessous, nous configurons quelques propriétés d’une ligne pour qu’elle ressemble à une flèche. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type `LINE` à l’aide de la méthode `add_auto_shape` sur l’objet [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Définissez le [style de ligne](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. Définissez la largeur de la ligne.
6. Définissez le [style de tiret](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) de la ligne.
7. Définissez le style et la longueur de la pointe de flèche du point de départ de la ligne.
8. Définissez le style et la longueur de la pointe de flèche du point d’arrivée de la ligne.
9. Enregistrez la présentation sous forme de fichier PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je convertir une ligne ordinaire en connecteur afin qu’elle « s’accroche » aux formes ?**

Non. Une ligne ordinaire (un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) de type [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour qu’elle s’accroche aux formes, utilisez le type dédié [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) et les [API correspondantes](/slides/fr/python-net/connector/) pour les connexions.

**Que faire si les propriétés d’une ligne sont héritées du thème et qu’il est difficile de déterminer les valeurs finales ?**

[Lire les propriétés effectives](/slides/fr/python-net/shape-effective-properties/) via les classes [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/). Elles prennent déjà en compte l’héritage et les styles du thème.

**Puis‑je verrouiller une ligne contre la modification (déplacement, redimensionnement) ?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) qui vous permettent de [interdire les opérations d’édition](/slides/fr/python-net/applying-protection-to-presentation/).