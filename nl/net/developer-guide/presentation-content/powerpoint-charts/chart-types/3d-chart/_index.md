---
title: 3D-diagrammen aanpassen in presentaties in .NET
linktitle: 3D-diagram
type: docs
url: /nl/net/3d-chart/
keywords:
- 3D-diagram
- rotatie
- diepte
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u 3-D-diagrammen maakt en aanpast in Aspose.Slides voor .NET, met ondersteuning voor PPT- en PPTX-bestanden — verbeter uw presentaties vandaag."
---
## **Overzicht**

Dit artikel legt uit hoe u een 3D-diagram in Aspose.Slides kunt aanpassen door de instellingen van `Rotation3D` te configureren, zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes`. Het leidt u door het maken van een presentatie, het toevoegen van een 3D-diagram met standaardgegevens, het toepassen van de benodigde 3D-weergave‑instellingen en het opslaan van de gewijzigde presentatie als een PPTX‑bestand.

## **Stel de eigenschappen RotationX, RotationY en DepthPercents van een 3D-diagram in**
Aspose.Slides voor .NET biedt een eenvoudige API om deze eigenschappen in te stellen. Dit artikel helpt u bij het instellen van verschillende eigenschappen zoals X‑, Y‑rotatie, **DepthPercents** enz. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de Rotation3D‑eigenschappen in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```c#
// Maak een instantie van de Presentation‑klasse
Presentation presentation = new Presentation();
           
// Toegang tot eerste dia
ISlide slide = presentation.Slides[0];

// Diagram toevoegen met standaardgegevens
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Index van het diagramgegevensblad instellen
int defaultWorksheetIndex = 0;

// Het diagramgegevens-werkblad ophalen
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Serie toevoegen
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Categorieën toevoegen
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D‑eigenschappen instellen
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Neem de tweede diagramserie
IChartSeries series = chart.ChartData.Series[1];

// Serie‑gegevens nu vullen
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Overlap‑waarde instellen
series.ParentSeriesGroup.Overlap = 100;         

// Presentatie naar schijf schrijven
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Welke diagramtypen ondersteunen de 3D-modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑types die verkrijgbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/)‑enumeratie. Voor een exacte en actuele lijst, raadpleeg de leden van [ChartType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/) in de API‑referentie van uw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. U kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/) of de volledige dia [renderen](/slides/nl/net/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer u een pixel‑perfecte weergave nodig heeft of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D-diagrammen?**

De prestaties zijn afhankelijk van het volume aan gegevens en de visuele complexiteit. Voor optimale resultaten houdt u 3D‑effecten minimaal, vermijdt u zware texturen op wanden en plot‑gebieden, beperkt u het aantal gegevenspunten per reeks waar mogelijk, en renderen Sie naar een passend formaat (resolutie en afmetingen) dat overeenkomt met de beoogde weergave‑ of afdrukbehoefte.