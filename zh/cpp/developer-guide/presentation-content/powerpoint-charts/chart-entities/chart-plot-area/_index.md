---
title: 图表绘图区
type: docs
url: /zh/cpp/chart-plot-area/
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for C++ 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用方法 IChart::ValidateChartLayout()。
1. 获取图表元素相对于图表左上角的实际 X 位置（左侧）。
1. 获取图表元素相对于图表左上角的实际顶部。
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

// 保存带有图表的演示文稿
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```


## **设置图表绘图区的布局模式**
Aspose.Slides for C++ 提供了一个简单的 API 来设置图表绘图区的布局模式。属性 **LayoutTargetType** 已被添加到 **ChartPlotArea** 和 **IChartPlotArea** 类中。如果绘图区的布局手动定义，则该属性指定是按其内部（不包括坐标轴和坐标轴标签）还是真正的外部（包括坐标轴和坐标轴标签）来布局绘图区。有两个可能的值在 **LayoutTargetType** 枚举中定义。

- **LayoutTargetType.Inner** - 指定绘图区的大小应决定绘图区的大小，不包括刻度线和坐标轴标签。
- **LayoutTargetType.Outer** - 指定绘图区的大小应决定绘图区的大小，包括刻度线和坐标轴标签。

示例代码如下。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}