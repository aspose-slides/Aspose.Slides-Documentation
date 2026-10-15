---
title: 使用 Python 在演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/python-java/chart-axis/
keywords:
- 图表坐标轴
- 垂直坐标轴
- 水平坐标轴
- 自定义坐标轴
- 操作坐标轴
- 管理坐标轴
- 坐标轴属性
- 最大值
- 最小值
- 坐标轴线
- 日期格式
- 坐标轴标题
- 坐标轴位置
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中自定义图表坐标轴，以实现报告和可视化。"
---
## **概览**

本文说明了如何使用 Aspose.Slides for Python via Java 自定义图表坐标轴。内容涉及计算后的坐标轴值、切换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别和格式、标题旋转、坐标轴定位、显示单位以及对数刻度。

## **获取图表垂直坐标轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)并添加一个带有默认数据的面积图。在读取计算后的坐标轴值之前调用[validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout)，以确保图表布局是最新的。

读取[getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue)和[getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue)以获取坐标轴的上下限，读取[getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit)和[getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit)以获取刻度间隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale)和[getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale)提供时间单位的刻度，这对日期坐标轴尤为重要。示例将这些值存入局部变量并保存图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在坐标轴之间交换数据**

使用[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn)来交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例在切换行列之前，使用[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)将默认数据绑定到 `Sheet1!A1:D5`，包括标题行和类别列。它保存了一个包含四个系列和三个类别的图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **反转坐标轴的绘制顺序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed)来反转类别或数值坐标轴。例如，水平条形图可以按照工作表中的顺序（规划、开发、测试）从上到下显示项目阶段。反转坐标轴会改变绘制方向，但不会对工作簿数据进行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn)会交换系列和类别的角色。

下面的示例创建了一个包含三个阶段和一个系列的水平条形图。它保存了一个包含三张幻灯片的演示文稿：正常顺序、类别反转和数值反转。每个副本使用相同的数据集，并且每个副本仅反转一个坐标轴。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # 第 2 张幻灯片：在顶部显示第一个类别。
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # 保持水平数值坐标轴在底部。
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # 第 3 张幻灯片：仅反转水平数值刻度。
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

反转坐标轴还可以将垂直坐标轴移动到绘图区的另一侧。[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType)控制另一坐标轴在被配置坐标轴上的交叉位置。在第 2 张幻灯片中，对反转后的类别坐标轴使用[CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum)可以保持水平数值坐标轴位于底部。若要指定特定的交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)。在更改方向时检查交叉设置，尤其是图表已经有自定义交叉点的情况。调用[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed)并传入 `False` 可以恢复正常的绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别和数值坐标轴顺序正常](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值坐标轴反转且零点在右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部排列；数值从左向右递增。 | 规划、开发和测试从上到下排列。数值及工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左递增。类别坐标轴在右侧零点处交叉。 |

## **禁用折线图的垂直坐标轴**

在垂直坐标轴上调用[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)并传入 `False` 以隐藏它。示例创建了一个默认数据的折线图，并将其保存为垂直坐标轴隐藏的状态。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **禁用折线图的水平坐标轴**

在水平坐标轴上调用[setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible)并传入 `False` 以隐藏它。示例创建了一个默认数据的折线图，并将其保存为水平坐标轴隐藏的状态。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **更改类别坐标轴**

使用[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)来选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中图表是第一张幻灯片的第一个形状，类别单元格包含 Excel 日期的数值。它将水平坐标轴更改为日期坐标轴。调用[setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit)并传入 `False`，以及[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)传入 `1`，再调用[setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale)并传入[TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months)将在一个月间隔放置主刻度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制类别坐标轴标签间隔**

当图表包含大量类别时，可在不删除类别或数据点的前提下降低可见坐标轴标签的数量。调用[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing)并传入 `False`，随后将所需的类别间隔传递给[setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing)。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

`3` 的间隔会每三标签显示一次，在显示的标签之间隐藏两个标签。它不会删除相应的列。自动间隔会根据可用空间选择间隔；并不一定显示所有标签。

刻度线有独立的控制。调用[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing)并传入 `False`，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing)设置其间隔。例如，`1` 在每个类别间隔保留一个刻度线，而标签仅每第三个类别显示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark)并设置可见样式，以便看到效果。再次将任一自动间隔设置器设为 `True`，图表会重新选择该间隔。

下面的自包含示例创建了 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、带独立刻度线的手动标签间隔以及恢复自动间隔。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # 第 2 张幻灯片：显示每三个标签，但保持每个类别都有刻度线。
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # 第 3 张幻灯片：让图表再次自动选择标签和刻度间隔。
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**自动间隔（幻灯片 1）：** 在此呈现中，每第二个类别标签会显示，并换行为两行。自动结果可能随图表大小、字体和渲染器而变化。

