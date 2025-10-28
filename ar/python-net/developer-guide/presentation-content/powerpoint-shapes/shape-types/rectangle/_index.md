---
title: إضافة مستطيلات إلى العروض التقديمية باستخدام بايثون
linktitle: مستطيل
type: docs
weight: 80
url: /ar/python-net/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتحسين عروض PowerPoint و OpenDocument التقديمية بإضافة مستطيلات باستخدام Aspose.Slides للبايثون عبر .NET — صمم وعدل الأشكال برمجيًا بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، شرحنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى الشرائح باستخدام Aspose.Slides للبايثون عبر .NET. لإضافة مستطيل بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مستطيل منسق**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. تعيين نوع التعبئة للمستطيل إلى صلبة.
1. تعيين لون المستطيل باستخدام الخاصية SolidFillColor.Color التي يوفرها كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط المستطيل.
1. تعيين عرض خطوط المستطيل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات المذكورة أعلاه في المثال التالي.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتداولة**

**كيف يمكنني إضافة مستطيل بزوايا مدورة؟**  
استخدم نوع الشكل ذو الزوايا المدورة [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) وعدل نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التدوير على كل زاوية على حدة عبر تعديل الهندسة.

**كيف أقوم بملء مستطيل بصورة (نقشة)؟**  
اختر نوع تعبئة الصورة [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)، زود مصدر الصورة، وقم بضبط أوضاع [التمدد/التكرار](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**  
نعم. تتوفر [الظل الخارجي/الداخلي، التوهج، والحواف الناعمة](/slides/ar/python-net/shape-effect/) مع إمكانية تعديل المعايير.

**هل يمكنني تحويل المستطيل إلى زر مع رابط تشعبي؟**  
نعم. يمكنك [إضافة رابط تشعبي](/slides/ar/python-net/manage-hyperlinks/) إلى النقر على الشكل (للانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحرك والتغييرات؟**  
[استخدم أقفال الشكل](/slides/ar/python-net/applying-protection-to-presentation/): يمكنك منع التحريك، إعادة القياس، التحديد، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**  
نعم. يمكنك [تحويل الشكل إلى صورة](/slides/ar/python-net/shape/get_image/) بحجم/مقياس محدد أو [تصديره كملف SVG](/slides/ar/python-net/shape/write_as_svg/) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعالة) للمستطيل مع مراعاة السمة والوراثة؟**  
[استخدم الخصائص الفعالة للشكل](/slides/ar/python-net/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.