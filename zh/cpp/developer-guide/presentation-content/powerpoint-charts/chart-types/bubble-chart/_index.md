---
title: 气泡图
type: docs
url: /cpp/bubble-chart/
---

## **气泡图大小缩放**
Aspose.Slides for C++ 支持气泡图大小缩放。在 Aspose.Slides for **C++** 中添加了 **IChartSeries.BubbleSizeScale** 和 **IChartSeriesGroup.BubbleSizeScale** 属性。下面给出了示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **将数据表示为气泡图大小**
新的 **get_BubbleSizeRepresentation()** 方法已添加到 **IChartSeries** 和 **ChartSeries** 类中。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的值为：**BubbleSizeRepresentationType.Area** 和 **BubbleSizeRepresentationType.Width**。因此，添加了 **BubbleSizeRepresentationType** 枚举以指定将数据表示为气泡图大小的可能方式。示例代码如下。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}