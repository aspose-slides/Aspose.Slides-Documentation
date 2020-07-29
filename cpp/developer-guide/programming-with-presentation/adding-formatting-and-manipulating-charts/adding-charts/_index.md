---
title: Adding Charts
type: docs
weight: 10
url: /cpp/adding-charts/
---

## **Adding Charts**
Aspose.Slides for C++ lets developers add custom charts into slides from scratch. This topic, explains how to create normal and scatter charts with multiple series from scratch using Aspose.Slides for C++. Aspose.Slides for C++ is works independently of Aspose.Cells for C++ for chart creation. This article explains how to create different types of charts:

- Creating normal charts.
- Creating scatter chart with multiple series and different series markers.
### **Creating Normal Chart**
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
### **Creating Scattered Chart**
The following code is used to create a scatter chart with different series markers.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ScatteredChart-ScatteredChart.cpp" >}}
### **Creating Pie Chart**
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
### **Creating Tree Map Chart**
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
### **Creating Stock Chart**
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
### **Creating Box and Whisker Chart**
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
### **Creating Funnel Chart**
Aspose.Slides for C++ provides a simple API for creating Funnel charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddFunnelChart-AddFunnelChart.cpp" >}}
### **Creating Sunburst Chart**
Aspose.Slides for C++ provides a simple API for creating Sunburst charts in an easy way. To create a chart on a slide:

1. Create an instance of the Presentation class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSunburstChart-AddSunburstChart.cpp" >}}
### **Creating Histogram Chart**
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
### **Creating Multi Category Chart**
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
### **Updating an Existing Chart**
Aspose.Slides for C++ has provided the simplest API to update charts in an easiest way. To update a chart in a slide:

- Open an instance of Presentation class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Adding a new series and populating data inside it.
- Write the modified presentation as a PPTX file.

The code examples that follow how to update a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExistingChart-ExistingChart.cpp" >}}
### **Setting Data Range for Chart**
Aspose.Slides for C++ has provided the simplest API to set the data range for chart in an easiest way. To set the data range for chart:

- Open an instance of Presentation class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

The code examples that follow how to update a chart.



{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}
## **Default Markers in Chart**
Aspose.Slides for C++ provides a simple API to set the chart series marker automatically. In the following feature, every chart series will get different default marker symbol automatically.

Below code example shows how to set the chart series marker automatically.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}
