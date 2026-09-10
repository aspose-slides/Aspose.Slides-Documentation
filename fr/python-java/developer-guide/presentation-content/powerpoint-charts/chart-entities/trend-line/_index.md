---
title: Ajouter des lignes de tendance aux graphiques de présentation en Python
linktitle: Ligne de tendance
type: docs
url: /fr/python-java/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez les lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides for Python via Java — un guide pratique pour captiver votre audience."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique, et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection en avant et en arrière des lignes de tendance ainsi que sur la préservation des lignes de tendance lors de l'exportation en PDF ou SVG et lors du rendu des graphiques en images.

## **Ajouter une ligne de tendance**

Aspose.Slides for Python via Java fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut et le type souhaité (cet exemple utilise [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Ajoutez une ligne de tendance exponentielle à la série 1 du graphique.
1. Ajoutez une ligne de tendance linéaire à la série 1 du graphique.
1. Ajoutez une ligne de tendance logarithmique à la série 2 du graphique.
1. Ajoutez une ligne de tendance moyenne mobile à la série 2 du graphique.
1. Ajoutez une ligne de tendance polynomiale à la série 3 du graphique.
1. Ajoutez une ligne de tendance puissance à la série 3 du graphique.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant crée un graphique avec des lignes de tendance.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    # Créer un graphique à colonnes groupées.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Ajouter une ligne de tendance exponentielle à la série 1 du graphique.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Ajouter une ligne de tendance linéaire à la série 1 du graphique.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Ajouter une ligne de tendance logarithmique à la série 2 du graphique.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Ajouter une ligne de tendance moyenne mobile à la série 2 du graphique.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Ajouter une ligne de tendance polynomiale à la série 3 du graphique.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Ajouter une ligne de tendance puissance à la série 3 du graphique.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Enregistrer la présentation.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter une ligne personnalisée**

Aspose.Slides for Python via Java fournit une API simple pour ajouter des lignes personnalisées à un graphique. Pour ajouter une ligne simple à un graphique sur une diapositive sélectionnée, suivez ces étapes :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à une diapositive par son indice.
- Créez un nouveau graphique en utilisant la méthode [addChart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addChart) de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Ajoutez une forme de ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) avec [ShapeType.Line](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Line).
- Définissez la couleur de la ligne de la forme.
- Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant crée un graphique avec une ligne personnalisée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées en avant ou en arrière : pour les graphiques de dispersion (XY), elles sont mesurées en unités d’axe ; pour les graphiques non‑dispersion, elles sont mesurées en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera‑t‑elle préservée lors de l’exportation de la présentation en PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/python-java/create-shape-thumbnails/) lui‑même.