---
title: 图表系列
type: docs
url: /cpp/chart-series/
---

系列是绘制在图表中的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

通过 [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) 方法，您可以指定在 2D 图表上条形和柱形的重叠程度（范围：-100 到 100）。此属性适用于父系列组的所有系列：这是适当组属性的一个投影。

使用 `get_ParentSeriesGroup()::set_Overlap()` 方法设置您首选的 `Overlap` 值。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 在幻灯片上添加簇状柱形图。
1. 访问第一个图表系列。
1. 访问图表系列的 `ParentSeriesGroup` 并为系列设置您首选的重叠值。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示如何为图表系列设置重叠：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 添加图表
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

## **更改系列颜色**
Aspose.Slides for C++ 允许您以这种方式更改系列的颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 在幻灯片上添加图表。
1. 访问您要更改颜色的系列。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 C++ 代码演示如何更改系列的颜色：

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

## **更改系列分类的颜色**
Aspose.Slides for C++ 允许您以这种方式更改系列分类的颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 在幻灯片上添加图表。
1. 访问您要更改颜色的系列分类。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 C++ 代码演示如何更改系列分类的颜色：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **更改系列名称** 

默认情况下，图表的图例名称是每个数据列或行上方单元格的内容。

在我们的示例中（示例图像），

* 列是 *Series 1, Series 2,* 和 *Series 3*；
* 行是 *Category 1, Category 2, Category 3,* 和 *Category 4.* 

Aspose.Slides for C++ 允许您在其图表数据和图例中更新或更改系列名称。

以下 C++ 代码演示如何在图表数据 `ChartDataWorkbook` 中更改系列名称：

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"新名称"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

以下 C++ 代码演示如何通过 `Series` 在其图例中更改系列名称：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"新名称"));
```

## **设置图表系列填充颜色**

Aspose.Slides for C++ 允许您以这种方式设置图表系列的自动填充颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 根据您首选的类型添加带有默认数据的图表（在下面的示例中，我们使用了 `ChartType::ClusteredColumn`）。
4. 访问图表系列并将填充颜色设置为自动。
5. 将演示文稿保存为 PPTX 文件。

以下 C++ 代码展示了如何为图表系列设置自动填充颜色：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 创建簇状柱形图
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// 将系列填充格式设置为自动
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// 将演示文稿文件写入磁盘
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **设置图表系列反转填充颜色**
Aspose.Slides 允许您以这种方式设置图表系列的反转填充颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 根据您首选的类型添加带有默认数据的图表（在下面的示例中，我们使用了 `ChartType::ClusteredColumn`）。
4. 访问图表系列并将填充颜色设置为反转。
5. 将演示文稿保存为 PPTX 文件。

以下 C++ 代码演示此操作：

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// 添加新的系列和分类
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"系列 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"分类 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"分类 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"分类 3")));

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

## **设置系列在值为负时反转**
Aspose.Slides 允许您通过 `IChartDataPoint::set_InvertIfNegative()` 和 `ChartDataPoint.set_InvertIfNegative()` 方法设置反转。当使用这些方法设置反转时，数据点在获取负值时会反转其颜色。

以下 C++ 代码演示此操作：

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

## **清除特定数据点的数据**
Aspose.Slides for C++ 允许您以这种方式清除特定图表系列的 `DataPoints` 数据：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过索引获取图表的引用。
4. 遍历所有图表的 `DataPoints` 并将 `XValue` 和 `YValue` 设置为 null。
5. 清除特定图表系列的所有 `DataPoints`。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示此操作：

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

## **设置系列间隙宽度**
Aspose.Slides for C++ 允许您通过 **`set_GapWidth()`** 方法以这种方式设置系列的间隙宽度：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 访问第一张幻灯片。
3. 添加具有默认数据的图表。
4. 访问任何图表系列。
5. 设置 `GapWidth` 属性。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示如何设置系列的间隙宽度：

```cpp
// 创建空演示文稿 
auto presentation = System::MakeObject<Presentation>();

// 访问演示文稿的第一张幻灯片
auto slide = presentation->get_Slides()->idx_get(0);

// 添加带有默认数据的图表
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// 设置图表数据工作表的索引
int32_t worksheetIndex = 0;

// 获取图表数据工作表
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// 添加系列
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"系列 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"系列 2")), chart->get_Type());

// 添加分类
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"分类 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"分类 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"分类 3")));

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

// 设置 GapWidth 值
series->get_ParentSeriesGroup()->set_GapWidth(50);

// 将演示文稿保存到磁盘
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```