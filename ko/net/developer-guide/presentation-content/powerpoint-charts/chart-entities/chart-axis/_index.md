---
title: .NET에서 프레젠테이션 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/net/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 사용자 지정
- 축 조작
- 축 관리
- 축 속성
- 최댓값
- 최솟값
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Aspose.Slides for .NET을 사용하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 축을 사용자 지정하는 방법을 설명합니다. 실제 축 값 가져오기, 축 간 데이터 교환, 라인 차트에서 세로 또는 가로 축 숨기기, 범주 축 유형 변경, 범주 축 값의 날짜 형식 설정, 축 제목 회전, 축 위치 지정, 값 축에 단위 레이블 표시 방법을 보여줍니다.

## **차트 세로 축의 최대값 가져오기**
Aspose.Slides for .NET을 사용하면 세로 축의 최소값과 최대값을 가져올 수 있습니다. 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 액세스합니다.
3. 기본 데이터가 포함된 차트를 추가합니다.
4. 축에서 실제 최대값을 가져옵니다.
5. 축에서 실제 최소값을 가져옵니다.
6. 축의 실제 주요 단위를 가져옵니다.
7. 축의 실제 부단위를 가져옵니다.
8. 축의 실제 주요 단위 스케일을 가져옵니다.
9. 축의 실제 부단위 스케일을 가져옵니다.

위 단계들을 구현한 샘플 코드는 C#에서 필요한 값을 가져오는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// 프레젠테이션을 저장합니다
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **축 간 데이터 교환**
Aspose.Slides를 사용하면 축 간 데이터를 빠르게 교환할 수 있습니다—세로 축(y축)의 데이터가 가로 축(x축)으로, 그 반대로 이동합니다.

다음 C# 코드는 차트에서 축 간 데이터 교환 작업을 수행하는 방법을 보여줍니다:

```c#
// 빈 프레젠테이션을 생성합니다
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//행과 열을 전환합니다
	chart.ChartData.SwitchRowColumn();
		   
	// 프레젠테이션을 저장합니다
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **라인 차트에서 세로 축 숨기기**

다음 C# 코드는 라인 차트의 세로 축을 숨기는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **라인 차트에서 가로 축 숨기기**

다음 코드는 라인 차트의 가로 축을 숨기는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **범주 축 변경**

**CategoryAxisType** 속성을 사용하여 원하는 범주 축 유형(**날짜** 또는 **텍스트**)을 지정할 수 있습니다. 다음 C# 코드는 해당 작업을 시연합니다:

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

## **범주 축 값의 날짜 형식 설정**
Aspose.Slides for .NET을 사용하면 범주 축 값의 날짜 형식을 설정할 수 있습니다. 이 작업은 다음 C# 코드에서 시연됩니다:

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

## **차트 축 제목 회전 각도 설정**
Aspose.Slides for .NET을 사용하면 차트 축 제목의 회전 각도를 설정할 수 있습니다. 이 C# 코드는 해당 작업을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **범주 축 또는 값 축의 위치 설정**
Aspose.Slides for .NET을 사용하면 범주 축이나 값 축의 위치를 설정할 수 있습니다. 이 C# 코드는 작업 수행 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **차트 값 축에 단위 레이블 표시 활성화**
Aspose.Slides for .NET을 사용하면 차트 값 축에 단위 레이블을 표시하도록 차트를 구성할 수 있습니다. 이 C# 코드는 해당 작업을 시연합니다:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**한 축이 다른 축과 교차하는 값(축 교차점)을 어떻게 설정합니까?**

축은 [crossing setting](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/axis/crosstype/)을 제공합니다: 0에서, 최대 범주/값에서 또는 특정 숫자 값에서 교차하도록 선택할 수 있습니다. 이는 X축을 위아래로 이동하거나 기준선을 강조할 때 유용합니다.

**틱 레이블을 축을 기준으로 어떻게 위치시킬 수 있습니까(옆, 바깥, 안쪽)?**

[label position](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/axis/majortickmark/)을 "cross", "outside" 또는 "inside"로 설정합니다. 이는 가독성을 향상하고 특히 작은 차트에서 공간을 절약하는 데 도움이 됩니다.