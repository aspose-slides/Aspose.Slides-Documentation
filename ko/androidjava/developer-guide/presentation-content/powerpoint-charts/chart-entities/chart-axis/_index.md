---
title: Android 프레젠테이션에서 차트 축 사용자 지정
linktitle: 차트 축
type: docs
url: /ko/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "보고서 및 시각화를 위한 PowerPoint 프레젠테이션에서 차트 축을 사용자 지정하기 위해 Java를 통해 Aspose.Slides for Android를 사용하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Java를 통해 Aspose.Slides for Android에서 차트 축을 사용자 지정하는 방법을 설명합니다. 계산된 축 값, 차트 행 및 열 전환, 축 표시 여부, 카테고리 레이블 및 눈금 간격, 날짜 카테고리 및 형식 지정, 제목 회전, 축 위치 지정, 표시 단위 및 로그 스케일링을 다룹니다.

## **차트 세로 축의 최대값 가져오기**

기본 데이터를 가진 영역 차트를 추가하고 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)을 생성합니다. 계산된 축 값을 읽기 전에 차트 레이아웃을 최신 상태로 만들기 위해 [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--)을 호출합니다.

축 한계값을 얻으려면 [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--)와 [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--)를 읽고, 눈금 간격을 얻으려면 [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--)와 [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--)를 읽습니다. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--)와 [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--)은 날짜 축과 관련된 시간 단위 스케일을 제공합니다. 예제에서는 이러한 값을 로컬 변수에 저장하고 차트를 저장합니다.

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

## **축 간 데이터 전환**

차트 데이터에서 시리즈와 카테고리의 역할을 교환하려면 [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--)를 사용합니다. 이전 카테고리는 시리즈가 되고, 이전 시리즈는 카테고리가 됩니다. 이는 데이터 그룹화 방식을 변경하지만 가로 축과 세로 축을 교환하지는 않습니다. 예제에서는 행과 열을 전환하기 전에 기본 데이터를 `Sheet1!A1:D5`(헤더 행과 카테고리 열 포함)와 연결하기 위해 [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-)를 사용합니다. 네 개의 시리즈와 세 개의 카테고리를 가진 차트를 저장합니다.

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

## **라인 차트의 세로 축 비활성화**

세로 축에 대해 `false`를 설정하여 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 세로 축이 숨겨진 상태로 저장합니다.

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

## **라인 차트의 가로 축 비활성화**

가로 축에 대해 `false`를 설정하여 [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)를 호출하면 축이 숨겨집니다. 예제에서는 기본 데이터가 있는 라인 차트를 생성하고 가로 축이 숨겨진 상태로 저장합니다.

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

## **카테고리 축 변경**

날짜 또는 텍스트 카테고리 축을 선택하려면 [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)를 사용합니다. 이 예제는 `ExistingChart.pptx` 파일이 필요하며, 첫 번째 슬라이드의 첫 번째 도형이 차트이고 카테고리 셀에 숫자형 Excel 날짜 값이 들어 있습니다. 가로 축을 날짜 축으로 변경합니다. [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)을 `false`로 호출하고, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-)을 `1`로 설정하며, [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-)을 `TimeUnitType.Months`로 지정하면 1개월 간격으로 주요 눈금이 배치됩니다.

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

## **카테고리 축 레이블 간격 제어**

차트에 많은 카테고리가 있을 때 카테고리를 제거하거나 데이터 포인트를 삭제하지 않고 표시되는 축 레이블 수를 줄일 수 있습니다. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)를 `false`로 설정한 다음, 원하는 카테고리 간격을 [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)에 전달합니다. 텍스트 카테고리가 일반 순서대로 있을 때, 첫 번째 카테고리부터 카운트합니다:

| 간격 | 예시에서 표시된 레이블 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

간격 `3`은 세 번째 레이블마다 표시하고, 표시된 레이블 사이에 두 개의 레이블을 숨깁니다. 해당 열은 제거되지 않습니다. 자동 간격은 사용 가능한 공간을 기반으로 간격을 선택하며, 반드시 모든 레이블을 표시하지는 않습니다.

눈금표시에는 별도 제어가 있습니다. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)를 `false`로 설정하고 [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)를 사용하여 간격을 지정합니다. 예를 들어, `1`은 각 카테고리 간격마다 눈금표시를 유지하지만 레이블은 세 번째 카테고리마다만 표시합니다. [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-)를 사용하여 눈에 보이는 스타일을 지정하면 결과를 확인할 수 있습니다. 자동 간격 설정자를 `true`로 다시 호출하면 차트가 해당 간격을 다시 선택합니다.

