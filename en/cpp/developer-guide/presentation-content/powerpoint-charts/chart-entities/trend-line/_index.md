---
title: Add Trend Lines to Presentation Charts in С++
linktitle: Trend Line
type: docs
url: /cpp/trend-line/
keywords:
- chart
- trend line
- exponential trend line
- linear trend line
- logarithmic trend line
- moving average trend line
- polynomial trend line
- power trend line
- custom trend line
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Quickly add and customize trend lines in PowerPoint charts with Aspose.Slides for С++ — a practical guide to engage your audience."
---

## **Add a Trend Line**
Aspose.Slides for C++ provides a simple API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
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

## **Add a Custom Line**
Aspose.Slides for C++ provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**What do 'forward' and 'backward' mean for a trendline?**

They are the lengths of the trendline projected forward/backward: for scatter (XY) charts — in axis units; for non-scatter charts — in number of categories. Only non-negative values are allowed.

**Will the trendline be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/cpp/render-a-slide-as-an-svg-image/) and renders charts to images; trendlines, as part of the chart, are preserved during these operations. A method is also available to [export an image of the chart](/slides/cpp/create-shape-thumbnails/) itself.
