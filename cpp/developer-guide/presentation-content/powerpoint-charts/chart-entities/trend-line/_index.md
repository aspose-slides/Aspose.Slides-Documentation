---
title: Trend Line
type: docs
url: /cpp/trend-line/
---

## **Add Trend Line**
Aspose.Slides for C++ provides a simple API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
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

## **Add Custom Line**
Aspose.Slides for C++ provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}


