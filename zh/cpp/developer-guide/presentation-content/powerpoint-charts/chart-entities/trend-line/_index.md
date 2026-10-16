---
title: 在 C++ 中向演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/cpp/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "快速在 PowerPoint 图表中使用 Aspose.Slides for C++ 添加和自定义趋势线 — 实用指南，帮助您吸引受众。"
---
## **概述**

本文解释了如何使用 Aspose.Slides 向演示文稿图表添加趋势线。它展示了如何创建图表、向图表系列添加趋势线，以及如何使用多种趋势线类型，包括指数、线性、对数、移动平均、多项式和幂。

它还描述了如何通过插入线形状向图表添加自定义线，并提供了一个简短的 FAQ，说明趋势线的前向和后向投影值的含义，以及在导出为 PDF 或 SVG 或将图表渲染为图像时趋势线是否会被保留。

## **添加趋势线**

使用 [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) 向图表系列添加趋势线，并使用 [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) 选择其类型。示例创建了一个带有默认数据的簇状柱形图，并为其三个系列中的每个系列添加了两条趋势线。

指数趋势线通过 [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) 和 [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) 隐藏其方程式和 R 平方值，而线性趋势线为红色。对数趋势线使用 [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) 添加自定义标签。移动平均使用 [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) 将三个数据点求平均，并使用 [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) 设置自定义名称。

多项式趋势线使用 [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) 将其次数设为三，并通过 [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/) 向前延伸一个类别。幂趋势线通过 [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/) 向后延伸一个类别。

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **设置趋势线截距**

使用 [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) 将趋势线在 X = 0 时的 Y 值固定。此设置支持线性、指数和多项式趋势线。

例如，生产成本模型可能需要在已知的固定成本 100 处开始，即使在非零生产量的测量数据暗示不同的基线。对于线性趋势线，将截距固定会将方程 `y = ax + b` 约束为 `b = 100`；斜率在该约束下拟合数据。这并不是简单地移动已拟合的直线。轴交叉设置决定图表坐标轴的交点位置，而不是已拟合趋势线的系数。

下面的示例创建了一个散点 (XY) 图表，生产量为 1 到 4，成本分别为 170、200、230 和 260。它先使用默认自动截距保存图表，然后将截距设为 100 再保存为第二个 PPTX。两个文件唯一的区别在于截距设置。趋势线显示其方程式并向后延伸至 X = 0。

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

在自动计算情况下，这些数据得到 `y = 30x + 140`。将截距设为 100 时得到约 `y = 43.33x + 100`：零点的拟合值与已知基线相匹配，但线条不再经过所有数据点。

| 自动截距 | 固定截距为 100 |
| --- | --- |
| ![线性趋势线，自动计算的截距为 140](intercept-automatic.png) | ![线性趋势线，固定截距为 100](intercept-fixed.png) |

两张图片使用相同的数据和坐标轴比例。趋势线向后延伸至 X = 0，以显示其截距。

默认情况下，该属性包含 `std::numeric_limits<double>::quiet_NaN()`，表示截距未指定而非零。随后截距会根据数据自动计算。

## **添加自定义线**

自定义线是一种在图表上方绘制的形状，而不是从系列数据计算得到的趋势线。此示例使用 [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) 向包含图表的幻灯片添加一条水平线。该线的位置以幻灯片坐标（点）指定，因此从图表的左边缘开始，位于图表中部的高度。其宽度与图表宽度相同。通过 [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) 返回的线条格式为该线设置了实心红色。

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**“前向”和“后向”在趋势线中是什么意思？**

它们指的是趋势线向前/向后投影的长度：对于散点 (XY) 图表，以坐标轴单位表示；对于非散点图表，以类别数量表示。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

会。Aspose.Slides 可将演示文稿转换为 [PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了将图表本身导出为图像的 [export an image of the chart](/slides/zh/cpp/shape-thumbnails/) 方法。