---
title: Customize Chart Legends in Presentations Using C++
linktitle: Chart Legend
type: docs
url: /cpp/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for C++ to optimize PowerPoint presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides for C++ provides options for customizing chart legends in PowerPoint presentations. This article shows how to position and size a legend, set the font size for the whole legend, format an individual legend entry, and hide or restore selected entries.

The FAQ covers related behaviors, including reserving space for the legend, displaying multiline labels, and inheriting formatting from the presentation theme.

## **Legend Positioning**

Use the legend's [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), and [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) methods to specify its position and size as fractions of the chart's dimensions.

This example creates a presentation and adds a clustered column chart with default data to the first slide. Dividing the desired legend offsets and dimensions by the chart's width and height converts them to relative values: the legend is offset by 50 points from the chart's top-left corner and sized to 100 by 100 points.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Set the Font Size of a Legend**

Use the legend's [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) to access its text formatting and use [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) to set the font size in points.

This example creates a chart with default data and sets the legend text to 20 points. It also disables automatic bounds for the vertical axis and sets its range to -5 through 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Set the Font Size of an Individual Legend Entry**

Use the collection returned by the legend's [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) method to access formatting for a specific entry. Entry indices are zero-based, so index `1` refers to the second entry.

This example creates a clustered column chart whose default data includes at least two series. It formats the second legend entry with bold, italic, and 20-point blue text.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Hide Individual Legend Entries**

To exclude an auxiliary series from the legend while keeping its data visible, call [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) with `true` through [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). This hides only the selected legend entry; it does not remove the series or its data points. Calling [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) with `false`, in contrast, hides the entire legend.

The example below creates a clustered column chart with multiple series using default data. It hides the second series' legend entry (index `1`) and saves the presentation. It then restores the entry by calling `set_Hide` with `false` and saves a second copy. The columns remain visible in both files.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Restore the same entry without changing the chart data.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

The comparison below shows the same chart with all entries visible and with the second entry hidden. The second series' columns remain unchanged.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In column, bar, and line charts, legend entries identify series. For pie charts, they identify individual data points (slices), so use [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) on the selected slice instead. The API documents this data-point method for the `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, and `BarOfPie` chart types. Do not assume it applies to doughnut charts, which are not included in that list.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Call [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) with `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.
