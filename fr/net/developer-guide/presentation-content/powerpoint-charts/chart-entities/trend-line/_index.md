---
title: Ajouter des lignes de tendance aux graphiques de présentation dans .NET
linktitle: Ligne de tendance
type: docs
url: /fr/net/trend-line/
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
- .NET
- C#
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour .NET — un guide pratique pour captiver votre audience."
---
## **Vue d’ensemble**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation à l’aide d’Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection avant et arrière des lignes de tendance ainsi que sur la conservation des lignes de tendance lors de l’exportation en PDF ou SVG et lors du rendu des graphiques en images.

## **Ajouter une ligne de tendance**

Utilisez [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). L’exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² via [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) et [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) pour une étiquette personnalisée. La moyenne mobile utilise une [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) de trois points de données et un [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) personnalisé.

La ligne de tendance polynomiale possède un [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) de trois et s’étend d’une catégorie vers l’avant via [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). La ligne de tendance puissance s’étend d’une catégorie vers l’arrière via [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Définir l’interception d’une ligne de tendance**

Utilisez [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) pour fixer la valeur Y d’une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir démarrer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production différents de zéro suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l’interception contraint l’équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne fait pas simplement bouger une ligne déjà ajustée. Les paramètres de croisement des axes contrôlent où les axes du graphique se rencontrent, et non les coefficients de la ligne de tendance ajustée.

L’exemple suivant crée un graphique de dispersion (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l’interception automatique par défaut, fixe l’interception à 100, puis enregistre un deuxième PPTX. Les deux fichiers ne diffèrent que par le paramètre d’interception. La ligne de tendance affiche son équation et s’étend jusqu’à X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l’interception à 100 produit environ `y = 43.33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de données.

| Intercept automatique | Intercept fixe à 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec un intercept calculé automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec un intercept fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d’axes. Les lignes de tendance sont étendues jusqu’à X = 0 pour montrer leurs interceptions.

Par défaut, la propriété contient `double.NaN`, qui représente une interception non spécifiée plutôt que zéro. L’interception est alors calculée automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu’une ligne de tendance calculée à partir des données de la série. Cet exemple utilise [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, de sorte qu’elle commence au bord gauche du graphique et se situe à mi‑hauteur du graphique. Sa largeur correspond à celle du graphique. Le [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) donne à la ligne une couleur rouge unie.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées respectivement en avant et en arrière : pour les graphiques de dispersion (XY) — en unités d’axe ; pour les graphiques non‑dispersion — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle conservée lors de l’exportation de la présentation en PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/net/convert-powerpoint-to-pdf/) ou en [SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/net/create-shape-thumbnails/) lui‑même.