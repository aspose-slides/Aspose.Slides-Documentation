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
- إهليلج منسق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق وتعديل أشكال الإهليلج في Aspose.Slides for Python via .NET عبر عروض PPT و PPTX و ODP — تشمل أمثلة التعليمات البرمجية."
---

## **إنشاء إهليلج**
في هذا الموضوع، سنعرّف المطورين على إضافة أشكال إهليلجية إلى الشرائح باستخدام Aspose.Slides for Python via .NET. توفر Aspose.Slides for Python via .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشيفرة فقط. لإضافة إهليلج بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)فئة
1. الحصول على مرجع شريحة باستخدام Index
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape المتوفرة في كائن IShapes
1. كتابة العرض التقديمي المعدل كملف PPTX

في المثال الموضح أدناه، أضفنا إهليلجًا إلى الشريحة الأولى.
```py
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة AutoShape من نوع إهليلج
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #حفظ ملف PPTX إلى القرص
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)فئة
1. الحصول على مرجع شريحة باستخدام Index
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape المتوفرة في كائن IShapes
1. ضبط نوع التعبئة للإهليلج إلى Solid
1. ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color المتوفرة في كائن FillFormat المرتبط بكائن IShape
1. ضبط لون خطوط الإهليلج
1. ضبط عرض خطوط الإهليلج
1. كتابة العرض التقديمي المعدل كملف PPTX

في المثال الموضح أدناه، أضفنا إهليلجًا منسقًا إلى الشريحة الأولى من العرض التقديمي.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء نسخة من فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة AutoShape من نوع إهليلج
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # تطبيق بعض التنسيق على شكل الإهليلج
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # تطبيق بعض التنسيق على خط الإهليلج
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #حفظ ملف PPTX إلى القرص
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**كيف يمكنني ضبط الموضع الدقيق وحجم الإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، احسب بناءً على حجم الشريحة وحول المليمترات أو الإنش المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت عناصر أخرى (التحكم في ترتيب التراص)؟**

عدل ترتيب الرسم للعنصر عن طريق إحضاره إلى الأمام أو إرساله إلى الخلف. يتيح ذلك للإهليلج أن يتداخل مع العناصر الأخرى أو يكشف ما تحتها.

**كيف يمكنني تحريك ظهور أو إبراز الإهليلج؟**

[تطبيق](/slides/ar/python-net/shape-animation/) تأثيرات الدخول أو التأكيد أو الخروج على الشكل، وقم بتكوين المشغلات والتوقيت لتحديد متى وكيفية تشغيل الرسوم المتحركة.