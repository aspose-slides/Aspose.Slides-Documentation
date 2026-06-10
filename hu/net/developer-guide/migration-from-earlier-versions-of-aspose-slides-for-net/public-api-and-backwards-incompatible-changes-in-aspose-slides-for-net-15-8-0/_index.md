---
title: Aspose.Slides for .NET 15.8.0 nyilvános API és visszafelé nem kompatibilis változások
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) osztályt, metódust, tulajdonságot és hasonlókat, valamint az Aspose.Slides for .NET 15.8.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API-változások**
#### **A DoughnutHoleSize tulajdonság hozzá lett adva az IChartSeries és a ChartSeries típusokhoz**
Megadja a cukorka diagram lyukának méretét.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```