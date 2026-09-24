---
title: 使用 C++ 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/cpp/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for C++ 允许您显示图表的数据表并自定义其文本格式、边框和图例键。本文说明如何启用表格、格式化其文本、控制每种边框以及显示或隐藏图例键。示例将配置好的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，请将 `true` 传递给 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/set_hasdatatable/)。使用 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/get_chartdatatable/) 访问表格并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载演示文稿。  
2. 在第一张幻灯片上添加一个簇状柱形图。  
3. 启用图表的数据表。  
4. 使用 [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_fontbold/) 启用粗体文本，并将 `20` 传递给 [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 以使用 20 磅的文字。  
5. 保存修改后的演示文稿。

以下示例要求工作目录中有 `test.pptx`，且该文件至少包含一张幻灯片。它在位置 (50, 50) 添加一个默认数据的图表，宽度为 600 点，高度为 400 点。保存的 `output.pptx` 包含已启用数据表并应用了指定字体设置的图表。

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

## **自定义数据表边框**

通过 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/set_hasdatatable/) 启用表格，并通过 [IChart::get_ChartDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/get_chartdatatable/) 访问它。您可以独立控制三种边框：

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) 控制水平单元格边框。  
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) 控制垂直单元格边框。  
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) 控制表格的外边框。

将 `true` 传递给各个 setter 以显示对应边框，或传 `false` 以隐藏它们。以下示例创建一个默认数据的簇状柱形图，显示水平边框和外边框，隐藏垂直边框。它不需要输入文件。图表的位置和尺寸均以点为单位指定。

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

下面的比较使用相同的图表数据和图例键设置，展示四种情况。首先启用所有边框，然后每个变体仅禁用一种边框设置。左下角的变体对应示例中的边框设置。

![所有边框已启用、无水平边框、无垂直边框和无外边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记，帮助读者将每行对应到图表系列。将 `true` 传递给 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) 以显示这些标记，或传 `false` 以隐藏它们。

图表的独立图例由 [IChart::set_HasLegend](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/set_haslegend/) 控制。这些设置相互独立：隐藏独立图例不会隐藏数据表中的键，隐藏表格键也不会隐藏独立图例。

以下示例创建一个默认数据的图表，启用其数据表，并在表格内显示图例键，同时隐藏独立图例。所有表格边框均显式启用。无需输入演示文稿。若只想隐藏表格的键，请将 `false` 传递给 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_showlegendkey/)。

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

下面的比较展示了相同表格在图例键启用和禁用时的效果。所有边框保持启用，独立图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

可以。将 `true` 传递给 [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) 以显示图例键，或传 `false` 以隐藏它们。

**导出演示文稿为 PDF、HTML 或图像时，数据表会被保留吗？**

会。Aspose.Slides 在导出到 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/) 或 [图像](/slides/zh/cpp/convert-powerpoint-to-png/) 时，会将图表及其显示的数据表作为幻灯片的一部分进行渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从已有演示文稿或模板加载的图表，使用 [IChart::get_HasDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/get_hasdatatable/) 检查其数据表是否已显示，并使用 [IChart::set_HasDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/set_hasdatatable/) 更改其可见性。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别图表并检查其 [IChart::get_HasDataTable](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/get_hasdatatable/) 返回值。返回 `true` 表示该图表已启用数据表。