---
title: Diagramm Plotbereich
type: docs
url: /de/net/chart-plot-area/
keywords: "Diagramm Plotbereich PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Erhalten Sie Breite, Höhe des Diagramm-Plotbereichs. Legen Sie den Layoutmodus fest. PowerPoint-Präsentation in C# oder .NET"
---

## **Erhalten Sie Breite, Höhe des Diagramm-Plotbereichs**
Aspose.Slides für .NET bietet eine einfache API für . 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode IChart.ValidateChartLayout() auf, um die tatsächlichen Werte zu erhalten.
1. Erhält die tatsächliche X-Position (links) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche obere Position des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Breite des Diagrammelements.
1. Erhält die tatsächliche Höhe des Diagrammelements.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Präsentation mit Diagramm speichern
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Legen Sie den Layoutmodus des Diagramm-Plotbereichs fest**
Aspose.Slides für .NET bietet eine einfache API, um den Layoutmodus des Diagramm-Plotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich innen (ohne Achsen und Achsenbeschriftungen) oder außen (einschließlich Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im **LayoutTargetType**-Enum definiert sind.

- **LayoutTargetType.Inner** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmen soll, ohne die Markierungen und Achsenbeschriftungen.
- **LayoutTargetType.Outer** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Markierungen und die Achsenbeschriftungen bestimmen soll.

Ein Beispielcode wird unten angegeben.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```