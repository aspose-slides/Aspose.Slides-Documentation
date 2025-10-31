---
title: Anpassen von Donut-Diagrammen in Präsentationen mit Python
linktitle: Donut-Diagramm
type: docs
weight: 30
url: /de/python-net/doughnut-chart/
keywords:
- Donut-Diagramm
- Zentraler Abstand
- Lochgröße
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donut-Diagramme in Aspose.Slides für Python über .NET erstellen und anpassen können, wobei PowerPoint- und OpenDocument-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentralen Abstand im Donut-Diagramm angeben**
Um die Größe des Lochs in einem Donut-Diagramm festzulegen, befolgen Sie bitte die untenstehenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Fügen Sie dem Folienblatt ein Donut-Diagramm hinzu.
- Geben Sie die Größe des Lochs im Donut-Diagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im folgenden Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Speichere die Präsentation auf dem Datenträger
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich ein mehrstufiges Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut-Diagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [Diagrammtyp](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut-Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es zu einem [Rasterbild](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rendern oder das Diagramm zu einem [SVG‑Bild](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) exportieren.