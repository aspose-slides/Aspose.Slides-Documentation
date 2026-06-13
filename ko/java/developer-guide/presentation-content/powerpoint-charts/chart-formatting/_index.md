---
title: Java에서 프레젠테이션 차트 형식 지정
linktitle: 차트 형식 지정
type: docs
weight: 60
url: /ko/java/chart-formatting/
keywords:
- 차트 형식 지정
- 차트 포맷팅
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 차트 형식 지정 방법을 배우고 전문적이고 눈에 띄는 스타일링으로 PowerPoint 프레젠테이션을 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션의 차트를 형식화하는 방법을 설명합니다. 차트 축, 눈금선, 제목, 범례, 플롯 영역 및 배경 채우기와 같은 주요 차트 요소를 사용자 정의하여 차트 데이터의 외관 및 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 사전 정의 및 사용자 지정 숫자 형식을 차트 데이터에 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 보여줍니다. 이러한 예제를 통해 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어할 수 있습니다.

## **차트 엔터티 형식 지정**
Aspose.Slides for Java는 개발자가 처음부터 슬라이드에 사용자 지정 차트를 추가할 수 있도록 합니다. 이 문서에서는 차트 범주 축 및 값 축을 포함한 다양한 차트 엔터티를 형식화하는 방법을 설명합니다.

Aspose.Slides for Java는 다양한 차트 엔터티를 관리하고 사용자 지정 값을 사용하여 형식화할 수 있는 간단한 API를 제공합니다:

1. [**Presentation**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터와 원하는 유형 중 하나의 차트를 추가합니다(이 예제에서는 ChartType.LineWithMarkers를 사용합니다).
1. 차트 값 축에 접근하여 다음 속성을 설정합니다:
   1. 값 축 주요 격자선에 대한 **Line format** 설정
   1. 값 축 보조 격자선에 대한 **Line format** 설정
   1. 값 축에 대한 **Number Format** 설정
   1. 값 축에 대한 **Min, Max, Major and Minor units** 설정
   1. 값 축 데이터에 대한 **Text Properties** 설정
   1. 값 축에 대한 **Title** 설정
   1. 값 축에 대한 **Line Format** 설정
1. 차트 범주 축에 접근하여 다음 속성을 설정합니다:
   1. 범주 축 주요 격자선에 대한 **Line format** 설정
   1. 범주 축 보조 격자선에 대한 **Line format** 설정
   1. 범주 축 데이터에 대한 **Text Properties** 설정
   1. 범주 축에 대한 **Title** 설정
   1. 범주 축에 대한 **Label Positioning** 설정
   1. 범주 축 레이블에 대한 **Rotation Angle** 설정
1. 차트 범례에 접근하여 **Text Properties**를 설정합니다.
1. 차트와 겹치지 않도록 차트 범례를 표시합니다.
1. 차트 **Secondary Value Axis**에 접근하여 다음 속성을 설정합니다:
   1. 보조 **Value Axis**를 활성화합니다.
   1. 보조 값 축에 대한 **Line Format** 설정
   1. 보조 값 축에 대한 **Number Format** 설정
   1. 보조 값 축에 대한 **Min, Max, Major and Minor units** 설정
1. 이제 첫 번째 차트 시리즈를 보조 값 축에 플롯합니다.
1. 차트 배경벽 채우기 색상을 설정합니다.
1. 차트 플롯 영역 채우기 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

```java
// Presentation 클래스 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 샘플 차트를 추가합니다
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // 차트 제목 설정
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 값 축에 대한 주요 격자선 형식 설정
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 값 축에 대한 보조 격자선 형식 설정
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 값 축 숫자 형식 설정
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // 차트 최대값 및 최소값 설정
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 값 축 텍스트 속성 설정
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 값 축 제목 설정
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 범주 축에 대한 주요 격자선 형식 설정
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // 범주 축에 대한 보조 격자선 형식 설정
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 범주 축 텍스트 속성 설정
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // 범주 축 제목 설정
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 범주 축 레이블 위치 설정
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // 범주 축 레이블 회전 각도 설정
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 범례 텍스트 속성 설정
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // 차트와 겹치지 않게 차트 범례 표시 설정

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 보조 값 축 설정
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 보조 값 축 숫자 형식 설정
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // 차트 최대값 및 최소값 설정
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // 차트 뒷벽 색상 설정
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // 플롯 영역 색상 설정
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // 프레젠테이션 저장
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **차트의 글꼴 속성 설정**
Aspose.Slides for Java는 차트의 글꼴 관련 속성을 설정하는 기능을 제공합니다. 차트의 글꼴 속성을 설정하려면 아래 단계를 따르세요.

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스 객체를 인스턴스화합니다.
- 슬라이드에 차트를 추가합니다.
- 글꼴 높이를 설정합니다.
- 수정된 프레젠테이션을 저장합니다.

아래 예제 코드가 제공됩니다.

```java
// Presentation 클래스 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **숫자 형식 설정**
Aspose.Slides for Java는 차트 데이터 형식을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 기본 데이터와 원하는 유형 중 하나의 차트를 추가합니다(이 예제에서는 **ChartType.ClusteredColumn**을 사용합니다).
1. 가능한 사전 정의 값 중에서 사전 정의 숫자 형식을 설정합니다.
1. 각 차트 시리즈의 차트 데이터 셀을 순회하면서 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.
1. 사용자 지정 숫자 형식을 설정합니다.
1. 각 차트 시리즈 내부의 차트 데이터 셀을 순회하면서 다른 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 프레젠테이션 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 기본 클러스터드 컬럼 차트를 추가합니다
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // 차트 시리즈 컬렉션에 접근합니다
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // 모든 차트 시리즈를 순회합니다
    for (IChartSeries ser : series) 
    {
        // 시리즈의 모든 데이터 셀을 순회합니다
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 숫자 형식을 설정합니다
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // 프레젠테이션을 저장합니다
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

아래 표에 사용 가능한 사전 정의 숫자 형식 값과 해당 인덱스가 제공됩니다:

|**0**|일반|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **차트 영역 둥근 테두리 설정**
Aspose.Slides for Java는 차트 영역 설정을 지원합니다. [**hasRoundedCorners**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart#hasRoundedCorners--) 및 [**setRoundedCorners**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) 메서드가 [IChart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChart) 인터페이스와 [Chart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Chart) 클래스에 추가되었습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 채우기 유형 및 채우기 색상을 설정합니다.
1. 둥근 모서리 속성을 True로 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 샘플 예제가 제공됩니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**열/영역에 반투명 채우기를 적용하면서 테두리를 불투명하게 유지할 수 있나요?**

예. 채우기 투명도와 외곽선은 별도로 설정됩니다. 이는 복잡한 시각화에서 격자와 데이터의 가독성을 향상시키는 데 유용합니다.

**데이터 레이블이 겹칠 때 어떻게 처리할 수 있나요?**

글꼴 크기를 줄이고, 필요 없는 레이블 구성 요소(예: 범주)를 비활성화하며, 레이블 오프셋/위치를 설정하고, 필요한 경우 선택된 포인트에만 레이블을 표시하거나, 형식을 "값 + 범례"로 전환합니다.

**시리즈에 그라디언트 또는 패턴 채우기를 적용할 수 있나요?**

예. 일반적으로 단색 채우기와 그라디언트/패턴 채우기 모두 사용할 수 있습니다. 실제로는 그라디언트를 제한적으로 사용하고, 격자와 텍스트와의 대비를 낮추는 조합은 피하는 것이 좋습니다.