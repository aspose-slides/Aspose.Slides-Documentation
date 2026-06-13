---
title: .NET에서 프레젠테이션을 위한 차트 계산 최적화
linktitle: 차트 계산
type: docs
weight: 50
url: /ko/net/chart-calculations/
keywords:
  - 차트 계산
  - 차트 요소
  - 요소 위치
  - 실제 위치
  - 하위 요소
  - 상위 요소
  - 차트 값
  - 실제 값
  - PowerPoint
  - 프레젠테이션
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET에서 PPT 및 PPTX용 차트 계산, 데이터 업데이트 및 정밀 제어를 이해하고 실용적인 C# 코드 예제를 확인하세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 차트 계산 및 레이아웃 데이터를 처리하기 위한 API를 제공합니다. 이 문서에서는 `IActualLayout`을 구현하는 요소의 실제 위치와 크기, 차트 축의 실제 값을 포함하여 차트 요소의 실제 값을 검색하는 방법을 보여줍니다. 이러한 값은 차트 레이아웃 검증 후에 채워진다는 점도 설명합니다.

또한, 이 문서에서는 부모 차트 요소의 실제 위치를 가져오는 방법과 제목, 축, 레전드, 눈금선과 같은 차트 구성 요소를 숨기는 방법을 시연합니다. 이러한 예제들을 통해 PowerPoint 프레젠테이션에서 차트 레이아웃 정보를 검사하고 차트 요소의 표시 여부를 프로그래밍 방식으로 제어할 수 있습니다.

## **차트 요소의 실제 값 계산**
Aspose.Slides for .NET은 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. 이를 통해 차트 요소의 실제 값을 계산할 수 있습니다. 실제 값에는 IActualLayout 인터페이스를 구현하는 요소의 위치(`IActualLayout.ActualX`, `IActualLayout.ActualY`, `IActualLayout.ActualWidth`, `IActualLayout.ActualHeight`)와 실제 축 값(`IAxis.ActualMaxValue`, `IAxis.ActualMinValue`, `IAxis.ActualMajorUnit`, `IAxis.ActualMinorUnit`, `IAxis.ActualMajorUnitScale`, `IAxis.ActualMinorUnitScale`)가 포함됩니다.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 프레젠테이션 저장
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **부모 차트 요소의 실제 위치 계산**
Aspose.Slides for .NET은 이러한 속성을 가져오기 위한 간단한 API를 제공합니다. `IActualLayout`의 속성은 부모 차트 요소의 실제 위치 정보를 제공합니다. 실제 값으로 속성을 채우려면 먼저 `IChart.ValidateChartLayout()` 메서드를 호출해야 합니다.

```c#
// 빈 프레젠테이션 만들기
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **차트 요소 숨기기**
이 항목에서는 차트에서 정보를 숨기는 방법을 설명합니다. Aspose.Slides for .NET을 사용하면 차트에서 **제목**, **수직 축**, **수평 축**, **눈금선**을 숨길 수 있습니다. 아래 코드 예제는 이러한 속성을 사용하는 방법을 보여줍니다.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // 차트 제목 숨기기
    chart.HasTitle = false;

    ///값 축 숨기기
    chart.Axes.VerticalAxis.IsVisible = false;

    // 카테고리 축 표시 여부
    chart.Axes.HorizontalAxis.IsVisible = false;

    // 범례 숨기기
    chart.HasLegend = false;

    // 주 격자선 숨기기
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // 시리즈 선 색상 설정
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**외부 Excel 워크북을 데이터 소스로 사용할 수 있나요? 또한 재계산에 어떤 영향을 줍니까?**

예. 차트는 외부 워크북을 참조할 수 있으며, 외부 소스를 연결하거나 새로 고치면 해당 워크북에서 수식과 값이 가져와지고 차트는 열기/편집 중에 업데이트를 반영합니다. API를 사용하면 [외부 워크북을 지정](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/setexternalworkbook/)할 수 있고, 연결된 데이터를 관리할 수 있습니다.

**회귀 분석을 직접 구현하지 않고도 추세선을 계산하고 표시할 수 있나요?**

예. [Trendlines](/slides/ko/net/trend-line/) (선형, 지수 등) 은 Aspose.Slides에 의해 자동으로 추가 및 업데이트되며, 매개변수는 시리즈 데이터에서 자동으로 재계산되므로 직접 구현할 필요가 없습니다.

**프레젠테이션에 외부 링크가 있는 여러 차트가 포함된 경우, 각 차트가 사용할 워크북을 개별적으로 제어할 수 있나요?**

예. 각 차트는 자체 [외부 워크북](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/chartdata/setexternalworkbook/)을 지정할 수 있으며, 차트마다 별도로 외부 워크북을 생성하거나 교체할 수 있습니다.