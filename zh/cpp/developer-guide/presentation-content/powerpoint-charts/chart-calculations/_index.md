---
title: 优化 C++ 中演示文稿的图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/cpp/chart-calculations/
keywords:
- 图表计算
- 图表元素
- 元素位置
- 实际位置
- 子元素
- 父元素
- 图表值
- 实际值
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解在 Aspose.Slides for C++ 中的图表计算、数据更新和精度控制，适用于 PPT 和 PPTX，并提供实用的 C++ 代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for C++ 提供了一个简洁的 API 来获取这些属性。这将帮助您计算图表元素的实际值。实际值包括实现 IActualLayout 接口的元素的位置 (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight())以及实际坐标轴值 (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale())。
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 保存演示文稿
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **计算父图表元素的实际位置**
Aspose.Slides for C++ 提供了一个简洁的 API 来获取这些属性。IActualLayout 的方法提供了父图表元素的实际位置信息。需要先调用 IChart::ValidateChartLayout() 方法以用实际值填充这些属性。
``` cpp
// 创建空演示文稿
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```


## **隐藏图表元素**
本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for C++，您可以隐藏图表的 **标题、垂直坐标轴、水平坐标轴** 和 **网格线**。下面的代码示例展示了如何使用这些属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **为图表设置数据范围**
Aspose.Slides for C++ 提供了最简便的 API 来设置图表的数据范围。设置图表的数据范围的步骤如下：

- 打开包含图表的 Presentation 类实例。
- 使用索引获取幻灯片的引用。
- 遍历所有形状以查找目标图表。
- 访问图表数据并设置范围。
- 将修改后的演示文稿另存为 PPTX 文件。

下面的代码示例展示了如何更新图表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **常见问题**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿获取，图表将在打开/编辑操作期间反映更新。该 API 允许您[指定外部工作簿](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)路径并管理链接的数据。

**我可以在不自行实现回归的情况下计算并显示趋势线吗？**

是的。[趋势线](/slides/zh/cpp/trend-line/)（线性、指数等）由 Aspose.Slides 添加并自动更新；其参数会根据系列数据自动重新计算，因此您无需自行实现计算。

**如果一个演示文稿有多个带外部链接的图表，我可以控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表都可以指向其自己的[外部工作簿](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)，或者您可以为每个图表独立创建/替换外部工作簿，而不受其他图表影响。