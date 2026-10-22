---
title: 使用 C++ 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/cpp/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- 图表缓存
- 工作簿恢复
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "发现 Aspose.Slides for C++：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化您的演示文稿数据。"
---
## **概述**

本文解释了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据，使用工作簿单元格作为图表数据标签，访问工作表集合，以及为图表值指定数据源类型。

它还涵盖了使用外部工作簿作为图表数据源的情况。示例演示了如何创建和分配外部工作簿，检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/cpp/chart-series/)了解空单元格与零的区别，以及可用显示模式的折线图对比。

## **包含隐藏行和列的数据**

使用[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/)来控制图表是否绘制隐藏工作表行和列中的数据。将其设置为 `true` 只绘制可见单元格，设置为 `false` 则包括可见和隐藏的单元格。此设置仅控制图表绘制，不会隐藏或显示工作表的行或列。

[示例演示文稿](hidden-source-data.pptx) 包含一个柱形图，位于其第一张幻灯片的第一个形状。嵌入的工作表 `Sheet1` 包含以下来源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)访问源单元格，并读取[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/)以检查它们的隐藏状态。此属性为只读。在此文件中，B2 可见，B3 位于隐藏行，C2 位于隐藏列；示例分别输出 `False`、`True` 和 `True`。

对于本例，在更改绘图设置后刷新图表数据：使用[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)保留嵌入的工作簿，然后使用[WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)重新加载。包含所有单元格时，还要使用[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // 从嵌入的工作簿刷新图表数据。
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 恢复完整的源范围，包括隐藏的类别。
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

示例保存了该演示文稿的两个版本：一个仅包含可见的零售值（10 和 20），另一个包含所有六个值。下图展示了两种绘图模式。第 3 行和 C 列在两个嵌入的工作簿中仍保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含值的隐藏单元格不同于空单元格。[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) 控制缺失值的显示方式；它并不包含或排除隐藏的源数据。参见[控制空单元格的显示](/slides/zh/cpp/chart-series/#control-the-display-of-empty-cells)示例。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，先检查源范围以确定每个图表使用的工作表单元格。[IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) 方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中，`Sheet1` 是工作表名称，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识从 A1 到 D5（含）的单元格。美元符号表示绝对的行列引用。

此方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，它会抛出 [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/)。更多信息请参见[ChartData API 参考](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)。

此示例打开一个演示文稿并直接检查每张幻灯片上的形状以寻找图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，它会打印一条消息并继续检查下一个图表。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **从工作簿读取和写入图表数据**

Aspose.Slides for C++ 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允许读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同方式组织或具有类似于源的结构。

此示例使用一个在第一张幻灯片的第一个形状中包含图表的演示文稿。它将嵌入的工作簿读取到流中，清除现有的系列和类别，然后将相同的工作簿写回。更改仅保存在内存中；示例并未保存演示文稿。

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **在工作簿修改后验证图表布局**

当您使用修改后的工作簿替换嵌入的工作簿时，图表仍保留其原始的系列和类别集合。此不匹配可能导致[IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) 因索引超出范围而失败。在将更新的工作簿写回图表之前，请先清除现有的系列和类别。此示例使用第一张幻灯片的第一个形状中的图表。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // 在此处修改工作簿流，例如，使用 Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

在写回工作簿之前清除集合可移除过时的数据引用。在使用图表之前，为更新的工作簿重新构建所需的系列和类别映射。

## **为工作簿单元格设置自定义数字格式**

使用[IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/)来控制数值在图表嵌入工作簿中的显示方式。例如，报告可能需要将转换率显示为保留四位小数的百分比，将系数显示为保留五位小数的数值。保持这两个值为数值类型，以便它们仍可用于计算和图表绘制。

数字格式仅改变显示方式，不改变存储的值。格式 `0.0000%` 将 `0.125` 显示为 `12.5000%`；它并未将存储的数字替换为 `12.5`。同样，`0.00000` 将 `0.1234567` 显示为 `0.12346`，但不对存储的值进行四舍五入。如果自定义格式为空字符串（`""`），则使用通过[set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/)分配的格式。

下面的示例创建一个柱形图，并通过[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)访问其单元格。在工作表 0 中，B2 包含转换率，C2 包含系数。两个单元格都提供图表数值。示例还启用了链接到来源格式的数值标签。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

工作簿单元格格式与直接在图表坐标轴或数据标签上设置的格式是分开的。在本例中，每个标签显示其来源单元格的值，因为 [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) 使用 `true` 调用，并且因为 [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) 使用 `true` 调用，标签遵循来源的数字格式。保存并重新打开演示文稿后，标签显示 `12.5000%` 和 `0.12346`，如下所示。垂直坐标轴使用通过 [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) 分配的 `0.00` 格式，且 [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) 使用 `false` 调用。

若要独立格式化数据标签，请将其来源链接标志设为 `false` 并通过 [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) 分配格式。这不会更改工作簿单元格的格式。例如，独立标签格式 `0.00` 将第一个值显示为 `0.13`，而 B2 仍显示 `12.5000%`。请参阅[图表数据标签](/slides/zh/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels)了解直接标签格式化。

![柱形图，来源链接标签显示 12.5000% 和 0.12346，坐标轴独立格式化为数值。](custom-cell-formats.png)

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。

此示例在现有演示文稿的第一张幻灯片上添加一个带默认数据的气泡图。它在工作表 0 上使用单元格 A10:A12 作为第一系列的前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **管理工作表**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) 方法提供对图表工作簿中工作表的访问。本示例创建一个带默认数据的饼图，并在控制台打印每个工作表的名称。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **指定数据源类型**

系列点值也可以直接存储为数值文字。请参阅[使用数值文字设置系列值](/slides/zh/cpp/chart-series/#set-series-values-using-numeric-literals)获取完整的保存和读取示例。点值的源类型与图表的内部或外部工作簿配置分离；使用数值文字本身并不会删除嵌入的工作簿。

此示例创建一个带默认数据的 3D 柱形图，并使用不同的数据源设置两个系列名称。第一个名称使用字符串文字；第二个使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) 枚举用于为每个名称选择源。示例保存了包含更新系列名称的演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **检测不受支持的嵌入工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) 上使用 [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) 方法并结合 [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。此示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个嵌入 .xlsb 工作簿的图表打印诊断信息。

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // 在此读取或修改受支持的图表工作簿数据。
}
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)和[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)将嵌入的图表工作簿导出为文件并将图表链接到该外部工作簿。

