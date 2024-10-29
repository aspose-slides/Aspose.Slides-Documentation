---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /ar/cpp/export-chart/
keywords:
- رسم بياني
- صورة الرسم البياني
- استخراج صورة الرسم البياني
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides for C++
description: "احصل على صور الرسم البياني من عروض PowerPoint في C++"
---

## **احصل على صورة الرسم البياني**
تقدم Aspose.Slides for C++ دعمًا لاستخراج صورة لرسم بياني محدد. أدناه مثال بسيط.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```