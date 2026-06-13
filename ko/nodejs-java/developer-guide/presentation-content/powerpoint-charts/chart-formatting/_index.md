---
title: JavaScript에서 프레젠테이션 차트 서식 지정
linktitle: 차트 서식 지정
type: docs
weight: 60
url: /ko/nodejs-java/chart-formatting/
keywords:
- 차트 서식 지정
- 차트 서식 지정
- 차트 엔터티
- 차트 속성
- 차트 설정
- 차트 옵션
- 글꼴 속성
- 둥근 테두리
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js의 차트 서식 지정 방법을 JavaScript에서 배우고, 전문적이고 시선을 끄는 스타일링으로 PowerPoint 프레젠테이션을 향상시키세요."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 차트를 서식 지정하는 방법을 설명합니다. 축, 눈금선, 제목, 범례, 플롯 영역 및 벽면 채우기와 같은 핵심 차트 요소를 사용자 정의하여 차트 데이터의 외관과 가독성을 향상시키는 방법을 보여줍니다.

또한 차트 텍스트에 대한 글꼴 속성을 설정하고, 차트 데이터에 사전 정의된 숫자 형식 및 사용자 정의 숫자 형식을 적용하며, 차트 영역에 둥근 모서리를 활성화하는 방법을 시연합니다. 이러한 예제를 통해 프레젠테이션에서 차트의 시각적 스타일과 데이터 표시를 모두 제어하는 방법을 배울 수 있습니다.

## **Format Chart Entities**

Aspose.Slides for Node.js via Java를 사용하면 개발자가 처음부터 슬라이드에 사용자 정의 차트를 추가할 수 있습니다. 이 문서는 차트 카테고리 축 및 값 축을 포함한 다양한 차트 엔터티를 서식 지정하는 방법을 설명합니다.

Aspose.Slides for Node.js via Java는 다양한 차트 엔터티를 관리하고 사용자 정의 값으로 서식 지정할 수 있는 간단한 API를 제공합니다:

