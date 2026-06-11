---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides for .NET 15.8.0
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides for .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona zawiera listę wszystkich [dodanych](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) lub [usuniętych](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) klas, metod, właściwości itp., oraz innych zmian wprowadzonych w API Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Właściwość DoughnutHoleSize została dodana do IChartSeries i ChartSeries**
Określa rozmiar otworu w wykresie pierścieniowym.

``` csharp

 using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;
   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);
}
```