---
title: 导出图表
type: docs
weight: 90
url: /cpp/export-chart/
keywords:
- 图表
- 图表图像
- 提取图表图像
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for C++
description: "在 C++ 中从 PowerPoint 演示文稿中获取图表图像"
---

## **获取图表图像**
Aspose.Slides for C++ 提供支持提取特定图表的图像。以下是示例代码。

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```