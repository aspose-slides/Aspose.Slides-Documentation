---
title: Customize Data Points in Treemap and Sunburst Charts in Python
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap chart
- sunburst chart
- hierarchical chart
- data point
- data label
- branch color
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to create hierarchical data and customize levels, labels, and colors in Treemap and Sunburst charts with Aspose.Slides for Python via Java."
---

## **Overview**

Treemap and Sunburst charts display the same kind of hierarchical data, but they use different layouts. A Treemap draws the hierarchy as nested rectangles whose areas represent leaf values. A Sunburst draws it as concentric rings: top-level groups are near the center, and leaf categories are on the outer ring.

In Aspose.Slides for Python via Java, each numeric value is a [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/). Its [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) method provides access to the leaf and its parent groups. This article explains that mapping and shows how to create and format both chart types from the same sample data.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Understand Categories, Data Points, and Levels**

The sample used below has three category levels and one numeric series:

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

Each row creates one leaf category and one data point. The category grouping levels describe the path from that leaf to its parents. For the first row, the path is `Consumer > Computers > Laptops`.

The indexes returned by [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) run from the leaf upward:

| `getDataPointLevels()` index | Logical level | Treemap representation | Sunburst representation |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

This order is the same for both chart types even though their visual layouts differ. A parent segment is shared by several leaves. To format it, use the corresponding level of the first data point in that group. For example, the `Consumer` branch starts with the `Laptops` point, while the `Software` stem starts with the `Licenses` point. Keeping references to those points is clearer and safer than using unexplained expressions such as `data_points.get_Item(0)` or `data_points.get_Item(6)`.

## **Create and Customize Both Chart Types**

The following complete example creates a Treemap on the first slide and a Sunburst on the second slide. It builds the hierarchy, displays the value for `Tablets`, applies fixed colors to selected levels, formats a branch label, and saves the presentation.

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

        # Add the leaf categories. A grouping item is set only when a new group begins;
        # the following categories remain in that group until another item is set.
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

        # Show the category and value on the Tablets leaf.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Format the Consumer branch through the first leaf in that branch.
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

        # Format the Software stem through the first leaf in that stem.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The category cells and value cells use the same worksheet row, so their collection positions remain aligned. When you work with an existing chart rather than creating one, inspect the category rows first and store named references to the data points and levels you intend to format.

## **Behavior and Practical Considerations**

### **Treemap and Sunburst Differences**

- A Treemap uses area to communicate value and nested rectangles to communicate hierarchy. The [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setParentLabelLayout) method controls how parent labels appear in this chart type.
- A Sunburst uses angle to communicate value and ring depth to communicate hierarchy. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setParentLabelLayout) does not control its ring labels.
- Both chart types use the same category grouping levels and the same leaf-to-parent order returned by [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), so the data-building and level-formatting code can be shared.
- Parent values are calculated from their descendant leaves. Do not add separate numeric points for branches or stems.

### **Sorting and Segment Order**

The chart layout engine determines the final placement of rectangles and ring segments. Arrange related category rows together before adding them, but do not rely on a specific rectangle position or start angle. If sequence carries meaning, include it in the labels or use a chart type with an explicit category axis.

### **Theme and Fixed Colors**

Unformatted chart levels inherit colors from the presentation theme. The example uses explicit RGB fills for predictable output. If the chart should follow theme changes, use scheme colors instead of fixed RGB values and avoid overriding every level. Also check label contrast after changing a branch or stem fill.

### **Labels and Available Space**

PowerPoint may hide or truncate labels when a segment is too small. Increasing the chart size, shortening category names, or showing fewer label fields usually produces a clearer result. A label can combine the category name, series name, and value through [DataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/), but enabling every field often makes hierarchical charts difficult to read.

### **Export and Rendering**

Saving to PPTX keeps the chart editable. When Aspose.Slides renders the presentation to PDF or an image, the supported fills and label settings are rendered with the chart. Font substitution and small differences in available layout space can change line wrapping or label visibility, so install the required fonts and verify important export targets.

## **FAQ**

**Why does changing a parent level affect several leaves?**

A branch or stem is a shared visual segment. Its [ChartDataPointLevel](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointlevel/) can be reached through a descendant leaf, but the formatting belongs to the shared parent segment rather than only to that leaf.

**Why is a data label missing?**

First enable the required fields on the label's [DataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) object. Then check whether the segment has enough space. Treemap parent-label layout, chart dimensions, label length, font size, and the number of enabled fields all affect whether a label can be displayed.

**Can I set the exact order or coordinates of segments?**

You can control the source-row order and keep each group contiguous, but you cannot assign exact Treemap rectangles or Sunburst angles. The chart layout engine calculates them from the hierarchy, values, and available space.

**Why do colors change after the presentation theme changes?**

Theme-based fills are designed to follow the presentation palette. Apply explicit RGB colors to the levels that must remain fixed, or keep scheme colors when adapting to a new theme is preferred.

**Will custom formatting be preserved in PDF and image exports?**

Yes, supported chart fills and label settings are included during rendering. For consistent results across systems, make the required fonts available and test the final export size because label fitting is layout-dependent.

## **See Also**

- [Create Treemap charts](/slides/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/python-java/export-chart/)
- [Manage presentation themes](/slides/python-java/presentation-theme/)
