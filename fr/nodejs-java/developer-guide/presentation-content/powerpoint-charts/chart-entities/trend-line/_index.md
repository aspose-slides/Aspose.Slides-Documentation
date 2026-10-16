---
title: Ajouter des lignes de tendance aux graphiques de présentation en JavaScript
linktitle: Ligne de tendance
type: docs
url: /fr/nodejs-java/trend-line/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez et personnalisez rapidement des lignes de tendance dans les graphiques PowerPoint avec JavaScript et Aspose.Slides pour Node.js via Java — un guide pratique pour captiver votre audience."
---
## **Vue d'ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique, et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection « forward » et « backward » des lignes de tendance ainsi que sur la préservation des lignes de tendance lors de l’exportation au format PDF ou SVG et lors du rendu des graphiques sous forme d’images.

## **Ajouter une ligne de tendance**

Utilisez [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). L’exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² via [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) et [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) pour une étiquette personnalisée. La moyenne mobile utilise un [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) de trois points de données et un [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) personnalisé.

La ligne de tendance polynomiale possède un [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) de trois et s’étend d’une catégorie vers l’avant grâce à [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). La ligne de tendance puissance s’étend d’une catégorie vers l’arrière grâce à [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l’interception d’une ligne de tendance**

Utilisez [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) pour fixer la valeur Y d’une ligne de tendance à X = 0. Cette configuration est prise en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir commencer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production différents de zéro suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l’interception contraint l’équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres de croisement des axes contrôlent où les axes du graphique se rencontrent, pas les coefficients de la ligne de tendance ajustée.

L’exemple suivant crée un graphique en nuage de points (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l’interception automatique par défaut, fixe l’interception à 100, et enregistre un deuxième PPTX. Les deux fichiers ne diffèrent que par le réglage de l’interception. La ligne de tendance affiche son équation et s’étend jusqu’à X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l’interception à 100 produit environ `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de données.

| Intercept automatique | Intercept fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec un intercept calculé automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec un intercept fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d’axes. Les lignes de tendance sont prolongées jusqu’à X = 0 pour afficher leurs interceptions.

Par défaut, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) renvoie `NaN`, ce qui représente un intercept non spécifié plutôt que zéro. L’intercept est alors calculé automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu’une ligne de tendance calculée à partir des données de la série. Cet exemple utilise [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, ainsi elle commence au bord gauche du graphique et se situe à mi‑hauteur du graphique. Sa largeur correspond à la largeur du graphique. Le [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) donne à la ligne une couleur rouge unie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées en avant/en arrière : pour les graphiques en nuage de points (XY) — en unités d’axe ; pour les graphiques non‑nuage de points — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) ou [SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/nodejs-java/create-shape-thumbnails/) lui‑même.