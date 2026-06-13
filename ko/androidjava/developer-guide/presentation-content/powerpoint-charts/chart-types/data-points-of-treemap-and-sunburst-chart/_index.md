---
title: Android에서 Treemap 및 Sunburst 차트의 데이터 포인트 맞춤 설정
linktitle: Treemap 및 Sunburst 차트의 데이터 포인트
type: docs
url: /ko/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 트리맵 차트
- 선버스트 차트
- 데이터 포인트
- 레이블 색상
- 브랜치 색상
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 트리맵 및 선버스트 차트의 데이터 포인트를 관리하는 방법을 배우고, PowerPoint 형식과 호환됩니다."
---
## **소개**

다른 유형의 PowerPoint 차트와 함께 계층형 차트 두 가지—**Treemap**와 **Sunburst** 차트(또는 Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph, Multi Level Pie Chart라고도 함)—가 있습니다. 이러한 차트는 트리 구조로 구성된 계층형 데이터를 표시합니다—잎에서 가지의 최상위까지. 잎은 시리즈 데이터 포인트로 정의되고, 이후 각 중첩 그룹 수준은 해당 카테고리로 정의됩니다. Aspose.Slides for Android via Java는 Java에서 Sunburst 차트와 Treemap의 데이터 포인트를 서식 지정할 수 있게 합니다.

아래는 Sunburst 차트 예시이며, Series1 열의 데이터가 잎 노드를 정의하고 나머지 열이 계층형 데이터 포인트를 정의합니다:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

프레젠테이션에 새 Sunburst 차트를 추가해 보겠습니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="See also" %}} 
- [**Create or Update PowerPoint Presentation Charts on Android**](/slides/ko/androidjava/create-chart/)
{{% /alert %}}

차트의 데이터 포인트를 서식 지정해야 하는 경우 다음을 사용합니다:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevel) 클래스와 
[**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 메서드는 Treemap 및 Sunburst 차트의 데이터 포인트 서식에 대한 접근을 제공합니다. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevelsManager)는 다중 레벨 카테고리에 접근하기 위해 사용되며—[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevel) 객체들의 컨테이너를 나타냅니다.
기본적으로 이는 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartCategoryLevelsManager) 의 래퍼이며, 데이터 포인트에 특화된 속성을 추가했습니다. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevel) 클래스에는 두 메서드가 있습니다: [**getFormat**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--)와 [**getDataLabel**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--)이며, 각각 해당 설정에 대한 접근을 제공합니다.
## **데이터 포인트 값 표시**
"Leaf 4" 데이터 포인트의 값을 표시합니다:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **데이터 포인트 레이블 및 색상 설정**
"Branch 1" 데이터 레이블을 카테고리 이름 대신 시리즈 이름("Series1")이 표시되도록 설정하고, 텍스트 색상을 노란색으로 지정합니다:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **데이터 포인트 브랜치 색상 설정**
"Steam 4" 브랜치의 색상을 변경합니다:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Sunburst/Treemap에서 세그먼트의 순서(정렬)를 변경할 수 있나요?**

아니오. PowerPoint는 세그먼트를 자동으로 정렬합니다(일반적으로 하강값 순, 시계 방향). Aspose.Slides도 이 동작을 그대로 따르며, 직접 순서를 변경할 수 없습니다; 데이터를 사전 처리하여 원하는 순서를 만들 수 있습니다.

**프레젠테이션 테마가 세그먼트와 레이블 색상에 어떤 영향을 미치나요?**

차트 색상은 프레젠테이션의 [theme/palette](/slides/ko/androidjava/presentation-theme/)를 상속합니다(별도로 채우기/글꼴을 지정하지 않은 경우). 일관된 결과를 원한다면 필요한 레벨에서 고정된 채우기와 텍스트 서식을 지정하십시오.

**PDF/PNG로 내보낼 때 사용자 지정 브랜치 색상과 레이블 설정이 유지되나요?**

예. 프레젠테이션을 내보낼 때 차트 설정(채우기, 레이블 등)은 출력 형식에 그대로 보존됩니다. Aspose.Slides는 차트 서식이 적용된 상태로 렌더링합니다.

**차트 위에 사용자 지정 오버레이를 배치하기 위해 레이블/요소의 실제 좌표를 계산할 수 있나요?**

예. 차트 레이아웃이 확인된 후 실제 *x*와 *y* 좌표가 요소(예: [DataLabel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/datalabel/))에 대해 제공되며, 이를 활용해 정확한 오버레이 위치를 지정할 수 있습니다.