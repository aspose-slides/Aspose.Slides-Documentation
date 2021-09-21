---
title: Create Chart
type: docs
weight: 10
url: /cpp/create-chart/
---


## **Create Chart**
Aspose.Slides for C++ lets developers add custom charts into slides from scratch. This topic, explains how to create normal and scatter charts with multiple series from scratch using Aspose.Slides for C++. Aspose.Slides for C++ is works independently of Aspose.Cells for C++ for chart creation. This article explains how to create different types of charts:

- Creating normal charts.
- Creating scatter chart with multiple series and different series markers.

## **Create Normal Chart**
Aspose.Slides for C++ has provided the simplest API for creating charts in an easy way. To create a chart in a slide, please follow the steps below:

1. Create an instance of the Presentation class.
1. Obtain the reference of a slide by index.
1. Add chart with default data along with desired type.
1. Add a chart title.
1. Access the chart data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for chart series.
1. Add fill color for chart series.
1. Adding chart series labels.
1. Write the modified presentation as a PPTX file.

The following example shows how to create normal Chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NormalCharts-NormalCharts.cpp" >}}

## **Create Scattered Chart**
The following code is used to create a scatter chart with different series markers.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ScatteredChart-ScatteredChart.cpp" >}}
## **Create Pie Chart**
Aspose.Slides for C++ provides a simple API for creating and filling pie charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Pie).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for charts and add custom colors for the pie chart's sectors.
1. Set labels for series.
1. Set leader lines for series labels.
1. Set the rotation angle for pie chart slides.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PieChart-PieChart.cpp" >}}
## **Create Tree Map Chart**
Aspose.Slides for C++ provides a simple API for creating Tree Map charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.TreeMap).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddTreemapChart-AddTreemapChart.cpp" >}}
## **Create Stock Chart**
Aspose.Slides for C++ provides a simple API for creating Stock charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.OpenHighLowClose).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. specifies HiLowLines format.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddStockChart-AddStockChart.cpp" >}}
## **Create Box and Whisker Chart**
Aspose.Slides for C++ provides a simple API for creating Box and Whisker charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.BoxAndWhisker).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddBoxAndWhiskerChart-AddBoxAndWhiskerChart.cpp" >}}
## **Create Funnel Chart**
Aspose.Slides for C++ provides a simple API for creating Funnel charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddFunnelChart-AddFunnelChart.cpp" >}}
## **Create Sunburst Chart**
Aspose.Slides for C++ provides a simple API for creating Sunburst charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSunburstChart-AddSunburstChart.cpp" >}}
## **Create Histogram Chart**
Aspose.Slides for C++ provides a simple API for creating Histogram charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Histogram).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddHistogramChart-AddHistogramChart.cpp" >}}
## **Create Multi Category Chart**
Aspose.Slides for C++ provides a simple API for creating multi category chart. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.ClusteredColumn).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-MultiCategoryChart-MultiCategoryChart.cpp" >}}


## **Setting Data Range for Charts**

To set the data range for a chart, do this:

- Open an instance of the [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

Code sample used to set data range for a chart:

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiate Presentation class that represents PPTX file
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Access first slideMarker and add chart with default data
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::DynamicCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```


## **Using Default Markers in Charts**
Aspose.Slides for C++ has a simple API that can help you set the chart series marker automatically. When you use a default marker in charts, each chart series get different default marker symbols automatically.

Code sample used to set a chart series marker automatically:

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Take second chart series
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Now populating series data
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```
