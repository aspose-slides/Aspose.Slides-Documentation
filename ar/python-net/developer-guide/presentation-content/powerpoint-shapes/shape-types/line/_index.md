---
title: إنشاء أشكال الخط في العروض التقديمية باستخدام بايثون
linktitle: خط
type: docs
weight: 50
url: /ar/python-net/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين الخط
- تخصيص الخط
- نمط الشرط
- رأس السهم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Python via .NET. اكتشف الخصائص والطرق والأمثلة."
---

## **نظرة عامة**

يُدعم Aspose.Slides for Python via .NET إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال بإضافة خطوط إلى الشرائح. باستخدام Aspose.Slides، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضاً رسم خطوط مزخرفة على الشرائح.

## **إنشاء خطوط عادية**

استخدم Aspose.Slides لإضافة خط عادي إلى شريحة كفاصل بسيط أو موصل. لإضافة خط عادي إلى شريحة محددة في عرض تقديمي، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة الفهرس.
3. إضافة [الشكل التلقائي](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [مجموعة الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) .
4. حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، يتم إضافة خط إلى الشريحة الأولى من العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation.
with slides.Presentation() as presentation:

    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **إنشاء خطوط على شكل أسهم**

يتيح لك Aspose.Slides تكوين خصائص الخط لجعلها أكثر جاذبية بصريًا. أدناه، نقوم بتكوين بعض خصائص الخط لجعله يبدو كسهم. اتبع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى شريحة بواسطة الفهرس.
3. إضافة [الشكل التلقائي](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [مجموعة الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) .
4. ضبط [نمط الخط](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) .
5. ضبط عرض الخط.
6. ضبط [نمط الشرطرة للخط](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) .
7. ضبط [نمط رأس السهم](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) وطوله لنقطة بداية الخط.
8. ضبط نمط رأس السهم وطوله لنقطة نهاية الخط.
9. حفظ العرض التقديمي كملف PPTX.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع LINE.
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


## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "ينتكِ" إلى الأشكال؟**

لا. الخط العادي (وهو [الشكل التلقائي](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله ينتكِ إلى الأشكال، استخدم نوع [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) المخصص و[واجهات برمجة التطبيقات المقابلة](/slides/ar/python-net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة وكان من الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/python-net/shape-effective-properties/) عبر صنفي [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/)—فهذه الصنوف تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل خط لمنعه من التعديل (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات [قفل](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) تتيح لك [منع عمليات التعديل](/slides/ar/python-net/applying-protection-to-presentation/).