---
title: "Android에서 프레젠테이션의 차트 데이터 레이블 관리"
linktitle: "데이터 레이블"
type: docs
url: /ko/androidjava/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 서식 지정하는 방법을 배우고, 보다 흥미로운 슬라이드를 만들 수 있습니다."
---
## **소개**

데이터 레이블은 차트 시리즈와 개별 데이터 포인트에 대한 정보를 표시하여 독자가 값을 식별하고 차트를 이해하는 데 도움을 줍니다. 이 문서에서는 값 서식 지정, 백분율 표시, 레이블 텍스트 읽기, 축 최대값을 초과하는 레이블 제어, 범주 축 레이블 간격 조정 및 파이 차트 레이블 위치 지정 방법을 설명합니다.

## **차트 데이터 레이블에서 데이터 정밀도 설정**

[setNumberFormatOfValues](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-)를 사용하여 시리즈 값을 서식 지정합니다. 이 예제는 기본 데이터로 선 차트를 만들고, 데이터 표를 표시하며, 첫 번째 시리즈에 값 레이블을 활성화합니다. `#,##0.00` 서식은 천 단위 구분자와 소수점 두 자리를 표시하지만 기본 값은 변경하지 않습니다.

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

## **백분율을 레이블로 표시**

누적 컬럼 차트의 경우, 각 값을 해당 범주 총계의 백분율로 계산하고, [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)이 반환하는 텍스트 프레임에 텍스트를 할당합니다. 이 예제는 기본 차트 데이터를 사용하며, 8포인트 글꼴로 소수점 둘째 자리까지 백분율을 표시합니다. 총계가 0인 범주는 나눗셈 오류 방지를 위해 건너뜁니다. 차트 데이터가 변경될 경우 사용자 정의 레이블 텍스트를 다시 계산합니다.

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

값이 분수로 저장된 경우, [setNumberFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)을 사용하여 백분율을 표시합니다. [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-)에 `false`를 전달하면 레이블 서식이 원본 셀과 독립적으로 적용됩니다.

이 예제는 네 개 범주에 걸쳐 빨강과 파랑 시리즈를 포함하는 100% 누적 컬럼 차트를 생성합니다. 각 값 쌍의 합은 1이 됩니다. 레이블 서식 `0.0%`는 0.30을 30.0%로 표시하고, 수직 축은 소수점 두 자리로 표시합니다. 두 시리즈 모두 흰색 10포인트 레이블 텍스트를 사용합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

## **데이터 레이블의 실제 텍스트 읽기**

[getActualLabelText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--)를 사용하여 데이터 레이블 설정에 의해 생성된 텍스트를 가져옵니다. 이는 보고서용 레이블 추출, 프레젠테이션 내용 검색 또는 차트 검증에 유용합니다. 아래 예제에서는 기본 [data label format](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat/)이 각 범주 이름, 시리즈 이름 및 값을 결합합니다. 하나의 포인트는 값을 백분율로 서식 지정하고, 다른 포인트는 [getTextFrameForOverriding](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)에서 가져온 사용자 정의 텍스트를 사용합니다.

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

데이터 포인트에 저장된 숫자는 `0.75` 그대로이며, 레이블이 범주 및 시리즈 이름과 함께 `75%`를 표시하더라도 값은 변하지 않습니다. 사용자 정의 텍스트는 생성된 레이블 텍스트를 대체합니다. [getActualLabelText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--)은 두 경우 모두 결과 레이블 문자열을 반환합니다. 표시된 레이블만 추출하려면 위와 같이 [isVisible](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabel/#isVisible--)을 별도로 확인하십시오.

## **축 최대값을 초과하는 데이터 레이블 제어**

축 범위를 수동으로 제한하면 일부 데이터 포인트가 최대값을 초과할 수 있습니다. [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-)을 사용하여 이러한 데이터 레이블을 표시할지 여부를 제어합니다. 이 설정은 레이블 가시성을 변경하지만 축 범위나 기본 데이터 값은 변경하지 않습니다.

아래 예제는 값이 60과 120인 2D 클러스터드 컬럼 차트를 생성합니다. 수직 축에 대해 [setAutomaticMaxValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-)에 `false`를 전달하고 [setMaxValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-)로 최대값을 100으로 설정합니다. 첫 번째 슬라이드는 최대값을 초과하는 레이블을 허용하고, 해당 슬라이드 복사본에서는 이를 비활성화합니다. 두 슬라이드 모두 `DataLabelsOverMaximum.pptx`에 저장됩니다.

[value labels]를 활성화하려면 [setShowValue](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-)를 사용합니다. 차트 수준 설정만으로 값 표시가 자동으로 활성화되지는 않으며 개별 레이블의 비활성화된 값 표시를 무시하지도 않습니다. 이 예제는 전체 시리즈에 대해 값을 활성화하고, [setPosition](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-)를 사용해 각 컬럼 외부 끝에 레이블을 배치합니다.

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

다음 이미지는 Microsoft PowerPoint에서 렌더링한 저장된 슬라이드를 보여줍니다. `true`인 경우 레이블 **120**이 상단 경계에 표시되고, `false`인 경우 숨겨집니다. 레이블 **60**은 계속 표시되며, 축 최대값은 **100**으로 유지되고 두 번째 데이터 포인트는 두 경우 모두 **120**으로 남아 있습니다.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![축 최대값이 100인 상태에서 값 레이블 120을 표시하는 PowerPoint 차트](data-labels-over-maximum-true.png) | ![축 최대값이 100인 상태에서 값 레이블 120을 숨기는 PowerPoint 차트](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
이 예제는 값 축이 있는 2D 컬럼 차트를 사용합니다. 파이 차트와 도넛 차트처럼 값 축이 없는 차트는 이와 같이 제한할 축 최대값이 없습니다.
{{% /alert %}}

## **축으로부터 레이블 거리 설정**

[setLabelOffset](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-)을 사용하여 범주 축 레이블과 축 사이의 거리를 제어합니다. 값은 축 레이블 최대 글꼴 크기의 백분율로 지정됩니다. 이 예제는 클러스터드 컬럼 차트를 만든 뒤 수평 축 레이블 오프셋을 500으로 설정합니다. 이 설정은 개별 데이터 포인트에 붙은 레이블이 아니라 범주 축 레이블에 영향을 줍니다.

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

## **레이블 위치 조정**

파이 차트에서 데이터 레이블 위치를 조정해 간격을 개선하고 리더 라인을 위한 공간을 확보합니다.

이 예제는 첫 번째 데이터 포인트의 값을 표시하고 레이블을 슬라이스 외부에 배치한 뒤, [setX](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutable/#setX-float-)와 [setY](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutable/#setY-float-)를 사용해 각각 차트 너비와 높이에 대한 상대적인 수평·수직 오프셋을 조정합니다.

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

## **FAQ**

**밀집된 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인 및 폰트 크기 축소를 결합합니다; 필요한 경우 일부 필드(예: 범주)를 숨기거나 극값 또는 핵심 포인트에만 레이블을 표시합니다.

**값이 0, 음수 또는 비어 있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**

폰트 종류와 크기를 명시적으로 설정하고, 렌더링 환경에 해당 폰트가 존재하는지 확인하여 대체 폰트가 사용되지 않도록 합니다.