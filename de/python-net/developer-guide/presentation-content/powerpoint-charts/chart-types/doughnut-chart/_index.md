---
title: Doughnut-Diagramme in Präsentationen mit Python anpassen
linktitle: Doughnut-Diagramm
type: docs
weight: 30
url: /de/python-net/doughnut-chart/
keywords:
- Doughnut-Diagramm
- zentrale Lücke
- Lochgröße
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Doughnut-Diagramme in Aspose.Slides für Python via .NET erstellen und anpassen, wobei PowerPoint- und OpenDocument‑Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentrierte Lücke im Doughnut-Diagramm angeben**
Um die Größe des Lochs in einem Doughnut-Diagramm festzulegen, führen Sie die folgenden Schritte aus:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Fügen Sie dem Folienblatt ein Doughnut-Diagramm hinzu.
- Geben Sie die Größe des Lochs im Doughnut-Diagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im folgenden Beispiel haben wir die Größe des Lochs in einem Doughnut-Diagramm festgelegt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich ein mehrstufiges Doughnut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Doughnut-Diagramm mehrere Datenreihen hinzu – jede Reihe wird zu einem eigenen Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Datenreihen in der Sammlung bestimmt.

**Wird ein „explodiertes“ Doughnut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Diagrammtyp Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft bei Datenpunkten; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Doughnut-Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist ein Shape; Sie können es in ein [Raster‑Bild](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) exportieren.