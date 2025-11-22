---
title: Donut-Diagramm
type: docs
weight: 30
url: /de/net/doughnut-chart/
keywords: "Donut-Diagramm, Lückenmitte, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Zentralen Abstand im Donut-Diagramm in einer PowerPoint-Präsentation in C# oder .NET festlegen"
---

## **Zentralen Abstand im Donut-Diagramm angeben**
Um die Größe des Lochs in einem Donut-Diagramm anzugeben, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Fügen Sie ein Donut-Diagramm zur Folie hinzu.
- Geben Sie die Größe des Lochs im Donut-Diagramm an.
- Schreiben Sie die Präsentation auf die Festplatte.

Im untenstehenden Beispiel haben wir die Größe des Lochs im Donut-Diagramm festgelegt.
```c#
// Erstelle eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Speichere die Präsentation auf der Festplatte
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich einen mehrstufigen Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut-Diagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodierter“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) sowie eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut-Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) exportieren.