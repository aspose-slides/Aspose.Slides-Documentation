---
title: 在 Python 中自定义 Treemap 和 Sunburst 图表的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 图表
- Sunburst 图表
- 层次结构图表
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 创建层次数据并自定义 Treemap 和 Sunburst 图表的层级、标签和颜色。"
---
## **概述**

Treemap 和 Sunburst 图表显示相同类型的层次数据，但使用不同的布局。Treemap 将层次结构绘制为嵌套矩形，矩形面积代表叶子值。Sunburst 则绘制为同心环：顶层组位于中心附近，叶子类别位于外环。

在 Aspose.Slides for Python via Java 中，每个数值都是一个 [ChartDataPoint](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/)。其 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供对叶子及其父组的访问。本文解释了该映射，并展示如何使用相同的示例数据创建和格式化这两种图表类型。

![包含 Consumer 和 Business 分支的 Treemap 图表](treemap-hierarchy.png)

![包含相同 Consumer 和 Business 层次结构的 Sunburst 图表](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面的示例包含三个类别层级和一个数值系列：

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述了从该叶子到其父级的路径。对于第一行，路径为 `Consumer > Computers > Laptops`。

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 返回的索引从叶子向上：

| `getDataPointLevels()` 索引 | 逻辑层级 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

此顺序对两种图表类型都相同，尽管它们的可视布局不同。父级段由多个叶子共享。要格式化它，使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 干从 `Licenses` 点开始。保留对这些点的引用比使用诸如 `data_points.get_Item(0)` 或 `data_points.get_Item(6)` 等不明确的表达式更清晰、更安全。

## **创建并自定义两种图表类型**

下面的完整示例在第一页创建 Treemap，在第二页创建 Sunburst。它构建层次结构，显示 `Tablets` 的值，对选定层级应用固定颜色，格式化分支标签，并保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # 添加叶子类别。仅在新组开始时设置分组项；
        # 后续类别将保持在该组中，直到设置另一项。
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # 在 Tablets 叶子上显示类别和数值。
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # 通过该分支中的第一个叶子（Consumer）进行分支格式设置。
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # 通过该干中的第一个叶子（Software）进行干的格式设置。
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout 影响 Treemap 的父标签；Sunburst 使用环段。
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

类别单元格和数值单元格使用相同的工作表行，因此它们的集合位置保持对齐。当您使用现有图表而不是创建新图表时，首先检查类别行并存储要格式化的数据点和层级的命名引用。

## **行为和实际注意事项**

### **Treemap 与 Sunburst 的区别**

- Treemap 使用面积传达数值，使用嵌套矩形传达层次。此图表类型的父标签布局由 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setParentLabelLayout) 方法控制。
- Sunburst 使用角度传达数值，使用环深度传达层次。其环标签不受 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setParentLabelLayout) 控制。
- 两种图表使用相同的类别分组层级和相同的叶子到父级顺序，返回自 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)，因此数据构建和层级格式化代码可以共享。
- 父级数值由其子叶子计算得出。不要为分支或干单独添加数值点。

### **排序和段顺序**

图表布局引擎决定矩形和环段的最终位置。将相关的类别行放在一起后再添加，但不要依赖特定的矩形位置或起始角度。如果顺序具有意义，请在标签中包含该信息或使用带有显式类别轴的图表类型。

### **主题和固定颜色**

未格式化的图表层级会从演示文稿主题继承颜色。示例使用显式的 RGB 填充以获得可预测的输出。如果图表应随主题变化，请使用配色方案颜色而非固定 RGB，并避免覆盖每个层级。更改分支或干的填充后，还需检查标签对比度。

### **标签和可用空间**

当段太小而标签被隐藏或截断时，PowerPoint 可能会省略标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常能得到更清晰的结果。标签可以通过 [DataLabelFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/) 将类别名、系列名和数值组合在一起，但启用所有字段往往会使层次图表难以阅读。

### **导出和渲染**

保存为 PPTX 可保持图表可编辑。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能导致换行或标签可见性变化，请安装所需字体并验证关键导出目标。

## **常见问题解答**

**为什么更改父级层级会影响多个叶子？**

分支或干是共享的可视段。它的 [ChartDataPointLevel](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapointlevel/) 可以通过后代叶子访问，但格式化属于共享的父段，而不仅仅是该叶子。

**为什么数据标签缺失？**

首先在标签的 [DataLabelFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/) 对象上启用所需字段。然后检查该段是否有足够空间。Treemap 父标签布局、图表尺寸、标签长度、字体大小以及启用字段的数量都会影响标签是否能够显示。

**我可以设置段的精确顺序或坐标吗？**

可以控制源行顺序并保持每个组连续，但不能为 Treemap 矩形或 Sunburst 角度指定精确坐标。图表布局引擎会根据层次结构、数值和可用空间计算它们。

**为什么在更改演示文稿主题后颜色会变化？**

基于主题的填充会遵循演示文稿调色板。对必须保持固定的层级使用显式 RGB 颜色，或在需要适配新主题时保留配色方案颜色。

**自定义格式在 PDF 和图像导出时会保留吗？**

会的，支持的图表填充和标签设置在渲染时会被包含。为获得跨系统的一致结果，请确保所需字体可用，并测试最终导出尺寸，因为标签适配取决于布局。

## **相关链接**

- [Create Treemap charts](/slides/zh/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/zh/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/zh/python-java/export-chart/)
- [Manage presentation themes](/slides/zh/python-java/presentation-theme/)