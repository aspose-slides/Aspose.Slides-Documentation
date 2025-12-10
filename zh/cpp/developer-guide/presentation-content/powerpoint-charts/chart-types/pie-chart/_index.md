---
title: 使用 C++ 在演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/cpp/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- С++
- Aspose.Slides
description: "了解如何使用 C++ 和 Aspose.Slides 创建和自定义饼图，可导出为 PowerPoint，帮助您在几秒钟内提升数据故事讲述。"
---

## **饼图中的饼图和条形饼图的次要绘图选项**
Aspose.Slides for C++ 现在支持饼图中的饼图或条形饼图的次要绘图选项。在本节中，我们将通过示例演示如何使用 Aspose.Slides 指定这些选项。请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的次要绘图选项。
1. 将演示文稿写入磁盘。

下面的示例中，我们对饼图中的饼图设置了不同的属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}



## **设置自动饼图切片颜色**
Aspose.Slides for C++ 提供了一个简洁的 API 用于设置自动饼图切片颜色。以下示例代码演示了上述属性的设置。

1. 创建 Presentation 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置图表标题。
1. 将第一系列设置为显示数值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**是否支持“饼图中的饼图”和“条形饼图”变体？**

是的，库 [supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) 次要绘图用于饼图，包括“饼图中的饼图”和“条形饼图”类型。

**我能只将图表导出为图像（例如 PNG）吗？**

可以，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)（如 PNG），而无需导出整个演示文稿。