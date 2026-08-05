---
title: 在 Python 中自定义 Treemap 和 Sunburst 图表的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap 图表
- sunburst 图表
- 层级图表
- 数据点
- 数据标签
- 分支颜色
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Python via .NET 创建层级数据，并在 Treemap 和 Sunburst 图表中自定义层级、标签和颜色。"
---
## **概述**

Treemap 和 Sunburst 图表展示相同类型的分层数据，但它们使用不同的布局。Treemap 将层级绘制为嵌套矩形，矩形面积代表叶子节点的数值。Sunburst 将层级绘制为同心环：顶层分组位于中心，叶子类别位于外环。

在 Aspose.Slides for Python via .NET 中，每个数值都是一个 [ChartDataPoint](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/)。其 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 集合提供对叶子及其父级组的访问。本文阐述了这种映射关系，并展示如何使用相同的示例数据创建并格式化两种图表类型。

![包含 Consumer 和 Business 分支的 Treemap 图表](treemap-hierarchy.png)

![包含相同 Consumer 和 Business 层级的 Sunburst 图表](sunburst-hierarchy.png)

## **了解类别、数据点和层级**

下面的示例包含三个类别层级和一个数值序列：

| 分支 | 主干 | 叶子 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每行创建一个叶子类别和一个数据点。类别分组层级描述了从该叶子到其父级的路径。第一行的路径是 `Consumer > Computers > Laptops`。

[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 中的索引从叶子向上运行：

| `data_point_levels` 索引 | 逻辑层级 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 叶子 | 值矩形 | 外环段 |
| `1` | 主干 | 父矩形或标题 | 中环段 |
| `2` | 分支 | 顶层矩形或标题 | 内环段 |

该顺序对两种图表类型都是相同的，尽管它们的视觉布局不同。一个父级段会被多个叶子共享。要格式化它，请使用该组中第一个数据点对应的层级。例如，`Consumer` 分支从 `Laptops` 点开始，而 `Software` 主干则从 `Licenses` 点开始。保留对这些点的引用比使用未说明的表达式（如 `data_points[0]` 或 `data_points[6]`）更清晰、更安全。

## **创建并自定义两种图表类型**

下面的完整示例在第一张幻灯片上创建 Treemap，在第二张幻灯片上创建 Sunburst。它构建层级，显示 `Tablets` 的数值，对选定层级应用固定颜色，格式化分支标签，并保存演示文稿。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # 添加叶子类别。当开始新分组时才设置分组项；
    # 随后类别保持在该分组中，直到设置另一个项。
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # 在 Tablets 叶子上显示类别和数值。
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # 通过该分支的第一个叶子格式化 Consumer 分支。
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # 通过该主干的第一个叶子格式化 Software 主干。
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout 影响 Treemap 的父标签；Sunburst 使用环段。
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```


类别单元格和数值单元格使用相同的工作表行，因此它们的集合位置保持对齐。当您处理已存在的图表而不是新建图表时，请先检查类别行，并存储要格式化的数据点和层级的命名引用。

## **行为和实际考虑事项**

### **Treemap 和 Sunburst 的差异**

- Treemap 使用面积来表示数值，使用嵌套矩形来表示层级。此图表类型的 [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/parent_label_layout/) 属性控制父标签的显示方式。
- Sunburst 使用角度来表示数值，使用环的深度来表示层级。其环标签不受 [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/parent_label_layout/) 控制。
- 两种图表使用相同的类别分组层级和相同的叶子‑到‑父级顺序（`data_point_levels`），因此构建数据和层级格式化的代码可以共享。
- 父级值是从其后代叶子计算得出的。不要为分支或主干单独添加数值点。

### **排序和段顺序**

图表布局引擎决定矩形和环段的最终位置。在添加之前将相关的类别行放在一起，但不要依赖特定的矩形位置或起始角度。如果顺序本身有意义，请将其包含在标签中或使用具有显式类别轴的图表类型。

### **主题和固定颜色**

未格式化的图表层级会继承演示文稿主题的颜色。示例使用显式的 RGB 填充以获得可预测的输出。如果图表需要跟随主题变化，请使用方案颜色而非固定的 RGB 值，并避免对每个层级都进行覆盖。在更改分支或主干填充后，还需检查标签的对比度。

### **标签和可用空间**

当段太小时，PowerPoint 可能隐藏或截断标签。增大图表尺寸、缩短类别名称或显示更少的标签字段通常可以得到更清晰的结果。标签可以通过 [DataLabelFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabelformat/) 将类别名称、系列名称和数值组合在一起，但启用所有字段往往会让分层图表难以阅读。

### **导出和渲染**

保存为 PPTX 可保持图表可编辑。当 Aspose.Slides 将演示文稿渲染为 PDF 或图像时，支持的填充和标签设置会随图表一起渲染。字体替换以及可用布局空间的细微差异可能会改变换行或标签可见性，建议安装所需字体并验证关键导出目标。

## **常见问题**

**为什么更改父级层级会影响多个叶子？**

分支或主干是共享的可视段。可以通过后代叶子访问其 [ChartDataPointLevel](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapointlevel/)，但格式化属于共享的父段，而不是仅属于该叶子。

**为什么缺少数据标签？**

首先在标签的 [DataLabelFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datalabelformat/) 对象上启用所需字段。然后检查该段是否有足够空间。Treemap 父标签布局、图表尺寸、标签长度、字体大小以及已启用字段的数量都会影响标签是否能显示。

**我可以设置段的精确顺序或坐标吗？**

可以控制源行的顺序并保持每个组连续，但不能为 Treemap 矩形或 Sunburst 角度指定精确坐标。图表布局引擎会根据层级、数值和可用空间计算它们。

**主题更改后颜色为什么会变化？**

基于主题的填充设计为跟随演示文稿调色板。对必须保持固定的层级使用显式的 RGB 颜色，或在需要适配新主题时保留方案颜色。

**自定义格式在 PDF 和图像导出时会保留吗？**

会的，受支持的图表填充和标签设置会在渲染时包含。为获得跨系统的一致结果，请提供所需字体并测试最终导出尺寸，因为标签适配取决于布局。

## **参见**

- [Create Treemap charts](/slides/zh/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/zh/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/zh/python-net/export-chart/)
- [Manage presentation themes](/slides/zh/python-net/presentation-theme/)