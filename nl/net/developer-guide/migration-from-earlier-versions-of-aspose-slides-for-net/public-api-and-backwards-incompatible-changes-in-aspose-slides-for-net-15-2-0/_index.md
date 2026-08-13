---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.2.0
linktitle: Aspose.Slides voor .NET 15.2.0
type: docs
weight: 140
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor .NET om uw PowerPoint-PPT, PPTX en ODP presentatie-oplossingen soepel te migreren."
---
{{% alert color="info" %}}
Deze pagina geeft een overzicht van alle [added](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) of [removed](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klassen, methoden, eigenschappen, enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.2.0 API.
{{% /alert %}}
## **Public API Changes**
#### **AddDataPointForDoughnutSeries Methods Have Been Added**
De twee overloads van de methode IChartDataPointCollection.AddDataPointForDoughnutSeries() zijn toegevoegd om gegevenspunten toe te voegen aan series van het Doughnut-grafiektype.
#### **Aspose.Slides.SmartArt.SmartArtShape Class Has Been Inherited from Aspose.Slides.GeometryShape Class**
De klasse Aspose.Slides.SmartArt.SmartArtShape is geërfd van de klasse Aspose.Slides.GeometryShape. Deze wijziging verbetert het objectmodel van Aspose.Slides en voegt nieuwe functies toe aan de SmartArtShape‑klasse.
#### **Methods for Removing Chart Data Point and Chart Category by Index Has Been Added**
De methode IChartDataPointCollection.RemoveAt(int index) is toegevoegd om een grafiek‑datapunt te verwijderen op basis van zijn index.  
De methode IChartCategoryCollection.RemoveAt(int index) is toegevoegd om een grafiek‑categorie te verwijderen op basis van zijn index.
#### **PptXPptY Value Has Been Added to Aspose.Slides.Animation.PropertyType Enumeration**
De waarde PptXPptY is toegevoegd aan de enumeratie Aspose.Slides.Animation.PropertyType in het kader van een reparatie van een serialisatie‑probleem.
#### **System.Drawing.Color GetAutomaticSeriesColor() Method Has Been Added to Aspose.Slides.Charts.IChartSeries**
De methode GetAutomaticSeriesColor retourneert een automatische kleur voor een serie op basis van de serie‑index en de grafiekstijl. Deze kleur wordt standaard gebruikt wanneer FillType gelijk is aan NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```