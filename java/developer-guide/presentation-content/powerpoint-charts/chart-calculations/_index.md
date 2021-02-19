---
title: Chart Calculations
type: docs
weight: 50
url: /java/chart-calculations/
---

## **Calculate Actual Value of Chart Element**
Aspose.Slides for Java provides a simple API for getting these properties. This will help you to Calculates actual values of chart elements. The actual values include position of elements that implement IActualLayout interface (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) and actual axes values (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-IActualLayoutAdded-IActualLayoutAdded.java" >}}

## **Calculate Actual Position of Parent Chart Element**
Aspose.Slides for Java provides a simple API for getting these properties. Properties of IActualLayout provide information about actual position of parent chart element. It is necessary to call method IChart.ValidateChartLayout() previously to fill properties with actual values.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-IActualLayoutAdded-IActualLayoutAdded.java" >}}
