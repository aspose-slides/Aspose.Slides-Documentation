---
title: Editing Chart's Content
type: docs
weight: 20
url: /java/editing-chart-s-content/
---

## **Add Chart Trend Lines**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add the trend lines for the chart by adding them from scratch. This article explains how to add different chart trend lines.

{{% /alert %}} 
### **Managing Chart Trend Lines**
Aspose.Slides for Java provides an API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Adding exponential trend line for chart series 1.
1. Adding linear trend line for chart series 1.
1. Adding logarithmic trend line for chart series 2.
1. Adding moving average trend line for chart series 2.
1. Adding polynomial trend line for chart series 3.
1. Adding power trend line for chart series 3.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingChartTrendLines-AddingChartTrendLines.java" >}}


The above code snippet created a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/KwBc4NT.png)|
| :- |
|**Figure: Sample chart with trend lines**|
## **Add Error Bars for Charts**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add the error bars for the chart series data. This article explains how to add different chart error bar lines.

{{% /alert %}} 
### **Adding Fixed Error Bar Value for Chart**
Aspose.Slides for Java provides an API for managing error bar values. The sample code below applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingFixedErrorBarValueForChart-AddingFixedErrorBarValueForChart.java" >}}
### **Adding Custom Error Bar Value for Chart**
Aspose.Slides for Java provides a simple API for managing custom error bar values.

The sample code applies when the [IErrorBarsFormat.ValueType](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IErrorBarsFormat) property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingCustomErrorBarValueForChart-AddingCustomErrorBarValueForChart.java" >}}
## **Adding Chart Series Overlap for Charts**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers set chart series overlap for chart series in chart series collection. This article explains how to set the chart series overlap values for chart series.

{{% /alert %}} 

Aspose.Slides for Java provides an API to set chart series overlap. The [IChartSeries.setOverlap()](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IChartSeries) method specifies how much bars and columns should overlap on 2D charts (in a range from -100 to 100). This property is not only for the referred series but for all series of the parent series group: this is projection of the appropriate group property. Therefore, this property is read-only.

Use the **ParentSeriesGroup** property to access the parent series group, and then access the **ParentSeriesGroup.setOverlap()** read/write property to change the value.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the selected series **ParentSeriesGroup** and set the chart series overlap value.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingChartSeriesOverlapForCharts-AddingChartSeriesOverlapForCharts.java" >}}
## **Setting the Chart Marker Options on Data Points Level**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports Setting the chart marker options on data points level. In this topic, we will see with example how to set the series marker on chart data point level inside particular series using Aspose.Slides.

{{% /alert %}} 

The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingTheChartMarkerOptionsOnDataPointsLevel-SettingTheChartMarkerOptionsOnDataPointsLevel.java" >}}
## **Display Percentage As Labels**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports displaying the percentage as labels.

{{% /alert %}} 

In order to set percentage as display, please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
1. Add stacked column chart.
1. Calculate the series data point values for particular categories.
1. Displaying the percentage as labels.
1. Set properties of label.
1. Write presentation to disk.

In the example given below, we have set the percentage as label.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-DisplayingPercentageAsLabels-DisplayingPercentageAsLabels.java" >}}
## **Switch Data over axis**
A new property has been added which Swap the data over the axis. Data being charted on the X axis will move to the Y axis and vice versa. Below sample example is given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SwitchChartRowColumns-SwitchChartRowColumns.java" >}}
## **Setting chart data from workbook**
A new property has been added to set chart data from workbook. Now Aspose.Slides does allow ReadWorkbookStream() and WrtiteWorkbookStream() methods to read and write chart data workbooks containing chart data edited using Aspose.Cells. However, the chart data needs to be organized in same way or of similar type as of source type. Below sample example is given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetChartDataFromWorkBook-SetChartDataFromWorkBook.java" >}}
## **Support for showing Display Unit label on Chart value axis**
Aspose.Slides for Java provides support for showing Display unit label on chart value axis. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ShowingDisplayUnitLabel-ShowingDisplayUnitLabel.java" >}}
## **Support of setting Position Axis in Category or Value Axis**
Aspose.Slides for Java provides a simple API for setting Position axis in category or Value axis. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingPositionAxis-SettingPositionAxis.java" >}}
## **Support for setting rotation angle for chart axis title**
Aspose.Slides for Java provides a simple API for setting rotation angle for chart axis title. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingRotationAngle-SettingRotationAngle.java" >}}
## **Support for setting date format for Category Axis Value**
Aspose.Slides for Java provides a simple API for setting date format for category axis value. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingDateFormatForCategoryAxis-SettingDateFormatForCategoryAxis.java" >}}
## **Setting Precision of Data in chart Data Labels**
Aspose.Slides for Java provides a simple API for setting precision of data in chart data label. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForPrecisionOfData-SupportForPrecisionOfData.java" >}}
## **Get Chart Image**
Aspose.Slides for Java provides support for extracting image of specific chart. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-GetChartImage-GetChartImage.java" >}}
## **Changing series Color**
Aspose.Slides for Java provides support for changing series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

` `Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForChangingSeriesColor-SupportForChangingSeriesColor.java" >}}
## **Setting chart area rounded borders**
Aspose.Slides for Java provides support for setting chart area. **IChart.HasRoundedCorners** and **Chart.HasRoundedCorners** properties have been added in Aspose.Slides. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Set fill type and fill color of chart
1. Set round corner property True.
1. Save modified presentation.

` `Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForChartAreaRoundedBorders-SupportForChartAreaRoundedBorders.java" >}}
## **Change color of categories in series**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

`  `Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ChangeColorOfCategories-ChangeColorOfCategories.java" >}}
## **Setting font properties for chart data table**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class object.
1. Add chart on the slide.
1. set chart table.
1. Set font height.
1. Save modified presentation.

` `Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingFontPropertiesForTable-SettingFontPropertiesForTable.java" >}}
## **Setting Callout For Doughnut chart**
Aspose.Slides for Java provides support for setting series data label callout shape for a Doughnut chart. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddDoughnutCallout-AddDoughnutCallout.java" >}}
## **Set Font Properties for Chart**
` `Aspose.Slides for Java provides support for setting the font related properties for the chart. Please follow the steps below for setting the font properties for chart. 

- Instantiate Presentation class object.
- Add chart on the slide.
- Set font height.
- Save modified presentation.

` `Below sample example is given.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FontPropertiesForChart-FontPropertiesForChart.java" >}}

