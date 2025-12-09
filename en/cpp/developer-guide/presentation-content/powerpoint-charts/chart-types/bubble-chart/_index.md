---
title: Customize Bubble Charts in Presentations Using С++
linktitle: Bubble Chart
type: docs
url: /cpp/bubble-chart/
keywords:
- bubble chart
- bubble size
- size scaling
- size representation
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Create and customize powerful bubble charts in PowerPoint with Aspose.Slides for С++ to enhance your data visualization easily."
---

## **Bubble Chart Size Scaling**
Aspose.Slides for C++ provides support for Bubble chart size scaling. In Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** and **IChartSeriesGroup.BubbleSizeScale** properties have been added. Below sample example is given. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Represent Data as Bubble Chart Sizes**
New **get_BubbleSizeRepresentation()** method has been added to **IChartSeries** and **ChartSeries** classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.Area** and **BubbleSizeRepresentationType.Width**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X-Y-S (size). The type is available in the [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumeration.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart-graphics rendering rules apply (resolution, anti-aliasing), so choose sufficient DPI for printing.
