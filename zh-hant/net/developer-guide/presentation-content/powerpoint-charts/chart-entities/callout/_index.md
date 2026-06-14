---
title: 在 .NET 中管理簡報圖表的呼叫線
linktitle: 呼叫線
type: docs
url: /zh-hant/net/callout/
keywords:
- 圖表呼叫線
- 使用呼叫線
- 資料標籤
- 標籤格式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用精簡的 C# 程式碼範例，在 Aspose.Slides for .NET 中建立與樣式化呼叫線，支援 PPT 與 PPTX，協助自動化簡報工作流程。"
---
## **概觀**

此文章說明如何在 Aspose.Slides 中使用圖表資料標籤的呼叫線。它展示了如何使用 `ShowLabelAsDataCallout` 屬性將標籤顯示為呼叫線，如何為環形圖設定與呼叫線相關的標籤設定，並說明在將簡報匯出為 PDF、HTML5、SVG 以及點陣圖像格式時，呼叫線及其外觀會被保留。

## **使用呼叫線**
已在 **DataLabelFormat** 類別及 **IDataLabelFormat** 介面中加入新屬性 **ShowLabelAsDataCallout**，此屬性決定指定圖表的資料標籤是以資料呼叫線還是資料標籤顯示。在下方範例中，我們已設定呼叫線。

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

## **為環形圖設定呼叫線**
Aspose.Slides for .NET 提供設定環形圖系列資料標籤呼叫線形狀的功能。以下提供範例程式碼。

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

## **常見問題**

**將簡報轉換為 PDF、HTML5、SVG 或影像時，呼叫線會被保留嗎？**

會。呼叫線是圖表渲染的一部分，當您匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/net/export-to-html5/)、[SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)、或 [raster images](/slides/zh-hant/net/convert-powerpoint-to-png/) 時，它們會與投影片的格式一起被保留。

**自訂字型在呼叫線中是否可用，且其外觀在匯出時能否保留？**

會。Aspose.Slides 支援將[嵌入字型](/slides/zh-hant/net/embedded-font/)嵌入簡報，並在匯出為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) 等格式時控制字型嵌入，確保呼叫線在不同系統上外觀一致。