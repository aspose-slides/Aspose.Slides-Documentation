---
title: Android에서 프레젠테이션용 파이 차트 맞춤 설정
linktitle: 파이 차트
type: docs
url: /ko/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 Android에서 파이 차트를 만들고 맞춤 설정합니다. 보조 플롯을 구성하고, 데이터 레이블을 표시하며, PowerPoint에서 자동 슬라이스 색상을 적용합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 원형 차트를 사용하는 방법을 설명합니다. 여기에서는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 구성하는 방법과 표준 원형 차트에 대한 자동 슬라이스 색상 적용 방법을 보여줍니다.

예제에서는 차트를 슬라이드에 추가하고, 시리즈 및 레이블 설정을 조정하며, 기본 차트 데이터를 사용자 지정 카테고리와 값으로 대체하고, 업데이트된 프레젠테이션을 저장하는 등 차트 사용자 지정 작업에 중점을 둡니다.

## **Pie of Pie 및 Bar of Pie 차트의 보조 플롯 옵션**

Aspose.Slides for Android via Java는 Pie of Pie 및 Bar of Pie 차트에 대한 보조 플롯 옵션을 지원합니다. 이러한 옵션은 보조 플롯의 크기와 데이터 포인트가 두 플롯 간에 어떻게 분할되는지를 제어합니다.

다음 예제는 새 프레젠테이션에 Pie of Pie 차트를 만들고 데이터 포인트 값을 레이블로 표시합니다. [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) 메서드는 보조 플롯 크기를 메인 플롯의 149%로 설정합니다. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 은 백분율 기반 분할을 선택하고, [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) 은 임계값을 53%로 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // 값을 표시하고 보조 플롯을 구성합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **보조 플롯용 카테고리 선택**

백분율 값과 관계없이 특정 카테고리를 보조 플롯에 그룹화하려면 사용자 지정 분할을 사용하십시오. 예를 들어, 판매 보고서에서 온라인과 이벤트를 함께 표시하면 독자가 두 채널을 비교할 수 있게 되는데, 이 두 채널은 전체 매출의 35%와 10%를 차지합니다.

다음과 같이 [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) 를 [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) 과 함께 호출하고, [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) 로 포인트를 선택합니다. 컬렉션의 [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) 메서드는 시리즈의 0부터 시작하는 인덱스를 허용합니다; [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) 을 사용하여 데이터 포인트 객체를 추가합니다. 이 예제에서는 인덱스 1이 온라인을 선택하고, 인덱스 3이 이벤트를 선택합니다. 파트너도 임시로 추가된 뒤, [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) 을 사용하여 제외됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // 기본 데이터를 채널별 매출 데이터로 교체합니다.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online을 0부터 시작하는 인덱스로, Events를 데이터 포인트 객체로 선택합니다.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners를 선택에서 제외하지만 원본 데이터를 삭제하지는 않습니다.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

온라인(35)과 이벤트(10)는 보조 플롯에서 별도의 슬라이스로 표시됩니다. 기본 플롯에서는 이들이 45값의 하나의 결합된 슬라이스로 표시되며, 소매(40)와 파트너(15)도 함께 나타납니다. 사용자 지정 선택에서 파트너를 제거해도 기본 플롯에는 남아 있으며, 차트의 원본 데이터에서 해당 카테고리나 값이 제거되지 않습니다.

다음 이미지는 PowerPoint에서 저장된 프레젠테이션을 보여줍니다:

![보조 플롯에 온라인과 이벤트가 포함되고 기본 플롯에서 결합된 값 45를 가진 Pie of Pie 차트](pie_of_pie_custom.png)

## **자동 원형 차트 슬라이스 색상 설정**

Aspose.Slides for Android via Java는 원형 차트 슬라이스에 자동으로 서로 다른 색상을 지정할 수 있습니다. 다음 예제는 중앙에 제목이 있는 원형 차트를 만들고 기본 데이터를 3개의 분기별 카테고리와 해당 값으로 교체합니다. [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) 메서드는 값 20, 50, 30을 레이블로 표시하고, [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) 은 각 슬라이스에 서로 다른 색상을 적용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 중앙에 정렬된 차트 제목을 추가합니다.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 첫 번째 워크시트를 사용하여 기본 데이터를 교체합니다.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // 값을 표시하고 슬라이스에 서로 다른 색상을 할당합니다.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **자주 묻는 질문**

**Pie of Pie 및 Bar of Pie 변형이 지원됩니까?**

예, 라이브러리는 Pie of Pie 및 Bar of Pie 유형을 포함한 원형 차트에 대한 보조 플롯을 [지원](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 합니다.

**차트를 이미지(예: PNG)로만 내보낼 수 있나요?**

예, 전체 프레젠테이션을 내보내지 않고 (예: PNG) 차트를 이미지로 직접 내보낼 수 있습니다. [차트를 이미지로 직접 내보내기](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (예: PNG) 를 사용하십시오.