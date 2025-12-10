---
title: 在 C++ 中导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/cpp/export-chart/
keywords:
- 图表
- 图表转图像
- 图表为图像
- 提取图表图像
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 导出演示文稿图表，支持 PPT 和 PPTX 格式，并将报告流程简化到任何工作流中。"
---

## **获取图表图像**
Aspose.Slides for C++ 提供了提取特定图表图像的支持。下面给出示例。
```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **常见问题**

**我能将图表导出为矢量（SVG）而不是光栅图像吗？**

是的。图表是一个形状，其内容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/)保存为 SVG。

**如何以像素为单位设置导出图表的精确大小？**

使用允许指定大小或比例的 image-rendering 重载——库支持按给定的尺寸/比例渲染对象。

**如果导出后标签和图例中的字体显示不正确，我该怎么办？**

通过[FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)使用[加载所需字体](/slides/zh/cpp/custom-font/)，以便图表渲染保留度量和文本外观。

**导出是否遵守 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），因此图表的外观得以保留。

**在哪里可以找到除图表图像之外的可用渲染/导出功能？**

请参阅 [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[文档](/slides/zh/cpp/convert-powerpoint/) 的导出部分，了解输出目标（[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)，等等）以及相关渲染选项。