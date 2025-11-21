---
title: Öffentliches API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.8.0
linktitle: Aspose.Slides für .NET 15.8.0
type: docs
weight: 190
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Öffentliche API-Updates und kritische Änderungen in Aspose.Slides für .NET überprüfen, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}}

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.8.0 API eingeführt wurden.

{{% /alert %}}
## **Öffentliche API-Änderungen**
#### **Die Eigenschaft DoughnutHoleSize wurde zu IChartSeries und ChartSeries hinzugefügt**
Gibt die Größe des Lochs in einem Donut-Diagramm an.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```