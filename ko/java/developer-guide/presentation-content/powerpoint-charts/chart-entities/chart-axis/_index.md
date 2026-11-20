---
title: Java를 사용하여 프레젠테이션에서 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/java/chart-axis/
keywords:
- 차트 축
- 수직 축
- 수평 축
- 축 사용자 지정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 선
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 Aspose.Slides for Java를 사용하여 차트 축을 사용자 지정하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축값, 차트 행 및 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 형식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트에서 수직 축의 최대값 가져오기**

기본 데이터가 있는 영역 차트를 추가하기 위해 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 을 생성합니다. 계산된 축값을 읽기 전에 차트 레이아웃이 최신 상태가 되도록 [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) 을 호출합니다.

축 한계를 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) 와 [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) 를 읽고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) 와 [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) 를 사용합니다. 날짜 축에 관련된 시간 단위 스케일은 [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) 와 [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) 가 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **축 간 데이터 교환**

[swapRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) 을 사용하여 차트 데이터에서 시리즈와 범주의 역할을 교환합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화를 변경하지만 수평 및 수직 축을 교환하지는 않습니다. 예제는 [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) 를 사용하여 기본 데이터를 `Sheet1!A1:D5`(머리 행 및 범주 열 포함) 에 바인딩한 다음 행과 열을 전환합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **축의 플롯 순서 역전**

[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) 를 사용하여 범주 축 또는 값 축의 순서를 역전합니다. 예를 들어, 수평 막대 차트는 워크시트와 동일한 순서인 계획, 개발, 테스트 순으로 단계가 위에서 아래로 표시될 수 있습니다. 축을 역전하면 플롯 방향이 바뀔 뿐 데이터가 정렬되거나 재배열되지 않습니다. 비교를 위해 [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) 은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 수평 막대 차트를 생성합니다. 세 슬라이드를 저장합니다: 일반 순서, 역순 카테고리, 역순 값. 각 사본은 동일한 데이터 세트를 사용하며 각각 하나의 축만 역전됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // 슬라이드 2: 첫 번째 범주를 맨 위에 표시합니다.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 수평 값 축을 아래에 유지합니다.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 슬라이드 3: 수평 숫자 눈금만 역전합니다.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

축을 역전하면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 역순 카테고리 축에 `CrossesType.Maximum` 를 지정하여 수평 값 축을 아래쪽에 유지합니다. 특정 교차점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) 를 사용하십시오. 방향을 변경할 때 교차 설정을 확인하십시오, 특히 차트에 사용자 지정 교차점이 이미 있는 경우. `setPlotOrderReversed` 를 `false` 로 호출하면 정상 플롯 방향이 복원됩니다; 교차 설정은 별개입니다.

| 일반 순서 (슬라이드 1) | 역순 카테고리 (슬라이드 2) | 역순 값 (슬라이드 3) |
| --- | --- | --- |
| ![수평 막대 차트 (일반 카테고리 및 값 축 순서)](axis-order-normal.png) | ![수평 막대 차트 (위에서 아래로 표시된 카테고리)](axis-order-categories-reversed.png) | ![수평 막대 차트 (역순 값 축 및 오른쪽에 0 위치)](axis-order-values-reversed.png) |
| 카테고리는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발 및 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 카테고리는 일반 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 카테고리 축은 오른쪽의 0에서 교차합니다. |

## **라인 차트에서 수직 축 비활성화**

수직 축에 `false` 를 전달하여 [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) 를 호출하면 축이 숨겨집니다. 예제는 기본 데이터를 사용하여 라인 차트를 만들고 수직 축을 숨긴 상태로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **라인 차트에서 수평 축 비활성화**

수평 축에 `false` 를 전달하여 [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) 를 호출하면 축이 숨겨집니다. 예제는 기본 데이터를 사용하여 라인 차트를 만들고 수평 축을 숨긴 상태로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 눈금선 표시 또는 숨기기**

축이 표시하는 눈금선을 확인하려면 [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) 와 [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) 를 호출합니다. 이러한 메서드는 현재 가시성을 보고합니다. 보조 눈금선을 표시하려면 [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) 를 사용하고 선 채우기를 실선이면서 보이는 색으로 설정합니다. 숨기려면 채우기를 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill) 로 설정합니다. 주요 눈금선의 선 채우기도 같은 방식으로 [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) 로 변경합니다. 채우기를 변경해도 축 가시성과 눈금표시는 유지됩니다.

