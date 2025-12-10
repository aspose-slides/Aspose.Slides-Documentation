---
title: 使用 C++ 在演示文稿中自定义 3D 图表
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
description: "了解如何在 Aspose.Slides for C++ 中创建和自定义 3D 图表，支持 PPT 和 PPTX 文件——立即提升您的演示文稿。"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for C++ 提供了用于设置这些属性的简易 API。下面的文章将帮助您设置诸如 X、Y 旋转、**DepthPercents** 等不同属性。示例代码演示了设置上述属性的方式。

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **常见问题**

**Aspose.Slides 支持哪些图表类型的 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)枚举公开的相关 3D 类型。要获取准确且最新的列表，请检查您安装的版本的 API 参考中的[ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)成员。

**我能获得 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以通过[chart API](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/)将图表导出为图像，或[渲染整个幻灯片](/slides/zh/cpp/convert-powerpoint-to-png/)为 PNG、JPEG 等格式。当需要像素级预览或将图表嵌入文档、仪表板或网页而不依赖 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将输出渲染为适当尺寸（分辨率和尺寸），以匹配目标显示或打印需求。