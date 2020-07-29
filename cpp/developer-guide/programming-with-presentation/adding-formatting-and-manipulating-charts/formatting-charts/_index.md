---
title: Formatting Charts
type: docs
weight: 30
url: /cpp/formatting-charts/
---

## **Formatting Charts**
### **Adding Trend Lines**
Aspose.Slides for C++ provides a simple API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses ChartType.ClusteredColumn).
1. Adding the exponential trend line for chart series 1.
1. Adding a linear trend line for chart series 1.
1. Adding a logarithmic trend line for chart series 2.
1. Adding moving average trend line for chart series 2.
1. Adding a polynomial trend line for chart series 3.
1. Adding a power trend line for chart series 3.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart with Trend Lines.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}
### **Adding Custom Lines**
Aspose.Slides for C++ provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}





### **Adding Error Bars**
Aspose.Slides for C++ provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a bubble chart on the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}
### **Adding Custom Error Bar Value**
Aspose.Slides for C++ provides a simple API for managing custom error bar values. The sample code applies when **IErrorBarsFormat.ValueType** property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a bubble chart on the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for an individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}
### **Displaying Percentage As Labels**
Aspose.Slides for C++ supports displaying the percentage as labels. In this topic, we will see with an example of how to display the percentage as labels using Aspose.Slides. In order to set percentage as a display. Please follow the steps below.

1. Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.
1. Add a stacked column chart.
1. Calculate the series data point values for particular categories.
1. Displaying the percentage as labels.
1. Set properties of label.
1. Write a presentation to disk.

In the example given below, we have set the percentage as a label.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayPercentageAsLabels-DisplayPercentageAsLabels.cpp" >}}
### **Setting Chart Data Numbers**
Aspose.Slides for C++ provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**The possible preset number format values along with their preset index and that can be used are given below:**|
| :- | :- |

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |
### **Setting Chart Series Overlap**
Aspose.Slides for C++ provides a simple API interface to set chart series overlap. The **Aspose.Slides.Charts.IChartSeries.Overlap** property specifies how much bars and columns should overlap on 2D charts (in a range from -100 to 100). This property is not only for the referred series but for all series of the parent series group: this is a projection of the appropriate group property. Therefore, this property is read-only. Use the **ParentSeriesGroup** property to access the parent series group, and then access the **ParentSeriesGroup.Overlap** read/write property to change the value.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the selected serie's **ParentSeriesGroup** and set the chart series to overlap value.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetChartSeriesOverlap-SetChartSeriesOverlap.cpp" >}}
### **Setting Chart Series Fill Colors**
Aspose.Slides for C++ provides a simple API for setting automatic fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to Automatic.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutomaticSeriesFillColor-SetAutomaticSeriesFillColor.cpp" >}}
### **Setting Chart Series Invert Fill Colors**
Aspose.Slides for C++ provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to invert.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetInvertFillColorChart-SetInvertFillColorChart.cpp" >}}
### **Setting Label Distances**
In order to set the Label Distance. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get the reference of the slide.
- Adding a chart on slide.
- Setting the position of a label from axis.
- Write the presentation as a PPTX file.

In the example given below, we have set the label distance from category axis.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetCategoryAxisLabelDistance-SetCategoryAxisLabelDistance.cpp" >}}
### **Positioning legend**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get the reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}
### **Setting percentage sign with chart data labels**
In order to set the percentage sign with chart data labels. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get the reference of the slide.
- Add PercentsStackedColumn chart on a slide.
- Set NumberFormatLinkedToSource to false.
- Getting the chart data worksheet.
- Add a new series.
- Setting the fill color of series.
- Setting LabelFormat properties.
- Write the presentation as a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataLabelsPercentageSign-SetDataLabelsPercentageSign.cpp" >}}
### **Setting Chart Marker Options**
The markers can be set on chart data points inside a particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Creating the default chart.
- Set the picture.
- Take the first chart series.
- Add a new data point.
- Write a presentation to disk.

In the example given below, we have set the chart marker options on data points level.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}
### **Formatting Chart Entities**
Aspose.Slides for C++ lets developers add custom charts to their slides from scratch. This article explains how to format different chart entities including chart category and value axis.