이 군집형 세로 막대 차트의 수직 축은 처음에 주요 눈금선만 표시합니다. 예제는 보조 눈금선을 어두운 주황색으로 표시한 뒤 다시 숨기고 프레젠테이션을 저장합니다. 각 단계에서 눈금선 가시성을 출력합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 보조 눈금선 활성화 | 보조 눈금선 숨김 |
| --- | --- |
| ![수직 축의 주요 눈금선 사이에 있는 주황색 보조 눈금선](minor-gridlines-enabled.png) | ![주요 눈금선만 보이는 동일한 세로 막대 차트](minor-gridlines-hidden.png) |

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 를 사용하여 날짜 축 또는 텍스트 축을 선택합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형에 차트가 포함된 `ExistingChart.pptx` 를 필요로 하며, 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 수평 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) 를 `false` 로, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) 를 `1` 로, 그리고 [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) 를 `TimeUnitType.Months` 로 설정하면 주요 눈금이 한 달 간격으로 배치됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **데이터에서 범주 축 유형 결정**

범주 데이터를 채운 후 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) 를 호출하고, [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) 로 선택된 유형을 검사합니다. 동일한 차트가 텍스트 레이블이나 숫자 날짜 값을 받을 수 있는 경우에 유용합니다. 이 메서드는 호출 시점에 유형을 결정하며, 이후 데이터 변경에 대해 지속적인 재평가 모드를 활성화하지 않습니다. 범주를 교체한 뒤 다시 호출하십시오.

다음 예제는 텍스트 범주가 있는 차트를 만든 뒤 선택된 유형이 `CategoryAxisType.Text` 일 때 `true` 를 출력합니다. 그런 다음 범주 셀 값을 날짜로 교체하고 메서드를 다시 호출하여 선택된 유형이 `CategoryAxisType.Date` 일 때 `true` 를 출력합니다. 날짜는 숫자형 OLE Automation 값으로 저장되며, 1899년 12월 30일 이후 경과한 일수로 계산됩니다. [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) 은 이러한 값이 표시되는 방식을 제어하지만 텍스트를 숫자 날짜로 변환하지는 않습니다. 범주 셀에 대한 자세한 내용은 [Chart Workbook](/slides/ko/java/chart-workbook/) 를 참조하십시오.

입력이 텍스트 범주 또는 숫자 날짜인지 알고 있는 경우 자동 결정을 사용하십시오. 일반 숫자 레이블, 혼합 범주 또는 빈 데이터의 경우 의도된 의미에 맞게 명시적으로 [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) 를 호출하십시오. 숫자 값만으로는 범주가 날짜를 나타낸다고 판단할 수 없습니다.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범주 축 레이블 간격 제어**

차트에 많은 범주가 있는 경우 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) 를 `false` 로 설정한 뒤, 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) 에 전달합니다. 정상 순서의 텍스트 범주의 경우 첫 번째 범주부터 계산됩니다:

| 간격 | 예시에서 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 매 세 번째 레이블만 표시하고, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기반으로 간격을 선택하며, 반드시 모든 레이블을 표시하는 것은 아닙니다.

눈금표도 별도로 제어합니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) 를 `false` 로 설정하고 [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) 로 간격을 지정합니다. 예를 들어, `1` 은 레이블이 매 세 번째 범주에만 표시되더라도 모든 범주 간격에 눈금표를 유지합니다. 눈금표가 보이도록 [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) 로 스타일을 지정하십시오. 자동-간격 설정자를 다시 `true` 로 호출하면 차트가 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 만든 뒤 `CategoryAxisIntervals.pptx` 에 세 슬라이드를 저장합니다: 자동 간격, 레이블 간격 수동(눈금표는 독립) 및 자동 간격 복원. 두 사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 수평 레이블 텍스트가 밀도를 쉽게 확인할 수 있게 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // 슬라이드 2: 매 세 번째 레이블을 표시하지만, 각 범주마다 눈금표는 유지합니다.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // 슬라이드 3: 차트가 두 간격을 다시 선택하도록 합니다.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 범주 레이블마다 표시되며 두 줄로 감싸집니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![24개 열 모두 표시된 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블만 한 줄에 표시되고, 눈금표는 모든 범주 간격에 유지됩니다. 레이블이 없는 24개 열 모두가 동일한 값과 함께 표시됩니다. 슬라이드 3은 위의 자동 모양을 복원합니다.

