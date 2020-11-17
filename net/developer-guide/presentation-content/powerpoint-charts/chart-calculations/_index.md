---
title: Chart Calculations
type: docs
weight: 50
url: /net/chart-calculations/
---

## **Calculate Actual Values of Chart Elements**
Aspose.Slides for .NET provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-ValidateChartLayoutAdded-ValidateChartLayoutAdded.cs" >}}

## **Calculate Actual Position of Parent Chart Elements**
Aspose.Slides for .NET provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Charts-IActualLayoutAdded-IActualLayoutadded.cs" >}}

## **Hide Information from Chart**
This topic helps you to understand how to hide information from chart. Using Aspose.Slides for .NET you can hide **Title, Vertical Axis, Horizontal Axis** and **Grid Lines** from chart. Below code example shows how to use these properties.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Charts-HideInformationFromChart-HideInformationFromChart.cs" >}}
