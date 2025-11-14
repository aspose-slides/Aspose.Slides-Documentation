---
title: Paragraphe
type: docs
weight: 60
url: /fr/python-net/paragraph/
keywords: "Paragraphe, portion, coordonnées de paragraphe, coordonnées de portion, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Paragraphe et portion dans une présentation PowerPoint en Python"
---

## **Obtenir les coordonnées de paragraphe et de portion dans TextFrame**
En utilisant Aspose.Slides pour Python via .NET, les développeurs peuvent désormais obtenir les coordonnées rectangulaires pour le Paragraphe à l'intérieur de la collection de paragraphes de TextFrame. Cela permet également d'obtenir les coordonnées de la portion à l'intérieur de la collection de portions d'un paragraphe. Dans ce sujet, nous allons démontrer avec l'aide d'un exemple comment obtenir les coordonnées rectangulaires pour le paragraphe ainsi que la position de la portion à l'intérieur d'un paragraphe.

## **Obtenir les coordonnées rectangulaires du paragraphe**
La nouvelle méthode **GetRect()** a été ajoutée. Elle permet d'obtenir le rectangle de limites du paragraphe.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Obtenir la taille du paragraphe et de la portion à l'intérieur de la cellule de texte du tableau** ##

Pour obtenir la taille et les coordonnées de la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) ou du [Paragraphe](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) dans une cellule de texte de tableau, vous pouvez utiliser les méthodes [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) et [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Cet exemple de code montre l'opération décrite :

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