Aspose.Slides for C++ provides a simple API for managing different chart entities and formatting them using custom values:

1. Create an instance of the **Presentation** class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of the desired type (in this example we will use ChartType.LineWithMarkers).
1. Access the chart Value Axis and set the following properties:
   1. Setting **Line format** for Value Axis Major Grid lines
   1. Setting **Line format** for Value Axis Minor Grid lines
   1. Setting **Number Format** for Value Axis
   1. Setting **Min, Max, Major and Minor units** for Value Axis
   1. Setting **Text Properties** for Value Axis data
   1. Setting **Title** for Value Axis
   1. Setting **Line Format** for Value Axis
1. Access the chart Category Axis and set the following properties:
   1. Setting **Line format** for Category Axis Major Grid lines
   1. Setting **Line format** for Category Axis Minor Grid lines
   1. Setting **Text Properties** for Category Axis data
   1. Setting **Title** for Category Axis
   1. Setting **Label Positioning** for Category Axis
   1. Setting **Rotation Angle** for Category Axis labels
1. Access the chart Legend and set the **Text Properties** for them
1. Set show chart Legends without overlapping chart
1. Access the chart **Secondary Value Axis** and set the following properties:
   1. Enable the Secondary **Value Axis**
   1. Setting **Line Format** for Secondary Value Axis
   1. Setting **Number Format** for Secondary Value Axis
   1. Setting **Min, Max, Major and Minor units** for Secondary Value Axis
1. Now plot the first chart series on Secondary Value Axis
1. Set the chart back wall to fill color
1. Set the chart plot area fill color
1. Write the modified presentation to a PPTX file

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}
### **Setting Chart Marker on Series Data point level**
Now, the markers can be set on chart data points inside a particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate Presentation class.
- Creating the default chart.
- Set the picture.
- Take the first chart series.
- Add a new data point.
- Write a presentation to disk.

In the example given below, we have set the chart marker options on data points level.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptionsonSeries-SetMarkerOptionsonSeries.cpp" >}}
### **Setting Font Size of Legend**
The Aspose.Slides for C++ lets developers allow to set the font size of the legend. Please follow the steps below: 

- Instantiate Presentation class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write a presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}
### **Setting Font Size of Individual Legend**
The Aspose.Slides for C++ lets developers allow to set the font size of individual legend entries. Please follow the steps below: 

- Instantiate Presentation class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write a presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}
### **Setting InvertIfNegative Property for Individual Series**
The Aspose.Slides for C++ lets developers allow to set inverts. **IChartDataPoint.InvertIfNegative** and **ChartDataPoint.InvertIfNegative** properties have been added. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingInvertIfNegativePropertyForIndividualSeries-SettingInvertIfNegativePropertyForIndividualSeries.cpp" >}}


### **Represent Data As Bubble Chart Sizes**
New **get_BubbleSizeRepresentation()** method has been added to **IChartSeries** and **ChartSeries** classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.Area** and **BubbleSizeRepresentationType.Width**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}
### **Clear Specific Chart Series Data Points Data**
Aspose.Slides for C++ provides a simple API to clear specific chart series **DataPoints** data. To clear specific chart series **DataPoints** data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the **DataPoints** of the chart and set **XValue** and **YValue** to null.
- Remove all **DataPoints** of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ClearSpecificChartSeriesDataPointsData-ClearSpecificChartSeriesDataPointsData.cpp" >}}
### **Setting Layout Mode of Chart Plot Area**
Aspose.Slides for C++ provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}
## **Apply Color to Data Points**
You can apply color to data points in the chart using Aspose.Slides for C++. [**IChartDataPointLevelsManager**](https://apireference.aspose.com/cpp/slides/class/aspose.slides.charts.i_chart_data_point_levels_manager/) and **[IChartDataPointLevel](https://apireference.aspose.com/cpp/slides/class/aspose.slides.charts.i_chart_data_point_level/)** classes have been added to get access to properties of data point levels. This article demonstrates how you can access and apply color to data points in a chart.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}
