---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor .NET 15.2.0
linktitle: Aspose.Slides voor .NET 15.2.0
type: docs
weight: 140
url: /nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migratie
- legacy code
- moderne code
- legacy aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Bekijk de updates van de openbare API en de breaking changes in Aspose.Slides voor .NET om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 
Deze pagina geeft een overzicht van alle [toegevoegd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) of [verwijderd](/slides/nl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die geïntroduceerd zijn met de Aspose.Slides for .NET 15.2.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
#### **Methoden AddDataPointForDoughnutSeries zijn toegevoegd**
De twee overloads van de IChartDataPointCollection.AddDataPointForDoughnutSeries()‑methode zijn toegevoegd om gegevenspunten toe te voegen aan series van het Doughnut‑grafiektype.
#### **De klasse Aspose.Slides.SmartArt.SmartArtShape is geërfd van de klasse Aspose.Slides.GeometryShape**
De Aspose.Slides.SmartArt.SmartArtShape‑klasse is geërfd van de Aspose.Slides.GeometryShape‑klasse. Deze wijziging verbetert het objectmodel van Aspose.Slides en voegt nieuwe functionaliteiten toe aan de SmartArtShape‑klasse.
#### **Methoden voor het verwijderen van diagramgegevenspunten en diagramcategorieën op index zijn toegevoegd**
De IChartDataPointCollection.RemoveAt(int index)‑methode is toegevoegd om een diagramgegevenspunt te verwijderen op basis van zijn index.
De IChartCategoryCollection.RemoveAt(int index)‑methode is toegevoegd om een diagramcategorie te verwijderen op basis van zijn index.
#### **De PptXPptY‑waarde is toegevoegd aan de Aspose.Slides.Animation.PropertyType‑enumeratie**
De PptXPptY‑waarde is toegevoegd aan de Aspose.Slides.Animation.PropertyType‑enumeratie in het kader van een oplossing voor een serialisatieprobleem.
#### **De System.Drawing.Color GetAutomaticSeriesColor()‑methode is toegevoegd aan Aspose.Slides.Charts.IChartSeries**
De GetAutomaticSeriesColor‑methode geeft een automatische kleur van de serie terug op basis van de seriële index en de grafiekstijl. Deze kleur wordt standaard gebruikt als FillType gelijk is aan NotDefined.
``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```