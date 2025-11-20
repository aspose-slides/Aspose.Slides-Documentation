---
title: Obtenir les limites du paragraphe à partir des présentations en Python
linktitle: Paragraphe
type: docs
weight: 60
url: /fr/python-net/paragraph/
keywords:
- limites du paragraphe
- limites de la portion de texte
- coordonnée du paragraphe
- coordonnée de la portion
- taille du paragraphe
- taille de la portion de texte
- cadre de texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à récupérer les limites du paragraphe et de la portion de texte dans Aspose.Slides pour Python via .NET afin d'optimiser le positionnement du texte dans les présentations PowerPoint et OpenDocument."
---

## **Obtenir les coordonnées du paragraphe et de la portion dans TextFrame**
En utilisant Aspose.Slides for Python via .NET, les developpeurs peuvent desormais obtenir les coordonnees rectangulaires d'un Paragraph a l'interieur de la collection de paragraphes d'un TextFrame. Cela permet egalement d'obtenir les coordonnees d'une portion a l'interieur de la collection de portions d'un paragraphe. Dans cet article, nous allons montrer, a l'aide d'un exemple, comment obtenir les coordonnees rectangulaires d'un paragraphe ainsi que la position d'une portion a l'interieur d'un paragraphe.

## **Obtenir les coordonnees rectangulaires du Paragraph**
La nouvelle methode **GetRect()** a ete ajoutee. Elle permet d'obtenir le rectangle des limites du paragraphe.
```py
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```


## **Obtenir la taille du paragraphe et de la portion a l'interieur du texte d'une cellule de tableau** ##
Pour obtenir la taille et les coordonnees du [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) ou du [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) dans le texte d'une cellule de tableau, vous pouvez utiliser les methodes [IPortion.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iportion/) et [IParagraph.GetRect](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).

Ce code d'exemple montre l'operation descrite:
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

**Dans quelles unites les coordonnees d'un paragraphe et des portions de texte sont-elles renvoyees ?**
En points, ou 1 pouce = 72 points. Cela s'applique a toutes les coordonnees et dimensions sur la diapositive.

**L'habillage du texte affecte-t-il les limites du paragraphe ?**
Oui. Si le [wrapping](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) est active dans le [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), le texte se coupe pour s'adapter a la largeur de la zone, ce qui modifie les limites reelles du paragraphe.

**Les coordonnees du paragraphe peuvent-elles etre mappees de facon fiable aux pixels dans l'image exportee ?**
Oui. Convertissez les points en pixels en utilisant : pixels = points x (DPI / 72). Le resultat depend du DPI choisi pour le rendu ou l'exportation.

**Comment obtenir les parametres de mise en forme "effective" du paragraphe, en tenant compte de l'heritage des styles ?**
Utilisez la [structure de donnees de mise en forme effective du paragraphe](/slides/fr/python-net/shape-effective-properties/) ; elle renvoie les valeurs finales consolidees pour les retraits, l'espacement, le wrapping, le RTL, etc.