---
title: "Cirkeldiagrammen aanpassen in presentaties in .NET"
linktitle: "Cirkeldiagram"
type: docs
url: /nl/net/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u cirkeldiagrammen maakt en aanpast in .NET met Aspose.Slides, exporteerbaar naar PowerPoint, waardoor uw dataverhaal in enkele seconden wordt verbeterd."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen werkt in Aspose.Slides. Het laat zien hoe u secundaire plotopties kunt configureren voor Pie of Pie- en Bar of Pie-diagrammen, en hoe u automatische kleuring van segmenten voor een standaard cirkeldiagram kunt inschakelen.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals een diagram toevoegen aan een dia, series- en labelinstellingen aanpassen, standaard diagramgegevens vervangen door aangepaste categorieën en waarden, en de bijgewerkte presentatie opslaan.

## **Secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen**
Aspose.Slides for .NET ondersteunt nu secundaire plotopties voor een Pie of Pie- of Bar of Pie-diagram. In dit onderwerp laten we met een voorbeeld zien hoe deze opties te specificeren met Aspose.Slides. Volg hiervoor de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation).
1. Voeg een diagram toe aan de dia.
1. Specificeer de secundaire plotopties van het diagram.
1. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie-diagram ingesteld.

```c#
// Maak een instantie van de Presentation-klasse
Presentation presentation = new Presentation();

// Voeg een diagram toe aan de dia
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Stel verschillende eigenschappen in
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Schrijf de presentatie naar schijf
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Automatische kleuring van cirkeldiagramsegmenten instellen**
Aspose.Slides for .NET biedt een eenvoudige API voor het instellen van automatische kleuren voor cirkeldiagramsegmenten. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de Presentation‑klasse.
1. Navigeer naar de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de titel van het diagram in.
1. Stel de eerste serie in om waarden te tonen.
1. Stel de index van het gegevensblad van het diagram in.
1. Haal het werkblad met diagramgegevens op.
1. Verwijder de standaard gegenereerde series en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg een nieuwe serie toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```c#
// Instantie van de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
	// Instantie van de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
	Presentation presentation = new Presentation();

	// Toegang tot de eerste dia
	ISlide slides = presentation.Slides[0];

	// Diagram toevoegen met standaardgegevens
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Diagramtitel instellen
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Eerste serie instellen om waarden weer te geven
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Index van het diagramgegevensblad instellen
	int defaultWorksheetIndex = 0;

	// Werkblad met diagramgegevens ophalen
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Standaard gegenereerde series en categorieën verwijderen
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Nieuwe categorieën toevoegen
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Nieuwe serie toevoegen
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Seriesgegevens nu vullen
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```
## **FAQ**

**Wordt de 'Pie of Pie' en 'Bar of Pie' variant ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de types 'Pie of Pie' en 'Bar of Pie'.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/) (bijvoorbeeld PNG) zonder de volledige presentatie.