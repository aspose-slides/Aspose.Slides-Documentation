---
title: ".NET에서 프레젠테이션의 파이 차트 사용자 지정"
linktitle: 파이 차트
type: docs
url: /ko/net/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 맞춤화
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: " .NET에서 Aspose.Slides를 사용하여 파이 차트를 만들고 맞춤화하는 방법을 배우고, PowerPoint로 내보내어 데이터 스토리텔링을 순식간에 강화하세요."
---
## **개요**

이 문서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 대해 자동 슬라이스 색상을 활성화하는 방법을 보여줍니다.

예제에서는 슬라이드에 차트를 추가하고, 시리즈 및 레이블 설정을 조정하며, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 실용적인 차트 사용자 지정 단계를 중점적으로 다룹니다.

## **Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션**

Aspose.Slides for .NET은 이제 Pie of Pie 또는 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이 항목에서는 예제를 통해 Aspose.Slides를 사용하여 이러한 옵션을 지정하는 방법을 살펴보겠습니다. 속성을 지정하려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스를 인스턴스화합니다.
2. 슬라이드에 차트를 추가합니다.
3. 차트의 보조 플롯 옵션을 지정합니다.
4. 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 Pie of Pie 차트의 다양한 속성을 설정했습니다.

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();

// 슬라이드에 차트를 추가합니다
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// 다양한 속성을 설정합니다
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **자동 파이 차트 슬라이스 색상 설정**

Aspose.Slides for .NET은 자동 파이 차트 슬라이스 색상을 설정하기 위한 간단한 API를 제공합니다. 샘플 코드는 앞서 언급한 속성을 적용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터로 차트를 추가합니다.
4. 차트 제목을 설정합니다.
5. 첫 번째 시리즈를 값 표시로 설정합니다.
6. 차트 데이터 시트의 인덱스를 설정합니다.
7. 차트 데이터 워크시트를 가져옵니다.
8. 기본 생성된 시리즈와 카테고리를 삭제합니다.
9. 새 카테고리를 추가합니다.
10. 새 시리즈를 추가합니다.

수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	Presentation presentation = new Presentation();

	// 첫 번째 슬라이드에 접근합니다
	ISlide slides = presentation.Slides[0];

	// 기본 데이터로 차트를 추가합니다
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// 차트 제목 설정
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 첫 번째 시리즈를 값 표시로 설정합니다
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// 차트 데이터 시트 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// 기본 생성된 시리즈와 카테고리를 삭제합니다
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// 새 카테고리를 추가합니다
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// 새 시리즈를 추가합니다
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// 이제 시리즈 데이터를 채웁니다
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **자주 묻는 질문**

**‘Pie of Pie’와 ‘Bar of Pie’ 변형이 지원됩니까?**

예, 해당 라이브러리는 [지원](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/charttype/)합니다. 파이 차트에 대한 보조 플롯을 제공하며, ‘Pie of Pie’와 ‘Bar of Pie’ 유형을 포함합니다.

**차트만 이미지(예: PNG)로 내보낼 수 있나요?**

예, 전체 프레젠테이션 없이 차트 자체를 이미지(예: PNG)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/getimage/).