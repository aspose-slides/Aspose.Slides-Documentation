---
title: Creating and Updating Chart in a Slide
type: docs
weight: 10
url: /java/creating-and-updating-chart-in-a-slide/
---

## **Create a chart from scratch**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers add custom charts into slides from scratch. This topic, explains how to create normal and scatter charts with multiple series from scratch using Aspose.Slides for Java.

Aspose.Slides for Java works independently of Aspose.Cells for Java for chart creation.

{{% /alert %}} 
### **Create Normal Charts**
Aspose.Slides for Java has provided the simplest API for creating charts. To create a chart in a slide, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
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

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreatingNormalCharts-CreatingNormalCharts.java" >}}

|![todo:image_alt_text](http://i.imgur.com/Yntx6mK.png)|
| :- |
|**Figure: Chart added to the slide**|
### **Creating Multi Category Chart**
Aspose.Slides for Java provides a simple API for creating multi category chart. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.ClusteredColumn).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-MultiCategoryChart-MultiCategoryChart.java" >}}
### **Creating Tree Map Chart**
Aspose.Slides for Java provides a simple API for creating Tree Map charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.TreeMap).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-TreeMapChart-TreeMapChart.java" >}}
### **Creating Box and Whisker Chart**
Aspose.Slides for Java provides a simple API for creating Box and Whisker charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.BoxAndWhisker).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-BoxChart-BoxChart.java" >}}
### **Creating Funnel Chart**
Aspose.Slides for Java provides a simple API for creating Funnel charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Funnel).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-FunnelChart-FunnelChart.java" >}}
### **Creating Sunburst Chart**
Aspose.Slides for Java provides a simple API for creating Sunburst charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.sunburst).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SunburstChart-SunburstChart.java" >}}
### **Creating Stock Chart**
Aspose.Slides for java provides a simple API for creating Stock charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.OpenHighLowClose).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Add new chart data for the chart series.
1. specifies HiLowLines format.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForStockChart-SupportForStockChart.java" >}}
### **Creating Histogram Chart**
Aspose.Slides for Java provides a simple API for creating Histogram charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.Histogram).
1. Access the chart data IChartDataWorkbook.
1. Clear the default series and categories.
1. Add new series and categories.
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-HistogramChart-HistogramChart.java" >}}
### **Creating Scattered Chart with multiple series and different series markers**
The following code is used to create a scatter chart with different series markers.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreatingScatteredChartWithMultipleSeriesAndDifferentSeriesMarkers-CreatingScatteredChartWithMultipleSeriesAndDifferentSeriesMarkers.java" >}}

