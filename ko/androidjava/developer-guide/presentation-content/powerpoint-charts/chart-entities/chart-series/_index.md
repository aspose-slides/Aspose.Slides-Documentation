---
title: Android 프레젠테이션에서 차트 데이터 시리즈 관리
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
description: "Android 프레젠테이션에서 차트 시리즈, 데이터 포인트, 워크북 셀, 서식, 겹침, 간격 폭 및 음수 값을 관리하는 방법을 배우십시오."
---
## **개요**

차트는 플롯된 데이터를 차트 데이터 워크북에 저장합니다. [IChartSeries](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/)는 관련 값 집합 하나를 나타내며, 시리즈의 각 [IChartDataPoint](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/)은 하나 이상의 워크북 셀을 참조합니다. [IChartCategory](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartcategory/) 개체는 시리즈가 공유하는 레이블 또는 그룹화 값을 제공합니다. 따라서 시리즈 이름, 카테고리 및 포인트 값은 표시 텍스트로만 저장되는 것이 아니라 [IChartDataCell](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatacell/) 개체에 연결됩니다.

일반적인 카테고리 차트의 경우 기본 워크북은 행 0을 시리즈 이름에, 열 0을 카테고리 이름에 사용하고 나머지 셀을 시리즈 값에 사용합니다. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)에 전달되는 워크시트, 행 및 열 인덱스는 0부터 시작합니다. 이 레이아웃은 기본 데이터로 차트를 만들 때 유용하지만, 모든 기존 차트가 이를 사용한다고 가정하지 마세요. 로드된 프레젠테이션에서는 워크북 값을 변경하기 전에 시리즈, 카테고리 및 데이터 포인트가 참조하는 셀을 확인하세요.

차트 설정에는 세 가지 범위가 있습니다:

- 시리즈 수준 설정(예: [IChartSeries.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getFormat--))은 하나의 시리즈에 속한 모든 포인트의 기본 모양을 제공합니다.
- 데이터 포인트 설정(예: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--))은 하나의 포인트에 대해 시리즈 모양을 무시합니다.
- 그룹 설정은 동일한 [IChartSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/)에 속한 호환 시리즈에 적용됩니다. 겹침(overlap)이나 간격(gap width)과 같은 옵션을 설정해야 할 때는 [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--)을 통해 그룹에 접근하세요.

명시적인 포인트 또는 시리즈 채우기가 설정되지 않은 경우 차트 스타일과 테마가 자동 모양을 결정합니다. 시리즈와 포인트 포맷팅이 모두 존재할 경우 해당 포인트에 대해서는 포인트 포맷팅이 우선합니다.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **차트 시리즈 겹침 설정**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getOverlap--)는 2D 차트에서 막대나 열이 -100%에서 100%까지 겹치는 정도를 보고합니다. 이는 상위 시리즈 그룹에 대한 읽기 전용 투영값입니다. 해당 그룹에 포함된 모든 호환 시리즈를 업데이트하려면 [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)를 사용하세요. 이 옵션은 그룹화된 막대나 열을 표시하는 차트 유형에만 적용되며, 복합 차트의 무관한 시리즈 그룹에는 영향을 주지 않습니다.

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

[IChartSeries.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getFormat--)을 사용하여 전체 시리즈의 기본 채우기를 설정합니다. 포인트에 명시적인 채우기가 이미 지정되어 있는 경우 해당 포인트의 [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 설정이 시리즈 채우기를 무시합니다.

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

시리즈 이름은 차트 데이터 워크북에 저장되며 일반적으로 범례에 표시됩니다. 클러스터드 열 차트용 기본 워크북에서 셀 B1은 행 0, 열 1에 위치하며 첫 번째 시리즈의 이름을 포함합니다. 다음 예제의 명명된 상수는 해당 구조를 명시적으로 보여줍니다:

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

또한 [IChartSeries.getName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getName--)이 이미 참조하고 있는 셀을 업데이트할 수도 있습니다. 이 방법은 기존 차트에서 특정 행과 열을 가정하지 않으므로 안전합니다:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--)은 시리즈 인덱스와 차트 스타일을 기반으로 계산된 Android ARGB 색상 정수를 반환합니다. 이는 시리즈 채우기가 명시적으로 정의되지 않았을 때 사용되는 색상입니다. 메서드를 호출하면 계산된 색상이 반환될 뿐 새 채우기가 할당되지 않습니다.

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

정확한 정수 값은 차트 스타일과 테마에 따라 다릅니다.

## **시리즈에 대한 반전 채우기 색상 설정**

