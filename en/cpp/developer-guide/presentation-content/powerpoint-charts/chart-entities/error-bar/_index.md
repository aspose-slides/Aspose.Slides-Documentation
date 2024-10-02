---
title: Error Bar
type: docs
url: /cpp/error-bar/
---

## **Add Error Bar**
Aspose.Slides for C++ provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Add a bubble chart on the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **Add Custom Error Bar**
Aspose.Slides for C++ provides a simple API for managing custom error bar values. The sample code applies when **IErrorBarsFormat.ValueType** property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Add a bubble chart on the desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for an individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}
