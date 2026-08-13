---
title: .NET에서 프레젠테이션 차트 만들기
linktitle: 차트 만들기
type: docs
weight: 30
url: /ko/net/how-to-create-charts-in-a-presentation/
keywords:
- 마이그레이션
- 차트 만들기
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 PowerPoint PPT, PPTX 및 ODP 프레젠테이션에 차트를 만들고, 레거시 및 최신 차트 API를 모두 활용하는 방법을 배웁니다."
---
{{% alert color="info" %}}

새로운 [Aspose.Slides for .NET API](/slides/ko/net/)가 릴리스되었으며 이제 이 단일 제품은 처음부터 PowerPoint 문서를 생성하고 기존 문서를 편집하는 기능을 지원합니다.

{{% /alert %}} 
## **레거시 코드 지원**
13.x 이전의 Aspose.Slides for .NET 버전으로 개발된 레거시 코드를 사용하려면 코드에 약간의 수정을 하면 이전과 같이 작동합니다. 이전 Aspose.Slides for .NET에서 Aspose.Slide 및 Aspose.Slides.Pptx 네임스페이스에 있었던 모든 클래스는 이제 단일 Aspose.Slides 네임스페이스로 병합되었습니다. 레거시 Aspose.Slides API를 사용하여 프레젠테이션에서 처음부터 일반 차트를 생성하는 간단한 코드 스니펫을 살펴보고 새로운 병합 API로 마이그레이션하는 방법을 설명하는 단계를 따라 보세요.
## **레거시 Aspose.Slides for .NET 접근 방식**
```c#
using System.Drawing;

//	PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
using (PresentationEx pres = new PresentationEx())
{
	//	첫 번째 슬라이드에 접근
	SlideEx sld = pres.Slides[0];

	// 기본 데이터로 차트 추가
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	// 차트 제목 설정
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 첫 번째 시리즈에 값 표시 설정
	chart.ChartData.Series[0].Labels.ShowValue = true;

	// 차트 데이터 시트 인덱스 설정 
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트 가져오기
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	// 기본 생성된 시리즈와 카테고리 삭제
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	// 새 시리즈 추가
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	// 새 카테고리 추가
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	// 첫 번째 차트 시리즈 가져오기
	ChartSeriesEx series = chart.ChartData.Series[0];

	// 이제 시리즈 데이터 채우기
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	// 시리즈 채우기 색상 설정
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	// 두 번째 차트 시리즈 가져오기
	series = chart.ChartData.Series[1];

	// 이제 시리즈 데이터 채우기
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	// 시리즈 채우기 색상 설정
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	// 새 시리즈의 각 카테고리에 대한 사용자 정의 레이블 생성

	// 첫 번째 레이블은 카테고리 이름을 표시합니다
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	// 두 번째 레이블에 시리즈 이름 표시
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	// 세 번째 레이블에 값 표시
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	// 값 및 사용자 정의 텍스트 표시
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	// 차트와 함께 프레젠테이션 저장
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **새 Aspose.Slides for .NET 13.x 접근 방식**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//Instantiate Presentation class that represents PPTX file//Instantiate Presentation class that represents PPTX file
Presentation pres = new Presentation();

//Access first slide
	ISlide sld = pres.Slides[0];

// Add chart with default data
	IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Setting chart Title
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

//Getting the chart data worksheet
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Delete default generated series and categories
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Adding new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Set first series to Show Values
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Adding new categories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Take first chart series
	IChartSeries series = chart.ChartData.Series[0];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Take second chart series
series = chart.ChartData.Series[1];

//Now populating series data
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Setting fill color for series
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//create custom labels for each of categories for new series
//first label will be show Category name
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Save presentation with chart
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

레거시 Aspose.Slides API를 사용하여 프레젠테이션에서 처음부터 분산형 차트를 생성하는 간단한 코드 스니펫을 살펴보고 새로운 병합 API로 이를 구현하는 방법을 확인해 보세요.
## **레거시 Aspose.Slides for .NET 접근 방식**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    // 기본 차트를 생성합니다
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    // 기본 차트 데이터 워크시트 인덱스를 가져옵니다
    int defaultWorksheetIndex = 0;

    // 차트 데이터 워크시트에 접근합니다
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    // 데모 시리즈 삭제
    chart.ChartData.Series.Clear();

    // 새 시리즈 추가
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    // 첫 번째 차트 시리즈 가져오기
    ChartSeriesEx series = chart.ChartData.Series[0];

    // 새 포인트 (1:3) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    // 새 포인트 (2:10) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    // 시리즈 유형 편집
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    // 차트 시리즈 마커 변경
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    // 두 번째 차트 시리즈 가져오기
    series = chart.ChartData.Series[1];

    // 새 포인트 (5:2) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    // 새 포인트 (3:1) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    // 새 포인트 (2:2) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    // 새 포인트 (5:1) 추가
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    // 차트 시리즈 마커 변경
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **새 Aspose.Slides for .NET 13.x 접근 방식**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// 기본 차트를 생성합니다
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// 기본 차트 데이터 워크시트 인덱스를 가져옵니다
int defaultWorksheetIndex = 0;

// 차트 데이터 워크시트에 접근합니다
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 데모 시리즈 삭제
chart.ChartData.Series.Clear();

// 새 시리즈 추가
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

// 첫 번째 차트 시리즈 가져오기
IChartSeries series = chart.ChartData.Series[0];

// 해당 위치에 새 포인트 (1:3) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// 새 포인트 (2:10) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// 시리즈 유형 편집
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// 차트 시리즈 마커 변경
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// 두 번째 차트 시리즈 가져오기
series = chart.ChartData.Series[1];

// 해당 위치에 새 포인트 (5:2) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// 새 포인트 (3:1) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// 새 포인트 (2:2) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// 새 포인트 (5:1) 추가
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// 차트 시리즈 마커 변경
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```