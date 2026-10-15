---
title: Android에서 프레젠테이션의 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "보고서 및 시각화를 위해 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Java를 통해 Android용 Aspose.Slides를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Android for Java를 사용하여 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행 및 열 전환, 축 표시 여부, 범주 레이블 및 눈금 간격, 날짜 범주 및 서식, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트 세로 축에서 최대값 가져오기**

새 [프레젠테이션](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)을 만들고 기본 데이터가 있는 영역 차트를 추가합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 만들기 위해 [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)을 호출합니다.

축 한계값을 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--)와 [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--)를 읽고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--)와 [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--)를 읽습니다. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--)은 날짜 축에 관련된 시간 단위 스케일을 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

차트 데이터에서 시리즈와 범주의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--)을 사용합니다. 이전의 각 범주는 시리즈가 되고, 이전의 각 시리즈는 범주가 됩니다. 이는 데이터 그룹화를 변경하지만 가로 및 세로 축을 교환하지는 않습니다. 예제에서는 행 및 열을 전환하기 전에 기본 데이터를 `Sheet1!A1:D5`(헤더 행 및 범주 열 포함)에 바인딩하기 위해 [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-)를 사용합니다. 네 개의 시리즈와 세 개의 범주를 가진 차트를 저장합니다.

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

## **축 플롯 순서 뒤집기**

[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-)를 사용하여 범주 축 또는 값 축의 플롯 순서를 뒤집습니다. 예를 들어, 가로 막대 차트는 워크시트와 동일한 순서로 상단에서 하단으로 프로젝트 단계를 표시할 수 있습니다: Planning, Development, Testing. 축을 뒤집으면 플롯 방향이 변경되지만 워크북 데이터를 정렬하거나 재배열하지는 않습니다. 비교하면, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--)은 시리즈와 범주의 역할을 교환합니다.

다음 예제는 세 단계와 하나의 시리즈를 가진 가로 막대 차트를 생성합니다. 정상 순서, 범주 뒤집힘, 값 뒤집힘의 세 슬라이드를 포함하는 프레젠테이션을 저장합니다. 각 복사본은 동일한 데이터 집합을 사용하며, 각 복사본에서 하나의 축만 뒤집습니다.

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
    // 수평 값 축을 하단에 유지합니다.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // 슬라이드 3: 수평 숫자 스케일만 뒤집습니다.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

축을 뒤집으면 수직 축을 플롯의 반대쪽으로 이동시킬 수도 있습니다. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-)은 다른 축이 구성 중인 축과 교차하는 위치를 제어합니다. 슬라이드 2에서는 뒤집힌 범주 축에 `CrossesType.Maximum`을 사용하면 가로 값 축이 하단에 유지됩니다. 특정 교차 지점을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)를 사용합니다. 방향을 변경할 때 교차 설정을 확인하십시오, 특히 차트에 사용자 지정 교차 지점이 있는 경우. 정상 플롯 방향을 복구하려면 `setPlotOrderReversed`에 `false`를 전달합니다; 교차 설정은 별개입니다.

| 정상 순서 (슬라이드 1) | 범주 뒤집힘 (슬라이드 2) | 값 뒤집힘 (슬라이드 3) |
| --- | --- | --- |
| ![정상 범주 및 값 축 순서의 가로 막대 차트](axis-order-normal.png) | ![범주가 위에서 아래로 표시되는 가로 막대 차트](axis-order-categories-reversed.png) | ![값 축이 뒤집히고 오른쪽에 0이 있는 가로 막대 차트](axis-order-values-reversed.png) |
| 범주는 아래에서 위로 진행하고, 값은 왼쪽에서 오른쪽으로 증가합니다. | Planning, Development, Testing이 위에서 아래로 진행됩니다. 값과 워크북 행 순서는 변경되지 않습니다. | 범주는 정상 순서를 유지하고, 값은 오른쪽에서 왼쪽으로 증가합니다. 범주 축은 오른쪽의 0에서 교차합니다. |

## **선형 차트에서 세로 축 비활성화**

