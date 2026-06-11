---
title: Hantera anmärkningar i presentationsdiagram i .NET
linktitle: Anmärkning
type: docs
url: /sv/net/callout/
keywords:
- diagramanmärkning
- använd anmärkning
- datamärkning
- etikettformat
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och formatera anmärkningar i Aspose.Slides för .NET med koncisa C#-kodexempel, kompatibla med PPT och PPTX för att automatisera presentationsarbetsflöden."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med anmärkningar för diagramdatamärkningar i Aspose.Slides. Den visar hur man använder egenskapen `ShowLabelAsDataCallout` för att visa märken som anmärkningar, hur man konfigurerar anmärkningrelaterade märkesinställningar för ett munkdiagram, och noterar att anmärkningar och deras utseende bevaras när presentationer exporteras till PDF, HTML5, SVG och rasterbildformat.

## **Använda anmärkningar**

Den nya egenskapen **ShowLabelAsDataCallout** har lagts till i klassen **DataLabelFormat** och gränssnittet **IDataLabelFormat**, vilket bestämmer om ett angivet diagramdatamärke ska visas som dataanmärkning eller som datamärke. I exemplet nedan har vi angett anmärkningarna.

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

## **Ange en anmärkning för ett munkdiagram**

Aspose.Slides för .NET erbjuder stöd för att ställa in serie‑datamärkesanmärkningsformen för ett munkdiagram. Nedanstående exempel ges.

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

**Behåller anmärkningar sig när en presentation konverteras till PDF, HTML5, SVG eller bilder?**

Ja. Anmärkningar är en del av diagramrenderingen, så när du exporterar till [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [HTML5](/slides/sv/net/export-to-html5/), [SVG](/slides/sv/net/render-a-slide-as-an-svg-image/), eller [rasterbilder](/slides/sv/net/convert-powerpoint-to-png/), bevaras de tillsammans med bildens formatering.

**Fungerar anpassade typsnitt i anmärkningar, och kan deras utseende bevaras vid export?**

Ja. Aspose.Slides stöder [inbäddning av typsnitt](/slides/sv/net/embedded-font/) i presentationen och styr typsnittsinbäddning vid exporter såsom [PDF](/slides/sv/net/convert-powerpoint-to-pdf/), vilket säkerställer att anmärkningarna ser likadana ut på olika system.