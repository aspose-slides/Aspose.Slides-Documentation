---
title: Ajouter des ellipses aux présentations en Python via Java
linktitle: Ellipse
type: docs
weight: 30
url: /fr/python-java/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer, mettre en forme et manipuler des formes d'ellipse dans Aspose.Slides pour Python via Java pour les présentations PPT et PPTX — exemples de code Python inclus."
---
## **Vue d'ensemble**

Cet article montre comment ajouter des formes d'ellipse aux diapositives PowerPoint en utilisant Aspose.Slides. Il couvre la création d'une ellipse simple, la création d'une ellipse formatée et l'enregistrement de la présentation mise à jour en tant que fichier PPTX. Il aborde également les questions connexes telles que la gestion de la position et de la taille de l'ellipse, le contrôle de l'ordre d'empilement et l'application d'effets d'animation.

## **Créer une ellipse**

Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenir une référence à une diapositive par son index.
- Ajouter une ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) de l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Enregistrer la présentation modifiée en tant que fichier PPTX.

L'exemple suivant ajoute une ellipse à la première diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instancier la classe Presentation qui représente le fichier PPTX.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme d'ellipse.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Créer une ellipse formatée**

Pour ajouter une ellipse formatée à une diapositive, suivez les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenir une référence à une diapositive par son index.
- Ajouter une ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) de l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Définir le type de remplissage de l'ellipse sur solide.
- Définir la couleur de remplissage de l'ellipse via [getSolidFillColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getSolidFillColor) sur l'objet [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) associé à l'objet [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/).
- Définir la couleur du contour de l'ellipse.
- Définir la largeur du contour de l'ellipse.
- Enregistrer la présentation modifiée en tant que fichier PPTX.

L'exemple suivant ajoute une ellipse formatée à la première diapositive de la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instancier la classe Presentation qui représente le fichier PPTX.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme d'ellipse.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formater le remplissage de l'ellipse.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formater le contour de l'ellipse.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'attribuer les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Ajustez l'ordre de dessin de l'objet en le mettant au premier plan ou en l'envoyant à l'arrière-plan. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'emphase d'une ellipse ?**

[Appliquer](/slides/fr/python-java/shape-animation/) des effets d'entrée, d'emphase ou de sortie à la forme, et configurer les déclencheurs et le timing pour orchestrer quand et comment l'animation se joue.