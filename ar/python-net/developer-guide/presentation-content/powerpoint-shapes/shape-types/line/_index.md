---
title: خط
type: docs
weight: 50
url: /ar/python-net/line/
keywords: "خط, شكل باوربوينت, عرض باوربوينت, بايثون, Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة خط في عرض باوربوينت في بايثون"
---

يدعم Aspose.Slides لـ بايثون عبر .NET إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال من خلال إضافة الخطوط إلى الشرائح. باستخدام Aspose.Slides لـ بايثون عبر .NET، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، ولكن يمكن أيضًا رسم بعض الخطوط الزخرفية على الشرائح.
## **إنشاء خط بسيط**
لإضافة خط بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات أدناه:

- أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- احصل على مرجع لشريحة باستخدام الفهرس الخاص بها.
- أضف شكل تلقائي من نوع خط باستخدام طريقة [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) المعروضة بواسطة كائن الأشكال.
- قم بكتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة PresentationEx التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع خط
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # كتابة ملف PPTX على القرص
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء خط على شكل سهم**
يتيح Aspose.Slides لـ بايثون عبر .NET أيضًا للمطورين تكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. دعنا نحاول تكوين بعض الخصائص لجعل الخط يبدو كالسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- احصل على مرجع لشريحة باستخدام الفهرس الخاص بها.
- أضف شكل تلقائي من نوع خط باستخدام طريقة AddAutoShape المعروضة بواسطة كائن الأشكال.
- قم بتعيين نمط الخط إلى أحد الأنماط المعروضة بواسطة Aspose.Slides لـ بايثون عبر .NET.
- قم بتعيين عرض الخط.
- قم بتعيين [نمط الخط المنقّط](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) للخط إلى أحد الأنماط المعروضة بواسطة Aspose.Slides لـ بايثون عبر .NET.
- قم بتعيين [نمط رأس السهم](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) وطول نقطة البداية للخط.
- قم بتعيين نمط رأس السهم وطول نقطة النهاية للخط.
- قم بكتابة العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثيل لفئة PresentationEx التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع خط
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # تطبيق بعض التنسيقات على الخط
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # كتابة ملف PPTX على القرص
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```