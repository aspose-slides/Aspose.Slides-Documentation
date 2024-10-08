---
title: مخطط الدونات
type: docs
weight: 30
url: /ar/net/doughnut-chart/
keywords: "مخطط الدونات، ثقب الوسط، عرض PowerPoint، C#، Csharp، Aspose.Slides لإطار عمل .NET"
description: "تحديد ثقب الوسط في مخطط الدونات في عرض PowerPoint باستخدام C# أو .NET"
---

## **تحديد ثقب الوسط في مخطط الدونات**
لتحديد حجم الثقب في مخطط الدونات. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إضافة مخطط دونات على الشريحة.
- تحديد حجم الثقب في مخطط الدونات.
- كتابة العرض إلى القرص.

في المثال المعطى أدناه، قمنا بتحديد حجم الثقب في مخطط الدونات.

```c#
// إنشاء مثيل من فئة Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// كتابة العرض إلى القرص
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```