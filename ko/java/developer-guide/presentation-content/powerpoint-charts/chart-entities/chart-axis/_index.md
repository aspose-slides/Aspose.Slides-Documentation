---
title: Java를 사용하여 프레젠테이션에서 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/java/chart-axis/
keywords:
- 차트 축
- 세로 축
- 가로 축
- 축 사용자 지정
- 축 조작
- 축 관리
- 축 속성
- 최대값
- 최소값
- 축 라인
- 날짜 형식
- 축 제목
- 축 위치
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "보고서와 시각화를 위해 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Aspose.Slides for Java를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행과 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트에서 세로 축의 최대값 가져오기**

Create a [프레젠테이션](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) and add an area chart with default data. Call [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) before reading calculated axis values so that the chart layout is up to date.

Read [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) and [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) for the axis limits, and [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) and [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) for the tick intervals. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) and [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) provide time-unit scales, which are relevant to date axes. The example stores these values in local variables and saves the chart.

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

## **축 사이의 데이터 교환**

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로와 세로 축을 교환하지는 않습니다. 예제에서는 행과 열을 전환하기 전에 [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-)을 사용하여 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)와 연결합니다. 네 개의 시리즈와 세 개의 범주가 있는 차트를 저장합니다.

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

## **축의 플로팅 순서 반전**

[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)를 사용하여 범주 축 또는 값 축의 플로팅 순서를 반전시킵니다. 예를 들어, 가로 막대 차트는 워크시트와 같은 순서(계획, 개발, 테스트)로 프로젝트 단계가 위에서 아래로 표시될 수 있습니다. 축을 반전하면 플로팅 방향이 바뀌지만 워크북 데이터를 정렬하거나 재배열하지는 않습니다. 비교하면, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈가 있는 가로 막대 차트를 생성합니다. 정상 순서, 반전된 범주, 반전된 값의 세 슬라이드가 포함된 프레젠테이션을 저장합니다. 각 복사본은 동일한 데이터 세트를 사용하며 각 복사본에서 하나의 축만 반전됩니다.

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

    // 슬라이드 2: 첫 번째 범주를 상단에 표시합니다.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 가로 값 축을 아래쪽에 유지합니다.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 슬라이드 3: 가로 숫자 축만 반전합니다.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

축을 반전하면 수직축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 반전된 범주 축에 `CrossesType.Maximum`을 사용하면 가로 값 축이 아래쪽에 유지됩니다. 특정 교차 지점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)를 사용합니다. 방향을 변경할 때 교차 설정을 확인하세요, 특히 차트에 사용자 지정 교차 지점이 있는 경우. `setPlotOrderReversed`를 `false`로 호출하면 정상 플로팅 방향으로 복원됩니다; 교차 설정은 별개입니다.

| 정상 순서 (슬라이드 1) | 반전된 범주 (슬라이드 2) | 반전된 값 (슬라이드 3) |
| --- | --- | --- |
| ![정상적인 범주 및 값 축 순서를 가진 가로 막대 차트](axis-order-normal.png) | ![위에서 아래로 표시된 범주를 가진 가로 막대 차트](axis-order-categories-reversed.png) | ![값 축이 반전되고 오른쪽에 0이 있는 가로 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고 값은 왼쪽에서 오른쪽으로 증가합니다. | 계획, 개발, 테스트가 위에서 아래로 진행합니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽의 0에서 교차합니다. |

## **꺾은선형 차트에서 세로 축 비활성화**

세로 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 꺾은선형 차트를 생성하고 세로 축을 숨긴 상태로 저장합니다.

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

## **꺾은선형 차트에서 가로 축 비활성화**

가로 축에 `false`를 전달하여 [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 꺾은선형 차트를 생성하고 가로 축을 숨긴 상태로 저장합니다.

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

## **범주 축 변경**

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)을 사용하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 `ExistingChart.pptx`가 필요하며, 첫 번째 슬라이드의 첫 번째 도형인 차트와 범주 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)에 `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-)에 `1`, [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-)에 `TimeUnitType.Months`를 전달하면 주요 눈금이 한 달 간격으로 배치됩니다.

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

## **범주 축 레이블 간격 제어**

차트에 범주가 많이 있을 때 범주나 데이터 포인트를 삭제하지 않고 표시되는 축 레이블 수를 줄입니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)에 `false`를 전달한 후 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)에 전달합니다. 정상 순서의 텍스트 범주의 경우 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 세 번째 레이블마다 표시하며, 표시된 레이블 사이에 두 개의 레이블이 숨겨집니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며 반드시 모든 레이블을 표시하지는 않습니다.

눈금표시에는 별도의 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)에 `false`를 전달하고 [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)을 사용하여 간격을 설정합니다. 예를 들어, `1`은 모든 범주 간격에 눈금표시를 유지하지만 레이블은 세 번째 범주마다만 표시됩니다. 결과를 보기 위해 [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-)에 표시 스타일을 사용합니다. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 해당 간격을 다시 선택합니다.

다음 독립형 예제는 24개의 범주와 하나의 시리즈를 생성한 다음 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 눈금표시가 있는 수동 레이블 간격, 및 복원된 자동 간격. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션이 필요하지 않습니다. 가로 레이블 텍스트는 밀도 차이를 쉽게 확인할 수 있게 합니다.

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

    // 슬라이드 2: 매 세 번째 레이블을 표시하지만 각 범주마다 눈금표시는 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 자동 줄바꿈됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![24개 열 모두가 보이는 자동 범주 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되며, 눈금표시는 모든 범주 간격에 유지됩니다. 레이블이 없는 열을 포함한 24개 모든 열이 동일한 값으로 표시됩니다. 슬라이드 3은 위에 보여진 자동 모양을 복원합니다.

![24개 열 모두가 보이는 세 번째 레이블 간격의 수동 설정](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축(예: 열, 선, 영역 또는 막대 차트의 범주 축)에는 이 범주 수 간격을 사용합니다. 열 차트에서는 가로 축이며, 가로 막대 차트에서는 범주 축이 세로이므로 이러한 설정을 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)가 반환하는 축에 적용합니다. 눈금표시 간격은 시리즈 축이 있는 차트에도 적용됩니다.

범주 레이블 간격을 사용하여 값 축의 숫자 스케일을 설정하지 마세요. 값 축에서 [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-)은 값 차이를 지정합니다: 예를 들어, 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등에 눈금이 생성됩니다. `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도와 버블 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우, [Change a Category Axis](#change-a-category-axis)에서 설명한 바와 같이 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값의 날짜 형식 설정**

예제에서는 기본 차트 데이터를 4개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 이는 1899년 12월 30일부터의 일수로 계산됩니다. [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)에 `CategoryAxisType.Date`를 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)에 `false`를 전달한 다음, [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)에 `yyyy`를 전달하면 셀 서식과 무관하게 범주 레이블에 4자리 연도가 표시됩니다.

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

