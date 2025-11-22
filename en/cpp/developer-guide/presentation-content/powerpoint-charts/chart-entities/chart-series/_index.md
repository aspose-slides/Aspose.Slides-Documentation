---
title: Manage Chart Data Series in Presentations Using С++
linktitle: Data Series
type: docs
url: /cpp/chart-series/
keywords:
- сhart series
- series overlap
- series color
- category color
- series name
- data point
- series gap
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Learn how to manage chart series in С++ for PowerPoint (PPT/PPTX) with practical code examples and best practices to enhance your data presentations."
---

A series is a row or column of numbers plotted in a chart.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set Chart Series Overlap**

With the [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) method, you can specify how much bars and columns should overlap on a 2D chart (range: -100 to 100). This property applies to all series of the parent series group: this is a projection of the appropriate group property.

Use the `get_ParentSeriesGroup()::set_Overlap()` method to set your preferred value for `Overlap`. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the chart series' `ParentSeriesGroup` and set your preferred overlap value for the series. 
1. Write the modified presentation to a PPTX file.

This C++ code shows you how to set the overlap for a chart series:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Sets series overlap
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Change Series Color**
Aspose.Slides for C++ allows you to change a series' color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Add chart on the slide.
1. Access the series whose color you want to change. 
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This C++ code shows you how to change a series' color:

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

## **Change Series Category's Color**
Aspose.Slides for C++ allows you to change a series category's color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Add chart on the slide.
1. Access the series category whose color you want to change.
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This code in C++ shows you how to change a series category's color:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Change Series' Name** 

By default, the legend names for a chart are the contents of cells above each column or row of data. 

In our example (sample image), 

* the columns are *Series 1, Series 2,* and *Series 3*;
* the rows are *Category 1, Category 2, Category 3,* and *Category 4.* 

Aspose.Slides for C++ allows you to update or change a series name in its chart data and legend. 

This C++ code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

This C++ code shows you how to change a series name in its legend through`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Set Chart Series Fill Color**

Aspose.Slides for C++ allows you to set the automatic fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType::ClusteredColumn`).
1. Access the chart series and set the fill color to Automatic.
1. Save the presentation to a PPTX file.

This C++ code shows you how to set the automatic fill color for a chart series:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Creates a clustered column chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Sets series fill format to automatic
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Writes the presentation file to disk
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Set Chart Series Invert Fill Colors**
Aspose.Slides allows you to set the invert fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType::ClusteredColumn`).
1. Access the chart series and set the fill color to invert.
1. Save the presentation to a PPTX file.

This C++ code demonstrates the operation:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
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


## **Set Series to Invert When Value is Negative**
Aspose.Slides allows you to set inverts through the`IChartDataPoint::set_InvertIfNegative()` and `ChartDataPoint.set_InvertIfNegative()` methods. When an invert is set using the methods, the data point inverts its colors when it gets a negative value. 

This C++ code demonstrates the operation:

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

## **Clear Specific Data Points' Data**
Aspose.Slides for C++ allows you to clear the `DataPoints` data for a specific chart series this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Obtain the reference of a slide through its index.
3. Obtain the reference of a chart through its index.
4. Iterate through all the chart `DataPoints` and set `XValue` and `YValue` to null.
5. Clear all `DataPoints` for specific chart series.
6. Write the modified presentation to a PPTX file.

This C++ code demonstrates the operation:

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

## **Set Series Gap Width**
Aspose.Slides for C++ allows you to set a series' Gap Width through the **`set_GapWidth()`** method this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set the `GapWidth` property.
1. Write the modified presentation to a PPTX file.

This code in C++ shows you how to set a series' Gap Width:

```cpp
// Creates empty presentation 
auto presentation = System::MakeObject<Presentation>();

// Accesses the presentation's first slide
auto slide = presentation->get_Slides()->idx_get(0);

// Adds a chart with default data
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Sets the index of the chart data sheet
int32_t worksheetIndex = 0;

// Gets the chart data worksheet
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Adds series
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Adds Categories
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the second chart series
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Populates the series data
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Sets GapWidth value
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Saves presentation to disk
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```
