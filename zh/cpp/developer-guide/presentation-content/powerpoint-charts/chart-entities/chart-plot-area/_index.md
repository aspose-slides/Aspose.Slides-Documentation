---
title: 自定义 C++ 演示文稿图表的绘图区域
linktitle: 绘图区域
type: docs
url: /zh/cpp/chart-plot-area/
keywords:
- 图表
- 绘图区域
- 绘图区域宽度
- 绘图区域高度
- 绘图区域大小
- 布局模式
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 自定义 PowerPoint 演示文稿中的图表绘图区域。轻松提升幻灯片视觉效果。"
---

## **获取图表绘图区域的宽度和高度**
Aspose.Slides for C++ 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加默认数据的图表。
1. 在获取实际值之前调用 IChart::ValidateChartLayout() 方法。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 保存包含图表的演示文稿
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **设置图表绘图区域的布局模式**
Aspose.Slides for C++ 提供了一个简单的 API 来设置图表绘图区域的布局模式。已在 **ChartPlotArea** 和 **IChartPlotArea** 类中添加了属性 **LayoutTargetType**。如果绘图区域的布局是手动定义的，则此属性指定是按照内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）来布局绘图区域。该 **LayoutTargetType** 枚举中定义了两种可能的值。

- **LayoutTargetType.Inner** - 指定绘图区域的大小应决定绘图区域的尺寸，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区域的大小应决定绘图区域的尺寸，包括刻度线和坐标轴标签。

下面给出示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **常见问题**

**ActualX、ActualY、ActualWidth 和 ActualHeight 以什么单位返回？**

以点为单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区域在内容上与图表区域有何区别？**

绘图区域是数据绘制区域（系列、网格线、趋势线等）；图表区域包括周围的元素（标题、图例等）。在 3D 图表中，绘图区域还包括墙面/底面和坐标轴。

**当布局为手动时，绘图区域的 X、Y、宽度和高度如何解释？**

它们是图表整体尺寸的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例。

**添加/移动图例后，为什么绘图区域的位置会改变？**

图例位于图表区域的绘图区域之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区域可能会移动。（这是 PowerPoint 图表的标准行为。）