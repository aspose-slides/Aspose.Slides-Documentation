---
title: 在演示文稿中使用 C++ 定制 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/cpp/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "学习如何在 Aspose.Slides for C++ 中创建和定制 3D 图表，支持 PPT 和 PPTX 文件——立即提升您的演示文稿。"
---
## **概述**

本文说明如何通过配置 `Rotation3D` 设置（例如 `RotationX`、`RotationY`、`DepthPercents` 和 `RightAngleAxes`）来自定义 Aspose.Slides 中的 3D 图表。文章将演示创建演示文稿、添加带默认数据的 3D 图表、应用所需的 3D 视图设置，并将修改后的演示文稿保存为 PPTX 文件的全过程。

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for C++ 提供了简单的 API 来设置这些属性。以下文章将帮助您设置 X、Y 旋转、**DepthPercents** 等不同属性。示例代码演示了对上述属性的设置。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加带默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。有关完整且最新的列表，请查阅您所安装版本的 API 参考中的 [ChartType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/charttype/) 成员。

**我能为报告或网页获取 3D 图表的光栅图像吗？**

可以。您可以通过 [chart API](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getimage/) 将图表导出为图像，或将整个幻灯片[/slides/zh/cpp/convert-powerpoint-to-png/] 渲染为 PNG、JPEG 等格式。这在需要像素级预览或将图表嵌入文档、仪表板或网页且无需 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量保持 3D 效果最小化，避免在墙壁和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出设置为适当的分辨率和尺寸，以匹配目标显示或打印需求。