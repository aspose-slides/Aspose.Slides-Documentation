---
title: Personnaliser les zones de tracé des graphiques de présentation en Python
linktitle: Zone de tracé
type: docs
url: /fr/python-java/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de mise en page
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides for Python via Java. Améliorez facilement l'aspect visuel de vos diapositives."
---
## **Aperçu**

Cet article montre comment travailler avec la zone de tracé d'un graphique dans Aspose.Slides. Il explique comment obtenir la position réelle et la taille de la zone de tracé en validant la mise en page du graphique puis en lisant ses valeurs X, Y, largeur et hauteur.

Il montre également comment configurer le mode de mise en page de la zone de tracé lorsque la mise en page est définie manuellement, en utilisant [LayoutTargetType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layouttargettype/) pour définir si la zone de tracé est calculée à partir de sa région interne ou de sa région externe avec les axes et les libellés d'axes.

## **Obtenir la largeur et la hauteur d’une zone de tracé de graphique**

Aspose.Slides for Python via Java fournit une API simple pour lire la position réelle et la taille de la zone de tracé d'un graphique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode [Chart.validateChartLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#validateChartLayout) avant d’obtenir les valeurs réelles.
1. Obtenez la position X réelle (gauche) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez la position Y réelle (haut) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez la largeur réelle de l'élément du graphique.
1. Obtenez la hauteur réelle de l'élément du graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Définir le mode de mise en page d’une zone de tracé de graphique**

Aspose.Slides for Python via Java fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. Les méthodes [setLayoutTargetType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) et [getLayoutTargetType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) sont disponibles dans la classe [ChartPlotArea](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartplotarea/). Si la mise en page de la zone de tracé est définie manuellement, ce paramètre indique s'il faut disposer la zone de tracé par son intérieur (excluant les axes et les libellés d'axes) ou par son extérieur (incluant les axes et les libellés d'axes). Deux valeurs possibles sont définies dans l'énumération [LayoutTargetType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layouttargettype/#Inner) indique que la taille de la zone de tracé exclut les marques de graduation et les libellés d'axes.
- [Outer](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layouttargettype/#Outer) indique que la taille de la zone de tracé inclut les marques de graduation et les libellés d'axes.

Un exemple de code est fourni ci-dessous.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dans quelles unités sont retournés les X réels, Y réels, la largeur réelle et la hauteur réelle ?**

En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d'Aspose.Slides.

**Comment la zone de tracé diffère-t-elle de la zone de graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone de graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé comprend également les murs/plancher et les axes.

**Comment les X, Y, largeur et hauteur de la zone de tracé sont-ils interprétés lorsque la mise en page est manuelle ?**

Ils sont exprimés en fractions (0‑1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a-t-elle changé après l'ajout ou le déplacement de la légende ?**

La légende se trouve dans la zone de graphique à l'extérieur de la zone de tracé mais influence la mise en page et l'espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C'est le comportement standard des graphiques PowerPoint.)