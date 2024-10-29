---
title: خط
type: docs
weight: 50
url: /ar/net/Line/
keywords: "خط، شكل PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة خط في عرض PowerPoint باستخدام C# أو .NET"
---

تدعم Aspose.Slides لـ .NET إضافة أنواع مختلفة من الأشكال إلى الشريحة. في هذا الموضوع، سنبدأ العمل مع الأشكال من خلال إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides لـ .NET، يمكن للمطورين إنشاء خطوط بسيطة، ولكن يمكن أيضًا رسم بعض الخطوط الفاخرة على الشرائح.
## **إنشاء خط عادي**
لإضافة خط عادي بسيط إلى الشريحة المحددة من العرض، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) الطريقة المعرضة من قبل كائن Shapes.
- كتابة العرض المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.

```c#
// إنشاء مثيل من PresentationEx class الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من نوع الخط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // كتابة ملف PPTX إلى القرص
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء خط بشكل سهم**
تتيح Aspose.Slides لـ .NET أيضًا للمطورين تكوين بعض خصائص الخط لجعله يبدو أكثر جاذبية. لنحاول تكوين بعض الخصائص لنجعل الخط يبدو كأنه سهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من نوع الخط باستخدام طريقة AddAutoShape المعرضة من قبل كائن Shapes.
- تعيين نمط الخط إلى أحد الأنماط المعروضة من قبل Aspose.Slides لـ .NET.
- تعيين عرض الخط.
- تعيين [نمط الخط المنقط](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المعروضة من قبل Aspose.Slides لـ .NET.
- تعيين [نمط رأس السهم](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) وطول نقطة البداية للخط.
- تعيين نمط رأس السهم وطول نقطة النهاية للخط.
- كتابة العرض المعدل كملف PPTX.

```c#
// إنشاء مثيل من PresentationEx class الذي يمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من نوع الخط
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // تطبيق بعض التنسيقات على الخط
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // كتابة ملف PPTX إلى القرص
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```