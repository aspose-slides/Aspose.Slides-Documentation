---
title: 使用 C++ 在演示文稿中自定义图表图例
linktitle: 图例
type: docs
url: /zh/cpp/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自定义图表图例，以针对性地格式化图例来优化 PowerPoint 演示文稿。"
---
## **概述**

Aspose.Slides for C++ 提供了在 PowerPoint 演示文稿中自定义图表图例的选项。本文展示了如何定位和调整图例大小、设置整个图例的字体大小、格式化单个图例条目以及隐藏或恢复选定的条目。

常见问题解答涵盖了相关行为，包括为图例预留空间、显示多行标签以及从演示文稿主题继承格式。

## **图例定位**

使用图例的[set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/)、[set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/)、[set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/)和[set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/)方法来指定其相对于图表尺寸的位置信息和大小（以比例表示）。

此示例创建一个演示文稿，并在第一张幻灯片上添加一个带有默认数据的簇状柱形图。将期望的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角偏移 50 磅，大小为 100×100 磅。

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

// 表示图例相对于图表的位置和大小。
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **设置图例的字体大小**

使用图例的[get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) 来访问其文本格式，并使用[set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) 设置字体大小（单位为磅）。

此示例创建一个带有默认数据的图表，并将图例文本的字体大小设置为 20 磅。此外，它还禁用了垂直轴的自动范围，并将范围设置为 -5 到 10。

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

## **设置单个图例条目的字体大小**

使用图例的[get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) 方法返回的集合来访问特定条目的格式。条目索引从零开始，所以索引 `1` 对应第二个条目。

此示例创建一个默认数据至少包含两个系列的簇状柱形图。它将第二个图例条目设置为粗体、斜体、20 磅的蓝色文本。

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

## **隐藏单个图例条目**

若要在保持数据可见的情况下将辅助系列从图例中排除，请通过[IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) 调用[ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) 并传入 `true`。这仅隐藏选中的图例条目，不会移除系列或其数据点。相反，调用[IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) 并传入 `false` 会隐藏整个图例。

下面的示例使用默认数据创建一个包含多个系列的簇状柱形图。它隐藏第二个系列的图例条目（索引 `1`）并保存演示文稿。随后通过将 `set_Hide` 设为 `false` 恢复该条目并保存第二份副本。两份文件中的柱形均保持可见。

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

// 恢复相同的条目而不更改图表数据。
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

下面的对比展示了同一图表在所有条目可见以及第二条目隐藏两种情况。第二个系列的柱形保持不变。

![比较显示所有图例条目可见以及第二系列从图例中隐藏的图表；所有柱形均保持可见。](hide-legend-entry.png)

在柱形图、条形图和折线图中，图例条目对应系列。对于饼图，图例条目对应单个数据点（切片），因此应对选中的切片使用[IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/)。API 对 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 和 `BarOfPie` 类型记录了此数据点方法。请勿认为它适用于环形图，因为环形图不在此列表中。

## **常见问题**

**我可以让图表为图例预留空间而不是覆盖它吗？**

可以。调用[set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) 并传入 `false`，即可为图例预留空间，而不是让其覆盖绘图区域。

**我可以创建多行图例标签吗？**

可以。当可用宽度不足时，长标签会自动换行。您也可以在系列名称中使用换行符来强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

保持图例的颜色、填充和字体未设置，让其继承主题格式。显式的格式设置会覆盖相应的主题设置。