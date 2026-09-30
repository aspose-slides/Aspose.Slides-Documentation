---
title: JavaScript를 사용하여 프레젠테이션에서 차트 범례 사용자 지정
linktitle: 차트 범례
type: docs
url: /ko/nodejs-java/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 차트 범례를 맞춤화하고, 맞춤형 범례 서식을 적용하여 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정하기 위한 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하며, 개별 범례 항목을 서식 지정하고, 선택한 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례를 위한 공간을 예약하고, 다중 행 레이블을 표시하며, 프레젠테이션 테마에서 서식을 상속받는 등 관련 동작을 다룹니다.

## **범례 위치 지정**

범례의 [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) 메서드를 사용하여 차트 차원의 비율로 위치와 크기를 지정합니다.

이 예제는 프레젠테이션을 만들고 첫 슬라이드에 기본 데이터가 포함된 군집형 세로 막대 차트를 추가합니다. 원하는 범례 오프셋 및 차원을 차트의 너비와 높이로 나누면 상대값으로 변환됩니다: 범례는 차트의 좌상단 모서리에서 50포인트 떨어져 있으며 크기는 100 × 100 포인트입니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 차트에 대해 범례의 위치와 크기를 상대적으로 지정합니다.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범례의 글꼴 크기 설정**

범례의 [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/)을(를) 사용하여 텍스트 서식을 가져오고, [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight)을(를) 사용해 글꼴 크기를 포인트 단위로 설정합니다.

이 예제는 기본 데이터가 있는 차트를 만들고 범례 텍스트를 20포인트로 설정합니다. 또한 수직 축에 대한 자동 경계를 비활성화하고 범위를 -5에서 10으로 설정합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) 메서드가 반환하는 컬렉션을 사용하여 특정 항목의 서식을 가져옵니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 최소 두 개의 시리즈가 포함된 군집형 세로 막대 차트를 생성합니다. 두 번째 범례 항목을 굵게, 기울임꼴, 20포인트 파란색 텍스트로 서식 지정합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 범례 항목 숨기기**

보조 시리즈를 범례에서 제외하면서 데이터는 표시하려면 [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/)을 `true`와 함께 [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/)를 통해 호출합니다. 이렇게 하면 선택된 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반대로 [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/)을 `false`로 호출하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용해 다중 시리즈가 포함된 군집형 세로 막대 차트를 생성합니다. 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨기고 프레젠테이션을 저장합니다. 그런 다음 [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/)을 `false`로 호출해 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 막대는 계속 표시됩니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // 차트 데이터를 변경하지 않고 동일한 항목을 복원합니다.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교는 모든 항목이 표시된 차트와 두 번째 항목이 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 막대는 변하지 않습니다.

![모든 범례 항목이 표시된 차트와 범례에서 시리즈 2가 숨겨진 차트의 비교; 모든 막대는 여전히 표시됩니다.](hide-legend-entry.png)

세로 막대, 가로 막대 및 꺾은선 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(조각)를 식별하므로 선택된 조각에 대해 [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/)를 사용합니다. API는 `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` 차트 유형에 대해 이 데이터 포인트 메서드를 문서화합니다. 이 목록에 포함되지 않은 도넛 차트에는 적용되지 않는다고 가정하지 마세요.

## **FAQ**

**차트가 범례를 겹치게 하지 않고 공간을 할당하도록 할 수 있나요?**

예. [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)을 `false`로 호출하면 범례가 플롯 영역과 겹치지 않고 공간을 예약합니다.

**다중 행 범례 레이블을 만들 수 있나요?**

예. 사용 가능한 너비가 부족하면 긴 레이블이 자동으로 줄 바꿈됩니다. 또한 시리즈 이름에 줄 바꿈 문자를 넣어 강제로 줄을 나눌 수 있습니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례의 색상, 채우기 및 글꼴을 설정하지 않으면 테마 서식을 상속합니다. 명시적인 서식 설정은 해당 테마 설정을 덮어씁니다.