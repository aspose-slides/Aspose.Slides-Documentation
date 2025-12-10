---
title: Diagrammberechnungen für Präsentationen in .NET optimieren
linktitle: Diagrammberechnungen
type: docs
weight: 50
url: /de/net/chart-calculations/
keywords:
- Diagrammberechnungen
- Diagrammelemente
- Elementposition
- Tatsächliche Position
- Kindelement
- Elternelement
- Diagrammwerte
- Tatsächlicher Wert
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verstehen Sie Diagrammberechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für .NET für PPT und PPTX, mit praktischen C#-Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die tatsächlichen Werte von Diagrammelementen zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout‑Interface implementieren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) sowie die tatsächlichen Achsenwerte (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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
Aspose.Slides für .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist erforderlich, vorher die Methode IChart.ValidateChartLayout() aufzurufen, um die Eigenschaften mit den tatsächlichen Werten zu füllen.
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


## **Diagrammelemente ausblenden**
Dieses Thema hilft Ihnen zu verstehen, wie Informationen im Diagramm ausgeblendet werden können. Mit Aspose.Slides für .NET können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das untenstehende Code‑Beispiel zeigt, wie diese Eigenschaften verwendet werden.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Diagrammtitel ausblenden
    chart.HasTitle = false;

    ///Achsenwerte ausblenden
    chart.Axes.VerticalAxis.IsVisible = false;

    //Kategorienachse sichtbar
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

    //Serienlinienfarbe festlegen
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Funktionieren externe Excel‑Arbeitsmappen als Datenquelle, und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann auf eine externe Arbeitsmappe verweisen: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht es Ihnen, den Pfad zur [externen Arbeitsmappe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) anzugeben und die verknüpften Daten zu verwalten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/net/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch anhand der Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen implementieren müssen.

**Kann ich bei einer Präsentation mit mehreren Diagrammen und externen Verknüpfungen steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene [externe Arbeitsmappe](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) verweisen, oder Sie können pro Diagramm eine externe Arbeitsmappe erstellen/ersetzen, unabhängig von den anderen.