세로 축을 숨기려면 `false`와 함께 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)를 호출합니다. 예제에서는 기본 데이터가 있는 선형 차트를 생성하고 세로 축이 숨겨진 상태로 저장합니다.

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

## **선형 차트에서 가로 축 비활성화**

가로 축을 숨기려면 `false`와 함께 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)를 호출합니다. 예제에서는 기본 데이터가 있는 선형 차트를 생성하고 가로 축이 숨겨진 상태로 저장합니다.

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

[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)을 사용하여 날짜 또는 텍스트 범주 축을 선택합니다. 이 예제는 첫 슬라이드의 첫 번째 도형으로 차트가 포함된 `ExistingChart.pptx`와 범주 셀에 숫자 Excel 날짜 값이 들어 있는 경우에 필요합니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)에 `false`를, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-)에 `1`을, 그리고 [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-)에 `TimeUnitType.Months`를 전달하면 주요 눈금이 한 달 간격으로 표시됩니다.

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

차트에 많은 범주가 있을 때, 범주나 데이터 포인트를 제거하지 않고 표시되는 축 레이블 수를 줄입니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)에 `false`를 호출한 다음 원하는 범주 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)에 전달합니다. 정상 순서의 텍스트 범주의 경우, 첫 번째 범주부터 카운트가 시작됩니다:

| 간격 | 예제에 표시된 레이블 |
| --- | --- |
| `1` | 범주 1, 범주 2, 범주 3, ... 범주 24 |
| `2` | 범주 1, 범주 3, 범주 5, ... 범주 23 |
| `3` | 범주 1, 범주 4, 범주 7, ... 범주 22 |

`3` 간격은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기준으로 간격을 선택하며, 반드시 모든 레이블을 표시하는 것은 아닙니다.

눈금표시에는 별도의 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)에 `false`를 호출하고 [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)을 사용하여 간격을 설정합니다. 예를 들어, `1`은 각 범주 간격마다 눈금표시를 유지하지만 레이블은 세 번째 범주마다만 표시됩니다. 결과를 확인하려면 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-)에 눈에 보이는 스타일을 지정합니다. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 범주와 하나의 시리즈를 생성한 다음 `CategoryAxisIntervals.pptx`에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 눈금표시가 있는 수동 레이블 간격, 자동 간격 복원. 두 복사본은 원본 차트 데이터를 유지합니다. 입력 프레젠테이션은 필요하지 않습니다. 가로 레이블 텍스트가 밀도 차이를 쉽게 확인하게 합니다.

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

    // 슬라이드 2: 세 번째 레이블마다 표시하지만, 모든 범주에 대한 눈금 표시를 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째마다 범주 레이블이 표시되고 두 줄로 래핑됩니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블마다 한 줄에 표시되고, 눈금표시는 각 범주 간격마다 유지됩니다. 레이블이 없는 열을 포함한 모든 24열이 동일한 값으로 보입니다. 슬라이드 3은 위에 표시된 자동 외관을 복원합니다.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 범주 축, 예를 들어 열, 선, 영역 또는 막대 차트의 범주 축에 이 범주 개수 간격을 사용하십시오. 열 차트에서는 가로 축이 되고, 가로 막대 차트에서는 범주 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)가 반환하는 축에 이 설정을 적용합니다. 눈금표시 간격은 축을 가진 차트의 시리즈 축에도 적용됩니다.

값 축의 숫자 스케일을 설정하기 위해 범주 레이블 간격을 사용하지 마십시오. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-)이 값 차이를 지정합니다: 예를 들어, 주요 단위가 `10`이면 축이 0에서 시작할 때 0, 10, 20 등에 눈금이 표시됩니다. `3` 간격의 범주 레이블은 데이터 값과 무관하게 범주 위치를 셉니다. 산점도 및 거품 차트는 텍스트 범주 축이 아니라 값 축을 사용합니다. 날짜 축의 경우, [범주 축 변경](#change-a-category-axis)에서 설명한 바와 같이 시간 기반 주요 단위와 스케일을 사용하십시오.

## **범주 축 값에 대한 날짜 형식 설정**

예제는 기본 차트 데이터를 연간 값 네 개로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 1899년 12월 30일부터 경과한 일수로 계산됩니다. 두 캘린더 모두 UTC를 사용하고 날짜를 설정하기 전에 초기화하여 일광 절약 시간 및 현재 시간의 영향을 받지 않게 합니다. [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)에 `CategoryAxisType.Date`를 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)에 `false`를 호출한 뒤, [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)에 `yyyy`를 전달하면 범주 레이블이 셀 서식과 무관하게 연도 4자리로 표시됩니다.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

