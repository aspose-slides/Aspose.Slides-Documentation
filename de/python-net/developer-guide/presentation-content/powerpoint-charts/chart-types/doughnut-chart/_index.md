---
title: Donut-Diagramm
type: docs
weight: 30
url: /de/python-net/doughnut-chart/
keywords: "Donut-Diagramm, Loch in der Mitte, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Loch in der Mitte im Donut-Diagramm in PowerPoint-Präsentation in Python angeben"
---

## **Loch in der Mitte im Donut-Diagramm angeben**
Um die Größe des Lochs in einem Donut-Diagramm anzugeben, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Fügen Sie ein Donut-Diagramm zur Folie hinzu.
- Geben Sie die Größe des Lochs in einem Donut-Diagramm an.
- Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen Sie eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Schreiben Sie die Präsentation auf die Festplatte
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```