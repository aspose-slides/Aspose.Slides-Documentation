---
title: إضافة مستطيلات إلى العروض التقديمية في بايثون
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
description: "عزّز عروض PowerPoint وOpenDocument الخاصة بك بإضافة مستطيلات باستخدام Aspose.Slides للبايثون عبر .NET—صمّم وعدّل الأشكال برمجياً بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى الشرائح باستخدام Aspose.Slides للبايثون عبر .NET. لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي توفرها كائن IShapes.
4. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء مثال لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع مستطيل
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # حفظ ملف PPTX إلى القرص
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء مستطيل منسق**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي توفرها كائن IShapes.
4. تعيين نوع التعبئة للمستطيل إلى Solid.
5. تعيين لون المستطيل باستخدام خاصية SolidFillColor.Color المتاحة عبر كائن FillFormat المرتبط بـ IShape.
6. تعيين لون خطوط المستطيل.
7. تعيين عرض خطوط المستطيل.
8. كتابة العرض التقديمي المعدل كملف PPTX.  
   تم تنفيذ الخطوات أعلاه في المثال أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء مثال لفئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع مستطيل
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # تطبيق بعض التنسيقات على شكل المستطيل
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # تطبيق بعض التنسيقات على خطوط المستطيل
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # حفظ ملف PPTX إلى القرص
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**  
استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) ذو الزوايا المستديرة وقم بضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التقوّس على كل زاوية على حدة عبر تعديل الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**  
اختر نوع التعبئة [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للصور، قدم مصدر الصورة، وقم بتكوين أوضاع [التمدد/التبليط](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وإضاءة؟**  
نعم. تتوفر [الظلال الخارجية/الداخلية، الإضاءة، والحواف الناعمة](/slides/ar/python-net/shape-effect/) مع إمكانية ضبط المعلمات.

**هل يمكن تحويل المستطيل إلى زر مع ارتباط تشعبي؟**  
نعم. [قم بتعيين ارتباط تشعبي](/slides/ar/python-net/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكن حماية المستطيل من التحريك والتعديل؟**  
[استخدم أقفال الشكل](/slides/ar/python-net/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكن تحويل المستطيل إلى صورة نقطية أو SVG؟**  
نعم. يمكنك [تصيير الشكل](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) إلى صورة بحجم/مقياس محدد أو [تصديره كملف SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) للاستخدام المتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**  
[استخدم الخصائص الفعّالة للشكل](/slides/ar/python-net/shape-effective-properties/): تُرجع الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.