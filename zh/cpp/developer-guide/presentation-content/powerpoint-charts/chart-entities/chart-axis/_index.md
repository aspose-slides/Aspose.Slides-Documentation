---
title: 使用 C++ 在演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/cpp/chart-axis/
keywords:
- 图表坐标轴
- 垂直坐标轴
- 水平坐标轴
- 自定义坐标轴
- 操作坐标轴
- 管理坐标轴
- 坐标轴属性
- 最大值
- 最小值
- 坐标轴线
- 日期格式
- 坐标轴标题
- 坐标轴位置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文解释了如何使用 Aspose.Slides for C++ 自定义图表坐标轴。内容包括计算坐标轴值、交换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、坐标轴位置、显示单位以及对数刻度。

## **获取图表纵坐标轴的最大值**

创建一个[演示文稿](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)并添加一个带默认数据的面积图。读取计算坐标轴值之前先调用[ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/)以确保图表布局是最新的。

读取[get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/)和[get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/)获取坐标轴上下限，读取[get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/)和[get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/)获取刻度间隔。[get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/)和[get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/)提供时间单位比例，适用于日期坐标轴。示例将这些值存入局部变量并保存图表。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **交换坐标轴之间的数据**

使用[SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/)交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式，但不会交换水平和垂直坐标轴。示例使用[SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/)将默认数据绑定到`Sheet1!A1:D5`（包括标题行和类别列），然后交换行列。它保存了一个包含四个系列和三个类别的图表。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **禁用折线图的纵坐标轴**

对纵坐标轴调用[set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)并传入`false`以隐藏它。示例创建一个带默认数据的折线图并保存为隐藏纵坐标轴的文件。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **禁用折线图的横坐标轴**

对横坐标轴调用[set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/)并传入`false`以隐藏它。示例创建一个带默认数据的折线图并保存为隐藏横坐标轴的文件。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **更改类别坐标轴**

使用[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)选择日期或文本类别坐标轴。此示例需要`ExistingChart.pptx`，其中第一张幻灯片的第一形状为图表，类别单元格包含 Excel 数字日期值。它将水平坐标轴改为日期坐标轴。调用[set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/)并设为`false`，随后调用[set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/)设为`1`，并使用[set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/)设为月份，以在每月间隔处放置主刻度。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **控制类别坐标轴标签间隔**

当图表拥有大量类别时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。将[set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/)设为`false`，随后使用[set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/)设置所需的类别间隔。对于文本类别的正常顺序，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1, 类别 2, 类别 3, ... 类别 24 |
| `2` | 类别 1, 类别 3, 类别 5, ... 类别 23 |
| `3` | 类别 1, 类别 4, 类别 7, ... 类别 22 |

间隔为`3`时每三个标签显示一次，之间的两个标签被隐藏。它并不删除对应的列。自动间隔会根据可用空间自动选择间隔，并不一定显示每个标签。

刻度线有独立的控制方式。将[set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/)设为`false`，并使用[set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/)设置其间隔。例如，`1` 在每个类别间隔处保留刻度线，而标签仅每三个类别显示一次。使用[set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/)设为可见样式以便观察结果。将任一自动间隔属性重新设为`true`即可让图表重新自动选择间隔。

下面的独立示例创建 24 个类别和一个系列，然后在`CategoryAxisIntervals.pptx`中保存三张幻灯片：自动间隔、手动标签间隔且刻度线独立，以及恢复自动间隔。两份复制保持原始图表数据。无需输入演示文稿。横向标签文字使密度差异一目了然。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// 第 2 张幻灯片：显示每三个标签，但为每个类别保留刻度线。
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// 第 3 张幻灯片：让图表再次选择两个间隔。
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**自动间隔（第 1 张幻灯片）：** 在此渲染中，每隔一个类别标签会显示一次，并换行为两行。自动结果会随图表大小、字体和渲染器的不同而变化。

![自动类别标签间距（显示所有24列）](category-axis-automatic.png)

**手动间隔（第 2 张幻灯片）：** 每三个标签显示在同一行，而刻度线仍保持在每个类别间隔。所有 24 列（包括未显示标签的列）均保持可见且数值相同。第 3 张幻灯片恢复了上图的自动外观。

