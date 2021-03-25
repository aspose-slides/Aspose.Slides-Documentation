---
title: Chart Series
type: docs
url: /cpp/chart-series/
---


## **Set Chart Series Overlap**
Aspose.Slides for C++ provides a simple API interface to set chart series overlap. The **Aspose.Slides.Charts.IChartSeries.Overlap** property specifies how much bars and columns should overlap on 2D charts (in a range from -100 to 100). This property is not only for the referred series but for all series of the parent series group: this is a projection of the appropriate group property. Therefore, this property is read-only. Use the **ParentSeriesGroup** property to access the parent series group, and then access the **ParentSeriesGroup.Overlap** read/write property to change the value.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the selected serie's **ParentSeriesGroup** and set the chart series to overlap value.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetChartSeriesOverlap-SetChartSeriesOverlap.cpp" >}}

## **Set Color of Chart Series**
Aspose.Slides for C++ provides support for changing series color. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangingSeriesColor-ChangingSeriesColor.cpp" >}}

## **Change Color of Chart Series**
Aspose.Slides for C++ provides support for changing color of categories in a series color. 

1. Instantiate Presentation class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeColorOfCategoriesInSeries-ChangeColorOfCategoriesInSeries.cpp" >}}

## **Set Fill Color of Chart Series**
Aspose.Slides for C++ provides a simple API for setting automatic fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to Automatic.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutomaticSeriesFillColor-SetAutomaticSeriesFillColor.cpp" >}}


## **Set Invert Fill Colors of Chart Series**
Aspose.Slides for C++ provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to invert.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetInvertFillColorChart-SetInvertFillColorChart.cpp" >}}



## **Set Invert If Negative Property for Individual Series**
The Aspose.Slides for C++ lets developers allow to set inverts. **IChartDataPoint.InvertIfNegative** and **ChartDataPoint.InvertIfNegative** properties have been added. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingInvertIfNegativePropertyForIndividualSeries-SettingInvertIfNegativePropertyForIndividualSeries.cpp" >}}



## **Clear Specific Chart Series Data Points Data**
Aspose.Slides for C++ provides a simple API to clear specific chart series **DataPoints** data. To clear specific chart series **DataPoints** data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the **DataPoints** of the chart and set **XValue** and **YValue** to null.
- Remove all **DataPoints** of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ClearSpecificChartSeriesDataPointsData-ClearSpecificChartSeriesDataPointsData.cpp" >}}

## **Set GapWidth of Chart Series**
Aspose.Slides for C++ provides a simple API for setting **GapWidth** property. The sample code applies setting the **GapWidth** property.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set GapWidth property.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetGapWidth-SetGapWidth.cpp" >}}