|![todo:image_alt_text](http://i.imgur.com/0ZRdueR.png)|
| :- |
|**Figure: Chart added to the slide**|
### **Default Markers in Chart**
Aspose.Slides for Java provides a simple API to set the chart series marker automatically. In the following feature, every chart series will get different default marker symbol automatically.

Below code example shows how to set the chart series marker automatically.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-DefaultMarkersInChart-DefaultMarkersInChart.java" >}}


## **Update an existing chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java facilitates developers to update charts generated through Aspose.Slides or MS PowerPoint. This topic explains how developers can modify existing charts in slides using Aspose.Slides for Java.

{{% /alert %}} 
### **Updating a Chart**
Please follow the steps below to update a chart in a slide:

- Open an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data worksheet.
- Modify the chart data series data by changing series values.
- Adding a new series and populating data inside it.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-UpdatingExistingChart-UpdatingExistingChart.java" >}}

|![todo:image_alt_text](http://i.imgur.com/900NBmE.png)|
| :- |
|**Figure: Chart in source presentation**|
The above code snippet modified the chart in the source presentation as shown below:

|![todo:image_alt_text](http://i.imgur.com/ZQ7K3dn.png)|
| :- |
|**Figure: Modified Chart**|
### **Setting Data Range for Chart**
Please follow the steps below to update a chart in a slide:

- Open an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find the desired chart.
- Access the chart data and set the range
- Save the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SetDataRangeForChart-SetDataRangeForChart.java" >}}
## **Manage different properties of charts**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers set properties of 3D charts. This article explains how to set these properties.

{{% /alert %}} 
### **Setting the RotationX, RotationY and DepthPercents properties of 3D Chart.**
Aspose.Slides for Java provides a simple API for setting these properties. Following code applies the said properties.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingRotationAndDepthPercentsPropertiesOf3DChart-SettingRotationAndDepthPercentsPropertiesOf3DChart.java" >}}
### **Setting the GapWidth property of Chart Series**
Aspose.Slides for Java provides an API for setting GapWidth property.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set **GapWidth** property.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingTheGapWidthPropertyOfChartSeries-SettingTheGapWidthPropertyOfChartSeries.java" >}}
### **Setting the automatic series color for chart series**
Aspose.Slides for Java provides an API for setting automatic series color. The first series is automatic because FillType is set to NotDefined. This is how to set automatic series color. While the other series is always grey because automatic series color is set for only one series.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set **FillType** property to NotDefined.
1. Write the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomaticSeriesFillColor-SettingAutomaticSeriesFillColor.java" >}}
### **Setting automatic pie chart slice colors**
`      `Aspose.Slides for Java provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the Presentation class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.java" >}}
### **Set Invert Fill Color for Chart Series Inside Plot Area**
Aspose.Slides for Java provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses [ChartType.ClusteredColumn](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/ChartType)).
1. Accessing the chart series and setting the fill color to invert
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.java" >}}
### **Setting Workbook Cell As DataLabel**
Aspose.Slides for Java provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-UsingWorkBookChartCellAsDataLabel-UsingWorkBookChartCellAsDatalabel.java" >}}
### **Get Width, Height for ChartPlotArea**
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
### **Calculates actual position of parent chart element**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-IActualLayoutAdded-IActualLayoutAdded.java" >}}
### **Calculates actual values of chart element**
Aspose.Slides for Java provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-IActualLayoutAdded-IActualLayoutAdded.java" >}}
### **Get Actual Max value of vertical axis on a chart**
Aspose.Slides for Java provides a simple API for getting value of vertical axis. 

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Get actual maximum value on the axis.
1. Get actual minimum value on the axis.
1. Get actual major unit of the axis.
1. Get actual minor unit of the axis.
1. Get actual major unit scale of the axis.
1. Get actual minor unit scale of the axis.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-GetValuesAndUnitScaleFromAxis-GetValuesAndUnitScaleFromAxis.java" >}}
## **Animate chart's elements**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports animating the chart elements. Series, Categories, Series Elements, Categories Elements could be animated because new method **addEffect** and two new enums **EffectChartMajorGroupingType** and **EffectChartMinorGroupingType** have been introduced, which are explained in the code below. In this topic, we will learn how to animate chart elements using Aspose.Slides.

{{% /alert %}} 
### **Animating a Series**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the series.
1. Write the presentation file to disk.

In the example given below, we animated chart series.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AnimatingASeries-AnimatingASeries.java" >}}
### **Animating a Category**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the Category.
1. Write the presentation file to disk.

In the example given below, we animated chart category.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AnimatingACategory-AnimatingACategory.java" >}}
### **Animating Series Elements**
If you want to animate series' elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate series elements.
1. Write the presentation file to disk.

In the example given below, we have animated series' elements.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AnimatingSeriesElements-AnimatingSeriesElements.java" >}}
### **Animating Categories Elements**
If you want to animate categories' elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate categories' elements.
1. Write the presentation file to disk.

In the example given below, we have animated categories' elements.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AnimatingCategoriesElements-AnimatingCategoriesElements.java" >}}
### **Hide Information From Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for Java you can hide **Title, Vertical Axis, Horizontal Axis, Legend** and **Grid Lines** from chart. Below code example shows how to use these properties.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-HideInformationFromChart-HideInformationFromChart.java" >}}