此示例创建一个带默认数据的饼图并导出其工作簿。在将外部工作簿分配为图表数据源之前，先关闭输出流，然后保存已链接的演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **设置外部工作簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供外部工作簿的相对路径，它会自动转换为完整路径。

此示例使用一个外部工作簿，其工作表 `Sheet1` 在 B1 中包含系列名称，在 A2:A4 中包含类别名称，在 B2:B4 中包含数值。示例创建一个饼图，链接工作簿，并使用[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)将 A1:B4 映射为一个系列和三个类别。它保存了带有链接图表的演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不存在。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例分配了一个占位符 URL，并将 `updateChartData` 设置为 `false`。它保留饼图的默认数据，并在未加载不可用工作簿的情况下保存演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **获取图表的外部数据源工作簿路径**

要确定链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

此示例检查一个带有链接外部工作簿的演示文稿第一张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例将把[get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) 打印到控制台。随后保存演示文稿的副本。

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **编辑图表数据**

您可以像修改内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

此示例使用第一张幻灯片的第一个形状中的图表，该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设置为 100 并保存更新后的演示文稿。编辑单元格值会更新链接的外部 XLSX 文件，因此如果需要保留原始工作簿，请使用副本。

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)，使用 [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) 进行配置，并在打开演示文稿前以 `true` 调用 [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/)。

以下 C++ 示例恢复了第一张幻灯片的第一个形状的图表的工作簿数据，该图表引用了不可用的外部工作簿。它通过[IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) 和 [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) 访问恢复的数据：

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // 在此读取或修改恢复的工作簿数据。
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出 [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/)。仅在使用缓存的图表数据作为可接受的后备方案时才启用恢复，因为缓存可能不包含演示文稿上次更新后对外部工作簿所做的更改。

## **常见问题**

**我能判断特定图表是链接到外部工作簿还是嵌入工作簿吗？**

是的。图表具有[数据源类型](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)和[外部工作簿路径](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径，且它们是如何存储的？**

是的。如果指定相对路径，它会自动转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我能使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可以用作外部数据源。但是，Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为数据源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

演示文稿存储[指向外部文件的链接](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)。编辑由单元格支持的图表数据也可能会更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护，我该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先解除保护或准备一个已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/cpp/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们都指向同一文件，更新该文件后，下次加载数据时会在每个图表中体现。