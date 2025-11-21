---
title: خط
type: docs
weight: 50
url: /ar/net/Line/
keywords: "خط, شكل PowerPoint, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة خط في عرض PowerPoint باستخدام C# أو .NET"
---


Aspose.Slides for .NET يدعم إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال بإضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for .NET، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم بعض الخطوط المتفوقة على الشرائح.

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من النوع Line باستخدام الطريقة [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) التي يقدمها كائن Shapes.
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

```c#
// إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع خط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // كتابة ملف PPTX إلى القرص
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء خط على شكل سهم**

Aspose.Slides for .NET يسمح أيضًا للمطورين بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض الخصائص لجعل الخط يبدو كسهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثيل من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة AutoShape من النوع Line باستخدام الطريقة AddAutoShape التي يقدمها كائن Shapes.
- ضبط نمط الخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- ضبط عرض الخط.
- ضبط [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) والطول لنقطة البداية للخط.
- ضبط نمط رأس السهم والطول لنقطة النهاية للخط.
- حفظ العرض التقديمي المعدل كملف PPTX.

```c#
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع خط
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


## **الأسئلة المتكررة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتقط" الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) واستخدم [الـ APIs المقابلة](/slides/ar/net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ومن الصعب تحديد القيم النهائية؟**

اقرأ الخصائص الفعالة عبر الفئات [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — هذه الفئات تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل الخط لمنعه من التحرير (التحريك، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات القفل [autoshapelock](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) التي تسمح لك بـ [منع عمليات التحرير](/slides/ar/net/applying-protection-to-presentation/).