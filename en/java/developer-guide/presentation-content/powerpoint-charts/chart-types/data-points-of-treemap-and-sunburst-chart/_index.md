---
title: Customize Data Points in Treemap and Sunburst Charts in Java
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Learn how to create hierarchical data and customize levels, labels, and colors in Treemap and Sunburst charts with Aspose.Slides for Java."
---

## **Overview**

Treemap and Sunburst charts display the same kind of hierarchical data, but they use different layouts. A Treemap draws the hierarchy as nested rectangles whose areas represent leaf values. A Sunburst draws it as concentric rings: top-level groups are near the center, and leaf categories are on the outer ring.

In Aspose.Slides for Java, each numeric value is an [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/). Its [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) method provides access to the leaf and its parent groups. This article explains that mapping and shows how to create and format both chart types from the same sample data.

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

The indexes returned by [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) run from the leaf upward:

| `getDataPointLevels()` index | Logical level | Treemap representation | Sunburst representation |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

This order is the same for both chart types even though their visual layouts differ. A parent segment is shared by several leaves. To format it, use the corresponding level of the first data point in that group. For example, the `Consumer` branch starts with the `Laptops` point, while the `Software` stem starts with the `Licenses` point. Keeping references to those points is clearer and safer than using unexplained expressions such as `dataPoints.get_Item(0)` or `dataPoints.get_Item(6)`.

## **Create and Customize Both Chart Types**

The following complete example creates a Treemap on the first slide and a Sunburst on the second slide. It builds the hierarchy, displays the value for `Tablets`, applies fixed colors to selected levels, formats a branch label, and saves the presentation.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Add the leaf categories. A grouping item is set only when a new group begins;
        // the following categories remain in that group until another item is set.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Show the category and value on the Tablets leaf.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format the Consumer branch through the first leaf in that branch.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Format the Software stem through the first leaf in that stem.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The category cells and value cells use the same worksheet row, so their collection positions remain aligned. When you work with an existing chart rather than creating one, inspect the category rows first and store named references to the data points and levels you intend to format.

## **Behavior and Practical Considerations**

### **Treemap and Sunburst Differences**

- A Treemap uses area to communicate value and nested rectangles to communicate hierarchy. The [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) method controls how parent labels appear in this chart type.
- A Sunburst uses angle to communicate value and ring depth to communicate hierarchy. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) does not control its ring labels.
- Both chart types use the same category grouping levels and the same leaf-to-parent order returned by [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), so the data-building and level-formatting code can be shared.
- Parent values are calculated from their descendant leaves. Do not add separate numeric points for branches or stems.

### **Sorting and Segment Order**

The chart layout engine determines the final placement of rectangles and ring segments. Arrange related category rows together before adding them, but do not rely on a specific rectangle position or start angle. If sequence carries meaning, include it in the labels or use a chart type with an explicit category axis.

### **Theme and Fixed Colors**

Unformatted chart levels inherit colors from the presentation theme. The example uses explicit RGB fills for predictable output. If the chart should follow theme changes, use scheme colors instead of fixed RGB values and avoid overriding every level. Also check label contrast after changing a branch or stem fill.

### **Labels and Available Space**

PowerPoint may hide or truncate labels when a segment is too small. Increasing the chart size, shortening category names, or showing fewer label fields usually produces a clearer result. A label can combine the category name, series name, and value through [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/), but enabling every field often makes hierarchical charts difficult to read.

### **Export and Rendering**

Saving to PPTX keeps the chart editable. When Aspose.Slides renders the presentation to PDF or an image, the supported fills and label settings are rendered with the chart. Font substitution and small differences in available layout space can change line wrapping or label visibility, so install the required fonts and verify important export targets.

## **FAQ**

**Why does changing a parent level affect several leaves?**

A branch or stem is a shared visual segment. Its [IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointlevel/) can be reached through a descendant leaf, but the formatting belongs to the shared parent segment rather than only to that leaf.

**Why is a data label missing?**

First enable the required fields on the label's [IDataLabelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) object. Then check whether the segment has enough space. Treemap parent-label layout, chart dimensions, label length, font size, and the number of enabled fields all affect whether a label can be displayed.

**Can I set the exact order or coordinates of segments?**

You can control the source-row order and keep each group contiguous, but you cannot assign exact Treemap rectangles or Sunburst angles. The chart layout engine calculates them from the hierarchy, values, and available space.

**Why do colors change after the presentation theme changes?**

Theme-based fills are designed to follow the presentation palette. Apply explicit RGB colors to the levels that must remain fixed, or keep scheme colors when adapting to a new theme is preferred.

**Will custom formatting be preserved in PDF and image exports?**

Yes, supported chart fills and label settings are included during rendering. For consistent results across systems, make the required fonts available and test the final export size because label fitting is layout-dependent.

## **See Also**

- [Create Treemap charts](/slides/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/java/export-chart/)
- [Manage presentation themes](/slides/java/presentation-theme/)
