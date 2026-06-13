---
title: JavaScript를 사용한 프레젠테이션 차트의 플롯 영역 사용자 지정
linktitle: 플롯 영역
type: docs
url: /ko/nodejs-java/chart-plot-area/
keywords:
- 차트
- 플롯 영역
- 플롯 영역 너비
- 플롯 영역 높이
- 플롯 영역 크기
- 레이아웃 모드
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에서 차트 플롯 영역을 사용자 지정하는 방법을 알아보세요. 슬라이드 시각 효과를 손쉽게 개선할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트의 플롯 영역을 사용하는 방법을 보여줍니다. 차트 레이아웃을 검증하고 X, Y, 너비, 높이 값을 읽어 플롯 영역의 실제 위치와 크기를 얻는 방법을 설명합니다.

또한 레이아웃을 수동으로 설정할 때 `LayoutTargetType`을 사용하여 플롯 영역을 내부 영역으로 계산할지 축 및 축 레이블을 포함한 외부 영역으로 계산할지를 정의하는 방법을 보여줍니다.

## **차트 플롯 영역의 너비와 높이 가져오기**

Aspose.Slides for Node.js via Java는 간단한 API를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 기본 데이터가 포함된 차트를 추가합니다.
1. 실제 값을 얻기 위해 [Chart.validateChartLayout()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#validateChartLayout--) 메서드를 호출합니다.
1. 차트 요소의 실제 X 위치(왼쪽)를 차트의 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 상단 위치를 차트의 왼쪽 상단 모서리를 기준으로 가져옵니다.
1. 차트 요소의 실제 너비를 가져옵니다.
1. 차트 요소의 실제 높이를 가져옵니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **차트 플롯 영역의 레이아웃 모드 설정**

Aspose.Slides for Node.js via Java는 차트 플롯 영역의 레이아웃 모드를 설정하기 위한 간단한 API를 제공합니다. [**setLayoutTargetType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-)와 [**getLayoutTargetType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) 메서드가 [**ChartPlotArea**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartPlotArea) 클래스에 추가되었습니다. 플롯 영역의 레이아웃이 수동으로 정의된 경우, 이 속성은 플롯 영역을 내부(축 및 축 레이블을 포함하지 않음)로 레이아웃할지 외부(축 및 축 레이블을 포함)로 레이아웃할지를 지정합니다. [**LayoutTargetType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LayoutTargetType) 열거형에 정의된 두 가지 가능한 값이 있습니다.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LayoutTargetType#Inner) - 플롯 영역의 크기가 플롯 영역의 크기를 결정하도록 하며, 눈금 및 축 레이블은 포함하지 않습니다.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LayoutTargetType#Outer) - 플롯 영역의 크기가 플롯 영역, 눈금 및 축 레이블의 크기를 결정하도록 합니다.

아래에 샘플 코드가 제공됩니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**실제 X, 실제 Y, 실제 Width, 실제 Height는 어떤 단위로 반환됩니까?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 Aspose.Slides 좌표 단위입니다.

**플롯 영역은 내용 면에서 차트 영역과 어떻게 다릅니까?**

플롯 영역은 데이터 그리기 영역(시리즈, 그리드라인, 추세선 등)이며, 차트 영역은 주변 요소(제목, 범례 등)를 포함합니다. 3D 차트에서는 플롯 영역에 벽/바닥 및 축도 포함됩니다.

**레이아웃이 수동일 때 플롯 영역의 X, Y, Width, Height는 어떻게 해석됩니까?**

이 값들은 차트 전체 크기에 대한 비율(0~1)이며, 이 모드에서는 자동 위치 지정이 비활성화되고 설정한 비율이 사용됩니다.

**범례를 추가하거나 이동한 후 플롯 영역 위치가 변경된 이유는 무엇입니까?**

범례는 플롯 영역 밖 차트 영역에 위치하지만 레이아웃 및 사용 가능한 공간에 영향을 주므로 자동 위치 지정이 적용될 경우 플롯 영역이 이동할 수 있습니다. (이는 PowerPoint 차트의 일반적인 동작입니다.)