---
title: Chart Plot Area
type: docs
url: /java/chart-plot-area/
---


## **Set Invert Fill Color for Plot Area**
Aspose.Slides for Java provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Accessing the chart series and setting the fill color to invert
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.java" >}}


## **Get Width, Height of Plot Area**
Aspose.Slides for Java provides a simple API for . 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart.ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-GetWidthHeightFromChartPlotArea-GetWidthHeightFromChartPlotArea.java" >}}

## **Set Layout Mode for Plot Area**
Aspose.Slides for Java provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetLayoutMode-SetLayoutMode.java" >}}



You can apply color to data points in the chart using Aspose.Slides for Java. [**IChartDataPointLevelsManager**](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevelsManager) and **[IChartDataPointLevel](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevel)** classes have been added to get access to properties of data point levels. This article demonstrates how you can access and apply color to data points in a chart.
