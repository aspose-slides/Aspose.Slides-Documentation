---
title: Diagramm exportieren
type: docs
weight: 90
url: /de/net/export-chart/
keywords:
- diagramm
- diagramm bild
- diagramm bild extrahieren
- PowerPoint
- präsentation
- C#
- Csharp
- Aspose.Slides für .NET
description: "Holen Sie sich Diagrammbilder aus PowerPoint-Präsentationen in C# oder .NET"
---

## **Diagrammbild abrufen**
Aspose.Slides für .NET bietet Unterstützung für das Extrahieren von Bildern spezifischer Diagramme. Nachfolgend ist ein Beispiel angegeben.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```