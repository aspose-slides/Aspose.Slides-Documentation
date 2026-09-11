---
title: Ajouter des formes de ligne aux présentations en Python via Java
linktitle: Ligne
type: docs
weight: 50
url: /fr/python-java/line/
keywords:
- ligne
- créer une ligne
- ajouter une ligne
- ligne simple
- configurer la ligne
- personnaliser la ligne
- style de tiret
- pointe de flèche
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à manipuler le formatage des lignes dans les présentations PowerPoint avec Aspose.Slides pour Python via Java. Découvrez les propriétés, les méthodes et des exemples."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'ajouter des formes de ligne aux diapositives PowerPoint de manière programmatique. Cet article montre comment créer une ligne simple et comment personnaliser une ligne afin qu'elle apparaisse comme une flèche.

Vous apprendrez comment ajouter une forme de ligne à une diapositive, ajuster son apparence visuelle, et enregistrer la présentation mise à jour. Les exemples portent sur des paramètres pratiques de formatage de ligne tels que le style, la largeur, le motif de tirets, les options de pointe de flèche et la couleur de remplissage.

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à une diapositive par son index.
- Ajoutez une forme de ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) de l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Enregistrez la présentation modifiée en tant que fichier PPTX.

L'exemple suivant ajoute une ligne à la première diapositive de la présentation :

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

    # Ajouter une forme de ligne.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Créer une ligne en forme de flèche**

Aspose.Slides for Python via Java permet également aux développeurs de configurer les propriétés d'une ligne pour la rendre plus attrayante. Pour configurer une ligne afin qu'elle ressemble à une flèche, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à une diapositive par son index.
- Ajoutez une forme de ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) de l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Définissez le [line style](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linestyle/) sur l'un des styles proposés par Aspose.Slides for Python via Java.
- Définissez la largeur de la ligne.
- Définissez le [dash style](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linedashstyle/) sur l'un des styles proposés par Aspose.Slides for Python via Java.
- Définissez le [style de pointe de flèche](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linearrowheadstyle/) et la [longueur](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linearrowheadlength/) au début de la ligne.
- Définissez le [style de pointe de flèche](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linearrowheadstyle/) et la [longueur](https://reference.aspose.com/slides/fr/python-java/aspose.slides/linearrowheadlength/) à la fin de la ligne.
- Enregistrez la présentation modifiée en tant que fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instancier la classe Presentation qui représente le fichier PPTX.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme de ligne.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Appliquer le formatage à la ligne.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je convertir une ligne ordinaire en connecteur afin qu'elle "snaps" aux formes?**

Non. Une ligne ordinaire (une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type [Line](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/)) ne devient pas automatiquement un connecteur. Pour la faire s'ajuster aux formes, utilisez le type [Connector](https://reference.aspose.com/slides/fr/python-java/aspose.slides/connector/) dédié et les [API correspondantes](/slides/fr/python-java/connector/) pour les connexions.

**Que faire si les propriétés d'une ligne sont héritées du thème et qu'il est difficile de déterminer les valeurs finales?**

[Lisez les propriétés effectives](/slides/fr/python-java/shape-effective-properties/) de la ligne et de son remplissage—elles tiennent déjà compte de l'héritage et des styles du thème.

**Puis-je verrouiller une ligne contre la modification (déplacement, redimensionnement)?**

Oui. Les formes offrent des [objets de verrouillage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/#getAutoShapeLock) qui vous permettent de [interdire les opérations de modification](/slides/fr/python-java/applying-protection-to-presentation/).