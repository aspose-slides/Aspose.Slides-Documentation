---
title: تخصيص المخططات الدائرية في العروض التقديمية باستخدام بايثون
linktitle: مخطط دائري
type: docs
weight: 30
url: /ar/python-net/doughnut-chart/
keywords:
- مخطط دائري
- فجوة مركزية
- حجم الفتحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص المخططات الدائرية في Aspose.Slides for Python via .NET، مع دعم تنسيقات PowerPoint و OpenDocument للعروض التقديمية الديناميكية."
---

## **تحديد الفجوة المركزية في المخطط الدائري**  
لتحديد حجم الفتحة في المخطط الدائري، يرجى اتباع الخطوات التالية:

- إنشاء مثيل فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- إضافة مخطط دائري إلى الشريحة.
- تحديد حجم الفتحة في المخطط الدائري.
- حفظ العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتعيين حجم الفتحة في المخطط الدائري.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يمكنني إنشاء مخطط دائري متعدد المستويات مع حلقات متعددة؟**

نعم. أضف سلاسل متعددة إلى مخطط دائري واحد—كل سلسلة تصبح حلقة مستقلة. يتم تحديد ترتيب الحلقات وفقًا لترتيب السلاسل في المجموعة.

**هل يدعم المخطط الدائري "المتفجر" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [Exploded Doughnut](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) وخصائص الانفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة للمخطط الدائري (PNG/SVG) لتضمينها في تقرير؟**

المخطط هو شكل؛ يمكنك تحويله إلى [raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) أو تصديره كصورة [SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/).