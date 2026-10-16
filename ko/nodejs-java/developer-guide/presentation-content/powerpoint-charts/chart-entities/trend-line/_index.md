---
title: JavaScript로 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/nodejs-java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 맞춤형 추세선
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Slides와 JavaScript를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 맞춤 설정하는 실용적인 가이드 — 청중을 사로잡는 방법."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식 및 거듭 제곱 등 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 라인 형태를 삽입하여 차트에 사용자 지정 선을 추가하는 방법을 설명하고, 전방 및 후방 추세선 투영 값과 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 보존되는지 여부에 대한 짧은 FAQ를 포함합니다.

## **추세선 추가**

차트 시리즈에 추세선을 추가하려면 [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add)를 사용하고, [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/)으로 유형을 선택합니다. 예제에서는 기본 데이터로 클러스터형 열 차트를 만들고 각 세 시리즈에 두 개의 추세선을 추가합니다.

지수 추세선은 [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) 및 [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue)를 통해 식과 R제곱 값을 숨기고, 선형 추세선은 빨간색입니다. 로그 추세선은 사용자 지정 레이블을 위해 [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding)를 사용합니다. 이동 평균은 세 데이터 포인트의 [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod)와 사용자 지정 [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName)를 사용합니다.

다항식 추세선은 [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder)값이 3이며, [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward)를 통해 한 카테고리 앞으로 확장됩니다. 거듭 제곱 추세선은 [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward)를 통해 한 카테고리 뒤로 확장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **추세선 절편 설정**

[setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept)를 사용하여 X = 0에서 추세선의 Y 값을 고정합니다. 이 설정은 선형, 지수 및 다항식 추세선에서 지원됩니다.

예를 들어, 생산 비용 모델은 비정량 생산량에서 측정된 값이 다른 기준선을 제시하더라도 알려진 고정 비용 100에서 시작해야 할 수 있습니다. 선형 추세선의 경우, 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`으로 제한되고, 기울기는 그 제한 하에 데이터에 맞춰 집니다. 이는 이미 맞춰진 선을 단순히 이동시키는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어하며, 맞춰진 추세선의 계수를 제어하지 않습니다.

다음 예제는 생산량 1에서 4까지와 비용 170, 200, 230, 260을 갖는 산점도(XY) 차트를 생성합니다. 기본 자동 절편으로 차트를 저장하고, 절편을 100으로 설정한 뒤 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 식을 표시하고 X = 0까지 뒤로 확장됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

자동 계산을 사용하면 이러한 데이터로 `y = 30x + 140`이 생성됩니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다: 제로에서의 맞춰진 값이 알려진 기준선과 일치하지만, 선이 더 이상 모든 데이터 포인트를 통과하지는 않습니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![자동 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편 100이 고정된 선형 추세선](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 눈금을 사용합니다. 추세선은 절편을 표시하기 위해 X = 0까지 뒤로 확장됩니다.

기본적으로 [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept)는 `NaN`을 반환하는데, 이는 0이 아니라 지정되지 않은 절편을 의미합니다. 절편은 데이터에서 자동으로 계산됩니다.

## **사용자 지정 선 추가**

사용자 지정 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제에서는 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape)를 사용하여 차트 위 슬라이드에 수평선을 추가합니다. 선의 위치는 포인트 단위의 슬라이드 좌표로 지정되어 차트 왼쪽 가장자리에서 시작해 차트 높이의 절반 지점에 위치합니다. 너비는 차트 너비와 동일합니다. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat)은 선에 단색 빨간색을 적용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**추세선의 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞/뒤로 투영한 길이를 의미합니다. 산점도(XY) 차트의 경우 축 단위로, 비산점도 차트의 경우 카테고리 수로 표시됩니다. 음수 값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다; 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/nodejs-java/create-shape-thumbnails/) 메서드도 제공됩니다.