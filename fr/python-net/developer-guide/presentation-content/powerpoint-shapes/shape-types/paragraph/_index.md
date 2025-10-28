---
title: Obtenir les limites du paragraphe à partir des présentations en Python
linktitle: Paragraphe
type: docs
weight: 60
url: /fr/python-net/paragraph/
keywords:
- limites de paragraphe
- limites de portion de texte
- coordonnées de paragraphe
- coordonnées de portion
- taille du paragraphe
- taille de portion de texte
- cadre de texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes et des portions de texte dans Aspose.Slides for Python via .NET afin d'optimiser le positionnement du texte dans les présentations PowerPoint et OpenDocument."
---

## **Obtenir les coordonnées du paragraphe et de la portion dans TextFrame**
En utilisant Aspose.Slides for Python via .NET, les développeurs peuvent désormais obtenir les coordonnées rectangulaires d’un **Paragraph** dans la collection de paragraphes d’un **TextFrame**. Cela permet également d’obtenir les coordonnées d’une **Portion** dans la collection de portions d’un paragraphe. Dans cet article, nous allons démontrer, à l’aide d’un exemple, comment obtenir les coordonnées rectangulaires d’un paragraphe ainsi que la position d’une portion à l’intérieur d’un paragraphe.

## **Obtenir les coordonnées rectangulaires du paragraphe**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d’obtenir le rectangle des limites du paragraphe.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obtenir la taille du paragraphe et de la portion à l'intérieur d'un cadre de texte de cellule de tableau** ##

Pour obtenir la taille et les coordonnées du [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) ou du [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) dans le cadre de texte d’une cellule de tableau, vous pouvez utiliser les méthodes [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) et [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Ce code d'exemple illustre l'opération décrite :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**Dans quelles unités les coordonnées retournées pour un paragraphe et les portions de texte sont‑elles mesurées ?**

En points, où 1 pouce = 72 points. Cela s'applique à toutes les coordonnées et dimensions sur la diapositive.

**Le retour à la ligne affecte‑t‑il les limites d'un paragraphe ?**

Oui. Si le [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) est activé dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), le texte se casse pour s’adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent‑elles être mappées de manière fiable aux pixels dans l'image exportée ?**

Oui. Convertissez les points en pixels à l’aide de : pixels = points × (DPI / 72). Le résultat dépend du DPI choisi pour le rendu/l’exportation.

**Comment obtenir les paramètres de mise en forme « effectifs » du paragraphe, en tenant compte de l'héritage des styles ?**

Utilisez la [structure de données de mise en forme effective du paragraphe](/slides/fr/python-net/shape-effective-properties/); elle renvoie les valeurs consolidées finales pour les retraits, l’espacement, le wrapping, le RTL, et plus encore.