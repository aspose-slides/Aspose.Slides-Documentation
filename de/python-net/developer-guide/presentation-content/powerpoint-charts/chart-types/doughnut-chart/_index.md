---
title: Anpassen von Donutdiagrammen in Präsentationen mit Python
linktitle: Donutdiagramm
type: docs
weight: 30
url: /de/python-net/doughnut-chart/
keywords:
- Donutdiagramm
- Zentraler Abstand
- Lochgröße
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donutdiagramme in Aspose.Slides für Python über .NET erstellen und anpassen können, wobei PowerPoint- und OpenDocument-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentrierte Lücke im Donutdiagramm angeben**
Um die Größe des Lochs in einem Donutdiagramm anzugeben, folgen Sie bitte den untenstehenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Fügen Sie dem Folie ein Donutdiagramm hinzu.
- Geben Sie die Größe des Lochs im Donutdiagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im nachstehenden Beispiel haben wir die Größe des Lochs im Donutdiagramm festgelegt.
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

**Kann ich ein mehrstufiges Donutdiagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donutdiagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donutdiagramm (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft bei Datenpunkten; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donutdiagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) exportieren.