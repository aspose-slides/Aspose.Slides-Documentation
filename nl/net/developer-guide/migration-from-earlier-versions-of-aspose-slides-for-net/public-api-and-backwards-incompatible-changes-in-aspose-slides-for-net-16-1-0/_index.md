---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 16.1.0
linktitle: Aspose.Slides voor .NET 16.1.0
type: docs
weight: 220
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "Bekijk de updates van de openbare API en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint PPT, PPTX en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 
Deze pagina toont alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) of [verwijderd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 16.1.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**

#### **Eigenschap RotationAngle is toegevoegd aan de interfaces IChartTextBlockFormat en ITextFrameFormat**
Eigenschap RotationAngle is toegevoegd aan de interfaces Aspose.Slides.Charts.IChartTextBlockFormat en Aspose.Slides.ITextFrameFormat.  
Het specificeert de aangepaste rotatie die wordt toegepast op de tekst binnen het omgrenzende vak.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException verplaatst van Aspose.Slides.Odp naar de Aspose.Slides-namespace**