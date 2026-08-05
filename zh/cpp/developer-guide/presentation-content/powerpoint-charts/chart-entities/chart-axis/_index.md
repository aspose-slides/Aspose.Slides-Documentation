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

本文介绍了如何在 Aspose.Slides 中自定义图表坐标轴。它展示了如何获取实际坐标轴数值、在坐标轴之间交换数据、在折线图中隐藏垂直或水平坐标轴、更改类目坐标轴类型、为类目坐标轴值设置日期格式、旋转坐标轴标题、设置坐标轴位置以及在值坐标轴上显示单位标签。

## **获取垂直坐标轴的最大值**
Aspose.Slides for C++ 允许您获取垂直坐标轴的最小值和最大值。按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
1. 访问第一张幻灯片。  
1. 添加一个带有默认数据的图表。  
1. 获取坐标轴上的实际最大值。  
1. 获取坐标轴上的实际最小值。  
1. 获取坐标轴的实际主单位。  
1. 获取坐标轴的实际次单位。  
1. 获取坐标轴的实际主单位比例。  
1. 获取坐标轴的实际次单位比例。  

下面的示例代码实现了上述步骤，演示了如何在 C++ 中获取所需的数值：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// 保存演示文稿
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **在坐标轴之间交换数据**
Aspose.Slides 允许您快速交换坐标轴之间的数据——垂直坐标轴（y 轴）上的数据会移动到水平坐标轴（x 轴），反之亦然。

下面的 C++ 代码演示了如何在图表的坐标轴之间执行数据交换：

``` cpp
// 创建空演示文稿
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// 切换行和列
chart->get_ChartData()->SwitchRowColumn();

// 保存演示文稿
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **在折线图中禁用垂直坐标轴**

下面的 C++ 代码演示了如何隐藏折线图的垂直坐标轴：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **在折线图中禁用水平坐标轴**

下面的代码演示了如何隐藏折线图的水平坐标轴：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **更改类目坐标轴**

使用 **set_CategoryAxisType()** 方法，您可以指定首选的类目坐标轴类型（**date** 或 **text**）。下面的 C++ 代码演示了该操作：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **为类目坐标轴值设置日期格式**
Aspose.Slides for C++ 允许您为类目坐标轴值设置日期格式。以下 C++ 代码演示了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **设置坐标轴标题的旋转角度**
Aspose.Slides for C++ 允许您为图表坐标轴标题设置旋转角度。以下 C++ 代码演示了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **在类目轴或值轴上设置坐标轴位置**
Aspose.Slides for C++ 允许您在类目轴或值轴上设置坐标轴位置。以下 C++ 代码展示了如何完成此任务：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **在图表值轴上启用显示单位标签**
Aspose.Slides for C++ 允许您配置图表在其值轴上显示单位标签。以下 C++ 代码演示了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **常见问题解答**

**如何设置一个坐标轴与另一个坐标轴相交的数值（坐标轴交叉）？**

坐标轴提供了一个[交叉设置](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/axis/set_crosstype/)：您可以选择在零点、在最大类目/值处或在特定数值处交叉。这对于将 X 轴向上或向下移动或强调基准线非常有用。

**如何相对于坐标轴定位刻度标签（旁边、外侧、内侧）？**

将[label position](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/axis/set_majortickmark/)设置为 "cross"、"outside" 或 "inside"。这会影响可读性，并有助于在小型图表上节省空间。