## **차트 축 제목의 회전 각도 설정**

세로 축에 `true`를 전달하여 [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-)을 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)으로 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목이 90도 회전된 열 차트를 저장합니다.

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

## **범주 또는 값 축의 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)을 사용하여 값 축이 범주 축을 범주 사이에 교차할지 범주 눈금표시에서 교차할지 제어합니다. 이 설정은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 `true`를 설정하고 결과를 저장합니다.

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

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-)을 사용하면 기본 데이터를 변경하지 않고 값 축의 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 생성하고 세로 축에 백만 단위 표시를 적용합니다.

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

양의 값이 여러 자릿수에 걸쳐 차이가 클 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0 근처에 밀집해 보입니다. 로그 스케일은 상대적 성장비를 쉽게 비교하도록 하며, 같은 거리당 같은 비율을 나타냅니다.

값 축에 `true`를 전달하여 [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-)을 호출하고, [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-)으로 기준을 선택합니다. 이는 기존 값이 표시되는 방식을 바꾸지만 데이터 자체를 변경하거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 관계를 나타내는 별도 기능입니다.

### **값 축 및 기준 선택**

선형 또는 열 차트에서는 [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)가 반환하는 축이 값 축입니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)가 반환하는 축이 값 축입니다. 산점도와 버블 차트는 두 개의 값 축이 있으므로 X 값에는 가로 축을, Y 값에는 세로 축을 선택하거나 둘 다 사용합니다. 범주 축에는 로그 스케일을 적용하지 마세요.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지의 기준을 사용할 수 있으며, `2.5`와 같은 소수점 기준도 지원됩니다. 기준이 `10`이면 10, 100, 1,000, 10,000과 같은 연속적인 거듭제곱이 동일한 간격으로 배치됩니다.

### **선형과 로그 스케일 비교**

다음 독립형 예제는 첫 번째 슬라이드에 5개의 요청 횟수를 가진 꺾은선형 차트를 만들고, 해당 슬라이드를 복제한 뒤 두 번째 슬라이드에서 10진 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**Linear scale (slide 1):** 요청 횟수의 차이가 같은 수직 거리에 해당합니다. 가장 큰 값이 차트를 지배하여 작은 값들을 구분하기 어렵게 합니다.

![선형 값 축에서 다섯 개 요청 횟수를 보여주는 PowerPoint 꺾은선형 차트](value-axis-linear.png)

**Logarithmic scale (slide 2):** 같은 수직 거리가 같은 비율을 나타냅니다. 각 기간의 요청 수가 이전 기간의 10배이므로, 10진 기준에서 점들이 직선 상승 형태를 이룹니다. 축 레이블은 여전히 원래 요청 횟수를 표시합니다.

![PowerPoint에서 10진 로그 값 축에 표시된 동일한 다섯 개 요청 횟수](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하세요. 0이나 음수값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 해당 값을 제외하는 것이 적절하면 제외 이유를 설명하세요. 작은 양수로 조용히 대체하면 데이터 의미가 변하므로 하지 마세요. 로그 축에 수동으로 설정한 최소값이나 최대값도 양수여야 합니다.

## **FAQ**

**한 축이 다른 축을 교차하는 값(축 교차)을 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)을 사용하여 교차 동작을 선택합니다. 수치 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준점으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-)을 호출하고 [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None` 중 하나를 사용합니다. 눈금표시 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) 또는 [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)을 사용합니다; 이는 레이블 위치와 별개입니다.