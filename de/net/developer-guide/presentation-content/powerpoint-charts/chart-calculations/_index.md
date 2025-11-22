---
title: Diagrammberechnungen
type: docs
weight: 50
url: /de/net/chart-calculations/
keywords: "Diagrammberechnungen, Diagrammelemente, Elementposition, Diagrammwerte C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint Diagrammberechnungen und Werte in C# oder .NET"
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die tatsächlichen Werte von Diagrammelementen zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout-Interface implementieren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) sowie die tatsächlichen Achsenwerte (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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




## **Tatsächliche Position von übergeordneten Diagrammelementen berechnen**
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Eigenschaften von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist notwendig, vorher die Methode IChart.ValidateChartLayout() aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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




## **Informationen im Diagramm ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Sie Informationen im Diagramm ausblenden können. Mit Aspose.Slides für .NET können Sie **Titel, vertikale Achse, horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das nachstehende Codebeispiel zeigt, wie diese Eigenschaften verwendet werden.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Diagrammtitel ausblenden
    chart.HasTitle = false;

    ///Wertachse ausblenden
    chart.Axes.VerticalAxis.IsVisible = false;

    //Sichtbarkeit der Kategorienachse
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Legende ausblenden
    chart.HasLegend = false;

    //Hauptgitternetzlinien ausblenden
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

    //Linienfarbe der Serie festlegen
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Funktionieren externe Excel-Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen-/Bearbeitungs-Vorgängen wider. Die API ermöglicht es Ihnen, den Pfad zur [die externe Arbeitsmappe angeben](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/net/trend-line/) (linear, exponentiell und andere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie Ihre eigenen Berechnungen nicht implementieren müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.