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

