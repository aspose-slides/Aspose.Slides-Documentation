---
title: إضافة مستطيلات إلى العروض التقديمية في .NET
linktitle: مستطيل
type: docs
weight: 80
url: /ar/net/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "عزز عروض PowerPoint التقديمية بإضافة مستطيلات باستخدام Aspose.Slides for .NET—صمم وعدل الأشكال برمجياً بسهولة."
---

## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، يتناول هذا الموضوع أيضًا إضافة شكل، وهذه المرة سنناقش الشكل المستطيل. في هذا الموضوع، شرحنا كيفية إضافة مستطيلات بسيطة أو منسقة إلى الشرائح باستخدام Aspose.Slides for .NET. لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع الشريحة باستخدام فهرستها Index.
1. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، أضفنا مستطيلًا بسيطًا إلى الشريحة الأولى من العرض التقديمي.
```c#
 // إنشاء فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //اكتب ملف PPTX إلى القرص
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء مستطيل مُنسق**
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع الشريحة باستخدام فهرستها Index.
1. إضافة IAutoShape من نوع Rectangle باستخدام طريقة AddAutoShape التي يوفرها كائن IShapes.
1. تعيين نوع التعبئة للمستطيل إلى Solid.
1. تعيين لون المستطيل باستخدام الخاصية SolidFillColor.Color كما هو معروض في كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط المستطيل.
1. تعيين عرض خطوط المستطيل.
1. كتابة العرض التقديمي المعدل كملف PPTX.

الخطوات السابقة مطبقة في المثال الموضح أدناه.
```c#
 // إنشاء فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من نوع المستطيل
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // تطبيق بعض التنسيقات على شكل المستطيل
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // تطبيق بعض التنسيقات على خط المستطيل
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //اكتب ملف PPTX إلى القرص
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني إضافة مستطيل بزوايا مدورة؟**

استخدم نوع الشكل بزوايا مدورة [نوع الشكل](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) وقم بضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التدوير لكل زاوية عبر تعديلات الهندسة.

**كيف أقوم بملء مستطيل بصورة (نقش)؟**

حدد نوع ملء الصورة [نوع الملء](https://reference.aspose.com/slides/net/aspose.slides/filltype/)، زود المصدر بالصورة، واضبط أوضاع [التمدد/التبليط](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. الظلال الخارجية/الداخلية، التوهج، والحواف الناعمة [/slides/net/shape-effect/] متاحة مع معلمات قابلة للتعديل.

**هل يمكن تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. يمكنك [تعيين ارتباط تشعبي](/slides/ar/net/manage-hyperlinks/) للنقر على الشكل (للانتقال إلى شريحة، ملف، عنوان ويب أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك والتعديل؟**

استخدم [قفل الشكل](/slides/ar/net/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار أو تعديل النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [تصدير الشكل كصورة](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) بحجم/مقياس محدد أو [تصديره كـ SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) للاستخدام المتجهي.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمات والوراثة؟**

استخدم [الخصائص الفعّالة للشكل](/slides/ar/net/shape-effective-properties/): تُرجع الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط والإعدادات المحلية، مما يبسط تحليل التنسيقات.