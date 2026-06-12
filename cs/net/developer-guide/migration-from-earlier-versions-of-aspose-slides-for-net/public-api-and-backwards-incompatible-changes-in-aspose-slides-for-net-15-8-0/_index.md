---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.8.0
linktitle: Aspose.Slides pro .NET 15.8.0
type: docs
weight: 190
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbíjející změny v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 
Tato stránka uvádí všechny [added](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) nebo [removed](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v Aspose.Slides for .NET 15.8.0 API.
{{% /alert %}} 
## **Public API Changes**
#### **Property DoughnutHoleSize Has Been Added to IChartSeries and ChartSeries**
Určuje velikost otvoru v prstencovém grafu.
``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```