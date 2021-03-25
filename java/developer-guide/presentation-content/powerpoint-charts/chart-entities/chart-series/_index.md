---
title: Chart Series
type: docs
url: /java/chart-series/
---


## **Set Gap Width of Chart Series**
Aspose.Slides for Java provides an API for setting GapWidth property.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set **GapWidth** property.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingTheGapWidthPropertyOfChartSeries-SettingTheGapWidthPropertyOfChartSeries.java" >}}

## **Set Color of Chart Series**
Aspose.Slides for Java provides an API for setting automatic series color. The first series is automatic because FillType is set to NotDefined. This is how to set automatic series color. While the other series is always grey because automatic series color is set for only one series.

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set **FillType** property to NotDefined.
1. Write the presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SettingAutomaticSeriesFillColor-SettingAutomaticSeriesFillColor.java" >}}

## **Set Fill Color of Chart Series**
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


## **Set InvertIfNegative Property of Chart Series**
The Aspose.Slides for Java lets developers allow to set inverts. **IChartDataPoint.InvertIfNegative** and **ChartDataPoint.InvertIfNegative** properties have been added. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-InvertIfNegativeForIndividualSeries-InvertIfNegativeForIndividualSeries.java" >}}

## **Add Overlap of Chart Series**
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

## **Change Color of Chart Series**
Aspose.Slides for Java provides support for changing series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

 Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-SupportForChangingSeriesColor-SupportForChangingSeriesColor.java" >}}

## **Change Category Color of Chart Series**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

`  `Below sample example is given. 

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ChangeColorOfCategories-ChangeColorOfCategories.java" >}}


## **Clear Data of Chart Series**
Aspose.Slides for Java provides a simple API to clear specific chart series **DataPoints** data. To clear specific chart series **DataPoints** data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the **DataPoints** of chart and set **XValue** and **YValue** to null.
- Remove all **DataPoints** of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ClearSpecificChartSeriesDataPointsData-ClearSpecificChartSeriesDataPointsData.java" >}}