![手动类别标签间隔为三且显示所有24列](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

在文本类别坐标轴（如柱形图、折线图、面积图或条形图的类别坐标轴）上使用此类别计数间隔。柱形图中它是水平坐标轴，水平条形图中类别坐标轴为垂直坐标轴，因此需对[get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)应用这些设置。刻度间隔同样适用于具有系列坐标轴的图表。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/)指定值的差异，例如 `10` 的主单位会在 0、10、20 等位置生成刻度。类别标签间隔 `3` 则仅计数类别位置，而不考虑其数值。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请参考[更改类别坐标轴](#change-a-category-axis)中描述的基于时间的主单位和比例。

## **为类别坐标轴值设置日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引`0`）中。使用[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/)选择日期坐标轴，使用[set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/)关闭源链接的数字格式，并用[set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/)设置`yyyy`，使类别标签独立于单元格格式而显示四位数年份。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **为图表坐标轴标题设置旋转角度**

使用[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/)启用纵坐标轴标题，提供标题文本，然后使用[set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/)旋转标题。角度以度为单位；本示例将值坐标轴标题旋转 90 度后保存柱形图。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **在类别坐标轴或数值坐标轴上设置坐标轴位置**

使用[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/)控制数值坐标轴是跨越类别之间还是在类别刻度线上与类别坐标轴相交。该属性适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为`true`并保存结果。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **为数值坐标轴设置显示单位**

使用[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/)在不更改底层数据的前提下缩放数值坐标轴标签。将[DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/)设为`Millions`后，60000000 将显示为 60。示例创建柱形图并将其纵坐标轴的显示单位设为“百万”。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **配置对数数值坐标轴**

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，某服务在五个时期的请求量可能为 10、100、1 000、10 000、100 000。在线性刻度下，较小的值会聚集在接近零的位置。对数刻度将等距的距离表示相等的比例，而非相等的差值。

在数值坐标轴上调用[set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/)并设为`true`，再使用[set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/)选择底数。这会改变已有数值的显示方式，但不会修改数据或添加对数趋势线。趋势线是对数据进行拟合的独立功能。

### **选择数值坐标轴和底数**

对于折线图或柱形图，数值坐标轴为[get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)。对于水平条形图，则为[get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/)。散点图和气泡图拥有两个数值坐标轴，可分别对 X 轴（水平）和 Y 轴（垂直）或同时设置。不要对类别坐标轴使用对数刻度。

默认的对数底数为`10`。对于 PPTX 图表，底数可在 `2` 到 `1000`（含）之间；同样支持如 `2.5` 的小数底数。底数为`10`时，10、100、1 000、10 000 等幂次等间距分布。

### **对比线性和对数刻度**

下面的独立示例在第一张幻灯片上创建包含五个请求计数的折线图，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值坐标轴。两张幻灯片保持相同数据。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// 保留第一张幻灯片为线性，仅更改复制的数值轴比例。
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**线性刻度（第 1 张幻灯片）：** 等距的垂直距离代表请求计数的相等差值。最大值主导图表，较小的值难以辨认。

![PowerPoint 中显示五个请求计数的折线图（线性数值坐标轴）](value-axis-linear.png)

**对数刻度（第 2 张幻灯片）：** 等距的垂直距离代表相等的比例。每个时期的请求量是前一个的十倍，因此在以 10 为底的对数刻度上形成一条直线上升线。坐标轴标签仍显示原始请求计数。

![PowerPoint 中显示相同五个请求计数的折线图（基数为 10 的对数数值坐标轴）](value-axis-logarithmic.png)

### **处理零值和负值**

对数刻度只能显示严格正值。启用前请检查数据。如果零或负值具有意义，请保留线性刻度或单独展示这些点。如果在分析中可以排除这些值，请说明原因。切勿悄悄将其替换为小的正数，因为这会改变数据含义。对数坐标轴的手动最小值或最大值也必须为正。

## **FAQ**

**如何设置一个轴交叉另一轴的数值（轴交叉）？**

使用[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)选择交叉行为。若要指定数值交叉点，使用[set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/)。这些设置可将轴交叉移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**

使用[set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/)并从[TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/)中选择 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用[set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/)或[set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/)，它们与标签位置独立。