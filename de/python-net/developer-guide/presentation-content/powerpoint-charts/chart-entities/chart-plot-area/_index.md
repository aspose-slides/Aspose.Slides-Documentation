---
title: Customize Plot Areas of Presentation Charts in Python
linktitle: Plot Area
type: docs
url: /de/python-net/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramm‑Plotbereiche in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET anpassen. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe des Diagramm‑Plotbereichs abrufen**
Aspose.Slides for Python via .NET bietet eine einfache API für .  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Rufen Sie die Methode IChart.ValidateChartLayout() auf, um die tatsächlichen Werte zu erhalten.  
5. Ermittelt den tatsächlichen X‑Standort (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
6. Ermittelt den tatsächlichen Y‑Standort (oben) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
7. Ermittelt die tatsächliche Breite des Diagrammelements.  
8. Ermittelt die tatsächliche Höhe des Diagrammelements.  

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
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Layout‑Modus des Diagramm‑Plotbereichs festlegen**
Aspose.Slides for Python via .NET bietet eine einfache API zum Festlegen des Layout‑Modus des Diagramm‑Plotbereichs. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob das Layout des Plotbereichs anhand seines Inneren (ohne Achsen und Achsenbeschriftungen) oder seines Äußeren (einschließlich Achsen und Achsenbeschriftungen) erfolgt. Es gibt zwei mögliche Werte, die im **LayoutTargetType**‑Enum definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen zu berücksichtigen.  
- **LayoutTargetType.Outer** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick‑Marks und die Achsenbeschriftungen bestimmt.  

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

## **FAQ**

**In welchen Einheiten werden actual_x, actual_y, actual_width und actual_height zurückgegeben?**  
In Punkten; 1 Zoll = 72 Punkte. Dies sind die Koordinateneinheiten von Aspose.Slides.

**Worin besteht der Unterschied zwischen Plot‑Area und Chart‑Area hinsichtlich des Inhalts?**  
Die Plot‑Area ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); die Chart‑Area umfasst die umgebenden Elemente (Titel, Legende usw.). Bei 3D‑Diagrammen beinhaltet die Plot‑Area auch die Wände/Boden und die Achsen.

**Wie werden X, Y, Width und Height der Plot‑Area interpretiert, wenn das Layout manuell erfolgt?**  
Sie werden als Bruchteile (0–1) der Gesamtabmessungen des Diagramms angegeben; in diesem Modus ist das automatische Positionieren deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum ändert sich die Position der Plot‑Area, nachdem die Legende hinzugefügt/verschoben wurde?**  
Die Legende befindet sich im Diagrammbereich außerhalb der Plot‑Area, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass sich die Plot‑Area verschieben kann, wenn automatisches Positionieren aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)