---
title: تخصيص مخططات الدونات في العروض التقديمية باستخدام بايثون
linktitle: مخطط الدونات
type: docs
weight: 30
url: /ar/python-net/doughnut-chart/
keywords:
- مخطط الدونات
- الفجوة المركزية
- حجم الفتحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص مخططات الدونات في Aspose.Slides لبايثون عبر .NET، مع دعم صيغ PowerPoint وOpenDocument للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في مخطط الدونات**
للتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- إضافة مخطط دونات إلى الشريحة.
- تحديد حجم الفتحة في مخطط الدونات.
- حفظ العرض التقديمي إلى القرص.

في المثال التالي، قمنا بتعيين حجم الفتحة في مخطط الدونات.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # حفظ العرض التقديمي إلى القرص
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعدد المستويات مع حلقات متعددة؟**

نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—كل سلسلة تصبح حلقة منفصلة. يتم تحديد ترتيب الحلقات بحسب ترتيب السلاسل في المجموعة.

**هل يتم دعم "دونات متفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) وخصائص انفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقرير؟**

المخطط هو شكل؛ يمكنك تصييره إلى [raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) أو تصديره إلى صورة [SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).