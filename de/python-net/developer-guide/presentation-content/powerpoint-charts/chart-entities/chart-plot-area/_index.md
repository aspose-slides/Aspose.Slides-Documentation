---
title: Diagrammplotbereich
type: docs
url: /python-net/chart-plot-area/
keywords: "Diagrammplotbereich PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Breite, Höhe des Diagrammplotbereichs abrufen. Layoutmodus festlegen. PowerPoint-Präsentation in Python"
---

## **Breite, Höhe des Diagrammplotbereichs abrufen**
Aspose.Slides für Python über .NET bietet eine einfache API für. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Rufen Sie die Methode IChart.ValidateChartLayout() auf, um die aktuellen Werte abzurufen.
1. Erhält die tatsächliche X-Position (links) des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche obere Position des Diagrammelements relativ zur oberen linken Ecke des Diagramms.
1. Erhält die tatsächliche Breite des Diagrammelements.
1. Erhält die tatsächliche Höhe des Diagrammelements.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Präsentation mit Diagramm speichern
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Layoutmodus des Diagrammplotbereichs festlegen**
Aspose.Slides für Python über .NET bietet eine einfache API, um den Layoutmodus des Diagrammplotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert ist, gibt diese Eigenschaft an, ob der Plotbereich innerhalb (ohne Achsen und Achsenbeschriftungen) oder außerhalb (einschließlich Achsen und Achsenbeschriftungen) layoutiert werden soll. Es gibt zwei mögliche Werte, die im **LayoutTargetType**-Enum definiert sind.

- **LayoutTargetType.Inner** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tickmarken und Achsenbeschriftungen.
- **LayoutTargetType.Outer** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs sowie die Tickmarken und die Achsenbeschriftungen bestimmt.

Beispielcode ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```