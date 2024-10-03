---
title: Export Chart
type: docs
weight: 90
url: /cpp/export-chart/
keywords:
- chart
- chart image
- extract chart image
- PowerPoint
- presentation
- C++
- Aspose.Slides for C++
description: "Get chart images from PowerPoint presentations in C++"
---

## **Get Chart Image**
Aspose.Slides for C++ provides support for extracting image of specific chart. Below sample example is given. 

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```
