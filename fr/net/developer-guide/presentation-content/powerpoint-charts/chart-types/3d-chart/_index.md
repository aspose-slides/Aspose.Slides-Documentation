---
title: Graphique 3D
type: docs
url: /net/3d-chart/
keywords: "graphique 3d, rotationX, rotationY, depthpercent, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Définir rotationX, rotationY et depthpercents pour un graphique 3D dans une présentation PowerPoint en C# ou .NET"
---

## **Définir les propriétés RotationX, RotationY et DepthPercents du graphique 3D**
Aspose.Slides pour .NET fournit une API simple pour définir ces propriétés. Cet article suivant vous aidera à définir différentes propriétés comme la rotation X, Y, **DepthPercents**, etc. Le code d'exemple applique les réglages des propriétés mentionnées ci-dessus.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Définissez les propriétés Rotation3D.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();
           
// Access first slide
ISlide slide = presentation.Slides[0];

// Add chart with default data
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Add series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.Type);

// Add Categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));

// Set Rotation3D properties
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Take second chart series
IChartSeries series = chart.ChartData.Series[1];

// Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Set OverLap value
series.ParentSeriesGroup.Overlap = 100;         

// Write presentation to disk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```