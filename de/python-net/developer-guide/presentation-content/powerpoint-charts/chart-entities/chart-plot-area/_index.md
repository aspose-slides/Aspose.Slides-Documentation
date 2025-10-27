---
title: Plotbereiche von Präsentationsdiagrammen in Python anpassen
linktitle: Plotbereich
type: docs
url: /de/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-plot-area/
keywords:
- diagramm
- plotbereich
- plotbereich breite
- plotbereich höhe
- plotbereich größe
- layoutmodus
- PowerPoint
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramm-Plotbereiche in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET anpassen. Verbessern Sie Ihre Folien visuell mühelos."
---

## **Breite und Höhe des Diagramm-Plotbereichs abrufen**
Aspose.Slides für Python via .NET bietet eine einfache API für .

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Greifen Sie auf die erste Folie zu.  
3. Fügen Sie ein Diagramm mit Standarddaten hinzu.  
4. Rufen Sie die Methode IChart.ValidateChartLayout() auf, um die tatsächlichen Werte zu erhalten.  
5. Ermittelt die tatsächliche X-Position (Links) des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
6. Ermittelt die tatsächliche obere Position des Diagrammelements relativ zur linken oberen Ecke des Diagramms.  
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
	
    # Präsentation mit Diagramm speichern
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Layoutmodus des Diagramm-Plotbereichs festlegen**
Aspose.Slides für Python via .NET bietet eine einfache API, um den Layoutmodus des Diagramm-Plotbereichs festzulegen. Die Eigenschaft **LayoutTargetType** wurde zu den Klassen **ChartPlotArea** und **IChartPlotArea** hinzugefügt. Wenn das Layout des Plotbereichs manuell definiert wird, gibt diese Eigenschaft an, ob der Plotbereich innen (ohne Achsen und Achsenbeschriftungen) oder außen (mit Achsen und Achsenbeschriftungen) angeordnet werden soll. Es gibt zwei mögliche Werte, die im Aufzählungstyp **LayoutTargetType** definiert sind.

- **LayoutTargetType.Inner** – gibt an, dass die Größe des Plotbereichs die Größe des Plotbereichs bestimmt, ohne die Tick‑Marks und Achsenbeschriftungen.  
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

**In welchen Einheiten werden actual_x, actual_y, actual_width und actual_height zurückgegeben?**  
In Punkt; 1 Zoll = 72 Punkte. Dies sind Koordinateneinheiten von Aspose.Slides.

**Wie unterscheidet sich der Plotbereich vom Diagrammbereich hinsichtlich des Inhalts?**  
Der Plotbereich ist der Datenzeichnungsbereich (Serien, Gitternetzlinien, Trendlinien usw.); der Diagrammbereich umfasst die umliegenden Elemente (Titel, Legende usw.). Bei 3D‑Diagrammen enthält der Plotbereich zudem die Wände/Boden und die Achsen.

**Wie werden die X‑, Y‑, Breiten‑ und Höhenwerte des Plotbereichs interpretiert, wenn das Layout manuell erfolgt?**  
Sie sind Bruchteile (0–1) der gesamten Diagrammgröße; in diesem Modus ist die automatische Positionierung deaktiviert und die von Ihnen gesetzten Bruchteile werden verwendet.

**Warum änderte sich die Position des Plotbereichs nach dem Hinzufügen/Bewegen der Legende?**  
Die Legende befindet sich im Diagrammbereich außerhalb des Plotbereichs, beeinflusst jedoch das Layout und den verfügbaren Platz, sodass der Plotbereich bei aktivierter automatischer Positionierung verschoben werden kann. (Dies ist das Standardverhalten von PowerPoint‑Diagrammen.)