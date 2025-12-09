---
title: إضافة إهليلجات إلى العروض التقديمية في .NET
linktitle: إهليلج
type: docs
weight: 30
url: /ar/net/ellipse/
keywords:
- إهليلج
- شكل
- إضافة إهليلج
- إنشاء إهليلج
- رسم إهليلج
- إهليلج منسق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق وتعديل أشكال الإهليلج في Aspose.Slides للـ .NET عبر عروض PPT و PPTX — يتضمن أمثلة كود C#."
---

## **إنشاء إهليلج**
في هذا القسم، سنعرّف المطورين على كيفية إضافة أشكال إهليلج إلى الشرائح باستخدام Aspose.Slides for .NET. توفر Aspose.Slides for .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال ببضع أسطر من الشفرة فقط. لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. الحصول على مرجع شريحة باستخدام فهرسها Index
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape التي يُقدِّمها كائن IShapes
1. كتابة العرض التقديمي المعدَّل كملف PPTX

في المثال أدناه، أضفنا إهليلجًا إلى الشريحة الأولى.
```c#
// إنشاء فئة Prseetation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من نوع إهليلج
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //اكتب ملف PPTX إلى القرص
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بصورة أفضل إلى شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع شريحة باستخدام فهرسها Index.
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape التي يُقدِّمها كائن IShapes.
1. ضبط Fill Type للإهليلج إلى Solid.
1. تعيين لون الإهليلج باستخدام الخاصية SolidFillColor.Color التي يُقدِّمها كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط الإهليلج.
1. ضبط عرض خطوط الإهليلج.
1. كتابة العرض التقديمي المعدَّل كملف PPTX.

في المثال أدناه، أضفنا إهليلجًا منسقًا إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء فئة Prseetation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // احصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // أضف autoshape من نوع إهليلج
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل الإهليلج
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // تطبيق بعض التنسيق على خط الإهليلج
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // كتابة ملف PPTX إلى القرص
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني تحديد الموضع الدقيق وحجم الإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما تُحدَّد الإحداثيات والأحجام **بالنقاط**. للحصول على نتائج متوقعة، احسب بناءً على حجم الشريحة وحوِّل المليمترات أو البوصات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع الإهليلج فوق أو أسفل كائنات أخرى (التحكم في ترتيب الطبقات)؟**

عدِّل ترتيب الرسم للكائن عن طريق إحضاره إلى الأمام أو إرساله إلى الخلف. يتيح ذلك للإهليلج أن يغطِّي كائنات أخرى أو يُظهر ما تحته.

**كيف يمكنني تحريك ظهور أو إبراز الإهليلج؟**

[Apply](/slides/ar/net/shape-animation/) تأثيرات دخول أو إبراز أو خروج على الشكل، واضبط المشغلات والتوقيت لتحديد متى وكيف يُنفَّذ التحريك.