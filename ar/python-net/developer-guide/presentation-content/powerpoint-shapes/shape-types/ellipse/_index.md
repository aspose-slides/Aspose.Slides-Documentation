---
title: إضافة إهليلجات إلى العروض التقديمية في بايثون
linktitle: إهليلج
type: docs
weight: 30
url: /ar/python-net/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج مُنسق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق ومعالجة أشكال الإهليلج في Aspose.Slides for Python via .NET عبر عروض PPT وPPTX وODP — مع أمثلة على الشيفرة."
---

## **إنشاء إهليلج**
في هذا الموضوع، سنعرّف المطورين على إضافة أشكال إهليلج إلى شرائحهم باستخدام Aspose.Slides for Python via .NET. توفر Aspose.Slides for Python via .NET مجموعة أسهل من الـ APIs لرسم أنواع مختلفة من الأشكال ببضع سطور من الشيفرة فقط. لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
2. الحصول على مرجع لشريحة باستخدام فهرستها
3. إضافة AutoShape من نوع إهليلج باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes
4. كتابة العرض التقديمي المعدل كملف PPTX

في المثال أدناه، قمنا بإضافة إهليلج إلى الشريحة الأولى.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة AutoShape من نوع إهليلج
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء إهليلج مُنسق**
لإضافة إهليلج مُنسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
2. الحصول على مرجع لشريحة باستخدام فهرستها
3. إضافة AutoShape من نوع إهليلج باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes
4. ضبط نوع التعبئة للإهليلج إلى صلب
5. ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color التي يوفرها كائن FillFormat المرتبط بكائن IShape
6. ضبط لون خطوط الإهليلج
7. ضبط عرض خطوط الإهليلج
8. كتابة العرض التقديمي المعدل كملف PPTX

في المثال أدناه، قمنا بإضافة إهليلج مُنسق إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation الذي يمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة AutoShape من نوع إهليلج
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # تطبيق بعض التنسيقات على شكل الإهليلج
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # تطبيق بعض التنسيقات على خط الإهليلج
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # كتابة ملف PPTX إلى القرص
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**كيف يمكنني تحديد الموضع الدقيق وحجم الإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما تُحدد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، احسب القيم بناءً على حجم الشريحة وحول المليمترات أو الإنشات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم في ترتيب الطبقات)؟**

قم بتعديل ترتيب الرسم للكائن عن طريق إرساله إلى المقدمة أو إرساله إلى الخلف. هذا يسمح للإهليلج بأن يتراكب مع كائنات أخرى أو يكشف الكائنات التي تحته.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

[تطبيق](/slides/ar/python-net/shape-animation/) تأثيرات الدخول أو التأكيد أو الخروج على الشكل، وتكوين المشغلات والتوقيت لتنسيق متى وكيف يُعرض التحريك.