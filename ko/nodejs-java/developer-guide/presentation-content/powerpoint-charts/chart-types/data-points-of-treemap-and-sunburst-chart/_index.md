---
title: JavaScript를 사용하여 Treemap 및 Sunburst 차트의 데이터 포인트 맞춤 설정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap 차트
- sunburst 차트
- 데이터 포인트
- 레이블 색상
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 treemap 및 sunburst 차트의 데이터 포인트를 관리하는 방법을 배우고, PowerPoint 형식과 호환됩니다."
---
## **Introduction**

PowerPoint 차트의 다른 유형들 중에 두 가지 “계층형” 차트가 있습니다 - **Treemap** 와 **Sunburst** 차트(일명 Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph 또는 Multi Level Pie Chart). 이러한 차트는 트리 형태로 조직된 계층형 데이터를 표시합니다 - 잎에서 가지의 최상위까지. 잎은 시리즈 데이터 포인트에 의해 정의되며, 각 이후의 중첩 그룹 수준은 해당 카테고리에 의해 정의됩니다. Aspose.Slides for Node.js via Java는 JavaScript에서 Sunburst 차트와 Treemap의 데이터 포인트를 형식화할 수 있게 합니다.

다음은 Sunburst 차트이며, Series1 열의 데이터가 잎 노드를 정의하고, 다른 열들은 계층형 데이터 포인트를 정의합니다:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

프레젠테이션에 새 Sunburst 차트를 추가해 보겠습니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="참고" %}} 
- [**JavaScript에서 PowerPoint 프레젠테이션 차트 만들기 또는 업데이트하기**](/slides/ko/nodejs-java/create-chart/)
{{% /alert %}}

차트의 데이터 포인트를 형식화해야 할 경우, 다음을 사용해야 합니다:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevel) 클래스 및 
[**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) 메서드는 Treemap 및 Sunburst 차트의 데이터 포인트를 형식화하는 접근을 제공합니다. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevelsManager)는 다중 수준 카테고리에 접근하기 위해 사용되며, 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevel) 객체들의 컨테이너를 나타냅니다. 
기본적으로 이는 데이터 포인트에 특화된 속성이 추가된 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartCategoryLevelsManager)의 래퍼입니다. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevel) 클래스에는 두 개의 메서드가 있습니다: 
[**getFormat**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--)와 
[**getDataLabel**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--)가 해당 설정에 대한 접근을 제공합니다.

## **Show Data Point Value**
"Leaf 4" 데이터 포인트의 값을 표시합니다:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Set Data Point Label and Color**
"Branch 1" 데이터 레이블을 카테고리 이름 대신 시리즈 이름("Series1")이 표시되도록 설정하고, 텍스트 색상을 노란색으로 지정합니다:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Set Data Point Branch Color**
"Steam 4" 브랜치의 색상을 변경합니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Sunburst/Treemap에서 세그먼트의 순서(정렬)를 변경할 수 있나요?**

아니오. PowerPoint는 세그먼트를 자동으로 정렬합니다(보통 값이 큰 순서대로 시계 방향). Aspose.Slides도 이 동작을 그대로 반영합니다: 직접 순서를 변경할 수 없으며, 데이터를 사전 처리하여 원하는 순서를 구현해야 합니다.

**프레젠테이션 테마가 세그먼트 및 레이블 색상에 어떤 영향을 미치나요?**

차트 색상은 별도로 채우기/글꼴을 지정하지 않는 한 프레젠테이션의 [테마/팔레트](/slides/ko/nodejs-java/presentation-theme/)를 상속합니다. 일관된 결과를 위해서는 필요한 수준에서 단색 채우기와 텍스트 서식을 고정해 두세요.

**PDF/PNG로 내보낼 때 사용자 지정 브랜치 색상 및 레이블 설정이 유지되나요?**

예. 프레젠테이션을 내보낼 경우 차트 설정(채우기, 레이블)이 출력 형식에 그대로 유지됩니다. 이는 Aspose.Slides가 차트의 포맷을 적용한 상태로 렌더링하기 때문입니다.

**차트 상단에 커스텀 오버레이를 배치하기 위해 레이블/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃이 검증된 후에는 요소에 대한 실제 X와 실제 Y값을 사용할 수 있습니다(예: [DataLabel](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datalabel/)). 이를 통해 오버레이를 정확히 배치할 수 있습니다.