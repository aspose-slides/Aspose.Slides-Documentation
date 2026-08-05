---
title: 使用 C++ 在演示文稿中管理图表数据系列
linktitle: 数据系列
type: docs
url: /zh/cpp/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 C++ 中使用实用代码示例和最佳实践管理 PowerPoint（PPT/PPTX）图表系列，以提升数据演示效果。"
---
## **概述**

本文档描述了 Aspose.Slides 中 [ChartSeries](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartseries/) 的作用，重点介绍了数据在演示文稿中的结构和可视化方式。这些对象提供了定义图表中单个数据点集合、类别以及外观参数的基础元素。通过使用 [ChartSeries](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartseries/)，开发者可以无缝集成底层数据源，并全面控制信息的显示方式，从而创建动态、数据驱动的演示文稿，清晰传达洞察和分析。

系列是绘制在图表中的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置数据系列重叠**

使用 [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) 方法，您可以指定 2D 图表中柱形和条形的重叠程度（范围：-100 到 100）。此属性适用于父系列组中的所有系列：它是对应组属性的投影。

使用 `get_ParentSeriesGroup()::set_Overlap()` 方法为 `Overlap` 设置首选值。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 在幻灯片上添加簇形柱形图。  
3. 访问第一个图表系列。  
4. 访问该系列的 `ParentSeriesGroup` 并为系列设置首选的重叠值。  
5. 将修改后的演示文稿写入 PPTX 文件。  

以下 C++ 代码展示了如何为图表系列设置重叠：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // 设置系列重叠
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// 将演示文稿文件写入磁盘
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **更改数据系列颜色**

Aspose.Slides for C++ 允许您以如下方式更改系列的颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 在幻灯片上添加图表。  
3. 访问需要更改颜色的系列。  
4. 设置首选的填充类型和填充颜色。  
5. 保存修改后的演示文稿。  

以下 C++ 代码展示了如何更改系列的颜色：

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **更改数据系列类别颜色**

Aspose.Slides for C++ 允许您以如下方式更改系列类别的颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 在幻灯片上添加图表。  
3. 访问需要更改颜色的系列类别。  
4. 设置首选的填充类型和填充颜色。  
5. 保存修改后的演示文稿。  

以下 C++ 代码展示了如何更改系列类别的颜色：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **更改数据系列名称**

默认情况下，图表的图例名称来源于每列或每行数据上方单元格的内容。

在我们的示例（示例图）中，

* 列对应 *Series 1*、*Series 2* 和 *Series 3*；  
* 行对应 *Category 1*、*Category 2*、*Category 3* 和 *Category 4*。  

Aspose.Slides for C++ 允许您在图表数据和图例中更新或更改系列名称。

以下 C++ 代码展示了如何在 `ChartDataWorkbook` 中更改系列名称：

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

以下 C++ 代码展示了如何通过 `Series` 在图例中更改系列名称：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **设置数据系列填充颜色**

Aspose.Slides for C++ 允许您为绘图区内的图表系列设置自动填充颜色，方法如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 根据首选类型（示例中使用 `ChartType::ClusteredColumn`）添加带默认数据的图表。  
4. 访问图表系列并将填充颜色设置为 Automatic。  
5. 将演示文稿保存为 PPTX 文件。  

以下 C++ 代码展示了如何为图表系列设置自动填充颜色：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 创建簇形柱状图
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// 将系列填充格式设置为自动
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// 将演示文稿文件写入磁盘
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **设置数据系列反转填充颜色**

Aspose.Slides 允许您为绘图区内的图表系列设置反转填充颜色，方法如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 根据首选类型（示例中使用 `ChartType::ClusteredColumn`）添加带默认数据的图表。  
4. 访问图表系列并将填充颜色设置为 invert。  
5. 将演示文稿保存为 PPTX 文件。  

以下 C++ 代码演示了该操作：

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// 添加新系列和类别
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// 获取第一个图表系列并填充其系列数据。
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **为图表系列设置反转填充颜色**

Aspose.Slides 允许您通过 `IChartDataPoint::set_InvertIfNegative()` 和 `ChartDataPoint.set_InvertIfNegative()` 方法设置反转。当使用这些方法设置反转后，数据点在值为负时会反转其颜色。

以下 C++ 代码演示了该操作：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **清除特定数据点值**

Aspose.Slides for C++ 允许您以如下方式清除特定图表系列的 `DataPoints` 数据：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过索引获取图表的引用。  
4. 遍历图表所有 `DataPoints` 并将 `XValue` 和 `YValue` 设为 null。  
5. 清除特定图表系列的所有 `DataPoints`。  
6. 将修改后的演示文稿写入 PPTX 文件。  

以下 C++ 代码演示了该操作：

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **设置数据系列间隙宽度**

Aspose.Slides for C++ 允许您通过 **`set_GapWidth()`** 方法为系列设置间隙宽度，方法如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 访问第一张幻灯片。  
3. 添加带默认数据的图表。  
4. 访问任意图表系列。  
5. 设置 `GapWidth` 属性。  
6. 将修改后的演示文稿写入 PPTX 文件。  

以下 C++ 代码展示了如何设置系列的间隙宽度：

```cpp
// 创建空白演示文稿 
auto presentation = System::MakeObject<Presentation>();

// 访问演示文稿的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加带默认数据的图表
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// 设置图表数据工作表的索引
int32_t worksheetIndex = 0;

// 获取图表数据工作表
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// 添加系列
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// 添加类别
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// 获取第二个图表系列
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// 填充系列数据
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// 设置间隙宽度值
series->get_ParentSeriesGroup()->set_GapWidth(50);

// 将演示文稿保存到磁盘
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **常见问题**

**单个图表可以包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际限制取决于图表的可读性以及应用程序可用的内存。

**如果簇内的柱形之间太靠近或太远该怎么办？**

调整该系列（或其父系列组）的间隙宽度设置。增大数值会扩大柱形之间的间距，减小数值则会使它们更靠近。