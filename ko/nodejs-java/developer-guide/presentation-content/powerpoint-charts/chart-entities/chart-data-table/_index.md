---
title: JavaScript를 사용하여 프레젠테이션의 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/nodejs-java/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 차트 데이터 테이블의 글꼴, 테두리 및 범례 키를 사용자 지정합니다."
---
## **개요**

Aspose.Slides for Node.js via Java를 사용하면 차트 데이터 테이블을 표시하고 텍스트 서식, 테두리 및 범례 키를 사용자 지정할 수 있습니다. 이 문서에서는 테이블을 활성화하고, 텍스트를 서식 지정하며, 각 유형의 테두리를 제어하고, 범례 키를 표시하거나 숨기는 방법을 설명합니다. 예제에서는 구성된 차트를 PPTX 파일에 저장합니다.

## **글꼴 속성 설정**

차트의 데이터 테이블을 표시하려면 [setDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/setdatatable/)에 `true`를 전달합니다. 테이블에 접근하고 텍스트 서식을 구성하려면 [getChartDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/getchartdatatable/)을 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 사용하여 프레젠테이션을 로드합니다.
1. 첫 번째 슬라이드에 클러스터형 세로 막대 차트를 추가합니다.
1. 차트의 데이터 테이블을 활성화합니다.
1. [setFontBold](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setfontbold)로 굵은 텍스트를 활성화하고, 20포인트 텍스트를 위해 [setFontHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseportionformat/#setfontheight)에 `20`을 전달합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 예제는 작업 디렉터리에 최소 하나의 슬라이드가 있는 `input.pptx`가 필요합니다. 위치 (50, 50)에 기본 데이터가 있는 차트를 추가하고, 너비는 600포인트, 높이는 400포인트로 설정합니다. 저장된 `output.pptx`에는 데이터 테이블이 활성화된 차트와 지정된 글꼴 설정이 적용됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **데이터 테이블 테두리 사용자 지정**

테이블은 [Chart.setDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/setdatatable/)으로 활성화하고, [Chart.getChartDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/getchartdatatable/)을 통해 접근합니다. 세 가지 유형의 테두리를 독립적으로 제어할 수 있습니다:

- [setBorderHorizontal](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setborderhorizontal/)은 가로 셀 테두리를 제어합니다.
- [setBorderVertical](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setbordervertical/)은 세로 셀 테두리를 제어합니다.
- [setBorderOutline](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setborderoutline/)은 테이블의 외부 테두리를 제어합니다.

`true`를 각 메서드에 전달하면 해당 테두리를 표시하고, `false`를 전달하면 숨깁니다. 다음 예제는 기본 데이터가 있는 클러스터형 세로 막대 차트를 만들고, 가로 테두리와 외부 테두리를 표시하며, 세로 테두리를 숨깁니다. 입력 파일이 필요하지 않습니다. 차트의 위치와 크기는 포인트 단위로 지정됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교는 네 경우 모두 동일한 차트 데이터와 범례 키 설정을 사용합니다. 모든 테두리가 활성화된 상태에서 각 변형은 하나의 테두리 설정만 비활성화합니다. 왼쪽 아래 변형이 예제의 테두리 설정과 일치합니다.

![모든 테두리가 활성화된 차트 데이터 테이블, 가로 테두리 없음, 세로 테두리 없음, 외부 테두리 없음](data-table-borders.png)

## **범례 키 표시 또는 숨기기**

범례 키는 데이터 테이블의 시리즈 이름 옆에 있는 작은 색상 마커입니다. 독자가 각 테이블 행을 차트 시리즈와 일치시키는 데 도움이 됩니다. [setShowLegendKey](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setshowlegendkey/)에 `true`를 전달하면 이러한 마커를 표시하고, `false`를 전달하면 숨깁니다.

차트의 별도 범례는 [Chart.setLegend](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/setlegend/)으로 제어됩니다. 이 설정은 독립적이며, 별도 범례를 숨겨도 데이터 테이블 내부의 키는 숨겨지지 않으며, 테이블의 키를 숨겨도 별도 범례는 숨겨지지 않습니다.

다음 예제는 기본 데이터가 있는 차트를 만들고, 데이터 테이블을 활성화한 뒤 별도 범례를 숨기고 내부에 범례 키를 표시합니다. 모든 테이블 테두리는 명시적으로 활성화됩니다. 입력 프레젠테이션이 필요하지 않습니다. 테이블의 키만 숨기려면 [setShowLegendKey](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setshowlegendkey/)에 `false`를 전달합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교에서는 범례 키가 활성화된 경우와 비활성화된 경우의 동일한 테이블을 보여줍니다. 모든 테두리는 계속 활성화되어 있으며, 별도 차트 범례는 두 경우 모두 숨겨집니다.

![왼쪽에 범례 키가 표시되고 오른쪽에 숨겨진 차트 데이터 테이블](data-table-legend-keys.png)

## **FAQ**

**차트 데이터 테이블에 범례 키를 표시할 수 있나요?**

예. [setShowLegendKey](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setshowlegendkey/)에 `true`를 전달하면 범례 키가 표시되고, `false`를 전달하면 숨겨집니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 유지되나요?**

예. Aspose.Slides는 차트와 표시된 데이터 테이블을 슬라이드의 일부로 렌더링하여 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/), 또는 [images](/slides/ko/nodejs-java/convert-powerpoint-to-png/)로 내보냅니다.

**템플릿에서 로드한 차트의 데이터 테이블을 작업할 수 있나요?**

예. 기존 프레젠테이션이나 템플릿에서 로드한 차트의 경우, [hasDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/hasdatatable/) 및 [setDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/setdatatable/)를 사용하여 데이터 테이블이 표시되는지 확인하거나 변경할 수 있습니다.

**데이터 테이블이 활성화된 차트를 어떻게 찾을 수 있나요?**

각 슬라이드의 셰이프를 반복해서 차트를 식별하고, 해당 차트의 [hasDataTable](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/hasdatatable/) 메서드를 호출합니다. `true` 값은 데이터 테이블이 활성화되어 있음을 나타냅니다.