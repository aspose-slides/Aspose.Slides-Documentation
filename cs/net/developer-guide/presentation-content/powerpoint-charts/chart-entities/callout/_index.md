---
title: Správa calloutů v grafech prezentací v .NET
linktitle: Callout
type: docs
url: /cs/net/callout/
keywords:
- callout grafu
- použití calloutu
- popisek dat
- formát popisku
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a upravujte callouty v Aspose.Slides pro .NET pomocí stručných příkladů kódu C#, kompatibilních s PPT a PPTX, pro automatizaci pracovních postupů prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s callouty pro popisky dat v grafech v Aspose.Slides. Ukazuje, jak použít vlastnost `ShowLabelAsDataCallout` k zobrazení popisků jako callouty, jak nakonfigurovat nastavení související s callouty pro doughnut graf a že callouty a jejich vzhled jsou zachovány při exportu prezentací do formátů PDF, HTML5, SVG a rastrových obrázků.

## **Používání calloutů**

Do třídy **DataLabelFormat** a rozhraní **IDataLabelFormat** byla přidána nová vlastnost **ShowLabelAsDataCallout**, která určuje, zda bude popisek dat v daném grafu zobrazen jako callout nebo jako popisek dat. V níže uvedeném příkladu jsme nastavili callouty.

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

## **Nastavení calloutu pro doughnut graf**

Aspose.Slides pro .NET poskytuje podporu pro nastavení tvaru calloutu popisku dat řady pro doughnut graf. Níže je uveden ukázkový příklad.

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

## **Často kladené otázky**

**Zachovají se callouty při konverzi prezentace do PDF, HTML5, SVG nebo obrázků?**

Ano. Callouty jsou součástí vykreslování grafu, takže při exportu do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [HTML5](/slides/cs/net/export-to-html5/), [SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) nebo [rastrální obrázky](/slides/cs/net/convert-powerpoint-to-png/) jsou zachovány spolu s formátováním snímku.

**Fungují vlastní písma v calloutech a lze jejich vzhled zachovat při exportu?**

Ano. Aspose.Slides podporuje [vkládání fontů](/slides/cs/net/embedded-font/) do prezentace a řídí vkládání fontů během exportů, například do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), což zajišťuje, že callouty vypadají stejně na různých systémech.