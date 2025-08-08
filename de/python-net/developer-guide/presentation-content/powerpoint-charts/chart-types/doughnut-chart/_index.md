---
title: Ringdiagramme in Präsentationen mit Python anpassen
linktitle: Ringdiagramm
type: docs
weight: 30
url: /de/python-net/doughnut-chart/
keywords:
- ringdiagramm
- innenabstand
- lochgröße
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ringdiagramme in Aspose.Slides for Python via .NET erstellen und anpassen, mit Unterstützung für PowerPoint- und OpenDocument-Formate für dynamische Präsentationen."
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