---
title: Offentlig API och bakåtinkompatibla förändringar i Aspose.Slides för .NET 15.8.0
linktitle: Aspose.Slides för .NET 15.8.0
type: docs
weight: 190
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint PPT, PPTX och ODP presentationslösningar."
---
{{% alert color="primary" %}}
Denna sida listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) eller [borttagna](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) klasser, metoder, egenskaper och så vidare, samt andra förändringar som införts med Aspose.Slides för .NET 15.8.0 API.
{{% /alert %}}
## **Offentliga API-ändringar**
#### **Egenskapen DoughnutHoleSize har lagts till i IChartSeries och ChartSeries**
Anger storleken på hålet i ett munkdiagram.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```