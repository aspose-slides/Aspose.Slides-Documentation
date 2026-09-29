---
title: 프레젠테이션에서 Java로 차트 데이터 시리즈 관리
linktitle: 데이터 시리즈
type: docs
url: /ko/java/chart-series/
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
- Java
- Aspose.Slides
description: "Java를 사용하여 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 너비 및 음수 값을 관리하는 방법을 배웁니다."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/)는 관련 값 집합 하나를 나타내며, 시리즈의 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/)은 하나 이상 워크북 셀을 참조합니다. [IChartCategory](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartcategory/) 객체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트만으로 저장되는 것이 아니라 [IChartDataCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/) 객체와 연결됩니다.

일반적인 카테고리 차트의 경우, 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)에 전달되는 워크시트, 행, 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터를 사용해 차트를 만들 때 유용하지만, 모든 기존 차트가 이 레이아웃을 사용한다는 가정은 하지 마세요. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하십시오.

차트 설정은 세 가지 범위로 구분됩니다:

- 시리즈 수준 설정은 [IChartSeries.getFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getFormat--)과 같이 동일 시리즈의 모든 포인트에 대한 기본 모양을 제공합니다.
- 데이터 포인트 설정은 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/#getFormat--)과 같이 하나의 포인트에 대해 시리즈 모양을 재정의합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseriesgroup/)에 속한 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 경우 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) 를 통해 그룹에 접근하세요.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우, 차트 스타일 및 테마가 자동 모양을 결정합니다. 시리즈와 포인트 모두에 서식이 지정된 경우, 해당 포인트에 대해서는 포인트 서식이 우선합니다.

![차트 시리즈 파워포인트](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getOverlap--)는 2D 차트에서 막대 또는 열이 -100%에서 100%까지 겹치는 정도를 보고합니다. 이는 상위 시리즈 그룹에 대한 읽기 전용 프로젝션입니다. 해당 그룹의 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)를 사용하세요. 이 옵션은 그룹화된 막대 또는 열을 표시하는 차트 유형에만 적용되며, 복합 차트의 다른 시리즈 그룹에는 영향을 주지 않습니다.

다음 예시는 첫 번째 시리즈가 포함된 그룹의 겹침을 설정합니다:

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

[IChartSeries.getFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getFormat--)를 사용해 전체 시리즈의 기본 채우기를 설정할 수 있습니다. 포인트에 명시적인 채우기가 이미 있는 경우, 해당 포인트의 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/#getFormat--) 설정이 시리즈 채우기를 재정의합니다.

다음 예시는 첫 번째 시리즈에 단색 파란색 채우기를 적용합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 군집 열 차트용 기본 워크북에서는 셀 B1(행 0, 열 1)에 첫 번째 시리즈 이름이 들어 있습니다. 아래 예시의 명명된 상수는 해당 구조를 명시적으로 보여줍니다:

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

또한 [IChartSeries.getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getName--)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--)는 시리즈 인덱스와 차트 스타일을 기반으로 계산된 색상을 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상이 반환될 뿐, 새로운 채우기가 적용되지는 않습니다.

다음 예시는 각 기본 시리즈의 자동 색상을 출력합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

기본 차트 스타일에 대한 예시 출력:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

정확한 색상은 차트 스타일 및 테마에 따라 다릅니다.

## **차트 시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)를 사용해 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고, 반전을 활성화한 뒤, [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)를 통해 음수 값 색상을 지정하세요. 워크북에서는 음수 값 자체가 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예시는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0에 시리즈 이름이, 열 0에 카테고리 이름이, 열 1에 값이 들어 있습니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

한 포인트에만 반전을 적용하려면 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)를 사용합니다. 아래 예에서는 시리즈에 대한 반전을 비활성화하고 선택한 포인트에만 활성화했습니다. 효과를 보기 위해 포인트에 음수 값을 부여했습니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

