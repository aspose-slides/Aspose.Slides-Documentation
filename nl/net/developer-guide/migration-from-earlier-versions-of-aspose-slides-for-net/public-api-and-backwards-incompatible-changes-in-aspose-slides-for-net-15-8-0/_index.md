---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.8.0
linktitle: Aspose.Slides voor .NET 15.8.0
type: docs
weight: 190
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- migratie
- oude code
- moderne code
- oude aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor .NET om soepel uw PowerPoint PPT, PPTX en ODP presentaties te migreren."
---
{{% alert color="info" %}} 

Deze pagina bevat een lijst van alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) of [verwijderd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides voor .NET 15.8.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Eigenschap DoughnutHoleSize is toegevoegd aan IChartSeries en ChartSeries**
Specificeert de grootte van het gat in een donutgrafiek.

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