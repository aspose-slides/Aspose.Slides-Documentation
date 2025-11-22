---
title: مخطط الدونات
type: docs
weight: 30
url: /ar/net/doughnut-chart/
keywords: "مخطط دونات، فجوة مركزية، عرض تقديمي لبرنامج PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "تحديد الفجوة المركزية في مخطط الدونات في عرض تقديمي لبرنامج PowerPoint باستخدام C# أو .NET"
---

## **تحديد الفجوة المركزية في مخطط الدونات**
لتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

- إنشاء فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إضافة مخطط دونات إلى الشريحة.
- تحديد حجم الفتحة في مخطط الدونات.
- حفظ العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتحديد حجم الفتحة في مخطط الدونات.
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
نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات حسب ترتيب السلاسل في المجموعة.

**هل يتم دعم الدونات "المتفجرة" (شرائح منفصلة)؟**
نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) وخصيصة الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**
المخطط هو شكل؛ يمكنك تحويله إلى [صورة نقطية](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو تصديره إلى [صورة SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).