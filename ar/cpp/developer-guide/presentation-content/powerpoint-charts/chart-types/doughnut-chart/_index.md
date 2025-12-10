---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام С++
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/cpp/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الثقب
- PowerPoint
- العرض التقديمي
- С++
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides لـ С++، مع دعم صيغ PowerPoint للعروض التقديمية الديناميكية."
---

## **حدد الفجوة المركزية في مخطط الدونات**
لتحديد حجم الثقب في مخطط الدونات. يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- إضافة مخطط دونات إلى الشريحة.
- تحديد حجم الثقب في مخطط الدونات.
- كتابة العرض التقديمي إلى القرص.

في المثال الموضح أدناه، قمنا بتعيين حجم الثقب في مخطط الدونات.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**هل يمكنني إنشاء دونات متعددة المستويات مع حلقات متعددة؟**

نعم. أضف سلاسل متعددة إلى مخطط الدونات الواحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات وفقًا لترتيب السلاسل في المجموعة.

**هل يتم دعم الدونات "المتفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) الدونات المتفجرة وميزة الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تصييره إلى [raster image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) أو تصدير المخطط إلى [SVG image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).