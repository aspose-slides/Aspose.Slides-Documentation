---
title: Grafiekassen aanpassen in presentaties in .NET
linktitle: Grafiekas
type: docs
url: /nl/net/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as‑eigenschappen
- maximale waarde
- minimale waarde
- as‑lijn
- datumformaat
- as‑titel
- as‑positie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor .NET kunt gebruiken om grafiekassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van een diagram kunt aanpassen in Aspose.Slides. Het laat zien hoe u de werkelijke aswaarden kunt verkrijgen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categorie-as kunt wijzigen, het datumformaat voor categorie-aswaarden kunt instellen, een as‑titel kunt roteren, de as‑positie kunt instellen en een eenheids‑label op de waardenas kunt weergeven.

## **De maximale waarden op de verticale as van diagrammen ophalen**
Aspose.Slides for .NET stelt u in staat de minimum‑ en maximumwaarden op een verticale as te verkrijgen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Haal de werkelijke maximale waarde van de as op.
5. Haal de werkelijke minimumwaarde van de as op.
6. Haal de werkelijke hoofd‑eenheid van de as op.
7. Haal de werkelijke sub‑eenheid van de as op.
8. Haal de werkelijke schaal van de hoofd‑eenheid van de as op.
9. Haal de werkelijke schaal van de sub‑eenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—laat zien hoe u de vereiste waarden in C# kunt ophalen:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Slaat de presentatie op
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Gegevens tussen assen verwisselen**
Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen te verwisselen—de gegevens die op de verticale as (y‑as) staan, worden verplaatst naar de horizontale as (x‑as) en omgekeerd.

Deze C#‑code laat zien hoe u de gegevenswissel‑taak tussen assen in een diagram kunt uitvoeren:

```c#
// Maakt lege presentatie
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Verwisselt rijen en kolommen
	chart.ChartData.SwitchRowColumn();
		   
	// Slaat presentatie op
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **De verticale as voor lijndiagrammen uitschakelen**
Deze C#‑code laat zien hoe u de verticale as voor een lijndiagram kunt verbergen:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **De horizontale as voor lijndiagrammen uitschakelen**
Deze code laat zien hoe u de horizontale as voor een lijndiagram kunt verbergen:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Een categorie‑as wijzigen**
Met behulp van de eigenschap **CategoryAxisType** kunt u het gewenste type categorie‑as opgeven (**date** of **text**). Deze C#‑code demonstreert de bewerking:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Het datumformaat voor categorie‑aswaarden instellen**
Aspose.Slides for .NET maakt het mogelijk om het datumformaat voor een categorie‑aswaarde in te stellen. De bewerking wordt gedemonstreerd in deze C#‑code:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Een rotatie‑hoek voor een diagram‑as‑titel instellen**
Aspose.Slides for .NET maakt het mogelijk om de rotatie‑hoek voor een diagram‑as‑titel in te stellen. Deze C#‑code demonstreert de bewerking:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **De as‑positie op een categorie‑ of waardenas instellen**
Aspose.Slides for .NET maakt het mogelijk om de positie van de as in een categorie‑ of waardenas in te stellen. Deze C#‑code laat zien hoe u deze taak kunt uitvoeren:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Het weergave‑eenheidslabel op de waardenas van een diagram inschakelen**
Aspose.Slides for .NET maakt het mogelijk om een diagram zo te configureren dat een eenheids‑label op de waardenas wordt weergegeven. Deze C#‑code demonstreert de bewerking:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Assen bieden een [crossing‑instelling](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/axis/crosstype/): u kunt kiezen om te kruisen bij nul, bij de maximale categorie/waarde, of bij een specifiek numeriek getal. Dit is handig om de X‑as omhoog of omlaag te verplaatsen of om een basislijn te benadrukken.

**Hoe kan ik tick‑labels ten opzichte van de as positioneren (naast, buiten, binnen)?**

Stel de [label‑positie](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/axis/majortickmark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine diagrammen.