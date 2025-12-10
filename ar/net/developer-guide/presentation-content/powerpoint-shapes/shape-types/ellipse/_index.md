---
title: إضافة أشكال إهليلجية إلى العروض التقديمية في .NET
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
description: "تعلم كيفية إنشاء وتنسيق ومعالجة أشكال الإهليلج في Aspose.Slides for .NET عبر عروض PPT و PPTX — تشمل أمثلة كود C#."
---

## **إنشاء إهليلج**
في هذا الموضوع، سنقدم للمطورين طريقة إضافة أشكال إهليلجية إلى الشرائح باستخدام Aspose.Slides for .NET. توفر Aspose.Slides for .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال بضع أسطر من الكود فقط. لإضافة إهلال بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
3. إضافة AutoShape من النوع Ellipse باستخدام طريقة AddAutoShape المتاحة عبر كائن IShapes
4. كتابة العرض التقديمي المعدل كملف PPTX

في المثال أدناه، تم إضافة إهليلج إلى الشريحة الأولى.
```c#
 // إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
 using (Presentation pres = new Presentation())
 {
 
     // الحصول على الشريحة الأولى
     ISlide sld = pres.Slides[0];
 
     // إضافة AutoShape من نوع Ellipse
     sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
 
     // كتابة ملف PPTX إلى القرص
     pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
 }
```


## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. إضافة AutoShape من النوع Ellipse باستخدام طريقة AddAutoShape المتاحة عبر كائن IShapes.
4. ضبط نوع التعبئة للإهليلج إلى Solid.
5. ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color المتاحة عبر كائن FillFormat المرتبط بكائن IShape.
6. ضبط لون خطوط الإهليلج.
7. ضبط عرض خطوط الإهليلج.
8. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، تم إضافة إهليلج منسق إلى الشريحة الأولى من العرض التقديمي.
```c#
 // إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من نوع Ellipse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيقات على شكل الإهليلج
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // تطبيق بعض التنسيقات على خط الإهليلج
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // كتابة ملف PPTX إلى القرص
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**كيف يمكنني ضبط الموقع والحجم الدقيق لإهليلج بالنسبة لوحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **بالنقطة**. للحصول على نتائج متوقعة، احسب بناءً على حجم الشريحة وحول المليمترات أو البوصات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم بترتيب التكديس)؟**

قم بتعديل ترتيب الرسم للكائن عن طريق إحضاره إلى الأمام أو إرساله إلى الخلف. يتيح ذلك للإهليلج التداخل مع كائنات أخرى أو إظهار ما تحتها.

**كيف أقوم بتحريك ظهور أو إبراز إهليلج؟**

[Apply](/slides/ar/net/shape-animation/) تأثيرات الدخول أو الإبراز أو الخروج إلى الشكل، وقم بتكوين المشغلات والتوقيت لتحديد متى وكيف تُنفّذ الرسوم المتحركة.