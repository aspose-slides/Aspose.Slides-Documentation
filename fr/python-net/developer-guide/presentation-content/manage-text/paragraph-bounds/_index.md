---
title: Obtenir les limites des paragraphes à partir de présentations en Python
linktitle: Limites des paragraphes
type: docs
weight: 43
url: /fr/python-net/paragraph-bounds/
keywords:
- limites de paragraphe
- coordonnées de paragraphe
- taille de paragraphe
- cadre de texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes dans Aspose.Slides pour Python via .NET afin d'optimiser le positionnement du texte dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer le rectangle d’un paragraphe à partir d’une [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) en utilisant [Paragraph.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/get_rect/), comment obtenir les coordonnées du paragraphe à l’intérieur d’un cadre de texte de cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l’effet du retour à la ligne sur les limites, la conversion en pixels et les valeurs de mise en forme de paragraphe « effectives ».

## **Obtenir les coordonnées rectangulaires d’un paragraphe**

Utilisez [Paragraph.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/get_rect/) pour obtenir le rectangle englobant d’un paragraphe.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Obtenir la taille d’un paragraphe à l’intérieur d’un cadre de texte de cellule de tableau**

Pour obtenir la taille et les coordonnées d’un [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/) dans un cadre de texte de cellule de tableau, utilisez [Paragraph.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/get_rect/). Le rectangle renvoyé est relatif au cadre de texte de la cellule du tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin des coordonnées au niveau de la diapositive.

L’exemple suivant récupère les limites du paragraphe à l’intérieur d’une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont‑elles mesurées ?**

Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s’applique à toutes les coordonnées et dimensions de la diapositive.

**L’ajustement du texte affecte‑t‑il les limites d’un paragraphe ?**

Oui. Si [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/wrap_text/) est activé pour le [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/), le texte se coupe pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être converties de façon fiable en pixels dans l’image exportée ?**

Oui. Convertissez les points en pixels en utilisant la formule suivante : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l’héritage des styles ?**

Utilisez la [structure de données de mise en forme effective du paragraphe](/slides/fr/python-net/shape-effective-properties/) ; elle renvoie les valeurs finales consolidées pour les retraits, l’espacement, le retour à la ligne, le sens RTL et plus encore.