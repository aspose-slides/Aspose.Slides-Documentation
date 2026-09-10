---
title: Personnaliser les légendes de graphiques dans les présentations avec Python
linktitle: Légende de graphique
type: docs
url: /fr/python-java/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides for Python via Java pour optimiser les présentations PowerPoint avec un formatage de légende adapté."
---
## **Aperçu**

Aspose.Slides propose des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende et appliquer un formatage à une entrée de légende individuelle.

Il couvre également plusieurs comportements associés dans la FAQ, notamment l’utilisation du mode non superposé afin que la zone de tracé fasse de la place à la légende, le fait de permettre aux étiquettes de légende longues de se renvoyer à la ligne ou d’utiliser des sauts de ligne, et le fait de laisser le formatage de la légende hériter du thème de la présentation lorsque des paramètres explicites de texte et de remplissage ne sont pas appliqués.

## **Positionnement de la légende**

Pour définir les propriétés de la légende, suivez ces étapes :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) class.
1. Obtenez une référence à la diapositive.
1. Ajoutez un graphique à la diapositive.
1. Définissez les propriétés de la légende.
1. Enregistrez la présentation au format PPTX file.

L’exemple suivant définit la position et la taille d’une légende de graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Créer une présentation vide.
presentation = Presentation()
try:
    # Obtenir une référence à la diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un graphique à colonnes groupées à la diapositive.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Définir les propriétés de la légende.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Enregistrer la présentation sur le disque.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la taille de police d’une légende**

Aspose.Slides for Python via Java vous permet de définir la taille de police d’une légende. Suivez les étapes suivantes :

1. Instanciez la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) class.
1. Créez le graphique par défaut.
1. Définissez la taille de police.
1. Définissez la valeur minimale de l’axe.
1. Définissez la valeur maximale de l’axe.
1. Enregistrez la présentation sur le disque.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Créer une présentation vide.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la taille de police d’une entrée de légende individuelle**

Aspose.Slides for Python via Java vous permet de définir la taille de police d’une entrée de légende individuelle. Suivez les étapes suivantes :

1. Instanciez la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) class.
1. Créez le graphique par défaut.
1. Accédez à une entrée de légende.
1. Définissez la taille de police.
1. Enregistrez la présentation sur le disque.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Créer une présentation vide.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je activer la légende afin que le graphique réserve automatiquement de l’espace pour celle‑ci au lieu de la superposer ?**

Oui. Utilisez [setOverlay](https://reference.aspose.com/slides/fr/python-java/aspose.slides/legend/#setOverlay) avec `False` pour activer le mode non superposé ; dans ce cas, la zone de tracé se réduira pour accueillir la légende.

**Puis-je créer des étiquettes de légende multi‑lignes ?**

Oui. Les longues étiquettes sont automatiquement renvoyées à la ligne lorsque l’espace est insuffisant ; les sauts de ligne forcés sont pris en charge via des caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Ne définissez pas de couleurs, de remplissages ou de polices explicites pour la légende ou son texte. Ils hériteront alors du thème et se mettront à jour correctement lorsque le design changera.