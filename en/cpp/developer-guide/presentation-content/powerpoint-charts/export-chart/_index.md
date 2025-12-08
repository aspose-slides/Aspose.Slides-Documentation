---
title: Export Presentation Charts in С++
linktitle: Export Chart
type: docs
weight: 90
url: /cpp/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for С++, supporting PPT and PPTX formats, and streamline reporting into any workflow."
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
