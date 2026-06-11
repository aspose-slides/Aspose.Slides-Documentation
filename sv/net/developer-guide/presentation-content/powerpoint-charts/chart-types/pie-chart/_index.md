---
title: Anpassa cirkeldiagram i presentationer i .NET
linktitle: Cirkeldiagram
type: docs
url: /sv/net/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar cirkeldiagram i .NET med Aspose.Slides, exportera till PowerPoint, och förbättra ditt databerättande på sekunder."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med cirkeldiagram i Aspose.Slides. Den visar hur du konfigurerar sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram samt hur du aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden samt spara den uppdaterade presentationen.

## **Sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram**
Aspose.Slides för .NET stöder nu sekundära plotalternativ för Pie of Pie- eller Bar of Pie-diagram. I det här avsnittet ser vi med ett exempel hur du anger dessa alternativ med Aspose.Slides. Följ stegen nedan för att ange egenskaperna:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klassobjekt.
1. Lägg till diagram på bilden.
1. Ange diagrammets sekundära plotalternativ.
1. Skriv presentationen till disk.

I exemplet nedan har vi ställt in olika egenskaper för Pie of Pie-diagrammet.

```c#
 // Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation();

 // Lägg till diagram på bilden
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
 // Ställ in olika egenskaper
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

 // Skriv presentationen till disk
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Ställ in automatisk färgläggning för cirkeldiagramsegment**
Aspose.Slides för .NET tillhandahåller ett enkelt API för att automatiskt färglägga cirkeldiagramsegment. Exempelkoden tillämpar de ovan nämnda inställningarna.

1. Skapa en instans av Presentation-klassen.
1. Åtkomst till första bilden.
1. Lägg till diagram med standarddata.
1. Ställ in diagramrubrik.
1. Ställ in den första serien att Visa värden.
1. Ställ in index för diagrammets datasheet.
1. Hämta diagrammets dataarbetsblad.
1. Ta bort standardgenererade serier och kategorier.
1. Lägg till nya kategorier.
1. Lägg till ny serie.

Skriv den modifierade presentationen till en PPTX‑fil.

```c#
 // Instansiera Presentation-klass som representerar PPTX-fil
using (Presentation presentation = new Presentation())
{
	// Instansiera Presentation-klass som representerar PPTX-fil
	Presentation presentation = new Presentation();

	// Åtkomst till första bilden
	ISlide slides = presentation.Slides[0];

	// Lägg till diagram med standarddata
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Ställ in diagramrubrik
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Ställ in den första serien till Visa värden
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Ställ in index för diagrammets datasheet
	int defaultWorksheetIndex = 0;

	// Hämta diagrammets dataarbetsblad
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Ta bort standardgenererade serier och kategorier
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Lägg till nya kategorier
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Lägg till ny serie
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Nu fyller på seriedata
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Stöds varianterna 'Pie of Pie' och 'Bar of Pie'?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/) ett sekundärt plot för cirkeldiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera bara diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/) (t.ex. PNG) utan hela presentationen.