![所有 24 列均可见的自动类别标签间隔](category-axis-automatic.png)

**手动间隔（幻灯片 2）：** 每第三个标签在一行显示，而刻度线仍保持在每个类别间隔。所有 24 列，包括没有标签的列，仍保持可见且数值相同。幻灯片 3 恢复了上图所示的自动外观。

![所有 24 列均可见的手动三间隔类别标签](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对文本类别坐标轴（例如柱形图、折线图、面积图或条形图的类别坐标轴）使用此类别计数间隔。在柱形图中，它是水平坐标轴。在水平条形图中，类别坐标轴是垂直的，因此将这些设置应用于[getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)返回的坐标轴。刻度线间隔同样适用于具有系列坐标轴的图表。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit)指定数值差异：例如，当坐标轴从零开始时，主单位为 `10` 会在 0、10、20 等位置生成刻度。类别标签间隔为 `3` 则是按类别位置计数，且与数据值无关。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请使用基于时间的主单位和刻度，如[更改类别坐标轴](#change-a-category-axis)所述。

## **设置类别坐标轴值的日期格式**

示例将默认图表数据替换为四个年度值。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中，计算方式为自 1899 年 12 月 30 日起的天数。使用[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType)并传入[CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date)，调用[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource)并传入 `False`，再将 `yyyy` 传给[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)，使类别标签独立于单元格格式显示四位年份。

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为图表坐标轴标题设置旋转角度**

在垂直坐标轴上调用[setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle)并传入 `True`，提供标题文本，并在标题文本块的格式中设置旋转角度。角度以度为单位；本示例保存了一个数值坐标轴标题旋转 90 度的柱形图。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在类别或数值坐标轴上设置坐标轴位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories)来控制数值坐标轴是位于类别之间还是在类别刻度线处与类别坐标轴交叉。此设置适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为 `True` 并保存结果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在图表数值坐标轴上设置显示单位**

使用[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit)在不更改基础数据的情况下缩放数值坐标轴的标签。将[DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/)设为 `Millions`，则 60,000,000 将显示为 60。示例创建了一个柱形图，并将其垂直坐标轴的显示单位设为百万。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **配置对数数值坐标轴**

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，一个服务在五个周期内可能收到 10、100、1,000、10,000 和 100,000 次请求。在线性刻度下，较小的值会集中在接近零的位置。对数刻度使它们的相对增长更易比较：相等的距离代表相等的比例，而不是相等的差值。

在数值坐标轴上调用[setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic)并传入 `True`，并使用[setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase)选择底数。这会改变现有值的显示方式，但不修改数据，也不会添加对数趋势线。趋势线表示对数据的拟合关系，是独立的功能。

### **选择数值坐标轴和底数**

对于折线图或柱形图，数值坐标轴由[getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis)返回。对于水平条形图，则由[getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis)返回。散点图和气泡图有两个数值坐标轴，因此可为 X 值选择水平坐标轴，为 Y 值选择垂直坐标轴，或两者皆选。不要对类别坐标轴应用对数刻度。

默认的对数底数为 `10`。对于 PPTX 图表，可使用 `2` 到 `1000`（含）之间的底数；也支持诸如 `2.5` 的小数底数。使用底数 `10` 时，后续的幂次如 10、100、1,000、10,000 等间隔相等。

### **比较线性和对数刻度**

以下自包含示例在第一张幻灯片上创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张幻灯片上启用底数为 10 的对数数值坐标轴。两张幻灯片保留相同的数据。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 保持第一张幻灯片为线性，仅更改复制的数值坐标轴比例。
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**线性刻度（幻灯片 1）：** 相等的垂直距离代表请求计数的相等差值。最大值主导图表，使较小的值难以区分。

![PowerPoint 中的折线图，显示线性数值坐标轴上的五个请求计数](value-axis-linear.png)

**对数刻度（幻灯片 2）：** 相等的垂直距离代表相等的比例。每个周期的请求量是前一个周期的十倍，因此在底数为 10 的刻度上，点形成一条直线上升线。坐标轴标签仍显示原始的请求计数。

![相同的五个请求计数在 PowerPoint 中的底数为 10 的对数数值坐标轴上](value-axis-logarithmic.png)

### **处理零和负值**

对数刻度只能显示严格正值。启用之前请检查数据。若零或负值有实际意义，请保持线性刻度或单独显示它们。如果在分析中排除这些值是合适的，请说明省略原因。不要悄悄将其替换为小的正数，因为这会改变数据的意义。对数坐标轴的任何手动设置的最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴交叉另一个坐标轴的数值（坐标轴交叉点）？**

使用[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType)选择交叉行为。若要指定数值交叉点，请使用[setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt)。这些设置可让您将坐标轴交叉点移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**

调用[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition)并使用[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo`或`None`。若要控制刻度线本身，请使用[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark)或[setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark)；这些设置独立于标签定位。