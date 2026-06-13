---
title: .NET에서 프레젠테이션 차트의 콜아웃 관리
linktitle: 콜아웃
type: docs
url: /ko/net/callout/
keywords:
- 차트 콜아웃
- 콜아웃 사용
- 데이터 레이블
- 레이블 형식
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 간결한 C# 코드 예제를 사용하여 콜아웃을 만들고 스타일을 지정하며, PPT 및 PPTX와 호환되어 프레젠테이션 워크플로를 자동화합니다."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 차트 데이터 레이블에 대한 콜아웃을 사용하는 방법을 설명합니다. `ShowLabelAsDataCallout` 속성을 사용하여 레이블을 콜아웃으로 표시하는 방법, 도넛 차트에 대한 콜아웃 관련 레이블 설정을 구성하는 방법, 그리고 프레젠테이션을 PDF, HTML5, SVG 및 래스터 이미지 형식으로 내보낼 때 콜아웃과 그 모양이 유지된다는 점을 보여줍니다.

## **Using Callouts**
새 속성 **ShowLabelAsDataCallout** 가 **DataLabelFormat** 클래스와 **IDataLabelFormat** 인터페이스에 추가되었습니다. 이 속성은 지정된 차트의 데이터 레이블을 데이터 콜아웃으로 표시할지 데이터 레이블로 표시할지를 결정합니다. 아래 예제에서는 콜아웃을 설정했습니다.

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



## **Set a Callout for a Doughnut Chart**
Aspose.Slides for .NET은 도넛 차트에 대한 시리즈 데이터 레이블 콜아웃 모양을 설정하는 기능을 제공합니다. 아래 샘플 예제가 제공됩니다.

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

예. 콜아웃은 차트 렌더링의 일부이므로 [PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [HTML5](/slides/ko/net/export-to-html5/), [SVG](/slides/ko/net/render-a-slide-as-an-svg-image/), [raster images](/slides/ko/net/convert-powerpoint-to-png/) 로 내보낼 때 슬라이드의 형식과 함께 유지됩니다.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

예. Aspose.Slides는 프레젠테이션에 [embedding fonts](/slides/ko/net/embedded-font/)을 지원하고, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/)와 같은 내보내기 시 글꼴 포함을 제어하여 콜아웃이 다양한 시스템에서 동일하게 보이도록 합니다.