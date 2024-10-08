---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /ar/net/export-chart/
keywords:
- رسم بياني
- صورة الرسم البياني
- استخراج صورة الرسم البياني
- باوربوينت
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "الحصول على صور الرسوم البيانية من عروض باوربوينت باستخدام C# أو .NET"
---

## **احصل على صورة الرسم البياني**
توفر Aspose.Slides for .NET دعمًا لاستخراج صورة رسم بياني محدد. مثال عينة أدناه.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```