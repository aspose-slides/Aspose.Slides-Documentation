---
title: تخصيص مخططات الدونات في العروض التقديمية في .NET
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/net/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides لـ .NET، مع دعم تنسيقات PowerPoint للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إضافة مخطط دونات إلى الشريحة.
- تحديد حجم الفتحة في مخطط الدونات.
- كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتحديد حجم الفتحة في مخطط الدونات.
```c#
// إنشاء مثيل لفئة Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// كتابة العرض التقديمي إلى القرص
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟**

نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات حسب ترتيب السلاسل في المجموعة.

**هل يتم دعم الدونات "المتفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط دونات متفجر [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) وخاصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تحويله إلى [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو تصدير المخطط إلى [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).