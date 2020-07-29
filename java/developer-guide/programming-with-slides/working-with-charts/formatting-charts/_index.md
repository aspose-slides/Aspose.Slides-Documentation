---
title: Formatting Charts
type: docs
weight: 30
url: /java/formatting-charts/
---

## **Formatting Chart Entities**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add custom charts to their slides from scratch. This article explains how to format different chart entities including chart category and value axis.

{{% /alert %}} 
### **Formatting Chart Entities**
Aspose.Slides for Java provides a simple API for managing different chart entities and formatting them using custom values:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (in this example we will use [ChartType.LineWithMarkers](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Access the chart Value Axis and set the following properties:
   1. Setting **Line format** for Value Axis Major Grid lines
   1. Setting **Line format** for Value Axis Minor Grid lines
   1. Setting **Number Format** for Value Axis
   1. Setting **Min, Max, Major and Minor units** for Value Axis
   1. Setting **Text Properties** for Value Axis data
   1. Setting **Title** for Value Axis
   1. Setting **Line Format** for Value Axis
1. Access the chart Category Axis and set the following properties:
   1. Setting **Line format** for Category Axis Major Grid lines
   1. Setting **Line format** for Category Axis Minor Grid lines
   1. Setting **Text Properties** for Category Axis data
   1. Setting **Title** for Category Axis
   1. Setting **Label Positioning** for Category Axis
   1. Setting **Rotation Angle** for Category Axis labels
1. Access the chart Legend and set the **Text Properties** for them
1. Set show chart Legends without overlapping chart
1. Access the chart **Secondary Value Axis** and set the following properties:
   1. Enable the Secondary **Value Axis**
   1. Setting **Line Format** for Secondary Value Axis
   1. Setting **Number Format** for Secondary Value Axis
   1. Setting **Min, Max, Major and Minor units** for Secondary Value Axis
1. Now plot the first chart series on Secondary Value Axis
1. Set the chart back wall fill color
1. Set the chart plot area fill color
1. Write the modified presentation to a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FormattingChartEntities-FormattingChartEntities.java" >}}

The above code snipped will create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/77YNJSx.png)|
| :- |
|**Figure: Formatted chart added to the slide**|
### **Change the type of chart's category axis**
New methods **getCategoryAxisType()** and **setCategoryAxisType()** have been added to [IAxis](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAxis) and [Axis](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Axis) classes. Below are the properties to determine category axis type.

- CategoryAxisType.Text - category axis type is Text
- CategoryAxisType.Date - category axis type is DateTime
  However, the CategoryAxisType.Auto is not supported at the moment.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ChangeTypeOfChartsCategoryAxis-ChangeTypeOfChartsCategoryAxis.java" >}}
### **Display chart labels as callouts**
New methods **getShowLabelAsDataCallout()** and **setShowLabelAsDataCallout()** have been added to [DataLabelFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/DataLabelFormat) class and [IDataLabelFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IDataLabelFormat) interface. These methods determine either specified chart's data label will be displayed as data callout or as data label.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-DisplayChartLabelsAsCallouts-DisplayChartLabelsAsCallouts.java" >}}
## **Set Pie Chart Sector Colors**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add custom charts to their slides from scratch. This article explains how to create a pie chart and set different colors for its sectors.

{{% /alert %}} 

Aspose.Slides for Java provides an API for creating and filling pie charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type ([ChartType.Pie](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Access the chart data [IChartDataWorkbook](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IChartDataWorkbook).
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Add new points for charts and add custom colors for the pie chart's sectors.
1. Set labels for series.
1. Set leader lines for series labels.
1. Set the rotation angle for pie chart slides.
1. Write the modified presentation to a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingPieChartSectorColors-SettingPieChartSectorColors.java" >}}

The above code snippet create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/qSbb9f1.png)|
| :- |
|**Figure: Pie chart added to the slide**|
## **Apply Color to Data Points**
You can apply color to data points in the chart using Aspose.Slides for Java. [**IChartDataPointLevelsManager**](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevelsManager) and **[IChartDataPointLevel](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevel)** classes have been added to get access to properties of data point levels. This article demonstrates how you can access and apply color to data points in a chart.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddColorToDataPoints-AddColorToDataPoints.java" >}}


## **Setting Number Format for Chart Data Cell**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers to set chart data cell number. This article explains how to set the chart data number format and possible options.

{{% /alert %}} 

Aspose.Slides for Java provides a simple API for managing chart data format:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Set the preset number format from the possible preset values.
1. Traverse through the chart data cell in every chart series and set the chart data number format.
1. Save the presentation.
1. Set the custom number format.
1. Traverse through chart data cell inside every chart series and setting a different chart data number format.
1. Save the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingNumberFormatForChartDataCell-SettingNumberFormatForChartDataCell.java" >}}

The above code snippet create a chart like the one shown below.

|![todo:image_alt_text](http://i.imgur.com/I3g8af5.png)|
| :- |
|**Figure: Sample chart with different number formats**|


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
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |
## **Setting Automatic Series Fill Color**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers to set the automatic chart series color which will be set in accordance with presentation theme used. Now, users will not have to bother about setting the fill colors for chart series. This article explains how to set the automatic fill color for chart series.

{{% /alert %}} 

Aspose.Slides for Java provides an API for setting automatic fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Accessing the chart series and setting the fill color to Automatic.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomaticSeriesFillColor-SettingAutomaticSeriesFillColor.java" >}}
## **Setting the Label Distance From Category Axis**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports setting the label's distance from category axis. In this topic, we will see with example how to set the label distance from axis in Aspose.Slides.

{{% /alert %}} 

In order to set the Label Distance. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Get reference of the slide.
1. Adding a chart on slide.
1. Setting the position of label from axis.
1. Write the presentation as a PPTX file.

In the example given below, we have set the label distance from category axis.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingTheLabelDistanceFromCategoryAxis-SettingTheLabelDistanceFromCategoryAxis.java" >}}
## **Setting Custom Location and Size for Chart Legend**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports setting the custom location and size of chart legend. In this topic, we will see with example how to set the Custom Location and Size for Chart legend in Aspose.Slides.

{{% /alert %}} 

In order to set the legend properties. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Get reference of the slide.
1. Adding a chart on slide.
1. Setting the properties of legend.
1. Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingCustomLocationAndSizeForChartLegend-SettingCustomLocationAndSizeForChartLegend.java" >}}
## **Specifying Doughnut chart hole size**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports specifying the size of the hole in a doughnut chart. In this topic, we will see with example how to specify the size of the hole in a doughnut chart.

{{% /alert %}} 

In order to specify the size of the hole in a doughnut chart, please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
1. Add doughnut chart on the slide.
1. Specify the size of the hole in a doughnut chart.
1. Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SpecifyingDoughnutChartHoleSize-SpecifyingDoughnutChartHoleSize.java" >}}
## **Second plot options for Pie of Pie and Bar of Pie chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will see with example how to specify these options using Aspose.Slides.

{{% /alert %}} 

In order to specify the properties, please follow the steps below:

1. Instantiate [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SecondPlotOptionsForPieOfPieAndBarOfPieChart-SecondPlotOptionsForPieOfPieAndBarOfPieChart.java" >}}
## **Get chart external data source woorkbook path**
Aspose.Slides for Java provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

In the example given below, we have set the label distance from category axis.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-DataSourceTypePropertyAdded-DataSourceTypePropertyAdded.java" >}}
## **Bubble chart size scaling**
Aspose.Slides for Java provides support for Bubble chart size scaling. In Aspose.Slides for Java IChartSeries.setBubbleSizeScale()/getBubbleSizeScale() and IChartSeriesGroup.setBubbleSizeScale()/getBubbleSizeScale() methods have been added. Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForBubbleChartScaling-SupportForBubbleChartScaling.java" >}}
## **Setting Font Size of Legend**
The Aspose.Slides for Java lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FontSizeLegend-FontSizeLegend.java" >}}
## **Setting font size of individual Legend**
The Aspose.Slides for Java lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FontPropertiesForInvidualLegend-FontPropertiesForInvidualLegend.java" >}}
## **Setting InvertIfNegative Property for Individual Series**
The Aspose.Slides for Java lets developers allow to set inverts. **IChartDataPoint.InvertIfNegative** and **ChartDataPoint.InvertIfNegative** properties have been added. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-InvertIfNegativeForIndividualSeries-InvertIfNegativeForIndividualSeries.java" >}}
## **Represent Data As Bubble Chart Sizes**
The Aspose.Slides for Java added a method **getBubbleSizeRepresentation** to IChartSeries, IChartSeriesGroup interfaces, and related classes. **getBubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.Area** and **BubbleSizeRepresentationType.Width**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.java" >}}
## **Adding Custom Lines**
Aspose.Slides for Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingCustomLines-AddingCustomLines.java" >}}
## **Clear Specific Chart Series Data Points Data**
Aspose.Slides for Java provides a simple API to clear specific chart series **DataPoints** data. To clear specific chart series **DataPoints** data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the **DataPoints** of chart and set **XValue** and **YValue** to null.
- Remove all **DataPoints** of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ClearSpecificChartSeriesDataPointsData-ClearSpecificChartSeriesDataPointsData.java" >}}
## **Setting Layout Mode of Chart Plot Area**
Aspose.Slides for Java provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetLayoutMode-SetLayoutMode.java" >}}



You can apply color to data points in the chart using Aspose.Slides for Java. [**IChartDataPointLevelsManager**](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevelsManager) and **[IChartDataPointLevel](https://apireference.aspose.com/java/slides/com.aspose.slides/IChartDataPointLevel)** classes have been added to get access to properties of data point levels. This article demonstrates how you can access and apply color to data points in a chart.
