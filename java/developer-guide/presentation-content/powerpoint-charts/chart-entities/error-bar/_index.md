---
title: Error Bar
type: docs
url: /java/error-bar/
---

## **Add Error Bar**
Aspose.Slides for Java provides an API for managing error bar values. The sample code below applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-AddingFixedErrorBarValueForChart-AddingFixedErrorBarValueForChart.java" >}}

## **Add Custom Error Bar**
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
