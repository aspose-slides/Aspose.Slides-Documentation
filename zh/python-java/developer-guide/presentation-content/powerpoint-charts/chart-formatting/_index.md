---
title: 在 Python 中格式化演示文稿图表
linktitle: 图表格式化
type: docs
weight: 60
url: /zh/python-java/chart-formatting/
keywords:
- 格式化图表
- 图表格式化
- 图表实体
- 图表属性
- 图表设置
- 图表选项
- 字体属性
- 圆角边框
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via Java 中的图表格式化，并通过专业、抢眼的风格提升您的 PowerPoint 演示文稿。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 在 PowerPoint 演示文稿中格式化图表。它展示了如何自定义关键图表元素，如坐标轴、网格线、标题、图例、绘图区域和墙面填充，以提升图表数据的外观和可读性。

它还演示了如何为图表文本设置字体属性、对图表数据应用预设和自定义数字格式，以及为图表区域启用圆角。通过这些示例，可展示如何同时控制图表的视觉样式和数据呈现。

## **格式化图表实体**
Aspose.Slides for Python via Java 让开发者可以从头在幻灯片中添加自定义图表。本文解释了如何格式化不同的图表实体，包括类别轴和数值轴。

Aspose.Slides for Python via Java 提供了一个简易 API，用于管理不同的图表实体并使用自定义值进行格式化：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引访问幻灯片。
1. 添加一个所需类型且带有默认数据的图表（本示例使用 [ChartType.LineWithMarkers](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/#LineWithMarkers)）。
1. 访问图表数值轴并设置以下属性：
   1. 为数值轴主网格线设置 **Line format**。
   1. 为数值轴次网格线设置 **Line format**。
   1. 为数值轴设置 **Number Format**。
   1. 为数值轴设置 **minimum, maximum, major, and minor units**。
   1. 为数值轴数据设置 **Text Properties**。
   1. 为数值轴设置 **Title**。
1. 访问图表类别轴并设置以下属性：
   1. 为类别轴主网格线设置 **Line format**。
   1. 为类别轴次网格线设置 **Line format**。
   1. 为类别轴数据设置 **Text Properties**。
   1. 为类别轴设置 **Title**。
   1. 为类别轴设置 **Label Positioning**。
   1. 为类别轴标签设置 **Rotation Angle**。
1. 访问图表图例并设置其 **text properties**。
1. 显示图表图例且不与图表重叠。
1. 访问图表的 **secondary value axis** 并设置以下属性：
   1. 启用次要 **value axis**。
   1. 为次要数值轴设置 **Line Format**。
   1. 为次要数值轴设置 **Number Format**。
   1. 为次要数值轴设置 **minimum, maximum, major, and minor units**。
1. 在次要数值轴上绘制第一条图表系列。
1. 设置图表后壁填充颜色。
1. 设置图表绘图区域填充颜色。
1. 将修改后的演示文稿写入 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# 创建 Presentation 类的实例
presentation = Presentation()
try:
    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 添加示例图表
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # 设置图表标题
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # 为数值轴设置主网格线格式
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # 为数值轴设置次网格线格式
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 设置数值轴数字格式
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # 设置图表的最大值和最小值
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # 设置数值轴文本属性
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # 设置数值轴标题
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 为类别轴设置主网格线格式
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # 为类别轴设置次网格线格式
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # 设置类别轴文本属性
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # 设置类别轴标题
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # 设置类别轴标签位置
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # 设置类别轴标签旋转角度
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # 设置图例文本属性
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # 显示图表图例且不与图表重叠

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # 设置次要数值轴
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # 设置次要数值轴数字格式
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # 设置图表的最大值和最小值
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # 设置图表后壁颜色
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # 设置绘图区域颜色
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # 保存演示文稿
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为图表设置字体属性**
Aspose.Slides for Python via Java 支持为图表设置字体属性。请按照以下步骤设置字体属性：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 向幻灯片添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

以下示例演示了这些步骤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 创建 Presentation 类的实例
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置数字格式**
Aspose.Slides for Python via Java 提供了一个简易 API，用于管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引访问幻灯片。
1. 添加一个所需类型且带有默认数据的图表（本示例使用 [ChartType.ClusteredColumn](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/#ClusteredColumn)）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的数据单元格并设置其数字格式。
1. 保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# 创建 Presentation 类的实例
presentation = Presentation()
try:
    # 访问第一张幻灯片
    slide = presentation.getSlides().get_Item(0)

    # 添加默认的簇状柱形图
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # 访问图表系列集合
    chart_series_collection = chart.getChartData().getSeries()

    # 遍历每个图表系列
    for chart_series in chart_series_collection:
        # 遍历系列中的每个数据点
        for data_point in chart_series.getDataPoints():
            # 设置数字格式
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # 保存演示文稿
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下列出了可用的预设数字格式及其索引：

|**0**|常规|
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

## **设置图表区域圆角边框**
Aspose.Slides for Python via Java 通过 [Chart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/) 类的 [hasRoundedCorners](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#hasRoundedCorners) 和 [setRoundedCorners](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setRoundedCorners) 方法支持图表区域的圆角。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 向幻灯片添加图表。
1. 设置图表边框线的填充类型和样式。
1. 启用圆角。
1. 保存修改后的演示文稿。

以下示例演示了这些步骤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# 创建 Presentation 类的实例
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

## **常见问题**

**是否可以为柱形/区域设置半透明填充，同时保持边框不透明？**

可以。填充透明度和轮廓是分开配置的。这有助于在密集的可视化中提升网格和数据的可读性。

**当数据标签重叠时，我该如何处理？**

减小字体大小，禁用非必要的标签组件（例如类别），设置标签偏移/位置，必要时仅对选定点显示标签，或将格式切换为 “值 + 图例”。

**我可以为系列应用渐变或图案填充吗？**

可以。通常同时提供纯色和渐变/图案填充。实际使用时，请适度使用渐变，并避免与网格和文字的对比度下降的组合。