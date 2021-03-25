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