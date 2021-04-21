---
title: Create Chart
type: docs
weight: 10
url: /net/create-chart/
---

## **Create Chart**
Aspose.Slides for .NET allows developers to create custom charts from slides. Aspose.Slides for .NET creates charts independently of Aspose.Cells. 

Aspose.Slides for .Net has simple APIs that allow you to create different types of charts, update charts, and perform other tasks involving charts. 



## **Creating Normal Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by index.
1. Add a chart with default data along with the desired type.
1. Add a chart title.
1. Access the chart data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for chart series.
1. Add fill color for chart series.
1. Add chart series labels.
1. Write the modified presentation as a PPTX file.

Sample code used to create a normal chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-NormalCharts-NormalCharts.cs" >}}
## **Creating Scattered Charts**
Sample code used to create a scatter chart with different series of markers:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-ScatteredChart-ScatteredChart.cs" >}}
## **Creating Pie Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
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

Sample code used to create a pie chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-PieChart-PieChart.cs" >}}
## **Creating Tree Map Chart**s
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.TreeMap).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

Sample code used to create a chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-TreeMapChart-TreeMapChart.cs" >}}
## **Creating Stock Chart**s
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.OpenHighLowClose).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Specify HiLowLines format.
1. Write the modified presentation to a PPTX file

Sample code used to create a chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SupportForStockChart-SupportForStockChart.cs" >}}
## **Creating Box and Whisker Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.BoxAndWhisker).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-BoxChart-BoxChart.cs" >}}
## **Creating Funnel Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-FunnelChart-FunnelChart.cs" >}}



## Creating Fusion Charts





## **Creating Sunburst Chart**s
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SunburstChart-SunburstChart.cs" >}}
## **Creating Histogram Chart**s
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Histogram).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-HistogramChart-HistogramChart.cs" >}}
## **Creating Multi Category Charts**
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.ClusteredColumn).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-MultiCategoryChart-MultiCategoryChart.cs" >}}
## **Updating Charts**
To update a chart, do this:

- Open an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Add a new series and populate the data in it.
- Write the modified presentation as a PPTX file.

Code sample used to update a chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-ExistingChart-ExistingChart.cs" >}}

## Setting Data Range for Charts

To set the data range for a chart, do this:

- Open an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

Code sample used to set data range for a chart:

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SetDataRange-SetDataRange.cs" >}}
## **Using Default Markers in Charts**
Aspose.Slides for .NET has a simple API that can help you set the chart series marker automatically. When you use a default marker in charts, each chart series get different default marker symbols automatically.

Code sample used to set a chart series marker automatically:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-DefaultMarkersInChart-DefaultMarkersInChart.cs" >}}










