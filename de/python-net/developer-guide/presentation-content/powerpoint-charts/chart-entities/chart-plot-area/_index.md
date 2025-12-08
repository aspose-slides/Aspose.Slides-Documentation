---
title: Diagramm-Plotbereiche von Präsentationsdiagrammen in Python anpassen
linktitle: Plotbereich
type: docs
url: /de/python-net/chart-plot-area/
keywords:
- Diagramm
- Plotbereich
- Plotbereichsbreite
- Plotbereichshöhe
- Plotbereichsgröße
- Layoutmodus
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Plotbereiche von Diagrammen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET anpassen können. Verbessern Sie mühelos die Visualisierung Ihrer Folien."
---

## **Breite und Höhe des Diagramm‑Plotbereichs abrufen**
Aspose.Slides for Python via .NET stellt eine einfache API für . bereit.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Zugriff auf die erste Folie.
1. Diagramm mit Standarddaten hinzufügen.
1. Rufen Sie die Methode IChart.ValidateChartLayout() auf, um tatsächliche Werte zu erhalten.
1. Ermittelt die tatsächliche X‑Position (links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.
1. Ermittelt die tatsächliche Breite des Diagrammelements.
1. Ermittelt die tatsächliche Höhe des Diagrammelements.
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





## **Layoutmodus des Diagramm‑Plotbereichs festlegen**
Aspose.Slides for Python via .NET stellt eine einfache API zum Festlegen des Layoutmodus des Diagramm‑Plotbereichs bereit. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich nach seinem Inneren (ohne Achsen und Achsenbeschriftungen) oder nach außen (mit Achsen und Achsenbeschriftungen) ausgerichtet werden soll. Es gibt zwei mögliche Werte, die im **LayoutTargetType**‑Enum definiert sind.

- **LayoutTargetType.Inner** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Markierungen und Achsenbeschriftungen.
- **LayoutTargetType.Outer** - gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs, die Tick‑Markierungen und die Achsenbeschriftungen bestimmt.

Sample code is given below.
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

**In welchen Einheiten werden actual_x, actual_y, actual_width und actual_height zurückgegeben?**

In Punkten; 1 Zoll = 72 Punkte. Dies sind Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plot‑Bereich vom Diagrammbereich hinsichtlich des Inhalts?**

Der Plot‑Bereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umliegenden Elemente (Titel, Legende usw.). In 3‑D‑Diagrammen schließt der Plot‑Bereich auch die Wände/Boden und die Achsen ein.

**Wie werden X, Y, Breite und Höhe des Plot‑Bereichs interpretiert, wenn das Layout manuell erfolgt?**

Sie sind Bruchteile (0–1) der Gesamtabmessungen des Diagramms; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen festgelegten Bruchteile werden verwendet.

**Warum verschob sich die Position des Plot‑Bereichs nach dem Hinzufügen/Bewegen der Legende?**

Die Legende befindet sich im Diagrammbereich außerhalb des Plot‑Bereichs, wirkt sich jedoch auf das Layout und den verfügbaren Raum aus, sodass sich der Plot‑Bereich verschieben kann, wenn die automatische Positionierung aktiv ist. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)