막대, 열 및 버블 시리즈의 경우, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)를 사용하면 음수 값을 다른 채우기로 표시할 수 있습니다. 일반 시리즈 채우기를 단색으로 설정하고 반전을 활성화한 뒤, [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)을 통해 음수 색상을 지정하세요. 워크북의 음수 값 자체는 변경되지 않으며, 표시 색상만 바뀝니다.

다음 예제는 기본 차트 데이터를 하나의 시리즈로 교체합니다. 워크시트 행 0은 시리즈 이름, 열 0은 카테고리 이름, 열 1은 값을 포함합니다:

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

한 포인트에만 반전을 적용하려면 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)를 사용합니다. 다음 예제에서는 시리즈에 대한 반전을 비활성화하고 선택된 포인트에만 활성화합니다. 해당 포인트에 음수 값을 할당해 효과를 확인할 수 있습니다:

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

다른 포인트를 제거하지 않고 하나의 포인트를 비워두려면 해당 워크북 셀을 `null`로 설정합니다. 열 차트의 경우 플롯된 값은 [IChartDataPoint.getValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)을 통해 얻을 수 있습니다. 데이터 포인트는 동일한 카테고리 위치에 남아 있지만 차트는 값이 비어 있다고 간주합니다.

다음 예제는 첫 번째 시리즈의 두 번째 포인트만 비웁니다:

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

산점도 차트는 X와 Y 셀이 별도이며, 버블 차트는 크기 셀도 별도로 사용합니다. 제거하려는 값이 들어 있는 셀만 비우세요. 다른 포인트를 유지하려는 경우 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) 메서드를 호출하지 마세요. 이 메서드는 해당 시리즈의 모든 데이터 포인트를 삭제합니다.

## **빈 셀 표시 제어**

빈 워크북 셀은 누락된 데이터를 나타내며, `0`이 들어 있는 셀은 알려진 숫자 값을 나타냅니다. 셀을 빈 상태로 만들려면 `null`을 사용해 [IChartDataCell.setValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)를 호출하세요. 숫자 0은 빈 셀 설정에 관계없이 0으로 남습니다.

차트가 빈 셀을 어떻게 표시할지 선택하려면 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)를 사용합니다. 이 설정은 차트 전체에 적용되며, 빈 셀을 0이나 보간값으로 채우지 않고 플롯 방식을 변경합니다.

다음 독립형 예제는 하나의 시리즈가 있는 라인 차트를 만들고 Day 3의 값을 비운 뒤, 각 모드별로 차트를 저장합니다. 입력 파일이 필요 없습니다. [IChartDataWorkbook](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdataworkbook/)은 워크시트 0, 열 0을 카테고리 레이블에, 열 1을 값에 사용하고, 행 0에 시리즈 이름을 둡니다. 최종 데이터는 `10, 20, empty, 30, 40` 입니다:

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

    // Day 3을 실제로 비워두되 카테고리와 데이터 포인트는 유지합니다.
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