1. [**Presentation**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 원하는 유형의 차트를 기본 데이터와 함께 추가합니다(이 예제에서는 ChartType.LineWithMarkers를 사용합니다).
1. 차트 값 축에 접근하고 다음 속성을 설정합니다:
   1. 값 축 주요 눈금선에 대한 **Line format** 설정
   1. 값 축 보조 눈금선에 대한 **Line format** 설정
   1. 값 축에 대한 **Number Format** 설정
   1. 값 축에 대한 **Min, Max, Major and Minor units** 설정
   1. 값 축 데이터에 대한 **Text Properties** 설정
   1. 값 축에 대한 **Title** 설정
   1. 값 축에 대한 **Line Format** 설정
1. 차트 카테고리 축에 접근하고 다음 속성을 설정합니다:
   1. 카테고리 축 주요 눈금선에 대한 **Line format** 설정
   1. 카테고리 축 보조 눈금선에 대한 **Line format** 설정
   1. 카테고리 축 데이터에 대한 **Text Properties** 설정
   1. 카테고리 축에 대한 **Title** 설정
   1. 카테고리 축에 대한 **Label Positioning** 설정
   1. 카테고리 축 레이블에 대한 **Rotation Angle** 설정
1. 차트 범례에 접근하고 **Text Properties**를 설정합니다.
1. 차트가 겹치지 않도록 범례를 표시합니다.
1. 차트 **Secondary Value Axis**에 접근하고 다음 속성을 설정합니다:
   1. 보조 **Value Axis** 활성화
   1. 보조 값 축에 대한 **Line Format** 설정
   1. 보조 값 축에 대한 **Number Format** 설정
   1. 보조 값 축에 대한 **Min, Max, Major and Minor units** 설정
1. 이제 첫 번째 차트 시리즈를 보조 값 축에 플롯합니다.
1. 차트 뒤쪽 벽면 채우기 색을 설정합니다.
1. 차트 플롯 영역 채우기 색을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 샘플 차트를 추가합니다
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // 차트 제목 설정
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 값 축의 주요 격자선 서식 설정
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // 값 축의 보조 격자선 서식 설정
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // 값 축 숫자 서식 설정
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // 차트 최대값 및 최소값 설정
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // 값 축 텍스트 속성 설정
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // 값 축 제목 설정
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 카테고리 축의 주요 격자선 서식 설정
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // 카테고리 축의 보조 격자선 서식 설정
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // 카테고리 축 텍스트 속성 설정
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // 카테고리 제목 설정
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // 카테고리 축 레이블 위치 설정
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // 카테고리 축 레이블 회전 각도 설정
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // 범례 텍스트 속성 설정
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // 차트가 겹치지 않도록 범례를 표시하도록 설정
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 보조 값 축 설정
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // 보조 값 축 숫자 서식 설정
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // 차트 최대값 및 최소값 설정
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // 차트 뒷벽 색상 설정
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 플롯 영역 색상 설정
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // 프레젠테이션 저장
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Font Properties for Chart**

Aspose.Slides for Node.js via Java는 차트에 대한 글꼴 관련 속성을 설정하는 기능을 제공합니다. 차트의 글꼴 속성을 설정하려면 아래 단계를 따르세요.

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스 객체를 인스턴스화합니다.
- 슬라이드에 차트를 추가합니다.
- 글꼴 높이를 설정합니다.
- 수정된 프레젠테이션을 저장합니다.

아래에 샘플 예제가 제공됩니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Format of Numerics**

Aspose.Slides for Node.js via Java는 차트 데이터 형식을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 기본 데이터와 함께 원하는 유형의 차트를 추가합니다(이 예제에서는 **ChartType.ClusteredColumn**을 사용합니다).
1. 가능한 사전 정의 값 중에서 사전 정의 숫자 형식을 설정합니다.
1. 각 차트 시리즈의 차트 데이터 셀을 순회하면서 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.
1. 사용자 정의 숫자 형식을 설정합니다.
1. 각 차트 시리즈의 차트 데이터 셀을 순회하면서 서로 다른 차트 데이터 숫자 형식을 설정합니다.
1. 프레젠테이션을 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 프레젠테이션 슬라이드에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 기본 클러스터드 컬럼 차트를 추가합니다
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // 차트 시리즈 컬렉션에 접근합니다
    var series = chart.getChartData().getSeries();
    // 각 차트 시리즈를 순회합니다
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // 시리즈의 각 데이터 셀을 순회합니다
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // 숫자 서식을 설정합니다
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // 프레젠테이션을 저장합니다
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

가능한 사전 정의 숫자 형식 값과 해당 인덱스는 다음과 같습니다:

|**0**|General|
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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Set Chart Area Rounded Borders**

Aspose.Slides for Node.js via Java는 차트 영역에 둥근 모서리를 설정하는 기능을 제공합니다. 메서드 [**hasRoundedCorners**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) 및 [**setRoundedCorners**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-)가 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Chart) 클래스에 추가되었습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스 객체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트의 채우기 유형과 채우기 색을 설정합니다.
1. 둥근 모서리 속성을 True로 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래에 샘플 예제가 제공됩니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

예. 채우기 투명도와 외곽선은 별도로 구성됩니다. 이는 격자와 데이터가 촘촘한 시각화에서 가독성을 높이는 데 유용합니다.

**How can I deal with data labels when they overlap?**

글꼴 크기를 줄이거나, 필요 없는 레이블 요소(예: 카테고리)를 비활성화하고, 레이블 오프셋/위치를 설정하며, 필요 시 선택된 포인트에만 레이블을 표시하거나 “값 + 범례” 형식으로 전환합니다.

**Can I apply gradient or pattern fills to series?**

예. 고체 채우기와 그라디언트/패턴 채우기가 일반적으로 제공됩니다. 실무에서는 그라디언트를 적게 사용하고, 격자와 텍스트 대비를 감소시키는 조합은 피하는 것이 좋습니다.