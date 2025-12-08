---
title: إهليلج
type: docs
weight: 30
url: /ar/net/ellipse/
keywords: "إهليلج, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إنشاء إهليلج في عرض PowerPoint باستخدام C# أو .NET"
---

## **إنشاء إهليلج**
في هذا الموضوع، سنقدم للمطورين طريقة إضافة أشكال إهليلج إلى شرائحهم باستخدام Aspose.Slides for .NET. يوفر Aspose.Slides for .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال بضعة أسطر من الشيفرة فقط. لإضافة إهليلج بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes
1. كتابة العرض التقديمي المعدل كملف PPTX

في المثال الموضح أدناه، قمنا بإضافة إهليلج إلى الشريحة الأولى.
```c#
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل AutoShape من نوع إهليلج
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // حفظ ملف PPTX إلى القرص
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع Ellipse باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes.
1. ضبط نوع التعبئة للإهليلج إلى Solid.
1. ضبط لون الإهليلج باستخدام الخاصية SolidFillColor.Color المعروضة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. ضبط لون خطوط الإهليلج.
1. ضبط عرض خطوط الإهليلج.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة إهليلج منسق إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من نوع إهليلج
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل الإهليلج
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // تطبيق بعض التنسيق على خط الإهليلج
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //احفظ ملف PPTX إلى القرص
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**كيف يمكنني ضبط الموضع الدقيق وحجم إهليلج بالنسبة إلى وحدات الشريحة؟**

عادةً ما يتم تحديد الإحداثيات والأحجام **in points**. للحصول على نتائج متوقعة، قم بعمل حساباتك بناءً على حجم الشريحة وحول المليمترات أو البوصات المطلوبة إلى نقاط قبل تعيين القيم.

**كيف يمكنني وضع إهليلج فوق أو تحت كائنات أخرى (التحكم في ترتيب التكدس)؟**

قم بتعديل ترتيب رسم الكائن عن طريق إحضاره إلى المقدمة أو إرساله إلى الخلف. هذا يسمح للإهليلج بالتراكب على كائنات أخرى أو إظهار ما تحتها.

**كيف يمكنني تحريك ظهور أو إبراز إهليلج؟**

استخدام [تطبيق](/slides/ar/net/shape-animation/) لتأثيرات الدخول أو الإبراز أو الخروج على الشكل، وتكوين المشغلات والتوقيت لتحديد متى وكيف يتم تشغيل الرسوم المتحركة.