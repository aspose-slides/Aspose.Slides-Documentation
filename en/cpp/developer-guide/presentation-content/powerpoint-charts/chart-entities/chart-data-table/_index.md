---
title: Customize Chart Data Tables in Presentations Using C++
linktitle: Data Table
type: docs
url: /cpp/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Customize chart data table fonts, borders, and legend keys in PowerPoint presentations using Aspose.Slides for C++."
---

## **Overview**

Aspose.Slides for C++ lets you display a chart's data table and customize its text formatting, borders, and legend keys. This article explains how to enable the table, format its text, control each type of border, and show or hide legend keys. The examples save the configured charts in PPTX files.

## **Set Font Properties**

To display a chart's data table, pass `true` to [IChart::set_HasDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Use [IChart::get_ChartDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdatatable/) to access the table and configure its text formatting.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Add a clustered column chart to the first slide.
1. Enable the chart's data table.
1. Enable bold text with [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontbold/) and pass `20` to [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) for 20-point text.
1. Save the modified presentation.

The following example requires `test.pptx` in the working directory with at least one slide. It adds a chart with default data at position (50, 50), with a width of 600 points and a height of 400 points. The saved `output.pptx` contains the chart with its data table enabled and the specified font settings applied.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Customize Data Table Borders**

Enable the table with [IChart::set_HasDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasdatatable/) and access it through [IChart::get_ChartDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdatatable/). You can control three types of borders independently:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) controls horizontal cell borders.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) controls vertical cell borders.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) controls the outer border of the table.

Pass `true` to each setter to display its borders or `false` to hide them. The following example creates a clustered column chart with default data, displays horizontal borders and the outer border, and hides vertical borders. It requires no input file. The chart's position and size are specified in points.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

The comparison below uses the same chart data and legend key setting in all four cases. Starting with all borders enabled, each remaining variant disables just one border setting. The lower-left variant matches the border settings in the example.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Show or Hide Legend Keys**

Legend keys are small colored markers beside the series names in the data table. They help readers match each table row to a chart series. Pass `true` to [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) to show these markers or `false` to hide them.

The chart's separate legend is controlled by [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/). These settings are independent: hiding the separate legend does not hide the keys inside the data table, and hiding the table's keys does not hide the separate legend.

The following example creates a chart with default data, enables its data table, and shows legend keys inside it while hiding the separate legend. All table borders are explicitly enabled. No input presentation is required. To hide only the table's keys, pass `false` to [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

The comparison below shows the same table with legend keys enabled and disabled. All borders remain enabled, and the separate chart legend is hidden in both cases.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Can I show legend keys in a chart's data table?**

Yes. Pass `true` to [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) to display legend keys or `false` to hide them.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart and its displayed data table as part of the slide when exporting to [PDF](/slides/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/cpp/convert-powerpoint-to-html/), or [images](/slides/cpp/convert-powerpoint-to-png/).

**Can I work with data tables in charts loaded from a template?**

Yes. For a chart loaded from an existing presentation or template, use [IChart::get_HasDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_hasdatatable/) to check whether its data table is displayed and [IChart::set_HasDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_hasdatatable/) to change its visibility.

**How can I find charts that have a data table enabled?**

Iterate through the shapes on each slide, identify the charts, and check their [IChart::get_HasDataTable](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_hasdatatable/) result. A value of `true` indicates that the data table is enabled.
