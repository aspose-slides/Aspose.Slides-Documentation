---
title: إنشاء أشكال خطية في العروض التقديمية باستخدام بايثون
linktitle: خط
type: docs
weight: 50
url: /ar/python-net/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط بسيط
- تكوين خط
- تخصيص خط
- نمط الشرطة
- رأس السهم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرّف على كيفية معالجة تنسيق الخطوط في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. اكتشف الخاصيات، الطرق، والأمثلة."
---

## **نظرة عامة**

يدعم Aspose.Slides لبايثون عبر .NET إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم خطوط مزخرفة على الشرائح.

## **إنشاء خطوط بسيطة**

استخدم Aspose.Slides لإضافة خط بسيط إلى شريحة كفاصل أو موصل. لإضافة خط بسيط إلى شريحة مختارة في عرض تقديمي، اتبع الخطوات التالية:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة حسب الفهرس.
1. أضف [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. احفظ العرض التقديمي كملف PPTX.

في المثال أدناه، يتم إضافة خط إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء خطوط على شكل سهم**

يوفر Aspose.Slides إمكانية تكوين خصائص الخط لجعله أكثر جاذبية بصريًا. أدناه، نقوم بتكوين بعض خصائص الخط ليظهر على شكل سهم. اتبع الخطوات التالية:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى شريحة حسب الفهرس.
1. أضف [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. اضبط [نمط الخط](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
1. اضبط عرض الخط.
1. اضبط [نمط الشرطة المتقطعة](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
1. اضبط نمط وطول رأس السهم لنقطة بدء الخط.
1. اضبط نمط وطول رأس السهم لنقطة نهاية الخط.
1. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة AutoShape من النوع LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # تطبيق تنسيق على الخط.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "ينقض" إلى الأشكال؟**

لا. الخط العادي ([AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله ينقض إلى الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) و[واجهات برمجة التطبيقات المقابلة](/slides/ar/python-net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/python-net/shape-effective-properties/) عبر الفئتين [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/). هذه الفئات تحتسب بالفعل الوراثة وأنماط السمة.

**هل يمكنني قفل الخط ضد التحرير (التحريك، تغيير الحجم)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) التي تسمح لك [بحظر عمليات التحرير](/slides/ar/python-net/applying-protection-to-presentation/).