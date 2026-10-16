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
description: "Ajoutez et personnalisez rapidement des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour Python via Java — un guide pratique pour captiver votre public."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, dont exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et inclut une courte FAQ sur les valeurs de projection « forward » et « backward » d’une ligne de tendance et sur le fait que les lignes de tendance sont conservées lors de l’exportation en PDF ou SVG et lors du rendu de graphiques sous forme d’images.

## **Ajouter une ligne de tendance**

Utilisez [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). L’exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² grâce à [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) et [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) pour une étiquette personnalisée. La moyenne mobile utilise un [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) de trois points de données et un [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) personnalisé.

La ligne de tendance polynomiale a un ordre de trois, défini via [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) et s’étend d’une catégorie vers l’avant grâce à [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). La ligne de tendance puissance s’étend d’une catégorie vers l’arrière grâce à [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l’interception d’une ligne de tendance**

Utilisez [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) pour fixer la valeur Y d’une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir commencer à un coût fixe connu de 100, même lorsque des mesures à des volumes de production non nuls suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l’interception contraint l’équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres d’intersection des axes déterminent où les axes du graphique se croisent, pas les coefficients de la ligne de tendance ajustée.

L’exemple suivant crée un graphique de dispersion (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l’interception automatique par défaut, fixe l’interception à 100, puis enregistre un second PPTX. Les deux fichiers ne diffèrent que par le paramètre d’interception. La ligne de tendance affiche son équation et s’étend jusqu’à X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l’interception à 100 produit approximativement `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de donnée.

| Intercept automatique | Intercept fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec un intercept calculé automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec un intercept fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d’axes. Les lignes de tendance sont prolongées jusqu’à X = 0 pour afficher leurs interceptions.

Par défaut, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) renvoie `NaN`, ce qui représente une interception non spécifiée plutôt que zéro. L’interception est alors calculée automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu’une ligne de tendance calculée à partir des données de série. Cet exemple utilise [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, de sorte qu’elle commence au bord gauche du graphique et se situe à mi‑hauteur du graphique. Sa largeur correspond à celle du graphique. La méthode [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) donne accès au format de ligne utilisé pour appliquer une couleur rouge unie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées vers l’avant ou vers l’arrière : pour les graphiques de dispersion (XY) — en unités d’axe ; pour les graphiques non‑dispersion — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/) ou en [SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont préservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/python-java/create-shape-thumbnails/) lui‑même.