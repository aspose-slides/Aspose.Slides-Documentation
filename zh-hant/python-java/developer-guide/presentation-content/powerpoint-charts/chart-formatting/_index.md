---
title: 在 Python 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/python-java/chart-formatting/
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
- Python
- Aspose.Slides
description: "學習在 Aspose.Slides for Python via Java 中的圖表格式化，並以專業且吸睛的樣式提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂軸線、格線、標題、圖例、繪圖區域以及牆面的填色，以提升圖表資料的外觀與可讀性。

同時也說明了如何為圖表文字設定字型屬性、套用預設與自訂的數值格式，以及為圖表區域啟用圓角。這些範例共同示範了如何同時控制簡報中圖表的視覺樣式與資料呈現方式。

## **格式化圖表實體**
Aspose.Slides for Python via Java 讓開發人員能夠從頭開始在投影片中加入自訂圖表。本文說明如何格式化不同的圖表實體，包括類別軸與值軸。

Aspose.Slides for Python via Java 提供簡易的 API 來管理各種圖表實體並使用自訂值進行格式化：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片。
1. 新增指定類型的圖表，並使用預設資料（本範例使用 [ChartType.LineWithMarkers](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/#LineWithMarkers)）。
1. 取得圖表的值軸並設定以下屬性：
   1. 設定 **Line format** 為值軸主要格線。
   1. 設定 **Line format** 為值軸次要格線。
   1. 設定 **Number Format** 為值軸的數值格式。
   1. 設定 **minimum, maximum, major, and minor units** 為值軸的最小值、最大值、主單位與次單位。
   1. 設定 **Text Properties** 為值軸資料的文字屬性。
   1. 設定 **Title** 為值軸標題。
1. 取得圖表的類別軸並設定以下屬性：
   1. 設定 **Line format** 為類別軸主要格線。
   1. 設定 **Line format** 為類別軸次要格線。
   1. 設定 **Text Properties** 為類別軸資料的文字屬性。
   1. 設定 **Title** 為類別軸標題。
   1. 設定 **Label Positioning** 為類別軸的標籤位置。
   1. 設定 **Rotation Angle** 為類別軸標籤的旋轉角度。
1. 取得圖表圖例並設定其 **text properties**。
1. 顯示圖表圖例且不與圖表重疊。
1. 取得圖表的 **secondary value axis** 並設定以下屬性：
   1. 啟用次要 **value axis**。
   1. 設定 **Line Format** 為次要值軸的線條格式。
   1. 設定 **Number Format** 為次要值軸的數值格式。
   1. 設定 **minimum, maximum, major, and minor units** 為次要值軸的最小值、最大值、主單位與次單位。
1. 在次要值軸上繪製第一個圖表資料系列。
1. 設定圖表背牆的填色。
1. 設定圖表繪圖區域的填色。
1. 將修改後的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# 建立 Presentation 類別的實例
presentation = Presentation()
try:
    # 取得第一張投影片
    slide = presentation.getSlides().get_Item(0)

    # 加入範例圖表
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # 設定圖表標題
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # 為值軸設定主要格線格式
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # 為值軸設定次要格線格式
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 設定值軸的數值格式
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # 設定圖表的最大值與最小值
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # 設定值軸文字屬性
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # 設定值軸標題
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 為類別軸設定主要格線格式
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # 為類別軸設定次要格線格式
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 設定類別軸文字屬性
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # 設定類別軸標題
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 設定類別軸標籤位置
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # 設定類別軸標籤旋轉角度
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # 設定圖例文字屬性
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # 顯示圖例且不與圖表重疊

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # 設定次要值軸
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # 設定次要值軸的數值格式
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # 設定圖表的最大值與最小值
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # 設定圖表背牆顏色
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # 設定繪圖區域顏色
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # 儲存簡報
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **為圖表設定字型屬性**
Aspose.Slides for Python via Java 支援為圖表設定字型屬性。依照以下步驟設定字型屬性：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 在投影片上加入圖表。
- 設定字型高度。
- 儲存修改後的簡報。

以下範例示範上述步驟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 建立 Presentation 類別的實例
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定數值格式**
Aspose.Slides for Python via Java 提供簡易的 API 來管理圖表資料格式：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片。
1. 新增指定類型的圖表，並使用預設資料（本範例使用 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/#ClusteredColumn)）。
1. 從可用的預設值中設定數值格式。
1. 逐一遍歷每個圖表系列中的資料儲存格，並設定其數值格式。
1. 儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 建立 Presentation 類別的實例
presentation = Presentation()
try:
    # 取得第一張簡報投影片
    slide = presentation.getSlides().get_Item(0)

    # 加入預設的叢集直條圖
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # 取得圖表系列集合
    chart_series_collection = chart.getChartData().getSeries()

    # 迭代每個圖表系列
    for chart_series in chart_series_collection:
        # 迭代系列中的每個資料點
        for data_point in chart_series.getDataPoints():
            # 設定數值格式
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # 儲存簡報
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

可用的預設數值格式與其索引列於下方：

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
Aspose.Slides for Python via Java 透過 [Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 類別的 [hasRoundedCorners](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#hasRoundedCorners) 與 [setRoundedCorners](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setRoundedCorners) 方法支援圖表區域的圓角功能。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 在投影片上加入圖表。
1. 設定圖表邊框線的填色類型與樣式。
1. 啟用圓角。
1. 儲存修改後的簡報。

以下範例示範上述步驟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# 建立 Presentation 類別的實例
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**我可以在設定欄位/區域的填色時保留邊框不透明嗎？**

可以。填色透明度與輪廓是分別設定的。這在提升密集視覺化圖表的格線與資料可讀性時相當有用。

**當資料標籤重疊時該怎麼處理？**

可縮小字型、停用非必要的標籤元件（例如類別）、設定標籤偏移/位置、必要時僅顯示選取點的標籤，或改為「值 + 圖例」的格式。

**我可以為資料系列套用漸層或圖樣填色嗎？**

可以。固體與漸層/圖樣填色通常都可使用。實務上建議節制使用漸層，避免與格線及文字的對比度下降。