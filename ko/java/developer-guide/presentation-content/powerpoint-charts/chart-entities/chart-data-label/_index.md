---
title: Java를 사용한 프레젠테이션의 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/java/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배워 보다 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하도록 돕습니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과한 레이블 제어, 범주 축 레이블 간격 조정, 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

[setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-)을 사용하여 시리즈 값을 서식 지정합니다. 이 예제는 기본 데이터를 사용해 꺾은선 차트를 만들고, 데이터 테이블을 표시하며 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 서식은 천 단위 구분 기호와 소수점 이하 두 자리를 표시하지만 기본 값은 변경하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **라벨에 백분율 표시**

누적 세로 막대 차트의 경우 각 값을 해당 카테고리 총합에 대한 백분율로 계산하고, [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)이 반환하는 텍스트 프레임에 텍스트로 할당합니다. 이 예제는 기본 차트 데이터를 사용하고, 8포인트 글꼴에 소수점 두 자리 백분율을 표시합니다. 총합이 0인 카테고리는 나눗셈 오류를 피하기 위해 건너뜁니다. 차트 데이터가 변경되면 사용자 정의 레이블 텍스트를 다시 계산해야 합니다.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 데이터 레이블에 백분율 기호 설정**

값이 분수 형태로 저장된 경우 [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)을 사용해 백분율을 표시합니다. 소스 셀과 독립적으로 레이블 서식을 적용하려면 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)에 `false`를 전달합니다.

이 예제는 네 개 카테고리에 빨간색 및 파란색 시리즈가 있는 100% 누적 세로 막대 차트를 만듭니다. 각 값 쌍은 합이 1이 됩니다. 레이블 서식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **데이터 레이블 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--)을 사용하면 데이터 레이블 설정으로 생성된 텍스트를 검색할 수 있습니다. 이는 보고서용 레이블 추출, 프레젠테이션 내용 검색, 생성된 차트 검증 등에 유용합니다. 아래 예제에서는 기본 [데이터 레이블 서식](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/)이 각 카테고리 이름, 시리즈 이름 및 값을 결합합니다. 한 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)에서 사용자 정의 텍스트를 사용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

데이터 포인트에 저장된 숫자는 `0.75`이며, 레이블에 `75%`와 카테고리·시리즈 이름이 함께 표시되더라도 값 자체는 변하지 않습니다. 사용자 정의 텍스트는 자동 생성된 레이블 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--)은 상황에 관계없이 최종 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위와 같이 [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--)을 별도로 확인하십시오.

## **축 최대값을 초과한 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-)을 사용해 이러한 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만, 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터형 세로 막대 차트를 만들고, 수직 축에 대해 [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-)에 `false`를 전달한 뒤 [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-)를 사용해 최대값을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 복사본 슬라이드는 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx` 파일로 저장됩니다.

[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-)를 사용해 값 레이블을 활성화합니다. 차트 수준 설정만으로는 개별 레이블의 표시 여부를 재정의하지 않으며, 값 표시가 비활성화된 레이블을 자동으로 켜지게 하지 않습니다. 이 예제는 전체 시리즈에 값을 활성화하고 [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-)을 사용해 각 열의 외부 끝에 레이블을 배치합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

다음 이미지는 Microsoft PowerPoint에서 렌더링된 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상한선에 표시되고, `false`인 경우 레이블이 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고 두 번째 데이터 포인트는 두 경우 모두 **120**으로 남습니다.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![축 최대값이 100인 상태에서 값 레이블 120을 표시하는 PowerPoint 차트](data-labels-over-maximum-true.png) | ![축 최대값이 100인 상태에서 값 레이블 120을 숨기는 PowerPoint 차트](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값을 갖는 축이 있는 2D 열 차트를 사용합니다. 파이 차트와 도넛 차트처럼 값 축이 없는 차트는 이와 같이 축 최대값을 제한할 수 없습니다.
{{% /alert %}}

## **축으로부터 라벨 간격 설정**

[setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-)을 사용해 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율입니다. 이 예제는 클러스터형 열 차트를 만들고 가로 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 붙은 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **라벨 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정해 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고, 레이블을 조각 외부에 배치한 뒤 [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-)와 [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-)를 사용해 차트 너비와 높이에 대한 상대적인 수평·수직 오프셋을 조정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![조정된 데이터 레이블 위치가 적용된 파이 차트](pie-chart-adjusted-label.png)

## **열 차트 위에 여러 행의 데이터 레이블 추가**

이 예제는 플롯 영역 위에 두 행의 데이터 레이블이 있는 열 차트를 만듭니다. 시리즈 A는 보이는 열을 표시하고, 시리즈 B와 시리즈 C는 추가 레이블을 제공합니다. 이들의 열은 채우기와 윤곽선을 제거해 숨깁니다. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) 메서드는 세 시리즈를 동일한 카테고리 중심에 정렬합니다.

[ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) 설정은 레이블 행을 위한 공간을 예약합니다. [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/)이 기본 위치를 계산한 후, [DataLabel.setX와 DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)가 수평 정렬을 유지하고 수직 오프셋을 적용해 레이블을 두 행으로 배치합니다. 숫자는 시리즈 값에 연결된 데이터 레이블이며, 행 제목만 별도의 텍스트 도형으로 존재합니다.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // B와 C의 열을 숨기지만 데이터 레이블은 유지합니다.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // 세 시리즈를 동일한 카테고리 중심에 맞춥니다.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // 이 간결한 예제를 위해 그리드 라인을 줄입니다.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // 플롯 위에 두 행의 데이터 레이블을 위한 공간을 예약합니다.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // 기본 수평 위치를 유지합니다. Y는 다음으로부터의 오프셋입니다
            // 기본 레이블 위치이며 차트 높이 비율로 표현됩니다.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // 행 제목만 별도의 텍스트 도형입니다.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![플롯 영역 위에 두 행의 데이터 레이블이 있는 열 차트](multiple-rows-of-labels.png)

## **자주 묻는 질문**

**많은 데이터가 있는 차트에서 레이블 겹침을 방지하려면 어떻게 해야 하나요?**  
자동 레이블 배치, 리더 라인, 폰트 축소를 조합하고 필요시 일부 필드(예: 카테고리)를 숨기거나 극값·핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 비어 있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**  
레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 0·음수·결측값에 대해 표시를 끄는 규칙을 적용합니다.

**PDF/이미지로 내보낼 때 레이블 스타일을 일관되게 유지하려면 어떻게 해야 하나요?**  
폰트 패밀리와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 폰트가 존재하는지 확인해 폰트 대체가 발생하지 않도록 합니다.