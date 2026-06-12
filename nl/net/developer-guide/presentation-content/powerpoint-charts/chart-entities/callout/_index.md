---
title: Callouts beheren in presentatie‑diagrammen in .NET
linktitle: Callout
type: docs
url: /nl/net/callout/
keywords:
- grafiek‑callout
- callout gebruiken
- gegevenslabel
- labelindeling
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en style callouts in Aspose.Slides voor .NET met beknopte C# codevoorbeelden, compatibel met PPT en PPTX om presentatieworkflows te automatiseren."
---
## **Overzicht**

Dit artikel legt uit hoe u callouts voor gegevenslabels in diagrammen in Aspose.Slides kunt gebruiken. Het toont hoe u de eigenschap `ShowLabelAsDataCallout` kunt gebruiken om labels als callouts weer te geven, hoe u callout‑gerelateerde labelinstellingen voor een donuts‑diagram kunt configureren, en vermeldt dat callouts en hun weergave behouden blijven wanneer presentaties worden geëxporteerd naar PDF, HTML5, SVG en raster‑afbeeldingsformaten.

## **Callouts gebruiken**
Er is een nieuwe eigenschap **ShowLabelAsDataCallout** toegevoegd aan de klasse **DataLabelFormat** en de interface **IDataLabelFormat**, die bepaalt of het gegevenslabel van het opgegeven diagram wordt weergegeven als data‑callout of als gegevenslabel. In het onderstaande voorbeeld hebben we de callouts ingesteld.

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```

## **Een callout instellen voor een donuts‑diagram**
Aspose.Slides for .NET biedt ondersteuning voor het instellen van de callout‑vorm van serie‑gegevenslabels voor een donuts‑diagram. Hieronder staat een voorbeeld.

```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Worden callouts behouden bij het converteren van een presentatie naar PDF, HTML5, SVG of afbeeldingen?**

Ja. Callouts maken deel uit van de diagramweergave, dus wanneer u exporteert naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/),[HTML5](/slides/nl/net/export-to-html5/),[SVG](/slides/nl/net/render-a-slide-as-an-svg-image/) of [rasterafbeeldingen](/slides/nl/net/convert-powerpoint-to-png/), blijven ze behouden samen met de opmaak van de dia.

**Werken aangepaste lettertypen in callouts, en kan hun weergave behouden blijven bij exporteren?**

Ja. Aspose.Slides ondersteunt het [inbedden van lettertypen](/slides/nl/net/embedded-font/) in de presentatie en beheert het inbedden van lettertypen tijdens exporten zoals [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), zodat de callouts er op verschillende systemen identiek uitzien.