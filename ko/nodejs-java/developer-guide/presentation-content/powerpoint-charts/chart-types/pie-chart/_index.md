---
title: JavaScript를 사용한 프레젠테이션의 파이 차트 사용자 지정
linktitle: 파이 차트
type: docs
url: /ko/nodejs-java/pie-chart/
keywords:
- 파이 차트
- 차트 관리
- 차트 사용자 지정
- 차트 옵션
- 차트 설정
- 플롯 옵션
- 슬라이스 색상
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 JavaScript에서 파이 차트를 만들고 사용자 지정합니다. 보조 플롯을 구성하고 데이터 레이블을 표시하며 PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 파이 차트를 사용하는 방법을 설명합니다. 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 파이 차트에 대한 자동 슬라이스 색상 지정 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈 및 레이블 설정을 조정하고, 기본 차트 데이터를 사용자 지정 카테고리 및 값으로 교체하고, 업데이트된 프레젠테이션을 저장하는 등 차트 맞춤 작업에 초점을 맞춥니다.

## **파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션**

Aspose.Slides for Node.js via Java는 파이 오브 파이 및 바 오브 파이 차트에 대한 보조 플롯 옵션을 지원합니다. 이러한 옵션은 보조 플롯의 크기와 두 플롯 간에 데이터 포인트가 분할되는 방식을 제어합니다.

다음 예제는 새 프레젠테이션에 파이 오브 파이 차트를 만들고 데이터 포인트 값을 레이블로 표시합니다. [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 메서드는 보조 플롯의 크기를 메인 플롯의 149%로 설정합니다. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 는 백분율 기반 분할을 선택하고, [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 은 임계값을 53%로 설정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // 값을 표시하고 보조 플롯을 구성합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **보조 플롯에 대한 카테고리 선택**

백분율 값과 무관하게 특정 카테고리를 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용합니다. 예를 들어, 매출 보고서에서 온라인과 이벤트를 함께 표시하면 독자가 두 채널을 비교할 수 있지만 전체 매출의 35%와 10%를 차지합니다.

[setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 를 [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) 과 함께 호출하고 [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 로 포인트를 선택합니다. 컬렉션의 [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) 메서드는 시리즈의 0부터 시작하는 인덱스를 허용하며, [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) 를 사용하여 데이터 포인트 객체를 추가합니다. 이 예제에서는 인덱스 1이 온라인을 선택하고 인덱스 3이 이벤트를 선택합니다. Partners도 일시적으로 추가된 뒤 [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) 으로 제외됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // 기본 데이터를 채널별 매출로 교체합니다.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // 온라인을 0 기반 인덱스로 선택하고 이벤트를 데이터 포인트 객체로 선택합니다.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // 파트너스를 선택에서 제외하지만 원본 데이터를 삭제하지는 않습니다.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

온라인(35)과 이벤트(10)는 보조 플롯에서 별개의 슬라이스로 나타납니다. 기본 플롯에서는 소매(40)와 파트너스(15)와 함께 값이 45인 하나의 결합된 슬라이스로 표시됩니다. 파트너스를 사용자 지정 선택에서 제거해도 기본 플롯에는 남으며, 차트 원본 데이터에서 해당 카테고리나 값을 제거하지는 않습니다.

다음 이미지는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에 온라인과 이벤트가 포함된 파이 오브 파이 차트와 기본 플롯에서 결합된 값 45](pie_of_pie_custom.png)

## **자동 파이 차트 슬라이스 색상 설정**

Aspose.Slides for Node.js via Java는 파이 차트 슬라이스에 자동으로 서로 다른 색상을 할당할 수 있습니다. 다음 예제는 중앙에 제목이 있는 파이 차트를 만들고 기본 데이터를 세 개의 분기별 카테고리와 해당 값으로 교체합니다. [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) 메서드는 값 20, 50, 30을 레이블로 표시하고, [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) 은 각 슬라이스마다 구별되는 색상을 활성화합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // 중앙에 배치된 차트 제목을 추가합니다.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 첫 번째 워크시트를 사용하여 기본 데이터를 교체합니다.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 값을 표시하고 슬라이스에 서로 다른 색상을 할당합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **자주 묻는 질문**

**파이 오브 파이 및 바 오브 파이 변형이 지원되나요?**

네, 이 라이브러리는 파이 차트에 대한 보조 플롯을 [지원합니다](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/), 파이 오브 파이 및 바 오브 파이 유형을 포함합니다.

**차트를 이미지(PNG 등)로만 내보낼 수 있나요?**

네, 전체 프레젠테이션을 내보내지 않고 차트 자체를 이미지(PNG 등)로 [내보낼 수 있습니다](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage).