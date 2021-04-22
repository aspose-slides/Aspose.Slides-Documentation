---
title: Create Chart
type: docs
weight: 10
url: /net/create-chart/
---

## **Create Chart**
Aspose.Slides for .NET lets developers add custom charts into slides from scratch. This topic, explains how to create normal and scatter charts with multiple series from scratch using Aspose.Slides for .NET. Aspose.Slides for .NET is works independently of Aspose.Cells for .NET for chart creation. This article explains how to create different types of charts:

- Create normal charts.
- Create a scatter chart with multiple series and different series markers.
## **Create Normal Chart**
Aspose.Slides for .NET has provided the simplest API for creating charts in an easy way. To create a chart in a slide, please follow the steps below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by index.
1. Add a chart with default data along with the desired type.
1. Add a chart title.
1. Access the chart data worksheet.
1. Clear all the default series and categories.
1. Add new series and categories.
1. Add new chart data for chart series.
1. Add fill color for chart series.
1. Adding chart series labels.
1. Write the modified presentation as a PPTX file.

The following example shows how to create a normal Chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-NormalCharts-NormalCharts.cs" >}}
## **Create Scattered Chart**
The following code is used to create a scatter chart with different series of markers.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-ScatteredChart-ScatteredChart.cs" >}}
## **Create Pie Chart**
Aspose.Slides for .NET provides a simple API for creating and filling pie charts in an easy way. To create a chart on a slide:

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

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-PieChart-PieChart.cs" >}}
## **Create Tree Map Chart**
Aspose.Slides for .NET provides a simple API for creating Tree Map charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.TreeMap).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-TreeMapChart-TreeMapChart.cs" >}}
## **Create Stock Chart**
Aspose.Slides for .NET provides a simple API for creating Stock charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.OpenHighLowClose).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. specifies HiLowLines format.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SupportForStockChart-SupportForStockChart.cs" >}}
## **Create Box and Whisker Chart**
Aspose.Slides for .NET provides a simple API for creating Box and Whisker charts in an easy way. To create a chart on a slide:

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
## **Create Funnel Chart**
Aspose.Slides for .NET provides a simple API for creating Funnel charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-FunnelChart-FunnelChart.cs" >}}
## **Create Sunburst Chart**
Aspose.Slides for .NET provides a simple API for creating Sunburst charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SunburstChart-SunburstChart.cs" >}}
## **Create Histogram Chart**
Aspose.Slides for .NET provides a simple API for creating Histogram charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Histogram).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-HistogramChart-HistogramChart.cs" >}}
## **Create Multi Category Chart**
Aspose.Slides for .NET provides a simple API for creating a multi category chart. To create a chart on a slide:

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
## **Update Chart**
Aspose.Slides for .NET has provided the simplest API to update charts in an easiest way. To update a chart in a slide:

- Open an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Adding a new series and populating data inside it.
- Write the modified presentation as a PPTX file.

The code examples that follow how to update a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-ExistingChart-ExistingChart.cs" >}}


Setting Data Range for Chart

Aspose.Slides for .NET has provided the simplest API to set the data range for a chart in an easiest way. To set the data range for a chart:

- Open an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

The code examples that follow how to update a chart.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-SetDataRange-SetDataRange.cs" >}}
## **Default Markers in Chart**
Aspose.Slides for .NET provides a simple API to set the chart series marker automatically. In the following feature, every chart series will get different default marker symbols automatically.

Below code example shows how to set the chart series marker automatically.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-DefaultMarkersInChart-DefaultMarkersInChart.cs" >}}










