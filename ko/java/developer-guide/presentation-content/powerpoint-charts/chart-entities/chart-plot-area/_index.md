---
title: Java에서 프레젠테이션 차트의 플롯 영역 사용자 지정
linktitle: 플롯 영역
type: docs
url: /ko/java/chart-plot-area/
keywords:
- 차트
- 플롯 영역
- 플롯 영역 너비
- 플롯 영역 높이
- 플롯 영역 크기
- 레이아웃 모드
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 차트 플롯 영역을 사용자 지정하는 방법을 알아보세요. 슬라이드 시각 효과를 손쉽게 개선할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트의 플롯 영역을 사용하는 방법을 보여줍니다. 차트 레이아웃을 검증한 다음 X, Y, 너비 및 높이 값을 읽어 플롯 영역의 실제 위치와 크기를 얻는 방법을 설명합니다.

또한 레이아웃을 수동으로 설정할 때 플롯 영역의 레이아웃 모드를 구성하는 방법을 보여줍니다. `LayoutTargetType`을 사용하여 플롯 영역이 내부 영역에 의해 계산되는지 또는 축 및 축 레이블을 포함한 외부 영역에 의해 계산되는지를 정의합니다.

## **차트 플롯 영역의 너비와 높이 가져오기**
Aspose.Slides for Java는 간단한 API를 제공합니다.

1. 다음 클래스인 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 액세스합니다.
1. 기본 데이터를 사용하여 차트를 추가합니다.
1. 실제 값을 얻기 위해 먼저 [IChart.validateChartLayout()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart#validateChartLayout--) 메서드를 호출합니다.
1. 차트 요소의 실제 X 위치(왼쪽)를 차트 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 상단 위치를 차트 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 너비를 가져옵니다.
1. 차트 요소의 실제 높이를 가져옵니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트 플롯 영역의 레이아웃 모드 설정**
Aspose.Slides for Java는 차트 플롯 영역의 레이아웃 모드를 설정하기 위한 간단한 API를 제공합니다. 메서드 [**setLayoutTargetType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 및 [**getLayoutTargetType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)가 [**ChartPlotArea**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ChartPlotArea) 클래스와 [**IChartPlotArea**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartPlotArea) 인터페이스에 추가되었습니다. 플롯 영역의 레이아웃이 수동으로 정의된 경우, 이 속성은 플롯 영역을 내부(축 및 축 레이블 제외) 또는 외부(축 및 축 레이블 포함) 중 어느 쪽으로 레이아웃할지 지정합니다. 가능한 두 값은 [**LayoutTargetType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/LayoutTargetType) 열거형에 정의되어 있습니다.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/LayoutTargetType#Inner) - 플롯 영역 크기가 플롯 영역 자체의 크기를 결정하도록 하며, 눈금선 및 축 레이블은 포함하지 않음을 지정합니다.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/LayoutTargetType#Outer) - 플롯 영역 크기가 플롯 영역 자체, 눈금선 및 축 레이블의 크기를 모두 결정하도록 함을 지정합니다.

아래에 샘플 코드가 제공됩니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **자주 묻는 질문**

**실제 x, 실제 y, 실제 너비 및 실제 높이는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치는 72포인트입니다. 이는 Aspose.Slides 좌표 단위입니다.

**플롯 영역은 차트 영역과 내용면에서 어떻게 다릅니까?**

플롯 영역은 데이터가 그려지는 영역(시리즈, 격자선, 추세선 등)이며, 차트 영역에는 여기 주변 요소(제목, 범례 등)가 포함됩니다. 3D 차트의 경우 플롯 영역에는 벽/바닥 및 축도 포함됩니다.

**레이아웃을 수동으로 설정한 경우 플롯 영역의 x, y, 너비 및 높이는 어떻게 해석됩니까?**

이는 차트 전체 크기에 대한 비율(0~1)이며, 이 모드에서는 자동 위치 지정이 비활성화되고 설정한 비율이 그대로 사용됩니다.

**범례를 추가하거나 이동한 후 플롯 영역 위치가 변경된 이유는 무엇입니까?**

범례는 플롯 영역 외부의 차트 영역에 배치되지만 레이아웃 및 사용 가능한 공간에 영향을 주므로 자동 위치 지정이 적용될 경우 플롯 영역이 이동할 수 있습니다. (이는 PowerPoint 차트의 일반적인 동작입니다.)