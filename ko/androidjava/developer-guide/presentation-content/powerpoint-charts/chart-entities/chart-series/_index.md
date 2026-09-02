---
title: Android에서 프레젠테이션의 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/androidjava/chart-series/
keywords:
- 차트 시리즈
- 시리즈 겹침
- 시리즈 색상
- 시리즈 이름
- 데이터 포인트
- 워크북 셀
- 시리즈 간격
- 음수 값
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android에서 프레젠테이션의 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 폭 및 음수 값을 관리하는 방법을 배우세요."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/)는 관련된 값 집합을 나타내며, 시리즈의 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [IChartCategory](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트로만 저장되는 것이 아니라 [IChartDataCell](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatacell/) 객체에 연결됩니다.

일반적인 카테고리 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀에 시리즈 값을 저장합니다. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마십시오. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정(예: [IChartSeries.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getFormat--))은 하나의 시리즈에 속한 모든 포인트의 기본 외观을 제공합니다.
- 데이터 포인트 설정(예: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--))은 특정 포인트에 대해 시리즈 외观을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/)에 속한 호환 시리즈에 적용됩니다. [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--)을 통해 그룹에 접근하고, 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정하십시오.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일과 테마가 자동 외观을 결정합니다. 시리즈와 포인트 포맷이 모두 존재하면 해당 포인트에 대해 포인트 포맷이 우선합니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getOverlap--)은 2D 차트에서 막대나 열이 겹치는 정도를 -100%에서 100%까지 보고합니다. 이는 상위 시리즈 그룹에 대한 읽기 전용 투영값입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)를 사용하십시오. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 결합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

다음 예제는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 새 차트에는 샘플 시리즈, 카테고리 및 값이 포함됩니다.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![시리즈 겹침](series_overlap.png)

## **시리즈 채우기 색상 변경**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getFormat--)을 사용하여 전체 시리즈의 기본 채우기를 설정합니다. 포인트에 명시적인 채우기가 이미 지정된 경우, 해당 포인트의 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 설정이 시리즈 채우기를 재정의합니다.

다음 예제는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![시리즈 색상](series_color.png)

## **시리즈 이름 변경**

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터형 열 차트용 기본 워크북에서는 셀 B1이 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 이름 상수는 해당 구조를 명시적으로 나타냅니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

또한 [IChartSeries.getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getName--)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않도록 해줍니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![시리즈 이름](series_name.png)

## **자동 시리즈 채우기 색상 가져오기**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--)은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 Android ARGB 색상 정수를 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상이 반환될 뿐, 새로운 채우기가 적용되지는 않습니다.

다음 예제는 각 기본 시리즈의 자동 색상 정수를 출력합니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

정수 값은 차트 스타일 및 테마에 따라 달라집니다.

## **차트 시리즈의 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)을 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 다음, [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)을 통해 음수값 색상을 지정하십시오. 음수값 자체는 워크북에 그대로 남으며, 표시 색상만 변경됩니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에 시리즈 이름이, 열 0에 카테고리 이름이, 열 1에 값이 들어 있습니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![반전된 단색 채우기 색상](inverted_solid_fill_color.png)

포인트 하나에 대해서만 반전을 활성화하려면 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)을 사용하십시오. 다음 예제에서는 시리즈에 대한 반전을 비활성화하고 선택된 포인트에만 활성화합니다. 또한 포인트에 음수 값을 할당해 효과를 확인할 수 있습니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **특정 데이터 포인트 값 지우기**

다른 포인트는 유지하면서 하나의 포인트를 비워두려면 해당 백업 워크북 셀을 `null`로 설정합니다. 열 차트의 경우 플롯된 값은 [IChartDataPoint.getValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)을 통해 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 차트의 빈값 설정에 따라 해당 값을 빈값으로 처리합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 지웁니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

산점도 차트는 별도의 X와 Y 셀을 사용하고, 버블 차트는 크기 셀도 사용합니다. 제거하려는 값에 해당하는 셀만 지우십시오. 다른 포인트를 유지하려면 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)를 호출하지 마십시오. 해당 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 비율로 나타낸 것입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)을 호출하십시오. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작으면 더 촘촘해집니다.

다음 예제는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![간격 너비](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/charttype/) 열거형에 포함된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지는 않습니다. 예를 들어, 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하십시오. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/)은 그룹 수준 플로팅 설정을 공유하는 호환 시리즈를 포함합니다. 결합 차트는 둘 이상의 그룹을 가질 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경한다고 해서 차트의 모든 시리즈가 바뀌는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [IShapeCollection.addChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)은 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 시리즈와 카테고리 컬렉션을 모두 비운 뒤 완전히 사용자 정의된 데이터 세트를 추가할 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블, 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 만들 때는 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 하십시오.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 하나요?**

해당 값 셀을 `null`로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. 전체 포인트를 제거하려는 경우에만 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)를 사용하십시오. 카테고리 자체를 제거하는 경우에도 각 시리즈의 값이 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

결과는 차트 유형 및 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)에 구성된 값에 따라 다릅니다. 지원되는 차트는 빈 값을 간격, 0값, 혹은 인접 포인트 연결 방식으로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하십시오.

**음수 값은 어떻게 서식이 지정되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)을 호출하고 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)이 반환하는 색상을 설정하십시오. 개별 포인트에 대해서는 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)으로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에 영향을 주며 저장된 숫자값 자체는 변경되지 않습니다.

**시리즈와 포인트 둘 다 서식이 지정된 경우 어느 것이 우선하나요?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 사용합니다. 겹침이나 간격 너비와 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 오버라이드가 아닙니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides에는 별도의 고정 시리즈 수 제한이 없습니다. 실제 제한은 프레젠테이션 파일 제한, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성에 따라 결정됩니다.

**열이 너무 가깝거나 너무 떨어져 있을 때 어떻게 수정하나요?**

적절한 상위 시리즈 그룹에 대해 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)을 호출하십시오. 값을 증가시키면 클러스터 사이의 간격이 넓어지고, 값을 감소시키면 클러스터가 더 가까워집니다.