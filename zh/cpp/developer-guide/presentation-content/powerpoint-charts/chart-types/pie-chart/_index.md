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
- C++
- Aspose.Slides
description: "学习如何使用 Aspose.Slides 在 C++ 中创建和自定义饼图，可导出为 PowerPoint，瞬间提升您的数据叙事能力。"
---
## **概述**

本文解释了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置次要绘图选项，以及如何为标准饼图启用自动切片着色。

示例侧重于实际的图表自定义步骤，例如向幻灯片添加图表、调整系列和标签设置、用自定义类别和值替换默认图表数据，以及保存更新后的演示文稿。

## **Pie of Pie 和 Bar of Pie 图表的次要绘图选项**
Aspose.Slides for C++ 现在支持 Pie of Pie 或 Bar of Pie 图表的次要绘图选项。在本主题中，我们将通过示例展示如何使用 Aspose.Slides 指定这些选项。请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的次要绘图选项。
1. 将演示文稿写入磁盘。

在下面的示例中，我们设置了 Pie of Pie 图表的不同属性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **设置自动饼图切片颜色**
Aspose.Slides for C++ 提供了一个简单的 API 用于设置自动饼图切片颜色。示例代码演示了上述属性的设置。

1. 创建 Presentation 类的实例。
1. 访问第一张幻灯片。
1. 添加默认数据的图表。
1. 设置图表标题。
1. 将第一个系列设置为显示数值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**是否支持 'Pie of Pie' 和 'Bar of Pie' 变体？**

是的，库[支持](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/) 饼图的次要绘图，包括 'Pie of Pie' 和 'Bar of Pie' 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以[将图表本身导出为图像](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getimage/)（如 PNG），而无需导出整个演示文稿。