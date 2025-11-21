---
title: Doughnut-Diagramme in Präsentationen in .NET anpassen
linktitle: Doughnut-Diagramm
type: docs
weight: 30
url: /de/net/doughnut-chart/
keywords:
- Doughnut-Diagramm
- Zentraler Abstand
- Lochgröße
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Doughnut-Diagramme in Aspose.Slides für .NET erstellen und anpassen können, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentralen Abstand im Donut-Diagramm festlegen**
Um die Größe des Lochs in einem Donut-Diagramm festzulegen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Fügen Sie der Folie ein Donut-Diagramm hinzu.
- Geben Sie die Größe des Lochs im Donut-Diagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im nachstehenden Beispiel haben wir die Größe des Lochs im Donut-Diagramm festgelegt.
```c#
// Erstelle eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Speichere die Präsentation auf dem Datenträger
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich ein mehrstufiges Donut-Diagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut-Diagramm mehrere Reihen hinzu – jede Reihe wird zu einem eigenen Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Reihen in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt den Diagrammtyp Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut-Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist ein Shape; Sie können es in ein [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) exportieren.