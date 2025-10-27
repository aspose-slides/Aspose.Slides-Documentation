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
- خط بسيط
- تكوين خط
- تخصيص خط
- نمط الشرط
- رأس السهم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. اكتشف الخصائص والطرق والأمثلة."
---

## **نظرة عامة**

يدعم Aspose.Slides للبايثون عبر .NET إضافة أشكال مختلفة إلى الشرائح. في هذا القسم، سنبدأ العمل بالأشكال عبر إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل أيضًا رسم خطوط متميزة على الشرائح.

## **إنشاء خطوط بسيطة**

استخدم Aspose.Slides لإضافة خط بسيط إلى شريحة كفاصل أو موصل. لإضافة خط بسيط إلى شريحة مختارة في عرض تقديمي، اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة حسب الفهرس.
3. أضف [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. احفظ العرض التقديمي كملف PPTX.

في المثال أدناه، يُضاف خط إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء خطوط على شكل أسهم**

يسمح Aspose.Slides لك بتكوين خصائص الخط لجعله أكثر جاذبية بصريًا. أدناه، نقوم بتكوين بعض خصائص الخط لجعله يبدو كسهم. اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع إلى شريحة حسب الفهرس.
3. أضف [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `LINE` باستخدام طريقة `add_auto_shape` على كائن [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. اضبط [نمط الخط](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. اضبط عرض الخط.
6. اضبط [نمط الشرط](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) للخط.
7. اضبط نمط وطول رأس السهم لنقطة بداية الخط عبر [arrowhead style](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/).
8. اضبط نمط وطول رأس السهم لنقطة نهاية الخط.
9. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "ينجذب" إلى الأشكال؟**

لا. الخط العادي ([AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله ينجذب إلى الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) وواجهات البرمجة [المقابلة](/slides/ar/python-net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط ورثة من السمة ويصعب تحديد القيم النهائية؟**

اقرأ [الخصائص الفعّالة](/slides/ar/python-net/shape-effective-properties/) عبر الفئات [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)، [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/). فهي تأخذ في الحسبان الوراثة وأنماط السمة.

**هل يمكنني قفل خط ضد التعديل (التحريك، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات [قفل](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) تتيح لك [منع عمليات التعديل](/slides/ar/python-net/applying-protection-to-presentation/).