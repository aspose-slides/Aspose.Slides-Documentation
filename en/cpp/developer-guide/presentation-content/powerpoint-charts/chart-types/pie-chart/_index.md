---
title: Customize Pie Charts in Presentations Using C++
linktitle: Pie Chart
type: docs
url: /cpp/pie-chart/
keywords:
- pie chart
- manage chart
- customize chart
- chart options
- chart settings
- plot options
- slice color
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Create and customize pie charts in C++ with Aspose.Slides. Configure secondary plots, display data labels, and apply automatic slice colors in PowerPoint."
---

## **Overview**

This article explains how to work with pie charts in Aspose.Slides. It shows how to configure secondary plot options for Pie of Pie and Bar of Pie charts, and how to enable automatic slice coloring for a standard pie chart.

The examples focus on chart customization tasks such as adding a chart to a slide, adjusting series and label settings, replacing default chart data with custom categories and values, and saving the updated presentation.

## **Second Plot Options for Pie of Pie and Bar of Pie Charts**

Aspose.Slides for C++ supports secondary plot options for Pie of Pie and Bar of Pie charts. These options control the size of the secondary plot and how data points are split between the two plots.

The following example creates a Pie of Pie chart in a new presentation and displays data point values as labels. The [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) method sets the secondary plot size to 149% of the main plot. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) selects percentage-based splitting, and [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) sets the threshold to 53%.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

To show or hide the lines connecting the main and secondary plots in Pie of Pie and Bar of Pie charts, see [Show or Hide Series Lines](/slides/cpp/chart-series/#show-or-hide-series-lines). The setting applies to the entire series group.

### **Select Categories for the Secondary Plot**

Use custom splitting when you want to group specific categories in the secondary plot regardless of their percentage values. For example, a sales report might show Online and Events together so readers can compare these two channels, even though they account for 35% and 10% of total sales.

Call [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) with [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) and select the points through [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). The collection's [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) method accepts a zero-based index in the series. In this example, index 1 selects Online, and index 3 selects Events. Partners is also added temporarily, then excluded using [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Replace the default data with sales by channel.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Select Online and Events by their zero-based indexes in the series.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Exclude Partners from the selection without deleting its source data.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) and Events (10) appear as separate slices in the secondary plot. In the primary plot, they are represented by one combined slice with a value of 45, alongside Retail (40) and Partners (15). Removing Partners from the custom selection keeps it in the primary plot; it does not remove the category or its value from the chart's source data.

The following image shows the saved presentation in PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Set Automatic Pie Chart Slice Colors**

Aspose.Slides for C++ can automatically assign different colors to pie chart slices. The following example creates a pie chart with a centered title and replaces the default data with three quarterly categories and their values. The [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) method displays the values 20, 50, and 30 as labels, while [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) enables a distinct color for each slice.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Add a centered chart title.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Replace the default data using the first worksheet.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Show values and assign different colors to the slices.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Are the Pie of Pie and Bar of Pie variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) a secondary plot for pie charts, including the Pie of Pie and Bar of Pie types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (such as PNG) without exporting the entire presentation.