각 출력 파일은 저장 전 설정된 모드를 파일명에 반영합니다: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx`. 하나의 버전만 저장하려면 원하는 모드를 지정하고 프레젠테이션을 한 번만 저장하면 됩니다.

아래 비교는 세 파일 모두 동일한 데이터를 보여줍니다. Day 3은 워크북에서 항상 비어 있습니다:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

시각적 효과는 차트 유형에 따라 다릅니다. 라인 차트는 세 모드를 쉽게 비교할 수 있지만, 막대와 열 차트는 연결선이 없어 `Span`이 위와 같은 연결 구간을 만들 수 없습니다. 누락된 열과 높이가 0인 열도 비슷해 보일 수 있습니다. 마커만 있는 산점도 차트 역시 연결선이 없습니다. 모든 차트 유형에서 세 가지 결과가 반드시 나오지는 않으니, 사용 중인 차트 유형에 대한 출력 결과를 확인하세요.

## **시리즈 간격 폭 설정**

간격 폭은 인접 막대 또는 열 클러스터 사이의 공간을 막대 또는 열 너비의 백분율로 표현한 값입니다. 겹침과 마찬가지로 이것은 개별 시리즈가 아닌 상위 시리즈 그룹에 속합니다. 그룹에 대해 한 번만 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)를 호출하세요. 값이 클수록 클러스터 사이의 간격이 넓어지고, 값이 작을수록 밀집됩니다.

다음 예제는 간격 폭을 변경하고 최종 프레젠테이션만 저장합니다:

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

![간격 폭](gap_width.png)

## **FAQ**

**어떤 차트 유형이 데이터 시리즈를 지원하나요?**

[ChartType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/charttype/) 열거형에 포함된 모든 차트 유형은 차트 데이터를 사용하지만, 시리즈마다 값 구조나 설정이 동일하지 않을 수 있습니다. 예를 들어, 카테고리 차트는 카테고리와 값을 사용하고, 산점도 차트는 X 및 Y 값을 사용하며, 버블 차트는 버블 크기를 추가합니다. 시리즈 유형에 맞는 데이터 포인트 생성 방법을 사용하세요. 겹침 및 간격 폭과 같은 옵션은 호환되는 막대 또는 열 그룹에만 적용됩니다.

**차트 시리즈 그룹이란 무엇인가요?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/)은 그룹 수준 플롯 설정을 공유하는 호환 시리즈를 포함합니다. 복합 차트는 둘 이상의 그룹을 포함할 수 있으므로, 하나의 시리즈를 통해 접근한 그룹을 변경해도 차트의 모든 시리즈에 영향을 주지는 않습니다.

**새로 만든 차트에 기본 데이터가 포함되어 있나요?**

예. 기본적으로 [IShapeCollection.addChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)는 샘플 시리즈, 카테고리 및 값을 생성합니다. 해당 셀을 편집하거나 시리즈와 카테고리 컬렉션을 모두 비워 완전한 사용자 정의 데이터 세트를 추가할 수 있습니다. 오버로드를 사용하면 기본 데이터 없이 차트를 만들 수도 있습니다.

**차트 객체는 워크북 셀과 어떻게 연결되나요?**

시리즈 이름, 카테고리 레이블 및 데이터 포인트 값은 [IChartDataWorkbook](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdataworkbook/)의 셀을 참조합니다. 참조 셀을 변경하면 해당 차트 요소가 업데이트됩니다. 사용자 정의 데이터를 구축할 때는 각 포인트가 의도한 카테고리 아래에 플롯되도록 카테고리 행과 시리즈‑값 행을 정렬하세요.

**전체 시리즈가 아니라 하나의 포인트만 지우려면 어떻게 하나요?**

해당 값 셀을 `null`로 설정하면 포인트의 카테고리 위치는 유지된 채 빈 포인트가 됩니다. 모든 포인트를 삭제하려는 경우에만 [IChartDataPointCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)를 사용하세요. 카테고리도 함께 제거한다면, 각 시리즈의 값이 카테고리 컬렉션과 정렬되도록 업데이트해야 합니다.

**빈 포인트는 어떻게 표시되나요?**

표시 방식은 차트 유형과 [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)에 설정된 값에 따라 달라집니다. 지원되는 차트는 빈값을 간격, 0값 또는 인접 포인트 연결로 표시할 수 있습니다. 프레젠테이션의 누락된 데이터 의미에 맞는 설정을 선택하세요. 전체 예제와 시각적 비교는 **빈 셀 표시 제어** 섹션을 참조하세요.

**음수 값은 어떻게 서식이 지정되나요?**

지원되는 막대, 열 및 버블 시리즈의 경우 [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)를 호출하고 [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)이 반환하는 색상을 지정하세요. 개별 포인트에 대해서는 [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)를 사용해 동작을 재정의할 수 있습니다. 이러한 메서드는 서식에만 영향을 주며 저장된 숫자 값은 변경되지 않습니다.

**시리즈와 포인트 모두 서식이 지정된 경우 어느 것이 우선인가요?**

명시적인 데이터 포인트 서식이 해당 포인트에 대해 우선합니다. 다른 포인트는 명시적인 시리즈 서식이나, 시리즈 서식이 정의되지 않은 경우 자동 차트 스타일 및 테마를 따릅니다. 겹침 및 간격 폭과 같은 그룹 설정은 레이아웃을 제어하며 포인트 수준 서식에 의해 무시되지 않습니다.

**차트에 포함될 수 있는 시리즈 수에 제한이 있나요?**

Aspose.Slides는 별도의 고정 시리즈 수 제한을 두고 있지 않습니다. 실제 제한은 프레젠테이션 파일 제약, 사용 가능한 메모리, 렌더링 시간 및 차트 가독성 등에 따라 결정됩니다.

**열이 너무 가깝거나 너무 멀리 떨어져 있을 때 어떻게 해야 하나요?**

해당 상위 시리즈 그룹에 대해 [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)를 호출하세요. 값을 높이면 클러스터 간 간격이 넓어지고, 값을 낮추면 클러스터가 더 가깝게 배치됩니다.