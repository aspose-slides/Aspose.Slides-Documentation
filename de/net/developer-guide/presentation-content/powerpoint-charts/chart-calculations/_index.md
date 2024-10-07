---
title: Diagramm-Berechnungen
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "Diagrammberechnungen, Diagrammelemente, Elementposition, Diagrammwerte C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Diagrammberechnungen und -werte in C# oder .NET"
---

## **Berechnung der Ist-Werte von Diagrammelementen**
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die Ist-Werte von Diagrammelementen zu berechnen. Die Ist-Werte umfassen die Position der Elemente, die das IActualLayout-Interface implementieren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) und die tatsächlichen Achsenwerte (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Präsentation speichern
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Berechnung der tatsächlichen Position von übergeordneten Diagrammelementen**
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften des IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist notwendig, die Methode IChart.ValidateChartLayout() vorher aufzurufen, um die Eigenschaften mit Ist-Werten zu füllen.

```c#
// Leere Präsentation erstellen
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



## **Informationen aus dem Diagramm ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Sie Informationen aus dem Diagramm ausblenden können. Mit Aspose.Slides für .NET können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitterlinien** aus dem Diagramm ausblenden. Das folgende Codebeispiel zeigt, wie man diese Eigenschaften verwendet.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // Ausblenden des Diagrammtitels
    chart.HasTitle = false;

    // Ausblenden der Werte-Achse
    chart.Axes.VerticalAxis.IsVisible = false;

    // Sichtbarkeit der Kategorischen Achse
    chart.Axes.HorizontalAxis.IsVisible = false;

    // Ausblenden der Legende
    chart.HasLegend = false;

    // Ausblenden der Hauptgitterlinien
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

    // Farbe der Serienlinie festlegen
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```