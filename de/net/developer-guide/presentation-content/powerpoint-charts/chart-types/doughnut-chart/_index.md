---
title: Donut-Diagramm
type: docs
weight: 30
url: /net/doughnut-chart/
keywords: "Donut-Diagramm, Mittelpunktlücke, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Spezifizieren Sie die Mittelpunktlücke in einem Donut-Diagramm in einer PowerPoint-Präsentation in C# oder .NET"
---

## **Mittelpunktlücke im Donut-Diagramm Spezifizieren**
Um die Größe des Lochs in einem Donut-Diagramm anzugeben, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
- Fügen Sie das Donut-Diagramm auf der Folie hinzu.
- Geben Sie die Größe des Lochs in einem Donut-Diagramm an.
- Schreiben Sie die Präsentation auf die Festplatte.

Im unten gegebenen Beispiel haben wir die Größe des Lochs in einem Donut-Diagramm festgelegt.

```c#
// Erstellen Sie eine Instanz der Presentation Klasse
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Schreiben Sie die Präsentation auf die Festplatte
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```