---
title: Beheer gegevensmarkers van grafieken in presentaties in .NET
linktitle: Gegevensmarker
type: docs
url: /nl/net/chart-data-marker/
keywords:
- grafiek
- gegevenspunt
- markering
- markeringopties
- markeringgrootte
- vullingstype
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u grafiekgegevensmarkers kunt aanpassen in Aspose.Slides voor .NET, waardoor de impact van presentaties in PPT- en PPTX-formats wordt vergroot met duidelijke C#-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe je met gegevensmarkers van grafieken werkt in Aspose.Slides. Het toont hoe je een grafiek maakt, toegang krijgt tot een reeks en de gegevenspunten ervan, afbeeldingvullingen toepast op markers op het niveau van gegevenspunten, de marker‑grootte aanpast en de bijgewerkte presentatie opslaat. Het vermeldt ook dat standaard marker‑vormen beschikbaar zijn via de `MarkerStyleType`‑enumeratie en dat de weergave van markers behouden blijft bij het exporteren van grafieken naar rasterformaten of SVG.

## **Instellen van grafiekmarkeringsopties**
De markers kunnen worden ingesteld op grafiekgegevenspunten binnen specifieke reeksen. Om grafiekmarkeringsopties in te stellen, volg je de onderstaande stappen:

- Instantieren van de klasse [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation).
- Maak de standaardgrafiek aan.
- Stel de afbeelding in.
- Neem de eerste grafiekreeks.
- Voeg een nieuw gegevenspunt toe.
- Schrijf de presentatie naar schijf.

```c#
// Maak een instantie van de Presentation-klasse
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Maak de standaardgrafiek aan
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Haalt de index van het standaardgrafiekgegevenswerkblad op
int defaultWorksheetIndex = 0;

// Haalt het grafiekgegevenswerkblad op
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Verwijder demo-reeks
chart.ChartData.Series.Clear();

// Voeg nieuwe reeks toe
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Stel de afbeelding in
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Stel de afbeelding in
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Neem de eerste grafiekreeks
IChartSeries series = chart.ChartData.Series[0];

// Voeg nieuw punt (1:3) daar toe.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Wijzig de marker van de grafiekreeks
series.Marker.Size = 15;

// Schrijf de presentatie naar schijf
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **Veelgestelde vragen**

**Welke marker‑vormen zijn er standaard beschikbaar?**

Standaardvormen zijn beschikbaar (cirkel, vierkant, ruit, driehoek, enz.); de lijst wordt bepaald door de [MarkerStyleType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/markerstyletype/)‑enumeratie. Als je een niet‑standaardvorm nodig hebt, gebruik dan een marker met een afbeeldingvulling om aangepaste visuals te emuleren.

**Worden markers behouden bij het exporteren van een grafiek naar een afbeelding of SVG?**

Ja. Bij het renderen van grafieken naar [rasterformaten](/slides/nl/net/convert-powerpoint-to-png/) of het opslaan van [vormen als SVG](/slides/nl/net/render-a-slide-as-an-svg-image/), behouden markers hun weergave en instellingen, inclusief grootte, vulling en omtrek.