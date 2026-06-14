---
title: 在 Android 上格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/androidjava/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習在 Aspose.Slides for Android via Java 中的圖表格式化，並以專業、吸睛的樣式提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它示範如何自訂圖表的關鍵元素，例如座標軸、格線、標題、圖例、繪圖區以及牆面填充，以提升圖表資料的外觀與可讀性。

同時也示範了如何設定圖表文字的字型屬性、對圖表資料套用預設或自訂的數值格式，以及為圖表區域啟用圓角。這些範例共同展示了如何同時控制簡報中圖表的視覺樣式與資料呈現方式。

## **格式化圖表實體**
Aspose.Slides for Android via Java 讓開發人員能從頭建立自訂圖表。本文說明如何格式化不同的圖表實體，包括圖表類別軸與值軸。

Aspose.Slides for Android via Java 提供簡單的 API 來管理各種圖表實體並使用自訂值進行格式化：

1. 建立 [**Presentation**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參考。
1. 新增一個帶有預設資料且類型為任意想要的圖表（本範例使用 ChartType.LineWithMarkers）。
1. 取得圖表的值軸並設定以下屬性：
   1. 為值軸主格線設定 **Line format**。
   1. 為值軸次格線設定 **Line format**。
   1. 為值軸設定 **Number Format**。
   1. 為值軸設定 **Min, Max, Major and Minor units**。
   1. 為值軸資料設定 **Text Properties**。
   1. 為值軸設定 **Title**。
   1. 為值軸設定 **Line Format**。
1. 取得圖表的類別軸並設定以下屬性：
   1. 為類別軸主格線設定 **Line format**。
   1. 為類別軸次格線設定 **Line format**。
   1. 為類別軸資料設定 **Text Properties**。
   1. 為類別軸設定 **Title**。
   1. 為類別軸設定 **Label Positioning**。
   1. 為類別軸標籤設定 **Rotation Angle**。
1. 取得圖表圖例並為其設定 **Text Properties**。
1. 設定顯示圖例且不與圖表重疊。
1. 取得圖表的 **Secondary Value Axis** 並設定以下屬性：
   1. 啟用次要 **Value Axis**。
   1. 為次要值軸設定 **Line Format**。
   1. 為次要值軸設定 **Number Format**。
   1. 為次要值軸設定 **Min, Max, Major and Minor units**。
1. 現在在次要值軸上繪製第一個圖表系列。
1. 設定圖表背牆填色。
1. 設定圖表繪圖區填色。
1. 將修改後的簡報寫入 PPTX 檔案。

```java
// 建立 Presentation 類別的執行個體
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增範例圖表
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // 設定圖表標題
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 為值軸設定主要格線格式
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // 為值軸設定次要格線格式
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 設定值軸的數值格式
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // 設定圖表的最大值與最小值
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // 設定值軸文字屬性
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // 設定值軸標題
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 為類別軸設定主要格線格式
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // 為類別軸設定次要格線格式
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // 設定類別軸文字屬性
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // 設定類別軸標題
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // 設定類別軸標籤位置
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // 設定類別軸標籤旋轉角度
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // 設定圖例文字屬性
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // 設定顯示圖例且不與圖表重疊

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // 設定次要值軸
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // 設定次要值軸的數值格式
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // 設定圖表的最大值與最小值
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // 設定圖表背牆顏色
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // 設定繪圖區顏色
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // 儲存簡報
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定圖表字型屬性**
Aspose.Slides for Android via Java 提供設定圖表字型相關屬性的功能。請依照以下步驟設定圖表的字型屬性。

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別物件。
- 在投影片上新增圖表。
- 設定字型高度。
- 儲存已修改的簡報。

以下提供範例程式碼。

```java
// 建立 Presentation 類別的執行個體
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

## **設定數值格式**
Aspose.Slides for Android via Java 提供簡單的 API 來管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。
1. 依索引取得投影片的參考。
1. 新增一個帶有預設資料且類型為任意想要的圖表（本範例使用 **ChartType.ClusteredColumn**）。
1. 從可能的預設值中設定數值格式。
1. 逐一遍歷每個圖表系列的資料儲存格，並設定圖表資料的數值格式。
1. 儲存簡報。
1. 設定自訂數值格式。
1. 逐一遍歷每個圖表系列的資料儲存格，設定不同的圖表資料數值格式。
1. 儲存簡報。

```java
// 建立 Presentation 類別的執行個體
Presentation pres = new Presentation();
try {
    // 取得第一張簡報投影片
    ISlide slide = pres.getSlides().get_Item(0);

    // 新增預設的群組直條圖
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // 取得圖表系列集合
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // 逐一遍歷每個圖表系列
    for (IChartSeries ser : series) 
    {
        // 逐一遍歷系列中的每個資料儲存格
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // 設定數值格式
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // 儲存簡報
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

以下為可使用的預設數值格式值、其索引與說明：

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **設定圖表區域圓角邊框**
Aspose.Slides for Android via Java 提供設定圖表區域的功能。已在 [IChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChart) 介面與 [Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Chart) 類別中加入方法 **hasRoundedCorners** 和 **setRoundedCorners**。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表的填充類型與填充顏色。
1. 將圓角屬性設為 True。
1. 儲存已修改的簡報。

以下提供範例程式碼。

```java
// 建立 Presentation 類別的執行個體
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

## **常見問題**

**我可以為柱狀圖/區域圖設定半透明填色，同時保持邊框不透明嗎？**

可以。填色透明度與外框是分別設定的，這有助於提升密集視覺化中格線與資料的可讀性。

**當資料標籤發生重疊時，我該如何處理？**

可以縮小字型、停用非必要的標籤元件（例如類別）、調整標籤偏移/位置、必要時僅顯示選取點的標籤，或改為「值 + 圖例」的格式。

**我可以為系列套用漸層或圖案填色嗎？**

可以。通常同時提供實色與漸層/圖案填色。實務上建議少用漸層，並避免與格線或文字的對比度下降的組合。