다음 자체 포함 예제는 24개의 카테고리와 하나의 시리즈를 생성하고 `CategoryAxisIntervals.pptx` 파일에 세 개의 슬라이드를 저장합니다: 자동 간격, 독립 눈금표시가 있는 수동 레이블 간격, 그리고 복원된 자동 간격. 두 사본 모두 원본 차트 데이터를 보존합니다. 입력 프레젠테이션이 필요하지 않습니다. 가로 레이블 텍스트가 밀도 차이를 쉽게 확인할 수 있게 합니다.

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

    // 슬라이드 2: 세 번째 레이블마다 표시하고, 각 카테고리마다 눈금표시는 유지합니다.
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

**자동 간격 (슬라이드 1):** 이 렌더링에서는 두 번째 카테고리 레이블마다 표시되며 두 줄로 감싸집니다. 자동 결과는 차트 크기, 글꼴 및 렌더러에 따라 달라질 수 있습니다.

![모든 24열이 보이는 자동 카테고리 레이블 간격](category-axis-automatic.png)

**수동 간격 (슬라이드 2):** 세 번째 레이블이 한 줄에 표시되고, 눈금표시는 각 카테고리 간격마다 유지됩니다. 레이블이 없는 모든 24열도 동일한 값으로 보입니다. 슬라이드 3은 위의 자동 표시를 복원합니다.

![세 번째 레이블 간격(수동)으로 모든 24열이 보임](category-axis-manual.png)

### **올바른 축 및 간격 선택**

텍스트 카테고리 축(예: 열, 라인, 영역 또는 막대 차트의 카테고리 축)에서 이 카테고리 개수 간격을 사용합니다. 열 차트에서는 가로 축이며, 가로 막대 차트에서는 카테고리 축이 세로이므로 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)에서 반환된 축에 이 설정을 적용합니다. 눈금 간격은 하나의 시리즈 축을 가진 차트에도 적용됩니다.

값 축의 숫자 스케일을 설정하려면 카테고리 레이블 간격을 사용하지 마세요. 값 축에서는 [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-)이 값 차이를 지정합니다: 예를 들어, 주요 단위가 `10`이면 축이 0부터 시작할 때 0, 10, 20 등으로 눈금이 표시됩니다. 반면 카테고리 레이블 간격 `3`은 데이터 값과 관계없이 카테고리 위치를 세며 카운트합니다. 산점도 및 버블 차트는 텍스트 카테고리 축이 아니라 값 축을 사용합니다. 날짜 축의 경우, [Change a Category Axis](#change-a-category-axis) 섹션에 설명된 바와 같이 시간 기반 주요 단위와 스케일을 사용하십시오.

## **카테고리 축 값에 대한 날짜 형식 설정**

예제에서는 기본 차트 데이터를 네 개의 연간 값으로 교체합니다. 날짜는 첫 번째 워크시트(인덱스 `0`)에 OLE Automation 일련 번호로 저장되며, 이는 1899년 12월 30일부터 경과된 일수입니다. 두 캘린더 모두 UTC를 사용하고 날짜를 설정하기 전에 초기화하여 일광 절약 시간 및 현재 시간의 영향을 받지 않도록 합니다. [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)을 `CategoryAxisType.Date`와 함께 사용하고, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)을 `false`로 호출한 뒤, [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)에 `yyyy`를 전달하여 셀 형식과 무관하게 카테고리 레이블이 4자리 연도로 표시되도록 합니다.

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

## **차트 축 제목 회전 각도 설정**

세로 축에 대해 `true`를 인수로 [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-)를 호출하고 제목 텍스트를 제공한 뒤, [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)를 사용하여 제목을 회전합니다. 각도는 도 단위이며, 이 예제는 값 축 제목을 90도 회전시킨 열 차트를 저장합니다.

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

