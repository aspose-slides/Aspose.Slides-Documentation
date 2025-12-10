---
title: 使用 C++ 在演示文稿中自定义图表轴
linktitle: 图表轴
type: docs
url: /zh/cpp/chart-axis/
keywords:
- 图表轴
- 垂直轴
- 水平轴
- 自定义轴
- 操作轴
- 管理轴
- 轴属性
- 最大值
- 最小值
- 轴线
- 日期格式
- 轴标题
- 轴位置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中自定义图表轴，以用于报告和可视化。"
---

## **获取垂直轴的最大值**
Aspose.Slides for C++ 允许您获取垂直轴的最小值和最大值。请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 获取轴上的实际最大值。
1. 获取轴上的实际最小值。
1. 获取轴的实际主单位。
1. 获取轴的实际次单位。
1. 获取轴的实际主单位比例。
1. 获取轴的实际次单位比例。

以下示例代码——上述步骤的实现——演示了如何在 C++ 中获取所需的值：
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


## **在轴之间交换数据**
Aspose.Slides 允许您快速交换轴之间的数据——垂直轴（y 轴）上的数据会移动到水平轴（x 轴），反之亦然。

以下 C++ 代码展示了如何在图表上执行轴之间的数据交换任务：
``` cpp
// 创建空白演示文稿
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// 交换行和列
chart->get_ChartData()->SwitchRowColumn();

// 保存演示文稿
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```


## **禁用折线图的垂直轴**

以下 C++ 代码展示了如何隐藏折线图的垂直轴：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **禁用折线图的水平轴**

以下代码展示了如何隐藏折线图的水平轴：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **更改分类轴**

使用 **set_CategoryAxisType()** 方法，您可以指定首选的分类轴类型（**date** 或 **text**）。以下 C++ 代码演示了该操作：
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


## **设置分类轴值的日期格式**
Aspose.Slides for C++ 允许您为分类轴值设置日期格式。以下 C++ 代码演示了该操作：
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


## **设置轴标题的旋转角度**
Aspose.Slides for C++ 允许您为图表轴标题设置旋转角度。以下 C++ 代码演示了该操作：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **设置分类轴或数值轴上的轴位置**
Aspose.Slides for C++ 允许您在分类轴或数值轴上设置轴的位置。以下 C++ 代码展示了如何执行此任务：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```


## **在图表数值轴上启用显示单位标签**
Aspose.Slides for C++ 允许您配置图表在其数值轴上显示单位标签。以下 C++ 代码演示了该操作：
``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **常见问题**

**如何设置一个轴交叉另一个轴的值（轴交叉）？**
轴提供了一个 [crossing setting](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/)：您可以选择在零、最大分类/数值或特定数值处交叉。这对于上下移动 X 轴或强调基线非常有用。

**如何相对于轴定位刻度标签（旁边、外部、内部）？**
将 [label position](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) 设置为 “cross”、 “outside” 或 “inside”。这会影响可读性，并有助于节省空间，尤其是在小型图表上。