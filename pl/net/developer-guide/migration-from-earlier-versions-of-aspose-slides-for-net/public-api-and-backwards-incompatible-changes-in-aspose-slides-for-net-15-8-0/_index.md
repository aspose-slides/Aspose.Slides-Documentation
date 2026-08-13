---
title: Public API i zmiany niezgodne wstecz w Aspose.Slides dla .NET 15.8.0
linktitle: Aspose.Slides dla .NET 15.8.0
type: docs
weight: 190
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- starsze podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) klasy, metody, własności i podobne, a także inne zmiany wprowadzone w API Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Właściwość DoughnutHoleSize została dodana do IChartSeries i ChartSeries**
Określa rozmiar otworu w wykresie pierścieniowym.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}
```