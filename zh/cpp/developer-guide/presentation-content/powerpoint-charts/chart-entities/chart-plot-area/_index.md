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
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中自定义图表绘图区域，轻松提升幻灯片视觉效果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中使用图表的绘图区域。它说明了通过验证图表布局然后读取其 X、Y、宽度和高度值来获取绘图区域的实际位置和大小。

它还演示了在手动设置布局时如何配置绘图区域的布局模式，使用 `LayoutTargetType` 来定义绘图区域是依据其内部区域还是包括坐标轴和轴标签的外部区域进行计算。

## **获取图表绘图区域的宽度和高度**
Aspose.Slides for C++ 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用 IChart::ValidateChartLayout() 方法。
1. 获取图表元素相对于图表左上角的实际 X 位置（左侧）。
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
Aspose.Slides for C++ 提供了一个简单的 API 来设置图表绘图区域的布局模式。属性 **LayoutTargetType** 已添加到 **ChartPlotArea** 和 **IChartPlotArea** 类中。如果手动定义绘图区域的布局，此属性指定是按内部（不包括坐标轴和轴标签）还是外部（包括坐标轴和轴标签）来布局绘图区域。**LayoutTargetType** 枚举中定义了两种可能的取值。

- **LayoutTargetType.Inner** - 指定绘图区域的尺寸应确定绘图区域的大小，不包括刻度线和轴标签。
- **LayoutTargetType.Outer** - 指定绘图区域的尺寸应确定绘图区域、刻度线以及轴标签的大小。

下面给出示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **常见问题**

**ActualX、ActualY、ActualWidth 和 ActualHeight 的返回单位是什么？**

使用点（points）单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区域在内容上与图表区域有何区别？**

绘图区域是数据绘制区域（系列、网格线、趋势线等）；图表区域则包括外围元素（标题、图例等）。在 3D 图表中，绘图区域还包括墙面/底面以及坐标轴。

**在手动布局时，绘图区域的 X、Y、宽度和高度如何解释？**

它们是相对于图表整体大小的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区域的位置会改变？**

图例位于图表区域的绘图区域外部，但会影响布局和可用空间，因此在自动定位生效时，绘图区域可能会移动。（这是 PowerPoint 图表的常规行为。）