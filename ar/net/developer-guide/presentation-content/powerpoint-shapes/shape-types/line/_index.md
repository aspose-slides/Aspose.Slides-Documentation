---
title: إضافة أشكال الخط إلى العروض التقديمية في .NET
linktitle: خط
type: docs
weight: 50
url: /ar/net/Line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط بسيط
- تكوين الخط
- تخصيص الخط
- نمط متقطع
- رأس السهم
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET. اكتشف الخصائص والطرق والأمثلة."
---

Aspose.Slides for .NET يدعم إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال بإضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for .NET، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم خطوط مزخرفة على الشرائح.
## **Create Plain Line**
لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام فهرسها Index.
- إضافة AutoShape من النوع Line باستخدام طريقة [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) المعروضة بواسطة كائن Shapes.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
 using (Presentation pres = new Presentation())
 {
     // الحصول على الشريحة الأولى
     ISlide sld = pres.Slides[0];

     // إضافة AutoShape من النوع خط
     sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

     // حفظ ملف PPTX إلى القرص
     pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
 }
```



## **Create Arrow Shaped Line**
Aspose.Slides for .NET يسمح أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. لنحاول تكوين بعض الخصائص للخط لجعله يبدو كسهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثال من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- الحصول على مرجع الشريحة باستخدام فهرسها Index.
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes.
- تعيين نمط الخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) وطول نقطة البداية للخط.
- تعيين نمط رأس السهم وطول نقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.
```c#
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من النوع خط
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


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) type and the [corresponding APIs](/slides/ar/net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/ar/net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) that let you [disallow editing operations](/slides/ar/net/applying-protection-to-presentation/).