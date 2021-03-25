---
title: Chart Calculations
type: docs
weight: 50
url: /cpp/chart-calculations/
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for C++ provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-ValidateChartLayoutAdded-ValidateChartLayoutAdded.cs" >}}


## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for C++ provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Charts-IActualLayoutAdded-IActualLayoutadded.cs" >}}

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for C++ you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Set Data Range for Chart**
Aspose.Slides for C++ has provided the simplest API to set the data range for chart in an easiest way. To set the data range for chart:

- Open an instance of Presentation class containing chart.
- Obtain the reference of a slide by using its Index.
- Traverse through all shapes to find desired chart.
- Access the chart data and set the range.
- Save the modified presentation as a PPTX file.

The code examples that follow how to update a chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

