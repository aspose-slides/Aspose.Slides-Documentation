---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 15.8.0
type: docs
weight: 190
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
---

{{% alert color="primary" %}}

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) Klassen, Methoden, Eigenschaften und so weiter sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 15.8.0 API eingeführt wurden.

{{% /alert %}}
## **Änderungen der öffentlichen API**
#### **Die Eigenschaft DoughnutHoleSize wurde zu IChartSeries und ChartSeries hinzugefügt**
Gibt die Größe des Lochs in einem Donut-Diagramm an.

```csharp
 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```