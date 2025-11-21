---
title: ".NET のプレゼンテーション チャートでコールアウトを管理する"
linktitle: "コールアウト"
type: docs
url: /ja/net/callout/
keywords:
- "チャート コールアウト"
- "コールアウトの使用"
- "データ ラベル"
- "ラベル形式"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PPT と PPTX に対応した簡潔な C# コード例でコールアウトを作成およびスタイル設定し、プレゼンテーション ワークフローを自動化します。"
---

## **Using Callouts**
新しいプロパティ **ShowLabelAsDataCallout** が **DataLabelFormat** クラスと **IDataLabelFormat** インターフェイスに追加されました。このプロパティは、指定したチャートのデータラベルをデータコールアウトとして表示するか、データラベルとして表示するかを決定します。以下の例では、コールアウトを設定しています。
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




## **Set Callout for Doughnut Chart**
Aspose.Slides for .NET は、ドーナツチャートの系列データラベルコールアウト形状の設定をサポートしています。以下にサンプル例を示します。
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

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

はい。コールアウトはチャートのレンダリングの一部であるため、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/net/export-to-html5/)、[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)、または[ラスタ画像](/slides/ja/net/convert-powerpoint-to-png/) にエクスポートする際、スライドの書式とともに保持されます。

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

はい。Aspose.Slides はプレゼンテーションへの[フォント埋め込み](/slides/ja/net/embedded-font/) をサポートしており、[PDF](/slides/ja/net/convert-powerpoint-to-pdf/) などへのエクスポート時にフォント埋め込みを制御します。その結果、コールアウトは異なるシステム間でも同じ外観が保たれます。