## **카테고리 또는 값 축의 축 위치 설정**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)를 사용하여 값 축이 카테고리 축을 카테고리 사이에 교차할지 카테고리 눈금 표시에서 교차할지 제어합니다. 이 설정은 카테고리 축에 적용됩니다. 예제에서는 열 차트의 가로 카테고리 축에 `true`로 설정하고 결과를 저장합니다.

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

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-)를 사용하여 기본 데이터를 변경하지 않고 값 축의 레이블을 스케일링합니다. [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/)을 `Millions`로 설정하면 60,000,000 값이 60으로 표시됩니다. 예제에서는 열 차트를 생성하고 세로 축에 백만 단위 표시를 적용합니다.

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

## **로그값 축 구성**

로그값 축은 양수 값이 여러 자릿수에 걸쳐 있을 때 유용합니다. 예를 들어, 서비스가 5기간에 걸쳐 10, 100, 1,000, 10,000, 100,000 요청을 받는다고 가정합니다. 선형 스케일에서는 작은 값이 0에 가깝게 모여 보입니다. 로그 스케일은 상대적 성장률을 비교하기 쉬워집니다: 동일한 거리와 비율을 나타냅니다.

[setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)을 `true`로 값 축에 적용하고, [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-)를 사용하여 기준을 선택합니다. 이는 기존 값이 표시되는 방식을 변경하지만 데이터 자체를 바꾸거나 로그 추세선을 추가하지는 않습니다. 추세선은 데이터에 맞춘 관계를 나타내며 별도의 기능입니다.

### **값 축 및 기준 선택**

라인 또는 열 차트에서는 값 축을 [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)로 가져옵니다. 가로 막대 차트에서는 [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)를 사용합니다. 산점도와 버블 차트는 두 개의 값 축을 갖고 있으므로 X 값에는 가로 축을, Y 값에는 세로 축을, 혹은 두 축을 모두 사용합니다. 카테고리 축에는 로그 스케일을 적용하지 마세요.

기본 로그 기준은 `10`입니다. PPTX 차트에서는 `2`부터 `1000`까지의 정수를 기준으로 사용할 수 있으며, `2.5`와 같은 소수 기준도 지원됩니다. 기준 `10`에서는 10, 100, 1,000, 10,000 등이 동일한 간격으로 배치됩니다.

### **선형 및 로그 스케일 비교**

다음 자체 포함 예제는 첫 번째 슬라이드에 5개의 요청 수를 가진 라인 차트를 만들고, 그 슬라이드를 복제한 뒤 두 번째 슬라이드에서 기준 10 로그값 축을 활성화합니다. 두 슬라이드 모두 동일한 데이터를 유지합니다.

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

**선형 스케일 (슬라이드 1):** 동일한 수직 거리가 요청 수의 동일한 차이를 나타냅니다. 가장 큰 값이 차트를 지배하여 작은 값들을 구별하기 어렵게 합니다.

![선형 값 축에 5개의 요청 수를 표시한 PowerPoint 라인 차트](value-axis-linear.png)

**로그 스케일 (슬라이드 2):** 동일한 수직 거리가 동일한 비율을 나타냅니다. 각 기간마다 이전보다 10배 많은 요청이 있으므로, 기준 10 스케일에서는 점들이 직선으로 상승합니다. 축 레이블은 여전히 원본 요청 수를 표시합니다.

![같은 5개의 요청 수를 기준 10 로그값 축에 표시한 PowerPoint](value-axis-logarithmic.png)

### **0 및 음수 값 처리**

로그 스케일은 양수 값만 표시할 수 있습니다. 적용하기 전에 데이터를 확인하십시오. 0 또는 음수 값이 의미가 있다면 선형 스케일을 유지하거나 별도로 표시하십시오. 해당 값을 제외하는 것이 분석에 적절하다면 그 이유를 설명해야 합니다. 작은 양수로 대체하여 조용히 바꾸면 데이터 의미가 변합니다. 로그 축에 수동으로 설정한 최소값 또는 최대값도 양수여야 합니다.

## **FAQ**

**축이 다른 축과 교차하는 값을 어떻게 설정합니까?**

[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-)을 사용하여 교차 방식을 선택합니다. 수치 교차 값을 지정하려면 [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)을 사용합니다. 이러한 설정을 통해 축 교차점을 적절한 기준선으로 이동할 수 있습니다.

**눈금 레이블을 축에 상대적으로 어떻게 배치합니까?**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-)을 호출하고 [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) 중 `Low`, `High`, `NextTo`, `None` 중 하나를 사용합니다. 눈금 자체를 제어하려면 [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) 또는 [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)을 사용합니다; 이는 레이블 위치와 별개입니다.