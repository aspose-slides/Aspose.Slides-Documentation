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
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides لـ .NET، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إضافة مخطط الدونات إلى الشريحة.
- تحديد حجم الفتحة في مخطط الدونات.
- كتابة العرض التقديمي إلى القرص.

في المثال المعروض أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.
```c#
// إنشاء كائن من فئة Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// حفظ العرض التقديمي إلى القرص
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟**

نعم. أضف عدة سلاسل إلى مخطط الدونات الواحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات بحسب ترتيب السلاسل في المجموعة.

**هل يدعم الدونات "المتفجر" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) وخصية الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تحويله إلى [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو تصدير المخطط إلى [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).