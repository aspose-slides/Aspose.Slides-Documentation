---
title: Ajouter des lignes de tendance aux graphiques de présentation en Java
linktitle: Ligne de tendance
type: docs
url: /fr/java/trend-line/
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
- Java
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour Java — un guide pratique pour captiver votre public."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et inclut une courte FAQ sur les valeurs de projection des lignes de tendance « forward » et « backward » ainsi que sur la préservation des lignes de tendance lors de l’exportation en PDF ou SVG et lors du rendu des graphiques en images.

## **Ajouter une ligne de tendance**

Utilisez [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). L'exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R-carré via [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) et [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) pour une étiquette personnalisée. La moyenne mobile utilise un [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) de trois points de données et un [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) personnalisé.

La ligne de tendance polynomiale possède un [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) de trois et s'étend d'une catégorie vers l'avant via [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). La ligne de tendance puissance s'étend d'une catégorie vers l'arrière via [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l'intercept d'une ligne de tendance**

Utilisez [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) pour fixer la valeur Y d'une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir démarrer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production non nuls suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l'intercept contraint l'équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres de croisement des axes déterminent où les axes du graphique se rencontrent, pas les coefficients de la ligne de tendance ajustée.

L'exemple suivant crée un graphique à nuage de points (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l'intercept automatique par défaut, fixe l'intercept à 100, puis enregistre un deuxième PPTX. Les deux fichiers ne diffèrent que par le paramètre d'intercept. La ligne de tendance affiche son équation et s'étend jusqu'à X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l'intercept à 100 produit approximativement `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de données.

| Intercept automatique | Intercept fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec un intercept calculé automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec un intercept fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d'axes. Les lignes de tendance sont prolongées jusqu'à X = 0 pour afficher leurs intercepts.

Par défaut, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) renvoie `Double.NaN`, qui représente un intercept non spécifié plutôt que zéro. L'intercept est alors calculé automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu'une ligne de tendance calculée à partir des données de la série. Cet exemple utilise [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, de sorte qu'elle commence au bord gauche du graphique et se situe à mi-hauteur du graphique. Sa largeur correspond à celle du graphique. Le [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) donne à la ligne une couleur rouge unie.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées vers l'avant/arrière : pour les graphiques à nuage de points (XY) – en unités d'axe ; pour les graphiques non nuage de points – en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle préservée lors de l'exportation de la présentation vers PDF ou SVG, ou lors du rendu d'une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/java/convert-powerpoint-to-pdf/) ou en [SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées lors de ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/java/create-shape-thumbnails/) lui‑même.