---
title: "Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.8.0-ban"
linktitle: "Aspose.Slides for .NET 15.8.0"
type: docs
weight: 190
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a szakadásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}}

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.8.0 API-val bevezetett egyéb változásokat.

{{% /alert %}}
## **Nyilvános API módosítások**
#### **A DoughnutHoleSize tulajdonság hozzá lett adva az IChartSeries és a ChartSeries osztályokhoz**
Megadja a fánk diagram lyukának méretét.

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