![3간격 수동 범주 레이블, 24개 열 모두 표시](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에서 이 범주 개수 간격을 사용합니다. 열 차트에서는 수평 축이 됩니다. 수평 막대 차트에서는 범주 축이 수직이므로 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 로 반환된 축에 이 설정을 적용합니다. 눈금표 간격은 시리즈 축이 있는 차트에도 적용됩니다.

값 축의 수치 스케일을 설정하려면 범주 레이블 간격을 사용하지 마십시오. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) 은 값 차이를 지정합니다(예: `10` 은 0, 10, 20…과 같이 표시). `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도 및 버블 차트는 텍스트 범주 축이 아닌 값 축을 사용합니다. 날짜 축의 경우 [범주 축 변경](#change-a-category-axis) 섹션에 설명된 대로 시간 기반 주요 단위 및 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일 이후 경과한 일수로 계산됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) 로 `CategoryAxisType.Date` 를 지정하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) 을 `false` 로, 그리고 `yyyy` 를 [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) 에 전달하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 축 제목 회전 각도 설정**

수직 축에 대해 [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) 를 `true` 로 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 로 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전한 세로 막대 차트를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범주 또는 값 축에서 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) 를 사용하여 값 축이 범주 축 사이에 교차할지, 범주 눈금표에 교차할지를 제어합니다. 이 설정은 범주 축에만 적용됩니다. 예제는 열 차트의 수평 범주 축에 `true` 로 설정하고 결과를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **차트 값 축에 표시 단위 설정**

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) 를 사용하면 데이터 자체를 변경하지 않고 값 축 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) 을 `Millions` 로 설정하면 60,000,000 값이 60 으로 표시됩니다. 예제는 열 차트를 만든 뒤 수직 축에 백만 표시 단위를 적용합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **로그 값 축 구성**

양의 값이 여러 차수에 걸쳐 있을 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 5개 기간 동안 10, 100, 1,000, 10,000, 100,000 요청을 받는 경우를 생각해 보십시오. 선형 스케일에서는 작은 값이 0 근처에 몰려 보입니다. 로그 스케일은 동일한 거리마다 동일한 비율을 나타내어 성장 차이를 비교하기 쉽게 합니다.

값 축에 [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) 를 `true` 로 호출하고, [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) 로 기준을 선택합니다. 이는 기존 값이 표시되는 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 별도 기능입니다.

### **값 축 및 기준 선택**

라인 또는 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) 로 반환됩니다. 수평 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) 로 반환됩니다. 산점도와 버블 차트에는 두 개의 값 축이 있으므로 X 값에 수평 축, Y 값에 수직 축을 선택하거나 둘 모두 적용합니다. 카테고리 축에는 로그 스케일을 적용하지 마십시오.

기본 로그 기준은 `10` 입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 기준을 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1,000, 10,000 같은 연속적인 거듭 제곱이 동일한 간격으로 표시됩니다.

### **선형과 로그 스케일링 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수가 있는 라인 차트를 만든 뒤 해당 슬라이드를 복제하고 두 번째 슬라이드에 기준 10 로그 값 축을 활성화합니다. 두 슬라이드는 동일한 데이터를 유지합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 첫 번째 슬라이드는 선형으로 유지하고 복사본의 값 축 스케일만 변경합니다.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**선형 스케일 (슬라이드 1):** 동일한 수직 거리는 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 지배하여 작은 값 구분이 어렵습니다.

![PowerPoint 선형 값 축에 5개의 요청 수를 표시한 선 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간의 요청 수가 이전보다 10배씩 증가하므로 기준‑10 스케일에서는 직선 상승 형태가 됩니다. 축 레이블은 여전히 원래 요청 수를 표시합니다.

![같은 5개의 요청 수를 기본‑10 로그 값 축에 표시한 PowerPoint](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 적용하기 전에 데이터를 확인하십시오. 0이나 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적절하면 그 이유를 설명하십시오. 작은 양수로 대체하면 데이터 의미가 바뀌므로 조용히 바꾸지 마십시오. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**한 축이 다른 축과 교차하는 값(축 교차)을 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) 를 사용하여 교차 동작을 선택합니다. 숫자 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) 를 사용하십시오. 이러한 설정을 통해 축 교차를 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 대해 어떻게 위치시킬 수 있나요?**

[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) 의 `Low`, `High`, `NextTo`, `None` 중 하나를 사용하여 [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) 를 호출합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) 또는 [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) 를 사용하십시오; 이는 레이블 위치와 별개입니다.