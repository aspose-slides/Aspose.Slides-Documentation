---
title: إضافة المستطيلات إلى العروض التقديمية في بايثون
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
description: "عزز عروض PowerPoint و OpenDocument التقديمية بإضافة مستطيلات باستخدام Aspose.Slides لبايثون عبر .NET—صمّم وعدّل الأشكال برمجيًا بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides for Python عبر .NET. لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة IAutoShape من النوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء فئة Presentation التي تمثل PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع مستطيل
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #كتابة ملف PPTX إلى القرص
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إنشاء مستطيل منسق**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. إضافة IAutoShape من النوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. تعيين نوع التعبئة للمستطيل إلى Solid.
1. تعيين لون المستطيل باستخدام خاصية SolidFillColor.Color التي يوفرها كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط المستطيل.
1. تعيين عرض خطوط المستطيل.
1. كتابة العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات السابقة في المثال المعطى أدناه.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء فئة Presentation التي تمثل ملف PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع مستطيل
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # تطبيق بعض التنسيق على شكل المستطيل
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # تطبيق بعض التنسيق على خط المستطيل
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #كتابة ملف PPTX إلى القرص
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) ذو الزوايا المستديرة واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التقريب على كل زاوية عبر تعديل الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**

حدد [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للصور، قدم مصدر الصورة، وقم بتكوين [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) حسب الحاجة.

**هل يمكن للمستطيل أن يكون له ظل وتوهج؟**

نعم. [Outer/inner shadow, glow, and soft edges](/slides/ar/python-net/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [Assign a hyperlink](/slides/ar/python-net/manage-hyperlinks/) للنقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من الحركة والتعديلات؟**

[Use shape locks](/slides/ar/python-net/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) للاستخدام المتجهي.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة الثيم والوراثة؟**

[Use the shape’s effective properties](/slides/ar/python-net/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط الثيم، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.