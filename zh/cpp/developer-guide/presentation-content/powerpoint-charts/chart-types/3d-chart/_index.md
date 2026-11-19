---
title: 使用 C++ 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/cpp/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中创建 3D 图表。通过 C++ 示例调整旋转、高度比例、图表深度以及系列之间的间距。"
---
## **概述**

Aspose.Slides for C++ 允许您通过 [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) 自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [演示文稿](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 并使用 [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用包含每个三个值的两个系列替换默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) 和 [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) 方法分别将图表的旋转设置为 40 度和 270 度。[set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) 将深度设置为宽度的 150%，而 [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) 则启用直角坐标轴而非透视。生成的演示文稿包含具有这些 3D 视图设置的填充图表。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **调整 3D 图表的高度比例**

使用 [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) 将 3D 图表的高度设置为其宽度的百分比。这会改变 3D 场景的比例，而不会调整幻灯片上图表对象的大小。

以下示例创建一个 [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 图表，使用默认数据：三系列和四类别。它保存三个演示文稿，分别使用 50%、100% 和 200% 的高度比例。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有三个文件中完全相同；仅高度百分比不同。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

以下图像来自等效的 .NET 示例，使用 Microsoft PowerPoint 导出，展示了相同的高度设置。较小的百分比产生更平坦的场景，而较大的百分比在相同图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度设置为宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设置为宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设置为宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | 3D 场景的高度，以其宽度的百分比表示。 |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | 幻灯片上图表对象的高度，单位为磅。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 3D 场景的深度，以其宽度的百分比表示。 |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |

高度设置影响 3D 柱形图和条形图，包括圆柱体、圆锥体和金字塔变体，以及 3D 折线图、面积图、饼图和表面图。上面的比较使用了已验证的 `Column3D` 类型。此设置不会更改 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 枚举的成员。有关其他图表外观设置，请参阅 [图表格式化](/slides/zh/cpp/chart-formatting/)。

## **调整系列之间的间距**

使用 [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) 控制 3D 图表中沿深度轴的数据系列之间的距离，表示为标记宽度的百分比。使用 **0 to 500**（包括 0 和 500）的值：`0` 移除间隙，较大的值会增加间距。在固定的图表深度下，增大间隙会使标记在深度轴上变得更细。

通过 [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) 访问该组。该设置适用于组中的每个系列，而不仅仅是用于访问它的系列。[IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) 返回父组的设置。

此设置影响 3D 柱形图和条形图，包括它们的圆柱体、圆锥体和金字塔变体，以及 3D 折线图和面积图。外观取决于系列是按深度、聚类还是堆叠排列。要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 枚举的 `ChartType::Column3D`。

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | 沿深度轴的系列间距，以标记宽度的百分比表示。 |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | 相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。 |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | 整体图表深度，以图表宽度的百分比表示。 |

以下自包含示例使用默认图表数据，包含三系列和四类别。它保存两个演示文稿，数据、旋转、间隙宽度和图表深度完全相同；仅间隙深度不同。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

以下图像来自等效的 .NET 示例，使用 Microsoft PowerPoint 导出，展示了相同的间隙深度设置。

| 间隙深度：0% | 间隙深度：500% |
| --- | --- |
| ![在深度轴上系列之间没有间隙的 3D 柱形图](gap_depth_0.png) | ![在深度轴上系列之间有 500% 间隙的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚类圆柱体图表中，第一系列从圆柱形条开始。示例在每次更改前后读取 [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) 和 [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/)。

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| 对第一系列的更改 | get_Type | get_Bar3DShape |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 调用 [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) 使用 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 调用 [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) 使用 `Box` | `ClusteredColumn3D` | `Box` |

将形状设为 `Box` 也会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型进行分支，请在更改形状后调用 `series->get_Type()`。在更改前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 对比显示第一系列从左到右分别为圆柱体、圆锥体和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。要获取精确且最新的列表，请在已安装版本的 API 参考中检查 [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 成员。

**我可以为报告或网页获取 3D 图表的光栅图像吗？**

是的。您可以使用 [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) 将图表导出为图像，或[渲染整个幻灯片](/slides/zh/cpp/convert-powerpoint-to-png/) 到 PNG 或 JPEG 等格式。当您需要栅格预览或想将图表嵌入文档、仪表板或网页而无需 PowerPoint 时，这很有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出到与目标显示或打印需求匹配的适当分辨率和尺寸。