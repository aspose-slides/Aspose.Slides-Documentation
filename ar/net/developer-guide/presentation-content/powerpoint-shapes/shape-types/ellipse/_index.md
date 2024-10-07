---
title: إهليلج
type: docs
weight: 30
url: /net/ellipse/
keywords: "إهليلج، شكل باوربوينت، عرض باوربوينت، C#، Csharp، Aspose.Slides لـ .NET"
description: "إنشاء إهليلج في عرض باوربوينت باستخدام C# أو .NET"
---


## **إنشاء إهليلج**
في هذا الموضوع، سنقدم للمطورين معلومات حول إضافة أشكال الإهليلج إلى الشرائح باستخدام Aspose.Slides لـ .NET. توفر Aspose.Slides لـ .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال باستخدام عدد قليل فقط من أسطر التعليمات البرمجية. لإضافة إهليلج بسيط إلى شريحة محددة من العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها
1. إضافة AutoShape من نوع إهليلج باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes
1. كتابة العرض المعدل كملف PPTX

في المثال المقدم أدناه، أضفنا إهليلج إلى الشريحة الأولى.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Write the PPTX file to disk
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **إنشاء إهليلج منسق**
لإضافة إهليلج منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع إهليلج باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes.
1. تعيين نوع التعبئة للإهليلج إلى صلب.
1. تعيين لون الإهليلج باستخدام خاصية SolidFillColor.Color المعروضة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط الإهليلج.
1. تعيين عرض خطوط الإهليلج.
1. كتابة العرض المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا إهليلج منسق إلى الشريحة الأولى من العرض.

```c#
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add autoshape of ellipse type
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Apply some formatting to the line of Ellipse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write the PPTX file to disk
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```