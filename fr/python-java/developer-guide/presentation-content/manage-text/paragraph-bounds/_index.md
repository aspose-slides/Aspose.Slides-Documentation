---
title: Obtenir les limites des paragraphes à partir des présentations en Python via Java
linktitle: Limites de paragraphe
type: docs
weight: 43
url: /fr/python-java/paragraph-bounds/
keywords:
- limites de paragraphe
- coordonnée de paragraphe
- taille de paragraphe
- cadre de texte
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites des paragraphes dans Aspose.Slides pour Python via Java afin d'optimiser le positionnement du texte dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment obtenir les limites, la taille et les coordonnées des paragraphes dans Aspose.Slides. Il montre comment récupérer un rectangle de paragraphe à partir d'un [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) en utilisant [Paragraph.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getRect), comment obtenir les coordonnées du paragraphe à l'intérieur d'un cadre de texte de cellule de tableau, et met en évidence des détails importants tels que les unités de mesure, l'effet du retour à la ligne sur les limites, la conversion en pixels et les valeurs de formatage effectif du paragraphe.

## **Obtenir les coordonnées rectangulaires d'un paragraphe**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getRect) pour obtenir le rectangle englobant d'un paragraphe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Obtenir la taille d'un paragraphe à l'intérieur d'un cadre de texte de cellule de tableau**

Pour obtenir la taille et les coordonnées d'un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) dans un cadre de texte de cellule de tableau, utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getRect). Le rectangle renvoyé est relatif au cadre de texte de la cellule du tableau, il faut donc ajouter la position du tableau et le décalage de la cellule lorsque vous avez besoin des coordonnées au niveau de la diapositive.

L'exemple suivant obtient les limites du paragraphe à l'intérieur d'une cellule de tableau et dessine des rectangles sur la diapositive pour visualiser ces limites :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dans quelles unités les coordonnées du paragraphe sont-elles mesurées ?**

Elles sont mesurées en points, où 1 pouce équivaut à 72 points. Cela s'applique à toutes les coordonnées et dimensions sur la diapositive.

**Le retour à la ligne affecte-t-il les limites d'un paragraphe ?**

Oui. Si [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) est activé pour le [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/), le texte se coupe pour s'adapter à la largeur de la zone, ce qui modifie les limites réelles du paragraphe.

**Les coordonnées du paragraphe peuvent-elles être mappées de façon fiable en pixels dans l'image exportée ?**

Oui. Convertissez les points en pixels en utilisant cette formule : pixels = points x (DPI / 72). Le résultat dépend du DPI choisi pour le rendu ou l'exportation.

**Comment obtenir les paramètres de formatage "effective" du paragraphe, en tenant compte de l'héritage des styles ?**

Utilisez la [effective paragraph formatting data structure](/slides/fr/python-java/shape-effective-properties/); elle renvoie les valeurs finales consolidées pour les retraits, l'espacement, le retour à la ligne, le RTL et plus encore.