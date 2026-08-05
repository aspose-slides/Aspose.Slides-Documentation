---
title: Customize Data Points in Treemap and Sunburst Charts in C++
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap chart
- sunburst chart
- hierarchical chart
- data point
- data label
- branch color
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to create hierarchical data and customize levels, labels, and colors in Treemap and Sunburst charts with Aspose.Slides for C++."
---

## **Overview**

Treemap and Sunburst charts display the same kind of hierarchical data, but they use different layouts. A Treemap draws the hierarchy as nested rectangles whose areas represent leaf values. A Sunburst draws it as concentric rings: top-level groups are near the center, and leaf categories are on the outer ring.

In Aspose.Slides for C++, each numeric value is an [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/). Its [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) method provides access to the leaf and its parent groups. This article explains that mapping and shows how to create and format both chart types from the same sample data.

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

The indexes returned by [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) run from the leaf upward:

| `get_DataPointLevels()` index | Logical level | Treemap representation | Sunburst representation |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

This order is the same for both chart types even though their visual layouts differ. A parent segment is shared by several leaves. To format it, use the corresponding level of the first data point in that group. For example, the `Consumer` branch starts with the `Laptops` point, while the `Software` stem starts with the `Licenses` point. Keeping references to those points is clearer and safer than using unexplained expressions such as `dataPoints->idx_get(0)` or `dataPoints->idx_get(6)`.

## **Create and Customize Both Chart Types**

The following complete example creates a Treemap on the first slide and a Sunburst on the second slide. It builds the hierarchy, displays the value for `Tablets`, applies fixed colors to selected levels, formats a branch label, and saves the presentation.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Add the leaf categories. A grouping item is set only when a new group begins;
    // the following categories remain in that group until another item is set.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Show the category and value on the Tablets leaf.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Format the Consumer branch through the first leaf in that branch.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        ->get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Format the Software stem through the first leaf in that stem.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The category cells and value cells use the same worksheet row, so their collection positions remain aligned. When you work with an existing chart rather than creating one, inspect the category rows first and store named references to the data points and levels you intend to format.

## **Behavior and Practical Considerations**

### **Treemap and Sunburst Differences**

- A Treemap uses area to communicate value and nested rectangles to communicate hierarchy. The [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) method controls how parent labels appear in this chart type.
- A Sunburst uses angle to communicate value and ring depth to communicate hierarchy. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) does not control its ring labels.
- Both chart types use the same category grouping levels and the same leaf-to-parent order returned by [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), so the data-building and level-formatting code can be shared.
- Parent values are calculated from their descendant leaves. Do not add separate numeric points for branches or stems.

### **Sorting and Segment Order**

The chart layout engine determines the final placement of rectangles and ring segments. Arrange related category rows together before adding them, but do not rely on a specific rectangle position or start angle. If sequence carries meaning, include it in the labels or use a chart type with an explicit category axis.

### **Theme and Fixed Colors**

Unformatted chart levels inherit colors from the presentation theme. The example uses explicit RGB fills for predictable output. If the chart should follow theme changes, use scheme colors instead of fixed RGB values and avoid overriding every level. Also check label contrast after changing a branch or stem fill.

### **Labels and Available Space**

PowerPoint may hide or truncate labels when a segment is too small. Increasing the chart size, shortening category names, or showing fewer label fields usually produces a clearer result. A label can combine the category name, series name, and value through [IDataLabelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/), but enabling every field often makes hierarchical charts difficult to read.

### **Export and Rendering**

Saving to PPTX keeps the chart editable. When Aspose.Slides renders the presentation to PDF or an image, the supported fills and label settings are rendered with the chart. Font substitution and small differences in available layout space can change line wrapping or label visibility, so install the required fonts and verify important export targets.

## **FAQ**

**Why does changing a parent level affect several leaves?**

A branch or stem is a shared visual segment. Its [IChartDataPointLevel](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointlevel/) can be reached through a descendant leaf, but the formatting belongs to the shared parent segment rather than only to that leaf.

**Why is a data label missing?**

First enable the required fields on the label's [IDataLabelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/) object. Then check whether the segment has enough space. Treemap parent-label layout, chart dimensions, label length, font size, and the number of enabled fields all affect whether a label can be displayed.

**Can I set the exact order or coordinates of segments?**

You can control the source-row order and keep each group contiguous, but you cannot assign exact Treemap rectangles or Sunburst angles. The chart layout engine calculates them from the hierarchy, values, and available space.

**Why do colors change after the presentation theme changes?**

Theme-based fills are designed to follow the presentation palette. Apply explicit RGB colors to the levels that must remain fixed, or keep scheme colors when adapting to a new theme is preferred.

**Will custom formatting be preserved in PDF and image exports?**

Yes, supported chart fills and label settings are included during rendering. For consistent results across systems, make the required fonts available and test the final export size because label fitting is layout-dependent.

## **See Also**

- [Create Treemap charts](/slides/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cpp/export-chart/)
- [Manage presentation themes](/slides/cpp/presentation-theme/)
