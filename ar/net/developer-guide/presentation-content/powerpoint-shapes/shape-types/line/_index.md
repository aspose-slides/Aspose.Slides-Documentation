---
title: إضافة أشكال الخط إلى العروض التقديمية في .NET
linktitle: خط
type: docs
weight: 50
url: /ar/net/line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين خط
- تخصيص خط
- نمط الشرطة
- رأس السهم
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET. اكتشف الخصائص والطرق والأمثلة."
---
## **نظرة عامة**

يتيح لك Aspose.Slides إضافة أشكال الخط إلى شرائح PowerPoint برمجيًا. تُظهر هذه المقالة كيفية إنشاء خط بسيط وكيفية تخصيص الخط ليظهر كسهم.

ستتعلم كيفية إضافة شكل خط إلى شريحة، وتعديل مظهره البصري، وحفظ العرض التقديمي المحدث. تركز الأمثلة على إعدادات تنسيق الخط العملية مثل النمط، العرض، نمط الشرطة، خيارات رأس السهم، ولون التعبئة.

## **إنشاء خط عادي**

لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من النوع Line باستخدام الطريقة [AddAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/methods/addautoshape/index) التي يوفرها كائن Shapes.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

```c#
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من النوع خط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //اكتب ملف PPTX إلى القرص
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **إنشاء خط على شكل سهم**

يتيح Aspose.Slides for .NET للمطورين أيضًا تكوين بعض خصائص الخط لجعله أكثر جاذبية. لنحاول تكوين بعض خصائص الخط لجعله يشبه السهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء نسخة من [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/ar/aspose.slides/)[](http://www.aspose.com/api/net/slides/ar/aspose.slides/).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape التي يوفرها كائن Shapes.
- تعيين نمط الخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- تعيين عرض الخط.
- تعيين [Dash Style](https://reference.aspose.com/slides/ar/net/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- تعيين [Arrow Head Style](https://reference.aspose.com/slides/ar/net/aspose.slides/linearrowheadstyle) وطول نقطة البداية للخط.
- تعيين نمط رأس السهم وطول نقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.

```c#
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
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

    //اكتب ملف PPTX إلى القرص
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/ar/net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم نوع [Connector](https://reference.aspose.com/slides/ar/net/aspose.slides/connector/) المخصص و[واجهات برمجة التطبيقات المقابلة](/slides/ar/net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط مُوروثة من المظهر وكان من الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/net/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأنماط المظهر.

**هل يمكنني قفل خط لمنع التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/ar/net/aspose.slides/autoshape/autoshapelock/) التي تسمح لك بـ[منع عمليات التحرير](/slides/ar/net/applying-protection-to-presentation/).