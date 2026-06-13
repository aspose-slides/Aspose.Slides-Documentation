---
title: .NET에서 프레젠테이션 차트의 플롯 영역 사용자 지정
linktitle: 플롯 영역
type: docs
url: /ko/net/chart-plot-area/
keywords:
- 차트
- 플롯 영역
- 플롯 영역 너비
- 플롯 영역 높이
- 플롯 영역 크기
- 레이아웃 모드
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 차트 플롯 영역을 사용자 지정하는 방법을 알아보세요. 슬라이드 시각 효과를 손쉽게 개선할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트의 플롯 영역을 사용하는 방법을 보여줍니다. 차트 레이아웃을 검증한 후 X, Y, 너비, 높이 값을 읽어 플롯 영역의 실제 위치와 크기를 가져오는 방법을 설명합니다.

또한 레이아웃을 수동으로 설정할 때 `LayoutTargetType`을 사용하여 플롯 영역을 내부 영역만으로 계산할지 축 및 축 레이블이 포함된 외부 영역으로 계산할지를 정의하는 플롯 영역 레이아웃 모드를 구성하는 방법을 보여줍니다.

## **차트 플롯 영역의 너비와 높이 가져오기**
Aspose.Slides for .NET은 간단한 API를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 만듭니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터가 있는 차트를 추가합니다.
1. 실제 값을 얻기 위해 IChart.ValidateChartLayout() 메서드를 호출합니다.
1. 차트 요소의 실제 X 위치(왼쪽)를 차트 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 상단을 차트 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 너비를 가져옵니다.
1. 차트 요소의 실제 높이를 가져옵니다.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 차트가 포함된 프레젠테이션 저장
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **차트 플롯 영역의 레이아웃 모드 설정**
Aspose.Slides for .NET은 차트 플롯 영역의 레이아웃 모드를 설정하는 간단한 API를 제공합니다. **LayoutTargetType** 속성이 **ChartPlotArea** 및 **IChartPlotArea** 클래스에 추가되었습니다. 플롯 영역 레이아웃이 수동으로 정의된 경우, 이 속성은 플롯 영역을 내부(축 및 축 레이블 제외)로 레이아웃할지 외부(축 및 축 레이블 포함)로 레이아웃할지를 지정합니다. 가능한 두 값은 **LayoutTargetType** 열거형에 정의되어 있습니다.

- **LayoutTargetType.Inner** - 플롯 영역 크기가 플롯 영역의 크기를 결정하도록 지정하며, 눈금과 축 레이블은 포함하지 않습니다.
- **LayoutTargetType.Outer** - 플롯 영역 크기가 플롯 영역, 눈금 및 축 레이블의 크기를 모두 결정하도록 지정합니다.

아래에 샘플 코드가 제공됩니다.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ActualX, ActualY, ActualWidth 및 ActualHeight는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 Aspose.Slides 좌표 단위입니다.

**플롯 영역은 내용 측면에서 차트 영역과 어떻게 다릅니까?**

플롯 영역은 데이터 그리기 영역(시리즈, 눈금선, 추세선 등)이며, 차트 영역은 주변 요소(제목, 범례 등)를 포함합니다. 3D 차트에서는 플롯 영역에 벽/바닥 및 축도 포함됩니다.

**레이아웃이 수동일 때 플롯 영역의 X, Y, Width 및 Height는 어떻게 해석됩니까?**

차트 전체 크기에 대한 비율(0–1)이며, 이 모드에서는 자동 배치가 비활성화되고 설정한 비율이 사용됩니다.

**범례를 추가하거나 이동한 후 플롯 영역 위치가 왜 변경되었나요?**

범례는 플롯 영역 외부의 차트 영역에 위치하지만 레이아웃과 사용 가능한 공간에 영향을 미치므로 자동 배치가 적용될 경우 플롯 영역이 이동할 수 있습니다. (이는 PowerPoint 차트의 일반적인 동작입니다.)