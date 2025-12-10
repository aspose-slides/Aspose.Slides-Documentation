---
title: Anpassen von Donutdiagrammen in Präsentationen in .NET
linktitle: Donutdiagramm
type: docs
weight: 30
url: /de/net/doughnut-chart/
keywords:
- Donutdiagramm
- zentrale Lücke
- Lochgröße
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Entdecken Sie, wie Sie Donutdiagramme in Aspose.Slides für .NET erstellen und anpassen, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Geben Sie die zentrale Lücke in einem Donutdiagramm an**
Um die Größe des Lochs in einem Donutdiagramm anzugeben, folgen Sie bitte den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Fügen Sie dem Folie ein Donutdiagramm hinzu.
- Geben Sie die Größe des Lochs in einem Donutdiagramm an.
- Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs in einem Donutdiagramm festgelegt.
```c#
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Kann ich ein mehrstufiges Donutdiagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donutdiagramm mehrere Datenreihen hinzu – jede Reihe wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Datenreihen in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donutdiagramm (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [Diagrammtyp](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donutdiagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Rasterbild](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) exportieren.