## **차트 축 제목에 회전 각도 설정**

세로 축에 대해 `true`와 함께 [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-)을 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)을 사용하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목이 90도 회전된 열 차트를 저장합니다.

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

## **범주 또는 값 축에 대한 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)를 사용하여 값 축이 범주 축을 범주 사이에 교차할지 범주 눈금표시에서 교차할지 제어합니다. 이 설정은 범주 축에 적용됩니다. 예제에서는 열 차트의 가로 범주 축에 대해 `true`로 설정하고 결과를 저장합니다.

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

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-)를 사용하면 기반 데이터를 변경하지 않고 값 축의 레이블을 스케일링할 수 있습니다. [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제는 열 차트를 생성하고 세로 축에 백만 표시 단위를 적용합니다.

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

양의 값이 여러 규모에 걸쳐 있을 때 로그 값 축이 유용합니다. 예를 들어, 서비스가 다섯 기간에 걸쳐 10, 100, 1,000, 10,000 및 100,000 요청을 받을 수 있습니다. 선형 스케일에서는 작은 값이 0 근처에 가깝게 나타납니다. 로그 스케일은 상대 성장률을 비교하기 쉽게 합니다: 동일한 거리는 동일한 비율을 의미하며, 동일한 차이가 아닙니다.

값 축에 `true`와 함께 [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)을 호출하고, [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-)를 사용하여 베이스를 선택합니다. 이는 기존 값의 표시 방식을 바꾸지만 데이터를 변경하거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터의 적합 관계를 나타내는 별도 기능입니다.

### **값 축 및 베이스 선택**

선형 또는 열 차트에서는 값 축이 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)가 반환합니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)가 반환합니다. 산점도 및 거품 차트는 두 개의 값 축을 가지므로 X 값에는 가로 축, Y 값에는 세로 축, 또는 둘 다 선택합니다. 범주 축에는 로그 스케일링을 적용하지 마십시오.

기본 로그 베이스는 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지(포함) 베이스를 사용할 수 있으며, `2.5`와 같은 소수 베이스도 지원됩니다. 베이스 `10`을 사용하면 10, 100, 1,000, 10,000과 같은 연속적인 거듭 제곱이 동일한 간격을 가집니다.

### **선형 및 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 다섯 개의 요청 수를 가진 선형 차트를 생성하고, 해당 슬라이드를 복제한 뒤 두 번째 슬라이드에서 베이스 10 로그 값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리는 동일한 비율을 나타냅니다. 각 기간은 이전 기간의 10배 요청 수를 가지므로 점들이 베이스 10 스케일에서 직선 상승을 이룹니다. 축 레이블은 여전히 원본 요청 수를 표시합니다.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양의 값만 표시할 수 있습니다. 활성화하기 전에 데이터를 확인하십시오. 0 또는 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 분석에 해당 값을 제외하는 것이 적절하면 그 이유를 설명하십시오. 데이터를 작은 양수로 조용히 대체하지 마십시오. 이는 데이터 의미를 변경합니다. 로그 축에 대해 수동으로 설정한 최소값 또는 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축을 교차하는 값을 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-)을 사용하여 교차 동작을 선택합니다. 수치 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-)을 [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/)을 사용하여 호출합니다: `Low`, `High`, `NextTo`, `None`. 눈금표시 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 또는 [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)을 사용하십시오; 이는 레이블 위치 지정과 별개입니다.