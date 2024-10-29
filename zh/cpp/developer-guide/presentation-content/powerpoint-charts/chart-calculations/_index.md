---
title: 图表计算
type: docs
weight: 50
url: /zh/cpp/chart-calculations/
---

## **计算图表元素的实际值**
Aspose.Slides for C++ 提供了一个简单的 API 来获取这些属性。这将帮助您计算图表元素的实际值。实际值包括实现 IActualLayout 接口的元素的位置（IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()）和实际的轴值（IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()）。

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
Aspose.Slides for C++ 提供了一个简单的 API 来获取这些属性。IActualLayout 的方法提供有关父图表元素实际位置的信息。必须先调用方法 IChart::ValidateChartLayout()，以填充实际值的属性。

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

## **隐藏图表中的信息**
本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for C++，您可以从图表中隐藏 **标题、纵轴、横轴** 和 **网格线**。以下代码示例显示了如何使用这些属性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **为图表设置数据范围**
Aspose.Slides for C++ 提供了最简单的 API，以最简单的方式为图表设置数据范围。要为图表设置数据范围：

- 打开包含图表的 Presentation 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 遍历所有形状以找到所需的图表。
- 访问图表数据并设置范围。
- 将修改后的演示文稿保存为 PPTX 文件。

以下代码示例展示了如何更新图表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}