한 포인트만 비워두고 다른 포인트는 그대로 두려면 해당 워크북 셀을 `null` 로 설정합니다. 열 차트의 경우 플롯된 값은 [IChartDataPoint.getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/#getValue--)를 통해 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만, 차트는 값이 비어 있다고 처리합니다(차트의 빈값 설정을 따름).

다음 예시는 첫 번째 시리즈의 두 번째 포인트만 삭제합니다:

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

산점도 차트는 X와 Y 셀을 별도로 사용하고, 버블 차트는 크기 셀도 사용합니다. 삭제하려는 값에 해당하는 셀만 비우세요. 다른 포인트를 유지하고 싶다면 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapointcollection/#clear--)를 호출하지 마세요. 이 메서드는 컬렉션의 모든 데이터 포인트를 제거합니다.

## **빈 셀 표시 제어**

값을 포함하고 있는 숨긴 셀은 빈 셀과는 별개의 경우입니다. 숨긴 워크시트 행 및 열의 데이터를 포함하거나 제외하려면 [Include Data from Hidden Rows and Columns](/slides/ko/java/chart-workbook/#include-data-from-hidden-rows-and-columns)를 참조하세요.

빈 워크북 셀은 데이터가 누락된 것을 의미하고, `0`을 포함한 셀은 알려진 숫자 값을 의미합니다. 셀을 비우려면 [IChartDataCell.setValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)에 `null` 을 전달하세요. 숫자 0은 빈 셀 설정과 관계없이 0으로 남습니다.

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)를 사용해 차트가 빈 셀을 표시하는 방식을 선택합니다. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 플롯 방식만 변경합니다.

다음 독립형 예시는 하나의 시리즈를 가진 선 차트를 만들고, Day 3의 값을 삭제한 뒤 각 모드별로 차트를 저장합니다. 입력 파일은 필요하지 않습니다. [IChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/)은 워크시트 0, 열 0에 카테고리 레이블, 열 1에 값을 사용하며, 행 0에 시리즈 이름을 저장합니다. 최종 데이터는 `10, 20, empty, 30, 40` 입니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Day 3을 실제로 비워 두고, 그 카테고리와 데이터 포인트는 유지합니다.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

각 출력 파일은 저장 전에 지정된 모드 이름을 포함합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나만 저장하려면 원하는 모드를 지정하고 한 번만 프레젠테이션을 저장하면 됩니다.

아래 비교는 세 파일의 동일 데이터를 보여줍니다. Day 3은 모든 경우 워크북에서 비어 있습니다:

![동일 데이터가 적용된 선 차트: Gap은 Day 3에서 라인을 끊고, Zero는 라인을 0으로 떨어뜨리며, Span은 Day 2와 Day 4를 연결합니다.](display_blanks_as.png)

보이는 효과는 차트 유형에 따라 다릅니다. 선 차트는 세 가지 모드를 쉽게 비교할 수 있지만, 막대와 열 차트는 누락된 카테고리를 연결할 라인이 없어 `Span`이 위와 같은 연결 구간을 만들 수 없습니다. 또한 누락된 열과 0 높이 열도 비슷하게 보일 수 있습니다. 마커만 있는 산점도 차트 역시 연결 라인이 없습니다. 모든 차트 유형에서 세 가지 결과가 모두 나타난다고 기대하지 말고, 사용 중인 차트 유형에 대해 출력 결과를 확인하세요.

## **시리즈 간격 너비 설정**

간격 너비는 인접한 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 나타낸 것입니다. 겹침과 마찬가지로 이는 개별 시리즈가 아니라 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)를 호출하세요. 값이 클수록 클러스터 사이의 공간이 넓어지고, 값이 작을수록 밀집됩니다.

다음 예시는 간격 너비를 변경하고 최종 프레젠테이션만 저장합니다:

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

[ChartType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/charttype/) 열거형에 정의된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조와 설정이 동일하지 않습니다. 예를 들어 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X와 Y 값을 사용하며, 버블 차트는 버블 크기도 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 메서드를 사용하세요. 겹침 및 간격 너비와 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 하나 이상의 그룹을 가질 수 있으므로, 한 시리즈를 통해 접근한 그룹을 변경해도 차트의 모든 시리즈가 변경되는 것은 아닙니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [IShapeCollection.addChart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 이러한 셀을 편집하거나 완전히 사용자 정의된 데이터 세트를 추가하기 전에 시리즈 및 카테고리 컬렉션을 모두 지울 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체가 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/)의 셀을 참조합니다. 참조된 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 만들 때는 카테고리 행과 시리즈 값 행이 정렬되어 각 포인트가 의도한 카테고리 아래에 플롯되도록 하세요.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 하나요?**

값 셀을 `null` 로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. 전체 시리즈를 삭제하려는 경우에만 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapointcollection/#clear--)를 사용하세요. 카테고리 자체를 제거한다면 모든 시리즈의 값이 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

결과는 차트 유형과 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)에 설정된 값에 따라 달라집니다. 지원되는 차트는 빈 셀을 간격, 0값 또는 인접 포인트 연결 중 하나로 표시할 수 있습니다. 프레젠테이션에서 누락된 데이터의 의미에 맞는 설정을 선택하세요. 전체 예제와 시각적 비교는 [Control the Display of Empty Cells](#control-the-display-of-empty-cells) 섹션을 참고하세요.

**음수 값은 어떻게 서식이 지정되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)를 호출하고, [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)가 반환하는 색상을 지정하세요. 개별 포인트에 대해서는 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)로 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에만 영향을 미치며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선되나요?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식을 사용하거나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 따릅니다. 겹침 및 간격 너비와 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식 재정의가 아닙니다.

**차트에 포함될 수 있는 시리즈 개수에 제한이 있나요?**

Aspose.Slides는 별도의 고정 시리즈 수 제한을 두고 있지 않습니다. 실제 제한은 프레젠테이션 파일 크기, 가용 메모리, 렌더링 시간 및 차트 가독성 등에 따라 달라집니다.

**열이 서로 너무 가깝거나 떨어져 있을 때 어떻게 해야 하나요?**

적절한 상위 시리즈 그룹에 대해 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)를 호출하세요. 값을 늘리면 클러스터 사이의 간격이 넓어지고, 값을 줄이면 클러스터가 더 가까워집니다.