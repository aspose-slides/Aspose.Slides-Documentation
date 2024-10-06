---
title: Calculs de Graphiques
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "Calculs de graphiques, éléments de graphique, position d'élément, valeurs de graphique C#, Csharp, Aspose.Slides pour .NET"
description: "Calculs et valeurs de graphiques PowerPoint en C# ou .NET"
---

## **Calculer les Valeurs Réelles des Éléments de Graphique**
Aspose.Slides pour .NET fournit une API simple pour obtenir ces propriétés. Cela vous aidera à calculer les valeurs réelles des éléments de graphique. Les valeurs réelles incluent la position des éléments qui implémentent l'interface IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) et les valeurs réelles des axes (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Enregistrer la présentation
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Calculer la Position Réelle des Éléments de Graphique Parent**
Aspose.Slides pour .NET fournit une API simple pour obtenir ces propriétés. Les propriétés de IActualLayout fournissent des informations sur la position réelle de l'élément de graphique parent. Il est nécessaire d'appeler la méthode IChart.ValidateChartLayout() au préalable pour remplir les propriétés avec des valeurs réelles.

```c#
// Création d'une présentation vide
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Masquer des Informations depuis le Graphique**
Ce sujet vous aide à comprendre comment masquer des informations depuis le graphique. En utilisant Aspose.Slides pour .NET, vous pouvez masquer **Titre, Axe Vertical, Axe Horizontal** et **Lignes de Grille** du graphique. L'exemple de code ci-dessous montre comment utiliser ces propriétés.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Masquer le Titre du graphique
    chart.HasTitle = false;

    //Masquer l'axe des Valeurs
    chart.Axes.VerticalAxis.IsVisible = false;

    //Visibilité de l'Axe Catégorique
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Masquer la Légende
    chart.HasLegend = false;

    //Masquer les MajorGridLines
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Définir la couleur de ligne de la série
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```